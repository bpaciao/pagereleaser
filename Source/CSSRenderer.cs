using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BoneSoft.CSS;

namespace PageReleaser
{
    static class CSSRenderer
    {
        public static string Render(CSSDocument css, bool bCompress)
        {
            if (!bCompress)
                return css.ToString();

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (Directive dr in css.Directives)
                RenderDirective(sb, dr);

            foreach (RuleSet rules in css.RuleSets)
                RenderRuleSet(sb, rules);

            return sb.ToString();
        }

        public static void RenderDirective(StringBuilder sb, Directive dir)
        {
            switch (dir.Type)
            {
                case DirectiveType.Charset: RenderDirectiveToCharSetString(sb, dir); return;
                case DirectiveType.Page: RenderDirectiveToPageString(sb, dir); return;
                case DirectiveType.Media: RenderDirectiveToMediaString(sb, dir); return;
                case DirectiveType.Import: RenderDirectiveToImportString(sb, dir); return;
                case DirectiveType.FontFace: RenderDirectiveToFontFaceString(sb, dir); return;
            }

            sb.AppendFormat("{0} ", dir.Name);

            if (dir.Expression != null) { 
                sb.AppendFormat("{0} ", dir.Expression); 
            }

            bool first = true;
            foreach (Medium m in dir.Mediums)
            {
                if (first)
                {
                    first = false;
                    sb.Append(" ");
                }
                else
                {
                    sb.Append(", ");
                }

                RenderMedium(sb, m);
            }

            bool HasBlock = (dir.Declarations.Count > 0 || dir.Directives.Count > 0 || dir.RuleSets.Count > 0);

            if (!HasBlock)
            {
                sb.Append(";");
                return;
            }

            foreach (Directive dr in dir.Directives)
                RenderDirectiveToCharSetString(sb, dr);

            foreach (RuleSet rules in dir.RuleSets)
                RenderRuleSet(sb, rules);

            first = true;
            foreach (Declaration dec in dir.Declarations)
            {
                if (first) { first = false; } else { sb.Append(";"); }
                RenderDeclaration(sb, dec);
            }

            sb.Append("}");
        }

        public static void RenderRuleSet(StringBuilder sb, RuleSet rs)
        {
            bool first = true;
            foreach (Selector sel in rs.Selectors)
            {
                if (first) { 
                    first = false; 
                } else { 
                    sb.Append(","); 
                }
                RenderSelector(sb, sel);
            }
            sb.Append("{");

            foreach (Declaration dec in rs.Declarations)
            {
                RenderDeclaration(sb, dec);
                sb.Append(";");
            }

            sb.Append("}");
        }

        public static void RenderSelector(StringBuilder sb, Selector sel)
        {
            bool first = true;
            foreach (SimpleSelector ss in sel.SimpleSelectors)
            {
                if (first) { 
                    first = false; 
                } else { 
                    sb.Append(" "); 
                }

                RenderSimpleSelector(sb, ss);
            }
        }

        public static void RenderSimpleSelector(StringBuilder sb, SimpleSelector sel)
        {
            if (sel.Combinator.HasValue)
            {
                switch (sel.Combinator.Value)
                {
                    case BoneSoft.CSS.Combinator.PrecededImmediatelyBy: sb.Append(" + "); break;
                    case BoneSoft.CSS.Combinator.ChildOf: sb.Append(" > "); break;
                    case BoneSoft.CSS.Combinator.PrecededBy: sb.Append(" ~ "); break;
                }
            }
            if (sel.ElementName != null) { 
                sb.Append(sel.ElementName); 
            }
            if (sel.ID != null) { 
                sb.AppendFormat("#{0}", sel.ID); 
            }
            if (sel.Class != null) { 
                sb.AppendFormat(".{0}", sel.Class);
            }
            if (sel.Pseudo != null) { 
                sb.AppendFormat(":{0}", sel.Pseudo); 
            }
            if (sel.Attribute != null)
            {
                RenderAttribute(sb, sel.Attribute);
            }
            if (sel.Function != null)
            {
                RenderFunction(sb, sel.Function);
            }
            if (sel.Child != null)
            {
                if (sel.Child.ElementName != null) { 
                    sb.Append(" "); 
                }
                RenderSimpleSelector(sb, sel.Child);
            }
        }

        public static void RenderTerm(StringBuilder sb, Term term)
        {
            if (term.Type == TermType.Function)
            {
                RenderFunction(sb, term.Function);
            }
            else if (term.Type == TermType.Url)
            {
                sb.AppendFormat("url('{0}')", term.Value);
            }
            else if (term.Type == TermType.Unicode)
            {
                sb.AppendFormat("U\\{0}", term.Value.ToUpper());
            }
            else if (term.Type == TermType.Hex)
            {
                sb.Append(term.Value.ToUpper());
            }
            else
            {
                if (term.Sign.HasValue) { 
                    sb.Append(term.Sign.Value); 
                }
                sb.Append(term.Value);
                if (term.Unit.HasValue)
                {
                    if (term.Unit.Value == BoneSoft.CSS.Unit.Percent)
                    {
                        sb.Append("%");
                    }
                    else
                    {
                        sb.Append(UnitOutput.ToString(term.Unit.Value));
                    }
                }
            }
        }

        public static void RenderFunction(StringBuilder sb, Function func)
        {
            sb.AppendFormat("{0}(", func.Name);
            if (func.Expression != null)
            {
                bool first = true;
                foreach (Term t in func.Expression.Terms)
                {
                    //if (t.Value.EndsWith("=")) {
                    if (first)
                    {
                        first = false;
                    }
                    else if (!t.Value.EndsWith("="))
                    {
                        sb.Append(",");
                    }

                    bool quoteMe = false;
                    if (t.Type == TermType.String && !t.Value.EndsWith("="))
                    {
                        quoteMe = true;
                    }
                    if (quoteMe) { 
                        sb.Append("'"); 
                    }
                    RenderTerm(sb, t);
                    if (quoteMe) { 
                        sb.Append("'"); 
                    }
                }
            }
            sb.Append(")");
        }

        public static void RenderAttribute(StringBuilder sb, BoneSoft.CSS.Attribute attr)
        {
            sb.AppendFormat("[{0}", attr.Operand);
            if (attr.Operator.HasValue)
            {
                switch (attr.Operator.Value)
                {
                    case AttributeOperator.Equals: sb.Append("="); break;
                    case AttributeOperator.InList: sb.Append("~="); break;
                    case AttributeOperator.Hyphenated: sb.Append("|="); break;
                    case AttributeOperator.BeginsWith: sb.Append("$="); break;
                    case AttributeOperator.EndsWith: sb.Append("^="); break;
                    case AttributeOperator.Contains: sb.Append("*="); break;
                }
                sb.Append(attr.Value);
            }
            sb.Append("]");
        }

        public static void RenderMedium(StringBuilder sb, Medium m)
        {
            sb.Append(m.ToString());
        }

        public static void RenderExpression(StringBuilder sb, Expression exp)
        {
            bool first = true;
            foreach (Term t in exp.Terms)
            {
                if (first)
                {
                    first = false;
                }
                else
                {
                    sb.AppendFormat("{0} ", t.Seperator.HasValue ? t.Seperator.Value.ToString() : "");
                }
                RenderTerm(sb, t);
            }
        }

        public static void RenderDeclaration(StringBuilder sb, Declaration decl)
        {
            sb.AppendFormat("{0}:", decl.Name);
            RenderExpression(sb, decl.Expression);
            if (decl.Important)
                sb.Append(" !important");
        }

        public static void RenderDirectiveToFontFaceString(StringBuilder sb, Directive dir)
        {
            sb.Append("@font-face {");

            bool first = true;
            foreach (Declaration dec in dir.Declarations)
            {
                if (first) { 
                    first = false; 
                } else { 
                    sb.Append(";"); 
                }
                RenderDeclaration(sb, dec);
            }

            sb.Append("}");
        }

        public static void RenderDirectiveToImportString(StringBuilder sb, Directive dir)
        {
            sb.Append("@import ");
            if (dir.Expression != null) { sb.AppendFormat("{0} ", dir.Expression); }
            bool first = true;
            foreach (Medium m in dir.Mediums)
            {
                if (first)
                {
                    first = false;
                    sb.Append(" ");
                }
                else
                {
                    sb.Append(", ");
                }
                RenderMedium(sb, m);
            }
            sb.Append(";");
        }

        public static void RenderDirectiveToMediaString(StringBuilder sb, Directive dir)
        {
            sb.Append("@media");

            bool first = true;
            foreach (Medium m in dir.Mediums)
            {
                if (first)
                {
                    first = false;
                    sb.Append(" ");
                }
                else
                {
                    sb.Append(", ");
                }
                RenderMedium(sb, m);
            }
            sb.Append("{");

            foreach (RuleSet rules in dir.RuleSets)
            {
                RenderRuleSet(sb, rules);
            }

            sb.Append("}");
        }

        public static void RenderDirectiveToPageString(StringBuilder sb, Directive dir)
        {
            sb.Append("@page ");
            if (dir.Expression != null) { sb.AppendFormat("{0} ", dir.Expression); }
            sb.Append("{");

            bool first = true;
            foreach (Declaration dec in dir.Declarations)
            {
                if (first) { 
                    first = false; 
                } else { 
                    sb.Append(";"); 
                }
                RenderDeclaration(sb, dec);
            }

            sb.Append("}");
        }

        public static void RenderDirectiveToCharSetString(StringBuilder sb, Directive dir)
        {
            sb.AppendFormat("{0} ", dir.Name);
            RenderExpression(sb, dir.Expression);
        }
    }
}
