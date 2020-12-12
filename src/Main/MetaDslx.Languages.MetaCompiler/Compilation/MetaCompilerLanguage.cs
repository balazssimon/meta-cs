// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System;
using System.Diagnostics;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using MetaDslx.Languages.MetaCompiler;
using MetaDslx.Languages.MetaCompiler.Symbols;
using MetaDslx.Languages.MetaCompiler.Syntax;
using MetaDslx.Languages.MetaCompiler.Syntax.InternalSyntax;

using MetaDslx.Languages.MetaCompiler.Model;

namespace MetaDslx.Languages.MetaCompiler
{
    public sealed class MetaCompilerLanguage : Language
    {
        public static readonly MetaCompilerLanguage Instance = new MetaCompilerLanguage();

		private MetaCompilerLanguage()
		{
		}

        public override string Name => "MetaCompiler";

        public new MetaCompilerSyntaxFacts SyntaxFacts => (MetaCompilerSyntaxFacts)base.SyntaxFacts;
        public new MetaCompilerSymbolFacts SymbolFacts => (MetaCompilerSymbolFacts)base.SymbolFacts;
        internal new MetaCompilerInternalSyntaxFactory InternalSyntaxFactory => (MetaCompilerInternalSyntaxFactory)base.InternalSyntaxFactory;
        public new MetaCompilerSyntaxFactory SyntaxFactory => (MetaCompilerSyntaxFactory)base.SyntaxFactory;
        public new MetaCompilerCompilationFactory CompilationFactory => (MetaCompilerCompilationFactory)base.CompilationFactory;
        protected override LanguageServices CreateLanguageServices()
        {
            return new MetaCompilerLanguageServices();
        }
    }
}

