// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
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

		private TestLexerModeLanguage()
		{
		}

        public override string Name => "TestLexerMode";

        public new TestLexerModeSyntaxFacts SyntaxFacts => (TestLexerModeSyntaxFacts)base.SyntaxFacts;
        public new TestLexerModeSymbolFacts SymbolFacts => (TestLexerModeSymbolFacts)base.SymbolFacts;
        internal new TestLexerModeInternalSyntaxFactory InternalSyntaxFactory => (TestLexerModeInternalSyntaxFactory)base.InternalSyntaxFactory;
        public new TestLexerModeSyntaxFactory SyntaxFactory => (TestLexerModeSyntaxFactory)base.SyntaxFactory;
        public new TestLexerModeCompilationFactory CompilationFactory => (TestLexerModeCompilationFactory)base.CompilationFactory;
        protected override LanguageServices CreateLanguageServices()
        {
            return new TestLexerModeLanguageServices();
        }
    }
}

