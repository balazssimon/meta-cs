// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System;
using System.Diagnostics;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using MetaDslx.Languages.Compiler;
using MetaDslx.Languages.Compiler.Symbols;
using MetaDslx.Languages.Compiler.Syntax;
using MetaDslx.Languages.Compiler.Syntax.InternalSyntax;
using Roslyn.Utilities;

using MetaDslx.Languages.Compiler.Model;

namespace MetaDslx.Languages.Compiler
{
    public sealed class CompilerLanguage : Language
    {
        public static readonly CompilerLanguage Instance = new CompilerLanguage();

		private CompilerLanguage()
		{
            EnumObject.Init(typeof(CompilerLanguageVersion));
            EnumObject.Init(typeof(CompilerTokensSyntaxKind));
            EnumObject.Init(typeof(CompilerSyntaxKind));
		}

        public override string Name => "Compiler";

        public new CompilerSyntaxFacts SyntaxFacts => (CompilerSyntaxFacts)base.SyntaxFacts;
        public new CompilerSymbolFacts SymbolFacts => (CompilerSymbolFacts)base.SymbolFacts;
        internal new CompilerInternalSyntaxFactory InternalSyntaxFactory => (CompilerInternalSyntaxFactory)base.InternalSyntaxFactory;
        public new CompilerSyntaxFactory SyntaxFactory => (CompilerSyntaxFactory)base.SyntaxFactory;
        public new CompilerCompilationFactory CompilationFactory => (CompilerCompilationFactory)base.CompilationFactory;
        protected override LanguageServices CreateLanguageServices()
        {
            return new CompilerLanguageServices();
        }
    }
}

