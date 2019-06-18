using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis.PooledObjects;

namespace MetaDslx.CodeAnalysis.Binding.BoundNodes
{
    public class BoundQualifier : BoundNode
    {
        public BoundQualifier(BoundKind kind, BoundTree boundTree, ImmutableArray<BoundNode> childBoundNodes, LanguageSyntaxNode syntax, bool hasErrors = false)
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

        public override void AddQualifiers(ArrayBuilder<Qualifier> qualifiers)
        {
            qualifiers.Add(new Qualifier(this.GetChildIdentifiers()));
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            var values = this.GetChildIdentifiers();
            for (int i = 0; i < values.Length; i++)
            {
                if (i > 0) sb.Append(".");
                sb.Append(values[i].MetadataName);
            }
            sb.Append(" = ");
            sb.Append(this.Symbol);
            return sb.ToString();
        }

    }

}
