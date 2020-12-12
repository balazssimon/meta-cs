// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.CodeAnalysis;
using MetaDslx.CodeAnalysis.Syntax;
using Roslyn.Utilities;

namespace MetaDslx.Languages.MetaCompiler.Syntax
{
	public class MetaCompilerSyntaxFacts : MetaCompilerTokensSyntaxFacts
	{
        public MetaCompilerSyntaxFacts() 
            : base(typeof(MetaCompilerSyntaxKind))
        {
        }

        public override SyntaxKind CompilationUnitKind => (MetaCompilerSyntaxKind)MetaCompilerSyntaxKind.Main;
	}
}

