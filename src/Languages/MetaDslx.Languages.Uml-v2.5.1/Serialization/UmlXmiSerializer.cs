using MetaDslx.Languages.Uml.Model;
using MetaDslx.Modeling;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Languages.Uml.Serialization
{
    public class UmlXmiReadOptions : XmiReadOptions
    {
        public UmlXmiReadOptions()
        {
            this.NamespaceToMetadataMap.Add(UmlInstance.MMetadata.Uri, UmlInstance.MMetadata);
            this.UriToModelMap.Add(UmlInstance.MMetadata.Uri, UmlInstance.MModel);
        }

        public UmlXmiReadOptions(ModelMetadata metadata)
            : base(metadata)
        {
            this.NamespaceToMetadataMap.Add(UmlInstance.MMetadata.Uri, UmlInstance.MMetadata);
            this.UriToModelMap.Add(UmlInstance.MMetadata.Uri, UmlInstance.MModel);
        }
    }

    public class UmlXmiWriteOptions : XmiWriteOptions
    {
        public UmlXmiWriteOptions()
        {
            this.ModelToUriMap.Add(UmlInstance.MModel, UmlInstance.MMetadata.Uri);
        }
    }

    public class UmlXmiSerializer
    {
        private XmiSerializer _xmiSerializer = new XmiSerializer();

        public ImmutableModel ReadModel(string xmiCode, ModelMetadata metadata)
        {
            if (xmiCode == null) throw new ArgumentNullException(nameof(xmiCode));
            if (metadata == null) throw new ArgumentNullException(nameof(metadata));
            return _xmiSerializer.ReadModel(xmiCode, new UmlXmiReadOptions(metadata));
        }

        public ImmutableModel ReadModel(string xmiCode, UmlXmiReadOptions options = null)
        {
            if (xmiCode == null) throw new ArgumentNullException(nameof(xmiCode));
            return _xmiSerializer.ReadModel(xmiCode, options ?? new UmlXmiReadOptions());
        }

        public ImmutableModel ReadModelFromFile(string xmiFilePath, ModelMetadata metadata)
        {
            if (xmiFilePath == null) throw new ArgumentNullException(nameof(xmiFilePath));
            if (metadata == null) throw new ArgumentNullException(nameof(metadata));
            return _xmiSerializer.ReadModelFromFile(xmiFilePath, new UmlXmiReadOptions(metadata));
        }

        public ImmutableModel ReadModelFromFile(string xmiFilePath, UmlXmiReadOptions options = null)
        {
            if (xmiFilePath == null) throw new ArgumentNullException(nameof(xmiFilePath));
            return _xmiSerializer.ReadModelFromFile(xmiFilePath, options ?? new UmlXmiReadOptions());
        }

        public ImmutableModelGroup ReadModelGroup(string xmiCode, ModelMetadata metadata)
        {
            return this.ReadModel(xmiCode, metadata).ModelGroup;
        }

        public ImmutableModelGroup ReadModelGroup(string xmiCode, UmlXmiReadOptions options = null)
        {
            return this.ReadModel(xmiCode, options).ModelGroup;
        }

        public ImmutableModelGroup ReadModelGroupFromFile(string xmiFilePath, ModelMetadata metadata)
        {
            return this.ReadModelFromFile(xmiFilePath, metadata).ModelGroup;
        }

        public ImmutableModelGroup ReadModelGroupFromFile(string xmiFilePath, UmlXmiReadOptions options = null)
        {
            return this.ReadModelFromFile(xmiFilePath, options).ModelGroup;
        }

        public string WriteModel(IModel model, UmlXmiWriteOptions options = null)
        {
            return _xmiSerializer.WriteModel(model, options);
        }

        public void WriteModelToFile(string xmiFilePath, IModel model, UmlXmiWriteOptions options = null)
        {
            _xmiSerializer.WriteModelToFile(xmiFilePath, model, options ?? new UmlXmiWriteOptions());
        }

        public IReadOnlyDictionary<string, string> WriteModelGroup(IModelGroup modelGroup, UmlXmiWriteOptions options = null)
        {
            return _xmiSerializer.WriteModelGroup(modelGroup, options);
        }

        public void WriteModelGroupToFile(IModelGroup modelGroup, UmlXmiWriteOptions options)
        {
            _xmiSerializer.WriteModelGroupToFile(modelGroup, options);
        }
    }

}
