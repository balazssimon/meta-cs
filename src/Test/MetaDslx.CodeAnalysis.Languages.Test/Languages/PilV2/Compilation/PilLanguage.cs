// NOTE: This is an auto-generated file. However, it will not be regenerated. If you want it to be regenerated, just delete it.
using System;
using System.Diagnostics;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using PilV2;
using PilV2.Symbols;
using PilV2.Syntax;
using PilV2.Syntax.InternalSyntax;

namespace PilV2
{
    public sealed class PilLanguage : Language
    {
        public static readonly PilLanguage Instance = new PilLanguage();

		private PilSyntaxFacts _syntaxFacts;
		private PilSymbolFacts _symbolFacts;
		private PilInternalSyntaxFactory _internalSyntaxFactory;
		private PilSyntaxFactory _syntaxFactory;
		private PilCompilationFactory _compilationFactory;

		private PilLanguage()
		{
			_syntaxFacts = new PilSyntaxFacts();
			_internalSyntaxFactory = new PilInternalSyntaxFactory(_syntaxFacts);
			_syntaxFactory = new PilSyntaxFactory(_internalSyntaxFactory);
			_symbolFacts = new PilSymbolFacts();
			_compilationFactory = new PilCompilationFactory();
		}

        public override string Name => "Pil";

        public new PilSyntaxFacts SyntaxFacts => _syntaxFacts;
        protected override SyntaxFacts SyntaxFactsCore => this.SyntaxFacts;

        public new PilSymbolFacts SymbolFacts => _symbolFacts;
        protected override SymbolFacts SymbolFactsCore => this.SymbolFacts;

        internal new PilInternalSyntaxFactory InternalSyntaxFactory => _internalSyntaxFactory;
        protected override InternalSyntaxFactory InternalSyntaxFactoryCore => this.InternalSyntaxFactory;

        public new PilSyntaxFactory SyntaxFactory => _syntaxFactory;
        protected override SyntaxFactory SyntaxFactoryCore => this.SyntaxFactory;

        public new PilCompilationFactory CompilationFactory => _compilationFactory;
        protected override CompilationFactory CompilationFactoryCore => this.CompilationFactory;
    }
}

