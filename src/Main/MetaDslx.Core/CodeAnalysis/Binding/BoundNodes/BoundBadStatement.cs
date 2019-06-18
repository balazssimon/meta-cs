using Microsoft.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding.BoundNodes
{
    public class BoundBadStatement : BoundNode
    {
        public BoundBadStatement(BoundTree boundTree, ImmutableArray<BoundNode> childBoundNodes, LanguageSyntaxNode syntax, bool hasErrors) 
            : base(BoundKind.BadStatement, boundTree, childBoundNodes, syntax, hasErrors)
        {
        }

        protected override void AddIdentifiers(ArrayBuilder<Identifier> identifiers)
        {
        }

        protected override void AddQualifiers(ArrayBuilder<Qualifier> qualifiers)
        {
        }

        protected override void AddNames(ArrayBuilder<Qualifier> names)
        {
        }

        protected override void AddProperties(ArrayBuilder<string> properties)
        {
        }

        protected override void AddValues(string property, ArrayBuilder<object> values)
        {
        }
    }
}
