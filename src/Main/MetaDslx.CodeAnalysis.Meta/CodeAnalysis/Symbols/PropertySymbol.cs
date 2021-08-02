using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [Symbol]
    public abstract partial class PropertySymbol : StructuralMemberSymbol
    {
        [SymbolProperty]
        public ImmutableArray<ParameterSymbol> Parameters { get; internal set; }

        [SymbolProperty]
        public MethodSymbol GetMethod { get; internal set; }

        [SymbolProperty]
        public MethodSymbol SetMethod { get; internal set; }

        public new PropertySymbol OriginalDefinition => this;
        public PropertySymbol OverriddenProperty { get; internal set; }

    }
}
