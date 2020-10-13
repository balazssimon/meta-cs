// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System;
using System.Diagnostics;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Symbols;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax.InternalSyntax;

using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Model;

namespace MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations
{
    public sealed class TestLanguageAnnotationsLanguage : Language
    {
        public static readonly TestLanguageAnnotationsLanguage Instance = new TestLanguageAnnotationsLanguage();

		private TestLanguageAnnotationsLanguage()
		{
		}

        public override string Name => "TestLanguageAnnotations";

        public new TestLanguageAnnotationsSyntaxFacts SyntaxFacts => (TestLanguageAnnotationsSyntaxFacts)base.SyntaxFacts;
        public new TestLanguageAnnotationsSymbolFacts SymbolFacts => (TestLanguageAnnotationsSymbolFacts)base.SymbolFacts;
        internal new TestLanguageAnnotationsInternalSyntaxFactory InternalSyntaxFactory => (TestLanguageAnnotationsInternalSyntaxFactory)base.InternalSyntaxFactory;
        public new TestLanguageAnnotationsSyntaxFactory SyntaxFactory => (TestLanguageAnnotationsSyntaxFactory)base.SyntaxFactory;
        public new TestLanguageAnnotationsCompilationFactory CompilationFactory => (TestLanguageAnnotationsCompilationFactory)base.CompilationFactory;
        protected override LanguageServices CreateLanguageServices()
        {
            return new TestLanguageAnnotationsLanguageServices();
        }
    }
}

