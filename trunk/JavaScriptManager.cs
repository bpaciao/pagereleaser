using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace PageReleaser
{
    class JavaScriptInfo
    {
        public string Value { get; set; }
        public XElement Element { get; set; }
    }

    class JavaScriptManager
    {
        SettingManager _sm;
        System.Collections.Generic.List<JavaScriptInfo> _jsElements = new List<JavaScriptInfo>();
        public JavaScriptManager(SettingManager sm)
        {
            _sm = sm;
        }

        public void Add(XElement xe)
        {
            if (_sm.IgnoreRemoteFile && _sm.IsRemoteFile(xe.Attribute("src").Value))
                return;

            JavaScriptInfo jsi = new JavaScriptInfo();
            jsi.Element = xe;

            System.IO.TextReader sr = _sm.GetTextReader(xe.Attribute("src").Value);
            jsi.Value = sr.ReadToEnd() + "\r\n";
            sr.Close();

           _jsElements.Add( jsi );
        }

        public void JSMin()
        {
            if (0 == _jsElements.Count)
                return;

            if (_sm.IsJavaScriptCombine && _jsElements.Count > 1)
            {
                // combine js files
                StringBuilder sb = new StringBuilder();
                foreach (JavaScriptInfo jsi in _jsElements)
                    sb.Append(jsi.Value);

                //
                JavaScriptInfo js = _jsElements[0];
                js.Value = sb.ToString();
                js.Element.Attribute("src").Value = "index.js";
                _jsElements.Remove(js);
                foreach (JavaScriptInfo jsi in _jsElements)
                    jsi.Element.Remove();

                _jsElements.Clear();
                _jsElements.Add(js);
            }

            if (_sm.IsJavaScriptCompress)
            {
                // compress js
                foreach (JavaScriptInfo jsi in _jsElements)
                {
                    StringBuilder sb = new StringBuilder();
                    JavaScriptSupport.JavaScriptMinifier jsmin = new JavaScriptSupport.JavaScriptMinifier();
                    jsmin.MinifyString(jsi.Value, sb);
                    jsi.Value = sb.ToString();
                }
            }

            if (_sm.IsJavaScriptEmbed)
            {
                // embed js in html
                StringBuilder sb = new StringBuilder();
                sb.Append("\r\n");
                foreach (JavaScriptInfo jsi in _jsElements)
                    sb.Append( jsi.Value );
                sb.Append("\r\n");

                JavaScriptInfo js = _jsElements[0];
                _jsElements.Remove(js);
                js.Element.Attribute("src").Remove();
                js.Element.Add(new XComment(sb.ToString()));

                foreach (JavaScriptInfo jsi in _jsElements)
                    jsi.Element.Remove();
                _jsElements.Clear();
            }

            // save js 
            foreach (JavaScriptInfo jsi in _jsElements)
            {
                System.IO.StreamWriter sw = new System.IO.StreamWriter(_sm.OutputPath + jsi.Element.Attribute("src").Value);
                sw.Write(jsi.Value);
                sw.Close();
            }
        }
    }
}
