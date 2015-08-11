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

        public static bool IsMetaName(this ModelProperty property)
        {
            if (property == null) return false;
            return property.Annotations.Any(a => a is NameAttribute);
        }
    }

    public class MetaBuiltInTypes
    {
        private static List<MetaType> types = new List<MetaType>();

        public static IEnumerable<MetaType> Types
        {
            get { return MetaBuiltInTypes.types; }
        }

        static MetaBuiltInTypes()
        {
            MetaBuiltInTypes.types.Add(Meta.Constants.Object);
            MetaBuiltInTypes.types.Add(Meta.Constants.String);
            MetaBuiltInTypes.types.Add(Meta.Constants.Int);
            MetaBuiltInTypes.types.Add(Meta.Constants.Long);
            MetaBuiltInTypes.types.Add(Meta.Constants.Float);
            MetaBuiltInTypes.types.Add(Meta.Constants.Double);
            MetaBuiltInTypes.types.Add(Meta.Constants.Byte);
            MetaBuiltInTypes.types.Add(Meta.Constants.Bool);
            MetaBuiltInTypes.types.Add(Meta.Constants.Void);

            MetaBuiltInTypes.types.Add(Meta.Constants.ModelObject);

            MetaBuiltInTypes.types.Add(Meta.Constants.None);
            MetaBuiltInTypes.types.Add(Meta.Constants.Any);

            MetaBuiltInTypes.types.Add(Meta.Constants.ModelObjectList);
        }

    }

    public class MetaBuiltInFunctions
    {
        private static List<MetaFunction> functions = new List<MetaFunction>();

        public static IEnumerable<MetaFunction> Functions
        {
            get { return MetaBuiltInFunctions.functions; }
        }

        static MetaBuiltInFunctions()
        {
            MetaBuiltInFunctions.functions.Add(Meta.Constants.TypeOf);
            MetaBuiltInFunctions.functions.Add(Meta.Constants.GetValueType);
            MetaBuiltInFunctions.functions.Add(Meta.Constants.GetReturnType);
            MetaBuiltInFunctions.functions.Add(Meta.Constants.CurrentType);
            MetaBuiltInFunctions.functions.Add(Meta.Constants.TypeCheck);
            MetaBuiltInFunctions.functions.Add(Meta.Constants.Balance);
            MetaBuiltInFunctions.functions.Add(Meta.Constants.Resolve1);
            MetaBuiltInFunctions.functions.Add(Meta.Constants.Resolve2);
            MetaBuiltInFunctions.functions.Add(Meta.Constants.ResolveName1);
            MetaBuiltInFunctions.functions.Add(Meta.Constants.ResolveName2);
            MetaBuiltInFunctions.functions.Add(Meta.Constants.ResolveType1);
            MetaBuiltInFunctions.functions.Add(Meta.Constants.ResolveType2);
            MetaBuiltInFunctions.functions.Add(Meta.Constants.Bind1);
            MetaBuiltInFunctions.functions.Add(Meta.Constants.Bind2);
            MetaBuiltInFunctions.functions.Add(Meta.Constants.Bind3);
            MetaBuiltInFunctions.functions.Add(Meta.Constants.Bind4);
            MetaBuiltInFunctions.functions.Add(Meta.Constants.SelectOfType1);
            MetaBuiltInFunctions.functions.Add(Meta.Constants.SelectOfType2);
            MetaBuiltInFunctions.functions.Add(Meta.Constants.SelectOfName1);
            MetaBuiltInFunctions.functions.Add(Meta.Constants.SelectOfName2);
        }
    }

    public static class MetaScopeEntryProperties
    {
        public static readonly ModelProperty SymbolTreeNodesProperty =
            ModelProperty.Register("SymbolTreeNodes", typeof(IList<object>), typeof(MetaScopeEntryProperties));

        public static readonly ModelProperty NameTreeNodesProperty =
            ModelProperty.Register("NameTreeNodes", typeof(IList<object>), typeof(MetaScopeEntryProperties));

        public static readonly ModelProperty CanMergeProperty =
            ModelProperty.Register("CanMerge", typeof(bool), typeof(MetaScopeEntryProperties));

    }

    [Scope]
    public class RootScope : ModelObject
    {
        public RootScope()
        {
            this.MSet(RootScope.BuiltInEntriesProperty, new ModelList<ModelObject>(this, RootScope.BuiltInEntriesProperty));
            this.MSet(RootScope.EntriesProperty, new ModelList<ModelObject>(this, RootScope.EntriesProperty));
            foreach (var type in MetaBuiltInTypes.Types)
            {
                this.BuiltInEntries.Add((ModelObject)type);
            }
            foreach (var func in MetaBuiltInFunctions.Functions)
            {
                this.BuiltInEntries.Add((ModelObject)func);
            }
        }

        [ScopeEntry]
        public static readonly ModelProperty BuiltInEntriesProperty =
             ModelProperty.Register("BuiltInEntries", typeof(IList<ModelObject>), typeof(RootScope));

        [Containment]
        [ScopeEntry]
        public static readonly ModelProperty EntriesProperty =
             ModelProperty.Register("Entries", typeof(IList<ModelObject>), typeof(RootScope));

        public IList<ModelObject> BuiltInEntries
        {
            get
            {
                return (IList<ModelObject>)this.MGet(RootScope.BuiltInEntriesProperty);
            }
        }

        public IList<ModelObject> Entries
        {
            get
            {
                return (IList<ModelObject>)this.MGet(RootScope.EntriesProperty);
            }
        }

    }

    internal class MetaImplementation : MetaImplementationBase
    {
        public override void MetaFunction_MetaFunction(MetaFunction @this)
        {
            base.MetaFunction_MetaFunction(@this);
            MetaFunctionType type = MetaModelFactory.Instance.CreateMetaFunctionType();
            ((ModelObject)type).MUnSet(Meta.MetaFunctionType.ParameterTypesProperty);
            ((ModelObject)type).MLazySet(Meta.MetaFunctionType.ParameterTypesProperty, new Lazy<object>(() => new ModelMultiList<MetaType>((ModelObject)type, Meta.MetaFunctionType.ParameterTypesProperty, @this.Parameters.Select(p => new Lazy<object>(() => p.Type))), false));
            ((ModelObject)type).MLazySet(Meta.MetaFunctionType.ReturnTypeProperty, new Lazy<object>(() => @this.ReturnType));
            ((ModelObject)@this).MSet(Meta.MetaFunction.TypeProperty, type);
        }

        public override void MetaUnaryExpression_MetaUnaryExpression(MetaUnaryExpression @this)
        {
            base.MetaUnaryExpression_MetaUnaryExpression(@this);
            ((ModelObject)@this).MLazyAdd(Meta.MetaBoundExpression.ArgumentsProperty, new Lazy<object>(() => @this.Expression));
        }

        public override void MetaBinaryExpression_MetaBinaryExpression(MetaBinaryExpression @this)
        {
            base.MetaBinaryExpression_MetaBinaryExpression(@this);
            ((ModelObject)@this).MLazyAdd(Meta.MetaBoundExpression.ArgumentsProperty, new Lazy<object>(() => @this.Left));
            ((ModelObject)@this).MLazyAdd(Meta.MetaBoundExpression.ArgumentsProperty, new Lazy<object>(() => @this.Right));
        }

        public override void MetaNewCollectionExpression_MetaNewCollectionExpression(MetaNewCollectionExpression @this)
        {
            base.MetaNewCollectionExpression_MetaNewCollectionExpression(@this);
            ((ModelObject)@this).MLazySetChild(Meta.MetaNewCollectionExpression.ValuesProperty, Meta.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => @this.TypeReference.InnerType));
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
                    case MetaCollectionKind.MultiSet:
                        return "ModelMultiSet<" + collection.InnerType.CSharpName() + ">";
                    case MetaCollectionKind.MultiList:
                        return "ModelMultiList<" + collection.InnerType.CSharpName() + ">";
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
                    case MetaCollectionKind.MultiSet:
                        return "ICollection<" + collection.InnerType.CSharpImplName() + ">";
                    case MetaCollectionKind.List:
                    case MetaCollectionKind.MultiList:
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
                    case MetaCollectionKind.MultiSet:
                        return "ICollection<" + collection.InnerType.CSharpFullImplName() + ">";
                    case MetaCollectionKind.List:
                    case MetaCollectionKind.MultiList:
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
                    case MetaCollectionKind.MultiSet:
                        return "ICollection<" + collection.InnerType.CSharpPublicName() + ">";
                    case MetaCollectionKind.List:
                    case MetaCollectionKind.MultiList:
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
                    case MetaCollectionKind.MultiSet:
                        return "ICollection<" + collection.InnerType.CSharpFullPublicName() + ">";
                    case MetaCollectionKind.List:
                    case MetaCollectionKind.MultiList:
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
