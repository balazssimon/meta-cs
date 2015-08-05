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

        public static readonly MetaPrimitiveType None;

        public static readonly MetaPrimitiveType Object;
        public static readonly MetaPrimitiveType String;
        public static readonly MetaPrimitiveType Int;
        public static readonly MetaPrimitiveType Long;
        public static readonly MetaPrimitiveType Float;
        public static readonly MetaPrimitiveType Double;
        public static readonly MetaPrimitiveType Byte;
        public static readonly MetaPrimitiveType Bool;
        public static readonly MetaPrimitiveType Void;

        public static readonly MetaPrimitiveType ModelObject;

        public static readonly MetaPrimitiveType Any;
        public static readonly MetaPrimitiveType Error;
        public static readonly MetaPrimitiveType MetaType;

        public static readonly MetaCollectionType ModelObjectList;

        public static IEnumerable<MetaType> Types
        {
            get { return MetaBuiltInTypes.types; }
        }

        static MetaBuiltInTypes()
        {
            MetaBuiltInTypes.Object = MetaModelFactory.Instance.CreateMetaPrimitiveType();
            MetaBuiltInTypes.Object.Name = "object";
            MetaBuiltInTypes.types.Add(MetaBuiltInTypes.Object);
            MetaBuiltInTypes.String = MetaModelFactory.Instance.CreateMetaPrimitiveType();
            MetaBuiltInTypes.String.Name = "string";
            MetaBuiltInTypes.types.Add(MetaBuiltInTypes.String);
            MetaBuiltInTypes.Int = MetaModelFactory.Instance.CreateMetaPrimitiveType();
            MetaBuiltInTypes.Int.Name = "int";
            MetaBuiltInTypes.types.Add(MetaBuiltInTypes.Int);
            MetaBuiltInTypes.Long = MetaModelFactory.Instance.CreateMetaPrimitiveType();
            MetaBuiltInTypes.Long.Name = "long";
            MetaBuiltInTypes.types.Add(MetaBuiltInTypes.Long);
            MetaBuiltInTypes.Float = MetaModelFactory.Instance.CreateMetaPrimitiveType();
            MetaBuiltInTypes.Float.Name = "float";
            MetaBuiltInTypes.types.Add(MetaBuiltInTypes.Float);
            MetaBuiltInTypes.Double = MetaModelFactory.Instance.CreateMetaPrimitiveType();
            MetaBuiltInTypes.Double.Name = "double";
            MetaBuiltInTypes.types.Add(MetaBuiltInTypes.Double);
            MetaBuiltInTypes.Byte = MetaModelFactory.Instance.CreateMetaPrimitiveType();
            MetaBuiltInTypes.Byte.Name = "byte";
            MetaBuiltInTypes.types.Add(MetaBuiltInTypes.Byte);
            MetaBuiltInTypes.Bool = MetaModelFactory.Instance.CreateMetaPrimitiveType();
            MetaBuiltInTypes.Bool.Name = "bool";
            MetaBuiltInTypes.types.Add(MetaBuiltInTypes.Bool);
            MetaBuiltInTypes.Void = MetaModelFactory.Instance.CreateMetaPrimitiveType();
            MetaBuiltInTypes.Void.Name = "void";
            MetaBuiltInTypes.types.Add(MetaBuiltInTypes.Void);

            MetaBuiltInTypes.ModelObject = MetaModelFactory.Instance.CreateMetaPrimitiveType();
            MetaBuiltInTypes.ModelObject.Name = "ModelObject";
            MetaBuiltInTypes.types.Add(MetaBuiltInTypes.ModelObject);

            MetaBuiltInTypes.None = MetaModelFactory.Instance.CreateMetaPrimitiveType();
            MetaBuiltInTypes.None.Name = "*none*";
            MetaBuiltInTypes.Any = MetaModelFactory.Instance.CreateMetaPrimitiveType();
            MetaBuiltInTypes.Any.Name = "*any*";
            MetaBuiltInTypes.Error = MetaModelFactory.Instance.CreateMetaPrimitiveType();
            MetaBuiltInTypes.Error.Name = "*error*";

            MetaBuiltInTypes.MetaType = MetaModelFactory.Instance.CreateMetaPrimitiveType();
            MetaBuiltInTypes.MetaType.Name = "MetaType";
            MetaBuiltInTypes.ModelObjectList = MetaModelFactory.Instance.CreateMetaCollectionType();
            MetaBuiltInTypes.ModelObjectList.Kind = MetaCollectionKind.List;
            MetaBuiltInTypes.ModelObjectList.InnerType = MetaBuiltInTypes.ModelObject;
            MetaBuiltInTypes.types.Add(MetaBuiltInTypes.ModelObject);
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
        public static readonly MetaFunction SelectOfType1;
        public static readonly MetaFunction SelectOfType2;
        public static readonly MetaFunction SelectOfName1;
        public static readonly MetaFunction SelectOfName2;

        static MetaBuiltInFunctions()
        {
            MetaBuiltInFunctions.TypeOf = MetaModelFactory.Instance.CreateMetaFunction();
            MetaBuiltInFunctions.TypeOf.Name = "typeof";
            MetaBuiltInFunctions.TypeOf.ReturnType = MetaBuiltInTypes.MetaType;
            var typeOfParam = MetaModelFactory.Instance.CreateMetaParameter();
            typeOfParam.Type = MetaBuiltInTypes.Any;
            MetaBuiltInFunctions.TypeOf.Parameters.Add(typeOfParam);
            MetaBuiltInFunctions.functions.Add(MetaBuiltInFunctions.TypeOf);

            MetaBuiltInFunctions.GetValueType = MetaModelFactory.Instance.CreateMetaFunction();
            MetaBuiltInFunctions.GetValueType.Name = "get_type";
            MetaBuiltInFunctions.GetValueType.ReturnType = MetaBuiltInTypes.MetaType;
            var getValueTypeParam = MetaModelFactory.Instance.CreateMetaParameter();
            getValueTypeParam.Type = MetaBuiltInTypes.Any;
            MetaBuiltInFunctions.GetValueType.Parameters.Add(getValueTypeParam);
            MetaBuiltInFunctions.functions.Add(MetaBuiltInFunctions.GetValueType);

            MetaBuiltInFunctions.GetReturnType = MetaModelFactory.Instance.CreateMetaFunction();
            MetaBuiltInFunctions.GetReturnType.Name = "get_return_type";
            MetaBuiltInFunctions.GetReturnType.ReturnType = MetaBuiltInTypes.MetaType;
            var getReturnTypeParam = MetaModelFactory.Instance.CreateMetaParameter();
            getReturnTypeParam.Type = MetaBuiltInTypes.Any;
            MetaBuiltInFunctions.GetReturnType.Parameters.Add(getReturnTypeParam);
            MetaBuiltInFunctions.functions.Add(MetaBuiltInFunctions.GetReturnType);

            MetaBuiltInFunctions.CurrentType = MetaModelFactory.Instance.CreateMetaFunction();
            MetaBuiltInFunctions.CurrentType.Name = "current_type";
            MetaBuiltInFunctions.CurrentType.ReturnType = MetaBuiltInTypes.MetaType;
            var currentTypeParam = MetaModelFactory.Instance.CreateMetaParameter();
            currentTypeParam.Type = MetaBuiltInTypes.ModelObject;
            MetaBuiltInFunctions.CurrentType.Parameters.Add(currentTypeParam);
            MetaBuiltInFunctions.functions.Add(MetaBuiltInFunctions.CurrentType);

            MetaBuiltInFunctions.TypeCheck = MetaModelFactory.Instance.CreateMetaFunction();
            MetaBuiltInFunctions.TypeCheck.Name = "type_check";
            MetaBuiltInFunctions.TypeCheck.ReturnType = MetaBuiltInTypes.Bool;
            var typeCheckParam = MetaModelFactory.Instance.CreateMetaParameter();
            typeCheckParam.Type = MetaBuiltInTypes.ModelObject;
            MetaBuiltInFunctions.TypeCheck.Parameters.Add(typeCheckParam);
            MetaBuiltInFunctions.functions.Add(MetaBuiltInFunctions.TypeCheck);

            MetaBuiltInFunctions.Balance = MetaModelFactory.Instance.CreateMetaFunction();
            MetaBuiltInFunctions.Balance.Name = "balance";
            MetaBuiltInFunctions.Balance.ReturnType = MetaBuiltInTypes.MetaType;
            var balanceLeftParam = MetaModelFactory.Instance.CreateMetaParameter();
            balanceLeftParam.Type = MetaBuiltInTypes.MetaType;
            MetaBuiltInFunctions.Balance.Parameters.Add(balanceLeftParam);
            var balanceRightParam = MetaModelFactory.Instance.CreateMetaParameter();
            balanceRightParam.Type = MetaBuiltInTypes.MetaType;
            MetaBuiltInFunctions.Balance.Parameters.Add(balanceRightParam);
            MetaBuiltInFunctions.functions.Add(MetaBuiltInFunctions.Balance);

            MetaBuiltInFunctions.Resolve1 = MetaModelFactory.Instance.CreateMetaFunction();
            MetaBuiltInFunctions.Resolve1.Name = "resolve";
            MetaBuiltInFunctions.Resolve1.ReturnType = MetaBuiltInTypes.ModelObjectList;
            var resolve1Param = MetaModelFactory.Instance.CreateMetaParameter();
            resolve1Param.Type = MetaBuiltInTypes.String;
            MetaBuiltInFunctions.Resolve1.Parameters.Add(resolve1Param);
            MetaBuiltInFunctions.functions.Add(MetaBuiltInFunctions.Resolve1);

            MetaBuiltInFunctions.ResolveName1 = MetaModelFactory.Instance.CreateMetaFunction();
            MetaBuiltInFunctions.ResolveName1.Name = "resolve_name";
            MetaBuiltInFunctions.ResolveName1.ReturnType = MetaBuiltInTypes.ModelObjectList;
            var resolveName1Param = MetaModelFactory.Instance.CreateMetaParameter();
            resolveName1Param.Type = MetaBuiltInTypes.String;
            MetaBuiltInFunctions.ResolveName1.Parameters.Add(resolveName1Param);
            MetaBuiltInFunctions.functions.Add(MetaBuiltInFunctions.ResolveName1);

            MetaBuiltInFunctions.ResolveType1 = MetaModelFactory.Instance.CreateMetaFunction();
            MetaBuiltInFunctions.ResolveType1.Name = "resolve_type";
            MetaBuiltInFunctions.ResolveType1.ReturnType = MetaBuiltInTypes.ModelObjectList;
            var resolveType1Param = MetaModelFactory.Instance.CreateMetaParameter();
            resolveType1Param.Type = MetaBuiltInTypes.String;
            MetaBuiltInFunctions.ResolveType1.Parameters.Add(resolveType1Param);
            MetaBuiltInFunctions.functions.Add(MetaBuiltInFunctions.ResolveType1);

            MetaBuiltInFunctions.Resolve2 = MetaModelFactory.Instance.CreateMetaFunction();
            MetaBuiltInFunctions.Resolve2.Name = "resolve";
            MetaBuiltInFunctions.Resolve2.ReturnType = MetaBuiltInTypes.ModelObjectList;
            var resolve2ContextParam = MetaModelFactory.Instance.CreateMetaParameter();
            resolve2ContextParam.Type = MetaBuiltInTypes.ModelObject;
            MetaBuiltInFunctions.Resolve2.Parameters.Add(resolve2ContextParam);
            var resolve2Param = MetaModelFactory.Instance.CreateMetaParameter();
            resolve2Param.Type = MetaBuiltInTypes.String;
            MetaBuiltInFunctions.Resolve2.Parameters.Add(resolve2Param);
            MetaBuiltInFunctions.functions.Add(MetaBuiltInFunctions.Resolve2);

            MetaBuiltInFunctions.ResolveName2 = MetaModelFactory.Instance.CreateMetaFunction();
            MetaBuiltInFunctions.ResolveName2.Name = "resolve_name";
            MetaBuiltInFunctions.ResolveName2.ReturnType = MetaBuiltInTypes.ModelObjectList;
            var resolveName2ContextParam = MetaModelFactory.Instance.CreateMetaParameter();
            resolveName2ContextParam.Type = MetaBuiltInTypes.ModelObject;
            MetaBuiltInFunctions.ResolveName2.Parameters.Add(resolveName2ContextParam);
            var resolveName2Param = MetaModelFactory.Instance.CreateMetaParameter();
            resolveName2Param.Type = MetaBuiltInTypes.String;
            MetaBuiltInFunctions.ResolveName2.Parameters.Add(resolveName2Param);
            MetaBuiltInFunctions.functions.Add(MetaBuiltInFunctions.ResolveName2);

            MetaBuiltInFunctions.ResolveType2 = MetaModelFactory.Instance.CreateMetaFunction();
            MetaBuiltInFunctions.ResolveType2.Name = "resolve_type";
            MetaBuiltInFunctions.ResolveType2.ReturnType = MetaBuiltInTypes.ModelObjectList;
            var resolveType2ContextParam = MetaModelFactory.Instance.CreateMetaParameter();
            resolveType2ContextParam.Type = MetaBuiltInTypes.ModelObject;
            MetaBuiltInFunctions.ResolveType2.Parameters.Add(resolveType2ContextParam);
            var resolveType2Param = MetaModelFactory.Instance.CreateMetaParameter();
            resolveType2Param.Type = MetaBuiltInTypes.String;
            MetaBuiltInFunctions.ResolveType2.Parameters.Add(resolveType2Param);
            MetaBuiltInFunctions.functions.Add(MetaBuiltInFunctions.ResolveType2);

            MetaBuiltInFunctions.Bind1 = MetaModelFactory.Instance.CreateMetaFunction();
            MetaBuiltInFunctions.Bind1.Name = "bind";
            MetaBuiltInFunctions.Bind1.ReturnType = MetaBuiltInTypes.ModelObject;
            var bind1Param = MetaModelFactory.Instance.CreateMetaParameter();
            bind1Param.Type = MetaBuiltInTypes.ModelObjectList;
            MetaBuiltInFunctions.Bind1.Parameters.Add(bind1Param);
            MetaBuiltInFunctions.functions.Add(MetaBuiltInFunctions.Bind1);

            MetaBuiltInFunctions.Bind2 = MetaModelFactory.Instance.CreateMetaFunction();
            MetaBuiltInFunctions.Bind2.Name = "bind";
            MetaBuiltInFunctions.Bind2.ReturnType = MetaBuiltInTypes.ModelObject;
            var bind2Param = MetaModelFactory.Instance.CreateMetaParameter();
            bind2Param.Type = MetaBuiltInTypes.ModelObject;
            MetaBuiltInFunctions.Bind2.Parameters.Add(bind2Param);
            MetaBuiltInFunctions.functions.Add(MetaBuiltInFunctions.Bind2);

            MetaBuiltInFunctions.SelectOfType1 = MetaModelFactory.Instance.CreateMetaFunction();
            MetaBuiltInFunctions.SelectOfType1.Name = "select_of_type";
            MetaBuiltInFunctions.SelectOfType1.ReturnType = MetaBuiltInTypes.ModelObjectList;
            var selectOfType1SymbolsParam = MetaModelFactory.Instance.CreateMetaParameter();
            selectOfType1SymbolsParam.Type = MetaBuiltInTypes.ModelObjectList;
            MetaBuiltInFunctions.SelectOfType1.Parameters.Add(selectOfType1SymbolsParam);
            var selectOfType1TypeParam = MetaModelFactory.Instance.CreateMetaParameter();
            selectOfType1TypeParam.Type = MetaBuiltInTypes.MetaType;
            MetaBuiltInFunctions.SelectOfType1.Parameters.Add(selectOfType1TypeParam);
            MetaBuiltInFunctions.functions.Add(MetaBuiltInFunctions.SelectOfType1);

            MetaBuiltInFunctions.SelectOfType2 = MetaModelFactory.Instance.CreateMetaFunction();
            MetaBuiltInFunctions.SelectOfType2.Name = "select_of_type";
            MetaBuiltInFunctions.SelectOfType2.ReturnType = MetaBuiltInTypes.ModelObjectList;
            var selectOfType2SymbolsParam = MetaModelFactory.Instance.CreateMetaParameter();
            selectOfType2SymbolsParam.Type = MetaBuiltInTypes.ModelObject;
            MetaBuiltInFunctions.SelectOfType2.Parameters.Add(selectOfType2SymbolsParam);
            var selectOfType2TypeParam = MetaModelFactory.Instance.CreateMetaParameter();
            selectOfType2TypeParam.Type = MetaBuiltInTypes.MetaType;
            MetaBuiltInFunctions.SelectOfType2.Parameters.Add(selectOfType2TypeParam);
            MetaBuiltInFunctions.functions.Add(MetaBuiltInFunctions.SelectOfType2);

            MetaBuiltInFunctions.SelectOfName1 = MetaModelFactory.Instance.CreateMetaFunction();
            MetaBuiltInFunctions.SelectOfName1.Name = "select_of_name";
            MetaBuiltInFunctions.SelectOfName1.ReturnType = MetaBuiltInTypes.ModelObjectList;
            var selectOfName1SymbolsParam = MetaModelFactory.Instance.CreateMetaParameter();
            selectOfName1SymbolsParam.Type = MetaBuiltInTypes.ModelObjectList;
            MetaBuiltInFunctions.SelectOfName1.Parameters.Add(selectOfName1SymbolsParam);
            var selectOfName1NameParam = MetaModelFactory.Instance.CreateMetaParameter();
            selectOfName1NameParam.Type = MetaBuiltInTypes.String;
            MetaBuiltInFunctions.SelectOfName1.Parameters.Add(selectOfName1NameParam);
            MetaBuiltInFunctions.functions.Add(MetaBuiltInFunctions.SelectOfName1);

            MetaBuiltInFunctions.SelectOfName2 = MetaModelFactory.Instance.CreateMetaFunction();
            MetaBuiltInFunctions.SelectOfName2.Name = "select_of_name";
            MetaBuiltInFunctions.SelectOfName2.ReturnType = MetaBuiltInTypes.ModelObjectList;
            var selectOfName2SymbolsParam = MetaModelFactory.Instance.CreateMetaParameter();
            selectOfName2SymbolsParam.Type = MetaBuiltInTypes.ModelObject;
            MetaBuiltInFunctions.SelectOfName2.Parameters.Add(selectOfName2SymbolsParam);
            var selectOfName2NameParam = MetaModelFactory.Instance.CreateMetaParameter();
            selectOfName2NameParam.Type = MetaBuiltInTypes.String;
            MetaBuiltInFunctions.SelectOfName2.Parameters.Add(selectOfName2NameParam);
            MetaBuiltInFunctions.functions.Add(MetaBuiltInFunctions.SelectOfName2);
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

    //internal class MetaModelImplementation : MetaModelImplementationBase
    internal class MetaImplementation : MetaImplementationBase
    {
        public override void MetaAnnotation_MetaAnnotation(MetaAnnotation @this)
        {
            base.MetaAnnotation_MetaAnnotation(@this);
        }

        public override void MetaEnumLiteral_MetaEnumLiteral(MetaEnumLiteral @this)
        {
            base.MetaEnumLiteral_MetaEnumLiteral(@this);
            ((ModelObject)@this).MLazySet(Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => @this.Enum));
        }

        public override void MetaFunction_MetaFunction(MetaFunction @this)
        {
            base.MetaFunction_MetaFunction(@this);
            MetaFunctionType type = MetaModelFactory.Instance.CreateMetaFunctionType();
            ((ModelObject)type).MUnSet(Meta.MetaFunctionType.ParameterTypesProperty);
            ((ModelObject)type).MLazySet(Meta.MetaFunctionType.ParameterTypesProperty, new Lazy<object>(() => new ModelMultiList<MetaType>((ModelObject)type, Meta.MetaFunctionType.ParameterTypesProperty, @this.Parameters.Select(p => new Lazy<object>(() => p.Type))), false));
            ((ModelObject)type).MLazySet(Meta.MetaFunctionType.ReturnTypeProperty, new Lazy<object>(() => @this.ReturnType));
            ((ModelObject)@this).MSet(Meta.MetaFunction.TypeProperty, type);
        }

        public override void MetaPropertyInitializer_MetaPropertyInitializer(MetaPropertyInitializer @this)
        {
            base.MetaPropertyInitializer_MetaPropertyInitializer(@this);
            ModelContext ctx = ModelContext.Current;
            if (ctx != null)
            {
                IModelCompiler compiler = ctx.Compiler;
                ((ModelObject)@this).MLazySet(Meta.MetaPropertyInitializer.PropertyProperty,
                    new Lazy<object>(() =>
                    compiler.BindingProvider.Bind(
                        (ModelObject)@this,
                        compiler.ResolutionProvider.Resolve(new ModelObject[] { compiler.ResolutionProvider.GetCurrentScope((ModelObject)@this) }, ResolveKind.Name, @this.PropertyName, new ResolutionInfo(), ResolveFlags.Scope),
                        new BindingInfo()
                        )));
                ((ModelObject)@this).MLazySetChild(Meta.MetaPropertyInitializer.ValueProperty, Meta.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => compiler.TypeProvider.GetTypeOf((ModelObject)@this.Property)));
            }
        }

        public override void MetaInheritedPropertyInitializer_MetaInheritedPropertyInitializer(MetaInheritedPropertyInitializer @this)
        {
            base.MetaInheritedPropertyInitializer_MetaInheritedPropertyInitializer(@this);
            ModelContext ctx = ModelContext.Current;
            if (ctx != null)
            {
                IModelCompiler compiler = ctx.Compiler;
                ((ModelObject)@this).MLazySet(Meta.MetaInheritedPropertyInitializer.ObjectProperty,
                    new Lazy<object>(() =>
                    compiler.BindingProvider.Bind(
                        (ModelObject)@this,
                        compiler.ResolutionProvider.Resolve(new ModelObject[] { compiler.ResolutionProvider.GetCurrentScope((ModelObject)@this) }, ResolveKind.Name, @this.ObjectName, new ResolutionInfo(), ResolveFlags.Scope),
                        new BindingInfo()
                        )));
                ((ModelObject)@this).MLazySet(Meta.MetaPropertyInitializer.PropertyProperty,
                    new Lazy<object>(() =>
                    compiler.BindingProvider.Bind(
                        (ModelObject)@this,
                        compiler.ResolutionProvider.Resolve(new ModelObject[] { (ModelObject)this.GetType((ModelObject)@this.Object) }, ResolveKind.Name, @this.PropertyName, new ResolutionInfo(), ResolveFlags.Scope),
                        new BindingInfo()
                        )));
            }
        }

        public override void MetaExpression_MetaExpression(MetaExpression @this)
        {
            base.MetaExpression_MetaExpression(@this);
            ModelContext ctx = ModelContext.Current;
            if (ctx != null)
            {
                IModelCompiler compiler = ctx.Compiler;
                ((ModelObject)@this).MLazySet(Meta.MetaExpression.NoTypeErrorProperty, new Lazy<object>(() => compiler.TypeProvider.TypeCheck((ModelObject)@this)));
            }
        }

        public override void MetaBracketExpression_MetaBracketExpression(MetaBracketExpression @this)
        {
            base.MetaBracketExpression_MetaBracketExpression(@this);
            ((ModelObject)@this).MLazySet(Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => @this.Expression.Type));
            ((ModelObject)@this).MLazySetChild(Meta.MetaBracketExpression.ExpressionProperty, Meta.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => @this.ExpectedType));
        }

        public override void MetaBoundExpression_MetaBoundExpression(MetaBoundExpression @this)
        {
            base.MetaBoundExpression_MetaBoundExpression(@this);
            ModelContext ctx = ModelContext.Current;
            if (ctx != null)
            {
                IModelCompiler compiler = ctx.Compiler;
                ((ModelObject)@this).MLazySet(Meta.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => true));
                ((ModelObject)@this).MLazySet(Meta.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => compiler.BindingProvider.Bind((ModelObject)@this, @this.Definitions != null ? @this.Definitions.OfType<ModelObject>() : new ModelObject[0], new BindingInfo())));
                ((ModelObject)@this).MLazySet(Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => this.GetType((ModelObject)@this.Definition)));
            }
        }

        public override void MetaThisExpression_MetaThisExpression(MetaThisExpression @this)
        {
            base.MetaThisExpression_MetaThisExpression(@this);
            ModelContext ctx = ModelContext.Current;
            if (ctx != null)
            {
                IModelCompiler compiler = ctx.Compiler;
                ((ModelObject)@this).MLazySet(Meta.MetaBoundExpression.DefinitionProperty, new Lazy<object>(() => compiler.ResolutionProvider.GetCurrentScope((ModelObject)@this)));
            }
        }

        public override void MetaNullExpression_MetaNullExpression(MetaNullExpression @this)
        {
            base.MetaNullExpression_MetaNullExpression(@this);
            ((ModelObject)@this).MSet(Meta.MetaTypedElement.TypeProperty, MetaBuiltInTypes.Any);
        }

        public override void MetaTypeConversionExpression_MetaTypeConversionExpression(MetaTypeConversionExpression @this)
        {
            base.MetaTypeConversionExpression_MetaTypeConversionExpression(@this);
            ModelContext ctx = ModelContext.Current;
            if (ctx != null)
            {
                IModelCompiler compiler = ctx.Compiler;
                ((ModelObject)@this).MLazySet(Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => @this.TypeReference));
                ((ModelObject)@this).MLazySetChild(Meta.MetaTypeConversionExpression.ExpressionProperty, Meta.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => MetaBuiltInTypes.Any));
            }
        }

        public override void MetaTypeCheckExpression_MetaTypeCheckExpression(MetaTypeCheckExpression @this)
        {
            base.MetaTypeCheckExpression_MetaTypeCheckExpression(@this);
            ModelContext ctx = ModelContext.Current;
            if (ctx != null)
            {
                IModelCompiler compiler = ctx.Compiler;
                ((ModelObject)@this).MLazySet(Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => MetaBuiltInTypes.Bool));
                ((ModelObject)@this).MLazySetChild(Meta.MetaTypeCheckExpression.ExpressionProperty, Meta.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => MetaBuiltInTypes.Any));
            }
        }

        public override void MetaTypeOfExpression_MetaTypeOfExpression(MetaTypeOfExpression @this)
        {
            base.MetaTypeOfExpression_MetaTypeOfExpression(@this);
            ((ModelObject)@this).MSet(Meta.MetaTypedElement.TypeProperty, MetaBuiltInTypes.MetaType);
        }

        public override void MetaConditionalExpression_MetaConditionalExpression(MetaConditionalExpression @this)
        {
            base.MetaConditionalExpression_MetaConditionalExpression(@this);
            ModelContext ctx = ModelContext.Current;
            if (ctx != null)
            {
                IModelCompiler compiler = ctx.Compiler;
                ((ModelObject)@this).MLazySet(Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => compiler.TypeProvider.Balance((ModelObject)@this.Then.Type, (ModelObject)@this.Else.Type)));
                ((ModelObject)@this).MLazySetChild(Meta.MetaConditionalExpression.ConditionProperty, Meta.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => MetaBuiltInTypes.Bool));
                ((ModelObject)@this).MLazySetChild(Meta.MetaConditionalExpression.ThenProperty, Meta.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => @this.ExpectedType));
                ((ModelObject)@this).MLazySetChild(Meta.MetaConditionalExpression.ElseProperty, Meta.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => @this.ExpectedType));
            }
        }

        public override void MetaConstantExpression_MetaConstantExpression(MetaConstantExpression @this)
        {
            base.MetaConstantExpression_MetaConstantExpression(@this);
            ModelContext ctx = ModelContext.Current;
            if (ctx != null)
            {
                IModelCompiler compiler = ctx.Compiler;
                ((ModelObject)@this).MLazySet(Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => compiler.TypeProvider.GetTypeOf(@this.Value)));
            }
        }

        public override void MetaIdentifierExpression_MetaIdentifierExpression(MetaIdentifierExpression @this)
        {
            base.MetaIdentifierExpression_MetaIdentifierExpression(@this);
            ModelContext ctx = ModelContext.Current;
            if (ctx != null)
            {
                IModelCompiler compiler = ctx.Compiler;
                ((ModelObject)@this).MLazySet(Meta.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => compiler.ResolutionProvider.Resolve(new ModelObject[] { compiler.ResolutionProvider.GetCurrentScope((ModelObject)@this) }, ResolveKind.NameOrType, @this.Name, new ResolutionInfo(), ResolveFlags.All).ToList()));
            }
        }

        public override void MetaMemberAccessExpression_MetaMemberAccessExpression(MetaMemberAccessExpression @this)
        {
            base.MetaMemberAccessExpression_MetaMemberAccessExpression(@this);
            ModelContext ctx = ModelContext.Current;
            if (ctx != null)
            {
                IModelCompiler compiler = ctx.Compiler;
                ((ModelObject)@this).MLazySet(Meta.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => compiler.ResolutionProvider.Resolve(new ModelObject[] { (ModelObject)this.GetType((ModelObject)@this.Expression) }, ResolveKind.Name, @this.Name, new ResolutionInfo(), ResolveFlags.Scope).ToList()));
                ((ModelObject)@this).MLazySetChild(Meta.MetaMemberAccessExpression.ExpressionProperty, Meta.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => false));
                ((ModelObject)@this).MLazySetChild(Meta.MetaMemberAccessExpression.ExpressionProperty, Meta.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => MetaBuiltInTypes.None));
            }
        }

        public override void MetaFunctionCallExpression_MetaFunctionCallExpression(MetaFunctionCallExpression @this)
        {
            base.MetaFunctionCallExpression_MetaFunctionCallExpression(@this);
            ModelContext ctx = ModelContext.Current;
            if (ctx != null)
            {
                IModelCompiler compiler = ctx.Compiler;
                ((ModelObject)@this).MLazySet(Meta.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ((MetaBoundExpression)@this.Expression).Definitions.OfType<MetaFunction>().OfType<ModelObject>().ToList()));
                ((ModelObject)@this).MLazySet(Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => this.GetReturnType((ModelObject)@this.Definition)));
                ((ModelObject)@this).MLazySetChild(Meta.MetaFunctionCallExpression.ExpressionProperty, Meta.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => false));
                ((ModelObject)@this).MLazySetChild(Meta.MetaFunctionCallExpression.ExpressionProperty, Meta.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => MetaBuiltInTypes.None));
            }
        }

        public override void MetaIndexerExpression_MetaIndexerExpression(MetaIndexerExpression @this)
        {
            base.MetaIndexerExpression_MetaIndexerExpression(@this);
            ModelContext ctx = ModelContext.Current;
            if (ctx != null)
            {
                IModelCompiler compiler = ctx.Compiler;
                ((ModelObject)@this).MLazySet(Meta.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => ((MetaBoundExpression)@this.Expression).Definitions.OfType<MetaFunction>().Where(e => e.Name == "operator[]").ToList()));
                ((ModelObject)@this).MLazySetChild(Meta.MetaIndexerExpression.ExpressionProperty, Meta.MetaBoundExpression.UniqueDefinitionProperty, new Lazy<object>(() => false));
                ((ModelObject)@this).MLazySetChild(Meta.MetaIndexerExpression.ExpressionProperty, Meta.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => MetaBuiltInTypes.None));
            }
        }

        public override void MetaOperatorExpression_MetaOperatorExpression(MetaOperatorExpression @this)
        {
            base.MetaOperatorExpression_MetaOperatorExpression(@this);
            ModelContext ctx = ModelContext.Current;
            if (ctx != null)
            {
                IModelCompiler compiler = ctx.Compiler;
                ((ModelObject)@this).MLazySet(Meta.MetaBoundExpression.DefinitionsProperty, new Lazy<object>(() => compiler.ResolutionProvider.Resolve(new ModelObject[] { compiler.ResolutionProvider.GetCurrentScope((ModelObject)@this) }, ResolveKind.Name, @this.Name, new ResolutionInfo(), ResolveFlags.All).ToList()));
            }
        }

        public override void MetaUnaryExpression_MetaUnaryExpression(MetaUnaryExpression @this)
        {
            base.MetaUnaryExpression_MetaUnaryExpression(@this);
            ((ModelObject)@this).MLazyAdd(Meta.MetaBoundExpression.ArgumentsProperty, new Lazy<object>(() => @this.Expression));
        }

        public override void MetaUnaryPlusExpression_MetaUnaryPlusExpression(MetaUnaryPlusExpression @this)
        {
            base.MetaUnaryPlusExpression_MetaUnaryPlusExpression(@this);
            ((ModelObject)@this).MSet(Meta.MetaOperatorExpression.NameProperty, "operator+()");
        }

        public override void MetaNegateExpression_MetaNegateExpression(MetaNegateExpression @this)
        {
            base.MetaNegateExpression_MetaNegateExpression(@this);
            ((ModelObject)@this).MSet(Meta.MetaOperatorExpression.NameProperty, "operator-()");
        }

        public override void MetaOnesComplementExpression_MetaOnesComplementExpression(MetaOnesComplementExpression @this)
        {
            base.MetaOnesComplementExpression_MetaOnesComplementExpression(@this);
            ((ModelObject)@this).MSet(Meta.MetaOperatorExpression.NameProperty, "operator~()");
        }

        public override void MetaNotExpression_MetaNotExpression(MetaNotExpression @this)
        {
            base.MetaNotExpression_MetaNotExpression(@this);
            ((ModelObject)@this).MSet(Meta.MetaOperatorExpression.NameProperty, "operator!()");
        }

        public override void MetaPostIncrementAssignExpression_MetaPostIncrementAssignExpression(MetaPostIncrementAssignExpression @this)
        {
            base.MetaPostIncrementAssignExpression_MetaPostIncrementAssignExpression(@this);
            ((ModelObject)@this).MSet(Meta.MetaOperatorExpression.NameProperty, "operator()++");
        }

        public override void MetaPostDecrementAssignExpression_MetaPostDecrementAssignExpression(MetaPostDecrementAssignExpression @this)
        {
            base.MetaPostDecrementAssignExpression_MetaPostDecrementAssignExpression(@this);
            ((ModelObject)@this).MSet(Meta.MetaOperatorExpression.NameProperty, "operator()--");
        }

        public override void MetaPreIncrementAssignExpression_MetaPreIncrementAssignExpression(MetaPreIncrementAssignExpression @this)
        {
            base.MetaPreIncrementAssignExpression_MetaPreIncrementAssignExpression(@this);
            ((ModelObject)@this).MSet(Meta.MetaOperatorExpression.NameProperty, "operator++()");
        }

        public override void MetaPreDecrementAssignExpression_MetaPreDecrementAssignExpression(MetaPreDecrementAssignExpression @this)
        {
            base.MetaPreDecrementAssignExpression_MetaPreDecrementAssignExpression(@this);
            ((ModelObject)@this).MSet(Meta.MetaOperatorExpression.NameProperty, "operator--()");
        }

        public override void MetaBinaryExpression_MetaBinaryExpression(MetaBinaryExpression @this)
        {
            base.MetaBinaryExpression_MetaBinaryExpression(@this);
            ((ModelObject)@this).MLazyAdd(Meta.MetaBoundExpression.ArgumentsProperty, new Lazy<object>(() => @this.Left));
            ((ModelObject)@this).MLazyAdd(Meta.MetaBoundExpression.ArgumentsProperty, new Lazy<object>(() => @this.Right));
        }

        public override void MetaMultiplyExpression_MetaMultiplyExpression(MetaMultiplyExpression @this)
        {
            base.MetaMultiplyExpression_MetaMultiplyExpression(@this);
            ((ModelObject)@this).MSet(Meta.MetaOperatorExpression.NameProperty, "operator()*()");
        }

        public override void MetaDivideExpression_MetaDivideExpression(MetaDivideExpression @this)
        {
            base.MetaDivideExpression_MetaDivideExpression(@this);
            ((ModelObject)@this).MSet(Meta.MetaOperatorExpression.NameProperty, "operator()/()");
        }

        public override void MetaModuloExpression_MetaModuloExpression(MetaModuloExpression @this)
        {
            base.MetaModuloExpression_MetaModuloExpression(@this);
            ((ModelObject)@this).MSet(Meta.MetaOperatorExpression.NameProperty, "operator()%()");
        }

        public override void MetaAddExpression_MetaAddExpression(MetaAddExpression @this)
        {
            base.MetaAddExpression_MetaAddExpression(@this);
            ((ModelObject)@this).MSet(Meta.MetaOperatorExpression.NameProperty, "operator()+()");
        }

        public override void MetaSubtractExpression_MetaSubtractExpression(MetaSubtractExpression @this)
        {
            base.MetaSubtractExpression_MetaSubtractExpression(@this);
            ((ModelObject)@this).MSet(Meta.MetaOperatorExpression.NameProperty, "operator()-()");
        }

        public override void MetaLeftShiftExpression_MetaLeftShiftExpression(MetaLeftShiftExpression @this)
        {
            base.MetaLeftShiftExpression_MetaLeftShiftExpression(@this);
            ((ModelObject)@this).MSet(Meta.MetaOperatorExpression.NameProperty, "operator()<<()");
        }

        public override void MetaRightShiftExpression_MetaRightShiftExpression(MetaRightShiftExpression @this)
        {
            base.MetaRightShiftExpression_MetaRightShiftExpression(@this);
            ((ModelObject)@this).MSet(Meta.MetaOperatorExpression.NameProperty, "operator()>>()");
        }

        public override void MetaLessThanExpression_MetaLessThanExpression(MetaLessThanExpression @this)
        {
            base.MetaLessThanExpression_MetaLessThanExpression(@this);
            ((ModelObject)@this).MSet(Meta.MetaOperatorExpression.NameProperty, "operator()<()");
        }

        public override void MetaLessThanOrEqualExpression_MetaLessThanOrEqualExpression(MetaLessThanOrEqualExpression @this)
        {
            base.MetaLessThanOrEqualExpression_MetaLessThanOrEqualExpression(@this);
            ((ModelObject)@this).MSet(Meta.MetaOperatorExpression.NameProperty, "operator()<=()");
        }

        public override void MetaGreaterThanExpression_MetaGreaterThanExpression(MetaGreaterThanExpression @this)
        {
            base.MetaGreaterThanExpression_MetaGreaterThanExpression(@this);
            ((ModelObject)@this).MSet(Meta.MetaOperatorExpression.NameProperty, "operator()>()");
        }

        public override void MetaGreaterThanOrEqualExpression_MetaGreaterThanOrEqualExpression(MetaGreaterThanOrEqualExpression @this)
        {
            base.MetaGreaterThanOrEqualExpression_MetaGreaterThanOrEqualExpression(@this);
            ((ModelObject)@this).MSet(Meta.MetaOperatorExpression.NameProperty, "operator()>=()");
        }

        public override void MetaEqualExpression_MetaEqualExpression(MetaEqualExpression @this)
        {
            base.MetaEqualExpression_MetaEqualExpression(@this);
            ((ModelObject)@this).MSet(Meta.MetaOperatorExpression.NameProperty, "operator()==()");
        }

        public override void MetaNotEqualExpression_MetaNotEqualExpression(MetaNotEqualExpression @this)
        {
            base.MetaNotEqualExpression_MetaNotEqualExpression(@this);
            ((ModelObject)@this).MSet(Meta.MetaOperatorExpression.NameProperty, "operator()!=()");
        }

        public override void MetaAndExpression_MetaAndExpression(MetaAndExpression @this)
        {
            base.MetaAndExpression_MetaAndExpression(@this);
            ((ModelObject)@this).MSet(Meta.MetaOperatorExpression.NameProperty, "operator()&()");
        }

        public override void MetaOrExpression_MetaOrExpression(MetaOrExpression @this)
        {
            base.MetaOrExpression_MetaOrExpression(@this);
            ((ModelObject)@this).MSet(Meta.MetaOperatorExpression.NameProperty, "operator()|()");
        }

        public override void MetaExclusiveOrExpression_MetaExclusiveOrExpression(MetaExclusiveOrExpression @this)
        {
            base.MetaExclusiveOrExpression_MetaExclusiveOrExpression(@this);
            ((ModelObject)@this).MSet(Meta.MetaOperatorExpression.NameProperty, "operator()^()");
        }

        public override void MetaAndAlsoExpression_MetaAndAlsoExpression(MetaAndAlsoExpression @this)
        {
            base.MetaAndAlsoExpression_MetaAndAlsoExpression(@this);
            ((ModelObject)@this).MSet(Meta.MetaOperatorExpression.NameProperty, "operator()&&()");
        }

        public override void MetaOrElseExpression_MetaOrElseExpression(MetaOrElseExpression @this)
        {
            base.MetaOrElseExpression_MetaOrElseExpression(@this);
            ((ModelObject)@this).MSet(Meta.MetaOperatorExpression.NameProperty, "operator()||()");
        }

        public override void MetaNullCoalescingExpression_MetaNullCoalescingExpression(MetaNullCoalescingExpression @this)
        {
            base.MetaNullCoalescingExpression_MetaNullCoalescingExpression(@this);
            ((ModelObject)@this).MSet(Meta.MetaOperatorExpression.NameProperty, "operator()??()");
        }

        public override void MetaAssignmentExpression_MetaAssignmentExpression(MetaAssignmentExpression @this)
        {
            base.MetaAssignmentExpression_MetaAssignmentExpression(@this);
            ModelContext ctx = ModelContext.Current;
            if (ctx != null)
            {
                IModelCompiler compiler = ctx.Compiler;
                ((ModelObject)@this).MLazySetChild(Meta.MetaBinaryExpression.LeftProperty, Meta.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => @this.ExpectedType));
                ((ModelObject)@this).MLazySetChild(Meta.MetaBinaryExpression.RightProperty, Meta.MetaExpression.ExpectedTypeProperty, new Lazy<object>(() => @this.Type));
                ((ModelObject)@this).MLazySet(Meta.MetaTypedElement.TypeProperty, new Lazy<object>(() => this.GetType((ModelObject)@this.Left)));
            }
        }

        public override void MetaAssignExpression_MetaAssignExpression(MetaAssignExpression @this)
        {
            base.MetaAssignExpression_MetaAssignExpression(@this);
            ((ModelObject)@this).MSet(Meta.MetaOperatorExpression.NameProperty, "operator()=()");
        }

        public override void MetaMultiplyAssignExpression_MetaMultiplyAssignExpression(MetaMultiplyAssignExpression @this)
        {
            base.MetaMultiplyAssignExpression_MetaMultiplyAssignExpression(@this);
            ((ModelObject)@this).MSet(Meta.MetaOperatorExpression.NameProperty, "operator()*=()");
        }

        public override void MetaDivideAssignExpression_MetaDivideAssignExpression(MetaDivideAssignExpression @this)
        {
            base.MetaDivideAssignExpression_MetaDivideAssignExpression(@this);
            ((ModelObject)@this).MSet(Meta.MetaOperatorExpression.NameProperty, "operator()/=()");
        }

        public override void MetaModuloAssignExpression_MetaModuloAssignExpression(MetaModuloAssignExpression @this)
        {
            base.MetaModuloAssignExpression_MetaModuloAssignExpression(@this);
            ((ModelObject)@this).MSet(Meta.MetaOperatorExpression.NameProperty, "operator()%=()");
        }

        public override void MetaAddAssignExpression_MetaAddAssignExpression(MetaAddAssignExpression @this)
        {
            base.MetaAddAssignExpression_MetaAddAssignExpression(@this);
            ((ModelObject)@this).MSet(Meta.MetaOperatorExpression.NameProperty, "operator()+=()");
        }

        public override void MetaSubtractAssignExpression_MetaSubtractAssignExpression(MetaSubtractAssignExpression @this)
        {
            base.MetaSubtractAssignExpression_MetaSubtractAssignExpression(@this);
            ((ModelObject)@this).MSet(Meta.MetaOperatorExpression.NameProperty, "operator()-=()");
        }

        public override void MetaLeftShiftAssignExpression_MetaLeftShiftAssignExpression(MetaLeftShiftAssignExpression @this)
        {
            base.MetaLeftShiftAssignExpression_MetaLeftShiftAssignExpression(@this);
            ((ModelObject)@this).MSet(Meta.MetaOperatorExpression.NameProperty, "operator()<<=()");
        }

        public override void MetaRightShiftAssignExpression_MetaRightShiftAssignExpression(MetaRightShiftAssignExpression @this)
        {
            base.MetaRightShiftAssignExpression_MetaRightShiftAssignExpression(@this);
            ((ModelObject)@this).MSet(Meta.MetaOperatorExpression.NameProperty, "operator()>>=()");
        }

        public override void MetaAndAssignExpression_MetaAndAssignExpression(MetaAndAssignExpression @this)
        {
            base.MetaAndAssignExpression_MetaAndAssignExpression(@this);
            ((ModelObject)@this).MSet(Meta.MetaOperatorExpression.NameProperty, "operator()&=()");
        }

        public override void MetaOrAssignExpression_MetaOrAssignExpression(MetaOrAssignExpression @this)
        {
            base.MetaOrAssignExpression_MetaOrAssignExpression(@this);
            ((ModelObject)@this).MSet(Meta.MetaOperatorExpression.NameProperty, "operator()|=()");
        }

        public override void MetaExclusiveOrAssignExpression_MetaExclusiveOrAssignExpression(MetaExclusiveOrAssignExpression @this)
        {
            base.MetaExclusiveOrAssignExpression_MetaExclusiveOrAssignExpression(@this);
            ((ModelObject)@this).MSet(Meta.MetaOperatorExpression.NameProperty, "operator()^=()");
        }

        private MetaType GetType(ModelObject symbol)
        {
            ModelContext ctx = ModelContext.Current;
            if (ctx != null)
            {
                return ctx.Compiler.TypeProvider.GetTypeOf(symbol);
            }
            else
            {
                return MetaBuiltInTypes.Error;
            }
        }

        private MetaType GetReturnType(ModelObject symbol)
        {
            ModelContext ctx = ModelContext.Current;
            if (ctx != null)
            {
                return ctx.Compiler.TypeProvider.GetReturnTypeOf(symbol);
            }
            else
            {
                return MetaBuiltInTypes.Error;
            }
        }


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
