using MetaDslx.Languages.Ecore.Model;
using MetaDslx.Languages.Meta.Model;
using MetaDslx.Modeling;
using MetaDslx.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace MetaDslx.Languages.Ecore
{
    public class EcoreXmiReadOptions : XmiReadOptions
    {
        public EcoreXmiReadOptions()
        {
            this.RequireXmiRoot = false;
            this.XmiNamespaces.Add("http://www.omg.org/XMI");
            this.NamespaceToMetamodelMap.Add(EcoreInstance.MMetaModel.Uri, EcoreInstance.MMetaModel);
            this.UriToModelMap.Add(EcoreInstance.MMetaModel.Uri, EcoreInstance.MModel);
        }

        public EcoreXmiReadOptions(IMetaModel metaModel)
            : base(metaModel)
        {
            this.RequireXmiRoot = false;
            this.XmiNamespaces.Add("http://www.omg.org/XMI");
            this.NamespaceToMetamodelMap.Add(EcoreInstance.MMetaModel.Uri, EcoreInstance.MMetaModel);
            this.UriToModelMap.Add(EcoreInstance.MMetaModel.Uri, EcoreInstance.MModel);
        }
    }

    public class EcoreXmiWriteOptions : XmiWriteOptions
    {
        public EcoreXmiWriteOptions()
        {
            this.RequireXmiRoot = false;
            this.PreferReferenceByName = true;
            this.XmiNamespace = "http://www.omg.org/XMI";
            this.ModelToUriMap.Add(EcoreInstance.MModel, EcoreInstance.MMetaModel.Uri);
        }
    }

    public class EcoreXmiSerializer
    {
        private XmiSerializer _xmiSerializer = new XmiSerializer();

        public ImmutableModel ReadModel(string xmiCode, IMetaModel metaModel)
        {
            if (xmiCode == null) throw new ArgumentNullException(nameof(xmiCode));
            if (metaModel == null) throw new ArgumentNullException(nameof(metaModel));
            return _xmiSerializer.ReadModel(xmiCode, new EcoreXmiReadOptions(metaModel));
        }

        public ImmutableModel ReadModel(string xmiCode, EcoreXmiReadOptions options = null)
        {
            if (xmiCode == null) throw new ArgumentNullException(nameof(xmiCode));
            return _xmiSerializer.ReadModel(xmiCode, options ?? new EcoreXmiReadOptions());
        }

        public ImmutableModel ReadModelFromFile(string xmiFilePath, IMetaModel metaModel)
        {
            if (xmiFilePath == null) throw new ArgumentNullException(nameof(xmiFilePath));
            if (metaModel == null) throw new ArgumentNullException(nameof(metaModel));
            return _xmiSerializer.ReadModelFromFile(xmiFilePath, new EcoreXmiReadOptions(metaModel));
        }

        public ImmutableModel ReadModelFromFile(string xmiFilePath, EcoreXmiReadOptions options = null)
        {
            if (xmiFilePath == null) throw new ArgumentNullException(nameof(xmiFilePath));
            return _xmiSerializer.ReadModelFromFile(xmiFilePath, options ?? new EcoreXmiReadOptions());
        }

        public ImmutableModelGroup ReadModelGroup(string xmiCode, IMetaModel metaModel)
        {
            return this.ReadModel(xmiCode, metaModel).ModelGroup;
        }

        public ImmutableModelGroup ReadModelGroup(string xmiCode, EcoreXmiReadOptions options = null)
        {
            return this.ReadModel(xmiCode, options).ModelGroup;
        }

        public ImmutableModelGroup ReadModelGroupFromFile(string xmiFilePath, IMetaModel metaModel)
        {
            return this.ReadModelFromFile(xmiFilePath, metaModel).ModelGroup;
        }

        public ImmutableModelGroup ReadModelGroupFromFile(string xmiFilePath, EcoreXmiReadOptions options = null)
        {
            return this.ReadModelFromFile(xmiFilePath, options).ModelGroup;
        }

        public string WriteModel(IModel model, EcoreXmiWriteOptions options = null)
        {
            return _xmiSerializer.WriteModel(model, options);
        }

        public void WriteModelToFile(string xmiFilePath, IModel model, EcoreXmiWriteOptions options = null)
        {
            _xmiSerializer.WriteModelToFile(xmiFilePath, model, options ?? new EcoreXmiWriteOptions());
        }

        public IReadOnlyDictionary<string, string> WriteModelGroup(IModelGroup modelGroup, EcoreXmiWriteOptions options = null)
        {
            return _xmiSerializer.WriteModelGroup(modelGroup, options);
        }

        public void WriteModelGroupToFile(IModelGroup modelGroup, EcoreXmiWriteOptions options)
        {
            _xmiSerializer.WriteModelGroupToFile(modelGroup, options);
        }
    }

}
