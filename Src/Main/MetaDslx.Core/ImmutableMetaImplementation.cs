﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Core.Immutable
{
    //*
    internal class MetaImplementation : MetaImplementationBase
    {
        public override void MetaBuilderInstance(MetaBuilderInstance _this)
        {
            MetaFactory f = new Immutable.MetaFactory(_this.Model);
            _this.Object = f.MetaPrimitiveType();
            _this.Object.Name = "object";
            _this.String = f.MetaPrimitiveType();
            _this.String.Name = "string";
            _this.Int = f.MetaPrimitiveType();
            _this.Int.Name = "int";
            _this.Long = f.MetaPrimitiveType();
            _this.Long.Name = "long";
            _this.Float = f.MetaPrimitiveType();
            _this.Float.Name = "float";
            _this.Double = f.MetaPrimitiveType();
            _this.Double.Name = "double";
            _this.Byte = f.MetaPrimitiveType();
            _this.Byte.Name = "byte";
            _this.Bool = f.MetaPrimitiveType();
            _this.Bool.Name = "bool";
            _this.Void = f.MetaPrimitiveType();
            _this.Void.Name = "void";
        }

        public override void MetaDeclaration(MetaDeclarationBuilder _this)
        {
            base.MetaDeclaration(_this);
            _this.MetaModelLazy = () => _this.Namespace.MetaModel;
        }

        public override void MetaFunction(MetaFunctionBuilder _this)
        {
            base.MetaFunction(_this);
            _this.TypeLazy = () =>
                {
                    MetaFactory f = new MetaFactory(_this.MModel, ModelFactoryFlags.CreateWeakSymbols);
                    MetaFunctionTypeBuilder ft = f.MetaFunctionType();
                    foreach (var param in _this.Parameters)
                    {
                        ft.ParameterTypes.Add(param.Type);
                    }
                    ft.ReturnType = _this.ReturnType;
                    return ft;
                };
        }

        public override ImmutableModelList<MetaClass> MetaClass_GetAllSuperClasses(MetaClass _this, bool includeSelf)
        {
            List<MetaClass> result = new List<MetaClass>();
            result.Add(_this);
            int i = 0;
            while(i < result.Count)
            {
                MetaClass current = result[i];
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
            return ImmutableModelList<MetaClass>.CreateUnique(result);
        }

        public override ImmutableModelList<MetaProperty> MetaClass_GetAllSuperProperties(MetaClass _this, bool includeSelf)
        {
            List<MetaProperty> result = new List<MetaProperty>();
            ImmutableModelList<MetaClass> supers = _this.GetAllSuperClasses(includeSelf);
            foreach (var sup in supers)
            {
                foreach (var prop in sup.Properties)
                {
                    result.Add(prop);
                }
            }
            return ImmutableModelList<MetaProperty>.CreateUnique(result);
        }

        public override ImmutableModelList<MetaOperation> MetaClass_GetAllSuperOperations(MetaClass _this, bool includeSelf)
        {
            List<MetaOperation> result = new List<MetaOperation>();
            ImmutableModelList<MetaClass> supers = _this.GetAllSuperClasses(includeSelf);
            foreach (var sup in supers)
            {
                foreach (var op in sup.Operations)
                {
                    result.Add(op);
                }
            }
            return ImmutableModelList<MetaOperation>.CreateUnique(result);
        }

        public override ImmutableModelList<MetaProperty> MetaClass_GetAllProperties(MetaClass _this)
        {
            return _this.GetAllSuperProperties(true);
        }

        public override ImmutableModelList<MetaOperation> MetaClass_GetAllOperations(MetaClass _this)
        {
            return _this.GetAllSuperOperations(true);
        }

        public override ImmutableModelList<MetaProperty> MetaClass_GetAllFinalProperties(MetaClass _this)
        {
            ImmutableModelList<MetaProperty> props = _this.GetAllProperties();
            List<MetaProperty> result = new List<MetaProperty>(props);
            int i = result.Count - 1;
            while (i >= 0)
            {
                string name = props[i].Name;
                MetaProperty prop = result.First(p => p.Name == name);
                if (prop != result[i])
                {
                    result.RemoveAt(i);
                }
                --i;
            }
            return ImmutableModelList<MetaProperty>.CreateUnique(result);
        }

        public override ImmutableModelList<MetaOperation> MetaClass_GetAllFinalOperations(MetaClass _this)
        {
            ImmutableModelList<MetaOperation> ops = _this.GetAllOperations();
            List<MetaOperation> result = new List<MetaOperation>(ops);
            int i = result.Count - 1;
            while (i >= 0)
            {
                string name = ops[i].Name;
                MetaOperation op = result.First(o => o.Name == name);
                if (op != result[i])
                {
                    result.RemoveAt(i);
                }
                --i;
            }
            return ImmutableModelList<MetaOperation>.CreateUnique(result);
        }
    }
    //*/
}
