using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [Symbol(SymbolParts = SymbolParts.None)]
    public abstract partial class ExpressionSymbol : NonDeclaredSymbol
    {
        public virtual TypeSymbol Type => null;
        public virtual TypeSymbol ExpectedType => null;
    }
}
