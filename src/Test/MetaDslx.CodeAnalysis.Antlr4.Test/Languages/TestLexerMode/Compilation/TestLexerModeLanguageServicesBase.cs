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
using Microsoft.Extensions.DependencyInjection;

namespace MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode
{
    public class TestLexerModeLanguageServicesBase : LanguageServices
    {
        public override SyntaxFacts CreateSyntaxFacts()
        {
            return new TestLexerModeSyntaxFacts();
        }
        public override SymbolFacts CreateSymbolFacts()
        {
            return new TestLexerModeSymbolFacts();
        }
        public override InternalSyntaxFactory CreateInternalSyntaxFactory(SyntaxFacts syntaxFacts)
        {
            return new TestLexerModeInternalSyntaxFactory((TestLexerModeSyntaxFacts)syntaxFacts);
        }
        public override SyntaxFactory CreateSyntaxFactory(InternalSyntaxFactory internalSyntaxFactory)
        {
            return new TestLexerModeSyntaxFactory((TestLexerModeInternalSyntaxFactory)internalSyntaxFactory);
        }
        public override CompilationFactory CreateCompilationFactory()
        {
            return new TestLexerModeCompilationFactory();
        }
        public override void RegisterServices(ServiceCollection services)
        {
        }
    }
}

