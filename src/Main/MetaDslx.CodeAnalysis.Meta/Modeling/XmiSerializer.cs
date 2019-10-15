using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace MetaDslx.Modeling
{
    public class XmiSerializer
    {
        private Type _metaInstanceType;

        public XmiSerializer(Type metaInstanceType)
        {
            _metaInstanceType = metaInstanceType;
        }

        public ImmutableModel ReadModel(string xmiFilePath)
        {
            XmiLoader loader = new XmiLoader(_metaInstanceType);
            loader.LoadXmiFile(xmiFilePath, ".");
            var diagnostics = loader.Diagnostics.ToReadOnly();
            if (diagnostics.Length > 0)
            {
                throw new ModelException(diagnostics[0]);
            }
            return loader.Model.ToImmutable();
        }

        public void WriteModel(XmlWriter writer, IModel model)
        {
        }

    }

    internal class XmiLoader
    {
        private Type _metaInstanceType;
        private MutableModelGroup _modelGroup;
        private MutableModel _mainModel;
        private DiagnosticBag _diagnostics;
        private Dictionary<string, XmiFileLoader> _loaders;

        public XmiLoader(Type metaInstanceType)
        {
            _metaInstanceType = metaInstanceType;
            _modelGroup = new MutableModelGroup();
            _diagnostics = new DiagnosticBag();
            _loaders = new Dictionary<string, XmiFileLoader>();
        }

        internal Type MetaInstanceType => _metaInstanceType;

        internal MutableModelGroup ModelGroup => _modelGroup;

        internal DiagnosticBag Diagnostics => _diagnostics;

        public MutableModel Model => _mainModel;

        public void LoadXmiCode(string filePath, string xmiCode)
        {
            string fullPath = filePath != null ? Path.GetFullPath(filePath) : string.Empty;
            if (!_loaders.ContainsKey(fullPath))
            {
                var loader = new XmiFileLoader(_loaders.Count == 0, filePath, xmiCode, this);
                _loaders.Add(fullPath, loader);
                loader.ReadModel();
                if (loader.IsMainLoader) _mainModel = loader.Model;
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

        public MutableObjectBase ResolveObject(string relativeFilePath, string currentFilePath, string id)
        {
            if (!relativeFilePath.Contains(':'))
            {
                relativeFilePath = Path.Combine(Path.GetDirectoryName(currentFilePath), relativeFilePath);
            }
            string fullPath = Path.GetFullPath(relativeFilePath);
            if (_loaders.TryGetValue(fullPath, out var loader))
            {
                return loader.ResolveObject(id);
            }
            return null;
        }
    }

    internal class XmiFileLoader
    {
        private bool _isMainLoader;
        private string _filePath;
        private string _xmiCode;
        private XNamespace _xmiNamespace;
        private XmiLoader _xmiLoader;
        private MutableModel _model;
        private ModelFactory _factory;
        private Dictionary<string, MutableObjectBase> _objects;

        public XmiFileLoader(bool isMainLoader, string filePath, string xmiCode, XmiLoader xmiLoader)
        {
            _isMainLoader = isMainLoader;
            _filePath = filePath;
            _xmiCode = xmiCode;
            _xmiLoader = xmiLoader;
            _model = _xmiLoader.ModelGroup.CreateModel();
            _factory = new ModelFactory(_model, _xmiLoader.MetaInstanceType, ModelFactoryFlags.DontMakeObjectsCreated);
            _objects = new Dictionary<string, MutableObjectBase>();
        }

        public bool IsMainLoader => _isMainLoader;
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
            _xmiLoader.Diagnostics.Add(ModelErrorCode.ERR_XmiLoadError.ToDiagnostic(GetLocation(xobj), message));
        }

        internal void AddError(XObject xobj, ModelException mex)
        {
            _xmiLoader.Diagnostics.Add(ModelErrorCode.ERR_XmiLoadError.ToDiagnostic(GetLocation(xobj), mex.Diagnostic.GetMessage()));
        }

        public void ReadModel()
        {
            List<MutableObjectBase> ownerStack = new List<MutableObjectBase>();
            var document = XDocument.Parse(_xmiCode, LoadOptions.SetBaseUri | LoadOptions.SetLineInfo);
            var root = document.Root;
            if (root.Name.LocalName != "XMI") this.AddError(root, "XML root must be an 'xmi:XMI' element.");
            _xmiNamespace = root.Name.NamespaceName;
            foreach (var child in root.Elements())
            {
                this.CreateObject(child);
            }
            foreach (var child in root.Elements())
            {
                this.ReadObject(child, null);
            }
        }

        private void CreateObject(XElement element)
        {
            XAttribute typeAttribute = element.Attribute(_xmiNamespace + "type");
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
                        _xmiLoader.LoadXmiFile(hrefFilePath, _filePath);
                    }
                }
                return;
            }
            if (idrefAttribute != null) return;
            if (idAttribute != null)
            {
                if (typeAttribute == null)
                {
                    this.AddError(element, $"Element '{element.Name}' must have an attribute 'xmi:type'.");
                    return;
                }
                string[] typeValue = typeAttribute.Value.Split(':');
                string typePrefix = typeValue.Length >= 2 ? typeValue[0] : null;
                string typeName = typeValue.Length >= 2 ? typeValue[1] : typeValue[0];
                string id = idAttribute.Value;
                MutableObjectBase obj = (MutableObjectBase)_factory.Create(typeName);
                if (_objects.ContainsKey(id))
                {
                    this.AddError(element, $"Element '{element.Name}' with id '{id}' already exists.");
                    return;
                }
                else
                {
                    _objects.Add(id, obj);
                }
            }
            foreach (var child in element.Elements())
            {
                this.CreateObject(child);
            }
        }

        private void ReadObject(XElement element, MutableObjectBase parent)
        {
            MutableObjectBase obj = null;
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
                        obj = _xmiLoader.ResolveObject(hrefFilePath, _filePath, objId);
                    }
                }
                if (obj == null)
                {
                    this.AddError(element, $"Element '{element.Name}' with href='{hrefAttribute.Value}' cannot be resolved.");
                    return;
                }
            }
            if (idrefAttribute != null)
            {
                obj = this.ResolveObject(idrefAttribute.Value);
                if (obj == null)
                {
                    this.AddError(element, $"Element '{element.Name}' with xmi:idref='{idrefAttribute.Value}' cannot be resolved.");
                    return;
                }
            }
            if (idAttribute != null)
            {
                obj = this.ResolveObject(idAttribute.Value);
                if (obj == null)
                {
                    this.AddError(element, $"Element '{element.Name}' with xmi:idref='{idAttribute.Value}' cannot be resolved.");
                    return;
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
                        if (hrefAttribute != null || idrefAttribute != null || idAttribute != null)
                        {
                            parent.MAdd(prop, obj);
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
            foreach (var attr in element.Attributes())
            {
                this.AssignProperty(obj, attr);
            }
            foreach (var child in element.Elements())
            {
                this.ReadObject(child, obj);
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
                    object value = null;
                    if (typeof(ImmutableObject).IsAssignableFrom(property.ImmutableTypeInfo.Type))
                    {
                        value = this.ResolveObject(propertyValue);
                        if (value == null)
                        {
                            this.AddError(xobj, $"Model object referenced by value '{propertyValue}' cannot be resolved.");
                            return;
                        }
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
                        value = intValue;
                    }
                    else if (property.ImmutableTypeInfo.Type == typeof(long))
                    {
                        long.TryParse(propertyValue, out long longValue);
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
                    obj.MAdd(property, value);
                }
                catch (ModelException mex)
                {
                    this.AddError(xobj, mex);
                }
            }
        }

        public MutableObjectBase ResolveObject(string id)
        {
            if (_objects.TryGetValue(id, out var result)) return result;
            else return null;
        }
    }

    internal static class StringExtensions
    {
        public static string ToPascalCase(this string identifier)
        {
            if (string.IsNullOrEmpty(identifier)) return identifier;
            else return char.ToUpper(identifier[0]) + identifier.Substring(1);
        }
    }
}
