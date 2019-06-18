using Microsoft.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding.BoundNodes
{
    public abstract class BoundValues : BoundNode
    {
        public BoundValues(BoundKind kind, BoundTree boundTree, ImmutableArray<BoundNode> childBoundNodes, LanguageSyntaxNode syntax, bool hasErrors = false)
            : base(kind, boundTree, childBoundNodes, syntax, hasErrors)
        {
        }

        public abstract ImmutableArray<object> Values { get; }

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
            values.AddRange(this.Values);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            var values = this.Values;
            for (int i = 0; i < values.Length; i++)
            {
                if (i > 0) sb.Append(", ");
                sb.Append(values[i]);
            }
            sb.Append("]");
            return sb.ToString();
        }
    }
}
