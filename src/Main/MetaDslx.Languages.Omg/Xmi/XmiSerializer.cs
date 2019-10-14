using MetaDslx.Languages.Meta.Model;
using MetaDslx.Modeling;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace MetaDslx.Languages.Xmi
{
    public class XmiSerializer
    {
        private XNamespace _xmiNamespace;
        private Type _metaInstanceType;

        public XmiSerializer(Type metaInstanceType, string xmiNamespace = null)
        {
            _metaInstanceType = metaInstanceType;
            _xmiNamespace = xmiNamespace ?? "http://www.omg.org/spec/XMI/20131001";
        }

        public ImmutableModel ReadModel(string xmiCode)
        {
            XmiLoader loader = new XmiLoader(_metaInstanceType, _xmiNamespace);
            return loader.ReadModel(xmiCode);
        }

        public void WriteModel(XmlWriter writer, IModel model)
        {
        }
    }

    internal class XmiLoader
    {
        private XNamespace _xmiNamespace;
        private Type _metaInstanceType;
        private MutableModelGroup _modelGroup;
        private MutableModel _model;
        private ModelFactory _factory;
        private Dictionary<string, MutableObjectBase> _objects;

        public XmiLoader(Type metaInstanceType, XNamespace xmiNamespace)
        {
            _metaInstanceType = metaInstanceType;
            _xmiNamespace = xmiNamespace;
            _modelGroup = new MutableModelGroup();
            _modelGroup.AddReference(Mof.Model.MofInstance.Model);
            _model = _modelGroup.CreateModel();
            _factory = new ModelFactory(_model, _metaInstanceType, ModelFactoryFlags.DontMakeObjectsCreated);
            _objects = new Dictionary<string, MutableObjectBase>();
            _objects.Add("http://www.omg.org/spec/UML/20131001/PrimitiveTypes.xmi#Boolean", (MutableObjectBase)MetaDslx.Languages.Mof.Model.MofInstance.Boolean.ToMutable());
            _objects.Add("http://www.omg.org/spec/UML/20131001/PrimitiveTypes.xmi#String", (MutableObjectBase)MetaDslx.Languages.Mof.Model.MofInstance.String.ToMutable());
            _objects.Add("http://www.omg.org/spec/UML/20131001/PrimitiveTypes.xmi#Integer", (MutableObjectBase)MetaDslx.Languages.Mof.Model.MofInstance.Integer.ToMutable());
            _objects.Add("http://www.omg.org/spec/UML/20131001/PrimitiveTypes.xmi#Real", (MutableObjectBase)MetaDslx.Languages.Mof.Model.MofInstance.Real.ToMutable());
            _objects.Add("http://www.omg.org/spec/UML/20131001/PrimitiveTypes.xmi#UnlimitedNatural", (MutableObjectBase)MetaDslx.Languages.Mof.Model.MofInstance.UnlimitedNatural.ToMutable());
        }

        public ImmutableModel ReadModel(string xmiCode)
        {
            List<MutableObjectBase> ownerStack = new List<MutableObjectBase>();
            var document = XDocument.Parse(xmiCode);
            var root = document.Root;
            if (root.Name.LocalName != "XMI" || root.Name.Namespace != _xmiNamespace) throw new InvalidOperationException("XML root must be an 'xmi:XMI' element.");
            foreach (var child in root.Elements())
            {
                this.CreateElement(child);
            }
            foreach (var child in root.Elements())
            {
                this.ReadElement(child, null);
            }
            return null;
        }

        private void CreateElement(XElement element)
        {
            XAttribute typeAttribute = element.Attribute(_xmiNamespace + "type");
            XAttribute idrefAttribute = element.Attribute(_xmiNamespace + "idref");
            XAttribute idAttribute = element.Attribute(_xmiNamespace + "id");
            XAttribute hrefAttribute = element.Attribute("href");
            if (idrefAttribute == null && hrefAttribute == null)
            {
                if (typeAttribute == null || idAttribute == null) return;
                //throw new InvalidOperationException($"Element '{element.Name}' must have 'xmi:type' and 'xmi:id' attributes or an 'xmi:idref' or a 'href' attribute.");
            }
            if (typeAttribute != null)
            {
                string[] typeValue = typeAttribute.Value.Split(':');
                string typePrefix = typeValue.Length >= 2 ? typeValue[0] : null;
                string typeName = typeValue.Length >= 2 ? typeValue[1] : typeValue[0];
                string id = idAttribute.Value;
                MutableObjectBase obj = (MutableObjectBase)_factory.Create(typeName);
                _objects.Add(id, obj);
                //_objects[id] = obj;
                foreach (var child in element.Elements())
                {
                    this.CreateElement(child);
                }
            }
        }

        private void ReadElement(XElement element, MutableObjectBase parent)
        {
            XAttribute idrefAttribute = element.Attribute(_xmiNamespace + "idref");
            XAttribute idAttribute = element.Attribute(_xmiNamespace + "id");
            XAttribute hrefAttribute = element.Attribute("href");
            string id = null;
            if (idAttribute != null) id = idAttribute.Value;
            if (idrefAttribute != null) id = idrefAttribute.Value;
            if (hrefAttribute != null) id = hrefAttribute.Value;
            if (id == null) return; // throw new InvalidOperationException($"Element {element.Name} must have an 'xmi:id' or an 'xmi:idref' attribute.");
            if (!_objects.TryGetValue(id, out var obj)) throw new InvalidOperationException($"Element with identifier '{id}' not found.");

            string parentProperty = element.Name.LocalName.ToPascalCase();
            if (parent != null)
            {
                ModelProperty prop = parent.MGetProperty(parentProperty);
                if (prop == null) throw new InvalidOperationException($"Model object '{parent.MName}' ({parent.MMetaClass.Name}) has no '{parentProperty}' property.");
                parent.MAdd(prop, obj);
            }
            foreach (var child in element.Elements())
            {
                this.ReadElement(child, obj);
            }
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
