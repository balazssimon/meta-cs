using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public enum RetargetOptions : byte
    {
        RetargetPrimitiveTypesByName = 0,
        RetargetPrimitiveTypesByTypeCode = 1,
    }
}
