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
        public string Uri { get; set; }
        public CSSDocument CSS { get; set; }
        public XElement Element { get; set; }
    }

    class CssManager
    {
        SettingManager _sm = null;
        System.Collections.Generic.List<CssInfo> _cssElements = new List<CssInfo>();

        public CssManager(SettingManager sm)
        {
            _sm = sm;
        }

        public void Add(XElement xe)
        {
            string uri = SettingManager.GetAbsolutePath(_sm.PageName, xe.Attribute("href").Value);
            if (_sm.IgnoreRemoteFile && _sm.IsRemoteFile(uri))
                return;

            CssInfo ci = new CssInfo();
            ci.Element = xe;
            ci.Uri = uri;

            CSSParser parser = new CSSParser();
            ci.CSS = parser.ParseStream( _sm.GetTextStream(ci.Uri));

            _cssElements.Add(ci);
        }

        public void Add(string uri)
        {
            if (_sm.IgnoreRemoteFile && _sm.IsRemoteFile(uri))
                return;

            CssInfo ci = new CssInfo();
            ci.Uri = uri;
            ci.Element = null;

            CSSParser parser = new CSSParser();
            ci.CSS = parser.ParseStream(_sm.GetTextStream(uri));

            _cssElements.Add(ci);
        }

        public void CssMin()
        {
            if (0 == _cssElements.Count)
                return;

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
                System.IO.StreamWriter sw = new System.IO.StreamWriter(css.Uri);
                sw.Write(CSSRenderer.Render(css.CSS, _sm.IsCssCompress));
                sw.Close();
            }
        }
    }
}
