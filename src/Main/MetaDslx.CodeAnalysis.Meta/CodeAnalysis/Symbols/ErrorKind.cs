using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public enum ErrorKind
    {
        None,
        Invalid,
        Missing,
        Ambiguous,
        Inaccessible,
        Unsupported
    }
}
