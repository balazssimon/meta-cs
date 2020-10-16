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

using MetaDslx.Languages.Meta.Model;

namespace MetaDslx.Languages.Meta
{
    public sealed class MetaLanguage : Language
    {
        public static readonly MetaLanguage Instance = new MetaLanguage();

		private MetaLanguage()
		{
		}

        public override string Name => "Meta";

        public new MetaSyntaxFacts SyntaxFacts => (MetaSyntaxFacts)base.SyntaxFacts;
        public new MetaSymbolFacts SymbolFacts => (MetaSymbolFacts)base.SymbolFacts;
        internal new MetaInternalSyntaxFactory InternalSyntaxFactory => (MetaInternalSyntaxFactory)base.InternalSyntaxFactory;
        public new MetaSyntaxFactory SyntaxFactory => (MetaSyntaxFactory)base.SyntaxFactory;
        public new MetaCompilationFactory CompilationFactory => (MetaCompilationFactory)base.CompilationFactory;
        protected override LanguageServices CreateLanguageServices()
        {
            return new MetaLanguageServices();
        }
    }
}

