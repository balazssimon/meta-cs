using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [Symbol(SymbolParts = SymbolParts.None)]
    public abstract partial class StatementSymbol : NonDeclaredSymbol
    {
        protected virtual Location GetLocation()
        {
            return this.Locations.FirstOrNone();
        }
    }
}
