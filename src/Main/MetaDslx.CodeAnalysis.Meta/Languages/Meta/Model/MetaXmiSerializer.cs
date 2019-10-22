using MetaDslx.Modeling;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Languages.Meta.Model
{
    public class MetaXmiReadOptions : XmiReadOptions
    {
        public MetaXmiReadOptions()
        {
            this.NamespaceToMetamodelMap.Add(MetaInstance.MMetaModel.Uri, MetaInstance.MMetaModel);
            this.UriToModelMap.Add(MetaInstance.MMetaModel.Uri, MetaInstance.MModel);
        }

        public MetaXmiReadOptions(IMetaModel metaModel)
            : base(metaModel)
        {
            this.NamespaceToMetamodelMap.Add(MetaInstance.MMetaModel.Uri, MetaInstance.MMetaModel);
            this.UriToModelMap.Add(MetaInstance.MMetaModel.Uri, MetaInstance.MModel);
        }
    }

    public class MetaXmiWriteOptions : XmiWriteOptions
    {
        public MetaXmiWriteOptions()
        {
            this.ModelToUriMap.Add(MetaInstance.MModel, MetaInstance.MMetaModel.Uri);
        }
    }

    public class MetaXmiSerializer
    {
        private XmiSerializer _xmiSerializer = new XmiSerializer();

        public ImmutableModel ReadModel(string xmiCode, IMetaModel metaModel)
        {
            if (xmiCode == null) throw new ArgumentNullException(nameof(xmiCode));
            if (metaModel == null) throw new ArgumentNullException(nameof(metaModel));
            return _xmiSerializer.ReadModel(xmiCode, new MetaXmiReadOptions(metaModel));
        }

        public ImmutableModel ReadModel(string xmiCode, MetaXmiReadOptions options = null)
        {
            if (xmiCode == null) throw new ArgumentNullException(nameof(xmiCode));
            return _xmiSerializer.ReadModel(xmiCode, options ?? new MetaXmiReadOptions());
        }

        public ImmutableModel ReadModelFromFile(string xmiFilePath, IMetaModel metaModel)
        {
            if (xmiFilePath == null) throw new ArgumentNullException(nameof(xmiFilePath));
            if (metaModel == null) throw new ArgumentNullException(nameof(metaModel));
            return _xmiSerializer.ReadModelFromFile(xmiFilePath, new MetaXmiReadOptions(metaModel));
        }

        public ImmutableModel ReadModelFromFile(string xmiFilePath, MetaXmiReadOptions options = null)
        {
            if (xmiFilePath == null) throw new ArgumentNullException(nameof(xmiFilePath));
            return _xmiSerializer.ReadModelFromFile(xmiFilePath, options ?? new MetaXmiReadOptions());
        }

        public ImmutableModelGroup ReadModelGroup(string xmiCode, IMetaModel metaModel)
        {
            return this.ReadModel(xmiCode, metaModel).ModelGroup;
        }

        public ImmutableModelGroup ReadModelGroup(string xmiCode, MetaXmiReadOptions options = null)
        {
            return this.ReadModel(xmiCode, options).ModelGroup;
        }

        public ImmutableModelGroup ReadModelGroupFromFile(string xmiFilePath, IMetaModel metaModel)
        {
            return this.ReadModelFromFile(xmiFilePath, metaModel).ModelGroup;
        }

        public ImmutableModelGroup ReadModelGroupFromFile(string xmiFilePath, MetaXmiReadOptions options = null)
        {
            return this.ReadModelFromFile(xmiFilePath, options).ModelGroup;
        }

        public string WriteModel(IModel model, MetaXmiWriteOptions options = null)
        {
            return _xmiSerializer.WriteModel(model, options);
        }

        public void WriteModelToFile(string xmiFilePath, IModel model, MetaXmiWriteOptions options = null)
        {
            _xmiSerializer.WriteModelToFile(xmiFilePath, model, options ?? new MetaXmiWriteOptions());
        }

        public IReadOnlyDictionary<string, string> WriteModelGroup(IModelGroup modelGroup, MetaXmiWriteOptions options = null)
        {
            return _xmiSerializer.WriteModelGroup(modelGroup, options);
        }

        public void WriteModelGroupToFile(IModelGroup modelGroup, MetaXmiWriteOptions options)
        {
            _xmiSerializer.WriteModelGroupToFile(modelGroup, options);
        }
    }
}
