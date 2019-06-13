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
    }
}
