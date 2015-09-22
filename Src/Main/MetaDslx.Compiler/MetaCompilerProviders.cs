using Antlr4.Runtime.Tree;
using MetaDslx.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MetaDslx.Compiler
{
    public class Antlr4DefaultNameProvider : DefaultNameProvider
    {
        public override string GetName(object node)
        {
            IParseTree parseTree = node as IParseTree;
            if (parseTree == null) return null;
            string name = parseTree.GetText();
            if (name != null && name.StartsWith("@")) name = name.Substring(1);
            return name;
        }

        public override object GetValue(object node)
        {
            IParseTree parseTree = node as IParseTree;
            if (parseTree == null) return null;
            string text = parseTree.GetText();
            if (text == "null") return null;
            if (text == "true") return true;
            if (text == "false") return false;
            if (text.Length >= 2 && text.StartsWith("\"") && text.EndsWith("\""))
            {
                return Regex.Unescape(text.Substring(1, text.Length - 2));
            }
            return parseTree.GetText();
        }

        public override TextSpan GetTreeNodeTextSpan(object node)
        {
            return new Antlr4TextSpan(node);
        }
    }

}
