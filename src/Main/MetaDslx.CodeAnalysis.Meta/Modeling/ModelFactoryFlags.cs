using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Modeling
{
    [Flags]
    public enum ModelFactoryFlags
    {
        None = 0x00,
        DontMakeObjectsCreated = 0x01,
        CreateWeakObjects = 0x02,
        CreateStrongObjects = 0x04
    }

}
