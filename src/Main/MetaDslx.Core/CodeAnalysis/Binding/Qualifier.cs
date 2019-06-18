using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding
{
    public struct Qualifier
    {
        public readonly ImmutableArray<Identifier> Identifiers;

        public Qualifier(ImmutableArray<Identifier> identifiers)
        {
            Identifiers = identifiers;
        }

        public bool IsDefault => Identifiers.IsDefault;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            var values = this.Identifiers;
            for (int i = 0; i < values.Length; i++)
            {
                if (i > 0) sb.Append(".");
                sb.Append(values[i].MetadataName);
            }
            return sb.ToString();
        }
    }
}
