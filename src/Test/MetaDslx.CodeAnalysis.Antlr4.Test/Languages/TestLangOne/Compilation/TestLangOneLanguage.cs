// NOTE: This is an auto-generated file. However, it will not be regenerated. If you want it to be regenerated, just delete it.
using System;
using System.Diagnostics;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageOne;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageOne.Symbols;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageOne.Syntax;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageOne.Syntax.InternalSyntax;

using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageOne.Model;

namespace MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageOne
{
    public sealed class TestLangOneLanguage : Language
    {
        public static readonly TestLangOneLanguage Instance = new TestLangOneLanguage();

		private TestLangOneSyntaxFacts _syntaxFacts;
		private TestLangOneSymbolFacts _symbolFacts;
		private TestLangOneInternalSyntaxFactory _internalSyntaxFactory;
		private TestLangOneSyntaxFactory _syntaxFactory;
		private TestLangOneCompilationFactory _compilationFactory;

		private TestLangOneLanguage()
		{
			_syntaxFacts = new TestLangOneSyntaxFacts();
			_internalSyntaxFactory = new TestLangOneInternalSyntaxFactory(_syntaxFacts);
			_syntaxFactory = new TestLangOneSyntaxFactory(_internalSyntaxFactory);
			_symbolFacts = new TestLangOneSymbolFacts();
			_compilationFactory = new TestLangOneCompilationFactory();
		}

        public override string Name => "TestLangOne";

        public new TestLangOneSyntaxFacts SyntaxFacts => _syntaxFacts;
        protected override SyntaxFacts SyntaxFactsCore => this.SyntaxFacts;

        public new TestLangOneSymbolFacts SymbolFacts => _symbolFacts;
        protected override SymbolFacts SymbolFactsCore => this.SymbolFacts;

        internal new TestLangOneInternalSyntaxFactory InternalSyntaxFactory => _internalSyntaxFactory;
        protected override InternalSyntaxFactory InternalSyntaxFactoryCore => this.InternalSyntaxFactory;

        public new TestLangOneSyntaxFactory SyntaxFactory => _syntaxFactory;
        protected override SyntaxFactory SyntaxFactoryCore => this.SyntaxFactory;

        public new TestLangOneCompilationFactory CompilationFactory => _compilationFactory;
        protected override CompilationFactory CompilationFactoryCore => this.CompilationFactory;
    }
}

