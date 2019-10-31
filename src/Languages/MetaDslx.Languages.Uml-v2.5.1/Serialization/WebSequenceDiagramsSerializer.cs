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
        private string _currentFile;

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
        }

        public MutableModel Model => _model;
        public DiagnosticBag Diagnostics => _diagnostics;

        internal void AddError(int line, int column, string message)
        {
            _diagnostics.Add(ModelErrorCode.ERR_ImportError.ToDiagnostic(new ExternalFileLocation(_currentFile, new TextSpan(), new LinePositionSpan(new LinePosition(line, column), new LinePosition(line, column))), message));
        }

        internal void AddError(int line, int column, ModelException mex)
        {
            _diagnostics.Add(ModelErrorCode.ERR_ImportError.ToDiagnostic(new ExternalFileLocation(_currentFile, new TextSpan(), new LinePositionSpan(new LinePosition(line, column), new LinePosition(line, column))), mex.Diagnostic.GetMessage()));
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
            _currentFile = filePath;
            var interaction = _factory.Interaction();
            interaction.Name = filePath;
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
            var stream = new AntlrInputStream();
            var lexer = new WebSequenceDiagramsLexer(stream);
            lexer.RemoveErrorListeners();
            var lifelines = new Dictionary<string, LifelineBuilder>();
            var combinedFragments = new Stack<CombinedFragmentBuilder>();
            var interactionOperands = new Stack<InteractionOperandBuilder>();
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
                line = sb.ToString();
                if (line.StartsWith("#") || string.IsNullOrWhiteSpace(line) || (currentInteraction == null && (line.StartsWith(" ") || line.StartsWith("\t"))))
                {
                    // skip comment
                }
                else if (line.StartsWith("activate ") || line.StartsWith("deactivate "))
                {
                    // skip
                }
                else if (line.StartsWith("note "))
                {
                    var text = line.Substring(5).Trim();
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
                else if (line.StartsWith("title "))
                {
                    string title = GetText(line.Substring(6));
                    interaction.Name = title;
                }
                else if (line.StartsWith("participant "))
                {
                    string name = GetText(line.Substring(12));
                    GetLifeline(name, lifelines, interaction, i);
                }
                else if (line.StartsWith("destroy "))
                {
                    string name = GetText(line.Substring(8));
                    var lifeline = GetLifeline(name, lifelines, interaction, i);
                    var destroy = _factory.DestructionOccurrenceSpecification();
                    destroy.Covered = lifeline;
                    if (currentInteraction != null) currentInteraction.Fragment.Add(destroy);
                    else interaction.Fragment.Add(destroy);
                }
                else if (line.StartsWith("loop "))
                {
                    var loop = _factory.CombinedFragment();
                    loop.InteractionOperator = InteractionOperatorKind.Loop;
                    if (currentInteraction != null) currentInteraction.Fragment.Add(loop);
                    else interaction.Fragment.Add(loop);
                    var body = _factory.InteractionOperand();
                    loop.Operand.Add(body);
                    var guard = _factory.LiteralString();
                    guard.Value = GetText(line.Substring(5));
                    var constraint = _factory.InteractionConstraint();
                    constraint.Specification = guard;
                    body.Guard = constraint;
                    combinedFragments.Push(loop);
                    interactionOperands.Push(body);
                }
                else if (line.StartsWith("opt "))
                {
                    var opt = _factory.CombinedFragment();
                    opt.InteractionOperator = InteractionOperatorKind.Opt;
                    if (currentInteraction != null) currentInteraction.Fragment.Add(opt);
                    else interaction.Fragment.Add(opt);
                    var body = _factory.InteractionOperand();
                    opt.Operand.Add(body);
                    var guard = _factory.LiteralString();
                    guard.Value = GetText(line.Substring(4));
                    var constraint = _factory.InteractionConstraint();
                    constraint.Specification = guard;
                    body.Guard = constraint;
                    combinedFragments.Push(opt);
                    interactionOperands.Push(body);
                }
                else if (line.StartsWith("alt "))
                {
                    var alt = _factory.CombinedFragment();
                    alt.InteractionOperator = InteractionOperatorKind.Alt;
                    if (currentInteraction != null) currentInteraction.Fragment.Add(alt);
                    else interaction.Fragment.Add(alt);
                    var body = _factory.InteractionOperand();
                    alt.Operand.Add(body);
                    var guard = _factory.LiteralString();
                    guard.Value = GetText(line.Substring(4));
                    var constraint = _factory.InteractionConstraint();
                    constraint.Specification = guard;
                    body.Guard = constraint;
                    combinedFragments.Push(alt);
                    interactionOperands.Push(body);
                }
                else if (line.StartsWith("else "))
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
                    guard.Value = GetText(line.Substring(5));
                    var constraint = _factory.InteractionConstraint();
                    constraint.Specification = guard;
                    body.Guard = constraint;
                    combinedFragments.Push(alt);
                    interactionOperands.Pop();
                    interactionOperands.Push(body);
                }
                else if (line.Trim() == "end")
                {
                    if (currentFragment == null)
                    {
                        this.AddError(i, 0, "End without a combined fragment.");
                        continue;
                    }
                    combinedFragments.Pop();
                    interactionOperands.Pop();
                }
                else
                {
                    sourceSb.Clear();
                    targetSb.Clear();
                    operationNameSb.Clear();
                    textSb.Clear();
                    var messageSort = MessageSort.SynchCall;
                    int state = 0;
                    int paramCount = 0;
                    lexer.Reset();
                    foreach (var token in tokens)
                    {
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
                                if (token.Type == WebSequenceDiagramsLexer.TOpenParen)
                                {
                                    state = 3;
                                }
                                else
                                {
                                    operationNameSb.Append(GetText(token.Text));
                                }
                                textSb.Append(GetText(token.Text));
                                break;
                            case 3:
                                if (token.Type == WebSequenceDiagramsLexer.TComma)
                                {
                                    state = 4;
                                    ++paramCount;
                                }
                                else if (token.Type == WebSequenceDiagramsLexer.TCloseParen)
                                {
                                    state = 5;
                                }
                                else
                                {
                                    if (paramCount == 0 && !string.IsNullOrWhiteSpace(token.Text)) paramCount = 1;
                                }
                                textSb.Append(GetText(token.Text));
                                break;
                            case 4:
                                if (token.Type == WebSequenceDiagramsLexer.TCloseParen)
                                {
                                    state = 5;
                                }
                                textSb.Append(GetText(token.Text));
                                break;
                            default:
                                break;
                        }
                    }
                    if (state >= 2)
                    {
                        var source = GetLifeline(sourceSb.ToString().Trim(), lifelines, interaction, i);
                        var target = GetLifeline(targetSb.ToString().Trim(), lifelines, interaction, i);
                        var message = _factory.Message();
                        interaction.Message.Add(message);
                        message.MessageSort = messageSort;
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
                        if (targetClassifier != null)
                        {
                            var callText = textSb.ToString().Trim();
                            var openIndex = callText.IndexOf('(');
                            var operationName = callText;
                            if (openIndex >= 0)
                            {
                                operationName = callText.Substring(0, openIndex);
                            }
                            List<OperationBuilder> operations = null;
                            if (targetClassifier is InterfaceBuilder intf) operations = intf.OwnedOperation.Where(op => op.Name == operationName).ToList();
                            else if (targetClassifier is ClassBuilder cls) operations = cls.OwnedOperation.Where(op => op.Name == operationName).ToList();
                            if (operations != null && operations.Count > 0)
                            {
                                if (operations.Count > 1)
                                {
                                    operations = operations.Where(op => op.OwnedParameter.Count == paramCount).ToList();
                                }
                                if (operations.Count == 0)
                                {
                                    this.AddError(i, 0, string.Format("Type '{0}' has no operations called '{1}' of {2} parameters.", targetClassifier.Name, operationName, paramCount));
                                }
                                else if (operations.Count > 1)
                                {
                                    this.AddError(i, 0, string.Format("Multiple valid operations: {0}", operationName));
                                }
                                else
                                {
                                    message.Signature = operations[0];
                                }
                            }
                            else
                            {
                                this.AddError(i, 0, string.Format("Type '{0}' has no operation called '{1}'.", targetClassifier.Name, operationName));
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
            if (text.StartsWith("\"")) startIndex = 1;
            if (text.EndsWith("\"")) endIndex = text.Length - 1;
            return text.Substring(startIndex, endIndex - startIndex);
        }

        private LifelineBuilder GetLifeline(string name, Dictionary<string, LifelineBuilder> lifelines, InteractionBuilder interaction, int lineIndex)
        {
            if (!lifelines.TryGetValue(name, out var lifeline))
            {
                string objectName = name;
                string typeName = null;
                int colonIndex = name.IndexOf(':');
                if (colonIndex >= 0)
                {
                    objectName = name.Substring(0, colonIndex).Trim();
                    typeName = name.Substring(colonIndex + 1, name.Length - colonIndex - 1).Trim();
                }
                lifeline = _factory.Lifeline();
                lifeline.Name = objectName;
                interaction.Lifeline.Add(lifeline);
                lifelines.Add(name, lifeline);
                var type = !string.IsNullOrWhiteSpace(typeName) ? _model.Objects.OfType<TypeBuilder>().Where(t => t.Name == typeName).FirstOrDefault() : null;
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
            }
            return lifeline;
        }
    }
}
