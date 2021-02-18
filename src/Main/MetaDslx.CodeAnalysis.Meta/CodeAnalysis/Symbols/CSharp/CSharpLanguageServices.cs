using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols.CSharp
{
    public class CSharpLanguageServices : LanguageServices
    {
        public override CompilationFactory CreateCompilationFactory()
        {
            return new CSharpCompilationFactory();
        }

        public override InternalSyntaxFactory CreateInternalSyntaxFactory(SyntaxFacts syntaxFacts)
        {
            return new CSharpInternalSyntaxFactory(syntaxFacts);
        }

        public override SymbolFacts CreateSymbolFacts()
        {
            return new CSharpSymbolFacts();
        }

        public override SyntaxFactory CreateSyntaxFactory(InternalSyntaxFactory internalSyntaxFactory)
        {
            return new CSharpSyntaxFactory(internalSyntaxFactory);
        }

        public override SyntaxFacts CreateSyntaxFacts()
        {
            return new CSharpSyntaxFacts();
        }

        public override void RegisterServices(ServiceCollection services)
        {
        }
    }
}
