using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Declarations
{
    public enum SymbolPropertyOwner
    {
        Current,
        ParentSymbolDef,
        ParentScope,
        AncestorSymbolDef,
        AncestorScope
    }
}
