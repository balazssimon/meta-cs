using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MetaDslx.Core
{
    public enum ModelExchangeFormat
    {
        Xmi,
        Json
    }

    public class ModelExchange
    {
        private const string XmiNamespace = "http://www.omg.org/spec/XMI/";

        public static void SaveToFile(string fileName, Model model, ModelExchangeFormat format = ModelExchangeFormat.Xmi)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine(ModelExchange.SaveToString(model, format));
            }
        }

        public static Model LoadFromFile(string fileName, ModelExchangeFormat format = ModelExchangeFormat.Xmi)
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                string text = reader.ReadToEnd();
                return ModelExchange.LoadFromString(text, format);
            }
        }

        public static string SaveToString(Model model, ModelExchangeFormat format = ModelExchangeFormat.Xmi)
        {
            switch (format)
            {
                case ModelExchangeFormat.Xmi:
                    return ModelExchange.ToXmi(model);
                case ModelExchangeFormat.Json:
                    return ModelExchange.ToJson(model);
                default:
                    return string.Empty;
            }
        }

        public static Model LoadFromString(string text, ModelExchangeFormat format = ModelExchangeFormat.Xmi)
        {
            switch (format)
            {
                case ModelExchangeFormat.Xmi:
                    return ModelExchange.FromXmi(text);
                case ModelExchangeFormat.Json:
                    return ModelExchange.FromJson(text);
                default:
                    return null;
            }
        }

        public static string ToXmi(Model model)
        {
            XDocument doc = new XDocument();
            XNamespace xmi = ModelExchange.XmiNamespace;
            XElement xmiRoot =
                new XElement(xmi + "XMI",
                    new XAttribute(XNamespace.Xmlns + "xmi", xmi.NamespaceName));
            doc.Add(xmiRoot);

            int counter = 0;
            Dictionary<MetaModel, XNamespace> metaModels = new Dictionary<MetaModel, XNamespace>();
            Dictionary<MetaModel, string> prefixes = new Dictionary<MetaModel, string>();

            List<ModelObject> instances = model.CachedInstances;
            foreach (var mo in instances)
            {
                if (mo.MMetaClass != null && mo.MMetaClass.Model != null)
                {
                    MetaModel mm = mo.MMetaClass.Model;
                    if (mm != null && !metaModels.ContainsKey(mm))
                    {
                        ++counter;
                        string prefix = "ns" + counter;
                        XNamespace ns = mm.Uri;
                        metaModels.Add(mm, ns);
                        prefixes.Add(mm, prefix);
                        xmiRoot.Add(new XAttribute(XNamespace.Xmlns + prefix, ns.NamespaceName));
                    }
                }
            }

            foreach (var mo in instances)
            {
                if (mo.MMetaClass != null && mo.MMetaClass.Model != null)
                {
                    if (mo.MParent == null || mo.MParent is RootScope)
                    {
                        XNamespace ns = metaModels[mo.MMetaClass.Model];
                        XElement elem = null;
                        if (ns != null)
                        {
                            elem = new XElement(ns + mo.MMetaClass.Name);
                        }
                        else
                        {
                            elem = new XElement(mo.MMetaClass.Name);
                        }
                        xmiRoot.Add(elem);
                        ModelExchange.SaveToXmi(xmi, metaModels, prefixes, elem, mo);
                    }
                }
            }

            return doc.ToString();
        }

        private static void SaveToXmi(XNamespace xmi, Dictionary<MetaModel, XNamespace> metaModels, Dictionary<MetaModel, string> prefixes, XElement elem, ModelObject mo)
        {
            if (!string.IsNullOrEmpty(mo.MetaID))
            {
                elem.Add(new XAttribute(xmi + "id", mo.MetaID));
            }
            foreach (var prop in mo.MGetProperties())
            {
                if (!prop.IsCollection && !prop.IsReadonly)
                {
                    if (prop.Type.IsPrimitive || prop.Type.IsEnum || prop.Type.Equals(typeof(string)))
                    {
                        if (!mo.MIsDefault(prop))
                        {
                            object value = mo.MGet(prop);
                            if (value != null)
                            {
                                elem.Add(new XAttribute(prop.Name.ToCamelCase(), value));
                            }
                            else
                            {
                                elem.Add(new XAttribute(prop.Name.ToCamelCase(), string.Empty));
                            }
                        }
                    }
                    else
                    {
                        if (!mo.MIsDefault(prop))
                        {
                            object value = mo.MGet(prop);
                            ModelObject valueObject = value as ModelObject;
                            if (valueObject != null)
                            {
                                if (!prop.OppositeProperties.Any(p => p.IsContainment))
                                {
                                    elem.Add(new XAttribute(prop.Name.ToCamelCase(), valueObject.MetaID));
                                }
                            }
                            else if (value != null)
                            {
                                elem.Add(new XAttribute(prop.Name.ToCamelCase(), value.ToString()));
                            }
                            else
                            {
                                elem.Add(new XAttribute(prop.Name.ToCamelCase(), string.Empty));
                            }
                        }
                    }
                }
                else if (prop.IsContainment)
                {
                    if (prop.IsCollection)
                    {
                        ModelCollection children = mo.MGet(prop) as ModelCollection;
                        if (children != null)
                        {
                            foreach (var childObj in children)
                            {
                                ModelObject child = childObj as ModelObject;
                                if (child != null && child.MMetaClass != null && child.MMetaClass.Model != null)
                                {
                                    string ns = prefixes[mo.MMetaClass.Model];
                                    XElement childElem =
                                        new XElement(
                                            prop.Name.ToCamelCase(),
                                            new XAttribute(xmi + "type", ns + ":" + child.MMetaClass.Name));
                                    elem.Add(childElem);
                                    ModelExchange.SaveToXmi(xmi, metaModels, prefixes, childElem, child);
                                }
                            }
                        }
                    }
                    else
                    {
                        ModelObject child = mo.MGet(prop) as ModelObject;
                        if (child != null && child.MMetaClass != null && child.MMetaClass.Model != null)
                        {
                            string ns = prefixes[mo.MMetaClass.Model];
                            XElement childElem =
                                new XElement(
                                    prop.Name.ToCamelCase(),
                                    new XAttribute(xmi + "type", ns + ":" + child.MMetaClass.Name));
                            elem.Add(childElem);
                            ModelExchange.SaveToXmi(xmi, metaModels, prefixes, childElem, child);
                        }
                    }
                }
                else 
                {
                    if (prop.IsCollection)
                    {
                        ModelCollection children = mo.MGet(prop) as ModelCollection;
                        if (children != null)
                        {
                            foreach (var childObj in children)
                            {
                                ModelObject child = childObj as ModelObject;
                                if (child != null && child.MMetaClass != null && child.MMetaClass.Model != null)
                                {
                                    //XNamespace ns = metaModels[mo.MMetaClass.Model];
                                    elem.Add(new XElement(prop.Name.ToCamelCase(), new XAttribute(xmi + "idref", child.MetaID)));
                                }
                            }
                        }
                    }
                    else if (!prop.IsReadonly)
                    {
                        ModelObject child = mo.MGet(prop) as ModelObject;
                        if (child != null && child.MMetaClass != null && child.MMetaClass.Model != null)
                        {
                            //string ns = prefixes[mo.MMetaClass.Model];
                            elem.Add(new XAttribute(prop.Name.ToCamelCase(), child.MetaID));
                        }
                    }
                }
            }
        }

        public static string ToJson(Model model)
        {
            return string.Empty;
        }

        public static Model FromXmi(string text)
        {
            return null;
        }

        public static Model FromJson(string text)
        {
            return null;
        }

    }
}
