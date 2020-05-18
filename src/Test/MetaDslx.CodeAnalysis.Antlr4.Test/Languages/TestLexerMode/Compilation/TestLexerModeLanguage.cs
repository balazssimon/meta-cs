// NOTE: This is an auto-generated file. However, it will not be regenerated. If you want it to be regenerated, just delete it.
using System;
using System.Diagnostics;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Symbols;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode.Syntax.InternalSyntax;

namespace MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode
{
    public sealed class TestLexerModeLanguage : Language
    {
        public static readonly TestLexerModeLanguage Instance = new TestLexerModeLanguage();

		private TestLexerModeSyntaxFacts _syntaxFacts;
		private TestLexerModeSymbolFacts _symbolFacts;
		private TestLexerModeInternalSyntaxFactory _internalSyntaxFactory;
		private TestLexerModeSyntaxFactory _syntaxFactory;
		private TestLexerModeCompilationFactory _compilationFactory;

		private TestLexerModeLanguage()
		{
			_syntaxFacts = new TestLexerModeSyntaxFacts();
			_internalSyntaxFactory = new CustomTestLexerModeInternalSyntaxFactory(_syntaxFacts);
			_syntaxFactory = new TestLexerModeSyntaxFactory(_internalSyntaxFactory);
			_symbolFacts = new TestLexerModeSymbolFacts();
			_compilationFactory = new TestLexerModeCompilationFactory();
		}

        public override string Name => "TestLexerMode";

        public new TestLexerModeSyntaxFacts SyntaxFacts => _syntaxFacts;
        protected override SyntaxFacts SyntaxFactsCore => this.SyntaxFacts;

        public new TestLexerModeSymbolFacts SymbolFacts => _symbolFacts;
        protected override SymbolFacts SymbolFactsCore => this.SymbolFacts;

        internal new TestLexerModeInternalSyntaxFactory InternalSyntaxFactory => _internalSyntaxFactory;
        protected override InternalSyntaxFactory InternalSyntaxFactoryCore => this.InternalSyntaxFactory;

        public new TestLexerModeSyntaxFactory SyntaxFactory => _syntaxFactory;
        protected override SyntaxFactory SyntaxFactoryCore => this.SyntaxFactory;

        public new TestLexerModeCompilationFactory CompilationFactory => _compilationFactory;
        protected override CompilationFactory CompilationFactoryCore => this.CompilationFactory;
    }
}

