using System;
using System.Collections.Generic;
using System.IO;
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
                        MetaBuiltInTypes.types.Add(MetaInstance.DefinitionList);
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
                        MetaBuiltInFunctions.functions.Add(MetaInstance.ToDefinitionList);
                        MetaBuiltInFunctions.functions.Add(MetaInstance.Bind1);
                        MetaBuiltInFunctions.functions.Add(MetaInstance.Bind2);
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
        public override IList<string> MetaDocumentedElement_GetDocumentationLines(MetaDocumentedElement @this)
        {
            List<string> result = new List<string>();
            if (@this.Documentation == null) return result;
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(@this.Documentation);
            writer.Flush();
            stream.Position = 0;
            StringBuilder sb = new StringBuilder();
            using (StreamReader reader = new StreamReader(stream))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (line != null)
                    {
                        result.Add(line);
                    }
                }
            }
            return result;
        }

        public override void MetaFunction(MetaFunction @this)
        {
            base.MetaFunction(@this);
            MetaFunctionType type = MetaFactory.Instance.CreateMetaFunctionType();
            ((ModelObject)type).MUnSet(MetaDescriptor.MetaFunctionType.ParameterTypesProperty);
            ((ModelObject)type).MLazySet(MetaDescriptor.MetaFunctionType.ParameterTypesProperty, new Lazy<object>(() => new ModelMultiList<MetaType>((ModelObject)type, MetaDescriptor.MetaFunctionType.ParameterTypesProperty, @this.Parameters.Select(p => new Lazy<object>(() => p.Type))), LazyThreadSafetyMode.PublicationOnly));
            ((ModelObject)type).MLazySet(MetaDescriptor.MetaFunctionType.ReturnTypeProperty, new Lazy<object>(() => @this.ReturnType, LazyThreadSafetyMode.PublicationOnly));
            ((ModelObject)@this).MSet(MetaDescriptor.MetaFunction.TypeProperty, type);
            //((ModelObject)type).MLazySet(MetaDescriptor.MetaFunctionType.ReturnTypeProperty, new Lazy<object>(() => @this.ReturnType, LazyThreadSafetyMode.PublicationOnly));
        }

        public override void MetaUnaryExpression(MetaUnaryExpression @this)
        {
            base.MetaUnaryExpression(@this);
            ((ModelObject)@this).MLazyAdd(MetaDescriptor.MetaBoundExpression.ArgumentsProperty, new Lazy<object>(() => @this.Expression, LazyThreadSafetyMode.PublicationOnly));
        }

        public override void MetaBinaryExpression(MetaBinaryExpression @this)
        {
            base.MetaBinaryExpression(@this);
            ((ModelObject)@this).MLazyAdd(MetaDescriptor.MetaBoundExpression.ArgumentsProperty, new Lazy<object>(() => @this.Left, LazyThreadSafetyMode.PublicationOnly));
            ((ModelObject)@this).MLazyAdd(MetaDescriptor.MetaBoundExpression.ArgumentsProperty, new Lazy<object>(() => @this.Right, LazyThreadSafetyMode.PublicationOnly));
        }

        public override void MetaNewCollectionExpression(MetaNewCollectionExpression @this)
        {
            base.MetaNewCollectionExpression(@this);
            ((ModelObject)@this).MLazySetChild(MetaDescriptor.MetaNewCollectionExpression.ValuesProperty, MetaDescriptor.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => @this.TypeReference.InnerType, LazyThreadSafetyMode.PublicationOnly));
        }

        public override IList<MetaOperation> MetaClass_GetAllOperations(MetaClass @this)
        {
            List<MetaOperation> result = new List<MetaOperation>();
            foreach (var oper in @this.Operations)
            {
                result.Add(oper);
            }
            foreach (var cls in @this.GetAllSuperClasses())
            {
                foreach (var oper in cls.Operations)
                {
                    result.Add(oper);
                }
            }
            return result;
        }

        public override IList<MetaProperty> MetaClass_GetAllProperties(MetaClass @this)
        {
            List<MetaProperty> result = new List<MetaProperty>();
            foreach (var prop in @this.Properties)
            {
                result.Add(prop);
            }
            foreach (var cls in @this.GetAllSuperClasses())
            {
                foreach (var prop in cls.Properties)
                {
                    result.Add(prop);
                }
            }
            return result;
        }

        public override IList<MetaClass> MetaClass_GetAllSuperClasses(MetaClass @this)
        {
            List<MetaClass> result = new List<MetaClass>();
            foreach (var super in @this.SuperClasses)
            {
                ICollection<MetaClass> allSupers = super.GetAllSuperClasses();
                if (!result.Contains(super))
                {
                    result.Add(super);
                }
                foreach (var superSuper in allSupers)
                {
                    if (!result.Contains(superSuper))
                    {
                        result.Add(superSuper);
                    }
                }
            }
            return result;
        }

        public override IList<MetaProperty> MetaClass_GetAllImplementedProperties(MetaClass @this)
        {
            IList<MetaProperty> props = @this.GetAllProperties();
            int i = props.Count - 1;
            while (i >= 0)
            {
                string name = props[i].Name;
                MetaProperty prop = props.First(p => p.Name == name);
                if (prop != props[i])
                {
                    props.RemoveAt(i);
                }
                --i;
            }
            return props;
        }

        public override IList<MetaOperation> MetaClass_GetAllImplementedOperations(MetaClass @this)
        {
            IList<MetaOperation> ops = @this.GetAllOperations();
            int i = ops.Count - 1;
            while (i >= 0)
            {
                string name = ops[i].Name;
                MetaOperation op = ops.First(o => o.Name == name);
                if (op != ops[i])
                {
                    ops.RemoveAt(i);
                }
                --i;
            }
            return ops;
        }
    }

    internal static class MetaModelExtensions
    {
        public static bool HasSameMetaModel(this ModelObject @this, ModelObject mobj)
        {
            if (@this == null || @this.MMetaModel == null) return false;
            if (mobj == null || mobj.MMetaModel == null) return false;
            return @this.MMetaModel == mobj.MMetaModel;
        }

        public static Dictionary<ModelObject, string> GetNamedModelObjects(this MetaModel model)
        {
            return ((ModelObject)model).MModel.GetNamedModelObjects();
        }

        public static Dictionary<ModelObject, string> GetNamedModelObjects(this Model model)
        {
            Dictionary<ModelObject, string> result = new Dictionary<ModelObject, string>();
            int tmpCounter = 0;
            foreach (var item in model.Instances)
            {
                string name = null;
                MetaProperty prop = item as MetaProperty;
                if (prop != null)
                {
                    name = prop.Class.BuiltInName() + "_" + prop.Name + "Property";
                }
                else
                {
                    MetaDeclaration decl = item as MetaDeclaration;
                    if (decl != null && !(decl is MetaConstant))
                    {
                        name = decl.BuiltInName();
                    }
                }
                if (name == null)
                {
                    ++tmpCounter;
                    name = "__tmp" + tmpCounter;
                }
                result.Add(item, name);
            }
            return result;
        }

        public static string CSharpName(this MetaNamespace @this)
        {
            if (@this == null) return string.Empty;
            string result = @this.Name;
            MetaNamespace parent = ((ModelObject)@this).MParent as MetaNamespace;
            while (parent != null)
            {
                result = parent.Name + "." + result;
                parent = ((ModelObject)parent).MParent as MetaNamespace;
            }
            return result;
        }

        public static string CSharpName(this MetaModel @this)
        {
            if (@this == null) return string.Empty;
            return @this.Name;
        }

        public static string CSharpFullName(this MetaModel @this)
        {
            if (@this == null) return string.Empty;
            string nsName = @this.Namespace.CSharpName();
            if (!string.IsNullOrEmpty(nsName)) return "global::" + nsName + "." + @this.Name;
            else return "global::" + @this.Name;
        }

        public static string CSharpName(this MetaType @this)
        {
            if (@this == null) return string.Empty;
            MetaCollectionType collection = @this as MetaCollectionType;
            if (collection != null)
            {
                string innerName = null;
                if (((ModelObject)collection.InnerType).HasSameMetaModel((ModelObject)@this)) innerName = collection.InnerType.CSharpName();
                else innerName = collection.InnerType.CSharpFullName();
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
            MetaNullableType nullable = @this as MetaNullableType;
            if (nullable != null)
            {
                string innerName = null;
                if (((ModelObject)nullable.InnerType).HasSameMetaModel((ModelObject)@this)) innerName = nullable.InnerType.CSharpName();
                else innerName = nullable.InnerType.CSharpFullName();
                return innerName + "?";
            }
            MetaPrimitiveType primitive = @this as MetaPrimitiveType;
            if (primitive != null)
            {
                return primitive.ToCSharpType();
            }
            return ((MetaNamedElement)@this).Name;
        }

        public static string ToCSharpType(this MetaPrimitiveType @this)
        {
            if (@this.Name == "DefinitionList") return "global::MetaDslx.Core.BindingInfo";
            return @this.Name;
        }

        public static string CSharpFullName(this MetaType @this)
        {
            if (@this == null) return string.Empty;
            MetaCollectionType collection = @this as MetaCollectionType;
            if (collection != null)
            {
                string innerName = collection.InnerType.CSharpFullName();
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
            MetaNullableType nullable = @this as MetaNullableType;
            if (nullable != null)
            {
                string innerName = nullable.InnerType.CSharpFullName();
                return innerName + "?";
            }
            MetaPrimitiveType primitive = @this as MetaPrimitiveType;
            if (primitive != null)
            {
                return primitive.ToCSharpType();
            }
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

        public static string CSharpFactoryName(this MetaModel @this)
        {
            return @this.CSharpName() + "Factory";
        }

        public static string CSharpFullFactoryName(this MetaModel @this)
        {
            return @this.CSharpFullName() + "Factory";
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

        public static string CSharpFullFactoryMethodName(this MetaClass @this)
        {
            return @this.Model.CSharpFullFactoryName() + ".Instance.Create" + @this.CSharpName();
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
                        return "global::System.Collections.Generic.ICollection<" + collection.InnerType.CSharpImplName() + ">";
                    case MetaCollectionKind.List:
                    case MetaCollectionKind.MultiList:
                        return "global::System.Collections.Generic.IList<" + collection.InnerType.CSharpImplName() + ">";
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
                return primitive.ToCSharpType();
            }
            return ((MetaNamedElement)@this).Name + "Impl";
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
                        return "global::System.Collections.Generic.ICollection<" + collection.InnerType.CSharpFullPublicName() + ">";
                    case MetaCollectionKind.List:
                    case MetaCollectionKind.MultiList:
                        return "global::System.Collections.Generic.IList<" + collection.InnerType.CSharpFullPublicName() + ">";
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
                return primitive.ToCSharpType();
            }
            return @this.CSharpFullName();
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

        public static bool ContainedBySingleOpposite(this ModelObject mobj, ModelProperty mobjProperty, ModelObject value)
        {
            foreach (var op in mobjProperty.OppositeProperties)
            {
                if (!op.IsCollection)
                {
                    object ov = value.MGet(op);
                    if (ov == mobj) return true;
                }
            }
            return false;
        }

    }

    internal static class MetaModelJavaExtensions
    {
        public static string ToCamelCase(this string name)
        {
            if (string.IsNullOrEmpty(name)) return name;
            else return name[0].ToString().ToLower() + name.Substring(1);
        }

        public static string JavaName(this MetaNamespace @this)
        {
            return @this.CSharpName().ToLower();
        }

        public static string JavaName(this MetaModel @this)
        {
            if (@this == null) return string.Empty;
            return @this.Name;
        }

        public static string JavaFullName(this MetaModel @this)
        {
            if (@this == null) return string.Empty;
            string nsName = @this.Namespace.JavaName();
            if (!string.IsNullOrEmpty(nsName)) return nsName + "." + @this.Name;
            else return @this.Name;
        }

        public static string JavaName(this MetaType @this)
        {
            if (@this == null) return string.Empty;
            MetaCollectionType collection = @this as MetaCollectionType;
            if (collection != null)
            {
                string innerName = null;
                if (((ModelObject)collection.InnerType).HasSameMetaModel((ModelObject)@this)) innerName = collection.InnerType.JavaName();
                else innerName = collection.InnerType.JavaFullName();
                switch (collection.Kind)
                {
                    case MetaCollectionKind.Set:
                        return "metadslx.core.ModelSet<" + innerName + ">";
                    case MetaCollectionKind.List:
                        return "metadslx.core.ModelList<" + innerName + ">";
                    case MetaCollectionKind.MultiSet:
                        return "metadslx.core.ModelMultiSet<" + innerName + ">";
                    case MetaCollectionKind.MultiList:
                        return "metadslx.core.ModelMultiList<" + innerName + ">";
                    default:
                        return null;
                }
            }
            MetaNullableType nullable = @this as MetaNullableType;
            if (nullable != null)
            {
                string innerName = null;
                if (nullable.InnerType is MetaPrimitiveType)
                {
                    innerName = ((MetaPrimitiveType)nullable.InnerType).ToJavaNullableType();
                }
                else
                {
                    if (((ModelObject)nullable.InnerType).HasSameMetaModel((ModelObject)@this)) innerName = nullable.InnerType.JavaName();
                    else innerName = nullable.InnerType.JavaFullName();
                }
                return innerName;
            }
            MetaPrimitiveType primitive = @this as MetaPrimitiveType;
            if (primitive != null)
            {
                return primitive.ToJavaType();
            }
            return ((MetaNamedElement)@this).Name;
        }

        public static string ToJavaType(this MetaPrimitiveType @this)
        {
            if (@this.Name == "bool") return "boolean";
            if (@this.Name == "object") return "Object";
            if (@this.Name == "string") return "String";
            if (@this.Name == "DefinitionList") return "metadslx.core.BindingInfo";
            return @this.Name;
        }

        public static string ToJavaNullableType(this MetaPrimitiveType @this)
        {
            switch (@this.Name)
            {
                case "object": return "Object";
                case "string": return "String";
                case "int": return "Integer";
                case "long": return "Long";
                case "float": return "Float";
                case "double": return "Double";
                case "byte": return "Byte";
                case "bool": return "Boolean";
                case "void": return "Void";
            }
            return null;
        }

        public static string JavaDefaultValue(this MetaPrimitiveType @this)
        {
            switch (@this.Name)
            {
                case "object": return "null";
                case "string": return "null";
                case "int": return "0";
                case "long": return "0";
                case "float": return "0";
                case "double": return "0";
                case "byte": return "0";
                case "bool": return "false";
                case "void": return "";
            }
            return "null";
        }

        public static string JavaDefaultValue(this MetaType @this)
        {
            if (@this == null) return string.Empty;
            MetaCollectionType collection = @this as MetaCollectionType;
            if (collection != null)
            {
                return "null";
            }
            MetaNullableType nullable = @this as MetaNullableType;
            if (nullable != null)
            {
                return "null";
            }
            MetaPrimitiveType primitive = @this as MetaPrimitiveType;
            if (primitive != null)
            {
                return primitive.JavaDefaultValue();
            }
            return "null";
        }

        public static string JavaNonGenericFullName(this MetaType @this)
        {
            if (@this == null) return string.Empty;
            MetaCollectionType collection = @this as MetaCollectionType;
            if (collection != null)
            {
                switch (collection.Kind)
                {
                    case MetaCollectionKind.Set:
                        return "metadslx.core.ModelSet";
                    case MetaCollectionKind.List:
                        return "metadslx.core.ModelList";
                    case MetaCollectionKind.MultiSet:
                        return "metadslx.core.ModelMultiSet";
                    case MetaCollectionKind.MultiList:
                        return "metadslx.core.ModelMultiList";
                    default:
                        return null;
                }
            }
            MetaNullableType nullable = @this as MetaNullableType;
            if (nullable != null)
            {
                string innerName = null;
                if (nullable.InnerType is MetaPrimitiveType)
                {
                    innerName = ((MetaPrimitiveType)nullable.InnerType).ToJavaNullableType();
                }
                else
                {
                    innerName = nullable.InnerType.JavaNonGenericFullName();
                }
                return innerName;
            }
            MetaPrimitiveType primitive = @this as MetaPrimitiveType;
            if (primitive != null)
            {
                return primitive.ToJavaType();
            }
            MetaDeclaration decl = @this as MetaDeclaration;
            string nsName = string.Empty;
            if (decl != null)
            {
                nsName = decl.Namespace.JavaName();
                if (!string.IsNullOrEmpty(nsName)) return nsName + "." + @this.JavaName();
                else return @this.JavaName();
            }
            else
            {
                return @this.JavaName();
            }
        }

        public static string JavaFullName(this MetaType @this)
        {
            if (@this == null) return string.Empty;
            MetaCollectionType collection = @this as MetaCollectionType;
            if (collection != null)
            {
                string innerName = collection.InnerType.JavaFullName();
                switch (collection.Kind)
                {
                    case MetaCollectionKind.Set:
                        return "metadslx.core.ModelSet<" + innerName + ">";
                    case MetaCollectionKind.List:
                        return "metadslx.core.ModelList<" + innerName + ">";
                    case MetaCollectionKind.MultiSet:
                        return "metadslx.core.ModelMultiSet<" + innerName + ">";
                    case MetaCollectionKind.MultiList:
                        return "metadslx.core.ModelMultiList<" + innerName + ">";
                    default:
                        return null;
                }
            }
            MetaNullableType nullable = @this as MetaNullableType;
            if (nullable != null)
            {
                string innerName = null;
                if (nullable.InnerType is MetaPrimitiveType)
                {
                    innerName = ((MetaPrimitiveType)nullable.InnerType).ToJavaNullableType();
                }
                else
                {
                    innerName = nullable.InnerType.JavaFullName();
                }
                return innerName;
            }
            MetaPrimitiveType primitive = @this as MetaPrimitiveType;
            if (primitive != null)
            {
                return primitive.ToJavaType();
            }
            MetaDeclaration decl = @this as MetaDeclaration;
            string nsName = string.Empty;
            if (decl != null)
            {
                nsName = decl.Namespace.JavaName();
                if (!string.IsNullOrEmpty(nsName)) return nsName + "." + @this.JavaName();
                else return @this.JavaName();
            }
            else
            {
                return @this.JavaName();
            }
        }

        public static string JavaImplName(this MetaType @this)
        {
            if (@this == null) return string.Empty;
            MetaCollectionType collection = @this as MetaCollectionType;
            if (collection != null)
            {
                switch (collection.Kind)
                {
                    case MetaCollectionKind.Set:
                    case MetaCollectionKind.MultiSet:
                        return "java.util.Collection<" + collection.InnerType.JavaImplName() + ">";
                    case MetaCollectionKind.List:
                    case MetaCollectionKind.MultiList:
                        return "java.util.List<" + collection.InnerType.JavaImplName() + ">";
                    default:
                        return null;
                }
            }
            MetaNullableType nullable = @this as MetaNullableType;
            if (nullable != null)
            {
                string innerName = null;
                if (nullable.InnerType is MetaPrimitiveType)
                {
                    innerName = ((MetaPrimitiveType)nullable.InnerType).ToJavaNullableType();
                }
                else
                {
                    innerName = nullable.InnerType.JavaImplName();
                }
                return innerName;
            }
            MetaPrimitiveType primitive = @this as MetaPrimitiveType;
            if (primitive != null)
            {
                return primitive.ToJavaType();
            }
            return ((MetaNamedElement)@this).Name + "Impl";
        }

        public static string JavaFullPublicName(this MetaType @this)
        {
            if (@this == null) return string.Empty;
            MetaCollectionType collection = @this as MetaCollectionType;
            if (collection != null)
            {
                switch (collection.Kind)
                {
                    case MetaCollectionKind.Set:
                    case MetaCollectionKind.MultiSet:
                        return "java.util.Collection<" + collection.InnerType.JavaFullPublicName() + ">";
                    case MetaCollectionKind.List:
                    case MetaCollectionKind.MultiList:
                        return "java.util.List<" + collection.InnerType.JavaFullPublicName() + ">";
                    default:
                        return null;
                }
            }
            MetaNullableType nullable = @this as MetaNullableType;
            if (nullable != null)
            {
                string innerName = null;
                if (nullable.InnerType is MetaPrimitiveType)
                {
                    innerName = ((MetaPrimitiveType)nullable.InnerType).ToJavaNullableType();
                }
                else
                {
                    innerName = nullable.InnerType.JavaFullPublicName();
                }
                return innerName;
            }
            MetaPrimitiveType primitive = @this as MetaPrimitiveType;
            if (primitive != null)
            {
                return primitive.ToJavaType();
            }
            return @this.JavaFullName();
        }

        public static string JavaDescriptorName(this MetaModel @this)
        {
            return @this.JavaName() + "Descriptor";
        }

        public static string JavaFullDescriptorName(this MetaModel @this)
        {
            return @this.JavaFullName() + "Descriptor";
        }

        public static string JavaInstancesName(this MetaModel @this)
        {
            return @this.JavaName() + "Instance";
        }

        public static string JavaFullInstancesName(this MetaModel @this)
        {
            return @this.JavaFullName() + "Instance";
        }

        public static string JavaFactoryName(this MetaModel @this)
        {
            return @this.JavaName() + "Factory";
        }

        public static string JavaFullFactoryName(this MetaModel @this)
        {
            return @this.JavaFullName() + "Factory";
        }

        public static string JavaFullImplementationName(this MetaModel @this)
        {
            return @this.JavaFullName() + "ImplementationProvider.implementation()";
        }

        public static string GetJavaValue(this MetaExpression @this)
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

        public static string JavaFullFactoryMethodName(this MetaClass @this)
        {
            return @this.Model.JavaFullFactoryName() + ".instance().create" + @this.JavaName();
        }

        public static string JavaDescriptorName(this MetaDeclaration @this)
        {
            return @this.BuiltInName();
        }

        public static string JavaDescriptorName(this MetaProperty @this)
        {
            return @this.Name + "Property";
        }

        public static string JavaFullDescriptorName(this MetaDeclaration @this)
        {
            return @this.Model.JavaFullDescriptorName() + "." + @this.JavaDescriptorName();
        }

        public static string JavaFullDescriptorName(this MetaProperty @this)
        {
            return @this.Class.JavaFullDescriptorName() + "." + @this.JavaDescriptorName();
        }

        public static string JavaInstanceName(this MetaDeclaration @this)
        {
            return @this.BuiltInName();
        }

        public static string JavaInstanceName(this MetaProperty @this)
        {
            return @this.Class.JavaName() + "_" + @this.Name + "Property";
        }

        public static string JavaFullInstanceName(this MetaModel @this)
        {
            return @this.JavaFullInstancesName() + ".Meta";
        }

        public static string JavaFullInstanceName(this MetaDeclaration @this)
        {
            return @this.Model.JavaFullInstancesName() + "." + @this.JavaInstanceName();
        }

        public static string JavaFullInstanceName(this MetaProperty @this)
        {
            return @this.Class.Model.JavaFullInstancesName() + "." + @this.JavaInstanceName();
        }

        public static string JavaFullDeclaredName(this ModelProperty property)
        {
            string nsName = property.DeclaringType.Namespace;
            string localName = property.DeclaringType.FullName.Substring(nsName.Length + 1).Replace("+", ".");
            return nsName.ToLower() + "." + localName + "." + property.DeclaredName;
        }

        public static string JavaEnumValueOf(this object enm)
        {
            string nsName = enm.GetType().Namespace;
            string localName = enm.GetType().FullName.Substring(nsName.Length + 1).Replace("+", ".");
            return nsName.ToLower() + "." + localName + "." + enm.ToString();
        }

        public static string SafeJavaName(this string name)
        {
            if (name == "getClass") return "getClass_";
            return name;
        }
    }
}