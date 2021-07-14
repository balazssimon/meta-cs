using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [Symbol(SymbolParts = SymbolParts.None, SubSymbolKindType = "StatementKind")]
    public abstract partial class StatementSymbol : NonDeclaredSymbol
    {

    }
}
