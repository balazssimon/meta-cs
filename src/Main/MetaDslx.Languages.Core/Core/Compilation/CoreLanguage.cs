// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System;
using System.Diagnostics;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using MetaDslx.Languages.Core;
using MetaDslx.Languages.Core.Symbols;
using MetaDslx.Languages.Core.Syntax;
using MetaDslx.Languages.Core.Syntax.InternalSyntax;
using Roslyn.Utilities;

using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.Languages.Core.Model;

namespace MetaDslx.Languages.Core
{
    public sealed class CoreLanguage : Language
    {
        public static readonly CoreLanguage Instance = new CoreLanguage();

		private CoreLanguage()
		{
            EnumObject.Init(typeof(CoreLanguageVersion));
            EnumObject.Init(typeof(CoreTokensSyntaxKind));
            EnumObject.Init(typeof(CoreSyntaxKind));
		}

        public override string Name => "Core";

        public new CoreSyntaxFacts SyntaxFacts => (CoreSyntaxFacts)base.SyntaxFacts;
        public new CoreSymbolFacts SymbolFacts => (CoreSymbolFacts)base.SymbolFacts;
        internal new CoreInternalSyntaxFactory InternalSyntaxFactory => (CoreInternalSyntaxFactory)base.InternalSyntaxFactory;
        public new CoreSyntaxFactory SyntaxFactory => (CoreSyntaxFactory)base.SyntaxFactory;
        public new CoreCompilationFactory CompilationFactory => (CoreCompilationFactory)base.CompilationFactory;
        protected override LanguageServices CreateLanguageServices()
        {
            return new CoreLanguageServices();
        }
    }
}

