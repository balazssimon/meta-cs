// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
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

		private TestIncrementalCompilationLanguage()
		{
		}

        public override string Name => "TestIncrementalCompilation";

        public new TestIncrementalCompilationSyntaxFacts SyntaxFacts => (TestIncrementalCompilationSyntaxFacts)base.SyntaxFacts;
        public new TestIncrementalCompilationSymbolFacts SymbolFacts => (TestIncrementalCompilationSymbolFacts)base.SymbolFacts;
        internal new TestIncrementalCompilationInternalSyntaxFactory InternalSyntaxFactory => (TestIncrementalCompilationInternalSyntaxFactory)base.InternalSyntaxFactory;
        public new TestIncrementalCompilationSyntaxFactory SyntaxFactory => (TestIncrementalCompilationSyntaxFactory)base.SyntaxFactory;
        public new TestIncrementalCompilationCompilationFactory CompilationFactory => (TestIncrementalCompilationCompilationFactory)base.CompilationFactory;
        protected override LanguageServices CreateLanguageServices()
        {
            return new TestIncrementalCompilationLanguageServices();
        }
    }
}

