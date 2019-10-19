using Microsoft.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Binding.BoundNodes
{
    public class CustomBoundNode : BoundNode
    {
        public CustomBoundNode(BoundKind kind, BoundTree boundTree, ImmutableArray<object> childBoundNodes, LanguageSyntaxNode syntax, bool hasErrors) 
            : base(kind, boundTree, childBoundNodes, syntax, hasErrors)
        {
        }

        public override void AddIdentifiers(ArrayBuilder<BoundIdentifier> identifiers, CancellationToken cancellationToken = default)
        {
            foreach (var child in this.ChildBoundNodes)
            {
                child.AddIdentifiers(identifiers, cancellationToken);
            }
        }

        public override void AddQualifiers(ArrayBuilder<BoundQualifier> qualifiers, CancellationToken cancellationToken = default)
        {
            foreach (var child in this.ChildBoundNodes)
            {
                child.AddQualifiers(qualifiers, cancellationToken);
            }
        }

        public override void AddNames(ArrayBuilder<BoundName> names, CancellationToken cancellationToken = default)
        {
            foreach (var child in this.ChildBoundNodes)
            {
                child.AddNames(names, cancellationToken);
            }
        }

        public override void AddProperties(ArrayBuilder<BoundProperty> properties, string property = null, CancellationToken cancellationToken = default)
        {
            foreach (var child in this.ChildBoundNodes)
            {
                child.AddProperties(properties, property, cancellationToken);
            }
        }

        public override void AddValues(ArrayBuilder<BoundValues> values, BoundProperty currentProperty = null, BoundProperty rootProperty = null, CancellationToken cancellationToken = default)
        {
            foreach (var child in this.ChildBoundNodes)
            {
                child.AddValues(values, currentProperty, rootProperty, cancellationToken);
            }
        }
    }
}
