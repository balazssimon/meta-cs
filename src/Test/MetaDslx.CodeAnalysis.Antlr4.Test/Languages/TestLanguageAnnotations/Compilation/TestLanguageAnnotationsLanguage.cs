// NOTE: This is an auto-generated file. However, it will not be regenerated. If you want it to be regenerated, just delete it.
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

		private TestLanguageAnnotationsSyntaxFacts _syntaxFacts;
		private TestLanguageAnnotationsSymbolFacts _symbolFacts;
		private TestLanguageAnnotationsInternalSyntaxFactory _internalSyntaxFactory;
		private TestLanguageAnnotationsSyntaxFactory _syntaxFactory;
		private TestLanguageAnnotationsCompilationFactory _compilationFactory;

		private TestLanguageAnnotationsLanguage()
		{
			_syntaxFacts = new TestLanguageAnnotationsSyntaxFacts();
			_internalSyntaxFactory = new TestLanguageAnnotationsInternalSyntaxFactory(_syntaxFacts);
			_syntaxFactory = new TestLanguageAnnotationsSyntaxFactory(_internalSyntaxFactory);
			_symbolFacts = new TestLanguageAnnotationsSymbolFacts();
			_compilationFactory = new TestLanguageAnnotationsCompilationFactory();
		}

        public override string Name => "TestLanguageAnnotations";

        public new TestLanguageAnnotationsSyntaxFacts SyntaxFacts => _syntaxFacts;
        protected override SyntaxFacts SyntaxFactsCore => this.SyntaxFacts;

        public new TestLanguageAnnotationsSymbolFacts SymbolFacts => _symbolFacts;
        protected override SymbolFacts SymbolFactsCore => this.SymbolFacts;

        internal new TestLanguageAnnotationsInternalSyntaxFactory InternalSyntaxFactory => _internalSyntaxFactory;
        protected override InternalSyntaxFactory InternalSyntaxFactoryCore => this.InternalSyntaxFactory;

        public new TestLanguageAnnotationsSyntaxFactory SyntaxFactory => _syntaxFactory;
        protected override SyntaxFactory SyntaxFactoryCore => this.SyntaxFactory;

        public new TestLanguageAnnotationsCompilationFactory CompilationFactory => _compilationFactory;
        protected override CompilationFactory CompilationFactoryCore => this.CompilationFactory;
    }
}

