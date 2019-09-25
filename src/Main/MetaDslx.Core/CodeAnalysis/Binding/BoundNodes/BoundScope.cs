using Microsoft.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Binding.BoundNodes
{
    public class BoundScope : BoundNode
    {
        public BoundScope(BoundKind kind, BoundTree boundTree, ImmutableArray<object> childBoundNodes, LanguageSyntaxNode syntax, bool hasErrors = false)
            : base(kind, boundTree, childBoundNodes, syntax, hasErrors)
        {
        }

        public override void AddProperties(ArrayBuilder<BoundProperty> properties, string property = null, CancellationToken cancellationToken = default)
        {
            foreach (var child in ChildBoundNodes)
            {
                child.AddProperties(properties, property, cancellationToken);
            }
        }

        public override void AddValues(ArrayBuilder<BoundValues> values, BoundProperty currentProperty = null, BoundProperty rootProperty = null, CancellationToken cancellationToken = default)
        {
            foreach (var child in ChildBoundNodes)
            {
                child.AddValues(values, currentProperty, rootProperty, cancellationToken);
            }
        }
    }
}
