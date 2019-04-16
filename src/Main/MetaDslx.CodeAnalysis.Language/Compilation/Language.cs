using Microsoft.CodeAnalysis.CSharp.Symbols;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.CodeAnalysis
{
    public abstract class Language
    {
        public static readonly Language None = new NoLanguage();

        public abstract string Name { get; }

        public SyntaxFacts SyntaxFacts => this.SyntaxFactsCore;
        internal protected abstract SyntaxFacts SyntaxFactsCore { get; }
        public LookupPosition LookupPosition => this.LookupPositionCore;
        internal protected abstract LookupPosition LookupPositionCore { get; }
        public InternalSyntaxFactory InternalSyntaxFactory => this.InternalSyntaxFactoryCore;
        internal protected abstract InternalSyntaxFactory InternalSyntaxFactoryCore { get; }
        public SyntaxFactory SyntaxFactory => this.SyntaxFactoryCore;
        internal protected abstract SyntaxFactory SyntaxFactoryCore { get; }
        public CSharp.SymbolDisplay SymbolDisplay => this.SymbolDisplayCore;
        internal protected virtual CSharp.SymbolDisplay SymbolDisplayCore { get; } = new CSharp.SymbolDisplay();
        public CSharp.Symbols.SymbolFacts SymbolFacts => this.SymbolFactsCore;
        internal protected abstract CSharp.Symbols.SymbolFacts SymbolFactsCore { get; }
    }

    internal class NoLanguage : Language
    {
        public override string Name => string.Empty;

        protected internal override SyntaxFacts SyntaxFactsCore => throw new NotImplementedException();

        protected internal override LookupPosition LookupPositionCore => throw new NotImplementedException();

        protected internal override InternalSyntaxFactory InternalSyntaxFactoryCore => throw new NotImplementedException();

        protected internal override SyntaxFactory SyntaxFactoryCore => throw new NotImplementedException();

        protected internal override SymbolFacts SymbolFactsCore => throw new NotImplementedException();
    }
}
