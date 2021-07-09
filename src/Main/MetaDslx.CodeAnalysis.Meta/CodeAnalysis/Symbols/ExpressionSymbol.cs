using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [Symbol(SubSymbolKindType = "ExpressionKind")]
    public abstract partial class ExpressionSymbol : NonDeclaredSymbol
    {
    }
}
