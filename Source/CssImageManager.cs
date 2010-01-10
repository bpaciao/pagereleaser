using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BoneSoft.CSS;

namespace Jeebook.PageReleaser
{
    public class CssImageInfo
    {
        public Term Term { get; set; }
        public UriResolver SourceUriResolver { get; set; }
        public UriResolver TargetUriResolver { get; set; }
    }

    public class CssImageManager
    {
        SettingManager _sm = null;
        System.Collections.Generic.List<CssImageInfo> _ciiElements = new List<CssImageInfo>();

        public CssImageManager(SettingManager sm)
        {
            _sm = sm;
        }

        public void AddFromCSS(CSSDocument doc, UriResolver urSource, UriResolver urTarget )
        {
            foreach (RuleSet rs in doc.RuleSets)
            {
                foreach (Declaration decl in rs.Declarations)
                {
                    foreach (Term t in decl.Expression.Terms)
                    {
                        if (t.Type != TermType.Url)
                            continue;

                        CssImageInfo cii = new CssImageInfo();
                        cii.Term = t;
                        cii.SourceUriResolver = urSource;
                        cii.TargetUriResolver = urTarget;
                        _ciiElements.Add(cii); 
                    }
                }
            }
        }

        public void ImageMin()
        {
            if (_ciiElements.Count == 0)
                return;

            foreach (CssImageInfo cii in _ciiElements)
            {
                string uri = cii.SourceUriResolver.ToAbsolute(cii.Term.Value);
                if (!_sm.Validate(uri))
                    continue;

                string uriTar = cii.TargetUriResolver.ToAbsolute( System.IO.Path.GetFileName( uri ) );
                
                System.IO.Directory.CreateDirectory( System.IO.Path.GetDirectoryName( uriTar ) );
                if (System.IO.File.Exists(uri) && !System.IO.File.Exists(uriTar))
                    System.IO.File.Copy(uri, uriTar);

                cii.Term.Value = cii.TargetUriResolver.ToRelative(uriTar);
            }
        }
    }
}
