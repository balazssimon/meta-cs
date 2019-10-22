using MetaDslx.Languages.Ecore.Model;
using MetaDslx.Languages.Meta.Model;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
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
    public class XmiReadOptions
    {
        public XmiReadOptions()
        {
            this.XmiRoot = true;
            this.XmiNamespaces = new HashSet<string>();
            this.NamespaceToMetamodelMap = new Dictionary<string, IMetaModel>();
            this.UriToFileMap = new Dictionary<string, string>();
            this.UriToModelMap = new Dictionary<string, IModel>();
        }

        public XmiReadOptions(IMetaModel metaModel)
            : this()
        {
            this.NamespaceToMetamodelMap.Add(metaModel.Uri, metaModel);
        }

        public bool XmiRoot { get; set; }
        public HashSet<string> XmiNamespaces { get; set; }
        public Dictionary<string, IMetaModel> NamespaceToMetamodelMap { get; }
        public Dictionary<string, string> UriToFileMap { get; }
        public Dictionary<string, IModel> UriToModelMap { get; }
    }

    public class MetaDslxXmiReadOptions : XmiReadOptions
    {
        public MetaDslxXmiReadOptions()
        {
            this.UriToModelMap.Add(MetaInstance.MMetaModel.Uri, MetaInstance.MModel);
        }

        public MetaDslxXmiReadOptions(IMetaModel metaModel)
            : base(metaModel)
        {
            this.UriToModelMap.Add(MetaInstance.MMetaModel.Uri, MetaInstance.MModel);
        }
    }

    public class EcoreXmiReadOptions : XmiReadOptions
    {
        public EcoreXmiReadOptions()
        {
            this.XmiRoot = false;
            this.UriToModelMap.Add(EcoreXmiSerializer.EcoreMetamodelUri, EcoreInstance.MModel);
        }

        public EcoreXmiReadOptions(IMetaModel metaModel)
            : base(metaModel)
        {
            this.XmiRoot = false;
            this.UriToModelMap.Add(EcoreXmiSerializer.EcoreMetamodelUri, EcoreInstance.MModel);
        }
    }

    public class XmiWriteOptions
    {
        public XmiWriteOptions()
        {
            this.XmiRoot = true;
            this.XmiNamespace = "http://www.omg.org/spec/XMI";
            this.MetamodelToNamespaceMap = new Dictionary<IMetaModel, string>();
            this.ModelToUriMap = new Dictionary<IModel, string>();
        }

        public bool XmiRoot { get; set; }
        public string XmiNamespace { get; set; }
        public Dictionary<IMetaModel, string> MetamodelToNamespaceMap { get; }
        public Dictionary<IModel, string> ModelToUriMap { get; }
    }

    public class MetaDslxXmiWriteOptions : XmiWriteOptions
    {
        public MetaDslxXmiWriteOptions()
        {
            this.ModelToUriMap.Add(MetaInstance.MModel, MetaInstance.MMetaModel.Uri);
        }
    }

    public class EcoreXmiWriteOptions : XmiWriteOptions
    {
        public EcoreXmiWriteOptions()
        {
            this.XmiRoot = false;
            this.XmiNamespace = "http://www.omg.org/XMI";
            this.ModelToUriMap.Add(EcoreInstance.MModel, EcoreXmiSerializer.EcoreMetamodelUri);
        }
    }

    public class EcoreXmiSerializer
    {
        public const string EcoreMetamodelUri = "http://www.eclipse.org/emf/2002/Ecore";

        public ImmutableModel ReadModel(string xmiCode, IMetaModel metaModel)
        {
            if (xmiCode == null) throw new ArgumentNullException(nameof(xmiCode));
            if (metaModel == null) throw new ArgumentNullException(nameof(metaModel));
            var options = new XmiReadOptions();
            options.NamespaceToMetamodelMap.Add(metaModel.Uri, metaModel);
            return this.ReadModelFromFile(xmiCode, options);
        }

        public ImmutableModel ReadModelFromFile(string xmiFilePath, IMetaModel metaModel)
        {
            if (xmiFilePath == null) throw new ArgumentNullException(nameof(xmiFilePath));
            if (metaModel == null) throw new ArgumentNullException(nameof(metaModel));
            var options = new XmiReadOptions();
            options.NamespaceToMetamodelMap.Add(metaModel.Uri, metaModel);
            return this.ReadModelFromFile(xmiFilePath, options);
        }

        public ImmutableModel ReadModelFromFile(string xmiFilePath, XmiReadOptions options)
        {
            if (xmiFilePath == null) throw new ArgumentNullException(nameof(xmiFilePath));
            if (options == null) throw new ArgumentNullException(nameof(options));
            XmiReader reader = new XmiReader(options);
            reader.LoadXmiFile(new Uri(Path.GetFullPath(xmiFilePath)), null);
            var diagnostics = reader.Diagnostics.ToReadOnly();
            if (diagnostics.Length > 0)
            {
                throw new ModelException(diagnostics[0]);
            }
            return reader.Model.ToImmutable();
        }

        public ImmutableModel ReadModel(string xmiCode, XmiReadOptions options)
        {
            if (xmiCode == null) throw new ArgumentNullException(nameof(xmiCode));
            if (options == null) throw new ArgumentNullException(nameof(options));
            XmiReader reader = new XmiReader(options);
            reader.LoadXmiCode(null, xmiCode);
            var diagnostics = reader.Diagnostics.ToReadOnly();
            if (diagnostics.Length > 0)
            {
                throw new ModelException(diagnostics[0]);
            }
            return reader.Model.ToImmutable();
        }

        public string WriteModel(IModel model, XmiWriteOptions options)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.Encoding = Encoding.UTF8;
            settings.OmitXmlDeclaration = false;
            using (MemoryStream stream = new MemoryStream())
            {
                using (XmlWriter writer = XmlWriter.Create(stream, settings))
                {
                    var xmiWriter = new XmiWriter(writer, options, model);
                    xmiWriter.WriteModel();
                    var diagnostics = xmiWriter.Diagnostics.ToReadOnly();
                    if (diagnostics.Length > 0)
                    {
                        throw new ModelException(diagnostics[0]);
                    }
                }
                return Encoding.UTF8.GetString(stream.ToArray());
            }
        }

        public void WriteModelToFile(string xmiFilePath, IModel model, XmiWriteOptions options)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.Encoding = Encoding.UTF8;
            settings.OmitXmlDeclaration = false;
            using (StreamWriter stream = new StreamWriter(xmiFilePath))
            using (XmlWriter writer = XmlWriter.Create(stream, settings))
            {
                var xmiWriter = new XmiWriter(writer, options, model);
                xmiWriter.WriteModel();
                var diagnostics = xmiWriter.Diagnostics.ToReadOnly();
                if (diagnostics.Length > 0)
                {
                    throw new ModelException(diagnostics[0]);
                }
            }
        }

    }

    internal class XmiWriter
    {
        private const string Xmi = "xmi";
        private XmlWriter _xml;
        private Dictionary<IMetaModel, (string, string)> _namespaces;
        private IModel _mainModel;
        private XmiWriteOptions _options;
        private DiagnosticBag _diagnostics;
        private IEnumerable<IModelObject> _allObjects;

        public XmiWriter(XmlWriter xmlWriter, XmiWriteOptions options, IModel mainModel)
        {
            _xml = xmlWriter;
            _options = options;
            _namespaces = new Dictionary<IMetaModel, (string, string)>();
            _diagnostics = new DiagnosticBag();
            _mainModel = mainModel;
        }

        internal XmiWriteOptions Options => _options;
        internal DiagnosticBag Diagnostics => _diagnostics;
        internal IModelGroup ModelGroup => _mainModel.ModelGroup;
        public IModel Model => _mainModel;

        private (string, string) RegisterNamespace(IMetaModel metaModel)
        {
            if (_namespaces.TryGetValue(metaModel, out var ns)) return ns;
            string prefix = string.IsNullOrWhiteSpace(metaModel.Prefix) ? metaModel.Name.ToCamelCase() : metaModel.Prefix;
            int index = 1;
            string currentPrefix = prefix;
            while (_namespaces.Values.Any(v => v.Item1 == currentPrefix) || currentPrefix == Xmi)
            {
                ++index;
                currentPrefix = prefix + index;
            }
            var result = (currentPrefix, metaModel.Uri ?? metaModel.Namespace + "." + metaModel.Name);
            _namespaces.Add(metaModel, result);
            return result;
        }

        private (string, string) GetNamespace(IMetaModel metaModel)
        {
            _namespaces.TryGetValue(metaModel, out var result);
            return result;
        }

        public void WriteModel()
        {
            _allObjects = _mainModel.Objects.Where(obj => obj.MParent == null);
            List<IModelObject> rootObjects = _allObjects.Where(obj => obj.MParent == null).ToList();
            IModelObject xmiRoot = null;
            if (_options.XmiRoot)
            {
                _xml.WriteStartElement(Xmi, "XMI", _options.XmiNamespace);
                this.WriteXmlNamespaces();
                foreach (var obj in rootObjects)
                {
                    this.WriteObject(obj, null);
                }
                _xml.WriteEndElement();
            }
            else
            {
                if (rootObjects.Count > 1)
                {
                    this.Diagnostics.Add(ModelErrorCode.ERR_XmiError.ToDiagnostic(Location.None, "Multiple root model objects found. If the XMI root is not used the number model objects with no parent must be exactly one."));
                }
                xmiRoot = rootObjects.FirstOrDefault();
                this.WriteObject(xmiRoot, null);
            }
        }

        private void WriteXmlNamespaces()
        {
            IEnumerable<IMetaModel> metaModels = _allObjects.Select(obj => obj.MMetaModel).Distinct();
            foreach (var mm in metaModels)
            {
                var ns = this.RegisterNamespace(mm);
                _xml.WriteAttributeString("xmlns", ns.Item1, null, ns.Item2);
            }
        }

        private void WriteObject(IModelObject obj, string parentProperty)
        {
            var mm = obj.MMetaModel;
            var ns = this.RegisterNamespace(mm);
            if (parentProperty != null)
            {
                _xml.WriteStartElement(parentProperty.ToCamelCase());
            }
            else
            {
                _xml.WriteStartElement(ns.Item1, obj.MId.DisplayTypeName, ns.Item2);
            }
            if (!_options.XmiRoot && obj.MParent == null)
            {
                this.WriteXmlNamespaces();
            }
            _xml.WriteAttributeString(Xmi, "type", _options.XmiNamespace, ns.Item1 + ":" + obj.MId.DisplayTypeName);
            _xml.WriteAttributeString(Xmi, "id", _options.XmiNamespace, obj.MId.Id);
            HashSet<IModelObject> written = new HashSet<IModelObject>();
            foreach (var prop in obj.MProperties)
            {
                if (prop.IsDerived || prop.IsDerivedUnion) continue;
                bool oppositeIsContainment = prop.OppositeProperties.Any(p => p.IsContainment);
                //if (oppositeIsContainment) continue;
                bool isModelObjectType = typeof(IModelObject).IsAssignableFrom(prop.ImmutableTypeInfo.Type);
                if (!prop.IsCollection && (!prop.IsContainment || !isModelObjectType))
                {
                    if (isModelObjectType)
                    {
                        var value = obj.MGet(prop) as IModelObject;
                        if (value != null)
                        {
                            if (value.MModel == _mainModel)
                            {
                                _xml.WriteAttributeString(prop.Name.ToCamelCase(), value.MId.Id);
                            }
                            else
                            {
                                _xml.WriteAttributeString(prop.Name.ToCamelCase(), "!!!REF!!!");
                            }
                        }
                    }
                    else
                    {
                        var value = obj.MGet(prop)?.ToString();
                        if (value != null)
                        {
                            _xml.WriteAttributeString(prop.Name.ToCamelCase(), value);
                        }
                    }
                }
            }
            foreach (var prop in obj.MProperties)
            {
                if (prop.IsDerived || prop.IsDerivedUnion) continue;
                bool oppositeIsContainment = prop.OppositeProperties.Any(p => p.IsContainment);
                //if (oppositeIsContainment) continue;
                bool isModelObjectType = typeof(IModelObject).IsAssignableFrom(prop.ImmutableTypeInfo.Type);
                if (prop.IsCollection && (!prop.IsContainment || !isModelObjectType))
                {
                    if (isModelObjectType)
                    {
                        var value = obj.MGet(prop) as IModelObject;
                        if (value != null)
                        {
                            _xml.WriteStartElement(prop.Name.ToCamelCase());
                            if (value.MModel == _mainModel)
                            {
                                _xml.WriteAttributeString(Xmi, "idref", _options.XmiNamespace, value.MId.Id);
                            }
                            else
                            {
                                _xml.WriteAttributeString(Xmi, "idref", _options.XmiNamespace, "!!!REF!!!");
                            }
                            _xml.WriteEndElement();
                        }
                    }
                    else
                    {
                        var values = obj.MGet(prop) as System.Collections.IEnumerable;
                        if (values != null)
                        {
                            foreach (var value in values)
                            {
                                _xml.WriteElementString(prop.Name.ToCamelCase(), value.ToString());
                            }
                        }
                    }
                }
            }
            foreach (var prop in obj.MProperties.Reverse())
            {
                if (prop.IsDerived || prop.IsDerivedUnion) continue;
                bool isModelObjectType = typeof(IModelObject).IsAssignableFrom(prop.ImmutableTypeInfo.Type);
                if (prop.IsContainment && isModelObjectType)
                {
                    if (prop.IsCollection)
                    {
                        var children = obj.MGet(prop) as System.Collections.IEnumerable;
                        if (children != null)
                        {
                            foreach (IModelObject child in children)
                            {
                                if (child != null && written.Add(child))
                                {
                                    this.WriteObject(child, prop.Name);
                                }
                            }
                        }
                    }
                    else
                    {
                        var child = obj.MGet(prop) as IModelObject;
                        if (child != null && written.Add(child))
                        {
                            this.WriteObject(child, prop.Name);
                        }
                    }
                }
            }
            _xml.WriteEndElement();
        }
    }

    internal class XmiReader
    {
        private XmiReadOptions _options;
        private MutableModelGroup _modelGroup;
        private MutableModel _mainModel;
        private DiagnosticBag _diagnostics;
        private Dictionary<string, XmiFileReader> _readers;

        public XmiReader(XmiReadOptions options)
        {
            _options = options;
            _modelGroup = new MutableModelGroup();
            _diagnostics = new DiagnosticBag();
            _readers = new Dictionary<string, XmiFileReader>();
        }

        internal XmiReadOptions Options => _options;
        internal DiagnosticBag Diagnostics => _diagnostics;

        internal MutableModelGroup ModelGroup => _modelGroup;

        public MutableModel Model => _mainModel;

        public XmiFileReader LoadXmiCode(Uri fileUri, string xmiCode)
        {
            string absoluteUri = fileUri != null ? fileUri.AbsoluteUri : string.Empty;
            if (!_readers.TryGetValue(absoluteUri, out var reader))
            {
                reader = new XmiFileReader(_readers.Count == 0, fileUri, xmiCode, this);
                _readers.Add(absoluteUri, reader);
                reader.CreateObjects();
                if (reader.IsMainReader) _mainModel = (MutableModel)reader.Model;
            }
            bool finished = !reader.IsMainReader;
            while (!finished)
            {
                finished = true;
                var unfinishedReaders = _readers.Values.Where(r => !r.IsFinished).ToList();
                foreach (var rdr in unfinishedReaders)
                {
                    if (!rdr.IsFinished)
                    {
                        rdr.ReadObjects();
                        finished = false;
                    }
                }
            }
            return reader;
        }

        public XmiFileReader LoadXmiFile(Uri currentUri, string relativeUri)
        {
            Uri fileUri;
            if (relativeUri != null)
            {
                if (!_options.UriToFileMap.TryGetValue(relativeUri, out var mappedUri))
                {
                    mappedUri = relativeUri;
                }
                fileUri = new Uri(currentUri, mappedUri);
            }
            else
            {
                fileUri = currentUri;
            }
            // TODO: download HTTP file
            if (fileUri.IsFile)
            {
                var filePath = fileUri.AbsolutePath;
                string xmiCode = File.ReadAllText(filePath);
                return this.LoadXmiCode(fileUri, xmiCode);
            }
            else
            {
                return null;
            }
        }

        private XmiFileReader LoadXmiModel(Uri fileUri, IModel model)
        {
            string absoluteUri = fileUri != null ? fileUri.AbsoluteUri : string.Empty;
            if (!_readers.TryGetValue(absoluteUri, out var reader))
            {
                reader = new XmiFileReader(fileUri, model, this);
                _readers.Add(absoluteUri, reader);
                if (model is MutableModel mutableModel) _modelGroup.AddReference(mutableModel);
                else if (model is ImmutableModel immmutableModel) _modelGroup.AddReference(immmutableModel);
            }
            return reader;
        }

        public List<IModelObject> ResolveObjects(Uri currentUri, string relativeUri, string id, XObject location)
        {
            XmiFileReader reader;
            if (!_options.UriToFileMap.TryGetValue(relativeUri, out var mappedUri))
            {
                mappedUri = relativeUri;
            }
            var fileUri = new Uri(currentUri, mappedUri);
            var absoluteUri = fileUri.AbsoluteUri;
            if (_options.UriToModelMap.TryGetValue(relativeUri, out var mappedModel))
            {
                reader = this.LoadXmiModel(fileUri, mappedModel);
                if (reader == null) return new List<IModelObject>();
            }
            else
            {
                if (!_readers.TryGetValue(absoluteUri, out reader))
                {
                    reader = this.LoadXmiFile(currentUri, relativeUri);
                    if (reader == null)
                    {
                        return new List<IModelObject>();
                    }
                }
            }
            return reader.ResolveObjectsByReference(location, id, null);
        }
    }

    internal class XmiFileReader
    {
        private static readonly XNamespace _xsiNamespace = "http://www.w3.org/2001/XMLSchema-instance";
        private static readonly string[] _wellKnownXmiNamespaces = new string[] { "http://www.omg.org/XMI", "http://www.omg.org/spec/XMI" };
        private bool _isMainReader;
        private bool _isFinished;
        private Uri _fileUri;
        private string _xmiCode;
        private XmiReader _xmiReader;
        private IModel _model;
        private XElement _root;
        private Dictionary<string, ModelFactory> _namespaceToFactoryMap;
        private Dictionary<string, MutableObjectBase> _objectsById;
        private Dictionary<(int,int), MutableObjectBase> _objectsByPosition;
        private Dictionary<MutableObjectBase, XElement> _elementsByObject;

        public XmiFileReader(bool isMainReader, Uri fileUri, string xmiCode, XmiReader xmiReader)
        {
            _isMainReader = isMainReader;
            _fileUri = fileUri;
            _xmiCode = xmiCode;
            _xmiReader = xmiReader;
            _model = _xmiReader.ModelGroup.CreateModel();
            _namespaceToFactoryMap = new Dictionary<string, ModelFactory>();
            _objectsById = new Dictionary<string, MutableObjectBase>();
            _objectsByPosition = new Dictionary<(int, int), MutableObjectBase>();
            _elementsByObject = new Dictionary<MutableObjectBase, XElement>();
        }

        public XmiFileReader(Uri fileUri, IModel model, XmiReader xmiReader)
        {
            _fileUri = fileUri;
            _model = model;
            _xmiReader = xmiReader;
            _isFinished = true;
        }

        internal XmiReadOptions Options => _xmiReader.Options;
        public bool IsMainReader => _isMainReader;
        public bool IsFinished => _isFinished;
        public IModel Model => _model;

        internal Location GetLocation(XObject xobj)
        {
            if (xobj == null) return Location.None;
            IXmlLineInfo info = xobj;
            var lineSpan = new LinePositionSpan(new LinePosition(info.LineNumber - 1, info.LinePosition - 1), new LinePosition(info.LineNumber - 1, info.LinePosition - 1));
            return new ExternalFileLocation(_fileUri?.AbsolutePath ?? string.Empty, new TextSpan(), lineSpan);
        }

        internal void AddError(XObject location, string message)
        {
            _xmiReader.Diagnostics.Add(ModelErrorCode.ERR_XmiError.ToDiagnostic(GetLocation(location), message));
        }

        internal void AddError(XObject location, ModelException mex)
        {
            _xmiReader.Diagnostics.Add(ModelErrorCode.ERR_XmiError.ToDiagnostic(GetLocation(location), mex.Diagnostic.GetMessage()));
        }

        private ModelFactory GetFactory(XObject location, string nsName, bool reportError = true)
        {
            if (_namespaceToFactoryMap.TryGetValue(nsName, out var factory) && factory != null) return factory;
            if (this.Options.NamespaceToMetamodelMap.TryGetValue(nsName, out var metaModel) && metaModel != null)
            {
                factory = new ModelFactory((MutableModel)_model, metaModel, ModelFactoryFlags.DontMakeObjectsCreated);
                _namespaceToFactoryMap.Add(nsName, factory);
                return factory;
            }
            else
            {
                if (!reportError) this.AddError(location, string.Format("No metamodel is specified for the namespace '{0}'. Use the XmiReadOptions.NamespaceToMetamodelMap property to register the metamodel for the given namespace.", nsName));
                return null;
            }
        }

        private bool IsXmiNamespace(string nsName)
        {
            foreach (var xmiNs in _wellKnownXmiNamespaces)
            {
                if (nsName.StartsWith(xmiNs)) return true;
            }
            foreach (var xmiNs in this.Options.XmiNamespaces)
            {
                if (nsName == xmiNs) return true;
            }
            return false;
        }

        public void CreateObjects()
        {
            var document = XDocument.Parse(_xmiCode, LoadOptions.SetBaseUri | LoadOptions.SetLineInfo);
            _root = document.Root;
            this.CreateObject(_root, null, null);
        }

        public void ReadObjects()
        {
            this.ReadObject(_root, null);
            foreach (var mobj in ((MutableModel)_model).Objects)
            {
                mobj.MMakeCreated();
            }
            _isFinished = true;
        }

        private void CreateObject(XElement element, MutableObjectBase parent, ModelFactory currentFactory)
        {
            XAttribute xmiTypeAttribute = GetXmiTypeAttribute(element);
            XAttribute xsiTypeAttribute = GetXsiTypeAttribute(element);
            XAttribute idAttribute = GetXmiIdAttribute(element);
            string typePrefix = null;
            string typeName = null;
            ModelFactory factory = null;
            if (xmiTypeAttribute != null || xsiTypeAttribute != null)
            {
                var typeAttribute = xmiTypeAttribute ?? xsiTypeAttribute;
                string[] typeValue = typeAttribute.Value.Split(':');
                typePrefix = typeValue.Length >= 2 ? typeValue[0] : null;
                typeName = typeValue.Length >= 2 ? typeValue[1] : typeValue[0];
                var typeNs = typePrefix != null ? element.GetNamespaceOfPrefix(typePrefix) : element.GetDefaultNamespace();
                factory = GetFactory(typeAttribute, typeNs.NamespaceName);
            }
            if (typeName == null)
            {
                if (parent == null)
                {
                    typeName = element.Name.LocalName.ToPascalCase();
                    factory = GetFactory(element, element.Name.Namespace.NamespaceName);
                }
                else
                {
                    string parentProperty = element.Name.LocalName.ToPascalCase();
                    ModelProperty property = parent.MGetProperty(parentProperty);
                    if (property != null)
                    {
                        if (typeof(ImmutableObject).IsAssignableFrom(property.ImmutableTypeInfo.Type))
                        {
                            typeName = property.ImmutableTypeInfo.Type.Name;
                            var typeNs = element.Parent != null ? element.Parent.Name.Namespace : element.Name.Namespace;
                            factory = GetFactory(element, typeNs.NamespaceName) ?? currentFactory;
                            if (factory == null)
                            {
                                this.AddError(element, "Unable to find a model factory for this element.");
                            }
                        }
                    }
                }
            }
            MutableObjectBase obj = null;
            if (factory != null && typeName != null)
            {
                obj = (MutableObjectBase)factory.Create(typeName);
                string parentPropertyName = element.Name.LocalName.ToPascalCase();
                ModelProperty parentProperty = parent?.MGetProperty(parentPropertyName);
                if (parentProperty != null)
                {
                    try
                    {
                        parent.MAdd(parentProperty, obj);
                    }
                    catch (ModelException mex)
                    {
                        this.AddError(element, mex);
                    }
                }
                this.RegisterObjectByPosition(element, obj);
                foreach (var nameProp in obj.MAllProperties.Where(p => p.IsName))
                {
                    var nameAttr = element.Attribute(nameProp.Name.ToCamelCase());
                    if (nameAttr != null)
                    {
                        string name = nameAttr.Value;
                        try
                        {
                            obj.MAdd(nameProp, name);
                        }
                        catch (ModelException mex)
                        {
                            this.AddError(element, mex);
                        }
                    }
                }
                if (idAttribute != null)
                {
                    string id = idAttribute.Value;
                    this.RegisterObjectById(idAttribute, id, obj);
                }
            }
            foreach (var child in element.Elements())
            {
                this.CreateObject(child, obj, factory ?? currentFactory);
            }
        }

        private XAttribute GetXmiAttribute(XElement element, string attributeName)
        {
            foreach (var attr in element.Attributes())
            {
                if (attr.Name.LocalName == attributeName && this.IsXmiNamespace(attr.Name.NamespaceName)) return attr;
            }
            return null;
        }

        private XAttribute GetXmiTypeAttribute(XElement element)
        {
            return GetXmiAttribute(element, "type");
        }

        private XAttribute GetXsiTypeAttribute(XElement element)
        {
            return element.Attribute(_xsiNamespace + "type");
        }

        private XAttribute GetXmiIdAttribute(XElement element)
        {
            return GetXmiAttribute(element, "id");
        }

        private XAttribute GetXmiIdrefAttribute(XElement element)
        {
            return GetXmiAttribute(element, "idref");
        }

        private XAttribute GetHrefAttribute(XElement element)
        {
            return element.Attribute("href");
        }

        private bool RegisterObjectByPosition(XElement location, MutableObjectBase mobj)
        {
            IXmlLineInfo info = location;
            var pos = (info.LineNumber, info.LinePosition);
            if (_objectsByPosition.TryGetValue(pos, out var existing))
            {
                this.AddError(location, string.Format("A model object is already registered for position {0}.", pos));
                return false;
            }
            else
            {
                _objectsByPosition.Add(pos, mobj);
            }
            if (_elementsByObject.TryGetValue(mobj, out var existingElem) && existingElem != location)
            {
                this.AddError(location, string.Format("The element is already registered for another model object.", pos));
                return false;
            }
            else
            {
                _elementsByObject.Add(mobj, location);
                return true;
            }
        }

        private bool RegisterObjectById(XObject location, string id, MutableObjectBase mobj)
        {
            if (_objectsById.TryGetValue(id, out var existing))
            {
                this.AddError(location, string.Format("Model object with identifier '{0}' already exists.", id));
                return false;
            }
            else
            {
                _objectsById.Add(id, mobj);
                return true;
            }
        }

        private void ReadObject(XElement element, MutableObjectBase parent)
        {
            MutableObjectBase currentObj = ResolveObjectByPosition(element, false);
            string parentPropertyName = element.Name.LocalName.ToPascalCase();
            ModelProperty parentProperty = parent?.MGetProperty(parentPropertyName);
            if (parentProperty != null)
            {
                if (currentObj == null)
                {
                    XAttribute idrefAttribute = GetXmiIdrefAttribute(element);
                    XAttribute hrefAttribute = GetHrefAttribute(element);
                    if (idrefAttribute != null || hrefAttribute != null)
                    {
                        var refAttribute = idrefAttribute ?? hrefAttribute;
                        var reference = refAttribute.Value;
                        foreach (var resolvedObj in ResolveObjectsByReference(refAttribute, reference, element))
                        {
                            var value = resolvedObj;
                            try
                            {
                                parent.MAdd(parentProperty, ResolveMetaConstantValue(parentProperty, resolvedObj));
                            }
                            catch (ModelException mex)
                            {
                                this.AddError(element, mex);
                            }
                        }
                        return;
                    }
                    else
                    {
                        this.AssignProperty(currentObj, element);
                        return;
                    }
                }
            }
            if (currentObj != null)
            {
                foreach (var attr in element.Attributes())
                {
                    this.AssignProperty(currentObj, element, attr);
                }
            }
            foreach (var child in element.Elements())
            {
                this.ReadObject(child, currentObj);
            }
        }

        private void AssignProperty(MutableObjectBase obj, XElement element)
        {
            if (element.Name.NamespaceName == string.Empty)
            {
                string propertyName = element.Name.LocalName.ToPascalCase();
                string propertyValue = element.Value;
                this.AssignProperty(obj, element, element, propertyName, propertyValue);
            }
        }

        private void AssignProperty(MutableObjectBase obj, XElement element, XAttribute attribute)
        {
            if (attribute.Name.NamespaceName == string.Empty)
            {
                string propertyName = attribute.Name.LocalName.ToPascalCase();
                string propertyValue = attribute.Value;
                this.AssignProperty(obj, attribute, element, propertyName, propertyValue);
            }
        }

        private void AssignProperty(MutableObjectBase obj, XObject location, XElement context, string propertyName, string propertyValue)
        {
            ModelProperty property = obj.MGetProperty(propertyName);
            if (property == null)
            {
                this.AddError(location, $"Model object '{obj.MName}' ({obj.MMetaClass.Name}) has no '{propertyName}' property.");
            }
            else
            {
                if (property.IsName) return;
                try
                {
                    IEnumerable<object> values = null;
                    object value = null;
                    if (typeof(ImmutableObject).IsAssignableFrom(property.ImmutableTypeInfo.Type))
                    {
                        values = this.ResolveObjectsByReference(location, propertyValue, context);
                    }
                    else if (property.ImmutableTypeInfo.Type.IsEnum)
                    {
                        try
                        {
                            value = Enum.Parse(property.ImmutableTypeInfo.Type, propertyValue, true);
                        }
                        catch (Exception)
                        {
                            this.AddError(location, $"Value '{propertyValue}' is invalid for the enum type '{property.ImmutableTypeInfo.Type.FullName}'.");
                            return;
                        }
                    }
                    else if (property.ImmutableTypeInfo.Type == typeof(string))
                    {
                        value = propertyValue;
                    }
                    else if (property.ImmutableTypeInfo.Type == typeof(bool))
                    {
                        value = propertyValue.ToLower() == "true" || propertyValue == "1";
                    }
                    else if (property.ImmutableTypeInfo.Type == typeof(int))
                    {
                        int.TryParse(propertyValue, out int intValue);
                        if (propertyValue == "*") intValue = -1;
                        value = intValue;
                    }
                    else if (property.ImmutableTypeInfo.Type == typeof(long))
                    {
                        long.TryParse(propertyValue, out long longValue);
                        if (propertyValue == "*") longValue = -1;
                        value = longValue;
                    }
                    else if (property.ImmutableTypeInfo.Type == typeof(float))
                    {
                        float.TryParse(propertyValue, out float floatValue);
                        value = floatValue;
                    }
                    else if (property.ImmutableTypeInfo.Type == typeof(double))
                    {
                        double.TryParse(propertyValue, out double doubleValue);
                        value = doubleValue;
                    }
                    else
                    {
                        this.AddError(location, $"Unhandled value type: {property.ImmutableTypeInfo.Type.FullName}.");
                        return;
                    }
                    if (values != null)
                    {
                        foreach (var v in values)
                        {
                            obj.MAdd(property, ResolveMetaConstantValue(property, v));
                        }
                    }
                    else
                    {
                        obj.MAdd(property, ResolveMetaConstantValue(property, value));
                    }
                }
                catch (ModelException mex)
                {
                    this.AddError(location, mex);
                }
            }
        }

        private object ResolveMetaConstantValue(ModelProperty property, object value)
        {
            if (property.ImmutableTypeInfo.Type != typeof(MetaConstant))
            {
                if (value is MetaConstant metaConstant) return metaConstant.Value;
                else if (value is MetaConstantBuilder metaConstantBuilder) return metaConstantBuilder.Value;
            }
            return value;
        }

        public MutableObjectBase ResolveObjectById(XObject location, string id, bool reportError = true)
        {
            if (_objectsById.TryGetValue(id, out var result))
            {
                return result;
            }
            if (reportError) this.AddError(location, $"Model object referenced by identifier '{id}' cannot be resolved.");
            return null;
        }

        public MutableObjectBase ResolveObjectByPosition(XObject location, bool reportError = true)
        {
            IXmlLineInfo info = location;
            var pos = (info.LineNumber, info.LinePosition);
            if (_objectsByPosition.TryGetValue(pos, out var result))
            {
                return result;
            }
            if (reportError) this.AddError(location, $"Model object referenced by position '{pos}' cannot be resolved.");
            return null;
        }

        public XElement ResolveElementByObject(MutableObjectBase mobj, XObject location, bool reportError = true)
        {
            if (_elementsByObject.TryGetValue(mobj, out var result))
            {
                return result;
            }
            if (reportError) this.AddError(location, $"Element cannot be resolved based on the model object.");
            return null;
        }

        public List<IModelObject> ResolveObjectsByReference(XObject location, string reference, XElement context)
        {
            if (context == null) context = _root;
            string[] idArray = reference.Split(new char[] { ' ', '\r', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            List<IModelObject> result = new List<IModelObject>();
            if (idArray.Length == 0) return result;
            foreach (var id in idArray)
            {
                this.ResolveObjectsByXPointer(location, id, context, result);
            }
            if (result.Count == 0)
            {
                this.AddError(location, $"Unable to resolve reference '{reference}'.");
            }
            return result;
        }

        private bool ResolveObjectsByXPointer(XObject location, string reference, XElement context, List<IModelObject> result)
        {
            string localReference = reference;
            string[] hrefValue = reference.Split('#');
            if (hrefValue.Length >= 2)
            {
                string hrefFilePath = hrefValue[0];
                string objId = hrefValue[1];
                if (string.IsNullOrWhiteSpace(hrefFilePath))
                {
                    localReference = objId;
                }
                else
                {
                    var externalObjects = _xmiReader.ResolveObjects(_fileUri, hrefFilePath, objId, location);
                    result.AddRange(externalObjects);
                    return externalObjects.Count > 0;
                }
            }
            return this.ResolveObjectsByLocalXPointer(location, localReference, context, result);
        }

        private bool ResolveObjectsByLocalXPointer(XObject location, string reference, XElement context, List<IModelObject> result)
        {
            if (!reference.Contains("/"))
            {
                var mobj = this.ResolveObjectById(location, reference, false);
                if (mobj != null)
                {
                    result.Add(mobj);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            var currentReference = reference;
            bool currentElementsAreModelObjects = false;
            List<object> currentElements = null;
            while (!string.IsNullOrWhiteSpace(currentReference))
            {
                (currentReference, currentElements, currentElementsAreModelObjects) = this.ResolveXPointPart(location, currentReference, currentElements, currentElementsAreModelObjects);
            }
            if (currentElements != null && currentElements.Count > 0)
            {
                if (currentElementsAreModelObjects) result.AddRange(currentElements.OfType<IModelObject>());
                else result.AddRange(currentElements.OfType<XElement>().Select(e => ResolveObjectByPosition(e)));
                return true;
            }
            else
            {
                return false;
            }
        }

        private (string, List<object>, bool) ResolveXPointPart(XObject location, string currentReference, List<object> currentElements, bool currentElementsAreModelObjects)
        {
            string nextReference = null;
            bool recursive = currentReference.StartsWith("//");
            bool resolveByElementName = currentReference.StartsWith("//@") || currentReference.StartsWith("/@");
            bool resolveByObjectName = !resolveByElementName && currentReference.StartsWith("/");
            string elementName = null;

            if (resolveByElementName) (elementName, nextReference) = this.GetNextXPointPart(currentReference.Substring(recursive ? 3 : 2));
            else  if (resolveByObjectName) (elementName, nextReference) = this.GetNextXPointPart(currentReference.Substring(recursive ? 2 : 1));
            else nextReference = null;
            
            int index = -1;
            int openIndex = elementName.IndexOf('[');
            int closeIndex = elementName.LastIndexOf(']');
            int dotIndex = elementName.LastIndexOf('.');
            if (openIndex >= 0 && closeIndex == elementName.Length)
            {
                var indexStr = elementName.Substring(openIndex + 1, closeIndex - openIndex - 1);
                if (int.TryParse(indexStr, out index)) index -= 1;
                else index = -1;
                elementName = elementName.Substring(0, openIndex);
            }
            else if (dotIndex >= 0)
            {
                var indexStr = elementName.Substring(dotIndex + 1);
                if (!int.TryParse(indexStr, out index)) index = -1;
                elementName = elementName.Substring(0, dotIndex);
            }
            
            if (resolveByElementName)
            {
                var nextElements = new List<object>();
                IEnumerable<XElement> parentElements = null;
                if (currentElements == null)
                {
                    if (recursive)
                    {
                        parentElements = _root.DescendantsAndSelf(elementName);
                    }
                    else
                    {
                        parentElements = _root.Name == elementName ? ImmutableArray.Create(_root) : ImmutableArray<XElement>.Empty;
                    }
                    int i = 0;
                    foreach (var refElem in parentElements)
                    {
                        var elem = ResolveObjectByPosition(refElem, false);
                        if (elem != null && (index < 0 || i == index))
                        {
                            nextElements.Add(refElem);
                        }
                        ++i;
                    }
                }
                else
                {
                    if (currentElementsAreModelObjects) parentElements = currentElements.OfType<MutableObjectBase>().Select(mobj => ResolveElementByObject(mobj, location));
                    else parentElements = currentElements.OfType<XElement>();
                    foreach (var parentElement in parentElements)
                    {
                        int i = 0;
                        var items = recursive ? parentElement.Descendants(elementName) : parentElement.Elements(elementName);
                        foreach (var refElem in items)
                        {
                            var elem = ResolveObjectByPosition(refElem, false);
                            if (elem != null && (index < 0 || i == index))
                            {
                                nextElements.Add(refElem);
                            }
                            ++i;
                        }
                    }
                }
                return (nextReference, nextElements, false);
            }

            if (resolveByObjectName)
            {
                var nextElements = new List<object>();
                if (currentElements == null)
                {
                    if (recursive) nextElements.AddRange(_model.Objects.Where(mobj => mobj.MName == elementName));
                    else nextElements.AddRange(_model.Objects.Where(mobj => mobj.MParent == null && mobj.MName == elementName));
                }
                else
                {
                    IEnumerable<IModelObject> parentObjects = null;
                    if (currentElementsAreModelObjects) parentObjects = currentElements.OfType<IModelObject>();
                    else parentObjects = currentElements.OfType<XElement>().Select(e => ResolveObjectByPosition(e));
                    foreach (var parentObject in parentObjects)
                    {
                        int i = 0;
                        var descendants = recursive ? GetModelObjectsRecursive(parentObject, elementName) : parentObject.MChildren.Where(mobj => mobj.MName == elementName);
                        foreach (var child in descendants)
                        {
                            if (child.MName == elementName)
                            {
                                nextElements.Add(child);
                                ++i;
                            }
                        }
                    }
                }
                return (nextReference, nextElements, true);
            }
            this.AddError(location, $"Unable to process reference '{currentReference}', because it is of an unknown format.");
            return (null, null, false);
        }

        private (string, string) GetNextXPointPart(string currentReference)
        {
            int slashIndex = currentReference.IndexOf('/');
            var elementName = currentReference;
            if (slashIndex >= 0)
            {
                elementName = currentReference.Substring(0, slashIndex);
                currentReference = currentReference.Substring(slashIndex);
            }
            else
            {
                currentReference = null;
            }
            return (elementName, currentReference);
        }

        private IEnumerable<IModelObject> GetModelObjectsRecursive(IModelObject parent, string name)
        {
            foreach (var child in parent.MChildren)
            {
                if (child.MName == name) yield return child;
                foreach (var descendant in GetModelObjectsRecursive(child, name))
                {
                    yield return descendant;
                }
            }
        }

    }

}
