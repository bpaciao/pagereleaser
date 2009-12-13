using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace PageReleaser
{
    class CssInfo
    {
        public string Value { get; set; }
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
            if (_sm.IgnoreRemoteFile && _sm.IsRemoteFile(xe.Attribute("href").Value))
                return;

            CssInfo ci = new CssInfo();
            ci.Element = xe;

            System.IO.TextReader sr = _sm.GetTextReader(xe.Attribute("href").Value);
            ci.Value = sr.ReadToEnd();
            sr.Close();

            _cssElements.Add(ci);
        }

        public void CssMin()
        {
            if (0 == _cssElements.Count)
                return;

            if (_sm.IsCssCombine && _cssElements.Count > 1)
            {
                // combine js files
                StringBuilder sb = new StringBuilder();
                foreach (CssInfo ci in _cssElements)
                    sb.Append(ci.Value);

                //
                CssInfo css = _cssElements[0];
                css.Value = sb.ToString();
                css.Element.Attribute("href").Value = "index.css";
                _cssElements.Remove(css);
                foreach (CssInfo ci in _cssElements)
                    ci.Element.Remove();

                _cssElements.Clear();
                _cssElements.Add(css);
            }

            if (_sm.IsCssCompress)
            {
                // compress js
                //foreach (CssInfo jsi in _jsElements)
                //{
                //    StringBuilder sb = new StringBuilder();
                //    JavaScriptSupport.JavaScriptMinifier jsmin = new JavaScriptSupport.JavaScriptMinifier();
                //    jsmin.MinifyString(jsi.Value, sb);
                //    jsi.Value = sb.ToString();
                //}
            }

            if (_sm.IsCssEmbed)
            {
                // embed js in html
                StringBuilder sb = new StringBuilder();
                foreach (CssInfo ci in _cssElements)
                    sb.Append( ci.Value );

                CssInfo css = _cssElements[0];
                _cssElements.Remove(css);
                css.Element.RemoveAll();
                css.Element.Name = css.Element.Name.Namespace + "style";
                css.Element.SetValue(sb.ToString());

                foreach (CssInfo ci in _cssElements)
                    ci.Element.Remove();
                _cssElements.Clear();
            }

            // save js 
            foreach (CssInfo jsi in _cssElements)
            {
                System.IO.StreamWriter sw = new System.IO.StreamWriter(_sm.OutputPath + jsi.Element.Attribute("href").Value);
                sw.Write(jsi.Value);
                sw.Close();
            }
        }
    }
}
