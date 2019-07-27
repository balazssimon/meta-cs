using MetaDslx.Languages.Soal.Symbols;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace MetaDslx.Languages.Soal.Importer
{
    internal enum XsdTypeKind
    {
        Type,
        Element,
        Attribute
    }

    internal class XsdReader : XmlReader
    {
        public const int PhaseCount = 3;
        public const string XsdNamespace = "http://www.w3.org/2001/XMLSchema";
        private XNamespace xsd;
        private XNamespace tns;
        private List<XElement> definedElements;

        public XsdReader(SoalImporter importer, XElement root, string uri)
            : base(importer, root, uri)
        {
        }

        public override void CollectImportedFiles()
        {
            xsd = XsdReader.XsdNamespace;
            XAttribute tnsAttr = this.Root.Attribute("targetNamespace");
            if (tnsAttr != null)
            {
                tns = tnsAttr.Value;
                this.Namespace = this.Importer.CreateNamespace(this, tnsAttr.Value, null, Path.GetFileNameWithoutExtension(this.Uri));
            }
            else
            {
                tns = string.Empty;
                this.Namespace = this.Importer.CreateNamespace(this, string.Empty, null, Path.GetFileNameWithoutExtension(this.Uri));
            }
            foreach (var attr in this.Root.Attributes())
            {
                if (attr.IsNamespaceDeclaration && attr.Value == tns && string.IsNullOrEmpty(this.Namespace.Prefix))
                {
                    this.Namespace.Prefix = attr.Name.LocalName;
                }
            }
            definedElements = new List<XElement>();
            foreach (var elem in this.Root.Elements())
            {
                if (elem.Name.Namespace == xsd)
                {
                    if (elem.Name.LocalName == "import")
                    {
                        XAttribute locAttribute = elem.Attribute("schemaLocation");
                        if (locAttribute != null)
                        {
                            string location = locAttribute.Value;
                            this.Importer.ImportRelativeFile(this.Uri, location);
                        }
                        else
                        {
                            //this.Importer.AddError("Attribute 'schemaLocation' is missing from import.", this.Uri, this.GetTextSpan(elem));
                        }
                    }
                    else if (elem.Name.LocalName == "element")
                    {
                        //this.ImportPhase3Element(elem);
                    }
                    else if (elem.Name.LocalName == "attribute")
                    {
                        //this.ImportPhase3Attribute(elem);
                    }
                    else if (elem.Name.LocalName == "simpleType")
                    {
                        this.ImportPhase1SimpleType(elem, null, XsdTypeKind.Type, null, true);
                    }
                    else if (elem.Name.LocalName == "complexType")
                    {
                        this.ImportPhase1ComplexType(elem, null, XsdTypeKind.Type, null, true);
                    }
                    else
                    {
                        //this.Importer.AddError("Unexpected element.", this.Uri, this.GetTextSpan(elem));
                    }
                }
                else
                {
                    //this.Importer.AddError("Unexpected element.", this.Uri, this.GetTextSpan(elem));
                }
            }
            if (this.Namespace.Uri == string.Empty && this.Namespace.Declarations.Count == 0)
            {
                this.Importer.RemoveNamespace(this.Namespace);
            }
        }

        public override void LoadXsdFile(int phase)
        {
            //if (this.Importer.Diagnostics.HasErrors()) return;
            switch (phase)
            {
                case 0:
                    this.ImportPhase2();
                    break;
                case 1:
                    this.ImportPhase3();
                    break;
                case 2:
                    this.ImportPhase4();
                    break;
                default:
                    break;
            }
        }

        private void ImportPhase2()
        {
            if (tns == null) return;
            foreach (var elem in this.Root.Elements())
            {
                if (elem.Name.Namespace == xsd)
                {
                    if (elem.Name.LocalName == "element")
                    {
                        //this.ImportPhase3Element(elem);
                    }
                    else if (elem.Name.LocalName == "attribute")
                    {
                        //this.ImportPhase3Attribute(elem);
                    }
                    else if (elem.Name.LocalName == "simpleType")
                    {
                        SoalTypeBuilder type = this.Importer.XsdTypes.Get(elem);
                        if (type != null)
                        {
                            this.ImportPhase2SimpleType(type, elem);
                            PrimitiveTypeBuilder pt = type as PrimitiveTypeBuilder;
                            if (pt != null)
                            {
                                this.Importer.WsdlTypes.Register(this, this.tns + pt.Name, elem, pt, false);
                            }
                        }
                    }
                    else if (elem.Name.LocalName == "complexType")
                    {
                        StructBuilder type = this.Importer.XsdTypes.Get(elem) as StructBuilder;
                        if (type != null)
                        {
                            this.ImportPhase2ComplexType(type, elem);
                            this.Importer.WsdlTypes.Register(this, this.tns + type.Name, elem, type, false);
                        }
                    }
                }
            }
        }

        private void ImportPhase3()
        {
            if (tns == null) return;
            foreach (var elem in this.Root.Elements())
            {
                if (elem.Name.Namespace == xsd)
                {
                    if (elem.Name.LocalName == "element")
                    {
                        SoalTypeBuilder type = this.ImportPhase3Element(elem);
                        if (type != null)
                        {
                            XAttribute nameAttr = elem.Attribute("name");
                            if (nameAttr != null)
                            {
                                string name = nameAttr.Value;
                                this.Importer.WsdlElements.Register(this, this.tns + name, elem, type, false);
                            }
                        }
                    }
                    else if (elem.Name.LocalName == "attribute")
                    {
                        this.ImportPhase3Attribute(elem);
                    }
                    else if (elem.Name.LocalName == "simpleType")
                    {
                        //this.ImportPhase2SimpleType(elem, null);
                    }
                    else if (elem.Name.LocalName == "complexType")
                    {
                        //this.ImportPhase2ComplexType(elem, null);
                    }
                }
            }
        }

        private void ImportPhase4()
        {
            if (tns == null) return;
            foreach (var elem in definedElements)
            {
                if (elem.Name.LocalName == "simpleType")
                {
                    //this.ImportPhase3SimpleType(elem, null);
                }
                else if (elem.Name.LocalName == "complexType")
                {
                    SoalTypeBuilder mo = this.Importer.XsdTypes.Get(elem);
                    StructBuilder st = mo as StructBuilder;
                    if (st != null)
                    {
                        this.ImportPhase4ComplexType(st, elem);
                        this.Importer.AddRootType(st);
                    }
                }
                else if (elem.Name.LocalName == "element")
                {
                    SoalTypeBuilder mo = this.Importer.XsdElements.Get(elem);
                    StructBuilder st = mo as StructBuilder;
                    /*if (st == null)
                    {
                        st = this.Importer.GetReplacementType(mo) as Struct;
                    }*/
                    if (st != null)
                    {
                        this.ImportPhase4Element(st, elem);
                        this.Importer.AddRootType(st);
                    }
                }
            }
        }

        private string GetUniqueName(string name, bool allowRename)
        {
            if (allowRename && this.Importer.ResolveXsdType(this.tns + name) != null)
            {
                int counter = 1;
                while (this.Importer.ResolveXsdType(this.tns + (name + counter)) != null)
                {
                    ++counter;
                }
                return name + counter;
            }
            return name;
        }
        
        private string GetNewEnumLiteralName(EnumBuilder enm, string literal)
        {
            if (literal == null) return literal;
            if (enm == null) return literal;
            if (!string.IsNullOrEmpty(literal) && !Regex.IsMatch(literal, @"[a-zA-Z_].*"))
            {
                literal = "_" + literal;
            }
            StringBuilder sb = new StringBuilder();
            foreach (var ch in literal)
            {
                if ((ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z') || (ch >= '0' && ch <= '9') || ch == '_')
                {
                    sb.Append(ch);
                }
                else
                {
                    sb.Append('_');
                }
            }
            string value = sb.ToString();
            string newValue = value;
            int counter = 1;
            if (string.IsNullOrEmpty(newValue))
            {
                value = "Value";
                newValue = value + counter;
            }
            while (enm.EnumLiterals.Any(l => l.Name == newValue))
            {
                ++counter;
                newValue = value + counter;
            }
            return newValue;
        }

        private string GetNewPropertyName(StructBuilder st, string name)
        {
            if (name == null) return name;
            if (st == null) return name;
            if (!string.IsNullOrEmpty(name) && !Regex.IsMatch(name, @"[a-zA-Z_].*"))
            {
                name = "_" + name;
            }
            StringBuilder sb = new StringBuilder();
            foreach (var ch in name)
            {
                if ((ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z') || (ch >= '0' && ch <= '9') || ch == '_')
                {
                    sb.Append(ch);
                }
                else
                {
                    sb.Append('_');
                }
            }
            string value = sb.ToString();
            string newValue = value;
            int counter = 1;
            if (string.IsNullOrEmpty(newValue))
            {
                value = "Value";
                newValue = value + counter;
            }
            while (st.Properties.Any(p => p.Name == newValue))
            {
                ++counter;
                newValue = value + counter;
            }
            return newValue;
        }

        private SoalTypeBuilder ImportPhase1SimpleType(XElement elem, string name, XsdTypeKind kind, XElement parentElem, bool register)
        {
            XAttribute nameAttr = elem.Attribute("name");
            XAttribute typeAttr = elem.Attribute("type");
            if (nameAttr != null)
            {
                name = nameAttr.Value;
            }
            if (name == null)
            {
                this.Importer.AddError("The simpleType has no name.", this.Uri, this.GetLinePositionSpan(elem));
                return null;
            }
            XElement restriction = elem.Element(xsd + "restriction");
            if (restriction != null)
            {
                XAttribute baseAttr = restriction.Attribute("base");
                if (baseAttr != null)
                {
                    XName baseRef = this.GetXName(restriction, baseAttr.Value);
                    if (baseRef == null)
                    {
                        this.Importer.AddError("Invalid base type: '" + baseAttr.Value + "'", this.Uri, this.GetLinePositionSpan(baseAttr));
                        return null;
                    }
                    bool stringBased = baseRef.Namespace == xsd && baseRef.LocalName == "string";
                    IEnumerable<XElement> enums = restriction.Elements(xsd + "enumeration");
                    if (stringBased && enums.Any())
                    {
                        EnumBuilder enm = this.Factory.Enum();
                        //name = this.GetUniqueName(name, element);
                        if (!register || (kind == XsdTypeKind.Type && this.Importer.XsdTypes.Register(this, tns + name, elem, enm) != null) ||
                            (kind == XsdTypeKind.Element && this.Importer.XsdElements.Register(this, tns + name, parentElem, enm) != null) ||
                            (kind == XsdTypeKind.Attribute && this.Importer.XsdAttributes.Register(this, tns + name, parentElem, enm) != null))
                        {
                            if (register)
                            {
                                if (kind == XsdTypeKind.Type)
                                {
                                    this.definedElements.Add(elem);
                                }
                                else
                                {
                                    this.definedElements.Add(parentElem);
                                }
                            }
                            enm.Name = name;
                            enm.Namespace = this.Namespace;
                            return enm;
                        }
                        else
                        {
                            this.Model.RemoveSymbol(enm);
                        }
                    }
                }
                else
                {
                    this.Importer.AddWarning("The restriction has no 'base' attribute.", this.Uri, this.GetLinePositionSpan(restriction));
                }
            }
            else
            {
                this.Importer.AddWarning("The importer of this element is not implemented.", this.Uri, this.GetLinePositionSpan(elem));
            }
            PrimitiveTypeBuilder type = this.Factory.PrimitiveType();
            type.Name = name;
            type.Namespace = this.Namespace;
            if (register)
            {
                switch (kind)
                {
                    case XsdTypeKind.Type:
                        return this.Importer.XsdTypes.Register(this, tns + name, elem, type);
                    case XsdTypeKind.Element:
                        return this.Importer.XsdElements.Register(this, tns + name, parentElem, type);
                    case XsdTypeKind.Attribute:
                        return this.Importer.XsdAttributes.Register(this, tns + name, parentElem, type);
                    default:
                        break;
                }
            }
            return type;
        }

        private SoalTypeBuilder ImportPhase1ComplexType(XElement elem, string name, XsdTypeKind kind, XElement parentElem, bool register)
        {
            XAttribute nameAttr = elem.Attribute("name");
            XAttribute typeAttr = elem.Attribute("type");
            if (nameAttr != null)
            {
                name = nameAttr.Value;
            }
            if (name == null)
            {
                this.Importer.AddError("The complexType has no name.", this.Uri, this.GetLinePositionSpan(elem));
                return null;
            }
            StructBuilder st = this.Factory.Struct();
            //name = this.GetUniqueName(name, element);
            if (!register || (kind == XsdTypeKind.Type && this.Importer.XsdTypes.Register(this, tns + name, elem, st) != null) ||
                (kind == XsdTypeKind.Element && this.Importer.XsdElements.Register(this, tns + name, parentElem, st) != null) ||
                (kind == XsdTypeKind.Attribute && this.Importer.XsdAttributes.Register(this, tns + name, parentElem, st) != null))
            {
                if (register)
                {
                    if (kind == XsdTypeKind.Type)
                    {
                        this.definedElements.Add(elem);
                    }
                    else
                    {
                        this.definedElements.Add(parentElem);
                    }
                }
                st.Name = name;
                st.Namespace = this.Namespace;
                XElement sequenceElem = elem.Element(xsd + "sequence");
                XElement choiceElem = elem.Element(xsd + "choice");
                XElement allElem = elem.Element(xsd + "all");
                XElement complexElem = null;
                if (sequenceElem != null)
                {
                    complexElem = sequenceElem;
                    List<XElement> children = sequenceElem.Elements(xsd + "element").ToList();
                    if (children.Count == 1)
                    {
                        XElement child = children[0];
                        XAttribute refAttr = child.Attribute("ref");
                        if (refAttr == null)
                        {
                            XAttribute nillableAttr = child.Attribute("nillable");
                            XAttribute minOccursAttr = child.Attribute("minOccurs");
                            XAttribute maxOccursAttr = child.Attribute("maxOccurs");
                            bool nillable = false;
                            int minOccurs = 1;
                            int maxOccurs = 1;
                            if (nillableAttr != null)
                            {
                                nillable = nillableAttr.Value == "1" || nillableAttr.Value.ToLower() == "true";
                            }
                            if (minOccursAttr != null)
                            {
                                if (!int.TryParse(minOccursAttr.Value, out minOccurs))
                                {
                                    minOccurs = 1;
                                }
                            }
                            if (maxOccursAttr != null)
                            {
                                if (maxOccursAttr.Value.ToLower() == "unbounded")
                                {
                                    maxOccurs = -1;
                                }
                                else if (!int.TryParse(maxOccursAttr.Value, out maxOccurs))
                                {
                                    maxOccurs = 1;
                                }
                            }
                            if (maxOccurs < 0 || maxOccurs > 1)
                            {
                                ArrayTypeBuilder array = this.Factory.ArrayType();
                                this.Importer.RegisterReplacementType(st, array);
                            }
                        }
                    }
                }
                else if (choiceElem != null)
                {
                    complexElem = choiceElem;
                }
                else if (allElem != null)
                {
                    complexElem = allElem;
                }
                else
                {
                    //this.Importer.AddError("The complexType has invalid content.", this.Uri, this.GetTextSpan(elem));
                    //return null;
                }
                return st;
            }
            else
            {
                this.Model.RemoveSymbol(st);
            }
            return null;
        }

        private SoalTypeBuilder ImportPhase2SimpleType(SoalTypeBuilder type, XElement elem)
        {
            XAttribute nameAttr = elem.Attribute("name");
            XAttribute typeAttr = elem.Attribute("type");
            XElement restriction = elem.Element(xsd + "restriction");
            if (restriction != null)
            {
                XAttribute baseAttr = restriction.Attribute("base");
                if (baseAttr != null)
                {
                    XName baseRef = this.GetXName(restriction, baseAttr.Value);
                    if (baseRef == null)
                    {
                        return null;
                    }
                    SoalTypeBuilder baseType = this.Importer.ResolveXsdType(baseRef);
                    if (baseType == null)
                    {
                        this.Importer.AddError("Could not resolve type '" + baseAttr.Value + "'.", this.Uri, this.GetLinePositionSpan(baseAttr));
                        return null;
                    }
                    EnumBuilder enm = type as EnumBuilder;
                    if (enm != null)
                    {
                        string name = enm.Name;
                        if (baseType is EnumBuilder)
                        {
                            enm.BaseType = (EnumBuilder)baseType;
                        }
                        IEnumerable<XElement> enums = restriction.Elements(xsd + "enumeration");
                        foreach (var enumValue in enums)
                        {
                            XAttribute valueAttr = enumValue.Attribute("value");
                            if (valueAttr != null)
                            {
                                string value = valueAttr.Value;
                                EnumLiteralBuilder enmLit = this.Factory.EnumLiteral();
                                string newValue = this.GetNewEnumLiteralName(enm, value);
                                enmLit.Name = newValue;
                                enm.EnumLiterals.Add(enmLit);
                                if (value != newValue)
                                {
                                    enmLit.SetAnnotationPropertyValue(SoalAnnotations.Enum, SoalAnnotationProperties.Name, value);
                                }
                            }
                            else
                            {
                                this.Importer.AddError("The enumeration has no 'value' attribute.", this.Uri, this.GetLinePositionSpan(restriction));
                                return null;
                            }
                        }
                        return enm;
                    }
                    else
                    {
                        SoalImporter.CopyAnnotations(baseType as AnnotatedElementBuilder, type as AnnotatedElementBuilder);
                        this.ProcessXsdRestriction(type, restriction, SoalAnnotationProperties.Pattern);
                        this.ProcessXsdRestriction(type, restriction, SoalAnnotationProperties.Length);
                        this.ProcessXsdRestriction(type, restriction, SoalAnnotationProperties.MinLength);
                        this.ProcessXsdRestriction(type, restriction, SoalAnnotationProperties.MaxLength);
                        this.ProcessXsdRestriction(type, restriction, SoalAnnotationProperties.MinInclusive);
                        this.ProcessXsdRestriction(type, restriction, SoalAnnotationProperties.MinExclusive);
                        this.ProcessXsdRestriction(type, restriction, SoalAnnotationProperties.MaxInclusive);
                        this.ProcessXsdRestriction(type, restriction, SoalAnnotationProperties.MaxExclusive);
                        this.ProcessXsdRestriction(type, restriction, SoalAnnotationProperties.TotalDigits);
                        this.ProcessXsdRestriction(type, restriction, SoalAnnotationProperties.FractionDigits);
                        this.Importer.RegisterReplacementType(type, baseType);
                        return type;
                    }
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        private void ProcessXsdRestriction(SoalTypeBuilder type, XElement elem, string restrictionName)
        {
            XElement restrElem = elem.Element(xsd + restrictionName);
            if (restrElem != null)
            {
                XAttribute valueAttr = restrElem.Attribute("value");
                if (valueAttr != null)
                {
                    AnnotatedElementBuilder ae = type as AnnotatedElementBuilder;
                    if (ae != null)
                    {
                        long longValue = 0;
                        if (restrictionName == SoalAnnotationProperties.Pattern)
                        {
                            ae.SetAnnotationPropertyValue(SoalAnnotations.Restriction, restrictionName, valueAttr.Value);
                        }
                        else if (long.TryParse(valueAttr.Value, out longValue))
                        {
                            ae.SetAnnotationPropertyValue(SoalAnnotations.Restriction, restrictionName, longValue);
                        }
                        else
                        {
                            ae.SetAnnotationPropertyValue(SoalAnnotations.Restriction, restrictionName, valueAttr.Value);
                        }
                    }
                }
            }
        }

        private SoalTypeBuilder ImportPhase2ComplexType(StructBuilder st, XElement elem)
        {
            if (st == null)
            {
                this.Importer.AddError("Type is missing for the element.", this.Uri, this.GetLinePositionSpan(elem));
                return null;
            }
            XElement complexContentElem = elem.Element(xsd + "complexContent");
            XElement simpleContentElem = elem.Element(xsd + "simpleContent");
            if (complexContentElem != null)
            {
                XElement restrictionElem = complexContentElem.Element(xsd + "restriction");
                XElement extensionElem = complexContentElem.Element(xsd + "extension");
                if (restrictionElem != null)
                {
                    XAttribute baseRef = restrictionElem.Attribute("base");
                    if (baseRef != null)
                    {
                        XName baseRefName = this.GetXName(restrictionElem, baseRef.Value);
                        SoalTypeBuilder type = this.Importer.XsdTypes.Get(baseRefName);
                        if (type == null)
                        {
                            type = this.Importer.ResolveXsdPrimitiveType(baseRefName);
                        }
                        if (type != null)
                        {
                            st.BaseType = type as StructBuilder;
                            if (st.BaseType == null)
                            {
                                this.Importer.RegisterReplacementType(st, type);
                            }
                            elem = extensionElem;
                        }
                        else
                        {
                            this.Importer.AddError("Could not resolve type '" + baseRef.Value + "'.", this.Uri, this.GetLinePositionSpan(baseRef));
                            return null;
                        }
                    }
                    else
                    {
                        this.Importer.AddError("The restriction has no 'base' attribute.", this.Uri, this.GetLinePositionSpan(restrictionElem));
                        return null;
                    }
                }
                else if (extensionElem != null)
                {
                    XAttribute baseRef = extensionElem.Attribute("base");
                    if (baseRef != null)
                    {
                        XName baseRefName = this.GetXName(extensionElem, baseRef.Value);
                        SoalTypeBuilder type = this.Importer.XsdTypes.Get(baseRefName);
                        if (type == null)
                        {
                            type = this.Importer.ResolveXsdPrimitiveType(baseRefName);
                        }
                        if (type != null)
                        {
                            st.BaseType = type as StructBuilder;
                            if (st.BaseType == null)
                            {
                                this.Importer.RegisterReplacementType(st, type);
                            }
                            elem = extensionElem;
                        }
                        else
                        {
                            this.Importer.AddError("Could not resolve type '" + baseRef.Value + "'.", this.Uri, this.GetLinePositionSpan(baseRef));
                            return null;
                        }
                    }
                    else
                    {
                        this.Importer.AddError("The extension has no 'base' attribute.", this.Uri, this.GetLinePositionSpan(extensionElem));
                        return null;
                    }
                }
                else
                {
                    this.Importer.AddError("Unsupported complex content.", this.Uri, this.GetLinePositionSpan(complexContentElem));
                }
            }
            else if (simpleContentElem != null)
            {
                XElement restrictionElem = simpleContentElem.Element(xsd + "restriction");
                XElement extensionElem = simpleContentElem.Element(xsd + "extension");
                if (restrictionElem != null)
                {
                    XAttribute baseRef = restrictionElem.Attribute("base");
                    if (baseRef != null)
                    {
                        XName baseRefName = this.GetXName(restrictionElem, baseRef.Value);
                        SoalTypeBuilder type = this.Importer.ResolveXsdType(baseRefName);
                        if (type != null)
                        {
                            this.Importer.RegisterReplacementType(st, type);
                            return type;
                        }
                        else
                        {
                            this.Importer.AddError("Could not resolve type '" + baseRef.Value + "'.", this.Uri, this.GetLinePositionSpan(baseRef));
                            return null;
                        }
                    }
                    else
                    {
                        this.Importer.AddError("The restriction has no 'base' attribute.", this.Uri, this.GetLinePositionSpan(restrictionElem));
                        return null;
                    }
                }
                else if (extensionElem != null)
                {
                    XAttribute baseRef = extensionElem.Attribute("base");
                    if (baseRef != null)
                    {
                        XName baseRefName = this.GetXName(extensionElem, baseRef.Value);
                        SoalTypeBuilder type = this.Importer.ResolveXsdType(baseRefName);
                        if (type != null)
                        {
                            this.Importer.RegisterReplacementType(st, type);
                            this.Importer.AddWarning("Simple content extension is not supported.", this.Uri, this.GetLinePositionSpan(extensionElem));
                            return type;
                        }
                        else
                        {
                            this.Importer.AddError("Could not resolve type '" + baseRef.Value + "'.", this.Uri, this.GetLinePositionSpan(baseRef));
                            return null;
                        }
                    }
                    else
                    {
                        this.Importer.AddError("The extension has no 'base' attribute.", this.Uri, this.GetLinePositionSpan(extensionElem));
                        return null;
                    }
                }
                else
                {
                    this.Importer.AddError("Unsupported simple content.", this.Uri, this.GetLinePositionSpan(complexContentElem));
                }
            }
            return st;
        }

        private SoalTypeBuilder ImportPhase3Element(XElement elem)
        {
            SoalTypeBuilder result = null;
            XAttribute nameAttr = elem.Attribute("name");
            XAttribute typeAttr = elem.Attribute("type");
            string name = null;
            if (nameAttr != null)
            {
                name = nameAttr.Value;
            }
            if (name == null)
            {
                this.Importer.AddError("The element has no name.", this.Uri, this.GetLinePositionSpan(elem));
                return null;
            }
            if (typeAttr == null)
            {
                XElement simpleType = elem.Element(xsd + "simpleType");
                XElement complexType = elem.Element(xsd + "complexType");
                if (simpleType != null)
                {
                    result = this.ImportPhase1SimpleType(simpleType, name, XsdTypeKind.Element, elem, true);
                    result = this.ImportPhase2SimpleType(result, simpleType);
                }
                else if (complexType != null)
                {
                    result = this.ImportPhase1ComplexType(complexType, name, XsdTypeKind.Element, elem, true);
                    StructBuilder cst = result as StructBuilder;
                    if (cst != null)
                    {
                        this.ImportPhase2ComplexType(cst, complexType);
                    }
                }
                else
                {
                    this.Importer.AddError("The element has no type.", this.Uri, this.GetLinePositionSpan(elem));
                    return null;
                }
            }
            else
            {
                XName typeRef = this.GetXName(elem, typeAttr.Value);
                if (typeRef == null)
                {
                    this.Importer.AddError("Invalid type reference: '" + typeAttr.Value + "'", this.Uri, this.GetLinePositionSpan(typeAttr));
                    return null;
                }
                result = this.Importer.XsdTypes.Get(typeRef) as SoalTypeBuilder;
                if (result == null)
                {
                    result = this.Importer.ResolveXsdPrimitiveType(typeRef);
                }
                if (result == null)
                {
                    this.Importer.AddError("Could not resolve type '" + typeAttr.Value + "'.", this.Uri, this.GetLinePositionSpan(typeAttr));
                    return null;
                }
                XAttribute nillableAttr = elem.Attribute("nillable");
                XAttribute minOccursAttr = elem.Attribute("minOccurs");
                XAttribute maxOccursAttr = elem.Attribute("maxOccurs");
                bool nillable = false;
                int minOccurs = 1;
                int maxOccurs = 1;
                if (nillableAttr != null)
                {
                    nillable = nillableAttr.Value == "1" || nillableAttr.Value.ToLower() == "true";
                }
                if (minOccursAttr != null)
                {
                    if (!int.TryParse(minOccursAttr.Value, out minOccurs))
                    {
                        minOccurs = 1;
                    }
                }
                if (maxOccursAttr != null)
                {
                    if (maxOccursAttr.Value.ToLower() == "unbounded")
                    {
                        maxOccurs = -1;
                    }
                    else if (!int.TryParse(maxOccursAttr.Value, out maxOccurs))
                    {
                        maxOccurs = 1;
                    }
                }
                if (maxOccurs < 0 || maxOccurs > 1)
                {
                    ArrayTypeBuilder array = this.Factory.ArrayType();
                    array.InnerType = result;
                    result = array;
                }
                PrimitiveTypeBuilder type = this.Factory.PrimitiveType();
                type.Name = this.GetUniqueName(name, true);
                type.Namespace = this.Namespace;
                this.Importer.XsdElements.Register(this, tns + name, elem, type);
                this.Importer.RegisterReplacementType(type, result);
            }
            return result;
        }

        private SoalTypeBuilder ImportPhase3Attribute(XElement elem)
        {
            SoalTypeBuilder result = null;
            XAttribute nameAttr = elem.Attribute("name");
            XAttribute typeAttr = elem.Attribute("type");
            string name = null;
            if (nameAttr != null)
            {
                name = nameAttr.Value;
            }
            if (name == null)
            {
                this.Importer.AddError("The attribute has no name.", this.Uri, this.GetLinePositionSpan(elem));
                return null;
            }
            if (typeAttr == null)
            {
                XElement simpleType = elem.Element(xsd + "simpleType");
                XElement complexType = elem.Element(xsd + "complexType");
                if (simpleType != null)
                {
                    result = this.ImportPhase1SimpleType(simpleType, name, XsdTypeKind.Attribute, elem, true);
                    result = this.ImportPhase2SimpleType(result, simpleType);
                }
                else if (complexType != null)
                {
                    result = this.ImportPhase1ComplexType(complexType, name, XsdTypeKind.Attribute, elem, true);
                    StructBuilder cst = result as StructBuilder;
                    if (cst != null)
                    {
                        this.ImportPhase2ComplexType(cst, complexType);
                    }
                }
                else
                {
                    this.Importer.AddError("The attribute has no type.", this.Uri, this.GetLinePositionSpan(elem));
                    return null;
                }
            }
            else
            {
                XName typeRef = this.GetXName(elem, typeAttr.Value);
                if (typeRef == null)
                {
                    this.Importer.AddError("Invalid type reference: '" + typeAttr.Value + "'", this.Uri, this.GetLinePositionSpan(typeAttr));
                    return null;
                }
                result = this.Importer.XsdTypes.Get(typeRef) as SoalTypeBuilder;
                if (result == null)
                {
                    result = this.Importer.ResolveXsdPrimitiveType(typeRef);
                }
                if (result != null)
                {
                    PrimitiveTypeBuilder type = this.Factory.PrimitiveType();
                    type.Name = this.GetUniqueName(name, true);
                    type.Namespace = this.Namespace;
                    this.Importer.XsdAttributes.Register(this, tns + name, elem, type);
                    this.Importer.RegisterReplacementType(type, result);
                }
                else
                {
                    this.Importer.AddError("Could not resolve type '" + typeAttr.Value + "'.", this.Uri, this.GetLinePositionSpan(typeAttr));
                    return null;
                }
            }
            return result;
        }

        private SoalTypeBuilder ImportPhase4Element(StructBuilder st, XElement elem)
        {
            SoalTypeBuilder result = st;
            XAttribute nameAttr = elem.Attribute("name");
            XAttribute typeAttr = elem.Attribute("type");
            string name = null;
            if (nameAttr != null)
            {
                name = nameAttr.Value;
            }
            if (name == null)
            {
                this.Importer.AddError("The element has no name.", this.Uri, this.GetLinePositionSpan(elem));
                return null;
            }
            if (typeAttr == null)
            {
                XElement simpleType = elem.Element(xsd + "simpleType");
                XElement complexType = elem.Element(xsd + "complexType");
                if (simpleType != null)
                {
                }
                else if (complexType != null)
                {
                    this.ImportPhase4ComplexType(st, complexType);
                }
                else
                {
                }
            }
            return result;
        }

        private SoalTypeBuilder ImportPhase4ComplexType(StructBuilder st, XElement elem)
        {
            if (st == null)
            {
                this.Importer.AddError("Type is missing for the element.", this.Uri, this.GetLinePositionSpan(elem));
                return null;
            }
            string name = st.Name;
            XElement complexContentElem = elem.Element(xsd + "complexContent");
            XElement simpleContentElem = elem.Element(xsd + "simpleContent");
            if (complexContentElem != null)
            {
                XElement restrictionElem = complexContentElem.Element(xsd + "restriction");
                XElement extensionElem = complexContentElem.Element(xsd + "extension");
                if (restrictionElem != null)
                {
                    return st;
                }
                else if (extensionElem != null)
                {
                    XAttribute baseRef = extensionElem.Attribute("base");
                    if (baseRef != null)
                    {
                        XName baseRefName = this.GetXName(extensionElem, baseRef.Value);
                        SoalTypeBuilder type = this.Importer.ResolveXsdType(baseRefName);
                        if (type != null)
                        {
                            elem = extensionElem;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    // nop
                }
            }
            else if (simpleContentElem != null)
            {
                XElement restrictionElem = simpleContentElem.Element(xsd + "restriction");
                XElement extensionElem = simpleContentElem.Element(xsd + "extension");
                if (restrictionElem != null)
                {
                    return null;
                }
                else if (extensionElem != null)
                {
                    return null;
                }
                else
                {
                    return null;
                }
            }
            XElement sequenceElem = elem.Element(xsd + "sequence");
            XElement choiceElem = elem.Element(xsd + "choice");
            XElement allElem = elem.Element(xsd + "all");
            XElement complexElem = null;
            if (sequenceElem != null)
            {
                complexElem = sequenceElem;
            }
            else if (choiceElem != null)
            {
                complexElem = choiceElem;
                st.AddAnnotation(SoalAnnotations.Choice);
            }
            else if (allElem != null)
            {
                complexElem = allElem;
                st.AddAnnotation(SoalAnnotations.All);
            }
            SoalTypeBuilder rt = this.Importer.ResolveXsdReplacementType(st);
            if (complexElem != null)
            {
                foreach (var child in complexElem.Elements())
                {
                    if (child.Name.Namespace == xsd)
                    {
                        if (child.Name.LocalName == "element")
                        {
                            this.ImportPhase4ElementProperty(st, rt, child, false);
                        }
                    }
                }
            }
            foreach (var child in elem.Elements())
            {
                if (child.Name.Namespace == xsd)
                {
                    if (child.Name.LocalName == "attribute")
                    {
                        this.ImportPhase4ElementProperty(st, rt, child, true);
                    }
                }
            }
            return st;
        }

        private PropertyBuilder ImportPhase4ElementProperty(StructBuilder st, SoalTypeBuilder rt, XElement elem, bool attribute)
        {
            XAttribute refAttr = elem.Attribute("ref");
            XAttribute nameAttr = elem.Attribute("name");
            XAttribute typeAttr = elem.Attribute("type");
            bool required = false;
            XAttribute useAttr = elem.Attribute("use");
            if (useAttr != null && useAttr.Value == "required")
            {
                required = true;
            }
            bool sap = false;
            ArrayTypeBuilder sapArray = null;
            string sapName = null;
            string name = null;
            SoalTypeBuilder type = null;
            if (refAttr != null)
            {
                XName refName = this.GetXName(elem, refAttr.Value);
                XElement originalElem = null;
                if (refName != null)
                {
                    if (attribute)
                    {
                        originalElem = this.Importer.XsdAttributes.GetX(refName);
                    }
                    else
                    {
                        originalElem = this.Importer.XsdElements.GetX(refName);
                    }
                }
                if (originalElem != null)
                {
                    name = refName.LocalName;
                    if (attribute)
                    {
                        type = this.Importer.XsdAttributes.Get(refName);
                        useAttr = originalElem.Attribute("use");
                        if (useAttr != null && useAttr.Value == "required")
                        {
                            required = true;
                        }
                    }
                    else
                    {
                        type = this.Importer.XsdElements.Get(refName);
                    }
                    if (type == null)
                    {
                        this.Importer.AddError("Could not resolve type '" + refAttr.Value + "'.", this.Uri, this.GetLinePositionSpan(refAttr));
                        return null;
                    }
                }
                else
                { 
                    this.Importer.AddError("Could not resolve the reference.", this.Uri, this.GetLinePositionSpan(refAttr));
                    return null;
                }
            }
            else
            {
                if (nameAttr != null)
                {
                    name = nameAttr.Value;
                }
                if (name == null)
                {
                    this.Importer.AddError("The element has no name.", this.Uri, this.GetLinePositionSpan(elem));
                    return null;
                }
                if (typeAttr == null)
                {
                    XElement simpleType = elem.Element(xsd + "simpleType");
                    XElement complexType = elem.Element(xsd + "complexType");
                    string typeName = this.GetUniqueName(name, true);
                    if (simpleType != null)
                    {
                        type = this.ImportPhase1SimpleType(simpleType, typeName, attribute ? XsdTypeKind.Attribute : XsdTypeKind.Element, elem, false);
                        type = this.ImportPhase2SimpleType(type, simpleType);
                    }
                    else if (complexType != null)
                    {
                        type = this.ImportPhase1ComplexType(complexType, typeName, attribute ? XsdTypeKind.Attribute : XsdTypeKind.Element, elem, false);
                        StructBuilder childSt = type as StructBuilder;
                        if (childSt != null)
                        {
                            type = this.ImportPhase2ComplexType(childSt, complexType);
                            childSt = type as StructBuilder;
                            if (childSt != null)
                            {
                                type = this.ImportPhase4ComplexType(childSt, complexType);
                                childSt = type as StructBuilder;
                                if (name == "item" && childSt != null && childSt.HasAnnotation(SoalAnnotations.All) && childSt.Properties.Count == 1)
                                {
                                    SoalTypeBuilder innerType = childSt.Properties[0].Type;
                                    if (innerType.IsArrayType())
                                    {
                                    }
                                    else
                                    {
                                        sap = true;
                                        sapName = childSt.Properties[0].Name;
                                        sapArray = this.Factory.ArrayType();
                                        sapArray.InnerType = innerType;
                                        //this.Importer.RegisterReplacementType(type, sapArray);
                                        this.Importer.RemoveType(type);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        this.Importer.AddError("The element has no type.", this.Uri, this.GetLinePositionSpan(elem));
                        return null;
                    }
                }
                else
                {
                    XName typeRef = this.GetXName(elem, typeAttr.Value);
                    if (typeRef == null)
                    {
                        this.Importer.AddError("Invalid type reference: '" + typeAttr.Value + "'", this.Uri, this.GetLinePositionSpan(typeAttr));
                        return null;
                    }
                    type = this.Importer.XsdTypes.Get(typeRef) as SoalTypeBuilder;
                    if (type == null)
                    {
                        type = this.Importer.ResolveXsdPrimitiveType(typeRef) as SoalTypeBuilder;
                    }
                    if (type == null)
                    {
                        this.Importer.AddError("Could not resolve type '" + typeAttr.Value + "'.", this.Uri, this.GetLinePositionSpan(typeAttr));
                        return null;
                    }
                }
            }
            SoalTypeBuilder originalType = type;
            type = this.Importer.ResolveXsdReplacementType(type);
            XAttribute nillableAttr = elem.Attribute("nillable");
            XAttribute minOccursAttr = elem.Attribute("minOccurs");
            XAttribute maxOccursAttr = elem.Attribute("maxOccurs");
            bool nillable = false;
            int minOccurs = 1;
            int maxOccurs = 1;
            if (nillableAttr != null)
            {
                nillable = nillableAttr.Value == "1" || nillableAttr.Value.ToLower() == "true";
            }
            if (minOccursAttr != null)
            {
                if (!int.TryParse(minOccursAttr.Value, out minOccurs))
                {
                    minOccurs = 1;
                }
            }
            if (maxOccursAttr != null)
            {
                if (maxOccursAttr.Value.ToLower() == "unbounded")
                {
                    maxOccurs = -1;
                }
                else if (!int.TryParse(maxOccursAttr.Value, out maxOccurs))
                {
                    maxOccurs = 1;
                }
            }
            if (type is PrimitiveTypeBuilder)
            {
                if (nillable && type.MId != SoalInstance.Object.MId && type.MId != SoalInstance.String.MId)
                {
                    NullableTypeBuilder nullable = this.Factory.NullableType();
                    nullable.InnerType = type;
                    type = nullable;
                }
                else if (!nillable && (type.MId == SoalInstance.Object.MId || type.MId == SoalInstance.String.MId))
                {
                    NonNullableTypeBuilder nonNull = this.Factory.NonNullableType();
                    nonNull.InnerType = type;
                    type = nonNull;
                }
            }
            else
            {
                if (!nillable)
                {
                    NonNullableTypeBuilder nonNull = this.Factory.NonNullableType();
                    nonNull.InnerType = type;
                    type = nonNull;
                }
            }
            PropertyBuilder prop = this.Factory.Property();
            string newName = this.GetNewPropertyName(st, name);
            prop.Name = newName;
            if (attribute)
            {
                prop.Type = type;
                AnnotationBuilder attrAnnot = prop.AddAnnotation(SoalAnnotations.Attribute);
                if (required)
                {
                    attrAnnot.SetPropertyValue(SoalAnnotationProperties.Required, true);
                }
                if (newName != name)
                {
                    attrAnnot.SetPropertyValue(SoalAnnotationProperties.Name, name);
                }
            }
            else
            {
                if (newName != name)
                {
                    AnnotationBuilder elemAnnot = prop.AddAnnotation(SoalAnnotations.Element);
                    elemAnnot.SetPropertyValue(SoalAnnotationProperties.Name, name);
                }
                if (rt != null && rt is ArrayTypeBuilder)
                {
                    if (sap)
                    {
                        ((ArrayTypeBuilder)rt).InnerType = sapArray.InnerType;
                        this.Importer.RegisterReplacementType(type, rt);
                        AnnotationBuilder arrayAnnot = st.AddAnnotation(SoalAnnotations.Type);
                        arrayAnnot.SetPropertyValue(SoalAnnotationProperties.Wrapped, true);
                        arrayAnnot.SetPropertyValue(SoalAnnotationProperties.Items, sapName);
                        arrayAnnot.SetPropertyValue(SoalAnnotationProperties.Sap, true);
                    }
                    else
                    {
                        if (type.IsArrayType())
                        {
                            type = originalType;
                            this.Importer.Reference(type);
                        }
                        ((ArrayTypeBuilder)rt).InnerType = type;
                        SoalTypeBuilder coreType = type.GetCoreType();
                        AnnotationBuilder arrayAnnot = st.AddAnnotation(SoalAnnotations.Type);
                        arrayAnnot.SetPropertyValue(SoalAnnotationProperties.Wrapped, true);
                        if (coreType is NamedElementBuilder && ((NamedElementBuilder)coreType).Name != prop.Name)
                        {
                            arrayAnnot.SetPropertyValue(SoalAnnotationProperties.Items, prop.Name);
                        }
                    }
                    prop.Type = rt;
                }
                else
                {
                    if (maxOccurs < 0 || maxOccurs > 1)
                    {
                        ArrayTypeBuilder array = this.Factory.ArrayType();
                        array.InnerType = type;
                        type = array;
                    }
                    prop.Type = type;
                }
                if (minOccurs == 0 && maxOccurs == 1)
                {
                    prop.SetAnnotationPropertyValue(SoalAnnotations.Element, SoalAnnotationProperties.Optional, true);
                }
            }
            this.Importer.RegisterOriginalType(prop, originalType);
            st.Properties.Add(prop);
            return prop;
        }
    }
}