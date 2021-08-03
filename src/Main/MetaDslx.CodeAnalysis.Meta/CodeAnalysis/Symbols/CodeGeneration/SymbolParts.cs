﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [Flags]
    public enum SymbolParts
    {
        None = 0,
        Error = 1,
        Source = 2,
        Metadata = 4,
        All = Error | Source | Metadata
    }
}
            