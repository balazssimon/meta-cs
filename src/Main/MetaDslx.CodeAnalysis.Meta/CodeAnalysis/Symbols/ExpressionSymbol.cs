using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [Symbol(SymbolParts = SymbolParts.None, SubSymbolKindType = "ExpressionKind")]
    public abstract partial class ExpressionSymbol : NonDeclaredSymbol
    {
    }
}
