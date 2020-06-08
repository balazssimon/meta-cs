// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.CodeAnalysis;
using MetaDslx.CodeAnalysis.Syntax;
using Roslyn.Utilities;

namespace PilV2.Syntax
{
	public class PilSyntaxFacts : PilTokensSyntaxFacts
	{
        public PilSyntaxFacts() 
            : base(typeof(PilSyntaxKind))
        {
        }

        public override SyntaxKind CompilationUnitKind => (PilSyntaxKind)PilSyntaxKind.Main;
	}
}

