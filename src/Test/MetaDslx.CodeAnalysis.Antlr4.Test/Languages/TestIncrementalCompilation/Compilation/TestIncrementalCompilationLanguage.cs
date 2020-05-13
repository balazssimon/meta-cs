// NOTE: This is an auto-generated file. However, it will not be regenerated. If you want it to be regenerated, just delete it.
using System;
using System.Diagnostics;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Symbols;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax;
using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax.InternalSyntax;

namespace MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation
{
    public sealed class TestIncrementalCompilationLanguage : Language
    {
        public static readonly TestIncrementalCompilationLanguage Instance = new TestIncrementalCompilationLanguage();

		private TestIncrementalCompilationSyntaxFacts _syntaxFacts;
		private TestIncrementalCompilationSymbolFacts _symbolFacts;
		private TestIncrementalCompilationInternalSyntaxFactory _internalSyntaxFactory;
		private TestIncrementalCompilationSyntaxFactory _syntaxFactory;
		private TestIncrementalCompilationCompilationFactory _compilationFactory;

		private TestIncrementalCompilationLanguage()
		{
			_syntaxFacts = new TestIncrementalCompilationSyntaxFacts();
			_internalSyntaxFactory = new TestIncrementalCompilationInternalSyntaxFactory(_syntaxFacts);
			_syntaxFactory = new TestIncrementalCompilationSyntaxFactory(_internalSyntaxFactory);
			_symbolFacts = new TestIncrementalCompilationSymbolFacts();
			_compilationFactory = new TestIncrementalCompilationCompilationFactory();
		}

        public override string Name => "TestIncrementalCompilation";

        public new TestIncrementalCompilationSyntaxFacts SyntaxFacts => _syntaxFacts;
        protected override SyntaxFacts SyntaxFactsCore => this.SyntaxFacts;

        public new TestIncrementalCompilationSymbolFacts SymbolFacts => _symbolFacts;
        protected override SymbolFacts SymbolFactsCore => this.SymbolFacts;

        internal new TestIncrementalCompilationInternalSyntaxFactory InternalSyntaxFactory => _internalSyntaxFactory;
        protected override InternalSyntaxFactory InternalSyntaxFactoryCore => this.InternalSyntaxFactory;

        public new TestIncrementalCompilationSyntaxFactory SyntaxFactory => _syntaxFactory;
        protected override SyntaxFactory SyntaxFactoryCore => this.SyntaxFactory;

        public new TestIncrementalCompilationCompilationFactory CompilationFactory => _compilationFactory;
        protected override CompilationFactory CompilationFactoryCore => this.CompilationFactory;
    }
}

