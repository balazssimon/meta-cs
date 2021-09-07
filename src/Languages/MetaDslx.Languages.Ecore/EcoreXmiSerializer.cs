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
            this.NamespaceToMetadataMap.Add(EcoreInstance.MMetadata.Uri, EcoreInstance.MMetadata);
            this.UriToModelMap.Add(EcoreInstance.MMetadata.Uri, EcoreInstance.MModel);
        }

        public EcoreXmiReadOptions(ModelMetadata metadata)
            : base(metadata)
        {
            this.RequireXmiRoot = false;
            this.XmiNamespaces.Add("http://www.omg.org/XMI");
            this.NamespaceToMetadataMap.Add(EcoreInstance.MMetadata.Uri, EcoreInstance.MMetadata);
            this.UriToModelMap.Add(EcoreInstance.MMetadata.Uri, EcoreInstance.MModel);
        }
    }

    public class EcoreXmiWriteOptions : XmiWriteOptions
    {
        public EcoreXmiWriteOptions()
        {
            this.RequireXmiRoot = false;
            this.PreferReferenceByName = true;
            this.XmiNamespace = "http://www.omg.org/XMI";
            this.ModelToUriMap.Add(EcoreInstance.MModel, EcoreInstance.MMetadata.Uri);
        }
    }

    public class EcoreXmiSerializer
    {
        private XmiSerializer _xmiSerializer = new XmiSerializer();

        public ImmutableModel ReadModel(string xmiCode, ModelMetadata metadata)
        {
            if (xmiCode == null) throw new ArgumentNullException(nameof(xmiCode));
            if (metadata.Model == null) throw new ArgumentNullException(nameof(metadata));
            return _xmiSerializer.ReadModel(xmiCode, new EcoreXmiReadOptions(metadata));
        }

        public ImmutableModel ReadModel(string xmiCode, EcoreXmiReadOptions options = null)
        {
            if (xmiCode == null) throw new ArgumentNullException(nameof(xmiCode));
            return _xmiSerializer.ReadModel(xmiCode, options ?? new EcoreXmiReadOptions());
        }

        public ImmutableModel ReadModelFromFile(string xmiFilePath, ModelMetadata metadata)
        {
            if (xmiFilePath == null) throw new ArgumentNullException(nameof(xmiFilePath));
            if (metadata.Model == null) throw new ArgumentNullException(nameof(metadata));
            return _xmiSerializer.ReadModelFromFile(xmiFilePath, new EcoreXmiReadOptions(metadata));
        }

        public ImmutableModel ReadModelFromFile(string xmiFilePath, EcoreXmiReadOptions options = null)
        {
            if (xmiFilePath == null) throw new ArgumentNullException(nameof(xmiFilePath));
            return _xmiSerializer.ReadModelFromFile(xmiFilePath, options ?? new EcoreXmiReadOptions());
        }

        public ImmutableModelGroup ReadModelGroup(string xmiCode, ModelMetadata metadata)
        {
            return this.ReadModel(xmiCode, metadata).ModelGroup;
        }

        public ImmutableModelGroup ReadModelGroup(string xmiCode, EcoreXmiReadOptions options = null)
        {
            return this.ReadModel(xmiCode, options).ModelGroup;
        }

        public ImmutableModelGroup ReadModelGroupFromFile(string xmiFilePath, ModelMetadata metadata)
        {
            return this.ReadModelFromFile(xmiFilePath, metadata).ModelGroup;
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
