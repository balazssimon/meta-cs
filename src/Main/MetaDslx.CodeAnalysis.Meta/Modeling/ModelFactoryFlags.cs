using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Modeling
{
    [Flags]
    public enum ModelFactoryFlags
    {
        None = 0x00,
        DontMakeSymbolsCreated = 0x01,
        CreateWeakSymbols = 0x02,
        CreateStrongSymbols = 0x04
    }

}
