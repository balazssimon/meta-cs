using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetaDslx.Core
{
    public class MetaBuiltInType
    {
        private static List<MetaType> types = new List<MetaType>();

        public static readonly MetaPrimitiveType Object;
        public static readonly MetaPrimitiveType String;
        public static readonly MetaPrimitiveType Int;
        public static readonly MetaPrimitiveType Long;
        public static readonly MetaPrimitiveType Float;
        public static readonly MetaPrimitiveType Double;
        public static readonly MetaPrimitiveType Byte;
        public static readonly MetaPrimitiveType Bool;
        public static readonly MetaPrimitiveType Void;

        public static IEnumerable<MetaType> Types
        {
            get { return MetaBuiltInType.types; }
        }

        static MetaBuiltInType()
        {
            MetaBuiltInType.Object = MetaFactory.Instance.CreateMetaPrimitiveType();
            MetaBuiltInType.Object.Name = "object";
            MetaBuiltInType.types.Add(MetaBuiltInType.Object);
            MetaBuiltInType.String = MetaFactory.Instance.CreateMetaPrimitiveType();
            MetaBuiltInType.String.Name = "string";
            MetaBuiltInType.types.Add(MetaBuiltInType.String);
            MetaBuiltInType.Int = MetaFactory.Instance.CreateMetaPrimitiveType();
            MetaBuiltInType.Int.Name = "int";
            MetaBuiltInType.types.Add(MetaBuiltInType.Int);
            MetaBuiltInType.Long = MetaFactory.Instance.CreateMetaPrimitiveType();
            MetaBuiltInType.Long.Name = "long";
            MetaBuiltInType.types.Add(MetaBuiltInType.Long);
            MetaBuiltInType.Float = MetaFactory.Instance.CreateMetaPrimitiveType();
            MetaBuiltInType.Float.Name = "float";
            MetaBuiltInType.types.Add(MetaBuiltInType.Float);
            MetaBuiltInType.Double = MetaFactory.Instance.CreateMetaPrimitiveType();
            MetaBuiltInType.Double.Name = "double";
            MetaBuiltInType.types.Add(MetaBuiltInType.Double);
            MetaBuiltInType.Byte = MetaFactory.Instance.CreateMetaPrimitiveType();
            MetaBuiltInType.Byte.Name = "byte";
            MetaBuiltInType.types.Add(MetaBuiltInType.Byte);
            MetaBuiltInType.Bool = MetaFactory.Instance.CreateMetaPrimitiveType();
            MetaBuiltInType.Bool.Name = "bool";
            MetaBuiltInType.types.Add(MetaBuiltInType.Bool);
            MetaBuiltInType.Void = MetaFactory.Instance.CreateMetaPrimitiveType();
            MetaBuiltInType.Void.Name = "void";
            MetaBuiltInType.types.Add(MetaBuiltInType.Void);
        }
    }

    internal class MetaImplementation : MetaImplementationBase
    {
        public override void MetaProperty_MetaProperty(MetaProperty @this)
        {
            base.MetaProperty_MetaProperty(@this);
            @this.Kind = MetaPropertyKind.Normal;
        }

        public override MetaNamespace MetaType_Namespace(MetaType @this)
        {
            return @this.Model.Namespace;
        }

        public override ICollection<MetaOperation> MetaClass_GetAllOperations(MetaClass @this)
        {
            return new List<MetaOperation>();
        }

        public override ICollection<MetaProperty> MetaClass_GetAllProperties(MetaClass @this)
        {
            return new List<MetaProperty>();
        }

        public override ICollection<MetaClass> MetaClass_GetAllSuperClasses(MetaClass @this)
        {
            return new List<MetaClass>();
        }

        public override void MetaCollectionType_MetaCollectionType(MetaCollectionType @this)
        {
            base.MetaCollectionType_MetaCollectionType(@this);
            @this.Kind = MetaCollectionKind.List;
        }
    }

    internal static class MetaModelExtensions
    {
        public static string CSharpPrefix(this MetaNamespace @this)
        {
            return string.Empty;
        }

        public static string CSharpName(this MetaModel @this)
        {
            if (@this == null) return string.Empty;
            return @this.Name;
        }

        public static string CSharpName(this MetaType @this)
        {
            if (@this == null) return string.Empty;
            return @this.Name;
        }

        public static string CSharpImplName(this MetaType @this)
        {
            if (@this == null) return string.Empty;
            return @this.Name;
        }

        public static string CSharpPublicName(this MetaType @this)
        {
            if (@this == null) return string.Empty;
            return @this.Name;
        }

        public static List<MetaClass> GetAllSuperClasses(this MetaClass @this, bool includeSelf)
        {
            return new List<MetaClass>();
        }

    }
}
