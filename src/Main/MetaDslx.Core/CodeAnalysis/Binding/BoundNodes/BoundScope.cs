using Microsoft.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding.BoundNodes
{
    public class BoundScope : BoundNode
    {
        public BoundScope(BoundKind kind, BoundTree boundTree, ImmutableArray<object> childBoundNodes, LanguageSyntaxNode syntax, bool hasErrors = false)
            : base(kind, boundTree, childBoundNodes, syntax, hasErrors)
        {
        }

        public override void AddProperties(ArrayBuilder<BoundProperty> properties, string property = null)
        {
            foreach (var child in ChildBoundNodes)
            {
                child.AddProperties(properties, property);
            }
        }

        public override void AddValues(ArrayBuilder<BoundValues> values, string currentProperty = null, string rootProperty = null)
        {
            foreach (var child in ChildBoundNodes)
            {
                child.AddValues(values, currentProperty, rootProperty);
            }
        }
    }
}
