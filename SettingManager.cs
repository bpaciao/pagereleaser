using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PageReleaser
{
    public class SettingManager
    {
        string _base;
        public string PageName { get; set; }
        public string OutputPath { get; set; }

        public bool IsJavaScriptCombine { get; set; }
        public bool IsJavaScriptCompress { get; set; }
        public bool IsJavaScriptEmbed { get; set; }

        public bool IsCssCombine { get; set; }
        public bool IsCssCompress { get; set; }
        public bool IsCssEmbed { get; set; }

        public bool IgnoreRemoteFile { get; set; }

        public SettingManager(string html, string output)
        {
            PageName = html;

            html = System.IO.Path.GetDirectoryName(html);
            if (!html.EndsWith("\\"))
                html += '\\';
            _base = html;

            if (!output.EndsWith("\\"))
                output += '\\';
            OutputPath = output;

            IsJavaScriptCombine = true;
            IsJavaScriptCompress = true;
            IsJavaScriptEmbed = false;
            IgnoreRemoteFile = true;
        }

        public System.IO.TextReader GetTextReader(string uri)
        {
            if ( IsRemoteFile( uri ) )
            {
                System.Net.WebRequest request = System.Net.HttpWebRequest.Create(uri);
                System.Net.WebResponse response = request.GetResponse();
                System.IO.Stream stream = response.GetResponseStream();
                return new System.IO.StreamReader(stream);
            }

            return new System.IO.StreamReader( _base + uri, System.Text.Encoding.Default );
        }

        public System.IO.TextWriter GetTextWriter(string uri)
        {
            return new System.IO.StreamWriter(OutputPath + uri, false, System.Text.Encoding.Default);
        }

        public bool IsRemoteFile( string uri )
        {
            return uri.IndexOf("://") > 0;
        }
    }
}
