using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Globalization;

namespace PageReleaser
{
    public class SettingManager
    {
        private bool _isHtmlCompress = true;
        private bool _isHtmlGZip = false;

        private bool _isJavaScriptCompress = true;
        private bool _isJavaScriptCombine = true;
        private bool _isJavaScriptEmbed = false;
        private bool _isJavaScriptGZip = false;

        private bool _isCssCompress = true;
        private bool _isCssCombine = true;
        private bool _isCssEmbed = false;
        private bool _isCssGZip = false;

        private bool _isImageCombine = true;

        private bool _ignoreRemoteFile = true;
        private bool _ignoreParentFolder = true;

        [BrowsableAttribute(false)]
        public string PageName { get; set; }

        [BrowsableAttribute(false)]
        public string OutputPath { get; set; }

        [CategoryAttribute("HTML"), DisplayNameAttribute("Compress"), DefaultValueAttribute(true)]
        public bool IsHtmlCompress { get { return _isHtmlCompress; } set { _isHtmlCompress = value; } }

        [CategoryAttribute("HTML"), DisplayNameAttribute("GZip"), DefaultValueAttribute(false), ReadOnlyAttribute(true)]
        public bool IsHtmlGZip { get { return _isHtmlGZip; } set { _isHtmlGZip = value; } }

        [CategoryAttribute("JavaScript"), DisplayNameAttribute("Combine"), DefaultValueAttribute(true)]
        public bool IsJavaScriptCombine { get { return _isJavaScriptCombine; } set { _isJavaScriptCombine = value; } }

        [CategoryAttribute("JavaScript"), DisplayNameAttribute("Compress"), DefaultValueAttribute(true)]
        public bool IsJavaScriptCompress { get { return _isJavaScriptCompress; } set { _isJavaScriptCompress = value; } }

        [CategoryAttribute("JavaScript"), DisplayNameAttribute("Embed"), DefaultValueAttribute(false)]
        public bool IsJavaScriptEmbed { get { return _isJavaScriptEmbed; } set { _isJavaScriptEmbed = value; } }

        [CategoryAttribute("JavaScript"), DisplayNameAttribute("GZip"), DefaultValueAttribute(false), ReadOnlyAttribute(true)]
        public bool IsJavaScriptGZip { get { return _isJavaScriptGZip; } set { _isJavaScriptGZip = value; } }

        [CategoryAttribute("CSS"), DisplayNameAttribute("Combine"), DefaultValueAttribute(true)]
        public bool IsCssCombine { get { return _isCssCombine; } set { _isCssCombine = value; } }

        [CategoryAttribute("CSS"), DisplayNameAttribute("Compress"), DefaultValueAttribute(true)]
        public bool IsCssCompress { get { return _isCssCompress; } set { _isCssCompress = value; } }

        [CategoryAttribute("CSS"), DisplayNameAttribute("Embed"), DefaultValueAttribute(false)]
        public bool IsCssEmbed { get { return _isCssEmbed; } set { _isCssEmbed = value; } }

        [CategoryAttribute("CSS"), DisplayNameAttribute("GZip"), DefaultValueAttribute(false), ReadOnlyAttribute(true)]
        public bool IsCssGZip { get { return _isCssGZip; } set { _isCssGZip = value; } }

        [CategoryAttribute("Image"), DisplayNameAttribute("Combine"), ReadOnlyAttribute(true)]
        public bool IsImageCombine { get { return _isImageCombine; } set { _isImageCombine = value; } }

        [DefaultValueAttribute(true)]
        public bool IgnoreRemoteFile { get { return _ignoreRemoteFile; } set { _ignoreRemoteFile = value; } }

        [DefaultValueAttribute(true)]
        public bool IgnoreParentFolder { get { return _ignoreParentFolder; } set { _ignoreParentFolder = value; } }

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
