using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MetaDslx.Modeling;
using MetaDslx.CodeAnalysis;

namespace MetaDslx.Languages.Meta.Model
{
    public static class MetaConstants
    {
        private static ImmutableList<IModelObject> types = ImmutableList<IModelObject>.Empty;

        public static ImmutableList<IModelObject> Types
        {
            get
            {
                if (MetaConstants.types.Count == 0 && MetaInstance.IsInitialized)
                {
                    ImmutableList<IModelObject>.Builder typesBuilder = ImmutableList.CreateBuilder<IModelObject>();
                    typesBuilder.Add(MetaInstance.Object);
                    typesBuilder.Add(MetaInstance.String);
                    typesBuilder.Add(MetaInstance.Int);
                    typesBuilder.Add(MetaInstance.Long);
                    typesBuilder.Add(MetaInstance.Float);
                    typesBuilder.Add(MetaInstance.Double);
                    typesBuilder.Add(MetaInstance.Byte);
                    typesBuilder.Add(MetaInstance.Bool);
                    typesBuilder.Add(MetaInstance.Void);
                    typesBuilder.Add(MetaInstance.ModelObject);
                    Interlocked.Exchange(ref MetaConstants.types, typesBuilder.ToImmutable());
                }
                return MetaConstants.types;
            }
        }
    }
}
namespace MetaDslx.Languages.Meta.Model.Internal
{
    //*
    public class MetaImplementation : MetaImplementationBase
    {
        internal override void MetaBuilderInstance(MetaBuilderInstance _this)
        {
            base.MetaBuilderInstance(_this);
            _this.Object.DotNetName = "System.Object";
            _this.String.DotNetName = "System.String";
            _this.Int.DotNetName = "System.Int32";
            _this.Long.DotNetName = "System.Int64";
            _this.Float.DotNetName = "System.Single";
            _this.Double.DotNetName = "System.Double";
            _this.Byte.DotNetName = "System.Byte";
            _this.Bool.DotNetName = "System.Boolean";
            _this.Void.DotNetName = "System.Void";
            _this.SystemType.DotNetName = "System.Type";
            _this.Model.DotNetName = "MetaDslx.Modeling.IModel";
            _this.ModelObject.DotNetName = "MetaDslx.Modeling.IModelObject";
        }

        public override MetaModelBuilder MetaDeclaration_ComputeProperty_MetaModel(MetaDeclarationBuilder _this)
        {
            return _this.Namespace?.DefinedMetaModel;
        }

        public override string MetaDeclaration_ComputeProperty_FullName(MetaDeclarationBuilder _this)
        {
            return _this.Namespace != null ? _this.Namespace.FullName + "." + _this.Name : _this.Name;
        }

        public override IReadOnlyList<MetaClassBuilder> MetaClass_GetAllSuperClasses(MetaClassBuilder _this, bool includeSelf)
        {
            var result = new List<MetaClassBuilder>();
            result.Add(_this);
            int i = 0;
            while (i < result.Count)
            {
                MetaClassBuilder current = result[i];
                foreach (var sup in current.SuperClasses)
                {
                    if (!result.Contains(sup))
                    {
                        result.Add(sup);
                    }
                }
                ++i;
            }
            if (!includeSelf) result.RemoveAt(0);
            result.Reverse();
            return result;
        }

        public override IReadOnlyList<MetaPropertyBuilder> MetaClass_GetAllSuperProperties(MetaClassBuilder _this, bool includeSelf)
        {
            var result = new List<MetaPropertyBuilder>();
            var supers = _this.GetAllSuperClasses(includeSelf);
            foreach (var sup in supers)
            {
                foreach (var prop in sup.Properties)
                {
                    result.Add(prop);
                }
            }
            return result;
        }

        public override IReadOnlyList<MetaOperationBuilder> MetaClass_GetAllSuperOperations(MetaClassBuilder _this, bool includeSelf)
        {
            var result = new List<MetaOperationBuilder>();
            var supers = _this.GetAllSuperClasses(includeSelf);
            foreach (var sup in supers)
            {
                foreach (var op in sup.Operations)
                {
                    result.Add(op);
                }
            }
            return result;
        }

        public override IReadOnlyList<MetaPropertyBuilder> MetaClass_GetAllProperties(MetaClassBuilder _this)
        {
            return _this.GetAllSuperProperties(true);
        }

        public override IReadOnlyList<MetaOperationBuilder> MetaClass_GetAllOperations(MetaClassBuilder _this)
        {
            return _this.GetAllSuperOperations(true);
        }

        public override IReadOnlyList<MetaPropertyBuilder> MetaClass_GetAllFinalProperties(MetaClassBuilder _this)
        {
            var props = _this.GetAllProperties();
            var result = new List<MetaPropertyBuilder>(props);
            result.Reverse();
            int i = result.Count - 1;
            while (i >= 0)
            {
                var currentProp = result[i];
                MetaPropertyBuilder prop = result.First(p => p.Name == currentProp.Name);
                if (prop != currentProp)
                {
                    result.RemoveAt(i);
                }
                --i;
            }
            return result;
        }

        public override IReadOnlyList<MetaOperationBuilder> MetaClass_GetAllFinalOperations(MetaClassBuilder _this)
        {
            var ops = _this.GetAllOperations();
            var result = new List<MetaOperationBuilder>(ops);
            result.Reverse();
            int i = result.Count - 1;
            while (i >= 0)
            {
                var currentOp = result[i];
                MetaOperationBuilder op = result.FirstOrDefault(o => o.ConformsTo(currentOp));
                if (op != null && op != currentOp)
                {
                    result.RemoveAt(i);
                }
                --i;
            }
            return result;
        }

        public override bool MetaType_ConformsTo(MetaTypeBuilder _this, MetaTypeBuilder type)
        {
            return type != null && _this == type;
        }

        public override bool MetaCollectionType_ConformsTo(MetaCollectionTypeBuilder _this, MetaTypeBuilder type)
        {
            return type is MetaCollectionTypeBuilder typeBuilder && _this.InnerType != null && _this.InnerType.ConformsTo(typeBuilder.InnerType);
        }

        public override bool MetaNullableType_ConformsTo(MetaNullableTypeBuilder _this, MetaTypeBuilder type)
        {
            return type is MetaNullableTypeBuilder typeBuilder && _this.InnerType != null && _this.InnerType.ConformsTo(typeBuilder.InnerType);
        }

        public override bool MetaPrimitiveType_ConformsTo(MetaPrimitiveTypeBuilder _this, MetaTypeBuilder type)
        {
            if (type == null) return false;
            if (_this == type) return true;
            if (type == MetaInstance.Object) return true;
            if (type is MetaNullableTypeBuilder nullableTypeBuilder && _this.ConformsTo(nullableTypeBuilder.InnerType)) return true;
            if (_this == MetaInstance.Byte && (type == MetaInstance.Int || type == MetaInstance.Long || type == MetaInstance.Float || type == MetaInstance.Double)) return true;
            if (_this == MetaInstance.Int && (type == MetaInstance.Long || type == MetaInstance.Float || type == MetaInstance.Double)) return true;
            if (_this == MetaInstance.Long && (type == MetaInstance.Float || type == MetaInstance.Double)) return true;
            if (_this == MetaInstance.Float && (type == MetaInstance.Double)) return true;
            return false;
        }

        public override bool MetaClass_ConformsTo(MetaClassBuilder _this, MetaTypeBuilder type)
        {
            return type is MetaClassBuilder superClass && _this.GetAllSuperClasses(true).Contains(superClass);
        }

        public override bool MetaOperation_ConformsTo(MetaOperationBuilder _this, MetaOperationBuilder operation)
        {
            if (operation == null) return false;
            if (_this.Name != operation.Name) return false;
            if (_this.Parameters.Count != operation.Parameters.Count) return false;
            if (_this.Class != null && !_this.Class.ConformsTo(operation.Class)) return false;
            if (_this.Enum != null && !_this.Enum.ConformsTo(operation.Enum)) return false;
            var thisReturnType = GetMetaType(_this.Result);
            var otherReturnType = GetMetaType(operation.Result);
            if (thisReturnType == null && otherReturnType != null) return false;
            if (thisReturnType != null && otherReturnType == null) return false;
            if (thisReturnType != null && !thisReturnType.ConformsTo(otherReturnType)) return false;
            for (int i = 0; i < _this.Parameters.Count; i++)
            {
                var thisParam = _this.Parameters[i];
                var otherParam = operation.Parameters[i];
                var thisType = GetMetaType(thisParam);
                var otherType = GetMetaType(otherParam);
                if (thisType == null || otherType == null || !otherType.ConformsTo(thisType)) return false;
            }
            return true;
        }

        public override bool MetaProperty_ConformsTo(MetaPropertyBuilder _this, MetaPropertyBuilder property)
        {
            if (property == null) return false;
            if (_this.Name != property.Name) return false;
            if (!_this.Class.ConformsTo(property.Class)) return false;
            if (_this.IsContainment && !property.IsContainment) return false;
            var thisType = GetMetaType(_this);
            var otherType = GetMetaType(property);
            if (!thisType.ConformsTo(otherType) && !otherType.ConformsTo(thisType)) return false;
            if (thisType is MetaCollectionTypeBuilder && !(otherType is MetaCollectionTypeBuilder)) return false;
            return true;
        }

        public static MetaTypeBuilder GetMetaType(MetaTypedElementBuilder mtypedElement)
        {
            var type = mtypedElement.MGet(MetaDescriptor.MetaTypedElement.TypeProperty);
            if (type is MetaTypeBuilder mtype) return mtype;
            if (type is MetaConstantBuilder mconst) return GetMetaConstantType(mconst.Name)?.ToMutable();
            return null;
        }

        public static MetaType GetMetaType(MetaTypedElement mtypedElement)
        {
            var type = mtypedElement.MGet(MetaDescriptor.MetaTypedElement.TypeProperty);
            if (type is MetaType mtype) return mtype;
            if (type is MetaConstant mconst) return GetMetaConstantType(mconst.Name);
            return null;
        }

        private static MetaType GetMetaConstantType(string mconst)
        {
            switch (mconst)
            {
                case "Object":
                case "EJavaObject":
                case "EEnumerator":
                    return MetaInstance.Object;
                case "String":
                case "EString":
                    return MetaInstance.String;
                case "Int":
                case "EInt":
                    return MetaInstance.Int;
                case "Long":
                case "ELong":
                    return MetaInstance.Long;
                case "Float":
                case "EFloat":
                    return MetaInstance.Float;
                case "Double":
                case "EDouble":
                    return MetaInstance.Double;
                case "Byte":
                case "EByte":
                    return MetaInstance.Byte;
                case "Bool":
                case "EBoolean":
                    return MetaInstance.Bool;
                case "Void": 
                    return MetaInstance.Void;
                case "SystemType":
                case "EJavaClass":
                    return MetaInstance.SystemType;
                case "Model":
                case "EResource":
                    return MetaInstance.Model;
                case "ModelObject": 
                    return MetaInstance.ModelObject;
                default: return null;
            }
        }
    }
    //*/
}
