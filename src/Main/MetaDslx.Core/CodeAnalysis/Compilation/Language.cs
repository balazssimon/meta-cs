using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis
{
    public abstract class Language
    {
        public static readonly Language None = new NoLanguage();

        public abstract string Name { get; }

        public SyntaxFacts SyntaxFacts => this.SyntaxFactsCore;
        internal protected abstract SyntaxFacts SyntaxFactsCore { get; }
        public InternalSyntaxFactory InternalSyntaxFactory => this.InternalSyntaxFactoryCore;
        internal protected abstract InternalSyntaxFactory InternalSyntaxFactoryCore { get; }
        public SyntaxFactory SyntaxFactory => this.SyntaxFactoryCore;
        internal protected abstract SyntaxFactory SyntaxFactoryCore { get; }
        public CompilationFactory CompilationFactory => this.CompilationFactoryCore;
        internal protected abstract CompilationFactory CompilationFactoryCore { get; }
        public SymbolFacts SymbolFacts => this.SymbolFactsCore;
        internal protected abstract SymbolFacts SymbolFactsCore { get; }
    }

    internal class NoLanguage : Language
    {
        public override string Name => string.Empty;

        protected internal override SyntaxFacts SyntaxFactsCore => throw new NotImplementedException();

        protected internal override InternalSyntaxFactory InternalSyntaxFactoryCore => throw new NotImplementedException();

        protected internal override SyntaxFactory SyntaxFactoryCore => throw new NotImplementedException();

        protected internal override CompilationFactory CompilationFactoryCore => throw new NotImplementedException();

        protected internal override SymbolFacts SymbolFactsCore => throw new NotImplementedException();

    }
}
