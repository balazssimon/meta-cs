using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetaDslx.Core
{
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
