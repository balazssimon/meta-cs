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

    public enum ClassKind
    {
        Normal,
        Id,
        Immutable,
        Builder
    }

    internal static class MetaModelExtensions
    {
        private const string ImmutablePrefix = "";
        private const string BuilderSuffix = "Builder";
        private const string IdSuffix = "Id";

        private static string GetPrefix(ClassKind classKind)
        {
            if (classKind == ClassKind.Immutable) return ImmutablePrefix;
            else return string.Empty;
        }

        private static string GetSuffix(ClassKind classKind)
        {
            if (classKind == ClassKind.Builder) return BuilderSuffix;
            else if (classKind == ClassKind.Id) return IdSuffix;
            else return string.Empty;
        }

        public static bool HasSameMetaModel(this ModelObject @this, ModelObject mobj)
        {
            if (@this == null || @this.MMetaModel == null) return false;
            if (mobj == null || mobj.MMetaModel == null) return false;
            return @this.MMetaModel == mobj.MMetaModel;
        }

        public static string CSharpName(this MetaNamespace @this, ClassKind classKind = ClassKind.Normal)
        {
            if (@this == null) return string.Empty;
            string result = @this.Name;
            if (classKind != ClassKind.Normal) result += ".Immutable";
            MetaNamespace parent = ((ModelObject)@this).MParent as MetaNamespace;
            while (parent != null)
            {
                result = parent.Name + "." + result;
                parent = ((ModelObject)parent).MParent as MetaNamespace;
            }
            return result;
        }

        public static string CSharpName(this MetaModel @this, ClassKind classKind = ClassKind.Normal)
        {
            if (@this == null) return string.Empty;
            return @this.Name;
        }

        public static string CSharpFullName(this MetaModel @this, ClassKind classKind = ClassKind.Normal)
        {
            if (@this == null) return string.Empty;
            string nsName = @this.Namespace.CSharpName(classKind);
            if (!string.IsNullOrEmpty(nsName)) return "global::" + nsName + "." + @this.CSharpName(classKind);
            else return "global::" + @this.CSharpName(classKind);
        }

        public static bool IsReferenceType(this MetaType @this)
        {
            if (@this == null) return false;
            if (@this is MetaCollectionType) return true;
            if (@this is MetaNullableType) return true;
            MetaPrimitiveType primitive = @this as MetaPrimitiveType;
            if (primitive != null)
            {
                return primitive.Name == "string" || primitive.Name == "object" || primitive.Name == "ModelObject";
            }
            if (@this is MetaClass) return true;
            return false;
        }

        public static string CSharpName(this MetaType @this, ClassKind classKind = ClassKind.Normal)
        {
            if (@this == null) return string.Empty;
            MetaCollectionType collection = @this as MetaCollectionType;
            if (collection != null)
            {
                string innerName = null;
                if (((ModelObject)collection.InnerType).HasSameMetaModel((ModelObject)@this)) innerName = collection.InnerType.CSharpName(classKind);
                else innerName = collection.InnerType.CSharpFullName(classKind);
                if (classKind == ClassKind.Immutable)
                {
                    return "global::MetaDslx.Core.Immutable.ImmutableModelList<" + innerName + ">";
                }
                else if (classKind == ClassKind.Builder)
                {
                    return "global::MetaDslx.Core.Immutable.ModelList<" + innerName + ">";
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
                if (((ModelObject)nullable.InnerType).HasSameMetaModel((ModelObject)@this)) innerName = nullable.InnerType.CSharpName(classKind);
                else innerName = nullable.InnerType.CSharpFullName(classKind);
                return innerName + "?";
            }
            MetaEnum enm = @this as MetaEnum;
            if (enm != null)
            {
                return enm.Name;
            }
            MetaPrimitiveType primitive = @this as MetaPrimitiveType;
            if (primitive != null)
            {
                return primitive.Name;
            }
            return GetPrefix(classKind) + ((MetaNamedElement)@this).Name + GetSuffix(classKind);
        }

        public static string CSharpFullName(this MetaType @this, ClassKind classKind = ClassKind.Normal)
        {
            if (@this == null) return string.Empty;
            MetaCollectionType collection = @this as MetaCollectionType;
            if (collection != null)
            {
                string innerName = collection.InnerType.CSharpFullName(classKind);
                if (classKind == ClassKind.Immutable)
                {
                    return "global::MetaDslx.Core.Immutable.ImmutableModelList<" + innerName + ">";
                }
                else if (classKind == ClassKind.Builder)
                {
                    return "global::MetaDslx.Core.Immutable.ModelList<" + innerName + ">";
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
                string innerName = nullable.InnerType.CSharpFullName(classKind);
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
                nsName = decl.Namespace.CSharpName(classKind);
                if (!string.IsNullOrEmpty(nsName)) return "global::" + nsName + "." + @this.CSharpName(classKind);
                else return @this.CSharpName(classKind);
            }
            else
            {
                return @this.CSharpName(classKind);
            }
        }

        public static string CSharpDescriptorName(this MetaModel @this, ClassKind classKind = ClassKind.Normal)
        {
            return @this.CSharpName(classKind) + "Descriptor";
        }

        public static string CSharpFullDescriptorName(this MetaModel @this, ClassKind classKind = ClassKind.Normal)
        {
            return @this.CSharpFullName(classKind) + "Descriptor";
        }

        public static string CSharpInstancesName(this MetaModel @this, ClassKind classKind = ClassKind.Normal)
        {
            return @this.CSharpName(classKind) + "Instance";
        }

        public static string CSharpFullInstancesName(this MetaModel @this, ClassKind classKind = ClassKind.Normal)
        {
            return @this.CSharpFullName(classKind) + "Instance";
        }

        public static string CSharpFactoryName(this MetaModel @this, ClassKind classKind = ClassKind.Normal)
        {
            return @this.CSharpName(classKind) + "Factory";
        }

        public static string CSharpFullFactoryName(this MetaModel @this, ClassKind classKind = ClassKind.Normal)
        {
            return @this.CSharpFullName(classKind) + "Factory";
        }

        public static string CSharpFullImplementationName(this MetaModel @this, ClassKind classKind = ClassKind.Normal)
        {
            return @this.CSharpFullName(classKind) + "ImplementationProvider.Implementation";
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

        public static string CSharpFullFactoryMethodName(this MetaClass @this, ClassKind classKind = ClassKind.Normal)
        {
            return @this.Model.CSharpFullFactoryName(classKind) + ".Instance.Create" + @this.CSharpName();
        }

        public static string CSharpDescriptorName(this MetaDeclaration @this, ClassKind classKind = ClassKind.Normal)
        {
            return @this.BuiltInName();
        }

        public static string CSharpDescriptorName(this MetaProperty @this, ClassKind classKind = ClassKind.Normal)
        {
            return @this.Name + "Property";
        }

        public static string CSharpFullDescriptorName(this MetaDeclaration @this, ClassKind classKind = ClassKind.Normal)
        {
            return @this.Model.CSharpFullDescriptorName(classKind) + "." + @this.CSharpDescriptorName();
        }

        public static string CSharpFullDescriptorName(this MetaProperty @this, ClassKind classKind = ClassKind.Normal)
        {
            return @this.Class.CSharpFullDescriptorName(classKind) + "." + @this.CSharpDescriptorName();
        }

        public static string CSharpInstanceName(this MetaDeclaration @this, ClassKind classKind = ClassKind.Normal)
        {
            return @this.BuiltInName();
        }

        public static string CSharpInstanceName(this MetaProperty @this, ClassKind classKind = ClassKind.Normal)
        {
            return @this.Class.CSharpName(classKind) + "_" + @this.Name + "Property";
        }

        public static string CSharpFullInstanceName(this MetaModel @this, ClassKind classKind = ClassKind.Normal)
        {
            return @this.CSharpFullInstancesName(classKind) + ".Meta";
        }

        public static string CSharpFullInstanceName(this MetaDeclaration @this, ClassKind classKind = ClassKind.Normal)
        {
            return @this.Model.CSharpFullInstancesName(classKind) + "." + @this.CSharpInstanceName(classKind);
        }

        public static string CSharpFullInstanceName(this MetaProperty @this, ClassKind classKind = ClassKind.Normal)
        {
            return @this.Class.Model.CSharpFullInstancesName(classKind) + "." + @this.CSharpInstanceName(classKind);
        }

        public static string CSharpImplName(this MetaType @this, ClassKind classKind = ClassKind.Normal)
        {
            if (@this == null) return string.Empty;
            MetaCollectionType collection = @this as MetaCollectionType;
            if (collection != null)
            {
                string innerName = collection.InnerType.CSharpImplName(classKind);
                if (classKind == ClassKind.Immutable)
                {
                    return "global::MetaDslx.Core.Immutable.ImmutableModelList<" + innerName + ">";
                }
                else if (classKind == ClassKind.Builder)
                {
                    return "global::MetaDslx.Core.Immutable.ModelList<" + innerName + ">";
                }
                else
                {
                    switch (collection.Kind)
                    {
                        case MetaCollectionKind.Set:
                        case MetaCollectionKind.MultiSet:
                            return "global::System.Collections.Generic.ICollection<" + innerName + ">";
                        case MetaCollectionKind.List:
                        case MetaCollectionKind.MultiList:
                            return "global::System.Collections.Generic.IList<" + innerName + ">";
                        default:
                            return null;
                    }
                }
            }
            MetaNullableType nullable = @this as MetaNullableType;
            if (nullable != null)
            {
                return nullable.InnerType.CSharpImplName(classKind) + "?";
            }
            MetaPrimitiveType primitive = @this as MetaPrimitiveType;
            if (primitive != null)
            {
                return primitive.Name;
            }
            return GetPrefix(classKind) + ((MetaNamedElement)@this).Name + GetSuffix(classKind) + "Impl";
        }

        public static string CSharpFullPublicName(this MetaType @this, ClassKind classKind = ClassKind.Normal)
        {
            if (@this == null) return string.Empty;
            MetaCollectionType collection = @this as MetaCollectionType;
            if (collection != null)
            {
                string innerName = collection.InnerType.CSharpFullPublicName(classKind);
                if (classKind == ClassKind.Immutable)
                {
                    return "global::MetaDslx.Core.Immutable.ImmutableModelList<" + innerName + ">";
                }
                else if (classKind == ClassKind.Builder)
                {
                    return "global::MetaDslx.Core.Immutable.ModelList<" + innerName + ">";
                }
                else
                {
                    switch (collection.Kind)
                    {
                        case MetaCollectionKind.Set:
                        case MetaCollectionKind.MultiSet:
                            return "global::System.Collections.Generic.ICollection<" + innerName + ">";
                        case MetaCollectionKind.List:
                        case MetaCollectionKind.MultiList:
                            return "global::System.Collections.Generic.IList<" + innerName + ">";
                        default:
                            return null;
                    }
                }
            }
            MetaNullableType nullable = @this as MetaNullableType;
            if (nullable != null)
            {
                return nullable.InnerType.CSharpFullPublicName(classKind) + "?";
            }
            MetaPrimitiveType primitive = @this as MetaPrimitiveType;
            if (primitive != null)
            {
                return primitive.Name;
            }
            return @this.CSharpFullName(classKind);
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

        public static List<MetaProperty> GetAllFinalProperties(this MetaClass @this)
        {
            List<MetaProperty> result = new List<MetaProperty>();
            foreach (var super in @this.GetAllSuperClasses(true))
            {
                foreach (var prop in super.Properties)
                {
                    result.RemoveAll(p => p.Name == prop.Name);
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
