using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Core;

namespace MetaDslx.Compiler.Declarations
{
    public sealed class RootSingleDeclaration : SingleDeclaration
    {
        public RootSingleDeclaration(
            ModelSymbolInfo kind,
            SyntaxReference treeNode, 
            ImmutableArray<SingleDeclaration> children) 
            : base(string.Empty, kind, treeNode, new SourceLocation(treeNode.SyntaxTree, treeNode.Span), children)
        {
        }
    }
}
