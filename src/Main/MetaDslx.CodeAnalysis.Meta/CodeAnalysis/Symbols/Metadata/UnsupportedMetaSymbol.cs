using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols.Metadata
{
    public class UnsupportedMetaSymbol : Symbol, IMetaErrorSymbol
    {
        private IModelObject _symbol;

        internal UnsupportedMetaSymbol(IModelObject symbol)
        {
            _symbol = symbol;
        }

        public IModelObject Symbol => _symbol;

        public override LanguageSymbolKind Kind => LanguageSymbolKind.ErrorType;

        public override ModelObjectDescriptor ModelSymbolInfo => _symbol.MId.Descriptor;

        public override Symbol ContainingSymbol => null;

        public override ImmutableArray<Location> Locations => ImmutableArray<Location>.Empty;

        public override void Accept(SymbolVisitor visitor)
        {
            // nop
        }

        public override TResult Accept<TResult>(SymbolVisitor<TResult> visitor)
        {
            return default;
        }

        public override TResult Accept<TArgument, TResult>(SymbolVisitor<TArgument, TResult> visitor, TArgument argument)
        {
            return default;
        }

        public override void Accept(Microsoft.CodeAnalysis.SymbolVisitor visitor)
        {
            // nop
        }

        public override TResult Accept<TResult>(Microsoft.CodeAnalysis.SymbolVisitor<TResult> visitor)
        {
            return default;
        }
    }
}
