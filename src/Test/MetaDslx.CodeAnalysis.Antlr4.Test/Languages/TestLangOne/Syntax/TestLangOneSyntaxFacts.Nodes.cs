// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.CodeAnalysis;
using MetaDslx.CodeAnalysis.Syntax;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Antlr4.Test.Language.TestLanguageOne.Syntax
{
	public class TestLangOneSyntaxFacts : TestLangOneTokensSyntaxFacts
	{
        public TestLangOneSyntaxFacts() 
            : base(typeof(TestLangOneSyntaxKind))
        {
        }

        public override SyntaxKind CompilationUnitKind => (TestLangOneSyntaxKind)TestLangOneSyntaxKind.Main;
	}
}

