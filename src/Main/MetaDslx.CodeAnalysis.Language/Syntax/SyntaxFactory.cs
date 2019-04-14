using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.CodeAnalysis.CSharp.Syntax
{
    public abstract class SyntaxFactory
    {
        public abstract SyntaxToken DefaultSeparator { get; }
        public abstract SyntaxNode CreateStructure(SyntaxTrivia trivia);
    }
}
