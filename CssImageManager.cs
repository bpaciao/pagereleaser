using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BoneSoft.CSS;

namespace PageReleaser
{
    class CssImageInfo
    {
        public Term Term { get; set; }
        public UriResolver SourceUriResolver { get; set; }
        public UriResolver TargetUriResolver { get; set; }
    }

    class CssImageManager
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
    }
}
