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
    public class EcoreXmiSerializer
    {
        private IMetaModel _metaModel;

        public EcoreXmiSerializer(IMetaModel metaModel)
        {
            _metaModel = metaModel;
        }

        public ImmutableModel ReadModelFromFile(string xmiFilePath)
        {
            XmiReader reader = new XmiReader(_metaModel);
            reader.LoadXmiFile(xmiFilePath, ".");
            var diagnostics = reader.Diagnostics.ToReadOnly();
            if (diagnostics.Length > 0)
            {
                throw new ModelException(diagnostics[0]);
            }
            return reader.Model.ToImmutable();
        }

        public ImmutableModel ReadModel(string xmiCode)
        {
            XmiReader reader = new XmiReader(_metaModel);
            reader.LoadXmiCode(null, xmiCode);
            var diagnostics = reader.Diagnostics.ToReadOnly();
            if (diagnostics.Length > 0)
            {
                throw new ModelException(diagnostics[0]);
            }
            return reader.Model.ToImmutable();
        }

        public string WriteModel(IModel model)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.Encoding = Encoding.UTF8;
            settings.OmitXmlDeclaration = false;
            using (MemoryStream stream = new MemoryStream())
            {
                using (XmlWriter writer = XmlWriter.Create(stream, settings))
                {
                    var xmiWriter = new XmiWriter(writer);
                    xmiWriter.WriteModel(model);
                }
                return Encoding.UTF8.GetString(stream.ToArray());
            }
        }

        public void WriteModelToFile(string xmiFilePath, IModel model)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.Encoding = Encoding.UTF8;
            settings.OmitXmlDeclaration = false;
            using (StreamWriter stream = new StreamWriter(xmiFilePath))
            using (XmlWriter writer = XmlWriter.Create(stream, settings))
            {
                var xmiWriter = new XmiWriter(writer);
                xmiWriter.WriteModel(model);
            }
        }

    }

    internal class XmiWriter
    {
        private const string Xmi = "xmi";
        private const string XmiNamespace = "http://www.omg.org/spec/XMI/20131001";
        private XmlWriter _xml;
        private Dictionary<IMetaModel, (string, string)> _namespaces;

        public XmiWriter(XmlWriter xmlWriter)
        {
            _xml = xmlWriter;
            _namespaces = new Dictionary<IMetaModel, (string, string)>();
        }

        private (string, string) RegisterNamespace(IMetaModel metaModel)
        {
            string prefix = metaModel.Prefix ?? metaModel.Name.ToCamelCase();
            int index = 1;
            string currentPrefix = prefix;
            while (_namespaces.Values.Any(v => v.Item1 == currentPrefix))
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

        public void WriteModel(IModel model)
        {
            _xml.WriteStartElement(Xmi, "XMI", XmiNamespace);
            IEnumerable<IModelObject> allObjects = model.ModelGroup != null ? model.ModelGroup.Models.SelectMany(m => m.Objects) : model.Objects.Where(obj => obj.MParent == null);
            IEnumerable<IModelObject> rootObjects = allObjects.Where(obj => obj.MParent == null);
            IEnumerable<IMetaModel> metaModels = allObjects.Select(obj => obj.MMetaModel).Distinct();
            foreach (var mm in metaModels)
            {
                var ns = this.RegisterNamespace(mm);
                _xml.WriteAttributeString("xmlns", ns.Item1, null, ns.Item2);
            }
            foreach (var obj in rootObjects)
            {
                this.WriteObject(obj, null);
            }
            _xml.WriteEndElement();
        }

        private void WriteObject(IModelObject obj, string parentProperty)
        {
            var mm = obj.MMetaModel;
            var ns = this.GetNamespace(mm);
            if (parentProperty != null)
            {
                _xml.WriteStartElement(parentProperty.ToCamelCase());
            }
            else
            {
                _xml.WriteStartElement(ns.Item1, obj.MId.DisplayTypeName, ns.Item2);
            }
            _xml.WriteAttributeString(Xmi, "type", XmiNamespace, ns.Item1 + ":" + obj.MId.DisplayTypeName);
            _xml.WriteAttributeString(Xmi, "id", XmiNamespace, obj.MId.Id);
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
                            _xml.WriteAttributeString(prop.Name.ToCamelCase(), value.MId.Id); 
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
                            _xml.WriteAttributeString(Xmi, "idref", XmiNamespace, value.MId.Id);
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
        private IMetaModel _metaModel;
        private MutableModelGroup _modelGroup;
        private MutableModel _mainModel;
        private DiagnosticBag _diagnostics;
        private Dictionary<string, XmiFileReader> _readers;

        public XmiReader(IMetaModel metaModel)
        {
            _metaModel = metaModel;
            _modelGroup = new MutableModelGroup();
            _diagnostics = new DiagnosticBag();
            _readers = new Dictionary<string, XmiFileReader>();
        }

        internal IMetaModel MetaModel => _metaModel;

        internal MutableModelGroup ModelGroup => _modelGroup;

        internal DiagnosticBag Diagnostics => _diagnostics;

        public MutableModel Model => _mainModel;

        public void LoadXmiCode(string filePath, string xmiCode)
        {
            string fullPath = filePath != null ? Path.GetFullPath(filePath) : string.Empty;
            if (!_readers.ContainsKey(fullPath))
            {
                var reader = new XmiFileReader(_readers.Count == 0, filePath, xmiCode, this);
                _readers.Add(fullPath, reader);
                reader.ReadModel();
                if (reader.IsMainReader) _mainModel = reader.Model;
            }
        }

        public void LoadXmiFile(string relativeFilePath, string currentFilePath)
        {
            if (!relativeFilePath.Contains(':'))
            {
                relativeFilePath = Path.Combine(Path.GetDirectoryName(currentFilePath), relativeFilePath);
            }
            string xmiCode = File.ReadAllText(relativeFilePath);
            this.LoadXmiCode(relativeFilePath, xmiCode);
        }

        public IEnumerable<MutableObjectBase> ResolveObjects(string relativeFilePath, string currentFilePath, string id, XObject location)
        {
            if (!relativeFilePath.Contains(':'))
            {
                relativeFilePath = Path.Combine(Path.GetDirectoryName(currentFilePath), relativeFilePath);
            }
            string fullPath = Path.GetFullPath(relativeFilePath);
            if (_readers.TryGetValue(fullPath, out var reader))
            {
                return reader.ResolveObjects(id, location, null);
            }
            return null;
        }
    }

    internal class XmiFileReader
    {
        private static readonly XNamespace _xsiNamespace = "http://www.w3.org/2001/XMLSchema-instance";
        private bool _isMainReader;
        private string _filePath;
        private string _xmiCode;
        private XNamespace _xmiNamespace;
        private XmiReader _xmiReader;
        private MutableModel _model;
        private ModelFactory _factory;
        private XElement _root;
        private Dictionary<string, MutableObjectBase> _objectsById;
        private Dictionary<(int,int), MutableObjectBase> _objectsByPosition;

        public XmiFileReader(bool isMainReader, string filePath, string xmiCode, XmiReader xmiReader)
        {
            _isMainReader = isMainReader;
            _filePath = filePath;
            _xmiCode = xmiCode;
            _xmiReader = xmiReader;
            _model = _xmiReader.ModelGroup.CreateModel();
            _factory = new ModelFactory(_model, _xmiReader.MetaModel, ModelFactoryFlags.DontMakeObjectsCreated);
            _objectsById = new Dictionary<string, MutableObjectBase>();
            _objectsByPosition = new Dictionary<(int, int), MutableObjectBase>();
        }

        public bool IsMainReader => _isMainReader;
        public MutableModel Model => _model;

        internal Location GetLocation(XObject xobj)
        {
            if (xobj == null) return Location.None;
            IXmlLineInfo info = xobj;
            var lineSpan = new LinePositionSpan(new LinePosition(info.LineNumber - 1, info.LinePosition - 1), new LinePosition(info.LineNumber - 1, info.LinePosition - 1));
            return new ExternalFileLocation(_filePath ?? string.Empty, new TextSpan(), lineSpan);
        }

        internal void AddError(XObject xobj, string message)
        {
            _xmiReader.Diagnostics.Add(ModelErrorCode.ERR_XmiLoadError.ToDiagnostic(GetLocation(xobj), message));
        }

        internal void AddError(XObject xobj, ModelException mex)
        {
            _xmiReader.Diagnostics.Add(ModelErrorCode.ERR_XmiLoadError.ToDiagnostic(GetLocation(xobj), mex.Diagnostic.GetMessage()));
        }

        public void ReadModel()
        {
            List<MutableObjectBase> ownerStack = new List<MutableObjectBase>();
            var document = XDocument.Parse(_xmiCode, LoadOptions.SetBaseUri | LoadOptions.SetLineInfo);
            _root = document.Root;
            // if (root.Name.LocalName != "XMI") this.AddError(root, "XML root must be an 'xmi:XMI' element.");
            _xmiNamespace = _root.Name.NamespaceName;
            foreach (var child in _root.Elements())
            {
                this.CreateObject(child, null);
            }
            foreach (var child in _root.Elements())
            {
                this.ReadObject(child, null);
            }
        }

        private void CreateObject(XElement element, MutableObjectBase parent)
        {
            XAttribute xmiTypeAttribute = element.Attribute(_xmiNamespace + "type");
            XAttribute xsiTypeAttribute = element.Attribute(_xsiNamespace + "type");
            XAttribute idrefAttribute = element.Attribute(_xmiNamespace + "idref");
            XAttribute idAttribute = element.Attribute(_xmiNamespace + "id");
            XAttribute hrefAttribute = element.Attribute("href");
            if (hrefAttribute != null)
            {
                string[] hrefValue = hrefAttribute.Value.Split('#');
                if (hrefValue.Length >= 2)
                {
                    string hrefFilePath = hrefValue[0];
                    string objId = hrefValue[1];
                    if (!string.IsNullOrWhiteSpace(hrefFilePath))
                    {
                        _xmiReader.LoadXmiFile(hrefFilePath, _filePath);
                    }
                }
                return;
            }
            if (idrefAttribute != null) return;
            string typePrefix = null;
            string typeName = null;
            if (xmiTypeAttribute != null)
            {
                string[] typeValue = xmiTypeAttribute.Value.Split(':');
                typePrefix = typeValue.Length >= 2 ? typeValue[0] : null;
                typeName = typeValue.Length >= 2 ? typeValue[1] : typeValue[0];
            }
            if (xsiTypeAttribute != null)
            {
                string[] typeValue = xsiTypeAttribute.Value.Split(':');
                typePrefix = typeValue.Length >= 2 ? typeValue[0] : null;
                typeName = typeValue.Length >= 2 ? typeValue[1] : typeValue[0];
            }
            if (typeName == null)
            {
                string parentProperty = element.Name.LocalName.ToPascalCase();
                if (parent != null)
                {
                    ModelProperty property = parent.MGetProperty(parentProperty);
                    if (property != null)
                    {
                        if (typeof(ImmutableObject).IsAssignableFrom(property.ImmutableTypeInfo.Type))
                        {
                            typeName = property.ImmutableTypeInfo.Type.Name;
                        }
                    }
                }
            }
            MutableObjectBase obj = null;
            if (idAttribute != null)
            {
                if (typeName == null)
                {
                    this.AddError(element, $"Element '{element.Name}' must have an attribute 'xmi:type' or 'xsi:type'.");
                    return;
                }
                obj = (MutableObjectBase)_factory.Create(typeName);
                string id = idAttribute.Value;
                if (_objectsById.ContainsKey(id))
                {
                    this.AddError(element, $"Element '{element.Name}' with id '{id}' already exists.");
                    return;
                }
                else
                {
                    _objectsById.Add(id, obj);
                }
            }
            else if (typeName != null)
            {
                obj = (MutableObjectBase)_factory.Create(typeName);
                IXmlLineInfo info = element;
                _objectsByPosition.Add((info.LineNumber, info.LinePosition), obj);
            }
            foreach (var child in element.Elements())
            {
                this.CreateObject(child, obj);
            }
        }

        private void ReadObject(XElement element, MutableObjectBase parent)
        {
            MutableObjectBase[] obj = null;
            XAttribute xmiTypeAttribute = element.Attribute(_xmiNamespace + "type");
            XAttribute xsiTypeAttribute = element.Attribute(_xsiNamespace + "type");
            XAttribute idrefAttribute = element.Attribute(_xmiNamespace + "idref");
            XAttribute idAttribute = element.Attribute(_xmiNamespace + "id");
            XAttribute hrefAttribute = element.Attribute("href");
            var currentObj = this.ResolveObject(element);
            if (hrefAttribute != null)
            {
                obj = this.ResolveObjects(hrefAttribute.Value, hrefAttribute, element);
                if (obj == null) return;
            }
            if (idrefAttribute != null)
            {
                obj = this.ResolveObjects(idrefAttribute.Value, idrefAttribute, element);
                if (obj == null) return;
            }
            if (idAttribute != null)
            {
                obj = this.ResolveObjects(idAttribute.Value, idAttribute, element);
                if (obj == null) return;
            }
            if (obj == null)
            {
                if (currentObj != null)
                {
                    obj = new MutableObjectBase[] { currentObj };
                }
                else
                {
                    obj = null;
                }
            }
            string parentProperty = element.Name.LocalName.ToPascalCase();
            if (parent != null)
            {
                ModelProperty prop = parent.MGetProperty(parentProperty);
                if (prop == null)
                {
                    this.AddError(element, $"Model object '{parent.MName}' ({parent.MMetaClass.Name}) has no '{parentProperty}' property.");
                }
                else
                {
                    try
                    {
                        if (obj != null)
                        {
                            foreach (var o in obj)
                            {
                                parent.MAdd(prop, o);
                            }
                        }
                        else
                        {
                            this.AssignProperty(parent, element);
                        }
                    }
                    catch (ModelException mex)
                    {
                        this.AddError(element, mex);
                    }
                }
            }
            if (currentObj != null)
            {
                foreach (var attr in element.Attributes())
                {
                    this.AssignProperty(currentObj, attr);
                }
                foreach (var child in element.Elements())
                {
                    this.ReadObject(child, currentObj);
                }
            }
        }

        private void AssignProperty(MutableObjectBase obj, XElement element)
        {
            if (element.Name.NamespaceName == string.Empty)
            {
                string propertyName = element.Name.LocalName.ToPascalCase();
                string propertyValue = element.Value;
                this.AssignProperty(obj, element, propertyName, propertyValue);
            }
        }

        private void AssignProperty(MutableObjectBase obj, XAttribute attribute)
        {
            if (attribute.Name.NamespaceName == string.Empty)
            {
                string propertyName = attribute.Name.LocalName.ToPascalCase();
                string propertyValue = attribute.Value;
                this.AssignProperty(obj, attribute, propertyName, propertyValue);
            }
        }

        private void AssignProperty(MutableObjectBase obj, XObject xobj, string propertyName, string propertyValue)
        {
            if (propertyName == "Href") return;
            ModelProperty property = obj.MGetProperty(propertyName);
            if (property == null)
            {
                this.AddError(xobj, $"Model object '{obj.MName}' ({obj.MMetaClass.Name}) has no '{propertyName}' property.");
            }
            else
            {
                try
                {
                    IEnumerable<object> values = null;
                    object value = null;
                    if (typeof(ImmutableObject).IsAssignableFrom(property.ImmutableTypeInfo.Type))
                    {
                        values = this.ResolveObjects(propertyValue, xobj, _root);
                    }
                    else if (property.ImmutableTypeInfo.Type.IsEnum)
                    {
                        try
                        {
                            value = Enum.Parse(property.ImmutableTypeInfo.Type, propertyValue, true);
                        }
                        catch (Exception)
                        {
                            this.AddError(xobj, $"Value '{propertyValue}' is invalid for the enum type '{property.ImmutableTypeInfo.Type.FullName}'.");
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
                        this.AddError(xobj, $"Unhandled value type: {property.ImmutableTypeInfo.Type.FullName}.");
                        return;
                    }
                    if (values != null)
                    {
                        foreach (var v in values)
                        {
                            obj.MAdd(property, v);
                        }
                    }
                    else
                    {
                        obj.MAdd(property, value);
                    }
                }
                catch (ModelException mex)
                {
                    this.AddError(xobj, mex);
                }
            }
        }

        public MutableObjectBase ResolveSingleObjectById(string id, XObject location)
        {
            if (_objectsById.TryGetValue(id, out var result))
            {
                return result;
            }
            this.AddError(location, $"Model object referenced by value '{id}' cannot be resolved.");
            return null;
        }

        public MutableObjectBase[] ResolveObjects(string ids, XObject location, XElement root)
        {
            string[] idArray = ids.Split(new char[] { ' ', '\r', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            if (idArray.Length == 0) return null;
            List<MutableObjectBase> result = new List<MutableObjectBase>();
            foreach (var id in idArray)
            {
                var objs = this.ResolveObjectsByIdOrXPath(id, location, root);
                if (objs == null) return null;
                result.AddRange(objs);
            }
            return result.ToArray();
        }

        private IEnumerable<MutableObjectBase> ResolveObjectsByIdOrXPath(string id, XObject location, XElement root)
        {
            string xpath = id;
            string[] hrefValue = id.Split('#');
            if (hrefValue.Length >= 2)
            {
                string hrefFilePath = hrefValue[0];
                string objId = hrefValue[1];
                if (string.IsNullOrWhiteSpace(hrefFilePath))
                {
                    xpath = objId;
                }
                else
                {
                    return _xmiReader.ResolveObjects(hrefFilePath, _filePath, objId, location);
                }
            }
            if (_objectsById.TryGetValue(xpath, out var result))
            {
                return new MutableObjectBase[] { result }; 
            }
            else
            {
                IEnumerable<XElement> list = root.XPathSelectElements(xpath);
                List<MutableObjectBase> objs = new List<MutableObjectBase>();
                foreach (XElement el in list)
                {
                    var obj = this.ResolveObject(el);
                    if (obj == null)
                    {
                        this.AddError(location, $"Model object referenced by value '{id}' cannot be resolved.");
                        return null;
                    }
                    else
                    {
                        objs.Add(obj);
                    }
                }
                return objs;
            }
            this.AddError(location, $"Model object referenced by value '{id}' cannot be resolved.");
            return null;
        }

        public MutableObjectBase ResolveObject(XElement element)
        {
            IXmlLineInfo info = element;
            if (_objectsByPosition.TryGetValue((info.LineNumber, info.LinePosition), out var result)) return result;
            else return null;
        }
    }

}
