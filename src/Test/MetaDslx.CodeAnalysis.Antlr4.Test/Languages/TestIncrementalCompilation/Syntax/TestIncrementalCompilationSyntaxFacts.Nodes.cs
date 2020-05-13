// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.CodeAnalysis;
using MetaDslx.CodeAnalysis.Syntax;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax
{
	public class TestIncrementalCompilationSyntaxFacts : TestIncrementalCompilationTokensSyntaxFacts
	{
        public TestIncrementalCompilationSyntaxFacts() 
            : base(typeof(TestIncrementalCompilationSyntaxKind))
        {
        }

        public override SyntaxKind CompilationUnitKind => (TestIncrementalCompilationSyntaxKind)TestIncrementalCompilationSyntaxKind.Main;
	}
}

