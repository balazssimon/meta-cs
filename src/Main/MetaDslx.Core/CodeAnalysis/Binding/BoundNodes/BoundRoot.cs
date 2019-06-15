using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding.BoundNodes
{
    public class BoundRoot : BoundSymbol
    {
        public BoundRoot(BoundKind kind, BoundTree boundTree, ImmutableArray<BoundNode> childBoundNodes, LanguageSyntaxNode syntax, bool hasErrors = false) 
            : base(kind, boundTree, childBoundNodes, syntax, hasErrors)
        {
        }
    }
}
