// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System;
using System.Diagnostics;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax.InternalSyntax;
using Microsoft.Extensions.DependencyInjection;

namespace MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation
{
    public class TestIncrementalCompilationLanguageServicesBase : LanguageServices
    {
        public override SyntaxFacts CreateSyntaxFacts()
        {
            return new TestIncrementalCompilationSyntaxFacts();
        }
        public override SymbolFacts CreateSymbolFacts()
        {
            return new TestIncrementalCompilationSymbolFacts();
        }
        public override InternalSyntaxFactory CreateInternalSyntaxFactory(SyntaxFacts syntaxFacts)
        {
            return new TestIncrementalCompilationInternalSyntaxFactory((TestIncrementalCompilationSyntaxFacts)syntaxFacts);
        }
        public override SyntaxFactory CreateSyntaxFactory(InternalSyntaxFactory internalSyntaxFactory)
        {
            return new TestIncrementalCompilationSyntaxFactory((TestIncrementalCompilationInternalSyntaxFactory)internalSyntaxFactory);
        }
        public override CompilationFactory CreateCompilationFactory()
        {
            return new TestIncrementalCompilationCompilationFactory();
        }
        public override void RegisterServices(ServiceCollection services)
        {
        }
    }
}

