// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.CodeAnalysis;
using MetaDslx.CodeAnalysis.Syntax;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax
{
	public class TestLanguageAnnotationsSyntaxFacts : TestLanguageAnnotationsTokensSyntaxFacts
	{
        public TestLanguageAnnotationsSyntaxFacts() 
            : base(typeof(TestLanguageAnnotationsSyntaxKind))
        {
        }

        public override SyntaxKind CompilationUnitKind => (TestLanguageAnnotationsSyntaxKind)TestLanguageAnnotationsSyntaxKind.Main;
	}
}

