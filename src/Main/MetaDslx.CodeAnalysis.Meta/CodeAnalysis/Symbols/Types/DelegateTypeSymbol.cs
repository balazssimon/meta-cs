using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [Symbol]
    public abstract partial class DelegateTypeSymbol : NamedTypeSymbol
    {
        [SymbolProperty]
        public abstract TypeSymbol ReturnType { get; }

        [SymbolProperty]
        public abstract ImmutableArray<ParameterSymbol> Parameters { get; }
    }
}
