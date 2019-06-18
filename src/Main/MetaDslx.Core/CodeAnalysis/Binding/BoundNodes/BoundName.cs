using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis.PooledObjects;

namespace MetaDslx.CodeAnalysis.Binding.BoundNodes
{
    public class BoundName : BoundNode
    {
        public BoundName(BoundKind kind, BoundTree boundTree, ImmutableArray<BoundNode> childBoundNodes, LanguageSyntaxNode syntax, bool hasErrors = false)
            : base(kind, boundTree, childBoundNodes, syntax, hasErrors)
        {
        }

        public Symbol Symbol
        {
            get
            {
                return null;
            }
        }

        public override void AddNames(ArrayBuilder<Qualifier> names)
        {
            names.AddRange(this.GetChildQualifiers());
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            var values = this.GetQualifiers();
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
