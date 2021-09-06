using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Modeling
{
    public class ModelMetadata
    {
        private readonly string _name;
        private readonly ModelVersion _version;
        private readonly string _uri;
        private readonly string _prefix;
        private readonly string _namespaceName;

        public ModelMetadata(string name, ModelVersion version, string uri, string prefix, string namespaceName)
        {
            _name = name;
            _version = version;
            _uri = uri;
            _prefix = prefix;
            _namespaceName = namespaceName;
        }

        protected ModelMetadata Update(string name, ModelVersion version, string uri, string prefix, string namespaceName)
        {
            if (_name != name || _version != version || _uri != uri || _prefix != prefix || _namespaceName != namespaceName)
            {
                return Create(name, version, uri, prefix, namespaceName);
            }
            return this;
        }

        protected virtual ModelMetadata Create(string name, ModelVersion version, string uri, string prefix, string namespaceName)
        {
            return new ModelMetadata(name, version, uri, prefix, namespaceName);
        }

        public virtual IModelFactory CreateFactory(MutableModel model, ModelFactoryFlags flags = ModelFactoryFlags.None)
        {
            return new ModelFactory(model, flags);
        }

        public string Name => _name;
        public ModelVersion Version => _version;
        public string Uri => _uri;
        public string Prefix => _prefix;
        public string NamespaceName => _namespaceName;
        public string FullName => $"{_namespaceName}.{_name}";
        public string InstanceClassFullName => $"{_namespaceName}.{_name}Instance";
        public string InstanceModelFullName => $"{_namespaceName}.{_name}Instance.MModel";

        public ModelMetadata WithName(string name)
        {
            return this.Update(name, _version, _uri, _prefix, _namespaceName);
        }

        public ModelMetadata WithVersion(ModelVersion version)
        {
            return this.Update(_name, version, _uri, _prefix, _namespaceName);
        }

    }
}
