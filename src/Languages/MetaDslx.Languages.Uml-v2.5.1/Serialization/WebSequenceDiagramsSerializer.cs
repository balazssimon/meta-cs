using Antlr4.Runtime;
using MetaDslx.Languages.Uml.Model;
using MetaDslx.Languages.Uml.Serialization.Syntax.InternalSyntax;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Text;

namespace MetaDslx.Languages.Uml.Serialization
{
    public class WebSequenceDiagramsSerializer
    {
        public ImmutableModel ReadModelFromFile(IEnumerable<string> filePath, ImmutableModel classDiagram, out ImmutableArray<Diagnostic> diagnostics)
        {
            if (filePath == null) throw new ArgumentNullException(nameof(filePath));
            var fileAndCode = filePath.Select(fp => (fp,File.ReadAllText(fp)));
            return this.ReadModel(fileAndCode, classDiagram, out diagnostics);
        }

        public ImmutableModel ReadModel(IEnumerable<string> umlCode, ImmutableModel classDiagram, out ImmutableArray<Diagnostic> diagnostics)
        {
            if (umlCode == null) throw new ArgumentNullException(nameof(umlCode));
            var fileAndCode = umlCode.Select<string, (string, string)>((uc, index) => ("code"+index, uc));
            return this.ReadModel(fileAndCode, classDiagram, out diagnostics);
        }

        protected ImmutableModel ReadModel(IEnumerable<(string,string)> fileAndCode, ImmutableModel classDiagram, out ImmutableArray<Diagnostic> diagnostics)
        {
            if (fileAndCode == null) throw new ArgumentNullException(nameof(fileAndCode));
            var reader = new WebSequenceDiagramsReader(fileAndCode, classDiagram);
            reader.ReadModel();
            diagnostics = reader.Diagnostics.ToReadOnly();
            return reader.Model.ToImmutable();
        }
    }

    internal class WebSequenceDiagramsReader
    {
        private IEnumerable<(string, string)> _fileAndCode;
        private MutableModel _model;
        private UmlFactory _factory;
        private DiagnosticBag _diagnostics;
        private PackageBuilder _mainPackage;
        private CollaborationBuilder _collaboration;
        private string _currentFileName;
        private Dictionary<InteractionUseBuilder, string> _crossReferences;

        public WebSequenceDiagramsReader(IEnumerable<(string, string)> fileAndCode, ImmutableModel classDiagram)
        {
            _fileAndCode = fileAndCode;
            if (classDiagram != null)
            {
                _model = classDiagram.ToMutable(true);
                _mainPackage = _model.Objects.OfType<ModelBuilder>().FirstOrDefault();
            }
            else
            {
                _model = new MutableModel();
            }
            _factory = new UmlFactory(_model);
            if (_mainPackage == null)
            {
                _mainPackage = _factory.Model();
            }
            _diagnostics = new DiagnosticBag();
            _crossReferences = new Dictionary<InteractionUseBuilder, string>();
        }

        public MutableModel Model => _model;
        public DiagnosticBag Diagnostics => _diagnostics;

        internal void AddError(int line, int column, string message)
        {
            _diagnostics.Add(ModelErrorCode.ERR_ImportError.ToDiagnostic(new ExternalFileLocation(_currentFileName, new TextSpan(), new LinePositionSpan(new LinePosition(line, column), new LinePosition(line, column))), message));
        }

        internal void AddError(int line, int column, ModelException mex)
        {
            _diagnostics.Add(ModelErrorCode.ERR_ImportError.ToDiagnostic(new ExternalFileLocation(_currentFileName, new TextSpan(), new LinePositionSpan(new LinePosition(line, column), new LinePosition(line, column))), mex.Diagnostic.GetMessage()));
        }

        public void ReadModel()
        {
            foreach (var fileAndCode in _fileAndCode)
            {
                this.ReadFile(fileAndCode.Item1, fileAndCode.Item2);
            }
        }

        private void ReadFile(string filePath, string code)
        {
            _currentFileName = Path.GetFileName(filePath);
            var interaction = _factory.Interaction();
            interaction.Name = _currentFileName;
            _mainPackage.PackagedElement.Add(interaction);
            _collaboration = _factory.Collaboration();
            _collaboration.Name = "locals";
            interaction.NestedClassifier.Add(_collaboration);
            var lines = new List<string>();
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(code)))
            using (StreamReader reader = new StreamReader(stream))
            {
                while(!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    lines.Add(line);
                }
            }
            this.ParseLines(interaction, lines);
        }

        private void ParseLines(InteractionBuilder interaction, List<string> lines)
        {
            var sb = new StringBuilder();
            var sourceSb = new StringBuilder();
            var targetSb = new StringBuilder();
            var textSb = new StringBuilder();
            var operationNameSb = new StringBuilder();
            var refTextSb = new StringBuilder();
            var refLifelineNameSb = new StringBuilder();
            var argNameSb = new StringBuilder();
            var stream = new AntlrInputStream();
            var lexer = new WebSequenceDiagramsLexer(stream);
            lexer.RemoveErrorListeners();
            var lifelines = new Dictionary<string, LifelineBuilder>();
            var lifelineAliases = new Dictionary<string, string>();
            var combinedFragments = new Stack<CombinedFragmentBuilder>();
            var interactionOperands = new Stack<InteractionOperandBuilder>();
            InteractionUseBuilder reference = null;
            for (int i = 0; i < lines.Count; ++i)
            {
                var currentFragment = combinedFragments.Count > 0 ? combinedFragments.Peek() : null;
                var currentInteraction = interactionOperands.Count > 0 ? interactionOperands.Peek() : null;
                var line = lines[i];
                lexer.SetInputStream(new AntlrInputStream(line));
                var tokens = lexer.GetAllTokens().Where(t => t.Channel == WebSequenceDiagramsLexer.DefaultTokenChannel).ToList();
                sb.Clear();
                foreach (var token in tokens)
                {
                    sb.Append(token.Text);
                }
                line = sb.ToString().Trim();
                if (line.StartsWith("#"))
                {
                    // skip comment
                }
                else if (reference != null && line != "end ref")
                {
                    refTextSb.Append(GetText(line));
                }
                else if (string.IsNullOrWhiteSpace(line))
                {
                    // skip comment
                }
                else if (line.StartsWith("activate ") || line == "activate" || line.StartsWith("deactivate ") || line == "deactivate")
                {
                    // skip
                }
                else if (line.StartsWith("note ") || line == "note")
                {
                    var text = line.Substring(4).Trim();
                    if (tokens.Any(t => t.Type == WebSequenceDiagramsLexer.TColon))
                    {
                        // skip single line note
                    }
                    else
                    {
                        // skip multi line note
                        while (i < lines.Count)
                        {
                            line = lines[i];
                            if (line.StartsWith("#") || line.StartsWith(" ") || line.StartsWith("\t")) /*skip*/;
                            else if (line.Trim() == "end note") break;
                            ++i;
                        }
                    }
                }
                else if (line.StartsWith("title ") || line == "title")
                {
                    string title = GetText(line.Substring(5).Trim());
                    interaction.Name = title;
                }
                else if (line.StartsWith("participant ") || line == "participant")
                {
                    string name = GetText(line.Substring(11).Trim());
                    GetLifeline(name, true, lifelines, lifelineAliases, interaction, i);
                }
                else if (line.StartsWith("destroy ") || line == "destroy")
                {
                    string name = GetText(line.Substring(7).Trim());
                    var lifeline = GetLifeline(name, false, lifelines, lifelineAliases, interaction, i);
                    var destroy = _factory.DestructionOccurrenceSpecification();
                    destroy.Covered = lifeline;
                    if (currentInteraction != null) currentInteraction.Fragment.Add(destroy);
                    else interaction.Fragment.Add(destroy);
                }
                else if (line.StartsWith("loop ") || line == "loop")
                {
                    var loop = _factory.CombinedFragment();
                    loop.InteractionOperator = InteractionOperatorKind.Loop;
                    if (currentInteraction != null) currentInteraction.Fragment.Add(loop);
                    else interaction.Fragment.Add(loop);
                    var body = _factory.InteractionOperand();
                    loop.Operand.Add(body);
                    var guard = _factory.LiteralString();
                    guard.Value = GetText(line.Substring(4).Trim());
                    var constraint = _factory.InteractionConstraint();
                    constraint.Specification = guard;
                    body.Guard = constraint;
                    combinedFragments.Push(loop);
                    interactionOperands.Push(body);
                }
                else if (line.StartsWith("opt ") || line == "opt")
                {
                    var opt = _factory.CombinedFragment();
                    opt.InteractionOperator = InteractionOperatorKind.Opt;
                    if (currentInteraction != null) currentInteraction.Fragment.Add(opt);
                    else interaction.Fragment.Add(opt);
                    var body = _factory.InteractionOperand();
                    opt.Operand.Add(body);
                    var guard = _factory.LiteralString();
                    guard.Value = GetText(line.Substring(3).Trim());
                    var constraint = _factory.InteractionConstraint();
                    constraint.Specification = guard;
                    body.Guard = constraint;
                    combinedFragments.Push(opt);
                    interactionOperands.Push(body);
                }
                else if (line.StartsWith("alt ") || line == "alt")
                {
                    var alt = _factory.CombinedFragment();
                    alt.InteractionOperator = InteractionOperatorKind.Alt;
                    if (currentInteraction != null) currentInteraction.Fragment.Add(alt);
                    else interaction.Fragment.Add(alt);
                    var body = _factory.InteractionOperand();
                    alt.Operand.Add(body);
                    var guard = _factory.LiteralString();
                    guard.Value = GetText(line.Substring(3).Trim());
                    var constraint = _factory.InteractionConstraint();
                    constraint.Specification = guard;
                    body.Guard = constraint;
                    combinedFragments.Push(alt);
                    interactionOperands.Push(body);
                }
                else if (line.StartsWith("else ") || line == "else")
                {
                    var alt = currentFragment;
                    if (currentFragment == null)
                    {
                        this.AddError(i, 0, "Else branch without alt combined fragment.");
                        continue;
                    }
                    if (currentFragment.InteractionOperator != InteractionOperatorKind.Alt)
                    {
                        this.AddError(i, 0, "Else branch for non-alt combined fragment.");
                    }
                    var body = _factory.InteractionOperand();
                    alt.Operand.Add(body);
                    var guard = _factory.LiteralString();
                    guard.Value = GetText(line.Substring(4).Trim());
                    var constraint = _factory.InteractionConstraint();
                    constraint.Specification = guard;
                    body.Guard = constraint;
                    combinedFragments.Push(alt);
                    interactionOperands.Pop();
                    interactionOperands.Push(body);
                }
                else if (line == "end ref")
                {
                    if (reference == null)
                    {
                        this.AddError(i, 0, "End reference without a reference.");
                        continue;
                    }
                    _crossReferences.Add(reference, refTextSb.ToString());
                    reference = null;
                }
                else if (line.StartsWith("end ") || line == "end")
                {
                    if (currentFragment == null)
                    {
                        this.AddError(i, 0, "End without a combined fragment.");
                        continue;
                    }
                    var endKind = line.Substring(3).Trim();
                    if (!string.IsNullOrEmpty(endKind))
                    {
                        switch (endKind)
                        {
                            case "alt":
                                if (currentFragment.InteractionOperator != InteractionOperatorKind.Alt)
                                {
                                    this.AddError(i, 0, string.Format("'{0}' should be 'end alt'.", line));
                                }
                                break;
                            case "opt":
                                if (currentFragment.InteractionOperator != InteractionOperatorKind.Opt)
                                {
                                    this.AddError(i, 0, string.Format("'{0}' should be 'end opt'.", line));
                                }
                                break;
                            case "loop":
                                if (currentFragment.InteractionOperator != InteractionOperatorKind.Loop)
                                {
                                    this.AddError(i, 0, string.Format("'{0}' should be 'end loop'.", line));
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    combinedFragments.Pop();
                    interactionOperands.Pop();
                }
                else if (line.StartsWith("ref ") || line == "ref")
                {
                    var text = GetText(line.Substring(3).Trim());
                    refTextSb.Clear();
                    reference = _factory.InteractionUse();
                    if (currentInteraction != null) currentInteraction.Fragment.Add(reference);
                    else interaction.Fragment.Add(reference);
                    if (text.StartsWith("over "))
                    {
                        refLifelineNameSb.Clear();
                        for (int j = 4; j < tokens.Count; j++)
                        {
                            var token = tokens[j];
                            if (token.Type == WebSequenceDiagramsLexer.TColon || token.Type == WebSequenceDiagramsLexer.TComma)
                            {
                                var covered = GetLifeline(GetText(refLifelineNameSb.ToString()), false, lifelines, lifelineAliases, interaction, i);
                                reference.Covered.Add(covered);
                                if (token.Type == WebSequenceDiagramsLexer.TColon) break;
                            }
                            else
                            {
                                refLifelineNameSb.Append(token.Text);
                            }
                        }
                    }
                }
                else
                {
                    sourceSb.Clear();
                    targetSb.Clear();
                    operationNameSb.Clear();
                    textSb.Clear();
                    var messageSort = MessageSort.SynchCall;
                    int state = 0;
                    int parenCount = 0;
                    int targetStartIndex = 0;
                    string resultVariable = null;
                    List<string> argNames = new List<string>();
                    lexer.Reset();
                    for (int j = 0; j < tokens.Count; ++j)
                    {
                        var token = tokens[j];
                        if (token.Channel != WebSequenceDiagramsLexer.DefaultTokenChannel) continue;
                        switch (state)
                        {
                            case 0:
                                if (token.Type == WebSequenceDiagramsLexer.TSync || token.Type == WebSequenceDiagramsLexer.TAsync ||
                                    token.Type == WebSequenceDiagramsLexer.TReturn || token.Type == WebSequenceDiagramsLexer.TCreate)
                                {
                                    switch (token.Type)
                                    {
                                        case WebSequenceDiagramsLexer.TSync:
                                            messageSort = MessageSort.SynchCall;
                                            break;
                                        case WebSequenceDiagramsLexer.TAsync:
                                            messageSort = MessageSort.AsynchCall;
                                            break;
                                        case WebSequenceDiagramsLexer.TCreate:
                                            messageSort = MessageSort.CreateMessage;
                                            break;
                                        case WebSequenceDiagramsLexer.TReturn:
                                            messageSort = MessageSort.Reply;
                                            break;
                                        default:
                                            break;
                                    }
                                    state = 1;
                                    targetStartIndex = j + 1;
                                }
                                else
                                {
                                    sourceSb.Append(GetText(token.Text));
                                }
                                break;
                            case 1:
                                if (token.Type == WebSequenceDiagramsLexer.TColon)
                                {
                                    state = 2;
                                }
                                else
                                {
                                    targetSb.Append(GetText(token.Text));
                                }
                                break;
                            case 2:
                                if (token.Type == WebSequenceDiagramsLexer.TAssign)
                                {
                                    state = 3;
                                    resultVariable = GetText(operationNameSb.ToString());
                                    operationNameSb.Clear();
                                }
                                else if(token.Type == WebSequenceDiagramsLexer.TOpenParen)
                                {
                                    state = 4;
                                    argNameSb.Clear();
                                    ++parenCount;
                                }
                                else
                                {
                                    operationNameSb.Append(GetText(token.Text));
                                }
                                textSb.Append(GetText(token.Text));
                                break;
                            case 3:
                                if (token.Type == WebSequenceDiagramsLexer.TOpenParen)
                                {
                                    state = 4;
                                    argNameSb.Clear();
                                    ++parenCount;
                                }
                                else
                                {
                                    operationNameSb.Append(GetText(token.Text));
                                }
                                textSb.Append(GetText(token.Text));
                                argNameSb.Clear();
                                break;
                            case 4:
                                if (token.Type == WebSequenceDiagramsLexer.TComma)
                                {
                                    argNames.Add(GetText(argNameSb.ToString()));
                                    argNameSb.Clear();
                                }
                                else if (token.Type == WebSequenceDiagramsLexer.TCloseParen)
                                {
                                    --parenCount;
                                    if (parenCount == 0)
                                    {
                                        state = 5;
                                        var argName = GetText(argNameSb.ToString());
                                        if (argNames.Count > 0 || !string.IsNullOrWhiteSpace(argName))
                                        {
                                            argNames.Add(argName);
                                        }
                                        argNameSb.Clear();
                                    }
                                }
                                else
                                {
                                    argNameSb.Append(token.Text);
                                }
                                textSb.Append(GetText(token.Text));
                                break;
                            case 5:
                                textSb.Append(GetText(token.Text));
                                break;
                            default:
                                break;
                        }
                    }
                    if (state >= 2)
                    {
                        var sourceName = sourceSb.ToString().Trim();
                        var targetName = targetSb.ToString().Trim();
                        if (targetName.StartsWith("ref "))
                        {
                            refTextSb.Clear();
                            reference = _factory.InteractionUse();
                            if (currentInteraction != null) currentInteraction.Fragment.Add(reference);
                            else interaction.Fragment.Add(reference);
                            targetName = targetName.Substring(4).Trim();
                            if (targetName.StartsWith("over "))
                            {
                                refLifelineNameSb.Clear();
                                for (int j = targetStartIndex+4; j < tokens.Count; j++)
                                {
                                    var token = tokens[j];
                                    if (token.Type == WebSequenceDiagramsLexer.TColon || token.Type == WebSequenceDiagramsLexer.TComma)
                                    {
                                        var covered = GetLifeline(GetText(refLifelineNameSb.ToString()), false, lifelines, lifelineAliases, interaction, i);
                                        reference.Covered.Add(covered);
                                        if (token.Type == WebSequenceDiagramsLexer.TColon) break;
                                    }
                                    else
                                    {
                                        refLifelineNameSb.Append(token.Text);
                                    }
                                }
                            }
                            continue;
                        }
                        else if (sourceName == "end ref")
                        {
                            if (reference == null)
                            {
                                this.AddError(i, 0, "End reference without a reference.");
                                continue;
                            }
                            _crossReferences.Add(reference, refTextSb.ToString());
                            reference = null;
                        }
                        else
                        {
                            var source = GetLifeline(sourceName, false, lifelines, lifelineAliases, interaction, i);
                            var target = GetLifeline(targetName, false, lifelines, lifelineAliases, interaction, i);
                            var message = _factory.Message();
                            interaction.Message.Add(message);
                            message.MessageSort = messageSort;
                            message.Name = textSb.ToString().Trim();
                            foreach (var argName in argNames)
                            {
                                var arg = _factory.LiteralString();
                                arg.Value = argName ?? string.Empty;
                                message.Argument.Add(arg);
                            }
                            if (!string.IsNullOrWhiteSpace(resultVariable))
                            {
                                var comment = _factory.Comment();
                                comment.Body = "result:"+resultVariable;
                                message.OwnedComment.Add(comment);
                            }
                            var sendEvent = _factory.MessageOccurrenceSpecification();
                            message.SendEvent = sendEvent;
                            sendEvent.Covered = source;
                            sendEvent.Message = message;
                            var receiveEvent = _factory.MessageOccurrenceSpecification();
                            message.ReceiveEvent = receiveEvent;
                            receiveEvent.Covered = target;
                            receiveEvent.Message = message;
                            if (currentInteraction != null)
                            {
                                currentInteraction.Fragment.Add(sendEvent);
                                currentInteraction.Fragment.Add(receiveEvent);
                            }
                            else
                            {
                                interaction.Fragment.Add(sendEvent);
                                interaction.Fragment.Add(receiveEvent);
                            }
                            var targetProperty = _collaboration.OwnedAttribute.FirstOrDefault(a => a.Name == target.Name);
                            var targetClassifier = targetProperty?.Type as ClassifierBuilder;
                            if (targetClassifier != null && (message.MessageSort == MessageSort.SynchCall || message.MessageSort == MessageSort.AsynchCall))
                            {
                                var callText = textSb.ToString().Trim();
                                var openIndex = callText.IndexOf('(');
                                var operationName = callText;
                                if (openIndex >= 0)
                                {
                                    operationName = callText.Substring(0, openIndex);
                                }
                                List<OperationBuilder> operations = targetClassifier.MAllOperations().Where(op => operationName.Equals(op.Name, StringComparison.InvariantCultureIgnoreCase)).ToList();
                                if (operations != null && operations.Count > 0)
                                {
                                    if (operations.Count > 1)
                                    {
                                        operations = operations.Where(op => op.OwnedParameter.Where(p => p.Direction != ParameterDirectionKind.Return).Count() == argNames.Count).ToList();
                                    }
                                    if (operations.Count == 0)
                                    {
                                        this.AddError(i, 0, string.Format("Type '{0}' has no operations called '{1}' of {2} parameters.", targetClassifier.Name, operationName, argNames.Count));
                                    }
                                    else 
                                    {
                                        message.Signature = operations[0];
                                        if (operations.Count > 1)
                                        {
                                            this.AddError(i, 0, string.Format("Multiple valid operations: {0}", operationName));
                                        }
                                        else if (operations[0].OwnedParameter.Where(p => p.Direction != ParameterDirectionKind.Return).Count() != argNames.Count)
                                        {
                                            this.AddError(i, 0, string.Format("Type '{0}' has no operations called '{1}' of {2} parameters.", targetClassifier.Name, operationName, argNames.Count));
                                        }
                                    }
                                }
                                else
                                {
                                    this.AddError(i, 0, string.Format("Type '{0}' has no operation called '{1}'.", targetClassifier.Name, operationName));
                                }
                            }
                        }
                    }
                    else
                    {
                        this.AddError(i, 0, string.Format("Invalid line: {0}", lines[i]));
                    }
                }
            }
        }

        private string GetText(string text)
        {
            if (text == null) return text;
            if (string.IsNullOrWhiteSpace(text)) return text;
            text = text.Trim();
            int startIndex = 0;
            int endIndex = text.Length;
            if (text.StartsWith("\"") && text.EndsWith("\""))
            {
                startIndex = 1;
                endIndex = text.Length - 1;
            }
            if (endIndex >= startIndex) return text.Substring(startIndex, endIndex - startIndex);
            else return string.Empty;
        }

        private LifelineBuilder GetLifeline(string name, bool participantLine, Dictionary<string, LifelineBuilder> lifelines, Dictionary<string, string> lifelineAliases, InteractionBuilder interaction, int lineIndex)
        {
            string objectName = name;
            string typeName = null;
            string id = null;
            int asIndex = name.IndexOf(" as ");
            if (participantLine && asIndex >= 0)
            {
                id = GetText(name.Substring(asIndex + 4));
                name = GetText(name.Substring(0, asIndex));
                if (lifelineAliases.TryGetValue(id, out var idToName))
                {
                    if (name != idToName)
                    {
                        AddError(lineIndex, 0, $"Lifeline alias '{id}' is already registered for lifeline '{idToName}'.");
                    }
                }
            }
            else if (lifelineAliases.TryGetValue(name, out var existingName))
            {
                name = existingName;
            }
            if (!lifelines.TryGetValue(name, out var lifeline))
            {
                int colonIndex = name.IndexOf(':');
                if (colonIndex >= 0)
                {
                    objectName = name.Substring(0, colonIndex).Trim();
                    typeName = name.Substring(colonIndex + 1, name.Length - colonIndex - 1).Trim();
                }
                else
                {
                    objectName = name;
                    typeName = name;
                }
                lifeline = _factory.Lifeline();
                if (!string.IsNullOrWhiteSpace(objectName)) lifeline.Name = objectName;
                else lifeline.Name = name;
                interaction.Lifeline.Add(lifeline);
                lifelines.Add(name, lifeline);
                TypeBuilder type = this.GetType<ClassBuilder>(typeName);
                if (type == null) type = this.GetType<InterfaceBuilder>(typeName);
                if (type == null) type = this.GetType<EnumerationBuilder>(typeName);
                var lifelineProp = _factory.Property();
                lifelineProp.Name = lifeline.Name;
                _collaboration.OwnedAttribute.Add(lifelineProp);
                lifelineProp.Type = type;
                lifelineProp.Aggregation = AggregationKind.Composite;
                lifeline.Represents = lifelineProp;
                if (typeName == null)
                {
                    this.AddError(lineIndex, 0, string.Format("Lifeline '{0}' does not have a type.", objectName));
                }
                else if (type == null)
                {
                    this.AddError(lineIndex, 0, string.Format("Type '{0}' does not exist in the Class Diagram.", typeName));
                }
                if (id != null)
                {
                    lifelineAliases.Add(id, name);
                }
            }
            return lifeline;
        }

        private TypeBuilder GetType<TType>(string typeName)
            where TType: class, TypeBuilder
        {
            var type = !string.IsNullOrWhiteSpace(typeName) ? _model.Objects.OfType<TType>().Where(t => t.Name == typeName).FirstOrDefault() : null;
            if (type == null && !string.IsNullOrWhiteSpace(typeName))
            {
                type = _model.Objects.OfType<TType>().Where(t => typeName.Equals(t.Name, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
            }
            return type;
        }
    }
}
