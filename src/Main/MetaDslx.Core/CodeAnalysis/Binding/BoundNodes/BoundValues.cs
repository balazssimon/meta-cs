using MetaDslx.CodeAnalysis.Symbols;
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

        public override void AddValues(ArrayBuilder<BoundValues> values, string currentProperty = null, string rootProperty = null)
        {
            if (rootProperty == null || currentProperty == rootProperty)
            {
                values.Add(this);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            var values = this.Values;
            for (int i = 0; i < values.Length; i++)
            {
                if (i > 0) sb.Append(", ");
                var symbol = values[i] as Symbol;
                if (symbol != null)
                {
                    string text = symbol.MetadataName;
                    while (symbol != null)
                    {
                        symbol = symbol.ContainingNamespaceOrType();
                        if (symbol != null)
                        {
                            text = symbol.Name + "." + text;
                        }
                    }
                    sb.Append(text);
                }
                else
                {
                    sb.Append(values[i]);
                }
            }
            sb.Append("]");
            return sb.ToString();
        }
    }
}
