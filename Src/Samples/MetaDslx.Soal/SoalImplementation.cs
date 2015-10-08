using MetaDslx.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Soal
{
    internal class SoalImplementation : SoalImplementationBase
    {
        public override string ComponentInterface_Name(ComponentInterface @this)
        {
            if (((ModelObject)@this).MIsValueCreated(SoalDescriptor.ComponentInterface.InterfaceProperty))
            {
                return @this.OptionalName != null ? @this.OptionalName : @this.Interface.Name;
            }
            else
            {
                return @this.OptionalName ?? string.Empty;
            }
        }
    }
}
