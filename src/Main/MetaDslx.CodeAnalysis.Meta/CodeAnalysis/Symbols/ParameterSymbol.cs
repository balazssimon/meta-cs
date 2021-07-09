using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [Symbol]
    public partial class ParameterSymbol : LocalSymbol
    {
        public ImmutableArray<CustomModifier> RefCustomModifiers { get; internal set; }
        public bool IsDiscard { get; internal set; }
        public bool IsParams { get; internal set; }
        public bool IsOptional { get; internal set; }
        public bool IsThis { get; internal set; }
        public int Ordinal { get; internal set; }
        public bool HasExplicitDefaultValue { get; internal set; }
        public object ExplicitDefaultValue { get; internal set; }
        public ParameterSymbol OriginalDefinition { get; internal set; }

        public override ImmutableArray<DeclaredSymbol> GetMembers()
        {
            throw new NotImplementedException();
        }

        public override ImmutableArray<NamedTypeSymbol> GetTypeMembers()
        {
            throw new NotImplementedException();
        }

    }
}
