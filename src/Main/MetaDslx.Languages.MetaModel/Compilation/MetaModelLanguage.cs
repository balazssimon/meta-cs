using MetaDslx.Languages.MetaModel.Syntax;
using MetaDslx.Languages.MetaModel.Syntax.InternalSyntax;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using System;
using System.Diagnostics;
using MetaDslx.Languages.MetaModel.Symbols;
using MetaDslx.CodeAnalysis.Symbols;

namespace MetaDslx.Languages.MetaModel
{
    public sealed class MetaModelLanguage : Language
    {
        public static readonly MetaModelLanguage Instance = new MetaModelLanguage();

        public override string Name => throw new NotImplementedException();

        public new MetaModelSyntaxFacts SyntaxFacts => (MetaModelSyntaxFacts)this.SyntaxFactsCore;
        protected override SyntaxFacts SyntaxFactsCore => new MetaModelSyntaxFacts();

        public new MetaModelSymbolFacts SymbolFacts => (MetaModelSymbolFacts)this.SymbolFactsCore;
        protected override SymbolFacts SymbolFactsCore => new MetaModelSymbolFacts();

        public new MetaModelLookupPosition LookupPosition => (MetaModelLookupPosition)this.LookupPositionCore;
        protected override LookupPosition LookupPositionCore => new MetaModelLookupPosition();

        internal new MetaModelInternalSyntaxFactory InternalSyntaxFactory => (MetaModelInternalSyntaxFactory)this.InternalSyntaxFactoryCore;
        protected override InternalSyntaxFactory InternalSyntaxFactoryCore => new MetaModelInternalSyntaxFactory();

        public new MetaModelSyntaxFactory SyntaxFactory => (MetaModelSyntaxFactory)this.SyntaxFactoryCore;
        protected override SyntaxFactory SyntaxFactoryCore => new MetaModelSyntaxFactory();

        public new MetaModelCompilationFactory CompilationFactory => (MetaModelCompilationFactory)this.CompilationFactoryCore;
        protected override CompilationFactory CompilationFactoryCore => new MetaModelCompilationFactory();
    }
}
