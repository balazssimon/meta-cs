// NOTE: This is an auto-generated file. However, it will not be regenerated. If you want it to be regenerated, just delete it.
using System;
using System.Diagnostics;
using System.Threading;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using MetaDslx.Languages.Meta.Symbols;
using MetaDslx.Languages.Meta.Syntax;
using MetaDslx.Languages.Meta.Syntax.InternalSyntax;

namespace MetaDslx.Languages.Meta
{
    public sealed class MetaLanguage : Language
    {
        public static readonly MetaLanguage Instance = new MetaLanguage();

        private MetaSyntaxFacts _syntaxFacts;
		private MetaSymbolFacts _symbolFacts;
		private MetaLookupPosition _lookupPosition;
		private MetaInternalSyntaxFactory _internalSyntaxFactory;
		private MetaSyntaxFactory _syntaxFactory;
		private MetaCompilationFactory _compilationFactory;

		private MetaLanguage()
		{
			_syntaxFacts = new MetaSyntaxFacts();
			_internalSyntaxFactory = new MetaInternalSyntaxFactory();
			_syntaxFactory = new MetaSyntaxFactory(_internalSyntaxFactory);
			_lookupPosition = new MetaLookupPosition();
			_symbolFacts = new MetaSymbolFacts();
			_compilationFactory = new MetaCompilationFactory();
		}

        public override string Name => "Meta";

        public new MetaSyntaxFacts SyntaxFacts => _syntaxFacts;
        protected override SyntaxFacts SyntaxFactsCore => this.SyntaxFacts;

        public new MetaSymbolFacts SymbolFacts => _symbolFacts;
        protected override SymbolFacts SymbolFactsCore => this.SymbolFacts;

        public new MetaLookupPosition LookupPosition => _lookupPosition;
        protected override LookupPosition LookupPositionCore => this.LookupPosition;

        internal new MetaInternalSyntaxFactory InternalSyntaxFactory => _internalSyntaxFactory;
        protected override InternalSyntaxFactory InternalSyntaxFactoryCore => this.InternalSyntaxFactory;

        public new MetaSyntaxFactory SyntaxFactory => _syntaxFactory;
        protected override SyntaxFactory SyntaxFactoryCore => this.SyntaxFactory;

        public new MetaCompilationFactory CompilationFactory => _compilationFactory;
        protected override CompilationFactory CompilationFactoryCore => this.CompilationFactory;
    }
}

