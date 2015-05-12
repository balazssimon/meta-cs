using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetaDslx.Core
{
    internal class MetaImplementation : MetaImplementationBase
    {
        public override MetaNamespace MetaType_Namespace(MetaType @this)
        {
            return @this.Model.Namespace;
        }
    }
}
