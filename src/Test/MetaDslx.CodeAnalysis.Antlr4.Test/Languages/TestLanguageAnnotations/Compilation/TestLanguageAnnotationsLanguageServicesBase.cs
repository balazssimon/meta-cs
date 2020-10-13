// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System;
using System.Diagnostics;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Symbols;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax;
using Microsoft.Extensions.DependencyInjection;

namespace MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations
{
    public class TestLanguageAnnotationsLanguageServicesBase : LanguageServices
    {
        public override SyntaxFacts CreateSyntaxFacts()
        {
            return new TestLanguageAnnotationsSyntaxFacts();
        }
        public override SymbolFacts CreateSymbolFacts()
        {
            return new TestLanguageAnnotationsSymbolFacts();
        }
        public override InternalSyntaxFactory CreateInternalSyntaxFactory(SyntaxFacts syntaxFacts)
        {
            return new TestLanguageAnnotationsInternalSyntaxFactory((TestLanguageAnnotationsSyntaxFacts)syntaxFacts);
        }
        public override SyntaxFactory CreateSyntaxFactory(InternalSyntaxFactory internalSyntaxFactory)
        {
            return new TestLanguageAnnotationsSyntaxFactory((TestLanguageAnnotationsInternalSyntaxFactory)internalSyntaxFactory);
        }
        public override CompilationFactory CreateCompilationFactory()
        {
            return new TestLanguageAnnotationsCompilationFactory();
        }
        public override void RegisterServices(ServiceCollection services)
        {
        }
    }
}

