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
        internal override void CoreBuilderInstance(CoreBuilderInstance _this)
        {
            base.CoreBuilderInstance(_this);
            _this.Object.DotNetName = "System.Object";
            _this.Void.DotNetName = "System.Void";
            _this.Boolean.DotNetName = "System.Boolean";
            _this.Char.DotNetName = "System.Char";
            _this.SByte.DotNetName = "System.SByte";
            _this.Byte.DotNetName = "System.Byte";
            _this.Int16.DotNetName = "System.Int16";
            _this.UInt16.DotNetName = "System.UInt16";
            _this.Int32.DotNetName = "System.Int32";
            _this.UInt32.DotNetName = "System.UInt32";
            _this.Int64.DotNetName = "System.Int64";
            _this.UInt64.DotNetName = "System.UInt64";
            _this.Decimal.DotNetName = "System.Decimal";
            _this.Single.DotNetName = "System.Single";
            _this.Double.DotNetName = "System.Double";
            _this.String.DotNetName = "System.String";
            _this.SystemType.DotNetName = "System.Type";
            _this.SystemEnum.DotNetName = "System.Enum";
        }

        public override EnumTypeBuilder EnumLiteral_ComputeProperty_Type(EnumLiteralBuilder _this)
        {
            return _this.MParent as EnumTypeBuilder;
        }

        public override IReadOnlyList<EnumLiteralBuilder> EnumType_ComputeProperty_Literals(EnumTypeBuilder _this)
        {
            return _this.Members.OfType<EnumLiteralBuilder>().ToList();
        }

        public override DataTypeBuilder DataType_ComputeProperty_ResolvedType(DataTypeBuilder _this)
        {
            return _this;
        }

        public override NamedTypeBuilder GenericTypeReference_ComputeProperty_ConstructedType(GenericTypeReferenceBuilder _this)
        {
            return _this.ReferencedType; // TODO:MetaDslx
        }

        public override DataTypeBuilder GenericTypeReference_ComputeProperty_ResolvedType(GenericTypeReferenceBuilder _this)
        {
            return _this.ConstructedType;
        }

    }
}

