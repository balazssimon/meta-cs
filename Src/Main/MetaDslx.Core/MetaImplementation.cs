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

        public static readonly MetaFunction TypeOf;
        public static readonly MetaFunction GetValueType;
        public static readonly MetaFunction GetReturnType;
        public static readonly MetaFunction CurrentType;
        public static readonly MetaFunction TypeCheck;
        public static readonly MetaFunction Balance;
        public static readonly MetaFunction Resolve1;
        public static readonly MetaFunction ResolveName1;
        public static readonly MetaFunction ResolveType1;
        public static readonly MetaFunction Resolve2;
        public static readonly MetaFunction ResolveName2;
        public static readonly MetaFunction ResolveType2;
        public static readonly MetaFunction Bind1;
        public static readonly MetaFunction Bind2;
        public static readonly MetaFunction Bind3;
        public static readonly MetaFunction Bind4;
        public static readonly MetaFunction SelectOfType1;
        public static readonly MetaFunction SelectOfType2;
        public static readonly MetaFunction SelectOfName1;
        public static readonly MetaFunction SelectOfName2;

        static MetaBuiltInFunctions()
        {
            MetaBuiltInFunctions.TypeOf = MetaModelFactory.Instance.CreateMetaFunction();
            MetaBuiltInFunctions.TypeOf.Name = "typeof";
            MetaBuiltInFunctions.TypeOf.ReturnType = Meta.MetaType.Instance;
            var typeOfParam = MetaModelFactory.Instance.CreateMetaParameter();
            typeOfParam.Type = Meta.Constants.Any;
            MetaBuiltInFunctions.TypeOf.Parameters.Add(typeOfParam);
            MetaBuiltInFunctions.functions.Add(MetaBuiltInFunctions.TypeOf);

            MetaBuiltInFunctions.GetValueType = MetaModelFactory.Instance.CreateMetaFunction();
            MetaBuiltInFunctions.GetValueType.Name = "get_type";
            MetaBuiltInFunctions.GetValueType.ReturnType = Meta.MetaType.Instance;
            var getValueTypeParam = MetaModelFactory.Instance.CreateMetaParameter();
            getValueTypeParam.Type = Meta.Constants.Any;
            MetaBuiltInFunctions.GetValueType.Parameters.Add(getValueTypeParam);
            MetaBuiltInFunctions.functions.Add(MetaBuiltInFunctions.GetValueType);

            MetaBuiltInFunctions.GetReturnType = MetaModelFactory.Instance.CreateMetaFunction();
            MetaBuiltInFunctions.GetReturnType.Name = "get_return_type";
            MetaBuiltInFunctions.GetReturnType.ReturnType = Meta.MetaType.Instance;
            var getReturnTypeParam = MetaModelFactory.Instance.CreateMetaParameter();
            getReturnTypeParam.Type = Meta.Constants.Any;
            MetaBuiltInFunctions.GetReturnType.Parameters.Add(getReturnTypeParam);
            MetaBuiltInFunctions.functions.Add(MetaBuiltInFunctions.GetReturnType);

            MetaBuiltInFunctions.CurrentType = MetaModelFactory.Instance.CreateMetaFunction();
            MetaBuiltInFunctions.CurrentType.Name = "current_type";
            MetaBuiltInFunctions.CurrentType.ReturnType = Meta.MetaType.Instance;
            var currentTypeParam = MetaModelFactory.Instance.CreateMetaParameter();
            currentTypeParam.Type = Meta.Constants.ModelObject;
            MetaBuiltInFunctions.CurrentType.Parameters.Add(currentTypeParam);
            MetaBuiltInFunctions.functions.Add(MetaBuiltInFunctions.CurrentType);

            MetaBuiltInFunctions.TypeCheck = MetaModelFactory.Instance.CreateMetaFunction();
            MetaBuiltInFunctions.TypeCheck.Name = "type_check";
            MetaBuiltInFunctions.TypeCheck.ReturnType = Meta.Constants.Bool;
            var typeCheckParam = MetaModelFactory.Instance.CreateMetaParameter();
            typeCheckParam.Type = Meta.Constants.ModelObject;
            MetaBuiltInFunctions.TypeCheck.Parameters.Add(typeCheckParam);
            MetaBuiltInFunctions.functions.Add(MetaBuiltInFunctions.TypeCheck);

            MetaBuiltInFunctions.Balance = MetaModelFactory.Instance.CreateMetaFunction();
            MetaBuiltInFunctions.Balance.Name = "balance";
            MetaBuiltInFunctions.Balance.ReturnType = Meta.MetaType.Instance;
            var balanceLeftParam = MetaModelFactory.Instance.CreateMetaParameter();
            balanceLeftParam.Type = Meta.MetaType.Instance;
            MetaBuiltInFunctions.Balance.Parameters.Add(balanceLeftParam);
            var balanceRightParam = MetaModelFactory.Instance.CreateMetaParameter();
            balanceRightParam.Type = Meta.MetaType.Instance;
            MetaBuiltInFunctions.Balance.Parameters.Add(balanceRightParam);
            MetaBuiltInFunctions.functions.Add(MetaBuiltInFunctions.Balance);

            MetaBuiltInFunctions.Resolve1 = MetaModelFactory.Instance.CreateMetaFunction();
            MetaBuiltInFunctions.Resolve1.Name = "resolve";
            MetaBuiltInFunctions.Resolve1.ReturnType = Meta.Constants.ModelObjectList;
            var resolve1Param = MetaModelFactory.Instance.CreateMetaParameter();
            resolve1Param.Type = Meta.Constants.String;
            MetaBuiltInFunctions.Resolve1.Parameters.Add(resolve1Param);
            MetaBuiltInFunctions.functions.Add(MetaBuiltInFunctions.Resolve1);

            MetaBuiltInFunctions.ResolveName1 = MetaModelFactory.Instance.CreateMetaFunction();
            MetaBuiltInFunctions.ResolveName1.Name = "resolve_name";
            MetaBuiltInFunctions.ResolveName1.ReturnType = Meta.Constants.ModelObjectList;
            var resolveName1Param = MetaModelFactory.Instance.CreateMetaParameter();
            resolveName1Param.Type = Meta.Constants.String;
            MetaBuiltInFunctions.ResolveName1.Parameters.Add(resolveName1Param);
            MetaBuiltInFunctions.functions.Add(MetaBuiltInFunctions.ResolveName1);

            MetaBuiltInFunctions.ResolveType1 = MetaModelFactory.Instance.CreateMetaFunction();
            MetaBuiltInFunctions.ResolveType1.Name = "resolve_type";
            MetaBuiltInFunctions.ResolveType1.ReturnType = Meta.Constants.ModelObjectList;
            var resolveType1Param = MetaModelFactory.Instance.CreateMetaParameter();
            resolveType1Param.Type = Meta.Constants.String;
            MetaBuiltInFunctions.ResolveType1.Parameters.Add(resolveType1Param);
            MetaBuiltInFunctions.functions.Add(MetaBuiltInFunctions.ResolveType1);

            MetaBuiltInFunctions.Resolve2 = MetaModelFactory.Instance.CreateMetaFunction();
            MetaBuiltInFunctions.Resolve2.Name = "resolve";
            MetaBuiltInFunctions.Resolve2.ReturnType = Meta.Constants.ModelObjectList;
            var resolve2ContextParam = MetaModelFactory.Instance.CreateMetaParameter();
            resolve2ContextParam.Type = Meta.Constants.ModelObject;
            MetaBuiltInFunctions.Resolve2.Parameters.Add(resolve2ContextParam);
            var resolve2Param = MetaModelFactory.Instance.CreateMetaParameter();
            resolve2Param.Type = Meta.Constants.String;
            MetaBuiltInFunctions.Resolve2.Parameters.Add(resolve2Param);
            MetaBuiltInFunctions.functions.Add(MetaBuiltInFunctions.Resolve2);

            MetaBuiltInFunctions.ResolveName2 = MetaModelFactory.Instance.CreateMetaFunction();
            MetaBuiltInFunctions.ResolveName2.Name = "resolve_name";
            MetaBuiltInFunctions.ResolveName2.ReturnType = Meta.Constants.ModelObjectList;
            var resolveName2ContextParam = MetaModelFactory.Instance.CreateMetaParameter();
            resolveName2ContextParam.Type = Meta.Constants.ModelObject;
            MetaBuiltInFunctions.ResolveName2.Parameters.Add(resolveName2ContextParam);
            var resolveName2Param = MetaModelFactory.Instance.CreateMetaParameter();
            resolveName2Param.Type = Meta.Constants.String;
            MetaBuiltInFunctions.ResolveName2.Parameters.Add(resolveName2Param);
            MetaBuiltInFunctions.functions.Add(MetaBuiltInFunctions.ResolveName2);

            MetaBuiltInFunctions.ResolveType2 = MetaModelFactory.Instance.CreateMetaFunction();
            MetaBuiltInFunctions.ResolveType2.Name = "resolve_type";
            MetaBuiltInFunctions.ResolveType2.ReturnType = Meta.Constants.ModelObjectList;
            var resolveType2ContextParam = MetaModelFactory.Instance.CreateMetaParameter();
            resolveType2ContextParam.Type = Meta.Constants.ModelObject;
            MetaBuiltInFunctions.ResolveType2.Parameters.Add(resolveType2ContextParam);
            var resolveType2Param = MetaModelFactory.Instance.CreateMetaParameter();
            resolveType2Param.Type = Meta.Constants.String;
            MetaBuiltInFunctions.ResolveType2.Parameters.Add(resolveType2Param);
            MetaBuiltInFunctions.functions.Add(MetaBuiltInFunctions.ResolveType2);

            MetaBuiltInFunctions.Bind1 = MetaModelFactory.Instance.CreateMetaFunction();
            MetaBuiltInFunctions.Bind1.Name = "bind";
            MetaBuiltInFunctions.Bind1.ReturnType = Meta.Constants.ModelObject;
            var bind1Param = MetaModelFactory.Instance.CreateMetaParameter();
            bind1Param.Type = Meta.Constants.ModelObjectList;
            MetaBuiltInFunctions.Bind1.Parameters.Add(bind1Param);
            MetaBuiltInFunctions.functions.Add(MetaBuiltInFunctions.Bind1);

            MetaBuiltInFunctions.Bind2 = MetaModelFactory.Instance.CreateMetaFunction();
            MetaBuiltInFunctions.Bind2.Name = "bind";
            MetaBuiltInFunctions.Bind2.ReturnType = Meta.Constants.ModelObject;
            var bind2Param = MetaModelFactory.Instance.CreateMetaParameter();
            bind2Param.Type = Meta.Constants.ModelObject;
            MetaBuiltInFunctions.Bind2.Parameters.Add(bind2Param);
            MetaBuiltInFunctions.functions.Add(MetaBuiltInFunctions.Bind2);
            
            MetaBuiltInFunctions.Bind3 = MetaModelFactory.Instance.CreateMetaFunction();
            MetaBuiltInFunctions.Bind3.Name = "bind";
            MetaBuiltInFunctions.Bind3.ReturnType = Meta.Constants.ModelObject;
            var bind3ContextParam = MetaModelFactory.Instance.CreateMetaParameter();
            bind3ContextParam.Type = Meta.Constants.ModelObject;
            MetaBuiltInFunctions.Bind3.Parameters.Add(bind3ContextParam);
            var bind3Param = MetaModelFactory.Instance.CreateMetaParameter();
            bind3Param.Type = Meta.Constants.ModelObjectList;
            MetaBuiltInFunctions.Bind3.Parameters.Add(bind3Param);
            MetaBuiltInFunctions.functions.Add(MetaBuiltInFunctions.Bind3);

            MetaBuiltInFunctions.Bind4 = MetaModelFactory.Instance.CreateMetaFunction();
            MetaBuiltInFunctions.Bind4.Name = "bind";
            MetaBuiltInFunctions.Bind4.ReturnType = Meta.Constants.ModelObject;
            var bind4ContextParam = MetaModelFactory.Instance.CreateMetaParameter();
            bind4ContextParam.Type = Meta.Constants.ModelObject;
            MetaBuiltInFunctions.Bind4.Parameters.Add(bind4ContextParam);
            var bind4Param = MetaModelFactory.Instance.CreateMetaParameter();
            bind4Param.Type = Meta.Constants.ModelObject;
            MetaBuiltInFunctions.Bind4.Parameters.Add(bind4Param);
            MetaBuiltInFunctions.functions.Add(MetaBuiltInFunctions.Bind4);
            
            MetaBuiltInFunctions.SelectOfType1 = MetaModelFactory.Instance.CreateMetaFunction();
            MetaBuiltInFunctions.SelectOfType1.Name = "select_of_type";
            MetaBuiltInFunctions.SelectOfType1.ReturnType = Meta.Constants.ModelObjectList;
            var selectOfType1SymbolsParam = MetaModelFactory.Instance.CreateMetaParameter();
            selectOfType1SymbolsParam.Type = Meta.Constants.ModelObjectList;
            MetaBuiltInFunctions.SelectOfType1.Parameters.Add(selectOfType1SymbolsParam);
            var selectOfType1TypeParam = MetaModelFactory.Instance.CreateMetaParameter();
            selectOfType1TypeParam.Type = Meta.MetaType.Instance;
            MetaBuiltInFunctions.SelectOfType1.Parameters.Add(selectOfType1TypeParam);
            MetaBuiltInFunctions.functions.Add(MetaBuiltInFunctions.SelectOfType1);

            MetaBuiltInFunctions.SelectOfType2 = MetaModelFactory.Instance.CreateMetaFunction();
            MetaBuiltInFunctions.SelectOfType2.Name = "select_of_type";
            MetaBuiltInFunctions.SelectOfType2.ReturnType = Meta.Constants.ModelObjectList;
            var selectOfType2SymbolsParam = MetaModelFactory.Instance.CreateMetaParameter();
            selectOfType2SymbolsParam.Type = Meta.Constants.ModelObject;
            MetaBuiltInFunctions.SelectOfType2.Parameters.Add(selectOfType2SymbolsParam);
            var selectOfType2TypeParam = MetaModelFactory.Instance.CreateMetaParameter();
            selectOfType2TypeParam.Type = Meta.MetaType.Instance;
            MetaBuiltInFunctions.SelectOfType2.Parameters.Add(selectOfType2TypeParam);
            MetaBuiltInFunctions.functions.Add(MetaBuiltInFunctions.SelectOfType2);

            MetaBuiltInFunctions.SelectOfName1 = MetaModelFactory.Instance.CreateMetaFunction();
            MetaBuiltInFunctions.SelectOfName1.Name = "select_of_name";
            MetaBuiltInFunctions.SelectOfName1.ReturnType = Meta.Constants.ModelObjectList;
            var selectOfName1SymbolsParam = MetaModelFactory.Instance.CreateMetaParameter();
            selectOfName1SymbolsParam.Type = Meta.Constants.ModelObjectList;
            MetaBuiltInFunctions.SelectOfName1.Parameters.Add(selectOfName1SymbolsParam);
            var selectOfName1NameParam = MetaModelFactory.Instance.CreateMetaParameter();
            selectOfName1NameParam.Type = Meta.Constants.String;
            MetaBuiltInFunctions.SelectOfName1.Parameters.Add(selectOfName1NameParam);
            MetaBuiltInFunctions.functions.Add(MetaBuiltInFunctions.SelectOfName1);

            MetaBuiltInFunctions.SelectOfName2 = MetaModelFactory.Instance.CreateMetaFunction();
            MetaBuiltInFunctions.SelectOfName2.Name = "select_of_name";
            MetaBuiltInFunctions.SelectOfName2.ReturnType = Meta.Constants.ModelObjectList;
            var selectOfName2SymbolsParam = MetaModelFactory.Instance.CreateMetaParameter();
            selectOfName2SymbolsParam.Type = Meta.Constants.ModelObject;
            MetaBuiltInFunctions.SelectOfName2.Parameters.Add(selectOfName2SymbolsParam);
            var selectOfName2NameParam = MetaModelFactory.Instance.CreateMetaParameter();
            selectOfName2NameParam.Type = Meta.Constants.String;
            MetaBuiltInFunctions.SelectOfName2.Parameters.Add(selectOfName2NameParam);
            MetaBuiltInFunctions.functions.Add(MetaBuiltInFunctions.SelectOfName2);
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
