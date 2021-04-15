using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Binding.BoundNodes
{
    public class BoundIdentifier : BoundSymbol
    {
        private DeclaredSymbol _symbol;

        public BoundIdentifier(DeclaredSymbol symbol)
        {
            _symbol = symbol;
        }

        public DeclaredSymbol Symbol => _symbol;

        public override ImmutableArray<Symbol> Symbols => _symbol != null ? ImmutableArray.Create((Symbol)_symbol) : ImmutableArray<Symbol>.Empty;

    }
}
