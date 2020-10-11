// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System;
using System.Diagnostics;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using MetaDslx.Languages.Meta;
using MetaDslx.Languages.Meta.Symbols;
using MetaDslx.Languages.Meta.Syntax;
using MetaDslx.Languages.Meta.Syntax.InternalSyntax;
using Microsoft.Extensions.DependencyInjection;

namespace MetaDslx.Languages.Meta
{
    public class MetaLanguageServicesBase : LanguageServices
    {
        public override SyntaxFacts CreateSyntaxFacts()
        {
            return new MetaSyntaxFacts();
        }
        public override SymbolFacts CreateSymbolFacts()
        {
            return new MetaSymbolFacts();
        }
        public override InternalSyntaxFactory CreateInternalSyntaxFactory(SyntaxFacts syntaxFacts)
        {
            return new MetaInternalSyntaxFactory((MetaSyntaxFacts)syntaxFacts);
        }
        public override SyntaxFactory CreateSyntaxFactory(InternalSyntaxFactory internalSyntaxFactory)
        {
            return new MetaSyntaxFactory((MetaInternalSyntaxFactory)internalSyntaxFactory);
        }
        public override CompilationFactory CreateCompilationFactory()
        {
            return new MetaCompilationFactory();
        }
        public override void RegisterServices(ServiceCollection services)
        {
        }
    }
}

