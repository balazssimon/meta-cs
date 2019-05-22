// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System.Collections.Generic;
using System.Threading;
using Microsoft.CodeAnalysis;
using MetaDslx.CodeAnalysis.Syntax;
using Roslyn.Utilities;

namespace MetaDslx.Languages.Meta.Syntax
{
	public partial class MetaSyntaxFacts
	{
        public override SyntaxKind CompilationUnitKind => (MetaSyntaxKind)MetaSyntaxKind.Main;

        public override bool IsInNamespaceOrTypeContext(SyntaxNode node)
        {
            return false;
        }

        public override bool IsStatement(SyntaxNode syntax)
        {
            return false;
        }

        public override bool IsExpression(SyntaxNode node)
        {
            return false;
        }
	}
}

