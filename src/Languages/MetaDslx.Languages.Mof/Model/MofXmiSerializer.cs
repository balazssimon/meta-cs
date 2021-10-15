using MetaDslx.Modeling;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Languages.Mof.Model
{
    public class MofXmiReadOptions : XmiReadOptions
    {
        public MofXmiReadOptions()
        {
            this.NamespaceToMetadataMap.Add(MofInstance.MMetadata.Uri, MofInstance.MMetadata);
            this.NamespaceToMetadataMap.Add("http://www.omg.org/spec/UML", MofInstance.MMetadata);
            this.UriToModelMap.Add(MofInstance.MMetadata.Uri, MofInstance.MModel);
        }

        public MofXmiReadOptions(ModelMetadata metadata)
            : base(metadata)
        {
            this.NamespaceToMetadataMap.Add(MofInstance.MMetadata.Uri, MofInstance.MMetadata);
            this.NamespaceToMetadataMap.Add("http://www.omg.org/spec/UML", MofInstance.MMetadata);
            this.UriToModelMap.Add(MofInstance.MMetadata.Uri, MofInstance.MModel);
        }
    }

    public class MofXmiWriteOptions : XmiWriteOptions
    {
        public MofXmiWriteOptions()
        {
            this.ModelToUriMap.Add(MofInstance.MModel, MofInstance.MMetadata.Uri);
        }
    }

    public class MofXmiSerializer
    {
        private XmiSerializer _xmiSerializer = new XmiSerializer();

        public ImmutableModel ReadModel(string xmiCode, ModelMetadata metadata)
        {
            if (xmiCode == null) throw new ArgumentNullException(nameof(xmiCode));
            if (metadata == null) throw new ArgumentNullException(nameof(metadata));
            return _xmiSerializer.ReadModel(xmiCode, new MofXmiReadOptions(metadata));
        }

        public ImmutableModel ReadModel(string xmiCode, MofXmiReadOptions options = null)
        {
            if (xmiCode == null) throw new ArgumentNullException(nameof(xmiCode));
            return _xmiSerializer.ReadModel(xmiCode, options ?? new MofXmiReadOptions());
        }

        public ImmutableModel ReadModelFromFile(string xmiFilePath, ModelMetadata metadata)
        {
            if (xmiFilePath == null) throw new ArgumentNullException(nameof(xmiFilePath));
            if (metadata == null) throw new ArgumentNullException(nameof(metadata));
            return _xmiSerializer.ReadModelFromFile(xmiFilePath, new MofXmiReadOptions(metadata));
        }

        public ImmutableModel ReadModelFromFile(string xmiFilePath, MofXmiReadOptions? options = null)
        {
            if (xmiFilePath == null) throw new ArgumentNullException(nameof(xmiFilePath));
            return _xmiSerializer.ReadModelFromFile(xmiFilePath, options ?? new MofXmiReadOptions());
        }

        public ImmutableModelGroup ReadModelGroup(string xmiCode, ModelMetadata metadata)
        {
            return this.ReadModel(xmiCode, metadata).ModelGroup;
        }

        public ImmutableModelGroup ReadModelGroup(string xmiCode, MofXmiReadOptions? options = null)
        {
            return this.ReadModel(xmiCode, options).ModelGroup;
        }

        public ImmutableModelGroup ReadModelGroupFromFile(string xmiFilePath, ModelMetadata metadata)
        {
            return this.ReadModelFromFile(xmiFilePath, metadata).ModelGroup;
        }

        public ImmutableModelGroup ReadModelGroupFromFile(string xmiFilePath, MofXmiReadOptions? options = null)
        {
            return this.ReadModelFromFile(xmiFilePath, options).ModelGroup;
        }

        public string WriteModel(IModel model, MofXmiWriteOptions? options = null)
        {
            return _xmiSerializer.WriteModel(model, options);
        }

        public void WriteModelToFile(string xmiFilePath, IModel model, MofXmiWriteOptions? options = null)
        {
            _xmiSerializer.WriteModelToFile(xmiFilePath, model, options ?? new MofXmiWriteOptions());
        }

        public IReadOnlyDictionary<string, string> WriteModelGroup(IModelGroup modelGroup, MofXmiWriteOptions? options = null)
        {
            return _xmiSerializer.WriteModelGroup(modelGroup, options);
        }

        public void WriteModelGroupToFile(IModelGroup modelGroup, MofXmiWriteOptions options)
        {
            _xmiSerializer.WriteModelGroupToFile(modelGroup, options);
        }
    }

}
