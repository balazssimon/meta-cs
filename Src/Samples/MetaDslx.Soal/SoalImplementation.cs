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
            return @this.OptionalName != null ? @this.OptionalName : @this.Interface.Name;
        }
    }
}
