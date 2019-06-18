using Microsoft.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding.BoundNodes
{
    public class BoundValue : BoundValues
    {
        private ImmutableArray<object> _values;

        public BoundValue(BoundKind kind, BoundTree boundTree, ImmutableArray<BoundNode> childBoundNodes, object value, LanguageSyntaxNode syntax, bool hasErrors = false)
            : base(kind, boundTree, childBoundNodes, syntax, hasErrors)
        {
            _values = ImmutableArray.Create(value);
        }

        public override ImmutableArray<object> Values => _values;

    }
}
