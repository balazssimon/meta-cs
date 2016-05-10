using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

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
        private static List<MetaType> types;

        public static IEnumerable<MetaType> Types
        {
            get
            {
                if (MetaBuiltInTypes.types == null)
                {
                    MetaBuiltInTypes.types = new List<MetaType>();
                    if (MetaBuiltInTypes.types.Count == 0 && MetaInstance.Object != null)
                    {
                        MetaBuiltInTypes.types.Add(MetaInstance.Object);
                        MetaBuiltInTypes.types.Add(MetaInstance.String);
                        MetaBuiltInTypes.types.Add(MetaInstance.Int);
                        MetaBuiltInTypes.types.Add(MetaInstance.Long);
                        MetaBuiltInTypes.types.Add(MetaInstance.Float);
                        MetaBuiltInTypes.types.Add(MetaInstance.Double);
                        MetaBuiltInTypes.types.Add(MetaInstance.Byte);
                        MetaBuiltInTypes.types.Add(MetaInstance.Bool);
                        MetaBuiltInTypes.types.Add(MetaInstance.Void);
                        MetaBuiltInTypes.types.Add(MetaInstance.ModelObject);
                        MetaBuiltInTypes.types.Add(MetaInstance.ModelObjectList);
                    }
                }
                return MetaBuiltInTypes.types;
            }
        }
    }

    public class MetaBuiltInFunctions
    {
        private static List<MetaFunction> functions;

        public static IEnumerable<MetaFunction> Functions
        {
            get
            {
                if (MetaBuiltInFunctions.functions == null)
                {
                    MetaBuiltInFunctions.functions = new List<MetaFunction>();
                    if (MetaBuiltInFunctions.functions.Count == 0 && MetaInstance.TypeOf != null)
                    {
                        MetaBuiltInFunctions.functions.Add(MetaInstance.TypeOf);
                        MetaBuiltInFunctions.functions.Add(MetaInstance.GetValueType);
                        MetaBuiltInFunctions.functions.Add(MetaInstance.GetReturnType);
                        MetaBuiltInFunctions.functions.Add(MetaInstance.CurrentType);
                        MetaBuiltInFunctions.functions.Add(MetaInstance.TypeCheck);
                        MetaBuiltInFunctions.functions.Add(MetaInstance.Balance);
                        MetaBuiltInFunctions.functions.Add(MetaInstance.Resolve1);
                        MetaBuiltInFunctions.functions.Add(MetaInstance.Resolve2);
                        MetaBuiltInFunctions.functions.Add(MetaInstance.ResolveName1);
                        MetaBuiltInFunctions.functions.Add(MetaInstance.ResolveName2);
                        MetaBuiltInFunctions.functions.Add(MetaInstance.ResolveType1);
                        MetaBuiltInFunctions.functions.Add(MetaInstance.ResolveType2);
                        MetaBuiltInFunctions.functions.Add(MetaInstance.Bind1);
                        MetaBuiltInFunctions.functions.Add(MetaInstance.Bind2);
                        MetaBuiltInFunctions.functions.Add(MetaInstance.Bind3);
                        MetaBuiltInFunctions.functions.Add(MetaInstance.Bind4);
                        MetaBuiltInFunctions.functions.Add(MetaInstance.SelectOfType1);
                        MetaBuiltInFunctions.functions.Add(MetaInstance.SelectOfType2);
                        MetaBuiltInFunctions.functions.Add(MetaInstance.SelectOfName1);
                        MetaBuiltInFunctions.functions.Add(MetaInstance.SelectOfName2);
                    }
                }
                return MetaBuiltInFunctions.functions;
            }
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
        }

        public void AddMetaBuiltInEntries()
        {
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
            MetaFunctionType type = MetaFactory.Instance.CreateMetaFunctionType();
            ((ModelObject)type).MUnSet(MetaDescriptor.MetaFunctionType.ParameterTypesProperty);
            ((ModelObject)type).MLazySet(MetaDescriptor.MetaFunctionType.ParameterTypesProperty, new Lazy<object>(() => new ModelMultiList<MetaType>((ModelObject)type, MetaDescriptor.MetaFunctionType.ParameterTypesProperty, @this.Parameters.Select(p => new Lazy<object>(() => p.Type))), LazyThreadSafetyMode.PublicationOnly));
            ((ModelObject)type).MLazySet(MetaDescriptor.MetaFunctionType.ReturnTypeProperty, new Lazy<object>(() => @this.ReturnType, LazyThreadSafetyMode.PublicationOnly));
            ((ModelObject)@this).MSet(MetaDescriptor.MetaFunction.TypeProperty, type);
        }

        public override void MetaUnaryExpression_MetaUnaryExpression(MetaUnaryExpression @this)
        {
            base.MetaUnaryExpression_MetaUnaryExpression(@this);
            ((ModelObject)@this).MLazyAdd(MetaDescriptor.MetaBoundExpression.ArgumentsProperty, new Lazy<object>(() => @this.Expression, LazyThreadSafetyMode.PublicationOnly));
        }

        public override void MetaBinaryExpression_MetaBinaryExpression(MetaBinaryExpression @this)
        {
            base.MetaBinaryExpression_MetaBinaryExpression(@this);
            ((ModelObject)@this).MLazyAdd(MetaDescriptor.MetaBoundExpression.ArgumentsProperty, new Lazy<object>(() => @this.Left, LazyThreadSafetyMode.PublicationOnly));
            ((ModelObject)@this).MLazyAdd(MetaDescriptor.MetaBoundExpression.ArgumentsProperty, new Lazy<object>(() => @this.Right, LazyThreadSafetyMode.PublicationOnly));
        }

        public override void MetaNewCollectionExpression_MetaNewCollectionExpression(MetaNewCollectionExpression @this)
        {
            base.MetaNewCollectionExpression_MetaNewCollectionExpression(@this);
            ((ModelObject)@this).MLazySetChild(MetaDescriptor.MetaNewCollectionExpression.ValuesProperty, MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => @this.TypeReference.InnerType, LazyThreadSafetyMode.PublicationOnly));
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
        private const string ImmutablePrefix = "Immutable.";

        private static string GetPrefix(bool immutable)
        {
            if (immutable) return ImmutablePrefix;
            else return string.Empty;
        }

        public static bool HasSameMetaModel(this ModelObject @this, ModelObject mobj)
        {
            if (@this == null || @this.MMetaModel == null) return false;
            if (mobj == null || mobj.MMetaModel == null) return false;
            return @this.MMetaModel == mobj.MMetaModel;
        }

        public static string CSharpName(this MetaNamespace @this, bool immutable = false)
        {
            if (@this == null) return string.Empty;
            string result = @this.Name;
            if (immutable) result += "." + ImmutablePrefix;
            MetaNamespace parent = ((ModelObject)@this).MParent as MetaNamespace;
            while (parent != null)
            {
                result = parent.Name + "." + result;
                parent = ((ModelObject)parent).MParent as MetaNamespace;
            }
            return result;
        }

        public static string CSharpName(this MetaModel @this, bool immutable = false)
        {
            if (@this == null) return string.Empty;
            return GetPrefix(immutable) + @this.Name;
        }

        public static string CSharpFullName(this MetaModel @this, bool immutable = false)
        {
            if (@this == null) return string.Empty;
            string nsName = @this.Namespace.CSharpName(immutable);
            if (!string.IsNullOrEmpty(nsName)) return "global::" + nsName + "." + GetPrefix(immutable) + @this.Name;
            else return "global::" + GetPrefix(immutable) + @this.Name;
        }

        public static string CSharpName(this MetaType @this, bool immutable = false)
        {
            if (@this == null) return string.Empty;
            MetaCollectionType collection = @this as MetaCollectionType;
            if (collection != null)
            {
                string innerName = null;
                if (((ModelObject)collection.InnerType).HasSameMetaModel((ModelObject)@this)) innerName = collection.InnerType.CSharpName(immutable);
                else innerName = collection.InnerType.CSharpFullName(immutable);
                if (immutable)
                {
                    switch (collection.Kind)
                    {
                        case MetaCollectionKind.Set:
                            return "global::MetaDslx.Core.Immutable.ImmutableModelSet<" + innerName + ">";
                        case MetaCollectionKind.List:
                            return "global::MetaDslx.Core.Immutable.ImmutableModelList<" + innerName + ">";
                        case MetaCollectionKind.MultiSet:
                            return "global::MetaDslx.Core.Immutable.ImmutableModelMultiSet<" + innerName + ">";
                        case MetaCollectionKind.MultiList:
                            return "global::MetaDslx.Core.Immutable.ImmutableModelMultiList<" + innerName + ">";
                        default:
                            return null;
                    }
                }
                else
                {
                    switch (collection.Kind)
                    {
                        case MetaCollectionKind.Set:
                            return "global::MetaDslx.Core.ModelSet<" + innerName + ">";
                        case MetaCollectionKind.List:
                            return "global::MetaDslx.Core.ModelList<" + innerName + ">";
                        case MetaCollectionKind.MultiSet:
                            return "global::MetaDslx.Core.ModelMultiSet<" + innerName + ">";
                        case MetaCollectionKind.MultiList:
                            return "global::MetaDslx.Core.ModelMultiList<" + innerName + ">";
                        default:
                            return null;
                    }
                }
            }
            MetaNullableType nullable = @this as MetaNullableType;
            if (nullable != null)
            {
                string innerName = null;
                if (((ModelObject)nullable.InnerType).HasSameMetaModel((ModelObject)@this)) innerName = nullable.InnerType.CSharpName(immutable);
                else innerName = nullable.InnerType.CSharpFullName(immutable);
                return innerName + "?";
            }
            MetaPrimitiveType primitive = @this as MetaPrimitiveType;
            if (primitive != null)
            {
                return primitive.Name;
            }
            return GetPrefix(immutable) + ((MetaNamedElement)@this).Name;
        }

        public static string CSharpFullName(this MetaType @this, bool immutable = false)
        {
            if (@this == null) return string.Empty;
            MetaCollectionType collection = @this as MetaCollectionType;
            if (collection != null)
            {
                string innerName = collection.InnerType.CSharpFullName(immutable);
                if (immutable)
                {
                    switch (collection.Kind)
                    {
                        case MetaCollectionKind.Set:
                            return "global::MetaDslx.Core.Immutable.ImmutableModelSet<" + innerName + ">";
                        case MetaCollectionKind.List:
                            return "global::MetaDslx.Core.Immutable.ImmutableModelList<" + innerName + ">";
                        case MetaCollectionKind.MultiSet:
                            return "global::MetaDslx.Core.Immutable.ImmutableModelMultiSet<" + innerName + ">";
                        case MetaCollectionKind.MultiList:
                            return "global::MetaDslx.Core.Immutable.ImmutableModelMultiList<" + innerName + ">";
                        default:
                            return null;
                    }
                }
                else
                {
                    switch (collection.Kind)
                    {
                        case MetaCollectionKind.Set:
                            return "global::MetaDslx.Core.ModelSet<" + innerName + ">";
                        case MetaCollectionKind.List:
                            return "global::MetaDslx.Core.ModelList<" + innerName + ">";
                        case MetaCollectionKind.MultiSet:
                            return "global::MetaDslx.Core.ModelMultiSet<" + innerName + ">";
                        case MetaCollectionKind.MultiList:
                            return "global::MetaDslx.Core.ModelMultiList<" + innerName + ">";
                        default:
                            return null;
                    }
                }
            }
            MetaNullableType nullable = @this as MetaNullableType;
            if (nullable != null)
            {
                string innerName = nullable.InnerType.CSharpFullName(immutable);
                return innerName + "?";
            }
            MetaPrimitiveType primitive = @this as MetaPrimitiveType;
            if (primitive != null)
            {
                return primitive.Name;
            }
            MetaDeclaration decl = @this as MetaDeclaration;
            string nsName = string.Empty;
            if (decl != null)
            {
                nsName = decl.Namespace.CSharpName(immutable);
                if (!string.IsNullOrEmpty(nsName)) return "global::" + nsName + "." + @this.CSharpName(immutable);
                else return @this.CSharpName(immutable);
            }
            else
            {
                return GetPrefix(immutable) + @this.CSharpName();
            }
        }

        public static string CSharpDescriptorName(this MetaModel @this)
        {
            return @this.CSharpName() + "Descriptor";
        }

        public static string CSharpFullDescriptorName(this MetaModel @this)
        {
            return @this.CSharpFullName() + "Descriptor";
        }

        public static string CSharpInstancesName(this MetaModel @this)
        {
            return @this.CSharpName() + "Instance";
        }

        public static string CSharpFullInstancesName(this MetaModel @this)
        {
            return @this.CSharpFullName() + "Instance";
        }

        public static string CSharpFactoryName(this MetaModel @this, bool immutable = false)
        {
            return GetPrefix(immutable) + @this.CSharpName() + "Factory";
        }

        public static string CSharpFullFactoryName(this MetaModel @this, bool immutable = false)
        {
            return GetPrefix(immutable) + @this.CSharpFullName() + "Factory";
        }

        public static string CSharpFullImplementationName(this MetaModel @this)
        {
            return @this.CSharpFullName() + "ImplementationProvider.Implementation";
        }
        public static string GetCSharpValue(this MetaExpression @this)
        {
            MetaConstantExpression mce = @this as MetaConstantExpression;
            if (mce != null)
            {
                if (mce.Value != null) return mce.Value.ToString();
                else return string.Empty;
            }
            else
            {
                return string.Empty;
            }
        }

        public static string BuiltInName(this MetaDeclaration @this)
        {
            foreach (var annot in @this.Annotations)
            {
                if (annot.Name == "BuiltInName")
                {
                    foreach (var prop in annot.Properties)
                    {
                        if (prop.Name == "Name")
                        {
                            return prop.Value.GetCSharpValue();
                        }
                    }
                }
            }
            return @this.Name;
        }

        public static string CSharpFullFactoryMethodName(this MetaClass @this, bool immutable = false)
        {
            return @this.Model.CSharpFullFactoryName(immutable) + ".Instance.Create" + @this.CSharpName();
        }

        public static string CSharpDescriptorName(this MetaDeclaration @this)
        {
            return @this.BuiltInName();
        }

        public static string CSharpDescriptorName(this MetaProperty @this)
        {
            return @this.Name + "Property";
        }

        public static string CSharpFullDescriptorName(this MetaDeclaration @this)
        {
            return @this.Model.CSharpFullDescriptorName() + "." + @this.CSharpDescriptorName();
        }

        public static string CSharpFullDescriptorName(this MetaProperty @this)
        {
            return @this.Class.CSharpFullDescriptorName() + "." + @this.CSharpDescriptorName();
        }

        public static string CSharpInstanceName(this MetaDeclaration @this)
        {
            return @this.BuiltInName();
        }

        public static string CSharpInstanceName(this MetaProperty @this)
        {
            return @this.Class.CSharpName() + "_" + @this.Name + "Property";
        }

        public static string CSharpFullInstanceName(this MetaModel @this)
        {
            return @this.CSharpFullInstancesName() + ".Meta";
        }

        public static string CSharpFullInstanceName(this MetaDeclaration @this)
        {
            return @this.Model.CSharpFullInstancesName() + "." + @this.CSharpInstanceName();
        }

        public static string CSharpFullInstanceName(this MetaProperty @this)
        {
            return @this.Class.Model.CSharpFullInstancesName() + "." + @this.CSharpInstanceName();
        }

        public static string CSharpImplName(this MetaType @this, bool immutable = false)
        {
            if (@this == null) return string.Empty;
            MetaCollectionType collection = @this as MetaCollectionType;
            if (collection != null)
            {
                if (immutable)
                {
                    switch (collection.Kind)
                    {
                        case MetaCollectionKind.Set:
                            return "global::MetaDslx.Core.Immutable.ImmutableModelSet<" + collection.InnerType.CSharpImplName(immutable) + ">";
                        case MetaCollectionKind.MultiSet:
                            return "global::MetaDslx.Core.Immutable.ImmutableModelMultiSet<" + collection.InnerType.CSharpImplName(immutable) + ">";
                        case MetaCollectionKind.List:
                            return "global::MetaDslx.Core.Immutable.ImmutableModelList<" + collection.InnerType.CSharpImplName(immutable) + ">";
                        case MetaCollectionKind.MultiList:
                            return "global::MetaDslx.Core.Immutable.ImmutableModelMultiList<" + collection.InnerType.CSharpImplName(immutable) + ">";
                        default:
                            return null;
                    }
                }
                else
                {
                    switch (collection.Kind)
                    {
                        case MetaCollectionKind.Set:
                        case MetaCollectionKind.MultiSet:
                            return "global::System.Collections.Generic.ICollection<" + collection.InnerType.CSharpImplName(immutable) + ">";
                        case MetaCollectionKind.List:
                        case MetaCollectionKind.MultiList:
                            return "global::System.Collections.Generic.IList<" + collection.InnerType.CSharpImplName(immutable) + ">";
                        default:
                            return null;
                    }
                }
            }
            MetaNullableType nullable = @this as MetaNullableType;
            if (nullable != null)
            {
                return nullable.InnerType.CSharpImplName(immutable) + "?";
            }
            MetaPrimitiveType primitive = @this as MetaPrimitiveType;
            if (primitive != null)
            {
                return primitive.Name;
            }
            return GetPrefix(immutable) + ((MetaNamedElement)@this).Name + "Impl";
        }

        public static string CSharpFullPublicName(this MetaType @this, bool immutable = false)
        {
            if (@this == null) return string.Empty;
            MetaCollectionType collection = @this as MetaCollectionType;
            if (collection != null)
            {
                if (immutable)
                {
                    return "global::MetaDslx.Core.Immutable.ImmutableModelArray<" + collection.InnerType.CSharpFullPublicName(immutable) + ">";
                }
                else
                {
                    switch (collection.Kind)
                    {
                        case MetaCollectionKind.Set:
                        case MetaCollectionKind.MultiSet:
                            return "global::System.Collections.Generic.ICollection<" + collection.InnerType.CSharpFullPublicName(immutable) + ">";
                        case MetaCollectionKind.List:
                        case MetaCollectionKind.MultiList:
                            return "global::System.Collections.Generic.IList<" + collection.InnerType.CSharpFullPublicName(immutable) + ">";
                        default:
                            return null;
                    }
                }
            }
            MetaNullableType nullable = @this as MetaNullableType;
            if (nullable != null)
            {
                return nullable.InnerType.CSharpFullPublicName(immutable) + "?";
            }
            MetaPrimitiveType primitive = @this as MetaPrimitiveType;
            if (primitive != null)
            {
                return primitive.Name;
            }
            return @this.CSharpFullName(immutable);
        }

        public static ModelObject GetRootNamespace(this ModelObject mobj)
        {
            if (mobj == null) return mobj;
            while (mobj.MParent != null && mobj.MParent is MetaNamespace) mobj = mobj.MParent;
            return mobj;
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
