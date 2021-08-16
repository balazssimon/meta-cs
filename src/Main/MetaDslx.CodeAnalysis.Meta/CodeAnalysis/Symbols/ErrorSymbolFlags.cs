using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [Flags]
    public enum ErrorSymbolFlags
    {
        None = 0,
        Unreported = 1,
        Wrapped = 2,
        UnreportedWrapped = Unreported | Wrapped
    }
}
