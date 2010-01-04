using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PageReleaser
{
    public class SettingManager
    {
        public string PageName { get; set; }
        public string OutputPath { get; set; }

        public bool IsHtmlCompress { get; set; }

        public bool IsJavaScriptCombine { get; set; }
        public bool IsJavaScriptCompress { get; set; }
        public bool IsJavaScriptEmbed { get; set; }

        public bool IsCssCombine { get; set; }
        public bool IsCssCompress { get; set; }
        public bool IsCssEmbed { get; set; }

        public bool IgnoreRemoteFile { get; set; }
        public bool IsCurrentFolderAndSubsOnly { get; set; }

        public SettingManager(string html, string output)
        {
            PageName = html;
            OutputPath = output;

            IsJavaScriptCombine = true;
            IsJavaScriptCompress = true;
            IsJavaScriptEmbed = false;
            IgnoreRemoteFile = true;
        }

        public System.IO.Stream GetTextStream(string uri)
        {
            if (IsRemoteFile(uri))
            {
                System.Net.WebRequest request = System.Net.HttpWebRequest.Create(uri);
                System.Net.WebResponse response = request.GetResponse();
                return response.GetResponseStream();
            }

            return new System.IO.FileStream(uri, System.IO.FileMode.Open);
        }

        public System.IO.TextReader GetTextReader(string uri)
        {
            return new System.IO.StreamReader(GetTextStream(uri), System.Text.Encoding.Default); 
        }

        public System.IO.TextWriter GetTextWriter(string uri)
        {
            string strPath = System.IO.Path.GetDirectoryName(uri);
            if (!System.IO.Directory.Exists(strPath))
                System.IO.Directory.CreateDirectory(strPath);

            return new System.IO.StreamWriter(uri, false, System.Text.Encoding.Default);
        }

        public bool IsRemoteFile( string uri )
        {
            return uri.IndexOf("://") > 0;
        }
    }
}
