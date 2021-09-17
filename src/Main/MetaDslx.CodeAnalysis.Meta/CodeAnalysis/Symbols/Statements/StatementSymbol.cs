using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [Symbol(SymbolParts = SymbolParts.None)]
    public abstract partial class StatementSymbol : NonDeclaredSymbol
    {
        public virtual ImmutableArray<LocalSymbol> DeclaredLocals => ImmutableArray<LocalSymbol>.Empty;

        protected virtual Location GetLocation()
        {
            return this.Locations.FirstOrNone();
        }
    }
}
