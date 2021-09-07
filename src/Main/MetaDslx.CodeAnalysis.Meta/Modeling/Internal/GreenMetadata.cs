using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.Modeling.Internal
{
    internal sealed class GreenMetadata
    {
        private readonly string _name;
        private readonly ModelVersion _version;
        private readonly string _uri;
        private readonly string _prefix;
        private readonly string _namespaceName;
        private readonly ImmutableArray<string> _namespaceSegments;
        private readonly Func<MutableModel, ModelFactoryFlags, IModelFactory> _factoryConstructor;

        internal GreenMetadata(ImmutableArray<string> namespaceSegments, string name, ModelVersion version, string uri, string prefix, Func<MutableModel,ModelFactoryFlags,IModelFactory> factoryConstructor)
        {
            _namespaceSegments = namespaceSegments;
            _namespaceName = string.Join(".", namespaceSegments);
            _name = name;
            _version = version;
            _uri = uri;
            _prefix = prefix;
            _factoryConstructor = factoryConstructor;
        }

        internal GreenMetadata(string namespaceName, string name, ModelVersion version, string uri, string prefix, Func<MutableModel, ModelFactoryFlags, IModelFactory> factoryConstructor)
        {
            _namespaceName = namespaceName;
            if (!string.IsNullOrEmpty(namespaceName))
            {
                var segments = namespaceName.Split('.');
                _namespaceSegments = ImmutableArray.Create(segments);
            }
            else
            {
                _namespaceSegments = ImmutableArray<string>.Empty;
            }
            _name = name;
            _version = version;
            _uri = uri;
            _prefix = prefix;
            _factoryConstructor = factoryConstructor;
        }

        protected GreenMetadata Update(ImmutableArray<string> namespaceSegments, string name, ModelVersion version, string uri, string prefix, Func<MutableModel, ModelFactoryFlags, IModelFactory> factoryConstructor)
        {
            if (_name != name || _version != version || _uri != uri || _prefix != prefix || _namespaceSegments != namespaceSegments || _factoryConstructor != factoryConstructor)
            {
                return new GreenMetadata(namespaceSegments, name, version, uri, prefix, factoryConstructor);
            }
            return this;
        }

        public string Name => _name;
        public ModelVersion Version => _version;
        public string Uri => _uri;
        public string Prefix => _prefix;
        public ImmutableArray<string> NamespaceSegments => _namespaceSegments;
        public string NamespaceName => _namespaceName;
        public string FullName => $"{_namespaceName}.{_name}";
        public string InstanceClassFullName => $"{_namespaceName}.{_name}Instance";
        public string InstanceModelFullName => $"{_namespaceName}.{_name}Instance.MModel";
        public Func<MutableModel, ModelFactoryFlags, IModelFactory> FactoryConstructor => _factoryConstructor;

        public GreenMetadata WithModel(IModel model)
        {
            return this.Update(_namespaceSegments, _name, _version, _uri, _prefix, _factoryConstructor);
        }

        public GreenMetadata WithNamespace(ImmutableArray<string> namespaceSegments)
        {
            return this.Update(namespaceSegments, _name, _version, _uri, _prefix, _factoryConstructor);
        }

        public GreenMetadata WithName(string name)
        {
            return this.Update(_namespaceSegments, name, _version, _uri, _prefix, _factoryConstructor);
        }

        public GreenMetadata WithVersion(ModelVersion version)
        {
            return this.Update(_namespaceSegments, _name, version, _uri, _prefix, _factoryConstructor);
        }

        public GreenMetadata WithUri(string uri)
        {
            return this.Update(_namespaceSegments, _name, _version, uri, _prefix, _factoryConstructor);
        }

        public GreenMetadata WithPrefix(string prefix)
        {
            return this.Update(_namespaceSegments, _name, _version, _uri, prefix, _factoryConstructor);
        }

        public GreenMetadata WithPrefixAndUri(string prefix, string uri)
        {
            return this.Update(_namespaceSegments, _name, _version, uri, prefix, _factoryConstructor);
        }

        public GreenMetadata WithFactoryConstructor(Func<MutableModel, ModelFactoryFlags, IModelFactory> factoryConstructor)
        {
            return this.Update(_namespaceSegments, _name, _version, _uri, _prefix, factoryConstructor);
        }
    }
}
