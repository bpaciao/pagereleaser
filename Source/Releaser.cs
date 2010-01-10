using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace PageReleaser
{
    class Releaser
    {
        public void Release(SettingManager sm)
        {
            // to xhtml
            System.IO.StreamReader sr = new System.IO.StreamReader(sm.PageName);
            string xhtml = Html2XHtml(sr.ReadToEnd());
            sr.Close();

            // parse xhtml
            XmlReaderSettings xrs = new XmlReaderSettings();
            xrs.XmlResolver = new XHTMLResolver();
            xrs.ProhibitDtd = false;

            XDocument doc = XDocument.Load(XmlReader.Create(new System.IO.StringReader(xhtml), xrs) );

            //
            UriResolver SourceUriResolver = new UriResolver( sm.PageName, false );
            UriResolver TargetUriResolver = new UriResolver(sm.OutputPath, true);

            // init js manager
            JavaScriptManager jsm = new JavaScriptManager( sm );
            var js = from s in doc.Descendants()
                     where string.Compare( s.Name.LocalName, "script", true ) == 0 && 
                     string.Compare( s.Attribute("type").Value, "text/javascript", true ) == 0 &&
                     s.Attribute("src") != null 
                     select s;
            foreach ( XElement xe in js )
                jsm.Add(xe, SourceUriResolver, TargetUriResolver);
            jsm.JSMin();
            
            // init css manager
            CssManager cm = new CssManager(sm);
            var css = from s in doc.Descendants()
                     where string.Compare( s.Name.LocalName, "link", true ) == 0 &&
                     string.Compare( s.Attribute("type").Value, "text/css", true ) == 0 &&
                     string.Compare( s.Attribute("rel").Value, "stylesheet", true ) == 0 &&
                     s.Attribute("href") != null
                     select s;
            foreach (XElement xe in css)
                cm.Add(xe, SourceUriResolver, TargetUriResolver);
            cm.CssMin();

            // init image manager

            // save html
            if ( !sm.IsHtmlCompress )
                doc.Save(TargetUriResolver.ToAbsolute( "index.html" ) );
            else
            {
                var nodes = from s in doc.DescendantNodes()
                           where s.NodeType == XmlNodeType.Comment &&
                           string.Compare( s.Parent.Name.LocalName, "script", true ) != 0
                           select s;

                nodes.Remove();
                doc.Save( TargetUriResolver.ToAbsolute("index.html"), SaveOptions.DisableFormatting );
            }
        }

        public static string Html2XHtml(string strHtml)
        {
            TidyNet.Tidy tidy = new TidyNet.Tidy();

            /* Set the options you want */
            tidy.Options.Xhtml = true;
            tidy.Options.XmlOut = true;
            tidy.Options.MakeClean = true;
            tidy.Options.CharEncoding = TidyNet.CharEncoding.UTF8;

            /* Declare the parameters that is needed */
            System.IO.MemoryStream input = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(strHtml));
            System.IO.MemoryStream output = new System.IO.MemoryStream();
            tidy.Parse(input, output, new TidyNet.TidyMessageCollection());

            return System.Text.Encoding.UTF8.GetString(output.ToArray());
        }
    }
}
