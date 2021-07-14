using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [Flags]
    public enum SymbolParts
    {
        None = 0,
        Source = 1,
        Metadata = 2,
        All = Source | Metadata
    }
}
            