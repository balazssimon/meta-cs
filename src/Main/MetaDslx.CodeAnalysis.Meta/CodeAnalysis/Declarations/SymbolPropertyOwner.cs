using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis
{
    public enum SymbolPropertyOwner
    {
        CurrentSymbol,
        CurrentScope,
        AncestorSymbol,
        AncestorScope
    }
}
