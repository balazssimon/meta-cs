using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Binding;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.Languages.Meta.Binding
{
    public class BoundOpposite : BoundNode
    {
        public BoundOpposite(BoundKind kind, BoundTree boundTree, ImmutableArray<BoundNode> childBoundNodes, LanguageSyntaxNode syntax, bool hasErrors) 
            : base(kind, boundTree, childBoundNodes, syntax, hasErrors)
        {
        }
    }
}
