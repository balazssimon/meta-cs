using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.CodeAnalysis
{
    public abstract class Language
    {
        public abstract string Name { get; }
        public abstract SyntaxFacts SyntaxFacts { get; }
        public abstract CSharp.Syntax.InternalSyntax.SyntaxFactory InternalSyntaxFactory { get; }
        public abstract CSharp.Syntax.SyntaxFactory SyntaxFactory { get; }
    }
}
