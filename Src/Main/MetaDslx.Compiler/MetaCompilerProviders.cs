using Antlr4.Runtime.Tree;
using MetaDslx.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler
{
    public class Antlr4DefaultNameProvider : DefaultNameProvider
    {
        public override string GetName(object node)
        {
            IParseTree parseTree = node as IParseTree;
            if (parseTree == null) return null;
            return parseTree.GetText();
        }

        public override object GetValue(object node)
        {
            IParseTree parseTree = node as IParseTree;
            if (parseTree == null) return null;
            return parseTree.GetText();
        }

        public override TextSpan GetTextSpan(object node)
        {
            return new Antlr4TextSpan(node);
        }
    }

}
