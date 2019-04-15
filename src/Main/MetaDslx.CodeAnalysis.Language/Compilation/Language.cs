using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.CodeAnalysis
{
    public abstract class Language
    {
        public abstract string Name { get; }

        public SyntaxFacts SyntaxFacts => this.SyntaxFactsCore;
        internal protected abstract SyntaxFacts SyntaxFactsCore { get; }
        public InternalSyntaxFactory InternalSyntaxFactory => this.InternalSyntaxFactoryCore;
        internal protected abstract InternalSyntaxFactory InternalSyntaxFactoryCore { get; }
        public SyntaxFactory SyntaxFactory => this.SyntaxFactoryCore;
        internal protected abstract SyntaxFactory SyntaxFactoryCore { get; }
    }
}
