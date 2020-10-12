using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using MetaDslx.CodeAnalysis.Syntax;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax
{
    public abstract class IncrementalParser : Parser
    {
        internal Antlr4SyntaxParser _incrementalParser;

        public IncrementalParser(ITokenStream input, TextWriter output, TextWriter errorOutput)
            : base(input, output, errorOutput)
        {
        }

        protected Antlr4SyntaxParser IncrementalAntlr4Parser => _incrementalParser;

    }
}
