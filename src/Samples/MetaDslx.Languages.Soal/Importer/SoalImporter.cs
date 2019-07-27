using MetaDslx.Languages.Soal.Importer;
using MetaDslx.Languages.Soal.Symbols;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace MetaDslx.Languages.Soal
{
    internal class ObjectStorage<TObject, TXObject> 
        where TObject : class
        where TXObject : XElement
    {
        private string name;
        private SoalImporter importer;
        private Dictionary<TXObject, TObject> objectsByElement = new Dictionary<TXObject, TObject>();
        private Dictionary<XName, TObject> objectsByName = new Dictionary<XName, TObject>();
        private Dictionary<XName, TXObject> elementsByName = new Dictionary<XName, TXObject>();
        private Dictionary<TObject, TXObject> elementsByObject = new Dictionary<TObject, TXObject>();

        public ObjectStorage(string name, SoalImporter importer)
        {
            this.name = name;
            this.importer = importer;
        }

        internal TObject Register(Importer.XmlReader reader, XName xname, TXObject xobj, TObject obj, bool allowReverse = true)
        {
            TObject oldObject = null;
            if (this.objectsByName.TryGetValue(xname, out oldObject))
            {
                TXObject oldElem = this.elementsByObject[oldObject];
                this.importer.AddError("The "+this.name+" '" + xname + "' is already imported from '" + oldElem.BaseUri + "' at '" + SoalImporter.GetLinePositionSpan(oldElem) + "'.", reader.Uri, SoalImporter.GetLinePositionSpan(xobj));
                return null;
            }
            if (this.objectsByElement.TryGetValue(xobj, out oldObject))
            {
                TXObject oldElem = this.elementsByObject[oldObject];
                this.importer.AddError("The " + this.name + " '" + xname + "' has already an object assigned to it.", reader.Uri, SoalImporter.GetLinePositionSpan(xobj));
                return null;
            }
            TXObject oldXObject = null;
            if (this.elementsByName.TryGetValue(xname, out oldXObject))
            {
                this.importer.AddError("The " + this.name + " '" + xname + "' is already registered to '" + oldXObject.BaseUri + "' at '" + SoalImporter.GetLinePositionSpan(oldXObject) + "'.", reader.Uri, SoalImporter.GetLinePositionSpan(xobj));
                return null;
            }
            this.objectsByName.Add(xname, obj);
            this.objectsByElement.Add(xobj, obj);
            this.elementsByName.Add(xname, xobj);
            if (allowReverse)
            {
                if (this.elementsByObject.TryGetValue(obj, out oldXObject))
                {
                    this.importer.AddError("The object is alredy registered to " + this.name + " in '" + oldXObject.BaseUri + "' at '" + SoalImporter.GetLinePositionSpan(oldXObject) + "'.", reader.Uri, SoalImporter.GetLinePositionSpan(xobj));
                    return null;
                }
                if (!this.elementsByObject.ContainsKey(obj))
                {
                    this.elementsByObject.Add(obj, xobj);
                }
            }
            return obj;
        }

        internal TObject Get(XName xname)
        {
            if (xname == null) return null;
            TObject result = null;
            this.objectsByName.TryGetValue(xname, out result);
            return result;
        }

        internal TObject Get(TXObject xobj)
        {
            if (xobj == null) return null;
            TObject result = null;
            this.objectsByElement.TryGetValue(xobj, out result);
            return result;
        }

        internal TXObject GetX(XName xname)
        {
            if (xname == null) return null;
            TXObject result = null;
            this.elementsByName.TryGetValue(xname, out result);
            return result;
        }

        internal TXObject GetX(TObject obj)
        {
            if (obj == null) return null;
            TXObject result = null;
            this.elementsByObject.TryGetValue(obj, out result);
            return result;
        }
    }

    public class SoalImporter
    {
        private int namespaceCounter;
        private ArrayTypeBuilder byteArray;
        private Dictionary<string, HashSet<Importer.XmlReader>> readers = new Dictionary<string, HashSet<Importer.XmlReader>>();
        private Dictionary<string, NamespaceBuilder> namespaces = new Dictionary<string, NamespaceBuilder>();
        private Dictionary<SoalTypeBuilder, SoalTypeBuilder> replacementTypes = new Dictionary<SoalTypeBuilder, SoalTypeBuilder>();
        private Dictionary<IMetaSymbol, SoalTypeBuilder> originalTypes = new Dictionary<IMetaSymbol, SoalTypeBuilder>();
        private HashSet<SoalTypeBuilder> rootTypes = new HashSet<SoalTypeBuilder>();
        private HashSet<SoalTypeBuilder> typesToRemove = new HashSet<SoalTypeBuilder>();
        private Dictionary<XName, WsdlMessage> messagesByName = new Dictionary<XName, WsdlMessage>();
        private Dictionary<SoalTypeBuilder, int> referenceCounter = new Dictionary<SoalTypeBuilder, int>();

        internal DiagnosticBag Diagnostics { get; private set; }
        internal MutableModel SoalModel { get; private set; }
        internal MutableModel Model { get; private set; }
        internal SoalFactory Factory { get; private set; }
        internal ObjectStorage<SoalTypeBuilder, XElement> XsdTypes { get; private set; }
        internal ObjectStorage<SoalTypeBuilder, XElement> XsdElements { get; private set; }
        internal ObjectStorage<SoalTypeBuilder, XElement> XsdAttributes { get; private set; }
        internal ObjectStorage<SoalTypeBuilder, XElement> WsdlTypes { get; private set; }
        internal ObjectStorage<SoalTypeBuilder, XElement> WsdlElements { get; private set; }
        internal ObjectStorage<WsdlMessage, XElement> WsdlMessages { get; private set; }
        internal ObjectStorage<InterfaceBuilder, XElement> WsdlPortTypes { get; private set; }
        internal ObjectStorage<BindingBuilder, XElement> WsdlBindings { get; private set; }
        internal ObjectStorage<EndpointBuilder, XElement> WsdlServices { get; private set; }
        internal ObjectStorage<BindingBuilder, XElement> WsdlPolicies { get; private set; }

        private SoalImporter(DiagnosticBag diagnostics)
        {
            this.Diagnostics = diagnostics;
            this.namespaceCounter = 0;
            MutableModelGroup group = new MutableModelGroup();
            group.AddReference(SoalInstance.Model);
            this.Model = group.CreateModel("ImportedModel", new ModelVersion());
            this.Factory = new Symbols.SoalFactory(this.Model);
            this.byteArray = this.Factory.ArrayType();
            this.byteArray.InnerType = SoalInstance.Byte.ToMutable();
            this.XsdTypes = new ObjectStorage<SoalTypeBuilder, XElement>("type", this);
            this.XsdElements = new ObjectStorage<SoalTypeBuilder, XElement>("element", this);
            this.XsdAttributes = new ObjectStorage<SoalTypeBuilder, XElement>("attribute", this);
            this.WsdlTypes = new ObjectStorage<SoalTypeBuilder, XElement>("type", this);
            this.WsdlElements = new ObjectStorage<SoalTypeBuilder, XElement>("element", this);
            this.WsdlMessages = new ObjectStorage<WsdlMessage, XElement>("message", this);
            this.WsdlPortTypes = new ObjectStorage<InterfaceBuilder, XElement>("portType", this);
            this.WsdlBindings = new ObjectStorage<BindingBuilder, XElement>("binding", this);
            this.WsdlServices = new ObjectStorage<EndpointBuilder, XElement>("service", this);
            this.WsdlPolicies = new ObjectStorage<BindingBuilder, XElement>("policy", this);
        }

        public static ImmutableModel Import(string uri, DiagnosticBag diagnostics = null)
        {
            SoalImporter importer = new SoalImporter(diagnostics);
            importer.ImportFile(uri);
            if (importer.Diagnostics.HasAnyErrors()) return importer.Model.ToImmutable();
            LoadImportedFiles(importer);
            if (importer.Diagnostics.HasAnyErrors()) return importer.Model.ToImmutable();
            importer.Model.EvaluateLazyValues();
            RemoveTypes(importer);
            foreach (var fileUri in importer.readers.Keys)
            {
                if (!importer.Diagnostics.AsEnumerable().Any(d => d.Location.GetLineSpan().Path == fileUri && d.Severity == DiagnosticSeverity.Error))
                {
                    importer.AddInfo("File successfully imported.", fileUri, default);
                }
                else
                {
                    importer.AddError("Could not import file.", fileUri, default);
                }
            }
            return importer.Model.ToImmutable();
        }

        private static void LoadImportedFiles(SoalImporter importer)
        {
            for (int i = 0; i < XsdReader.PhaseCount; i++)
            {
                foreach (var reader in importer.readers)
                {
                    foreach (var r in reader.Value)
                    {
                        r.LoadXsdFile(i);
                    }
                }
            }
            importer.CheckXsdTypes();
            for (int i = 0; i < WsdlReader.PhaseCount; i++)
            {
                foreach (var reader in importer.readers)
                {
                    foreach (var r in reader.Value)
                    {
                        r.LoadWsdlFile(i);
                    }
                }
            }
        }

        internal void AddError(string message, string fileUri, LinePositionSpan location)
        {
            this.Diagnostics.Add(SoalImporterErrorCode.Error, Location.Create(fileUri, default, location), message);
        }

        internal void AddWarning(string message, string fileUri, LinePositionSpan location)
        {
            this.Diagnostics.Add(SoalImporterErrorCode.Warning, Location.Create(fileUri, default, location), message);
        }

        internal void AddInfo(string message, string fileUri, LinePositionSpan location)
        {
            this.Diagnostics.Add(SoalImporterErrorCode.Info, Location.Create(fileUri, default, location), message);
        }

        private static void RemoveTypes(SoalImporter importer)
        {
            foreach (var type in importer.typesToRemove)
            {
                DeclarationBuilder decl = type as DeclarationBuilder;
                if (decl != null)
                {
                    int count = 0;
                    importer.referenceCounter.TryGetValue(type, out count);
                    if (count <= 0)
                    {
                        decl.Namespace = null;
                        importer.Model.RemoveSymbol(decl);
                    }
                }
            }
        }

        internal void AddRootType(SoalTypeBuilder type)
        {
            if (type == null) return;
            this.rootTypes.Add(type);
        }

        internal void Reference(SoalTypeBuilder type)
        {
            if (type == null) return;
            int count = 0;
            if (this.referenceCounter.TryGetValue(type, out count))
            {
                ++count;
            }
            else
            {
                count = 1;
            }
            this.referenceCounter[type] = count;
        }

        internal static LinePositionSpan GetLinePositionSpan(XObject xobj)
        {
            if (xobj == null) return new LinePositionSpan();
            IXmlLineInfo info = xobj;
            return new LinePositionSpan(new LinePosition(info.LineNumber, info.LinePosition), new LinePosition(info.LineNumber, info.LinePosition));
        }

        internal void ImportFile(string fileUri)
        {
            try
            {
                XDocument doc;
                Uri uri;
                string absoluteUri;
                if (Uri.TryCreate(fileUri, UriKind.Absolute, out uri))
                {
                    absoluteUri = uri.AbsoluteUri;
                }
                else
                {
                    string fullPath = Path.GetFullPath(fileUri);
                    if (Uri.TryCreate(fullPath, UriKind.Absolute, out uri))
                    {
                        absoluteUri = uri.AbsoluteUri;
                    }
                    else
                    {
                        absoluteUri = fullPath;
                    }
                }
                doc = XDocument.Load(absoluteUri, LoadOptions.SetBaseUri | LoadOptions.SetLineInfo);
                this.ImportXmlDocument(doc, absoluteUri);
            }
            catch(System.Exception ex)
            {
                this.AddError("Could not import file: "+ex.Message, fileUri, default);
            }
        }

        internal void ImportRelativeFile(string currentUri, string relativeUri)
        {
            string importUri = this.GetAbsoluteFileUri(currentUri, relativeUri);
            if (importUri != null)
            {
                this.ImportFile(importUri);
            }
            else
            {
                this.AddError("Invalid relative URI in import '" + relativeUri + "'.", currentUri, default);
            }
        }

        internal string GetAbsoluteFileUri(string currentUri, string relativeUri)
        {
            Uri uri;
            if (Uri.TryCreate(relativeUri, UriKind.Absolute, out uri))
            {
                return uri.AbsoluteUri;
            }
            else
            {
                string baseUriStr = currentUri.Substring(0, currentUri.LastIndexOf('/') + 1);
                Uri baseUri;
                if (Uri.TryCreate(baseUriStr, UriKind.Absolute, out baseUri))
                {
                    if (Uri.TryCreate(baseUri, relativeUri, out uri))
                    {
                        return uri.AbsoluteUri;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    if (Path.IsPathRooted(relativeUri))
                    {
                        return relativeUri;
                    }
                    else
                    {
                        string absoluteUri = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(currentUri), relativeUri));
                        return absoluteUri;
                    }
                }
            }
        }

        internal NamespaceBuilder CreateNamespace(Importer.XmlReader reader, string uri, string prefix, string qualifiedName)
        {
            if (qualifiedName == null)
            {
                qualifiedName = "Ns" + (++this.namespaceCounter);
            }
            NamespaceBuilder result = this.GetNamespace(uri);
            if (result != null)
            {
                if (result.Uri != uri)
                {
                    this.AddWarning("Namespace '" + result.FullName + "' has conflicting URIs: '" + result.FullName + "' and '" + uri + "'", reader.Uri, default);
                }
                return result;
            }
            string[] names = qualifiedName.Split('.');
            int i = 0;
            NamespaceBuilder currentNs = null;
            while (i < names.Length)
            {
                var parentNs = currentNs;
                if (i == 0)
                {
                    NamespaceBuilder rootNs = this.Model.Symbols.OfType<NamespaceBuilder>().FirstOrDefault(ns => ns.Name == names[0] && ns.Namespace == null);
                    currentNs = rootNs;
                }
                else
                {
                    currentNs = currentNs.Declarations.OfType<NamespaceBuilder>().FirstOrDefault(ns => ns.Name == names[i]);
                }
                if (currentNs != null)
                {
                    ++i;
                    if (i == names.Length)
                    {
                        if (string.IsNullOrEmpty(currentNs.Prefix))
                        {
                            currentNs.Prefix = prefix;
                        }
                        this.namespaces.Add(uri, currentNs);
                        return currentNs;
                    }
                }
                else
                {
                    while(i < names.Length)
                    {
                        NamespaceBuilder ns = this.Factory.Namespace();
                        ns.Name = names[i];
                        ns.Namespace = parentNs;
                        ++i;
                        if (i == names.Length)
                        {
                            ns.Prefix = prefix;
                            ns.Uri = uri;
                            result = ns;
                            this.namespaces.Add(uri, ns);
                            return result;
                        }
                        parentNs = ns;
                    }
                }
            }
            return result;
        }

        internal NamespaceBuilder GetNamespace(string uri)
        {
            NamespaceBuilder result = null;
            this.namespaces.TryGetValue(uri, out result);
            return result;
        }

        internal void RegisterOriginalType(IMetaSymbol obj, SoalTypeBuilder type)
        {
            if (obj == null) return;
            if (type == null) return;
            if (!originalTypes.ContainsKey(obj))
            {
                this.originalTypes.Add(obj, type);
            }
        }

        internal void RegisterReplacementType(SoalTypeBuilder from, SoalTypeBuilder to)
        {
            if (from == null) return;
            if (to == null) return;
            if (!replacementTypes.ContainsKey(from))
            {
                this.replacementTypes.Add(from, to);
                this.typesToRemove.Add(from);
            }
        }

        internal void RemoveType(SoalTypeBuilder type)
        {
            this.typesToRemove.Add(type);
        }

        internal void RemoveNamespace(NamespaceBuilder ns)
        {
            this.Model.RemoveSymbol(ns);
        }

        internal SoalTypeBuilder GetReplacementType(SoalTypeBuilder original)
        {
            SoalTypeBuilder result = null;
            this.replacementTypes.TryGetValue(original, out result);
            return result;
        }

        internal SoalTypeBuilder ResolveXsdPrimitiveType(XName name)
        {
            if (name.NamespaceName == XsdReader.XsdNamespace)
            {
                SoalType result = null;
                SoalTypeBuilder resultAsBuilder = null;
                switch (name.LocalName)
                {
                    case "any": result = SoalInstance.Object; break;
                    case "anySimpleType": result = SoalInstance.Object; break;
                    case "string": result = SoalInstance.String; break;
                    case "anyURI": result = SoalInstance.String; break;
                    case "QName": result = SoalInstance.String; break;
                    case "NOTATION": result = SoalInstance.String; break;
                    case "normalizedString": result = SoalInstance.String; break;
                    case "token": result = SoalInstance.String; break;
                    case "language": result = SoalInstance.String; break;
                    case "Name": result = SoalInstance.String; break;
                    case "NCName": result = SoalInstance.String; break;
                    case "NMTOKEN": result = SoalInstance.String; break;
                    case "NMTOKENS": result = SoalInstance.String; break;
                    case "ID": result = SoalInstance.String; break;
                    case "IDREF": result = SoalInstance.String; break;
                    case "IDREFS": result = SoalInstance.String; break;
                    case "ENTITY": result = SoalInstance.String; break;
                    case "ENTITIES": result = SoalInstance.String; break;
                    case "integer": result = SoalInstance.Int; break;
                    case "nonPositiveInteger": result = SoalInstance.Int; break;
                    case "negativeInteger": result = SoalInstance.Int; break;
                    case "int": result = SoalInstance.Int; break;
                    case "short": result = SoalInstance.Int; break;
                    case "nonNegativeInteger": result = SoalInstance.Int; break;
                    case "positiveInteger": result = SoalInstance.Int; break;
                    case "unsignedInt": result = SoalInstance.Int; break;
                    case "unsignedShort": result = SoalInstance.Int; break;
                    case "long": result = SoalInstance.Long; break;
                    case "unsignedLong": result = SoalInstance.Int; break;
                    case "float": result = SoalInstance.Float; break;
                    case "double": result = SoalInstance.Double; break;
                    case "decimal": result = SoalInstance.Double; break;
                    case "byte": result = SoalInstance.Byte; break;
                    case "unsignedByte": result = SoalInstance.Byte; break;
                    case "base64Binary": resultAsBuilder = this.byteArray; break;
                    case "hexBinary": resultAsBuilder = this.byteArray; break;
                    case "bool": result = SoalInstance.Bool; break;
                    case "boolean": result = SoalInstance.Bool; break;
                    case "time": result = SoalInstance.Time; break;
                    case "date": result = SoalInstance.Date; break;
                    case "dateTime": result = SoalInstance.DateTime; break;
                    case "duration": result = SoalInstance.TimeSpan; break;
                    case "gDay": result = SoalInstance.Date; break;
                    case "gMonth": result = SoalInstance.Date; break;
                    case "gMonthDay": result = SoalInstance.Date; break;
                    case "gYear": result = SoalInstance.Date; break;
                    case "gYearMonth": result = SoalInstance.Date; break;
                    default:
                        break;
                }
                if (resultAsBuilder == null && result != null)
                {
                    resultAsBuilder = result.ToMutable();
                }
                return resultAsBuilder;
            }
            return null;
        }

        internal SoalTypeBuilder ResolveXsdType(XName name)
        {
            SoalTypeBuilder result = null;
            if (name.NamespaceName == XsdReader.XsdNamespace)
            {
                result = this.ResolveXsdPrimitiveType(name);
                if (result != null) return result;
            }
            NamespaceBuilder ns = this.GetNamespace(name.NamespaceName);
            if (ns != null)
            {
                SoalTypeBuilder type = ns.Declarations.FirstOrDefault(d => d.Name == name.LocalName) as SoalTypeBuilder;
                return this.ResolveXsdReplacementType(type);
            }
            return null;
        }

        internal SoalTypeBuilder ResolveXsdReplacementType(SoalTypeBuilder type)
        {
            while (true)
            {
                SoalTypeBuilder replacementType = null;
                if (type != null && this.replacementTypes.TryGetValue(type, out replacementType))
                {
                    type = replacementType;
                }
                if (replacementType == null) return type;
            }
        }

        private void RegisterReader(string uri, Importer.XmlReader reader)
        {
            HashSet<Importer.XmlReader> rs;
            if (!this.readers.TryGetValue(uri, out rs))
            {
                rs = new HashSet<Importer.XmlReader>();
                this.readers.Add(uri, rs);
            }
            rs.Add(reader);
        }

        internal void ImportXmlDocument(XDocument doc, string uri)
        {
            if (readers.ContainsKey(uri)) return;
            this.ImportXml(doc.Root, uri);
        }

        internal void ImportXml(XElement root, string uri)
        {
            if (root.Name.LocalName == "schema" && root.Name.NamespaceName == XsdReader.XsdNamespace)
            {
                XsdReader reader = new XsdReader(this, root, uri);
                this.RegisterReader(uri, reader);
                reader.CollectImportedFiles();
            }
            else if (root.Name.LocalName == "definitions" && root.Name.NamespaceName == WsdlReader.WsdlNamespace)
            {
                WsdlReader reader = new WsdlReader(this, root, uri);
                this.RegisterReader(uri, reader);
                reader.CollectImportedFiles();
            }
            else
            {
                this.AddError("Unknown XML data.", uri, GetLinePositionSpan(root));
                return;
            }
        }

        private void CheckXsdTypes()
        {
            var types = this.Model.Symbols.OfType<StructBuilder>().ToList();
            foreach (var type in types)
            {
                foreach (var prop in type.Properties)
                {
                    if (prop.Type == null || prop.Type.GetCoreType() == null)
                    {
                        XElement elem = this.XsdTypes.GetX(type);
                        string uri = "";
                        if (elem != null)
                        {
                            uri = elem.BaseUri;
                        }
                        this.AddError("The property '" + type.Name + "." + prop.Name + "' has no type.", uri, SoalImporter.GetLinePositionSpan(elem));
                    }
                    else
                    {
                        SoalTypeBuilder originalType = null;
                        if (this.originalTypes.TryGetValue((IMetaSymbol)prop, out originalType))
                        {
                            if (originalType is AnnotatedElementBuilder && ((AnnotatedElementBuilder)originalType).HasAnnotation(SoalAnnotations.Restriction))
                            {
                                SoalImporter.CopyAnnotation(SoalAnnotations.Restriction, ((AnnotatedElementBuilder)originalType), prop);
                            }
                            if (originalType is StructBuilder)
                            {
                                object wrapped = ((StructBuilder)originalType).GetAnnotationPropertyValue(SoalAnnotations.Type, SoalAnnotationProperties.Wrapped) ?? false;
                                if ((bool)wrapped)
                                {
                                    SoalImporter.CopyAnnotationProperty(SoalAnnotations.Type, SoalAnnotationProperties.Wrapped, ((AnnotatedElementBuilder)originalType), SoalAnnotations.Element, SoalAnnotationProperties.Wrapped, prop);
                                    SoalImporter.CopyAnnotationProperty(SoalAnnotations.Type, SoalAnnotationProperties.Items, ((AnnotatedElementBuilder)originalType), SoalAnnotations.Element, SoalAnnotationProperties.Items, prop);
                                    SoalImporter.CopyAnnotationProperty(SoalAnnotations.Type, SoalAnnotationProperties.Sap, ((AnnotatedElementBuilder)originalType), SoalAnnotations.Element, SoalAnnotationProperties.Sap, prop);
                                }
                            }
                        }
                    }

                }
            }
        }

        internal static AnnotationBuilder CloneAnnotation(AnnotationBuilder annot)
        {
            SoalFactory f = new Symbols.SoalFactory(annot.MModel);
            AnnotationBuilder toAnnot = f.Annotation();
            toAnnot.Name = annot.Name;
            foreach (var annotProp in annot.Properties)
            {
                AnnotationPropertyBuilder toAnnotProp = f.AnnotationProperty();
                toAnnotProp.Name = annotProp.Name;
                toAnnotProp.Value = annotProp.Value;
                toAnnot.Properties.Add(toAnnotProp);
            }
            return toAnnot;
        }

        internal static void CopyAnnotationProperty(string annotationName, string propertyName, AnnotatedElementBuilder from, AnnotatedElementBuilder to)
        {
            foreach (var annot in from.Annotations)
            {
                if (annot.Name == annotationName)
                {
                    AnnotationPropertyBuilder annotProp = annot.Properties.FirstOrDefault(prop => prop.Name == propertyName);
                    if (annotProp != null)
                    {
                        to.SetAnnotationPropertyValue(annotationName, propertyName, annotProp.Value);
                    }
                }
            }
        }

        internal static void CopyAnnotationProperty(string annotationName, string propertyName, AnnotatedElementBuilder from, string targetAnnotationName, string targetPropertyName, AnnotatedElementBuilder to)
        {
            foreach (var annot in from.Annotations)
            {
                if (annot.Name == annotationName)
                {
                    AnnotationPropertyBuilder annotProp = annot.Properties.FirstOrDefault(prop => prop.Name == propertyName);
                    if (annotProp != null)
                    {
                        to.SetAnnotationPropertyValue(targetAnnotationName, targetPropertyName, annotProp.Value);
                    }
                }
            }
        }

        internal static void CopyAnnotation(string name, AnnotatedElementBuilder from, AnnotatedElementBuilder to)
        {
            if (from == null) return;
            if (to == null) return;
            SoalFactory f = new Symbols.SoalFactory(to.MModel);
            foreach (var annot in from.Annotations)
            {
                if (annot.Name == name)
                {
                    AnnotationBuilder toAnnot = f.Annotation();
                    toAnnot.Name = annot.Name;
                    to.Annotations.Add(toAnnot);
                    foreach (var annotProp in annot.Properties)
                    {
                        AnnotationPropertyBuilder toAnnotProp = f.AnnotationProperty();
                        toAnnotProp.Name = annotProp.Name;
                        toAnnotProp.Value = annotProp.Value;
                        toAnnot.Properties.Add(toAnnotProp);
                    }
                }
            }
        }

        internal static void CopyAnnotations(AnnotatedElementBuilder from, AnnotatedElementBuilder to)
        {
            if (from == null) return;
            if (to == null) return;
            SoalFactory f = new Symbols.SoalFactory(to.MModel);
            foreach (var annot in from.Annotations)
            {
                AnnotationBuilder toAnnot = f.Annotation();
                toAnnot.Name = annot.Name;
                to.Annotations.Add(toAnnot);
                foreach (var annotProp in annot.Properties)
                {
                    AnnotationPropertyBuilder toAnnotProp = f.AnnotationProperty();
                    toAnnotProp.Name = annotProp.Name;
                    toAnnotProp.Value = annotProp.Value;
                    toAnnot.Properties.Add(toAnnotProp);
                }
            }
        }

    }
}
