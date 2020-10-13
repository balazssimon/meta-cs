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

namespace PilV2
{
    public sealed class PilLanguage : Language
    {
        public static readonly PilLanguage Instance = new PilLanguage();

		private PilLanguage()
		{
		}

        public override string Name => "Pil";

        public new PilSyntaxFacts SyntaxFacts => (PilSyntaxFacts)base.SyntaxFacts;
        public new PilSymbolFacts SymbolFacts => (PilSymbolFacts)base.SymbolFacts;
        internal new PilInternalSyntaxFactory InternalSyntaxFactory => (PilInternalSyntaxFactory)base.InternalSyntaxFactory;
        public new PilSyntaxFactory SyntaxFactory => (PilSyntaxFactory)base.SyntaxFactory;
        public new PilCompilationFactory CompilationFactory => (PilCompilationFactory)base.CompilationFactory;
        protected override LanguageServices CreateLanguageServices()
        {
            return new PilLanguageServices();
        }
    }
}

