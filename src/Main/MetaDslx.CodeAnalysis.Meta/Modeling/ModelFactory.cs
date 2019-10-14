using MetaDslx.Languages.Meta.Model;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MetaDslx.Modeling
{
    public class ModelFactory : ModelFactoryBase
    {
        private readonly string _metaModelNamespace;
        private readonly Type _metaInstanceType;
        private readonly Assembly _metaModelAssembly;
        private readonly ConcurrentDictionary<string, ModelObjectDescriptor> _descriptors;

        public ModelFactory(MutableModel model, ModelFactoryFlags flags = ModelFactoryFlags.None)
            : base(model, flags)
        {
        }

        public ModelFactory(MutableModel model, Type metaInstanceType, ModelFactoryFlags flags = ModelFactoryFlags.None)
            : base(model, flags)
        {
            if (metaInstanceType == null) throw new ArgumentNullException(nameof(metaInstanceType));
            _metaInstanceType = metaInstanceType;
            _metaModelAssembly = _metaInstanceType.Assembly;
            _metaModelNamespace = metaInstanceType.Namespace + ".";
            _descriptors = new ConcurrentDictionary<string, ModelObjectDescriptor>();
        }

        public Type MetaInstanceType => _metaInstanceType;

        public override MutableObject Create(string type)
        {
            string fullTypeName = _metaModelNamespace + type;
            return this.CreateByFullTypeName(fullTypeName);
        }

        public override MutableObject Create(Type type)
        {
            return this.CreateByFullTypeName(type.FullName);
        }

        private MutableObject CreateByFullTypeName(string fullTypeName)
        {
            if (!_descriptors.TryGetValue(fullTypeName, out var result))
            {
                Type resolvedType = _metaModelAssembly.GetType(fullTypeName, false);
                if (resolvedType == null) throw new ModelException(ModelErrorCode.ERR_UnknownTypeName.ToDiagnosticWithNoLocation(fullTypeName));
                result = ModelObjectDescriptor.GetDescriptor(resolvedType);
                if (result == null) throw new ModelException(ModelErrorCode.ERR_UnknownTypeName.ToDiagnosticWithNoLocation(fullTypeName));
                _descriptors.TryAdd(fullTypeName, result);
            }
            return this.CreateObject(result.CreateObjectId());
        }
    }


}
