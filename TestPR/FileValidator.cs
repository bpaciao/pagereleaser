using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jeebook.PageReleaser;

namespace TestPR
{
    class FileValidator
    {
        string _path = "";
        bool _bSame = true;
        List<string> _list = new List<string>();

        public FileValidator(string path, bool bSame)
        {
            _path = path;
            _bSame = bSame;
        }

        public void Add(string strFilename, bool bRelative)
        {
            string fn = strFilename;
            if (bRelative)
            {
                UriResolver ur = new UriResolver(_path, true);
                fn = ur.ToAbsolute(strFilename);
            }

            _list.Add(fn);
        }

        public bool Validate()
        {
            List<string> list = new List<string>();
            GetAllDirList(_path, list);

            if (_bSame && list.Count != _list.Count)
                return false;

            for (int i = 0; i < _list.Count; i++)
            {
                if (!Exist(list, _list[i]))
                    return false;
            }
            return true;
        }

        private bool Exist(List<string> list, string s)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == s)
                    return true;
            }
            return false;
        }

        public void GetAllDirList(string strBaseDir, List<string> list)
        {
            list.AddRange(System.IO.Directory.GetFiles( strBaseDir ) );

            string[] dirs = System.IO.Directory.GetDirectories( strBaseDir );
            for (int i = 0; i < dirs.Length; i++)
            {
                GetAllDirList(dirs[i], list);
            }
        }
    }
}
