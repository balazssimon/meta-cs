// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
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
using Microsoft.Extensions.DependencyInjection;

namespace PilV2
{
    public class PilLanguageServicesBase : LanguageServices
    {
        public override SyntaxFacts CreateSyntaxFacts()
        {
            return new PilSyntaxFacts();
        }
        public override SymbolFacts CreateSymbolFacts()
        {
            return new PilSymbolFacts();
        }
        public override InternalSyntaxFactory CreateInternalSyntaxFactory(SyntaxFacts syntaxFacts)
        {
            return new PilInternalSyntaxFactory((PilSyntaxFacts)syntaxFacts);
        }
        public override SyntaxFactory CreateSyntaxFactory(InternalSyntaxFactory internalSyntaxFactory)
        {
            return new PilSyntaxFactory((PilInternalSyntaxFactory)internalSyntaxFactory);
        }
        public override CompilationFactory CreateCompilationFactory()
        {
            return new PilCompilationFactory();
        }
        public override void RegisterServices(ServiceCollection services)
        {
        }
    }
}

