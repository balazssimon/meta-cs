using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetaDslx.Core
{
    [System.AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
    public sealed class NameAttribute : Attribute
    {

    }

    [System.AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class | AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
    public sealed class TypeAttribute : Attribute
    {

    }

    [System.AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
    public sealed class ScopeEntryAttribute : Attribute
    {
    }

    [System.AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    public sealed class ScopeAttribute : Attribute
    {
    }

    [System.AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
    public sealed class ImportedScopeAttribute : Attribute
    {
    }

    [System.AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
    public sealed class ImportedEntryAttribute : Attribute
    {
    }

    [System.AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
    public sealed class InheritedScopeAttribute : Attribute
    {
    }

    public static class MetaExtensions
    {
        public static bool IsMetaScope(this ModelObject symbol)
        {
            if (symbol == null) return false;
            if (symbol.GetType().IsMetaScope()) return true;
            foreach (var intf in symbol.GetType().GetInterfaces())
            {
                if (intf.IsMetaScope()) return true;
            }
            return false;
        }

        public static bool IsMetaScope(this Type symbolType)
        {
            if (symbolType == null) return false;
            var attributes = symbolType.GetCustomAttributes(typeof(ScopeAttribute), true);
            return attributes.Length > 0;
        }

        public static bool IsMetaType(this ModelObject symbol)
        {
            if (symbol == null) return false;
            if (symbol.GetType().IsMetaType()) return true;
            foreach (var intf in symbol.GetType().GetInterfaces())
            {
                if (intf.IsMetaType()) return true;
            }
            return false;
        }

        public static bool IsMetaType(this Type symbolType)
        {
            if (symbolType == null) return false;
            var attributes = symbolType.GetCustomAttributes(typeof(TypeAttribute), true);
            return attributes.Length > 0;
        }
    }

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
        public static readonly MetaPrimitiveType Any;

        public static IEnumerable<MetaType> Types
        {
            get { return MetaBuiltInType.types; }
        }

        static MetaBuiltInType()
        {
            MetaBuiltInType.Object = MetaModelFactory.Instance.CreateMetaPrimitiveType();
            MetaBuiltInType.Object.Name = "object";
            MetaBuiltInType.types.Add(MetaBuiltInType.Object);
            MetaBuiltInType.String = MetaModelFactory.Instance.CreateMetaPrimitiveType();
            MetaBuiltInType.String.Name = "string";
            MetaBuiltInType.types.Add(MetaBuiltInType.String);
            MetaBuiltInType.Int = MetaModelFactory.Instance.CreateMetaPrimitiveType();
            MetaBuiltInType.Int.Name = "int";
            MetaBuiltInType.types.Add(MetaBuiltInType.Int);
            MetaBuiltInType.Long = MetaModelFactory.Instance.CreateMetaPrimitiveType();
            MetaBuiltInType.Long.Name = "long";
            MetaBuiltInType.types.Add(MetaBuiltInType.Long);
            MetaBuiltInType.Float = MetaModelFactory.Instance.CreateMetaPrimitiveType();
            MetaBuiltInType.Float.Name = "float";
            MetaBuiltInType.types.Add(MetaBuiltInType.Float);
            MetaBuiltInType.Double = MetaModelFactory.Instance.CreateMetaPrimitiveType();
            MetaBuiltInType.Double.Name = "double";
            MetaBuiltInType.types.Add(MetaBuiltInType.Double);
            MetaBuiltInType.Byte = MetaModelFactory.Instance.CreateMetaPrimitiveType();
            MetaBuiltInType.Byte.Name = "byte";
            MetaBuiltInType.types.Add(MetaBuiltInType.Byte);
            MetaBuiltInType.Bool = MetaModelFactory.Instance.CreateMetaPrimitiveType();
            MetaBuiltInType.Bool.Name = "bool";
            MetaBuiltInType.types.Add(MetaBuiltInType.Bool);
            MetaBuiltInType.Void = MetaModelFactory.Instance.CreateMetaPrimitiveType();
            MetaBuiltInType.Void.Name = "void";
            MetaBuiltInType.types.Add(MetaBuiltInType.Void);
            MetaBuiltInType.Any = MetaModelFactory.Instance.CreateMetaPrimitiveType();
            MetaBuiltInType.Any.Name = null;
            MetaBuiltInType.types.Add(MetaBuiltInType.Any);
        }
         
    }

    public enum MetaScopeEntryKind
    {
        None,
        Name,
        Type
    }

    public static class MetaScopeEntryProperties
    {
        public static readonly ModelProperty KindProperty =
            ModelProperty.Register("Kind", typeof(MetaScopeEntryKind), typeof(MetaScopeEntryProperties));

        public static readonly ModelProperty NameProperty =
            ModelProperty.Register("Name", typeof(object), typeof(MetaScopeEntryProperties));

        public static readonly ModelProperty CanMergeProperty =
            ModelProperty.Register("CanMerge", typeof(bool), typeof(MetaScopeEntryProperties));

        public static readonly ModelProperty EntriesProperty =
             ModelProperty.Register("Entries", typeof(IList<object>), typeof(MetaScopeEntryProperties));

        public static readonly ModelProperty ImportedEntriesProperty =
            ModelProperty.Register("ImportedEntries", typeof(IList<object>), typeof(MetaScopeEntryProperties));

        public static readonly ModelProperty ImportedScopesProperty =
            ModelProperty.Register("ImportedScopes", typeof(IList<object>), typeof(MetaScopeEntryProperties));

        public static readonly ModelProperty InheritedScopesProperty =
            ModelProperty.Register("InheritedScopes", typeof(IList<object>), typeof(MetaScopeEntryProperties));

    }

    [Scope]
    public class RootScope : ModelObject
    {
        public RootScope()
        {
            this.MSet(RootScope.EntriesProperty, new ModelList<ModelObject>(this, RootScope.EntriesProperty));
        }

        [Containment]
        [ScopeEntry]
        public static readonly ModelProperty EntriesProperty =
             ModelProperty.Register("Entries", typeof(IList<ModelObject>), typeof(RootScope));

        public IList<ModelObject> Entries
        {
            get
            {
                return (IList<ModelObject>)this.MGet(RootScope.EntriesProperty);
            }
        }

    }

    //internal class MetaModelImplementation : MetaModelImplementationBase
    internal class MetaImplementation : MetaImplementationBase
    {
        public override void MetaProperty_MetaProperty(MetaProperty @this)
        {
            base.MetaProperty_MetaProperty(@this);
            @this.Kind = MetaPropertyKind.Normal;
            ((ModelObject)@this).MMakeDefault();
        }

        public override MetaNamespace MetaDeclaration_Namespace(MetaDeclaration @this)
        {
            if (@this.Model == null) return null;
            return @this.Model.Namespace;
        }

        public override IList<MetaOperation> MetaClass_GetAllOperations(MetaClass @this)
        {
            List<MetaOperation> result = new List<MetaOperation>();
            foreach (var cls in @this.GetAllSuperClasses())
            {
                foreach (var oper in cls.Operations)
                {
                    result.Add(oper);
                }
            }
            foreach (var oper in @this.Operations)
            {
                result.Add(oper);
            }
            return result;
        }

        public override IList<MetaProperty> MetaClass_GetAllProperties(MetaClass @this)
        {
            List<MetaProperty> result = new List<MetaProperty>();
            foreach (var cls in @this.GetAllSuperClasses())
            {
                foreach (var prop in cls.Properties)
                {
                    result.Add(prop);
                }
            }
            foreach (var prop in @this.Properties)
            {
                result.Add(prop);
            }
            return result;
        }

        public override IList<MetaClass> MetaClass_GetAllSuperClasses(MetaClass @this)
        {
            List<MetaClass> result = new List<MetaClass>();
            foreach (var super in @this.SuperClasses)
            {
                ICollection<MetaClass> allSupers = super.GetAllSuperClasses();
                foreach (var superSuper in allSupers)
                {
                    if (!result.Contains(superSuper))
                    {
                        result.Add(superSuper);
                    }
                }
                if (!result.Contains(super))
                {
                    result.Add(super);
                }
            }
            return result;
        }

        public override void MetaCollectionType_MetaCollectionType(MetaCollectionType @this)
        {
            base.MetaCollectionType_MetaCollectionType(@this);
            @this.Kind = MetaCollectionKind.List;
            ((ModelObject)@this).MMakeDefault();
        }
    }

    internal static class MetaModelExtensions
    {
        public static string CSharpPrefix(this MetaNamespace @this)
        {
            return string.Empty;
        }

        public static string CSharpName(this MetaNamespace @this)
        {
            if (@this == null) return string.Empty;
            string result = @this.Name;
            MetaNamespace parent = ((ModelObject)@this).MParent as MetaNamespace;
            while(parent != null)
            {
                result = parent.Name + "." + result;
                parent = ((ModelObject)parent).MParent as MetaNamespace;
            }
            return result;
        }
        /*
        public static string CSharpName(this MetaScopeEntry @this)
        {
            if (@this == null) return string.Empty;
            MetaNamedElement ne = @this as MetaNamedElement;
            if (ne != null) return "Meta"+ne.Name;
            else return string.Empty;
        }*/

        public static string CSharpFullName(this MetaModel @this)
        {
            if (@this == null) return string.Empty;
            string nsName = @this.Namespace.CSharpName();
            if (!string.IsNullOrEmpty(nsName)) return "global::" + nsName + ".Meta";
            else return "Meta";
        }

        public static string CSharpFullName(this MetaType @this)
        {
            if (@this == null) return string.Empty;
            MetaDeclaration decl = @this as MetaDeclaration;
            string nsName = string.Empty;
            if (decl != null)
            {
                nsName = decl.Namespace.CSharpName();
                if (!string.IsNullOrEmpty(nsName)) return "global::" + nsName + "." + @this.CSharpName();
                else return @this.CSharpName();
            }
            else
            {
                return @this.CSharpName();
            }
        }

        public static string CSharpName(this MetaModel @this)
        {
            if (@this == null) return string.Empty;
            return "Meta";
        }

        public static string CSharpName(this MetaType @this)
        {
            if (@this == null) return string.Empty;
            MetaCollectionType collection = @this as MetaCollectionType;
            if (collection != null)
            {
                switch (collection.Kind)
                {
                    case MetaCollectionKind.Set:
                        return "ModelSet<" + collection.InnerType.CSharpName() + ">";
                    case MetaCollectionKind.List:
                        return "ModelList<" + collection.InnerType.CSharpName() + ">";
                    default:
                        return null;
                }
            }
            MetaNullableType nullable = @this as MetaNullableType;
            if (nullable != null)
            {
                return nullable.InnerType.CSharpName() + "?";
            }
            MetaPrimitiveType primitive = @this as MetaPrimitiveType;
            if (primitive != null)
            {
                return primitive.Name;
            }
            return "Meta" + ((MetaNamedElement)@this).Name;
        }

        public static string CSharpImplName(this MetaType @this)
        {
            if (@this == null) return string.Empty;
            MetaCollectionType collection = @this as MetaCollectionType;
            if (collection != null)
            {
                switch (collection.Kind)
                {
                    case MetaCollectionKind.Set:
                        return "ICollection<" + collection.InnerType.CSharpImplName() + ">";
                    case MetaCollectionKind.List:
                        return "IList<" + collection.InnerType.CSharpImplName() + ">";
                    default:
                        return null;
                }
            }
            MetaNullableType nullable = @this as MetaNullableType;
            if (nullable != null)
            {
                return nullable.InnerType.CSharpImplName() + "?";
            }
            MetaPrimitiveType primitive = @this as MetaPrimitiveType;
            if (primitive != null)
            {
                return primitive.Name;
            }
            return "Meta" + ((MetaNamedElement)@this).Name + "Impl";
        }

        public static string CSharpFullImplName(this MetaType @this)
        {
            if (@this == null) return string.Empty;
            MetaCollectionType collection = @this as MetaCollectionType;
            if (collection != null)
            {
                switch (collection.Kind)
                {
                    case MetaCollectionKind.Set:
                        return "ICollection<" + collection.InnerType.CSharpFullImplName() + ">";
                    case MetaCollectionKind.List:
                        return "IList<" + collection.InnerType.CSharpFullImplName() + ">";
                    default:
                        return null;
                }
            }
            MetaNullableType nullable = @this as MetaNullableType;
            if (nullable != null)
            {
                return nullable.InnerType.CSharpFullImplName() + "?";
            }
            MetaPrimitiveType primitive = @this as MetaPrimitiveType;
            if (primitive != null)
            {
                return primitive.Name;
            }
            return @this.CSharpFullName() + "Impl";
        }

        public static string CSharpPublicName(this MetaType @this)
        {
            if (@this == null) return string.Empty;
            MetaCollectionType collection = @this as MetaCollectionType;
            if (collection != null)
            {
                switch (collection.Kind)
                {
                    case MetaCollectionKind.Set:
                        return "ICollection<" + collection.InnerType.CSharpPublicName() + ">";
                    case MetaCollectionKind.List:
                        return "IList<" + collection.InnerType.CSharpPublicName() + ">";
                    default:
                        return null;
                }
            }
            MetaNullableType nullable = @this as MetaNullableType;
            if (nullable != null)
            {
                return nullable.InnerType.CSharpPublicName() + "?";
            }
            MetaPrimitiveType primitive = @this as MetaPrimitiveType;
            if (primitive != null)
            {
                return primitive.Name;
            }
            return "Meta" + ((MetaNamedElement)@this).Name;
        }

        public static string CSharpFullPublicName(this MetaType @this)
        {
            if (@this == null) return string.Empty;
            MetaCollectionType collection = @this as MetaCollectionType;
            if (collection != null)
            {
                switch (collection.Kind)
                {
                    case MetaCollectionKind.Set:
                        return "ICollection<" + collection.InnerType.CSharpFullPublicName() + ">";
                    case MetaCollectionKind.List:
                        return "IList<" + collection.InnerType.CSharpFullPublicName() + ">";
                    default:
                        return null;
                }
            }
            MetaNullableType nullable = @this as MetaNullableType;
            if (nullable != null)
            {
                return nullable.InnerType.CSharpFullPublicName() + "?";
            }
            MetaPrimitiveType primitive = @this as MetaPrimitiveType;
            if (primitive != null)
            {
                return primitive.Name;
            }
            return @this.CSharpFullName();
        }

        public static List<string> GetAllSuperPropertyNames(this MetaClass @this)
        {
            return GetAllSuperProperties(@this).Select(p => p.Name).ToList();
        }

        public static List<MetaProperty> GetAllSuperProperties(this MetaClass @this)
        {
            List<MetaProperty> result = new List<MetaProperty>();
            foreach (var super in @this.GetAllSuperClasses(false))
            {
                foreach (var prop in super.Properties)
                {
                    result.Add(prop);
                }
            }
            return result;
        }

        public static List<MetaClass> GetAllSuperClasses(this MetaClass @this, bool includeSelf)
        {
            if (@this == null) return new List<MetaClass>();
            List<MetaClass> result = new List<MetaClass>(@this.GetAllSuperClasses());
            if (includeSelf)
            {
                result.Add(@this);
            }
            return result;
        }

    }
}
