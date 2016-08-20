using MetaDslx.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Soal.Internal
{
    internal class SoalImplementation : SoalImplementationBase
    {
        public override void InterfaceReference(InterfaceReferenceBuilder _this)
        {
            base.InterfaceReference(_this);
            _this.OptionalNameLazy = () => _this.OptionalName != null ? _this.OptionalName : (_this.Interface != null ? _this.Interface.Name : string.Empty);
        }

    }
}
