using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [Flags]
    public enum CompleteMethodParameters
    {
        None = 0,
        LocationOpt = 1,
        Diagnostics = 2,
        CancellationToken = 4,
        All = Diagnostics | CancellationToken,
        AllWithLocation = LocationOpt | All
    }
}
