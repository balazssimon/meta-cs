// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.CodeAnalysis;
using MetaDslx.CodeAnalysis.Syntax;
using Roslyn.Utilities;

namespace WebSequenceDiagramsModel.Syntax
{
	public class SequenceSyntaxFacts : SequenceTokensSyntaxFacts
	{
        public SequenceSyntaxFacts() 
            : base(typeof(SequenceSyntaxKind))
        {
        }

        public override SyntaxKind CompilationUnitKind => (SequenceSyntaxKind)SequenceSyntaxKind.Main;
	}
}

