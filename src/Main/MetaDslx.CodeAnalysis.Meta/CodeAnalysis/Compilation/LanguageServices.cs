using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Symbols.Metadata;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis
{
    public abstract class LanguageServices
    {
        public abstract SyntaxFacts CreateSyntaxFacts();
        public abstract InternalSyntaxFactory CreateInternalSyntaxFactory(SyntaxFacts syntaxFacts);
        public abstract SyntaxFactory CreateSyntaxFactory(InternalSyntaxFactory internalSyntaxFactory);
        public abstract SymbolFacts CreateSymbolFacts();
        public virtual SymbolFactory CreateSymbolFactory()
        {
            return new MetaSymbolFactory();
        }
        public abstract CompilationFactory CreateCompilationFactory();

        internal void RegisterDefaultServices(ServiceCollection services)
        {
            var syntaxFacts = this.CreateSyntaxFacts();
            services.AddSingleton(syntaxFacts);
            var internalSyntaxFactory = this.CreateInternalSyntaxFactory(syntaxFacts);
            services.AddSingleton(internalSyntaxFactory);
            services.AddSingleton(this.CreateSyntaxFactory(internalSyntaxFactory));
            services.AddSingleton(this.CreateSymbolFacts());
            services.AddSingleton(this.CreateSymbolFactory());
            services.AddSingleton(this.CreateCompilationFactory());
        }

        public abstract void RegisterServices(ServiceCollection services);
    }
}
