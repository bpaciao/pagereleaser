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

            return new System.IO.FileStream( GetAbsolutePath( PageName, uri ), System.IO.FileMode.Open );
        }

        public System.IO.TextReader GetTextReader(string uri)
        {
            return new System.IO.StreamReader(GetTextStream(uri), System.Text.Encoding.Default); 
        }

        public System.IO.TextWriter GetTextWriter(string uri)
        {
            return new System.IO.StreamWriter(OutputPath + uri, false, System.Text.Encoding.Default);
        }

        public bool IsRemoteFile( string uri )
        {
            return uri.IndexOf("://") > 0;
        }

        /// <summary>
        /// 计算绝对路径
        /// </summary>
        /// <param name="absoluteDir">绝对目录</param>
        /// <param name="relativeFile">相对文件</param>
        /// <returns></returns>
        /// <example>
        /// @"D:\Windows\regedit.exe" = GetAbsolutePath(@"D:\Windows\Web\Wallpaper\", @"..\..\regedit.exe" );
        /// </example>
        public static string GetAbsolutePath(string absoluteDir, string relativeFile)
        {
            bool isNotOver = true;
            int intStart = 0;
            while (isNotOver)
            {
                if (relativeFile.StartsWith(@"..\"))
                {
                    relativeFile = relativeFile.Remove(0, 3);
                    intStart++;
                }
                else
                {
                    isNotOver = false;
                }
            }

            if (intStart > 0)
            {
                if (absoluteDir.EndsWith("\\"))
                {
                    absoluteDir = absoluteDir.Remove(absoluteDir.Length - 1);
                }

                for (int i = 0; i < intStart; i++)
                {
                    absoluteDir = absoluteDir.Remove(absoluteDir.LastIndexOf("\\"));
                }
            }
            return System.IO.Path.Combine(absoluteDir, relativeFile);
        }

        /// <summary>
        /// 计算相对路径
        /// 后者相对前者的路径。
        /// </summary>
        /// <param name="mainDir">主目录</param>
        /// <param name="fullFilePath">文件的绝对路径</param>
        /// <returns>fullFilePath相对于mainDir的路径</returns>
        /// <example>
        /// @"..\..\regedit.exe" = GetRelativePath(@"D:\Windows\Web\Wallpaper\", @"D:\Windows\regedit.exe" );
        /// </example>
        public static string GetRelativePath(string mainDir, string fullFilePath)
        {
            if (!mainDir.EndsWith("\\"))
            {
                mainDir += "\\";
            }

            int intIndex = -1, intPos = mainDir.IndexOf('\\');

            while (intPos >= 0)
            {
                intPos++;
                if (string.Compare(mainDir, 0, fullFilePath, 0, intPos, true) != 0) break;
                intIndex = intPos;
                intPos = mainDir.IndexOf('\\', intPos);
            }

            if (intIndex >= 0)
            {
                fullFilePath = fullFilePath.Substring(intIndex);
                intPos = mainDir.IndexOf("\\", intIndex);
                while (intPos >= 0)
                {
                    fullFilePath = "..\\" + fullFilePath;
                    intPos = mainDir.IndexOf("\\", intPos + 1);
                }
            }

            return fullFilePath;
        }
    }
}
