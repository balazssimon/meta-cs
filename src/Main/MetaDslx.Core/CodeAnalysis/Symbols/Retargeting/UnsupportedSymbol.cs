using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols.Retargeting
{
    public class UnsupportedSymbol : Symbol, IMetaErrorSymbol
    {
        private ISymbol _symbol;

        internal UnsupportedSymbol(ISymbol symbol)
        {
            _symbol = symbol;
        }

        public ISymbol Symbol => _symbol;

        public override SymbolKind Kind => SymbolKind.Unknown;

        public override Symbol ContainingSymbol => null;

        public override ImmutableArray<Location> Locations => ImmutableArray<Location>.Empty;

        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => ImmutableArray<SyntaxReference>.Empty;

        public override bool IsStatic => false;

        public override void Accept(SymbolVisitor visitor)
        {
            // nop
        }

        public override TResult Accept<TResult>(SymbolVisitor<TResult> visitor)
        {
            return default;
        }
    }
}
