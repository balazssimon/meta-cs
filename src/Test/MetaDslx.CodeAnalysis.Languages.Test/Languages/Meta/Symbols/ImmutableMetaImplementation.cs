﻿using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MetaDslx.Modeling;

namespace MetaDslx.CodeAnalysis.Languages.Test.Languages.Meta.Symbols
{
    public static class MetaConstants
    {
        private static ImmutableList<IMetaSymbol> types = ImmutableList<IMetaSymbol>.Empty;

        public static ImmutableList<IMetaSymbol> Types
        {
            get
            {
                if (MetaConstants.types.Count == 0 && MetaXInstance.IsInitialized)
                {
                    ImmutableList<IMetaSymbol>.Builder typesBuilder = ImmutableList.CreateBuilder<IMetaSymbol>();
                    typesBuilder.Add(MetaXInstance.Object);
                    typesBuilder.Add(MetaXInstance.String);
                    typesBuilder.Add(MetaXInstance.Int);
                    typesBuilder.Add(MetaXInstance.Long);
                    typesBuilder.Add(MetaXInstance.Float);
                    typesBuilder.Add(MetaXInstance.Double);
                    typesBuilder.Add(MetaXInstance.Byte);
                    typesBuilder.Add(MetaXInstance.Bool);
                    typesBuilder.Add(MetaXInstance.Void);
                    typesBuilder.Add(MetaXInstance.ModelObject);
                    typesBuilder.Add(MetaXInstance.NameAttribute);
                    typesBuilder.Add(MetaXInstance.TypeAttribute);
                    typesBuilder.Add(MetaXInstance.ScopeAttribute);
                    typesBuilder.Add(MetaXInstance.BaseScopeAttribute);
                    typesBuilder.Add(MetaXInstance.LocalScopeAttribute);
                    Interlocked.Exchange(ref MetaConstants.types, typesBuilder.ToImmutable());
                }
                return MetaConstants.types;
            }
        }
    }
}
namespace MetaDslx.CodeAnalysis.Languages.Test.Languages.Meta.Symbols.Internal
{
    //*
    internal class MetaXImplementation : MetaXImplementationBase
    {
        internal override void MetaXBuilderInstance(Internal.MetaXBuilderInstance _this)
        {
            MetaXFactory f = new MetaXFactory(_this.Model);
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
            _this.ModelObject = f.MetaPrimitiveType();
            _this.ModelObject.Name = "symbol";
            _this.NameAttribute = f.MetaAttribute();
            _this.NameAttribute.Name = "NameAttribute";
            _this.TypeAttribute = f.MetaAttribute();
            _this.TypeAttribute.Name = "TypeAttribute";
            _this.ScopeAttribute = f.MetaAttribute();
            _this.ScopeAttribute.Name = "ScopeAttribute";
            _this.BaseScopeAttribute = f.MetaAttribute();
            _this.BaseScopeAttribute.Name = "BaseScopeAttribute";
            _this.LocalScopeAttribute = f.MetaAttribute();
            _this.LocalScopeAttribute.Name = "LocalScopeAttribute";
        }

        public override void MetaDeclaration(MetaDeclarationBuilder _this)
        {
            base.MetaDeclaration(_this);
            _this.MetaModelLazy = () => _this.Namespace?.DefinedMetaModel;
        }
        /*
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
        */
        public override ImmutableModelList<string> MetaDocumentedElement_GetDocumentationLines(MetaDocumentedElement _this)
        {
            if (_this.Documentation == null) return ImmutableModelList<string>.Empty;
            List<string> result = new List<string>();
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(_this.Documentation);
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
            return ImmutableModelList<string>.CreateNonUnique(result);
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
            result.Reverse();
            /*if (includeSelf) result.Add(_this);
            throw new NotImplementedException("TODO:MetaDslx");*/
            //result.AddRange(_this.MGetAllBases().Cast<MetaClass>());
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
            result.Reverse();
            int i = result.Count - 1;
            while (i >= 0)
            {
                string name = result[i].Name;
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
            result.Reverse();
            int i = result.Count - 1;
            while (i >= 0)
            {
                string name = result[i].Name;
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