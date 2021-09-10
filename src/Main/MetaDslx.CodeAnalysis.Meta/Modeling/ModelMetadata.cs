using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using System.Linq;
using MetaDslx.Modeling.Internal;

namespace MetaDslx.Modeling
{
    public class ModelMetadata : IModelMetadata
    {
        private readonly IModel _model;
        private readonly GreenMetadata _green;

        internal ModelMetadata(IModel model, GreenMetadata green)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));
            if (green == null) throw new ArgumentNullException(nameof(green));
            _model = model;
            _green = green;
        }

        private ModelMetadata Update(IModel model, GreenMetadata green)
        {
            if (!object.ReferenceEquals(_model, model) || _green != green)
            {
                return new ModelMetadata(model, green);
            }
            return this;
        }

        public IModelFactory CreateFactory(MutableModel model, ModelFactoryFlags flags = ModelFactoryFlags.None)
        {
            if (_green.FactoryConstructor != null) return _green.FactoryConstructor(model, flags);
            else throw new NotImplementedException($"No factory constructor is specified for the model {_model?.ToString()}.");
        }

        internal GreenMetadata Green => _green;
        public IModel Model => _model;
        public string Name => _green.Name;
        public ModelVersion Version => _green.Version;
        public string Uri => _green.Uri;
        public string Prefix => _green.Prefix;
        public ImmutableArray<string> NamespaceSegments => _green.NamespaceSegments;
        public string NamespaceName => _green.NamespaceName;
        public string FullName => _green.FullName;
        public string InstanceClassFullName => _green.InstanceClassFullName;
        public string InstanceModelFullName => _green.InstanceModelFullName;

        internal ModelMetadata WithModel(IModel model)
        {
            return this.Update(model, _green);
        }

        public ModelMetadata WithNamespace(string qualifiedNamespaceName)
        {
            var segments = qualifiedNamespaceName != null ? qualifiedNamespaceName.Split('.') : null;
            var namespaceSegments = segments != null ? ImmutableArray.Create(segments) : ImmutableArray<string>.Empty;
            return this.Update(_model, _green.WithNamespace(namespaceSegments));
        }

        public ModelMetadata WithNamespace(ImmutableArray<string> namespaceSegments)
        {
            return this.Update(_model, _green.WithNamespace(namespaceSegments));
        }

        public ModelMetadata WithName(string name)
        {
            return this.Update(_model, _green.WithName(name));
        }

        public ModelMetadata WithQualifiedName(string qualifiedName)
        {
            var segments = qualifiedName != null ? qualifiedName.Split('.') : null;
            if (segments == null || segments.Length == 0) return this.Update(_model, _green.WithName(null).WithNamespace(ImmutableArray<string>.Empty));
            var name = segments[segments.Length - 1];
            var namespaceSegments = segments.Length > 1 ? ImmutableArray.Create<string>(segments.Take(segments.Length-1).ToArray()) : ImmutableArray<string>.Empty;
            return this.Update(_model, _green.WithName(name).WithNamespace(namespaceSegments));
        }

        public ModelMetadata WithVersion(ModelVersion version)
        {
            return this.Update(_model, _green.WithVersion(version));
        }

        public ModelMetadata WithUri(string uri)
        {
            return this.Update(_model, _green.WithUri(uri));
        }

        public ModelMetadata WithPrefix(string prefix)
        {
            return this.Update(_model, _green.WithPrefix(prefix));
        }

        public ModelMetadata WithPrefixAndUri(string prefix, string uri)
        {
            return this.Update(_model, _green.WithPrefixAndUri(prefix, uri));
        }

        public ModelMetadata WithFactoryConstructor(Func<MutableModel, ModelFactoryFlags, IModelFactory> factoryConstructor)
        {
            return this.Update(_model, _green.WithFactoryConstructor(factoryConstructor));
        }
    }
}
