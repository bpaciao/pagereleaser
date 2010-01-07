using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using BoneSoft.CSS;

namespace PageReleaser
{
    class CssInfo
    {
        public XElement Element { get; set; }
        public CSSDocument CSS { get; set; }
        public UriResolver SourceUriResolver { get; set; }
        public UriResolver TargetUriResolver { get; set; }
    }

    class CssManager
    {
        SettingManager _sm = null;
        CssImageManager _cim = null;
        System.Collections.Generic.List<CssInfo> _cssElements = new List<CssInfo>();

        public CssManager(SettingManager sm)
        {
            _sm = sm;
            _cim = new CssImageManager(sm);
        }

        public void Add(XElement xe, UriResolver urSource, UriResolver urTarget )
        {
            string uri = urSource.ToAbsolute( xe.Attribute("href").Value );
            if (_sm.IgnoreRemoteFile && _sm.IsCssCombine && _sm.IsRemoteFile(uri))
                return;

            CssInfo ci = new CssInfo();
            ci.Element = xe;
            ci.SourceUriResolver = urSource;
            ci.TargetUriResolver = urTarget;

            CSSParser parser = new CSSParser();
            ci.CSS = parser.ParseStream( _sm.GetTextStream(uri));
            _cssElements.Add(ci);

            //
            UriResolver SourceUriResolver = new UriResolver(uri, false);
            UriResolver TargetUriResolver = new UriResolver(urTarget.ToAbsolute("images\\"), true);

            _cim.AddFromCSS(ci.CSS, SourceUriResolver, TargetUriResolver);
        }

        public void CssMin()
        {
            if (0 == _cssElements.Count)
                return;

            _cim.ImageMin();

            if (_cssElements.Count > 1 && (_sm.IsCssCombine || _sm.IsCssEmbed ))
            {
                // combine css files
                CssInfo css = _cssElements[0];
                for (int i = 1; i < _cssElements.Count; i++)
                {
                    css.CSS.Directives.AddRange(_cssElements[i].CSS.Directives);
                    css.CSS.RuleSets.AddRange(_cssElements[i].CSS.RuleSets);
                }
                css.Element.Attribute("href").Value = "index.css";
                _cssElements.Remove(css);
                foreach (CssInfo ci in _cssElements)
                    ci.Element.Remove();

                _cssElements.Clear();
                _cssElements.Add(css);
            }

            if (_sm.IsCssEmbed)
            {
                // embed css in html
                CssInfo css = _cssElements[0];
                _cssElements.Remove(css);
                css.Element.RemoveAll();
                css.Element.Name = css.Element.Name.Namespace + "style";
                css.Element.SetValue(CSSRenderer.Render( css.CSS, _sm.IsCssCompress ) );

                foreach (CssInfo ci in _cssElements)
                    ci.Element.Remove();
                _cssElements.Clear();
            }

            // save css 
            foreach (CssInfo css in _cssElements)
            {
                string uri = css.TargetUriResolver.ToAbsolute(css.Element.Attribute("href").Value);
                System.IO.TextWriter sw = _sm.GetTextWriter(uri);
                sw.Write(CSSRenderer.Render(css.CSS, _sm.IsCssCompress));
                sw.Close();
            }
        }
    }
}
