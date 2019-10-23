using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;

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
                    typesBuilder.Add(MetaInstance.NameAttribute);
                    typesBuilder.Add(MetaInstance.TypeAttribute);
                    typesBuilder.Add(MetaInstance.ScopeAttribute);
                    typesBuilder.Add(MetaInstance.BaseScopeAttribute);
                    typesBuilder.Add(MetaInstance.LocalScopeAttribute);
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
    internal class MetaImplementation : MetaImplementationBase
    {
        public override MetaModelBuilder MetaDeclaration_ComputeProperty_MetaModel(MetaDeclarationBuilder _this)
        {
            return _this.Namespace?.DefinedMetaModel;
        }

        public override string MetaDeclaration_ComputeProperty_FullName(MetaDeclarationBuilder _this)
        {
            return _this.Namespace != null ? _this.Namespace.FullName + "." + _this.Name : _this.Name;
        }

        public override IReadOnlyList<string> MetaDocumentedElement_GetDocumentationLines(MetaDocumentedElementBuilder _this)
        {
            if (_this.Documentation == null) return ImmutableList<string>.Empty;
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
            return result;
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
                string name = result[i].Name;
                MetaPropertyBuilder prop = result.First(p => p.Name == name);
                if (prop != result[i])
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
                string name = result[i].Name;
                MetaOperationBuilder op = result.First(o => o.Name == name);
                if (op != result[i])
                {
                    result.RemoveAt(i);
                }
                --i;
            }
            return result;
        }

    }
    //*/
}
