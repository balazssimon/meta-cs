using MetaDslx.Languages.Uml.Model;
using MetaDslx.Modeling;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Text;
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
        public ImmutableModel ReadModelFromFile(string filePath)
        {
            if (filePath == null) throw new ArgumentNullException(nameof(filePath));
            var umlCode = File.ReadAllText(filePath);
            var result = this.ReadModel(filePath, umlCode, out var diagnostics);
            if (diagnostics.Length > 0)
            {
                throw new ModelException(diagnostics[0]);
            }
            return result;
        }

        public ImmutableModel ReadModel(string umlCode)
        {
            if (umlCode == null) throw new ArgumentNullException(nameof(umlCode));
            var result = this.ReadModel(string.Empty, umlCode, out var diagnostics);
            if (diagnostics.Length > 0)
            {
                throw new ModelException(diagnostics[0]);
            }
            return result;
        }

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
        private Dictionary<MutableObjectBase, XElement> _elementsByObject;
        private Dictionary<string, PrimitiveTypeBuilder> _primitiveTypes;
        private Dictionary<MessageOccurrenceSpecificationBuilder, LifelineBuilder> _mosToLifeline;
        private HashSet<string> _invisible;
        private Dictionary<MessageBuilder, string> _messageLabels;

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
            _elementsByObject = new Dictionary<MutableObjectBase, XElement>();
            _primitiveTypes = new Dictionary<string, PrimitiveTypeBuilder>();
            _mosToLifeline = new Dictionary<MessageOccurrenceSpecificationBuilder, LifelineBuilder>();
            _invisible = new HashSet<string>();
            _messageLabels = new Dictionary<MessageBuilder, string>();
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
            _diagnostics.Add(ModelErrorCode.ERR_ImportError.ToDiagnostic(GetLocation(location), message));
        }

        internal void AddError(XObject location, ModelException mex)
        {
            _diagnostics.Add(ModelErrorCode.ERR_ImportError.ToDiagnostic(GetLocation(location), mex.Diagnostic.GetMessage()));
        }

        internal void AddWarning(XObject location, string message)
        {
            _diagnostics.Add(ModelErrorCode.WRN_ImportWarning.ToDiagnostic(GetLocation(location), message));
        }

        internal void AddWarning(XObject location, ModelException mex)
        {
            _diagnostics.Add(ModelErrorCode.WRN_ImportWarning.ToDiagnostic(GetLocation(location), mex.Diagnostic.GetMessage()));
        }

        public void ReadModel()
        {
            this.CreateObjects();
            if (_body == null) return;
            this.ReadObjects();
            this.ReadSequenceViews();
            this.PostProcessObjects();
            foreach (var mobj in _model.Objects)
            {
                mobj.MMakeCreated();
            }
        }

        private void CreateObjects()
        {
            XElement root = null;
            try
            {
                var document = XDocument.Parse(_umlCode, LoadOptions.SetBaseUri | LoadOptions.SetLineInfo);
                root = document.Root;
                if (root.Name.LocalName != "PROJECT" || root.Name.Namespace != _whiteStarUmlNamespace)
                {
                    this.AddError(root, "The root must be an xpd:PROJECT tag.");
                }
                _body = root.Element(_whiteStarUmlNamespace + "BODY");
            }
            catch(XmlException ex)
            {
                this.AddError(root, "Invalid XML file: "+ ex.Message);
            }
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
            if (_body == null) return;
            this.ReadObject(_body, null);
        }

        private void ReadSequenceViews()
        {
            if (_body == null) return;
            var viewTypes = new HashSet<string>() { "UMLSeqStimulusView", "UMLSeqObjectView", "UMLCombinedFragmentView", "UMLInteractionOperandView" };
            var interactionElements = _body.Descendants(_whiteStarUmlNamespace + "OBJ").Where(e => e.Attribute("type")?.Value == "UMLInteractionInstanceSet");
            foreach (var interactionElement in interactionElements)
            {
                var interactionId = interactionElement.Attribute("guid")?.Value;
                if (interactionId != null)
                {
                    var interaction = ResolveObjectById(interactionElement, interactionId) as InteractionBuilder;
                    if (interaction != null)
                    {
                        var sequenceViews = new Dictionary<MutableObjectBase, (int, int)>();
                        var views = interactionElement.Descendants(_whiteStarUmlNamespace + "OBJ").Where(e => viewTypes.Contains(e.Attribute("type")?.Value));
                        foreach (var view in views)
                        {
                            var viewType = view.Attribute("type").Value;
                            var seqIdElement = view.Elements(_whiteStarUmlNamespace + "REF").Where(e => e.Attribute("name")?.Value == "Model").FirstOrDefault();
                            var seqId = seqIdElement?.Value;
                            if (seqId != null)
                            {
                                var seqObj = ResolveObjectById(seqIdElement, seqId);
                                if (seqObj != null)
                                {
                                    if (viewType == "UMLSeqStimulusView" && seqObj is MessageBuilder message)
                                    {
                                        var pointsElement = view.Elements(_whiteStarUmlNamespace + "ATTR").Where(e => e.Attribute("name")?.Value == "Points").FirstOrDefault();
                                        var points = pointsElement?.Value;
                                        if (!string.IsNullOrWhiteSpace(points))
                                        {
                                            var pointItems = points.Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
                                            if (pointItems.Length >= 4)
                                            {
                                                int.TryParse(pointItems[1], out int value);
                                                int start = value;
                                                int end = value;
                                                for (int i = 3; i < pointItems.Length; i += 2)
                                                {
                                                    int.TryParse(pointItems[i], out value);
                                                    if (value < start) start = value;
                                                    if (value > end) end = value;
                                                }
                                                sequenceViews.Add((MutableObjectBase)message.SendEvent, (start, start));
                                                sequenceViews.Add((MutableObjectBase)message.ReceiveEvent, (end, end));
                                            }
                                        }
                                        var labelElement = view.Elements(_whiteStarUmlNamespace + "OBJ").Where(e => e.Attribute("name")?.Value == "NameLabel" && e.Attribute("type")?.Value == "EdgeLabelView").FirstOrDefault();
                                        if (labelElement != null)
                                        {
                                            var textElement = labelElement.Elements(_whiteStarUmlNamespace + "ATTR").Where(e => e.Attribute("name")?.Value == "Text").FirstOrDefault();
                                            if (textElement != null && !string.IsNullOrWhiteSpace(textElement.Value))
                                            {
                                                _messageLabels.Add(message, textElement.Value);
                                            }
                                        }
                                    }
                                    else if (viewType == "UMLSeqObjectView" || viewType == "UMLCombinedFragmentView" || viewType == "UMLInteractionOperandView")
                                    {
                                        var topElement = view.Elements(_whiteStarUmlNamespace + "ATTR").Where(e => e.Attribute("name")?.Value == "Top").FirstOrDefault();
                                        var heightElement = view.Elements(_whiteStarUmlNamespace + "ATTR").Where(e => e.Attribute("name")?.Value == "Height").FirstOrDefault();
                                        var topString = topElement?.Value;
                                        var heightString = heightElement?.Value;
                                        if (topString != null && heightString != null && int.TryParse(topString, out int top) && int.TryParse(heightString, out int height))
                                        {
                                            if (sequenceViews.ContainsKey(seqObj))
                                            {
                                                if (seqObj is LifelineBuilder)
                                                {
                                                    AddError(seqIdElement, "Duplicate lifeline '"+seqObj.MName+"' in interaction '"+ interaction.Name + "'");
                                                }
                                                else
                                                {
                                                    AddError(seqIdElement, "Duplicate element '" + seqObj.MName + "' in interaction '" + interaction.Name + "'");
                                                }
                                            }
                                            else
                                            {
                                                sequenceViews.Add(seqObj, (top, top + height));
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        foreach (var view in sequenceViews.Where(v => v.Key is CombinedFragmentBuilder).ToList())
                        {
                            var cf = (CombinedFragmentBuilder)view.Key;
                            if (cf.Operand.Count > 0)
                            {
                                var firstOp = cf.Operand[0];
                                if (sequenceViews.TryGetValue((MutableObjectBase)firstOp, out var firstRange))
                                {
                                    int top = Math.Min(view.Value.Item1, firstRange.Item1);
                                    sequenceViews[(MutableObjectBase)firstOp] = (top, firstRange.Item2);
                                }
                                var lastOp = cf.Operand[cf.Operand.Count - 1];
                                if (sequenceViews.TryGetValue((MutableObjectBase)lastOp, out var lastRange))
                                {
                                    int bottom = Math.Max(view.Value.Item2, lastRange.Item2);
                                    sequenceViews[(MutableObjectBase)lastOp] = (lastRange.Item1, bottom);
                                }
                            }
                        }
                        var orderedViews = sequenceViews.OrderBy(entry => entry.Value.Item1).ThenByDescending(entry => entry.Value.Item2).ToList();
                        var fragmentStack = new Stack<KeyValuePair<MutableObjectBase, (int, int)>>();
                        var lifelineMap = new Dictionary<LifelineBuilder, LifelineBuilder>();
                        foreach (var view in orderedViews)
                        {
                            if (view.Key is LifelineBuilder lifeline)
                            {
                                if (lifeline.MParent != null)
                                {
                                    var replacement = _factory.Lifeline();
                                    replacement.Name = lifeline.Name;
                                    interaction.Lifeline.Add(replacement);
                                    lifelineMap.Add(lifeline, replacement);
                                    if (_elementsByObject.TryGetValue((MutableObjectBase)lifeline, out var lifelineElement))
                                    {
                                        _elementsByObject.Add((MutableObjectBase)replacement, lifelineElement);
                                    }
                                }
                                else
                                {
                                    interaction.Lifeline.Add(lifeline);
                                }
                            }
                        }
                        foreach (var view in orderedViews)
                        {
                            if (!(view.Key is LifelineBuilder))
                            {
                                InteractionOperandBuilder currentFragment = null;
                                while (fragmentStack.Count > 0)
                                {
                                    var top = fragmentStack.Peek();
                                    if (top.Value.Item2 < view.Value.Item1)
                                    {
                                        fragmentStack.Pop();
                                    }
                                    else
                                    {
                                        currentFragment = (InteractionOperandBuilder)top.Key;
                                        break;
                                    }
                                }
                                if (view.Key is CombinedFragmentBuilder combinedFragment)
                                {
                                    if (combinedFragment.MParent == null)
                                    {
                                        if (currentFragment != null)
                                        {
                                            currentFragment.Fragment.Add(combinedFragment);
                                        }
                                        else
                                        {
                                            interaction.Fragment.Add(combinedFragment);
                                        }
                                    }
                                    else
                                    {
                                        var location = ResolveElementByObject((MutableObjectBase)combinedFragment, null);
                                        AddError(location, "Error importing combined fragments in the interaction called '"+interaction.Name+"'. The combined fragments are not properly nested.");
                                    }
                                }
                                else if (view.Key is InteractionOperandBuilder interactionOperand)
                                {
                                    fragmentStack.Push(view);
                                }
                                else if (view.Key is MessageOccurrenceSpecificationBuilder messageEnd)
                                {
                                    if (currentFragment != null)
                                    {
                                        currentFragment.Fragment.Add(messageEnd);
                                    }
                                    else
                                    {
                                        interaction.Fragment.Add(messageEnd);
                                    }
                                    if (_mosToLifeline.TryGetValue(messageEnd, out var messageEndLifeline) && messageEndLifeline != null)
                                    {
                                        if (!lifelineMap.TryGetValue(messageEndLifeline, out var finalLifeline))
                                        {
                                            finalLifeline = messageEndLifeline;
                                        }
                                        messageEnd.Covered = finalLifeline;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void PostProcessObjects()
        {
            /*foreach (var dep in _model.Objects.OfType<DependencyBuilder>())
            {
                if (dep is InterfaceRealizationBuilder intfReal)
                {
                    foreach (var client in intfReal.Client)
                    {
                        if (client is ClassBuilder clientClass)
                        {
                            intfReal.Owner = null;
                            clientClass.InterfaceRealization.Add(intfReal);
                        }
                    }
                }
            }*/
            foreach (var prop in _model.Objects.OfType<PropertyBuilder>())
            {
                var propElement = ResolveElementByObject((MutableObjectBase)prop, null);
                var defaultValueElement = propElement.Elements(_whiteStarUmlNamespace + "ATTR").Where(e => e.Attribute("name")?.Value == "InitialValue" && !string.IsNullOrWhiteSpace(e.Value)).FirstOrDefault();
                if (defaultValueElement != null)
                {
                    prop.DefaultValue = ParseDefaultValue(prop.Type, defaultValueElement.Value);
                }
            }
            foreach (var param in _model.Objects.OfType<ParameterBuilder>())
            {
                var paramElement = ResolveElementByObject((MutableObjectBase)param, null);
                var defaultValueElement = paramElement.Elements(_whiteStarUmlNamespace + "ATTR").Where(e => e.Attribute("name")?.Value == "DefaultValue" && !string.IsNullOrWhiteSpace(e.Value)).FirstOrDefault();
                if (defaultValueElement != null)
                {
                    param.DefaultValue = ParseDefaultValue(param.Type, defaultValueElement.Value);
                }
            }
            foreach (var assoc in _model.Objects.OfType<AssociationBuilder>())
            {
                if (assoc.MemberEnd.Count == 2)
                {
                    var firstEnd = assoc.MemberEnd[0];
                    var secondEnd = assoc.MemberEnd[1];
                    var firstNavigable = !assoc.OwnedEnd.Contains(firstEnd);
                    var secondNavigable = !assoc.OwnedEnd.Contains(secondEnd);
                    if (firstNavigable)
                    {
                        var type = secondEnd.Type;
                        if (type is ClassBuilder cls) cls.OwnedAttribute.Add(firstEnd);
                        else if (type is InterfaceBuilder intf) intf.OwnedAttribute.Add(firstEnd);
                    }
                    if (secondNavigable)
                    {
                        var type = firstEnd.Type;
                        if (type is ClassBuilder cls) cls.OwnedAttribute.Add(secondEnd);
                        else if (type is InterfaceBuilder intf) intf.OwnedAttribute.Add(secondEnd);
                    }
                }
            }
            foreach (var inter in _model.Objects.OfType<InteractionBuilder>())
            {
                var collaboration = _factory.Collaboration();
                collaboration.Name = "locals";
                foreach (var lifeline in inter.Lifeline)
                {
                    var lifelineProp = _factory.Property();
                    lifelineProp.Name = lifeline.Name;
                    collaboration.OwnedAttribute.Add(lifelineProp);
                    var lifelineElement = ResolveElementByObject((MutableObjectBase)lifeline, null);
                    ClassifierBuilder classifier = null;
                    var classifierId = lifelineElement?.Elements(_whiteStarUmlNamespace + "REF")?.Where(e => e.Attribute("name")?.Value == "Classifier")?.FirstOrDefault()?.Value;
                    if (classifierId != null)
                    {
                        classifier = ResolveObjectById(lifelineElement, classifierId) as ClassifierBuilder;
                    }
                    else
                    {
                        classifier = _model.Objects.MOfType<ClassBuilder>().Where(c => c.Name == lifeline.Name).FirstOrDefault();
                        if (classifier == null)
                        {
                            classifier = _model.Objects.MOfType<InterfaceBuilder>().Where(c => c.Name == lifeline.Name).FirstOrDefault();
                        }
                    }
                    if (classifier != null)
                    {
                        lifelineProp.Type = classifier;
                        lifelineProp.Aggregation = AggregationKind.Composite;
                        lifeline.Represents = lifelineProp;
                    }
                }
                foreach (var message in inter.Message)
                {
                    var messageElement = ResolveElementByObject((MutableObjectBase)message, null);
                    var argumentsElement = messageElement.Elements(_whiteStarUmlNamespace + "ATTR").Where(e => e.Attribute("name")?.Value == "Arguments" && !string.IsNullOrWhiteSpace(e.Value)).FirstOrDefault();
                    var returnElement = messageElement.Elements(_whiteStarUmlNamespace + "ATTR").Where(e => e.Attribute("name")?.Value == "Return" && !string.IsNullOrWhiteSpace(e.Value)).FirstOrDefault();
                    var signature = ParseMessageArguments(message, argumentsElement, returnElement);
                    message.Name = signature;
                    if (message.Signature == null)
                    {
                        bool hasOperation = false;
                        var actionElement = messageElement.Elements(_whiteStarUmlNamespace + "OBJ").Where(e => e.Attribute("name")?.Value == "Action").FirstOrDefault();
                        if (actionElement != null)
                        {
                            var operationElement = actionElement.Elements(_whiteStarUmlNamespace + "REF").Where(e => e.Attribute("name")?.Value == "Operation").FirstOrDefault();
                            if (operationElement != null)
                            {
                                hasOperation = true;
                            }
                        }
                        var target = ((message.ReceiveEvent as MessageOccurrenceSpecificationBuilder)?.Covered?.Represents as PropertyBuilder)?.Type as ClassifierBuilder;
                        if (!hasOperation && target != null)
                        {
                            message.Signature = target.MResolveOperationBySignature(signature);
                        }
                    }
                }
                inter.NestedClassifier.Add(collaboration);
            }
        }

        private ValueSpecificationBuilder ParseDefaultValue(TypeBuilder type, string value)
        {
            if (value.ToLower() == "null")
            {
                return _factory.LiteralNull();
            }
            if (value.ToLower() == "true" || value.ToLower() == "false")
            {
                var result = _factory.LiteralBoolean();
                result.Value = value == "true";
                return result;
            }
            if (int.TryParse(value, out var intValue))
            {
                var result = _factory.LiteralInteger();
                result.Value = intValue;
                return result;
            }
            if (double.TryParse(value, out var doubleValue))
            {
                var result = _factory.LiteralReal();
                result.Value = doubleValue;
                return result;
            }
            if (type is EnumerationBuilder enumType)
            {
                foreach (var enumLit in enumType.OwnedLiteral)
                {
                    if (value == enumLit.Name || value == enumType.Name+"."+enumLit.Name || value == enumType.Name + "::" + enumLit.Name)
                    {
                        var result = _factory.InstanceValue();
                        result.Instance = enumLit;
                        return result;
                    }
                }
            }
            var defaultResult = _factory.LiteralString();
            defaultResult.Value = value;
            return defaultResult;
        }

        private string ParseMessageArguments(MessageBuilder message, XElement argumentsElement, XElement returnElement)
        {
            string operationName = message.Signature?.Name;
            bool inString = false;
            var argList = string.Empty;
            var ret = string.Empty;
            if (_messageLabels.TryGetValue(message, out var label))
            {
                int colonIndex = label.IndexOf(':');
                if (colonIndex >= 0)
                {
                    string messageNumberStr = label.Substring(0, colonIndex);
                    if (int.TryParse(messageNumberStr, out var messageNumber))
                    {
                        label = label.Substring(colonIndex + 1).Trim();
                    }
                }
                else if(int.TryParse(label, out var messageNumber))
                {
                    label = string.Empty;
                }
            }
            else
            {
                label = message.Name;
            }
            if (argumentsElement != null)
            {
                argList = argumentsElement.Value;
            }
            if (returnElement != null)
            {
                ret = returnElement.Value;
            }
            if (message.Signature == null && label != null)
            {
                int assignIndex = label.IndexOf(":=");
                if (assignIndex < 0) assignIndex = label.IndexOf('=');
                int openParenIndex = label.IndexOf("(");
                if (assignIndex >= 0 && (openParenIndex < 0 || assignIndex < openParenIndex))
                {
                    var labelRet = label.Substring(0, assignIndex).Trim();
                    if (returnElement == null)
                    {
                        ret = labelRet;
                    }
                    label = label.Substring(assignIndex + (label[assignIndex] == ':' ? 2 : 1)).Trim();
                }
                openParenIndex = label.IndexOf("(");
                operationName = label;
                if (openParenIndex >= 0)
                {
                    operationName = label.Substring(0, openParenIndex).Trim();
                    if (argumentsElement == null)
                    {
                        int parenCount = 1;
                        int endIndex = 0;
                        inString = false;
                        var labelArgs = label.Substring(openParenIndex + 1).Trim();
                        foreach (var ch in labelArgs)
                        {
                            if (ch == '"') inString = !inString;
                            else if (!inString)
                            {
                                if (ch == ')')
                                {
                                    --parenCount;
                                    if (parenCount == 0) break;
                                }
                                else if (ch == '(')
                                {
                                    ++parenCount;
                                }
                            }
                            ++endIndex;
                        }
                        argList = labelArgs.Substring(0, endIndex).Trim();
                    }
                }
            }
            if (message.MessageSort != MessageSort.Reply)
            {
                if (!string.IsNullOrWhiteSpace(argList))
                {
                    int parenCount = 0;
                    int index = 0;
                    int lastIndex = 0;
                    string argValue = null;
                    foreach (var ch in argList)
                    {
                        if (ch == '"') inString = !inString;
                        else if (!inString)
                        {
                            if (ch == '(')
                            {
                                ++parenCount;
                            }
                            else if (ch == ')')
                            {
                                --parenCount;
                            }
                            else if (ch == ',' && parenCount == 0)
                            {
                                var arg = _factory.LiteralString();
                                argValue = argList.Substring(lastIndex, index - lastIndex).Trim();
                                arg.Value = argValue;
                                message.Argument.Add(arg);
                                lastIndex = index + 1;
                            }
                        }
                        ++index;
                    }
                    argValue = argList.Substring(lastIndex, index - lastIndex).Trim();
                    if (message.Argument.Count > 0 || !string.IsNullOrEmpty(argValue))
                    {
                        var arg = _factory.LiteralString();
                        arg.Value = argValue;
                        message.Argument.Add(arg);
                    }
                }
                if (!string.IsNullOrWhiteSpace(ret))
                {
                    var comment = _factory.Comment();
                    comment.Body = "result:" + ret;
                    message.OwnedComment.Add(comment);
                }
                if (!string.IsNullOrWhiteSpace(operationName)) return $"{operationName}({argList})";
                else return null;
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(operationName)) return operationName;
                else return null;
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
                    if (!IsVisible(element, typeName) || !IsVisible(element, GetWhiteStarUmlTypeName(element)))
                    {
                        var nameAttr = element.Elements(_whiteStarUmlNamespace + "ATTR").Where(e => e.Attribute("name") != null).FirstOrDefault();
                        this.AddWarning(element, $"Model object '{nameAttr?.Value}' ({typeName}) is not visible in any diagrams.");
                        var id = guidAttribute?.Value;
                        if (id != null)
                        {
                            _invisible.Add(id);
                        }
                    }
                    else
                    {
                        try
                        {
                            obj = (MutableObjectBase)_factory.Create(typeName);
                        }
                        catch (ModelException mex)
                        {
                            this.AddError(element, mex);
                        }
                    }
                    if (obj != null)
                    {
                        this.RegisterObjectByPosition(element, obj);
                        if (guidAttribute != null)
                        {
                            string id = guidAttribute.Value;
                            this.RegisterObjectById(guidAttribute, id, obj);
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
                            }
                            else
                            {
                                this.AddWarning(element, $"Model object '{parent.MName}' ({parent.MMetaClass.Name}) has no '{parentPropertyName}' property.");
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

        private string GetWhiteStarUmlTypeName(XElement element)
        {
            XAttribute typeAttribute = element.Attribute("type");
            var typeName = typeAttribute?.Value;
            return typeName;
        }

        private bool IsVisible(XElement element, string typeName)
        {
            if (typeName == null) return false;
            if (!UmlTypeMustHaveView.Contains(typeName) && !WhiteStarUmlTypeMustHaveView.Contains(typeName)) return true;
            var view0 = element.Elements(_whiteStarUmlNamespace + "REF").Where(e => e.Attribute("name")?.Value == "Views[0]");
            return view0.Count() > 0;
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
                            this.AddWarning(element, $"Model object '{parent.MName}' ({parent.MMetaClass.Name}) has no '{parentPropertyName}' property.");
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
            if (reportError && !_invisible.Contains(id)) this.AddError(location, $"Model object referenced by identifier '{id}' cannot be resolved.");
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
            if (parent is PackageBuilder && child is IncludeBuilder include && parentPropertyName == "PackagedElement")
            {
                return true;
            }
            if (parent is PackageBuilder && child is ExtendBuilder extend && parentPropertyName == "PackagedElement")
            {
                return true;
            }
            if (child is InteractionBuilder interaction)
            {
                var element = (XElement)location;
                var frame = element.Elements(_whiteStarUmlNamespace + "OBJ").Where(e => e.Attribute("type")?.Value == "UMLFrame").FirstOrDefault();
                if (frame != null)
                {
                    var nameElement = frame.Elements(_whiteStarUmlNamespace + "ATTR").Where(e => e.Attribute("name")?.Value == "Name" && !string.IsNullOrWhiteSpace(e.Value)).FirstOrDefault();
                    if (nameElement != null && (string.IsNullOrWhiteSpace(interaction.Name) || interaction.Name.StartsWith("InteractionInstanceSet") || interaction.Name.StartsWith("Frame")))
                    {
                        interaction.Name = nameElement.Value;
                    }
                }
                var seqDiagram = element.Elements(_whiteStarUmlNamespace + "OBJ").Where(e => e.Attribute("type")?.Value == "UMLSequenceDiagram").FirstOrDefault();
                if (seqDiagram != null && (string.IsNullOrWhiteSpace(interaction.Name) || interaction.Name.StartsWith("InteractionInstanceSet") || interaction.Name.StartsWith("Frame")))
                {
                    var nameElement = seqDiagram.Elements(_whiteStarUmlNamespace + "ATTR").Where(e => e.Attribute("name")?.Value == "Name" && !string.IsNullOrWhiteSpace(e.Value)).FirstOrDefault();
                    if (nameElement != null)
                    {
                        interaction.Name = nameElement.Value;
                    }
                }
                if (parent is PackageBuilder package) package.PackagedElement.Add(interaction);
                return true;
            }
            if (parent is MessageBuilder message && parentPropertyName == "Action")
            {
                var element = (XElement)location;
                var typeAttribute = element.Attribute("type");
                switch (typeAttribute?.Value)
                {
                    case "UMLCallAction":
                        message.MessageSort = MessageSort.SynchCall;
                        break;
                    case "UMLReturnAction":
                        message.MessageSort = MessageSort.Reply;
                        break;
                    case "UMLSendAction":
                        message.MessageSort = MessageSort.AsynchCall;
                        break;
                    case "UMLCreateAction":
                        message.MessageSort = MessageSort.CreateMessage;
                        break;
                    case "UMLDestroyAction":
                        message.MessageSort = MessageSort.DeleteMessage;
                        break;
                    default:
                        break;
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
                    if (propertyValue.ToLower() == "false" && prop.Association != null && prop.Class == null)
                    {
                        prop.Association.OwnedEnd.Add(prop);
                    }
                    return true;
                }
                if (propertyName == "Aggregation")
                {
                    if (propertyValue == "akAggregate") propertyValue = "akShared";
                    prop.Aggregation = CreateEnumValue<AggregationKind>(location, propertyValue, 2);
                    return true;
                }
            }
            if (obj is TypedElementBuilder typedElement)
            {
                if (propertyName == "TypeExpression")
                {
                    int openBracketIndex = propertyValue.IndexOf('[');
                    if (openBracketIndex >= 0)
                    {
                        string multiplicity = propertyValue.Substring(openBracketIndex + 1);
                        propertyValue = propertyValue.Substring(0, openBracketIndex).Trim();
                        int closeBracketIndex = multiplicity.IndexOf(']');
                        if (closeBracketIndex >= 0)
                        {
                            multiplicity = multiplicity.Substring(0, closeBracketIndex);
                            int lower = 0;
                            int upper = 1;
                            if (string.IsNullOrWhiteSpace(multiplicity))
                            {
                                upper = -1;
                            }
                            else
                            {
                                string[] parts = multiplicity.Split(new string[] { ".." }, StringSplitOptions.RemoveEmptyEntries);
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
                            if (typedElement is MultiplicityElementBuilder multiplicityElement1)
                            {
                                var lowerValue = _factory.LiteralInteger();
                                lowerValue.Value = lower;
                                var upperValue = _factory.LiteralUnlimitedNatural();
                                upperValue.Value = upper;
                                multiplicityElement1.LowerValue = lowerValue;
                                multiplicityElement1.UpperValue = upperValue;
                            }
                        }
                    }
                    int assignIndex = propertyValue.IndexOf('=');
                    if (assignIndex >= 0)
                    {
                        propertyValue = propertyValue.Substring(0, assignIndex).Trim();
                    }
                    if (typedElement.Type == null)
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
                    }
                    return true;
                }
            }
            if (obj is InterfaceRealizationBuilder interfaceRealization)
            {
                if (propertyName == "Client")
                {
                    var cls = ResolveValue(location, typeof(IModelObject), propertyValue) as BehavioredClassifierBuilder;
                    if (cls != null)
                    {
                        interfaceRealization.Owner = null;
                        cls.InterfaceRealization.Add(interfaceRealization);
                        return true;
                    }
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
                    var startEvent = _factory.MessageOccurrenceSpecification();
                    startEvent.Message = message;
                    message.SendEvent = startEvent;
                    var lifeline = ResolveValue(location, typeof(IModelObject), propertyValue) as LifelineBuilder;
                    _mosToLifeline.Add(startEvent, lifeline);
                    return true;
                }
                else if (propertyName == "Receiver")
                {
                    var interaction = message.Interaction;
                    var endEvent = _factory.MessageOccurrenceSpecification();
                    endEvent.Message = message;
                    message.ReceiveEvent = endEvent;
                    var lifeline = ResolveValue(location, typeof(IModelObject), propertyValue) as LifelineBuilder;
                    _mosToLifeline.Add(endEvent, lifeline);
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
            "CollaborationInstanceSet", "Frame", "CallAction", "ReturnAction", "CreateAction", "DestroyAction", "SendAction"
        };
        private static readonly HashSet<string> UmlIgnoredTypes = new HashSet<string>()
        {
            "UseCaseDiagram", "ClassDiagram", "DeploymentDiagram", "SequenceDiagram", "ComponentDiagram", "StatechartDiagram", "StateMachine"
        };
        private static readonly HashSet<string> WhiteStarUmlTypeMustHaveView = new HashSet<string>()
        {
            "UMLAssociationEnd"
        };
        private static readonly HashSet<string> UmlTypeMustHaveView = new HashSet<string>()
        {
            "UseCase", "Actor", "Class", "Interface", "Enumeration", "Lifeline", "Message", "CombinedFragment", "Include", "Extend",
            "Association", "Generalization", "Realization", "Dependency"
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
            { "Realization", "InterfaceRealization" },
        };
        private static readonly HashSet<string> UmlIgnoredProperties = new HashSet<string>()
        {
            "Associations", "TypedParameters", "SupplierDependencies", "ClientDependencies", "Instances"
        };
        private static readonly HashSet<string> UmlIgnoredQualifiedProperties = new HashSet<string>()
        {
            "UseCase.Includers",
            "UseCase.Extenders",
            "UseCase.StereotypeName",
            "UseCase.Specializations",
            "Actor.StereotypeName",
            "Actor.Specializations",
            "Include.Namespace",
            "Extend.Namespace",
            "Generalization.Namespace",
            "InterfaceRealization.Namespace",
            "Class.Specializations",
            "Class.StereotypeName",
            "Class.TypedFeatures",
            "Class.CreateActions",
            "Interface.StereotypeName",
            "Interface.Specializations",
            "Interface.TypedFeatures",
            "Enumeration.TypedFeatures",
            "Property.InitialValue",
            "Operation.CallActions",
            "Parameter.BehavioralFeature",
            "Parameter.DefaultValue",
            "Package.ParticipatingInstances",
            "Package.RepresentedClassifier",
            "Package.StereotypeProfile",
            "Package.StereotypeName",
            "CombinedFragment.EnclosingInteractionInstanceSet",
            "CombinedFragment.StereotypeName",
            "CombinedFragment.EnclosingOperand",
            "Interaction.Context",
            "Interaction.InteractionInstanceSet",
            "Interaction.FrameKind",
            "Interaction.OwnedFrames",
            "Interaction.Fragments",
            "Interaction.ParticipatingInstances",
            "InteractionOperand.Fragments",
            "InteractionOperand.CombinedFragment",
            "Lifeline.Classifier",
            "Lifeline.SendingStimuli",
            "Lifeline.ReceivingStimuli",
            "Lifeline.CollaborationInstanceSet",
            "Lifeline.IsMultiInstance",
            "Message.InteractionInstanceSet",
            "Message.Stimulus",
            "Message.Arguments",
            "Message.Return",
            "Message.IsSpecification",
            "Message.Instantiation",
        };
        private static readonly Dictionary<string, string> UmlPropertyMap = new Dictionary<string, string>()
        {
            { "Model.Title", "Name" },
            { "Model.OwnedElements", "PackagedElement" },
            { "Package.OwnedElements", "PackagedElement" },
            { "Package.InteractionInstanceSets", "PackagedElement" },
            { "Actor.Generalizations", "Generalization" },
            { "UseCase.Includes", "Include" },
            { "UseCase.Extends", "Extend" },
            { "UseCase.Generalizations", "Generalization" },
            { "Include.Base", "IncludingCase" },
            { "Extend.Base", "ExtendedCase" },
            { "Association.Namespace", "Package" },
            { "Association.Connections", "MemberEnd" },
            { "Enumeration.Namespace", "Package" },
            { "Enumeration.Literals", "OwnedLiteral" },
            { "Generalization.Parent", "General" },
            { "Generalization.Child", "Specific" },
            //{ "InterfaceRealization.Client", "ImplementingClassifier" },
            { "InterfaceRealization.Supplier", "Contract" },
            { "Interface.Namespace", "Package" },
            { "Interface.Attributes", "OwnedAttribute" },
            { "Interface.Operations", "OwnedOperation" },
            { "Interface.Generalizations", "Generalization" },
            { "Class.Namespace", "Package" },
            { "Class.Attributes", "OwnedAttribute" },
            { "Class.Operations", "OwnedOperation" },
            { "Class.Generalizations", "Generalization" },
            { "Property.Participant", "Type" },
            { "Property.Qualifiers", "Qualifier" },
            { "Property.Type_", "Type" },
            { "Operation.Parameters", "OwnedParameter" },
            { "Parameter.Type_", "Type" },
            { "Interaction.ParticipatingStimuli", "Message" },
            //{ "Interaction.ParticipatingInstances", "Lifeline" },
            //{ "Interaction.OwnedFrames", "Fragment" },
            //{ "Interaction.Fragments", "Fragment" },
            { "Message.Operation", "Signature" },
            { "CombinedFragment.Operands", "Operand" },
        };


    }
}
