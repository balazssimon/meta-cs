using Microsoft.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding.BoundNodes
{
    public class BoundBadStatement : BoundNode
    {
        public BoundBadStatement(BoundTree boundTree, ImmutableArray<object> childBoundNodes, LanguageSyntaxNode syntax, bool hasErrors) 
            : base(BoundKind.BadStatement, boundTree, childBoundNodes, syntax, hasErrors)
        {
        }


    }
}
