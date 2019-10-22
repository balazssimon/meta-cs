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
            this.NamespaceToMetamodelMap.Add(MofInstance.MMetaModel.Uri, MofInstance.MMetaModel);
            this.NamespaceToMetamodelMap.Add("http://www.omg.org/spec/UML", MofInstance.MMetaModel);
            this.UriToModelMap.Add(MofInstance.MMetaModel.Uri, MofInstance.MModel);
        }

        public MofXmiReadOptions(IMetaModel metaModel)
            : base(metaModel)
        {
            this.NamespaceToMetamodelMap.Add(MofInstance.MMetaModel.Uri, MofInstance.MMetaModel);
            this.NamespaceToMetamodelMap.Add("http://www.omg.org/spec/UML", MofInstance.MMetaModel);
            this.UriToModelMap.Add(MofInstance.MMetaModel.Uri, MofInstance.MModel);
        }
    }

    public class MofXmiWriteOptions : XmiWriteOptions
    {
        public MofXmiWriteOptions()
        {
            this.ModelToUriMap.Add(MofInstance.MModel, MofInstance.MMetaModel.Uri);
        }
    }

    public class MofXmiSerializer
    {
        private XmiSerializer _xmiSerializer = new XmiSerializer();

        public ImmutableModel ReadModel(string xmiCode, IMetaModel metaModel)
        {
            if (xmiCode == null) throw new ArgumentNullException(nameof(xmiCode));
            if (metaModel == null) throw new ArgumentNullException(nameof(metaModel));
            return _xmiSerializer.ReadModel(xmiCode, new MofXmiReadOptions(metaModel));
        }

        public ImmutableModel ReadModel(string xmiCode, MofXmiReadOptions options = null)
        {
            if (xmiCode == null) throw new ArgumentNullException(nameof(xmiCode));
            return _xmiSerializer.ReadModel(xmiCode, options ?? new MofXmiReadOptions());
        }

        public ImmutableModel ReadModelFromFile(string xmiFilePath, IMetaModel metaModel)
        {
            if (xmiFilePath == null) throw new ArgumentNullException(nameof(xmiFilePath));
            if (metaModel == null) throw new ArgumentNullException(nameof(metaModel));
            return _xmiSerializer.ReadModelFromFile(xmiFilePath, new MofXmiReadOptions(metaModel));
        }

        public ImmutableModel ReadModelFromFile(string xmiFilePath, MofXmiReadOptions options = null)
        {
            if (xmiFilePath == null) throw new ArgumentNullException(nameof(xmiFilePath));
            return _xmiSerializer.ReadModelFromFile(xmiFilePath, options ?? new MofXmiReadOptions());
        }

        public ImmutableModelGroup ReadModelGroup(string xmiCode, IMetaModel metaModel)
        {
            return this.ReadModel(xmiCode, metaModel).ModelGroup;
        }

        public ImmutableModelGroup ReadModelGroup(string xmiCode, MofXmiReadOptions options = null)
        {
            return this.ReadModel(xmiCode, options).ModelGroup;
        }

        public ImmutableModelGroup ReadModelGroupFromFile(string xmiFilePath, IMetaModel metaModel)
        {
            return this.ReadModelFromFile(xmiFilePath, metaModel).ModelGroup;
        }

        public ImmutableModelGroup ReadModelGroupFromFile(string xmiFilePath, MofXmiReadOptions options = null)
        {
            return this.ReadModelFromFile(xmiFilePath, options).ModelGroup;
        }

        public string WriteModel(IModel model, MofXmiWriteOptions options = null)
        {
            return _xmiSerializer.WriteModel(model, options);
        }

        public void WriteModelToFile(string xmiFilePath, IModel model, MofXmiWriteOptions options = null)
        {
            _xmiSerializer.WriteModelToFile(xmiFilePath, model, options ?? new MofXmiWriteOptions());
        }

        public IReadOnlyDictionary<string, string> WriteModelGroup(IModelGroup modelGroup, MofXmiWriteOptions options = null)
        {
            return _xmiSerializer.WriteModelGroup(modelGroup, options);
        }

        public void WriteModelGroupToFile(IModelGroup modelGroup, MofXmiWriteOptions options)
        {
            _xmiSerializer.WriteModelGroupToFile(modelGroup, options);
        }
    }

}
