using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding
{
    public class BoundSymbols : BoundSymbol
    {
        private ImmutableArray<Symbol> _symbols;

        public BoundSymbols(ImmutableArray<Symbol> symbols)
        {
            _symbols = symbols;
        }

        public override ImmutableArray<Symbol> Symbols => _symbols;
    }
}
