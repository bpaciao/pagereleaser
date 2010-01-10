using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PageReleaser
{
    class UriResolver
    {
        private string _baseUri = "";

        public UriResolver(string uri, bool bFolder)
        {
            if (bFolder)
            {
                _baseUri = uri;
                if (!_baseUri.EndsWith("\\"))
                    _baseUri += "\\";
            }
            else
                _baseUri = System.IO.Path.GetDirectoryName(uri);
        }
        
        public string ToAbsolute(string relativeUri)
        {
            if (relativeUri.IndexOf("://") >= 0)
                return relativeUri;

            bool isNotOver = true;
            int intStart = 0;
            while (isNotOver)
            {
                if (relativeUri.StartsWith(@"..\"))
                {
                    relativeUri = relativeUri.Remove(0, 3);
                    intStart++;
                }
                else
                {
                    isNotOver = false;
                }
            }

            if (intStart > 0)
            {
                if (_baseUri.EndsWith("\\"))
                {
                    _baseUri = _baseUri.Remove(_baseUri.Length - 1);
                }

                for (int i = 0; i < intStart; i++)
                {
                    _baseUri = _baseUri.Remove(_baseUri.LastIndexOf("\\"));
                }
            }
            return System.IO.Path.Combine(_baseUri, relativeUri);
        }

        public string ToRelative(string absoluteUri)
        {
            if (!_baseUri.EndsWith("\\"))
            {
                _baseUri += "\\";
            }

            int intIndex = -1, intPos = _baseUri.IndexOf('\\');

            while (intPos >= 0)
            {
                intPos++;
                if (string.Compare(_baseUri, 0, absoluteUri, 0, intPos, true) != 0) break;
                intIndex = intPos;
                intPos = _baseUri.IndexOf('\\', intPos);
            }

            if (intIndex >= 0)
            {
                absoluteUri = absoluteUri.Substring(intIndex);
                intPos = _baseUri.IndexOf("\\", intIndex);
                while (intPos >= 0)
                {
                    absoluteUri = "..\\" + absoluteUri;
                    intPos = _baseUri.IndexOf("\\", intPos + 1);
                }
            }

            return absoluteUri;
        }
    }
}
