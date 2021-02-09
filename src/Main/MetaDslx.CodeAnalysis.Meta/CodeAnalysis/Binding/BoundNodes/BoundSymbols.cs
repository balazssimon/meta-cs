using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding.BoundNodes
{
    public class BoundSymbols : BoundSymbol
    {
        private ImmutableArray<Symbol> _symbols;

        public BoundSymbols(SyntaxNodeOrToken syntax, BoundNode parent, ImmutableArray<Symbol> symbols)
            : base(syntax, parent)
        {
            _symbols = symbols;
        }

        public override ImmutableArray<Symbol> Symbols => _symbols;
    }
}
