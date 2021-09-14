// NOTE: This is an auto-generated file. However, it will not be changed or regenerated unless you delete it.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;


namespace MetaDslx.Languages.Core.Model.Internal
{
    /// <summary>
    /// Class for implementing the behavior of the model elements.
    /// </summary>
    public class CoreImplementation : CoreImplementationBase
    {
        public override EnumTypeBuilder EnumLiteral_ComputeProperty_Type(EnumLiteralBuilder _this)
        {
            return _this.MParent as EnumTypeBuilder;
        }

        public override IReadOnlyList<EnumLiteralBuilder> EnumType_ComputeProperty_Literals(EnumTypeBuilder _this)
        {
            return _this.Members.OfType<EnumLiteralBuilder>().ToList();
        }
    }
}

