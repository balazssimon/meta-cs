using MetaDslx.Languages.Uml.Model;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace MetaDslx.Languages.Uml.Serialization
{
    public class WhiteStarUmlSerializer
    {
        public ImmutableModel ReadModelFromFile(string filePath, out ImmutableArray<Diagnostic> diagnostics)
        {
            if (filePath == null) throw new ArgumentNullException(nameof(filePath));
            var umlCode = File.ReadAllText(filePath);
            return this.ReadModel(filePath, umlCode, out diagnostics);
        }

        public ImmutableModel ReadModel(string umlCode, out ImmutableArray<Diagnostic> diagnostics)
        {
            if (umlCode == null) throw new ArgumentNullException(nameof(umlCode));
            return this.ReadModel(string.Empty, umlCode, out diagnostics);
        }

        protected ImmutableModel ReadModel(string filePath, string umlCode, out ImmutableArray<Diagnostic> diagnostics)
        {
            if (umlCode == null) throw new ArgumentNullException(nameof(umlCode));
            var reader = new WhiteStarUmlReader(filePath, umlCode);
            reader.ReadModel();
            diagnostics = reader.Diagnostics.ToReadOnly();
            return reader.Model.ToImmutable();
        }
    }

    internal class WhiteStarUmlReader
    {
        private static readonly XNamespace _whiteStarUmlNamespace = "http://www.staruml.com";
        private string _fileUri;
        private string _umlCode;
        private XElement _body;
        private MutableModel _model;
        private UmlFactory _factory;
        private DiagnosticBag _diagnostics;
        private Dictionary<string, MutableObjectBase> _objectsById;
        private Dictionary<(int, int), MutableObjectBase> _objectsByPosition;
        private Dictionary<string, PrimitiveTypeBuilder> _primitiveTypes;

        public WhiteStarUmlReader(string fileUri, string umlCode)
        {
            _fileUri = fileUri;
            _umlCode = umlCode;
            _model = new MutableModel();
            ((MutableModel)_model).Name = _fileUri;
            _factory = new UmlFactory(_model, ModelFactoryFlags.DontMakeObjectsCreated);
            _diagnostics = new DiagnosticBag();
            _objectsById = new Dictionary<string, MutableObjectBase>();
            _objectsByPosition = new Dictionary<(int, int), MutableObjectBase>();
            _primitiveTypes = new Dictionary<string, PrimitiveTypeBuilder>();
        }

        public MutableModel Model => _model;
        public DiagnosticBag Diagnostics => _diagnostics;

        internal Location GetLocation(XObject xobj)
        {
            if (xobj == null) return Location.None;
            IXmlLineInfo info = xobj;
            var lineSpan = new LinePositionSpan(new LinePosition(info.LineNumber - 1, info.LinePosition - 1), new LinePosition(info.LineNumber - 1, info.LinePosition - 1));
            return new ExternalFileLocation(_fileUri ?? string.Empty, new TextSpan(), lineSpan);
        }

        internal void AddError(XObject location, string message)
        {
            _diagnostics.Add(ModelErrorCode.ERR_XmiError.ToDiagnostic(GetLocation(location), message));
        }

        internal void AddError(XObject location, ModelException mex)
        {
            _diagnostics.Add(ModelErrorCode.ERR_XmiError.ToDiagnostic(GetLocation(location), mex.Diagnostic.GetMessage()));
        }

        public void ReadModel()
        {
            this.CreateObjects();
            this.ReadObjects();
            this.PostProcessObjects();
            foreach (var mobj in _model.Objects)
            {
                mobj.MMakeCreated();
            }
        }

        private void CreateObjects()
        {
            var document = XDocument.Parse(_umlCode, LoadOptions.SetBaseUri | LoadOptions.SetLineInfo);
            var root = document.Root;
            if (root.Name.LocalName != "PROJECT" || root.Name.Namespace != _whiteStarUmlNamespace)
            {
                this.AddError(root, "The root must be an xpd:PROJECT tag.");
            }
            _body = root.Element(_whiteStarUmlNamespace + "BODY");
            if (_body != null)
            {
                this.CreateObject(_body, null);
            }
            else
            {
                this.AddError(root, "The root must have an xpd:OBJECT child tag.");
            }
        }

        private void ReadObjects()
        {
            if (_body != null)
            {
                this.ReadObject(_body, null);
            }
        }

        private void PostProcessObjects()
        {
            foreach (var prop in _model.Objects.OfType<PropertyBuilder>())
            {
                if (prop.Class == null && prop.Association != null)
                {
                    prop.Association.OwnedEnd.Add(prop);
                }
            }
        }

        private void CreateObject(XElement element, MutableObjectBase parent)
        {
            if (IgnoreElement(element)) return;
            MutableObjectBase obj = null;
            if (element.Name.LocalName == "OBJ" && element.Name.Namespace == _whiteStarUmlNamespace)
            {
                XAttribute nameAttribute = element.Attribute("name");
                XAttribute guidAttribute = element.Attribute("guid");
                var typeName = GetTypeName(element);
                if (!SkipTypeName(typeName))
                {
                    try
                    {
                        obj = (MutableObjectBase)_factory.Create(typeName);
                    }
                    catch (ModelException mex)
                    {
                        this.AddError(element, mex);
                    }
                    if (obj != null)
                    {
                        this.RegisterObjectByPosition(element, obj);
                        if (guidAttribute != null)
                        {
                            string id = guidAttribute.Value;
                            this.RegisterObjectById(guidAttribute, id, obj);
                        }
                    }
                }
                if (parent != null)
                {
                    string parentPropertyName = GetPropertyName(parent.MMetaClass.Name, nameAttribute?.Value);
                    if (parentPropertyName != null)
                    {
                        if (!HandleSpecialChild(element, parent, parentPropertyName, obj) && obj != null)
                        {
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
                                foreach (var nameProp in obj.MAllProperties.Where(p => p.IsName))
                                {
                                    var nameAttr = element.Elements(_whiteStarUmlNamespace + "ATTR").Where(e => e.Attribute("name")?.Value == nameProp.Name).FirstOrDefault();
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
                            }
                            else
                            {
                                this.AddError(element, $"Model object '{parent.MName}' ({parent.MMetaClass.Name}) has no '{parentPropertyName}' property.");
                            }
                        }
                    }
                }
            }
            foreach (var child in element.Elements())
            {
                this.CreateObject(child, SkipElement(element) ? parent : obj);
            }
        }

        private string GetTypeName(XElement element)
        {
            XAttribute typeAttribute = element.Attribute("type");
            var typeName = typeAttribute?.Value;
            if (typeName == null) return null;
            if (typeName.StartsWith("UML")) typeName = typeName.Substring(3);
            if (UmlTypeMap.TryGetValue(typeName, out var newTypeName))
            {
                typeName = newTypeName;
            }
            var stereotypes = element.Elements(_whiteStarUmlNamespace + "ATTR").Where(e => e.Attribute("name")?.Value == "StereotypeName");
            foreach (var stereotype in stereotypes)
            {
                if (typeName == "Class" && stereotype.Value == "interface")
                {
                    return "Interface";
                }
                else if (typeName == "Dependency" && stereotype.Value == "includes")
                {
                    return "Include";
                }
                else if (typeName == "Dependency" && stereotype.Value == "extends")
                {
                    return "Extend";
                }
            }
            return typeName;
        }

        private bool HasStereotype(XElement element, string stereotypeName)
        {
            var stereotypes = element.Elements(_whiteStarUmlNamespace + "ATTR").Where(e => e.Attribute("name")?.Value == "StereotypeName");
            return stereotypes.Any(st => st.Value == stereotypeName);
        }

        private bool SkipElement(XElement element)
        {
            if (element.Name.LocalName == "OBJ" && element.Name.Namespace == _whiteStarUmlNamespace)
            {
                var typeName = GetTypeName(element);
                return SkipTypeName(typeName);
            }
            return false;
        }

        private bool SkipTypeName(string typeName)
        {
            if (typeName == null) return true;
            if (UmlSkippedTypes.Contains(typeName)) return true;
            return false;
        }

        private bool IgnoreElement(XElement element)
        {
            if (element.Name.LocalName == "OBJ" && element.Name.Namespace == _whiteStarUmlNamespace)
            {
                var typeName = GetTypeName(element);
                return IgnoreTypeName(typeName);
            }
            return false;
        }

        private bool IgnoreTypeName(string typeName)
        {
            if (typeName == null) return true;
            if (typeName.EndsWith("View")) return true;
            if (UmlIgnoredTypes.Contains(typeName)) return true;
            return false;
        }

        private string GetPropertyName(string typeName, string propertyName)
        {
            if (typeName == null) return null;
            if (propertyName == null) return null;
            if (propertyName.StartsWith("#")) return null;
            int openBracketIndex = propertyName.IndexOf('[');
            if (openBracketIndex >= 0)
            {
                propertyName = propertyName.Substring(0, openBracketIndex);
            }
            if (propertyName == "Views") return null;
            if (UmlIgnoredProperties.Contains(propertyName)) return null;
            if (UmlIgnoredQualifiedProperties.Contains(typeName + "." + propertyName)) return null;
            if (UmlPropertyMap.TryGetValue(typeName+"."+propertyName, out var newPropertyName))
            {
                return newPropertyName;
            }
            else
            {
                return propertyName;
            }
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
            return true;
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
            if (IgnoreElement(element)) return;
            if (parent != null && (element.Name.LocalName == "ATTR" || element.Name.LocalName == "REF") && element.Name.Namespace == _whiteStarUmlNamespace)
            {
                XAttribute nameAttribute = element.Attribute("name");
                string parentPropertyName = GetPropertyName(parent.MMetaClass.Name, nameAttribute?.Value);
                if (parentPropertyName != null)
                {
                    string value = element.Value;
                    if (!HandleSpecialProperty(element, parent, parentPropertyName, value))
                    {
                        ModelProperty parentProperty = parent?.MGetProperty(parentPropertyName);
                        if (parentProperty != null)
                        {
                            this.AssignProperty(element, parent, parentProperty, value);
                        }
                        else
                        {
                            this.AddError(element, $"Model object '{parent.MName}' ({parent.MMetaClass.Name}) has no '{parentPropertyName}' property.");
                        }
                    }
                }
            }
            MutableObjectBase currentObj = ResolveObjectByPosition(element, false);
            foreach (var child in element.Elements())
            {
                this.ReadObject(child, SkipElement(element) ? parent : currentObj);
            }
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

        private void AssignProperty(XObject location, MutableObjectBase obj, ModelProperty property, string propertyValue)
        {
            if (property.IsName) return;
            try
            {
                object value = ResolveValue(location, property.ImmutableType, propertyValue);
                obj.MAdd(property, value);
            }
            catch (ModelException mex)
            {
                this.AddError(location, mex);
            }
        }

        private bool HandleSpecialChild(XObject location, MutableObjectBase parent, string parentPropertyName, MutableObjectBase child)
        {
            if (parent is PackageBuilder && child is GeneralizationBuilder generalization && parentPropertyName == "PackagedElement")
            {
                return true;
            }
            if (child is InteractionBuilder interaction)
            {
                var element = (XElement)location;
                var frame = element.Elements(_whiteStarUmlNamespace + "OBJ").Where(e => e.Attribute("type")?.Value == "UMLFrame").FirstOrDefault();
                if (frame != null)
                {
                    var nameElement = frame.Elements(_whiteStarUmlNamespace + "ATTR").Where(e => e.Attribute("name")?.Value == "Name").FirstOrDefault();
                    if (nameElement != null)
                    {
                        interaction.Name = nameElement.Value;
                    }
                }
                return true;
            }
            if (parent is MessageBuilder message && parentPropertyName == "Action")
            {
                var element = (XElement)location;
                var typeAttribute = element.Attribute("type");
                if (typeAttribute?.Value == "UMLCallAction")
                {
                    message.MessageSort = MessageSort.SynchCall;
                }
                if (typeAttribute?.Value == "UMLReturnAction")
                {
                    message.MessageSort = MessageSort.Reply;
                }
                return true;
            }
            return false;
        }
        
        private bool HandleSpecialProperty(XObject location, MutableObjectBase obj, string propertyName, string propertyValue)
        {
            if (obj is NamedElementBuilder namedElement)
            {
                if (propertyName == "Visibility")
                {
                    namedElement.Visibility = CreateEnumValue<VisibilityKind>(location, propertyValue, 2);
                    return true;
                }
            }
            if (obj is MultiplicityElementBuilder multiplicityElement)
            {
                if (propertyName == "Multiplicity")
                {
                    int lower = 0;
                    int upper = 1;
                    if (propertyValue.Contains(".."))
                    {
                        string[] parts = propertyValue.Split(new string[] { ".." }, StringSplitOptions.RemoveEmptyEntries);
                        if (parts.Length >= 2)
                        {
                            if (!int.TryParse(parts[0], out lower)) lower = 0;
                            if (!int.TryParse(parts[1], out upper))
                            {
                                if (parts[1] == "*") upper = -1;
                                else upper = 1;
                            }
                        }
                    }
                    else if (propertyValue == "*")
                    {
                        upper = -1;
                    }
                    var lowerValue = _factory.LiteralInteger();
                    lowerValue.Value = lower;
                    var upperValue = _factory.LiteralUnlimitedNatural();
                    upperValue.Value = upper;
                    multiplicityElement.LowerValue = lowerValue;
                    multiplicityElement.UpperValue = upperValue;
                    return true;
                }
            }
            if (obj is ParameterBuilder param)
            {
                if (propertyName == "DirectionKind")
                {
                    param.Direction = CreateEnumValue<ParameterDirectionKind>(location, propertyValue, 3);
                    return true;
                }
            }
            if (obj is PropertyBuilder prop)
            {
                if (propertyName == "IsNavigable")
                {
                    if (propertyValue.ToLower() == "true" && prop.Association != null && prop.Class == null)
                    {
                        prop.Association.NavigableOwnedEnd.Add(prop);
                    }
                    return true;
                }
                if (propertyName == "Aggregation")
                {
                    prop.Aggregation = CreateEnumValue<AggregationKind>(location, propertyValue, 2);
                    return true;
                }
            }
            if (obj is TypedElementBuilder typedElement)
            {
                if (propertyName == "TypeExpression")
                {
                    var type = _model.Objects.OfType<TypeBuilder>().Where(t => t.Name == propertyValue).FirstOrDefault();
                    if (type != null)
                    {
                        typedElement.Type = type;
                    }
                    else
                    {
                        
                        typedElement.Type = CreatePrimitiveType(propertyValue);
                        // this.AddError(location, string.Format("Cannot resolve type name: {0}", propertyValue));
                    }
                    return true;
                }
            }
            if (obj is MessageBuilder message)
            {
                if (propertyName == "StereotypeName")
                {
                    if (propertyValue == "create")
                    {
                        message.MessageSort = MessageSort.CreateMessage;
                    }
                    return true;
                }
                else if (propertyName == "Sender")
                {
                    var interaction = message.Interaction;
                    var lifeline = ResolveValue(location, typeof(IModelObject), propertyValue) as LifelineBuilder;
                    if (lifeline != null)
                    {
                        lifeline.Interaction = interaction;
                        var startEvent = _factory.MessageOccurrenceSpecification();
                        interaction.Fragment.Add(startEvent);
                        startEvent.Covered = lifeline;
                        startEvent.Message = message;
                        message.SendEvent = startEvent;
                    }
                    return true;
                }
                else if (propertyName == "Receiver")
                {
                    var interaction = message.Interaction;
                    var lifeline = ResolveValue(location, typeof(IModelObject), propertyValue) as LifelineBuilder;
                    if (lifeline != null)
                    {
                        lifeline.Interaction = interaction;
                        var endEvent = _factory.MessageOccurrenceSpecification();
                        interaction.Fragment.Add(endEvent);
                        endEvent.Covered = lifeline;
                        endEvent.Message = message;
                        message.ReceiveEvent = endEvent;
                    }
                    return true;
                }
                else if (propertyName == "Arguments")
                {
                    var argStrings = propertyValue.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var argString in argStrings)
                    {
                        var arg = _factory.LiteralString();
                        arg.Value = argString;
                        message.Argument.Add(arg);
                    }
                    return true;
                }
            }
            if (obj is CombinedFragmentBuilder combinedFragment)
            {
                if (propertyName == "InteractionOperator")
                {
                    combinedFragment.InteractionOperator = CreateEnumValue<InteractionOperatorKind>(location, propertyValue, 3);
                    return true;
                }
            }
            if (obj is InteractionOperandBuilder interactionOperand)
            {
                if (propertyName == "Guard")
                {
                    var guard = _factory.LiteralString();
                    guard.Value = propertyValue;
                    var constraint = _factory.InteractionConstraint();
                    constraint.Specification = guard;
                    interactionOperand.Guard = constraint;
                    return true;
                }
            }
            return false;
        }

        private PrimitiveTypeBuilder CreatePrimitiveType(string name)
        {
            if (!_primitiveTypes.TryGetValue(name, out var primitiveType))
            {
                primitiveType = _factory.PrimitiveType();
                primitiveType.Name = name;
            }
            return primitiveType;
            /*switch (propertyValue.ToLower())
            {
                case "bool":
                case "boolean":
                    typedElement.Type = UmlInstance.Boolean.ToMutable();
                    return true;
                case "byte":
                case "short":
                case "int":
                case "long":
                    typedElement.Type = UmlInstance.Integer.ToMutable();
                    return true;
                case "float":
                case "double":
                    typedElement.Type = UmlInstance.Real.ToMutable();
                    return true;
                case "string":
                    typedElement.Type = UmlInstance.Real.ToMutable();
                    return true;
            }*/
        }

        private TEnumValue CreateEnumValue<TEnumValue>(XObject location, string valueString, int prefixLength)
            where TEnumValue: struct
        {
            if (valueString.Length > prefixLength)
            {
                string enumValue = valueString.Substring(prefixLength);
                if (Enum.TryParse<TEnumValue>(enumValue, out var value))
                {
                    return value;
                }
            }
            this.AddError(location, string.Format("Cannot resolve {0}: {1}", typeof(TEnumValue).Name, valueString));
            return default;
        }

        private object ResolveValue(XObject location, System.Type type, string propertyValue)
        {
            if (typeof(IModelObject).IsAssignableFrom(type))
            {
                return this.ResolveObjectById(location, propertyValue);
            }
            else if (type.IsEnum)
            {
                try
                {
                    return Enum.Parse(type, propertyValue, true);
                }
                catch (Exception)
                {
                    this.AddError(location, $"Value '{propertyValue}' is invalid for the enum type '{type.FullName}'.");
                    return null;
                }
            }
            else if (type == typeof(string))
            {
                return propertyValue;
            }
            else if (type == typeof(bool))
            {
                return propertyValue.ToLower() == "true" || propertyValue == "1";
            }
            else if (type == typeof(int))
            {
                int.TryParse(propertyValue, out int intValue);
                if (propertyValue == "*") intValue = -1;
                return intValue;
            }
            else if (type == typeof(long))
            {
                long.TryParse(propertyValue, out long longValue);
                if (propertyValue == "*") longValue = -1;
                return longValue;
            }
            else if (type == typeof(float))
            {
                float.TryParse(propertyValue, out float floatValue);
                return floatValue;
            }
            else if (type == typeof(double))
            {
                double.TryParse(propertyValue, out double doubleValue);
                return doubleValue;
            }
            else
            {
                this.AddError(location, $"Unhandled value type: {type.FullName}.");
                return null;
            }
        }

        private static readonly HashSet<string> UmlSkippedTypes = new HashSet<string>()
        {
            "CollaborationInstanceSet", "CallAction", "ReturnAction", "Frame", "CallAction", "ReturnAction"
        };
        private static readonly HashSet<string> UmlIgnoredTypes = new HashSet<string>()
        {
            "UseCaseDiagram", "ClassDiagram", "DeploymentDiagram", "SequenceDiagram", "ComponentDiagram"
        };
        private static readonly Dictionary<string, string> UmlTypeMap = new Dictionary<string, string>()
        {
            { "Project", "Model" },
            { "Model", "Package" },
            { "AssociationEnd", "Property" },
            { "Attribute", "Property" },
            { "InteractionInstanceSet", "Interaction" },
            { "Stimulus", "Message" },
            { "Object", "Lifeline" },
        };
        private static readonly HashSet<string> UmlIgnoredProperties = new HashSet<string>()
        {
            "Associations", "TypedParameters", "SupplierDependencies", "ClientDependencies", "Instances"
        };
        private static readonly HashSet<string> UmlIgnoredQualifiedProperties = new HashSet<string>()
        {
            "Interaction.Context",
            "Generalization.Namespace",
            "Class.Specializations",
            "Class.StereotypeName",
            "Interface.StereotypeName",
            "Operation.CallActions",
            "Parameter.BehavioralFeature",
            "Package.ParticipatingInstances",
            "Package.RepresentedClassifier",
            "CombinedFragment.EnclosingInteractionInstanceSet",
            "Interaction.InteractionInstanceSet",
            "Interaction.FrameKind",
            "Message.InteractionInstanceSet",
            "Lifeline.SendingStimuli",
            "Lifeline.ReceivingStimuli",
            "Lifeline.CollaborationInstanceSet",
            "Message.Stimulus"
        };
        private static readonly Dictionary<string, string> UmlPropertyMap = new Dictionary<string, string>()
        {
            { "Model.Title", "Name" },
            { "Model.OwnedElements", "PackagedElement" },
            { "Package.OwnedElements", "PackagedElement" },
            { "Package.InteractionInstanceSets", "PackagedElement" },
            { "Association.Namespace", "Package" },
            { "Association.Connections", "MemberEnd" },
            { "Enumeration.Namespace", "Package" },
            { "Enumeration.Literals", "OwnedLiteral" },
            { "Generalization.Parent", "General" },
            { "Generalization.Child", "Specific" },
            { "Interface.Namespace", "Package" },
            { "Interface.Attributes", "OwnedAttribute" },
            { "Interface.Operations", "OwnedOperation" },
            { "Class.Namespace", "Package" },
            { "Class.Attributes", "OwnedAttribute" },
            { "Class.Operations", "OwnedOperation" },
            { "Class.Generalizations", "Generalization" },
            { "Property.Participant", "Type" },
            { "Property.Qualifiers", "Qualifier" },
            { "Operation.Parameters", "OwnedParameter" },
            { "Parameter.Type_", "Type" },
            { "Interaction.ParticipatingInstances", "Lifeline" },
            { "Interaction.ParticipatingStimuli", "Message" },
            { "Interaction.OwnedFrames", "Fragment" },
            { "Interaction.Fragments", "Fragment" },
            { "Message.Operation", "Signature" },
            { "CombinedFragment.Operands", "Operand" },
            { "Lifeline.Classifier", "Classifier" },
        };
    }
}
