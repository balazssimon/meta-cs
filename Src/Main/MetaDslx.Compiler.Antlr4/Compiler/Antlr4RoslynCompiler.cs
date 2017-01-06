using Antlr4.Runtime;
using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Text;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using MetaDslx.Compiler.MetaModel;

namespace MetaDslx.Compiler.Antlr4Roslyn
{
    public class Antlr4RoslynCompiler : IAntlrErrorListener<int>, IAntlrErrorListener<IToken>
    {
        internal Antlr4Grammar Grammar { get; private set; }
        internal Antlr4RoslynLexer Lexer { get; private set; }
        internal Antlr4RoslynParser Parser { get; private set; }
        internal CommonTokenStream CommonTokenStream { get; private set; }
        internal Antlr4RoslynParser.GrammarSpecContext ParseTree { get; private set; }
        public string Source { get; private set; }
        public string DefaultNamespace { get; private set; }
        public string FileName { get; private set; }
        public string OutputDirectory { get; private set; }
        public bool GenerateOutput { get; set; }
        private DiagnosticBag DiagnosticBag { get; set; }
        public ImmutableArray<Diagnostic> Diagnostics { get; private set; }
        public string LanguageName { get; private set; }

        public bool IsLexer { get; private set; }
        public bool IsParser { get; private set; }

        public string GeneratedFixedTokensSource { get; private set; }
        public string GeneratedInternalSyntax { get; private set; }
        public string GeneratedSyntax { get; private set; }
        public string GeneratedSyntaxTree { get; private set; }
        public string GeneratedLanguage { get; private set; }
        public string GeneratedErrorCode { get; private set; }
        public string GeneratedSyntaxParser { get; private set; }
        public string GeneratedLanguageVersion { get; private set; }
        public string GeneratedParseOptions { get; private set; }
        public string GeneratedFeature { get; private set; }

        public Antlr4RoslynCompiler(string source, string defaultNamespace, string outputDirectory, string fileName)
        {
            this.Source = source;
            this.DefaultNamespace = defaultNamespace;
            this.OutputDirectory = outputDirectory;
            this.FileName = fileName;
            this.GenerateOutput = true;
            string languageName = Path.GetFileNameWithoutExtension(this.FileName);
            if (languageName.EndsWith("Parser")) languageName = languageName.Substring(0, languageName.Length - 6);
            else if (languageName.EndsWith("Lexer")) languageName = languageName.Substring(0, languageName.Length - 5);
            this.LanguageName = languageName;
        }

        public void Compile()
        {
            AntlrInputStream inputStream = new AntlrInputStream(this.Source);
            this.Lexer = new Antlr4RoslynLexer(inputStream);
            this.CommonTokenStream = new CommonTokenStream(this.Lexer);
            this.Parser = new Antlr4RoslynParser(this.CommonTokenStream);
            this.Lexer.RemoveErrorListeners();
            this.Parser.RemoveErrorListeners();
            this.Lexer.AddErrorListener(this);
            this.Parser.AddErrorListener(this);
            this.DiagnosticBag = new DiagnosticBag();

            this.ParseTree = this.Parser.grammarSpec();
            RoslynRuleCollector ruleCollector = new RoslynRuleCollector(this);
            ruleCollector.Visit(this.ParseTree);
            this.IsLexer = ruleCollector.IsLexer;
            this.IsParser = ruleCollector.IsParser;
            this.Grammar = ruleCollector.Grammar;

            this.SimplifyElements();
            if (this.GenerateOutput) this.Generate();

            this.Diagnostics = this.DiagnosticBag.ToReadOnly();
        }

        public void Generate()
        {
            if (!this.IsParser) return;
            if (this.DiagnosticBag.HasAnyErrors()) return;
            CompilerGenerator generator = new CompilerGenerator(this.Grammar);
            generator.Properties.DefaultNamespace = this.DefaultNamespace;
            generator.Properties.LanguageName = this.LanguageName;
            this.GeneratedInternalSyntax = generator.GenerateInternalSyntax();
            this.GeneratedSyntax = generator.GenerateSyntax();
            this.GeneratedSyntaxTree = generator.GenerateSyntaxTree();
            this.GeneratedLanguage = generator.GenerateLanguage();
            this.GeneratedErrorCode = generator.GenerateErrorCode();
            this.GeneratedSyntaxParser = generator.GenerateSyntaxParser();
            this.GeneratedLanguageVersion = generator.GenerateLanguageVersion();
            this.GeneratedParseOptions = generator.GenerateParseOptions();
            this.GeneratedFeature = generator.GenerateFeature();
        }

        private void SimplifyElements()
        {
            if (this.DiagnosticBag.HasAnyErrors()) return;
            bool simplified = true;
            while(simplified)
            {
                simplified = false;
                foreach (var rule in this.Grammar.ParserRules)
                {
                    foreach (var elem in rule.AllElements)
                    {
                        if (this.SimplifyElement(elem))
                        {
                            simplified = true;
                        }
                    }
                    foreach (var alt in rule.Alternatives)
                    {
                        foreach (var elem in alt.AllElements)
                        {
                            if (this.SimplifyElement(elem))
                            {
                                simplified = true;
                            }
                        }
                    }
                }
            }
        }

        private bool SimplifyElement(Antlr4ParserRuleElement elem)
        {
            /*if (!elem.IsList && !elem.IsBlock && !elem.IsToken)
            {
                var elemRule = this.Grammar.ParserRules.FirstOrDefault(r => r.Name == elem.Type);
                if (elemRule != null)
                {
                    if (elemRule.Elements.Count == 1 && elemRule.Elements[0].IsList && elemRule.Elements[0].IsSeparated)
                    {
                        var listElem = elemRule.Elements[0];
                        elem.IsList = listElem.IsList;
                        elem.IsSeparated = listElem.IsSeparated;
                        elem.IsOptional |= listElem.IsOptional;
                        elem.EndToken = listElem.EndToken;
                        elem.OriginalType = elem.Type;
                        elem.Type = listElem.Type;
                        elem.Separator = listElem.Separator;
                        elem.IsSimplified = true;
                        elem.Annotations = listElem.Annotations;
                        return true;
                    }
                }
            }*/
            return false;
        }

        public static string FixedTokenToCSharpString(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return null;
            if (value.Length >= 2 && value.StartsWith("'") && value.EndsWith("'"))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append('"');
                value = value.Substring(1, value.Length - 2);
                for (int i = 0; i < value.Length; ++i)
                {
                    if (i + 1 < value.Length && value[i] == '\\')
                    {
                        sb.Append(value[i]);
                        sb.Append(value[i + 1]);
                        ++i;
                    }
                    else if (value[i] == '"')
                    {
                        sb.Append("\\\"");
                    }
                    else
                    {
                        sb.Append(value[i]);
                    }
                }
                sb.Append('"');
                value = sb.ToString();
                return value;
            }
            return value;
        }

        public static string FixedTokenToText(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return null;
            if (value.Length >= 2 && value.StartsWith("'") && value.EndsWith("'"))
            {
                StringBuilder sb = new StringBuilder();
                value = value.Substring(1, value.Length - 2);
                for (int i = 0; i < value.Length; ++i)
                {
                    if (i + 1 < value.Length && value[i] == '\\')
                    {
                        switch (value[i + 1])
                        {
                            case 'b': sb.Append("\b"); break;
                            case 't': sb.Append("\t"); break;
                            case 'n': sb.Append("\n"); break;
                            case 'f': sb.Append("\f"); break;
                            case 'r': sb.Append("\r"); break;
                            case '"': sb.Append("\""); break;
                            case '\'': sb.Append("\'"); break;
                            case '\\': sb.Append("\\"); break;
                            default: sb.Append(value[i + 1]); break;
                        }
                        ++i;
                    }
                    else
                    {
                        sb.Append(value[i]);
                    }
                }
                value = sb.ToString();
                return value;
            }
            return value;
        }

        private TextSpan GetTextSpan(IToken token)
        {
            return new TextSpan(token.StartIndex, token.StopIndex - token.StartIndex + 1);
        }

        private LinePositionSpan GetLinePositionSpan(IToken token)
        {
            if (token == null) return LinePositionSpan.Zero;
            int startLine = token.Line;
            int startPosition = token.Column;
            int endLine;
            int endPosition;
            string text = token.Text;
            if (!text.Contains('\n'))
            {
                endLine = startLine;
                endPosition = startPosition + token.Text.Length;
            }
            else
            {
                endLine = token.Line + token.Text.Count(c => c == '\n');
                int index = text.LastIndexOf('\n');
                endPosition = text.Length - index;
            }
            if (startLine > 0 && endLine > 0)
            {
                --startLine;
                --endLine;
            }
            return new LinePositionSpan(new LinePosition(startLine, startPosition), new LinePosition(endLine, endPosition));
        }

        private TextSpan GetTextSpan(ParserRuleContext rule)
        {
            return new TextSpan(rule.Start.StartIndex, rule.Stop.StopIndex - rule.Start.StartIndex + 1);
        }

        private LinePositionSpan GetLinePositionSpan(ParserRuleContext rule)
        {
            int startLine = rule.Start.Line;
            int startPosition = rule.Start.Column;
            int endLine = rule.Stop.Line;
            int endPosition = rule.Stop.Column + rule.Stop.Text.Length;
            if (startLine > 0 && endLine > 0)
            {
                --startLine;
                --endLine;
            }
            return new LinePositionSpan(new LinePosition(startLine, startPosition), new LinePosition(endLine, endPosition));
        }

        private TextSpan GetTextSpan(int position)
        {
            return new TextSpan(position, 0);
        }

        private LinePositionSpan GetLinePositionSpan(int line, int charPositionInLine)
        {
            if (line > 0) --line;
            return new LinePositionSpan(new LinePosition(line, charPositionInLine), new LinePosition(line, charPositionInLine));
        }

        public void SyntaxError(IRecognizer recognizer, int offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            IToken token = e.OffendingToken;
            if (token != null)
            {
                this.DiagnosticBag.Add(Antlr4RoslynMessageProvider.Instance.CreateDiagnostic(Antlr4RoslynErrors.ERR_SyntaxError, Location.Create(this.FileName, this.GetTextSpan(token), this.GetLinePositionSpan(token)), msg));
            }
            else
            {
                this.DiagnosticBag.Add(Antlr4RoslynMessageProvider.Instance.CreateDiagnostic(Antlr4RoslynErrors.ERR_SyntaxError, Location.Create(this.FileName, this.GetTextSpan(recognizer.InputStream.Index), this.GetLinePositionSpan(line, charPositionInLine)), msg));
            }
        }

        public void SyntaxError(IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            if (offendingSymbol != null)
            {
                this.DiagnosticBag.Add(Antlr4RoslynMessageProvider.Instance.CreateDiagnostic(Antlr4RoslynErrors.ERR_SyntaxError, Location.Create(this.FileName, this.GetTextSpan(offendingSymbol), this.GetLinePositionSpan(offendingSymbol)), msg));
            }
            else
            {
                this.DiagnosticBag.Add(Antlr4RoslynMessageProvider.Instance.CreateDiagnostic(Antlr4RoslynErrors.ERR_SyntaxError, Location.Create(this.FileName, this.GetTextSpan(recognizer.InputStream.Index), this.GetLinePositionSpan(line, charPositionInLine)), msg));
            }
        }

        internal void AddDiagnostic(object node, Antlr4RoslynErrors code, params object[] args)
        {
            if (node is ParserRuleContext)
            {
                this.AddDiagnostic((ParserRuleContext)node, code, args);
            }
            else if (node is ITerminalNode)
            {
                this.AddDiagnostic((ParserRuleContext)node, code, args);
            }
            else
            {
                throw new ArgumentException("Node must be a terminal or a parser rule.", nameof(node));
            }
        }

        internal void AddDiagnostic(ITerminalNode token, Antlr4RoslynErrors code, params object[] args)
        {
            this.DiagnosticBag.Add(Antlr4RoslynMessageProvider.Instance.CreateDiagnostic(code, Location.Create(this.FileName, this.GetTextSpan(token.Symbol), this.GetLinePositionSpan(token.Symbol)), args));
        }

        internal void AddDiagnostic(ParserRuleContext rule, Antlr4RoslynErrors code, params object[] args)
        {
            this.DiagnosticBag.Add(Antlr4RoslynMessageProvider.Instance.CreateDiagnostic(code, Location.Create(this.FileName, this.GetTextSpan(rule), this.GetLinePositionSpan(rule)), args));
        }

        internal static readonly string[] reservedNames =
            {
                "abstract",
                "as",
                "base",
                "bool",
                "break",
                "byte",
                "case",
                "catch",
                "char",
                "checked",
                "class",
                "const",
                "continue",
                "decimal",
                "default",
                "delegate",
                "do",
                "double",
                "else",
                "enum",
                "event",
                "explicit",
                "extern",
                "false",
                "finally",
                "fixed",
                "float",
                "for",
                "foreach",
                "goto",
                "if",
                "implicit",
                "in",
                "int",
                "interface",
                "internal",
                "is",
                "lock",
                "long",
                "namespace",
                "new",
                "null",
                "object",
                "operator",
                "out",
                "override",
                "params",
                "private",
                "protected",
                "public",
                "readonly",
                "ref",
                "return",
                "sbyte",
                "sealed",
                "short",
                "sizeof",
                "stackalloc",
                "static",
                "string",
                "struct",
                "switch",
                "this",
                "throw",
                "true",
                "try",
                "typeof",
                "uint",
                "ulong",
                "unchecked",
                "unsafe",
                "ushort",
                "using",
                "virtual",
                "void",
                "volatile",
                "while",
            };
    }

    internal class RoslynRuleCollector : Antlr4RoslynParserBaseVisitor<object>
    {
        private Antlr4RoslynCompiler compiler;

        private string parserName;
        private string lexerName;
        private string parserHeader;
        private string lexerHeader;

        private Antlr4Grammar currentGrammar;
        private Antlr4Mode currentMode;
        private Antlr4LexerRule currentLexerRule;

        public Antlr4Grammar Grammar { get { return this.currentGrammar; } }
        public bool IsParser { get; private set; }
        public bool IsLexer { get; private set; }

        public RoslynRuleCollector(Antlr4RoslynCompiler compiler)
        {
            this.compiler = compiler;
        }

        private void CollectAnnotations(Antlr4AnnotatedObject obj, Antlr4RoslynParser.AnnotationContext[] annotations)
        {
            foreach (var annot in annotations)
            {
                string annotationName = annot.qualifiedName().GetText();
                if (annot.annotationBody() != null)
                {
                    var propertyBuilder = ImmutableArray.CreateBuilder<MetaAnnotationProperty>();
                    if (annot.annotationBody().annotationAttributeList() != null)
                    {
                        foreach (var attr in annot.annotationBody().annotationAttributeList().annotationAttribute())
                        {
                            string propertyName = attr.annotationIdentifier().GetText();
                            MetaAnnotationProperty property = null;
                            if (attr.expression() != null)
                            {
                                string value = attr.expression().GetText();
                                property = new MetaAnnotationProperty(propertyName, value);
                            }
                            else if (attr.expressionList() != null)
                            {
                                var valueBuilder = ImmutableArray.CreateBuilder<string>();
                                foreach (var expr in attr.expressionList().expression())
                                {
                                    string value = expr.GetText();
                                    valueBuilder.Add(value);
                                }
                                property = new MetaAnnotationProperty(propertyName, valueBuilder.ToImmutable());
                            }
                            if (property != null)
                            {
                                propertyBuilder.Add(property);
                            }
                        }
                    }
                    else if (annot.annotationBody().expression() != null)
                    {
                        string value = annot.annotationBody().expression().GetText();
                        propertyBuilder.Add(MetaCompilerAnnotationInfo.CreateDefaultProperty(annotationName, value));
                    }
                    else if (annot.annotationBody().expressionList() != null)
                    {
                        var valueBuilder = ImmutableArray.CreateBuilder<string>();
                        foreach (var expr in annot.annotationBody().expressionList().expression())
                        {
                            string value = expr.GetText();
                            valueBuilder.Add(value);
                        }
                        propertyBuilder.Add(MetaCompilerAnnotationInfo.CreateDefaultProperty(annotationName, valueBuilder.ToImmutable()));
                    }
                    MetaCompilerAnnotation annotation = new MetaCompilerAnnotation(annotationName, propertyBuilder.ToImmutable());
                    obj.Annotations = obj.Annotations.Add(annotation);
                }
                else
                {
                    MetaCompilerAnnotation annotation = new MetaCompilerAnnotation(annotationName, ImmutableArray<MetaAnnotationProperty>.Empty);
                    obj.Annotations = obj.Annotations.Add(annotation);
                }
            }
        }

        public override object VisitGrammarSpec(Antlr4RoslynParser.GrammarSpecContext context)
        {
            if (context.grammarType().PARSER() != null)
            {
                this.parserName = context.identifier().GetText();
                this.lexerName = this.parserName;
                this.IsLexer = false;
                this.IsParser = true;
            }
            else if (context.grammarType().LEXER() != null)
            {
                this.lexerName = context.identifier().GetText();
                this.IsLexer = true;
                this.IsParser = false;
            }
            else
            {
                this.parserName = context.identifier().GetText();
                this.lexerName = this.parserName;
                this.IsLexer = true;
                this.IsParser = true;
            }
            currentGrammar = new Antlr4Grammar();
            currentGrammar.Name = context.identifier().GetText();
            currentMode = new Antlr4Mode(this.currentGrammar);
            currentMode.Name = "DEFAULT_MODE";
            currentGrammar.Modes.Add(currentMode);
            this.CollectAnnotations(currentGrammar, context.annotation());
            return base.VisitGrammarSpec(context);
        }

        public override object VisitTokensSpec([NotNull] Antlr4RoslynParser.TokensSpecContext context)
        {
            if (context.idList() != null)
            {
                foreach (var id in context.idList().annotatedIdentifier())
                {
                    this.currentLexerRule = new Antlr4LexerRule(this.currentMode);
                    this.currentLexerRule.Name = id.identifier().GetText();
                    this.currentLexerRule.FixedToken = id.identifier().GetText();
                    if (this.currentLexerRule != null)
                    {
                        this.currentGrammar.FixedTokens.Add(this.currentLexerRule);
                        this.currentGrammar.LexerRules.Add(this.currentLexerRule);
                        this.currentMode.LexerRules.Add(this.currentLexerRule);
                        this.CollectAnnotations(this.currentLexerRule, id.annotation());
                        this.currentLexerRule = null;
                    }
                }
            }
            return null;
        }

        private bool TryGetToken(string tokenLine, out string tokenName, out int tokenKind, out bool fixedToken)
        {
            tokenName = null;
            tokenKind = 0;
            fixedToken = false;
            int index = 0;
            tokenLine = tokenLine.Trim();
            if (tokenLine.StartsWith("'"))
            {
                ++index;
                while (index < tokenLine.Length)
                {
                    if (tokenLine[index] == '\'')
                    {
                        ++index;
                        tokenName = tokenLine.Substring(0, index);
                        fixedToken = true;
                        break;
                    }
                    if (tokenLine[index] == '\\') ++index;
                    ++index;
                }
                while (index < tokenLine.Length && tokenLine[index] != '=') ++index;
            }
            else
            {
                index = tokenLine.IndexOf('=');
                tokenName = tokenLine.Substring(0, index).Trim();
            }
            return tokenName != null && int.TryParse(tokenLine.Substring(index + 1).Trim(), out tokenKind) && tokenKind > 0;
        }

        public override object VisitOption(Antlr4RoslynParser.OptionContext context)
        {
            if (context.identifier().GetText() == "tokenVocab")
            {
                this.lexerName = context.optionValue().GetText();
            }
            if (context.identifier().GetText() == "tokenVocab")
            {
                string tokenVocabName = context.optionValue().GetText();
                string tokenVocabFileName = Path.Combine(this.compiler.OutputDirectory, tokenVocabName + ".tokens");
                if (File.Exists(tokenVocabFileName))
                {
                    Dictionary<string, int> fixedTokens = new Dictionary<string, int>();
                    using (StreamReader reader = new StreamReader(tokenVocabFileName))
                    {
                        while (!reader.EndOfStream)
                        {
                            string line = reader.ReadLine();
                            string tokenName;
                            int tokenKind;
                            bool fixedToken;
                            if (!string.IsNullOrEmpty(line) && this.TryGetToken(line, out tokenName, out tokenKind, out fixedToken))
                            {
                                if (fixedToken)
                                {
                                    fixedTokens.Add(tokenName, tokenKind);
                                }
                                else
                                {
                                    Antlr4LexerRule rule = new Antlr4LexerRule(this.currentMode);
                                    rule.Name = tokenName;
                                    rule.Kind = tokenKind;
                                    rule.Artificial = true;
                                    this.currentGrammar.LexerRules.Add(rule);
                                }
                            }
                        }
                    }
                    foreach (var fixedToken in fixedTokens)
                    {
                        Antlr4LexerRule rule = this.currentGrammar.LexerRules.FirstOrDefault(r => r.Kind == fixedToken.Value);
                        if (rule != null)
                        {
                            rule.FixedToken = fixedToken.Key;
                            this.currentGrammar.FixedTokens.Add(rule);
                        }
                    }
                }
            }
            return base.VisitOption(context);
        }

        public override object VisitAction(Antlr4RoslynParser.ActionContext context)
        {
            string id = context.identifier().GetText();
            if (id == "header")
            {
                string scopeName = null;
                if (context.actionScopeName() != null)
                {
                    scopeName = context.actionScopeName().GetText();
                }
                string action = context.actionBlock().GetText();
                int first = action.IndexOf('{');
                int last = action.LastIndexOf('}');
                if (first >= 0 && last >= 0)
                {
                    action = action.Substring(first + 1, last - first - 1);
                }
                if (scopeName == null || scopeName == "parser")
                {
                    this.parserHeader = action;
                }
                if (scopeName == null || scopeName == "lexer")
                {
                    this.lexerHeader = action;
                }
            }
            return base.VisitAction(context);
        }

        public override object VisitModeSpec(Antlr4RoslynParser.ModeSpecContext context)
        {
            currentMode = new Antlr4Mode(this.currentGrammar);
            if (context.identifier() != null)
            {
                currentMode.Name = context.identifier().GetText();
            }
            currentGrammar.Modes.Add(currentMode);
            this.CollectAnnotations(currentMode, context.annotation());
            return base.VisitModeSpec(context);
        }

        public override object VisitLexerRuleSpec(Antlr4RoslynParser.LexerRuleSpecContext context)
        {
            if (context.FRAGMENT() == null)
            {
                this.currentLexerRule = new Antlr4LexerRule(this.currentMode);
                this.currentLexerRule.Name = context.TOKEN_REF().GetText();
                base.VisitLexerRuleSpec(context);
                if (this.currentLexerRule != null)
                {
                    if (context.lexerRuleBlock().lexerAltList().lexerAlt().Length == 1)
                    {
                        Antlr4RoslynParser.LexerAltContext lexerAlt = context.lexerRuleBlock().lexerAltList().lexerAlt(0);
                        if (lexerAlt.lexerElements().lexerElement().Length == 1)
                        {
                            Antlr4RoslynParser.LexerElementContext lexerElement = lexerAlt.lexerElements().lexerElement(0);
                            if (lexerElement.ebnfSuffix() == null)
                            {
                                Antlr4RoslynParser.LexerAtomContext lexerAtom = null;
                                if (lexerElement.labeledLexerElement() != null)
                                {
                                    Antlr4RoslynParser.LabeledLexerElementContext labeledLexerElement = lexerElement.labeledLexerElement();
                                    if (labeledLexerElement.lexerAtom() != null)
                                    {
                                        lexerAtom = labeledLexerElement.lexerAtom();
                                    }
                                }
                                else if (lexerElement.lexerAtom() != null)
                                {
                                    lexerAtom = lexerElement.lexerAtom();
                                }
                                if (lexerAtom != null && lexerAtom.terminal() != null)
                                {
                                    if (lexerAtom.terminal().TOKEN_REF() != null)
                                    {
                                        this.currentLexerRule.FixedToken = lexerAtom.terminal().TOKEN_REF().GetText();
                                        this.currentGrammar.FixedTokenCandidates.Add(this.currentLexerRule);
                                    }
                                    else if (lexerAtom.terminal().STRING_LITERAL() != null)
                                    {
                                        string literal = lexerAtom.terminal().STRING_LITERAL().GetText();
                                        this.currentLexerRule.FixedToken = literal;
                                        this.currentGrammar.FixedTokens.Add(this.currentLexerRule);
                                    }
                                }
                            }
                        }
                    }
                    this.currentGrammar.LexerRules.Add(this.currentLexerRule);
                    this.currentMode.LexerRules.Add(this.currentLexerRule);
                    this.CollectAnnotations(this.currentLexerRule, context.annotation());
                    this.currentLexerRule = null;
                }
            }
            return null;
        }

        public override object VisitLexerCommand(Antlr4RoslynParser.LexerCommandContext context)
        {
            string commandName = context.lexerCommandName().GetText();
            if (string.IsNullOrEmpty(commandName)) return null;
            if (commandName == "more")
            {
                this.currentLexerRule = null;
            }
            return null;
        }

        public override object VisitRuleBlock([NotNull] Antlr4RoslynParser.RuleBlockContext context)
        {
            Antlr4RoslynParser.ParserRuleSpecContext ruleSpec = context.Parent as Antlr4RoslynParser.ParserRuleSpecContext;
            if (ruleSpec != null)
            {
                bool handled = false;
                bool reportedError = false;
                string ruleName = ruleSpec.RULE_REF().GetText();
                Antlr4ParserRule rule = null;
                if (!handled && context.ruleAltList().labeledAlt().Length == 1)
                {
                    if (!handled && this.IsRoslynRule(context.ruleAltList().labeledAlt()[0], ref reportedError, out rule))
                    {
                        handled = true;
                    }
                }
                if (!reportedError && !handled && this.IsRoslynAltList(context, TokenOrRule.Rule, true, ref reportedError, out rule))
                {
                    handled = true;
                }
                if (!reportedError && !handled && this.IsRoslynAltList(context, TokenOrRule.Token, false, ref reportedError, out rule))
                {
                    handled = true;
                }
                bool possiblyGood = false;
                if (!reportedError && !handled)
                {
                    if (this.IsInheritanceRule(context, ref reportedError, out possiblyGood, out rule))
                    {
                        handled = true;
                    }
                    else if (possiblyGood)
                    {
                        handled = true;
                        reportedError = true;
                        this.compiler.AddDiagnostic(ruleSpec.RULE_REF(), Antlr4RoslynErrors.ERR_RuleMapUnnamedAlt, ruleName);
                    }
                }
                if (!reportedError && !handled)
                {
                    this.compiler.AddDiagnostic(ruleSpec.RULE_REF(), Antlr4RoslynErrors.ERR_RuleMapTooComplex, ruleName);
                }
                if (!reportedError && handled && rule != null)
                {
                    this.CollectAnnotations(rule, ruleSpec.annotation());
                    this.Grammar.ParserRules.Add(rule);
                    rule.Name = ruleName;
                }
            }
            else
            {
                this.compiler.AddDiagnostic(context, Antlr4RoslynErrors.ERR_BlockUnhandled);
            }
            return base.VisitRuleBlock(context);
        }

        private bool CheckUniqueElements(Antlr4ParserRule rule, ref bool reportedErrors)
        {
            bool result = true;
            var elements = rule.AllElements;
            for (int i = 0; i < elements.Count; i++)
            {
                if (elements[i].IsBlock) continue;
                bool renameNeeded = false;
                for (int j = 0; j < elements.Count; j++)
                {
                    if (j == i || elements[j].IsBlock) continue;
                    if (elements[j].Name == elements[i].Name)
                    {
                        renameNeeded = true;
                        break;
                    }
                }
                if (renameNeeded)
                {
                    result = false;
                    reportedErrors = true;
                    this.compiler.AddDiagnostic(elements[i].Node, Antlr4RoslynErrors.ERR_UnnamedElement, elements[i].Type);
                }
            }
            return result;
        }

        private bool IsInheritanceRule(Antlr4RoslynParser.RuleBlockContext context, ref bool reportedErrors, out bool possiblyGood, out Antlr4ParserRule rule)
        {
            bool allNamed = true;
            foreach (var alt in context.ruleAltList().labeledAlt())
            {
                if (alt.identifier() == null)
                {
                    allNamed = false;
                    break;
                }
            }
            rule = new Antlr4ParserRule(this.currentGrammar);
            possiblyGood = true;
            foreach (var alt in context.ruleAltList().labeledAlt())
            {
                string ruleName = alt.identifier() != null ? alt.identifier().GetText() : null;
                bool handled = false;
                Antlr4ParserRule ruleAlt;
                if (!handled && this.IsRoslynRule(alt, ref reportedErrors, out ruleAlt))
                {
                    handled = true;
                    ruleAlt.Name = ruleName;
                    ruleAlt.ParentRule = rule;
                    rule.Alternatives.Add(ruleAlt);
                    this.CollectAnnotations(ruleAlt, alt.annotation());
                }
                if (!handled)
                {
                    possiblyGood = false;
                }
            }
            return allNamed && possiblyGood;
        }

        private bool IsRoslynRule(Antlr4RoslynParser.LabeledAltContext context, ref bool reportedErrors, out Antlr4ParserRule rule)
        {
            Antlr4RoslynParser.ElementContext[] elems = context.alternative().element();
            rule = new Antlr4ParserRule(this.Grammar);
            for (int i = 0; i < elems.Length; ++i)
            {
                Antlr4ParserRuleElement element;
                int skip = this.IsRoslynRuleElement(elems[i], i + 1 < elems.Length ? elems[i + 1] : null, i + 2 < elems.Length ? elems[i + 2] : null, true, ref reportedErrors, out element);
                if (skip > 0)
                {
                    element.Rule = rule;
                    rule.Elements.Add(element);
                    i += skip - 1;
                }
                else
                {
                    return false;
                }
            }
            return this.CheckUniqueElements(rule, ref reportedErrors);
        }

        private int IsRoslynRuleElement(Antlr4RoslynParser.ElementContext first, Antlr4RoslynParser.ElementContext second, Antlr4RoslynParser.ElementContext third, bool allowBlocks, ref bool reportedErrors, out Antlr4ParserRuleElement element)
        {
            int skip = this.IsSeparatedList(first, second, third, out element);
            if (skip > 0)
            {
                return skip;
            }
            Antlr4RoslynParser.ElementContext elem = first;
            if (this.IsSingleTokenOrRuleElement(elem, TokenOrRule.Any, true, out element))
            {
                return 1;
            }
            else if (elem.labeledElement() != null && elem.labeledElement().block() != null)
            {
                if (this.IsRoslynBlockTokenAlts(elem.labeledElement().block(), ref reportedErrors, out element))
                {
                    element.Name = elem.labeledElement().identifier().GetText();
                    if (this.IsEbnfOptional(elem.ebnfSuffix()))
                    {
                        element.IsOptional = true;
                    }
                    if (this.IsEbnfList(elem.ebnfSuffix()))
                    {
                        element.IsList = true;
                    }
                    return 1;
                }
                this.compiler.AddDiagnostic(elem.labeledElement().identifier(), Antlr4RoslynErrors.ERR_BlockMap);
                return 0;
            }
            else if (elem.ebnf() != null)
            {
                if (this.IsRoslynBlockSingleAlt(elem.ebnf().block(), ref reportedErrors, out element))
                {
                    Antlr4RoslynParser.BlockSuffixContext blockSuffix = elem.ebnf().blockSuffix();
                    if (blockSuffix != null)
                    {
                        if (this.IsEbnfOptional(blockSuffix.ebnfSuffix()))
                        {
                            element.IsOptional = true;
                            return 1;
                        }
                        this.compiler.AddDiagnostic(blockSuffix, Antlr4RoslynErrors.ERR_BlockMapSuffix);
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }
                }
                else if (this.IsRoslynBlockTokenAlts(elem.ebnf().block(), ref reportedErrors, out element))
                {
                    reportedErrors = true;
                    this.compiler.AddDiagnostic(elem.ebnf().block(), Antlr4RoslynErrors.ERR_UnnamedBlock);
                    return 0;
                }
                this.compiler.AddDiagnostic(elem.ebnf().block(), Antlr4RoslynErrors.ERR_BlockMap);
                return 0;
            }
            return 0;
        }

        private bool IsEbnfOptional(Antlr4RoslynParser.EbnfSuffixContext context)
        {
            if (context == null) return false;
            return context.PLUS() == null && context.STAR() == null && context.QUESTION().Length == 1;
        }

        private bool IsEbnfList(Antlr4RoslynParser.EbnfSuffixContext context)
        {
            if (context == null) return false;
            return (context.PLUS() != null || context.STAR() != null) && context.QUESTION().Length == 0;
        }

        private bool IsRoslynBlock(Antlr4RoslynParser.BlockContext context, ref bool reportedErrors, out Antlr4ParserRuleElement block)
        {
            if (this.IsRoslynBlockTokenAlts(context, ref reportedErrors, out block))
            {
                return true;
            }
            if (this.IsRoslynBlockSingleAlt(context, ref reportedErrors, out block))
            {
                return true;
            }
            return false;
        }

        private bool IsRoslynAltList(Antlr4RoslynParser.RuleBlockContext context, TokenOrRule kind, bool allowEbnf, ref bool reportedErrors, out Antlr4ParserRule rule)
        {
            rule = new Antlr4ParserRule(this.Grammar);
            Antlr4ParserRuleElement blockElem = null;
            if (kind == TokenOrRule.Token)
            {
                blockElem = new Antlr4ParserRuleElement(context);
                blockElem.Rule = rule;
                blockElem.Name = ((Antlr4RoslynParser.ParserRuleSpecContext)(context.Parent)).RULE_REF().GetText();
                blockElem.IsFixedTokenAltBlock = true;
                blockElem.IsBlock = true;
                rule.Elements.Add(blockElem);
            }
            var alts = context.ruleAltList().labeledAlt().Select(la => la.alternative()).ToList();
            foreach (var alt in alts)
            {
                Antlr4ParserRuleElement element;
                if (this.IsRoslynSingleTokenOrRuleElementAlt(alt, kind, allowEbnf, out element))
                {
                    if (blockElem != null)
                    {
                        element.ParentBlock = blockElem;
                        blockElem.BlockItems.Add(element);
                    }
                    else
                    {
                        element.Rule = rule;
                        rule.Elements.Add(element);
                    }
                }
                else
                {
                    rule = null;
                    return false;
                }
            }
            rule.IsSimpleAlt = kind == TokenOrRule.Rule;
            return this.CheckUniqueElements(rule, ref reportedErrors);
        }
        
        private bool IsRoslynBlockTokenAlts(Antlr4RoslynParser.BlockContext context, ref bool reportedErrors, out Antlr4ParserRuleElement block)
        {
            block = new Antlr4ParserRuleElement(context);
            block.IsBlock = true;
            block.IsFixedTokenAltBlock = true;
            var alts = context.altList().alternative();
            foreach (var alt in alts)
            {
                Antlr4ParserRuleElement token;
                if (this.IsRoslynSingleTokenOrRuleElementAlt(alt, TokenOrRule.Token, false, out token))
                {
                    token.ParentBlock = block;
                    block.BlockItems.Add(token);
                }
                else
                {
                    block = null;
                    return false;
                }
            }
            return true;
        }

        private bool IsRoslynBlockSingleAlt(Antlr4RoslynParser.BlockContext context, ref bool reportedErrors, out Antlr4ParserRuleElement block)
        {
            if (context.altList().alternative().Length == 1)
            {
                block = new Antlr4ParserRuleElement(context);
                block.IsBlock = true;
                var alt = context.altList().alternative()[0];
                Antlr4RoslynParser.ElementContext[] elems = alt.element();
                for (int i = 0; i < elems.Length; ++i)
                {
                    Antlr4ParserRuleElement element;
                    int skip = this.IsRoslynRuleElement(elems[i], i + 1 < elems.Length ? elems[i + 1] : null, i + 2 < elems.Length ? elems[i + 2] : null, false, ref reportedErrors, out element);
                    if (skip > 0)
                    {
                        element.ParentBlock = block;
                        block.BlockItems.Add(element);
                        i += skip - 1;
                    }
                    else
                    {
                        this.compiler.AddDiagnostic(elems[i], Antlr4RoslynErrors.ERR_ElementMap);
                        reportedErrors = true;
                        block = null;
                        return false;
                    }
                }
                return true;
            }
            block = null;
            return false;
        }

        private bool IsRoslynSingleElementAlt(Antlr4RoslynParser.AlternativeContext context, TokenOrRule kind, bool allowEbnf, ref bool reportedErrors, out Antlr4ParserRuleElement element)
        {
            Antlr4RoslynParser.ElementContext[] elems = context.element();
            int skip = this.IsRoslynRuleElement(elems[0], elems.Length >= 2 ? elems[1] : null, elems.Length >= 3 ? elems[2] : null, false, ref reportedErrors, out element);
            if (skip > 0 && skip == elems.Length)
            {
                return true;
            }
            element = null;
            return false;
        }

        private bool IsRoslynSingleTokenOrRuleElementAlt(Antlr4RoslynParser.AlternativeContext context, TokenOrRule kind, bool allowEbnf, out Antlr4ParserRuleElement element)
        {
            if (context.element().Length == 1)
            {
                Antlr4RoslynParser.ElementContext elem = context.element()[0];
                if (this.IsSingleTokenOrRuleElement(elem, kind, allowEbnf, out element))
                {
                    return true;
                }
            }
            element = null;
            return false;
        }

        private bool IsSingleTokenOrRuleElement(Antlr4RoslynParser.ElementContext elem, TokenOrRule kind, bool allowEbnf, out Antlr4ParserRuleElement element)
        {
            element = null;
            if (elem.ebnf() == null && elem.actionBlock() == null)
            {
                string name = null;
                Antlr4RoslynParser.AtomContext atom = null;
                if (elem.labeledElement() != null)
                {
                    if (elem.labeledElement().atom() != null && elem.labeledElement().PLUS_ASSIGN() == null)
                    {
                        name = elem.labeledElement().identifier().GetText();
                        atom = elem.labeledElement().atom();
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (elem.atom() != null)
                {
                    atom = elem.atom();
                }
                if (atom != null)
                {
                    if (atom.terminal() != null)
                    {
                        if (kind == TokenOrRule.Rule) return false;
                        element = new Antlr4ParserRuleElement(elem);
                        element.Type = atom.terminal().GetText();
                        this.CollectAnnotations(element, elem.annotation());
                    }
                    else if (atom.ruleref() != null)
                    {
                        if (kind == TokenOrRule.Token) return false;
                        element = new Antlr4ParserRuleElement(elem);
                        element.Type = atom.ruleref().GetText();
                        this.CollectAnnotations(element, elem.annotation());
                    }
                    if (element != null)
                    {
                        if (name == null) element.Name = element.Type;
                        else element.Name = name;
                        if (elem.ebnfSuffix() != null)
                        {
                            if (!allowEbnf)
                            {
                                element = null;
                                return false;
                            }
                            if (elem.ebnfSuffix().PLUS() != null)
                            {
                                element.IsList = true;
                            }
                            else if (elem.ebnfSuffix().STAR() != null)
                            {
                                element.IsList = true;
                                element.IsOptional = true;
                            }
                            else if (elem.ebnfSuffix().QUESTION().Length > 0)
                            {
                                element.IsOptional = true;
                            }
                        }
                        return true;
                    }
                }
            }
            return false;
        }

        private int IsSeparatedList(Antlr4RoslynParser.ElementContext first, Antlr4RoslynParser.ElementContext second, Antlr4RoslynParser.ElementContext third, out Antlr4ParserRuleElement element)
        {
            int skip = 0;
            if (first != null && second != null)
            {
                if (second.ebnf() != null && second.ebnf().blockSuffix() != null && second.ebnf().blockSuffix().ebnfSuffix() != null &&
                    (second.ebnf().blockSuffix().ebnfSuffix().PLUS() != null ||
                    second.ebnf().blockSuffix().ebnfSuffix().STAR() != null) &&
                    second.ebnf().blockSuffix().ebnfSuffix().QUESTION().Length == 0 &&
                    second.ebnf().block().altList().alternative().Length == 1 &&
                    second.ebnf().block().altList().alternative()[0].element().Length == 2)
                {
                    Antlr4RoslynParser.ElementContext token = second.ebnf().block().altList().alternative()[0].element()[0];
                    Antlr4RoslynParser.ElementContext ruleRep = second.ebnf().block().altList().alternative()[0].element()[1];
                    Antlr4ParserRuleElement ruleElement;
                    Antlr4ParserRuleElement tokenElement;
                    Antlr4ParserRuleElement ruleRepElement;
                    if (this.IsSingleTokenOrRuleElement(first, TokenOrRule.Rule, false, out ruleElement) &&
                        this.IsSingleTokenOrRuleElement(token, TokenOrRule.Token, false, out tokenElement) &&
                        this.IsSingleTokenOrRuleElement(ruleRep, TokenOrRule.Rule, false, out ruleRepElement) &&
                        ruleElement.Type == ruleRepElement.Type && ruleElement.Name == ruleRepElement.Name)
                    {
                        skip = 2;
                        ruleElement.IsList = true;
                        ruleElement.IsSeparated = true;
                        ruleElement.Separator = tokenElement;
                        tokenElement.ParentBlock = ruleElement;
                        ruleElement.EndToken = Antlr4SeparatedListEndToken.Forbidden;
                        Antlr4ParserRuleElement lastElement;
                        if (third != null && this.IsSingleTokenOrRuleElement(third, TokenOrRule.Token, true, out lastElement) &&
                            lastElement.Type == tokenElement.Type && lastElement.Name == tokenElement.Name)
                        {
                            ++skip;
                            if (!lastElement.IsList)
                            {
                                if (lastElement.IsOptional) ruleElement.EndToken = Antlr4SeparatedListEndToken.Allowed;
                                else ruleElement.EndToken = Antlr4SeparatedListEndToken.Mandatory;
                            }
                        }
                        element = ruleElement;
                        return skip;
                    }
                }
            }
            else if (first != null)
            {
                if (first.ebnf() != null && first.ebnf().blockSuffix() != null && first.ebnf().blockSuffix().ebnfSuffix() != null &&
                    (first.ebnf().blockSuffix().ebnfSuffix().PLUS() != null ||
                    first.ebnf().blockSuffix().ebnfSuffix().STAR() != null) &&
                    first.ebnf().blockSuffix().ebnfSuffix().QUESTION().Length == 0 &&
                    first.ebnf().block().altList().alternative().Length == 1 &&
                    first.ebnf().block().altList().alternative()[0].element().Length == 2)
                {
                    Antlr4RoslynParser.ElementContext ruleRep = second.ebnf().block().altList().alternative()[0].element()[0];
                    Antlr4RoslynParser.ElementContext token = second.ebnf().block().altList().alternative()[0].element()[1];
                    Antlr4ParserRuleElement ruleRepElement;
                    Antlr4ParserRuleElement tokenElement;
                    if (this.IsSingleTokenOrRuleElement(ruleRep, TokenOrRule.Rule, false, out ruleRepElement) &&
                        this.IsSingleTokenOrRuleElement(token, TokenOrRule.Token, false, out tokenElement))
                    {
                        skip = 1;
                        ruleRepElement.IsList = true;
                        ruleRepElement.IsSeparated = true;
                        ruleRepElement.Separator = tokenElement;
                        tokenElement.ParentBlock = ruleRepElement;
                        ruleRepElement.EndToken = Antlr4SeparatedListEndToken.Mandatory;
                        Antlr4ParserRuleElement lastElement;
                        if (second != null && this.IsSingleTokenOrRuleElement(second, TokenOrRule.Rule, false, out lastElement) &&
                            lastElement.Type == ruleRepElement.Type && lastElement.Name == ruleRepElement.Name)
                        {
                            ruleRepElement.EndToken = Antlr4SeparatedListEndToken.Forbidden;
                            ++skip;
                        }
                        element = ruleRepElement;
                        return skip;
                    }
                }
            }
            element = null;
            return 0;
        }

        private enum TokenOrRule
        {
            Any,
            Token,
            Rule
        }
    }

    // TODO: make these classes internal
    public enum Antlr4SeparatedListEndToken
    {
        Forbidden,
        Mandatory,
        Allowed
    }

    public class Antlr4AnnotatedObject
    {
        public Antlr4AnnotatedObject()
        {
            this.Annotations = MetaCompilerAnnotations.Empty;
        }
        public MetaCompilerAnnotations Annotations { get; internal set; }
    }
    public class Antlr4Grammar : Antlr4AnnotatedObject
    {
        public Antlr4Grammar()
        {
            this.ParserRules = new List<Antlr4ParserRule>();
            this.LexerRules = new List<Antlr4LexerRule>();
            this.Modes = new List<Antlr4Mode>();
            this.FixedTokenCandidates = new List<Antlr4LexerRule>();
            this.FixedTokens = new List<Antlr4LexerRule>();
        }
        public string Name { get; set; }
        public List<Antlr4ParserRule> ParserRules { get; private set; }
        public List<Antlr4LexerRule> LexerRules { get; private set; }
        public List<Antlr4Mode> Modes { get; private set; }
        internal List<Antlr4LexerRule> FixedTokenCandidates { get; private set; }
        public List<Antlr4LexerRule> FixedTokens { get; private set; }
        public Antlr4ParserRule FindParserRule(string type)
        {
            return this.ParserRules.FirstOrDefault(rule => rule.Name == type);
        }
    }
    public class Antlr4ParserRule : Antlr4AnnotatedObject
    {
        public Antlr4ParserRule(Antlr4Grammar grammar)
        {
            this.Grammar = grammar;
            this.Elements = new List<Antlr4ParserRuleElement>();
            this.Alternatives = new List<Antlr4ParserRule>();
        }
        public Antlr4Grammar Grammar { get; private set; }
        public Antlr4ParserRule ParentRule { get; internal set; }
        public string Name { get; set; }
        public List<Antlr4ParserRuleElement> Elements { get; private set; }
        public List<Antlr4ParserRule> Alternatives { get; private set; }
        public Antlr4RoslynParser.PropertiesBlockContext PropertiesBlock { get; set; }
        public bool IsSimpleAlt { get; internal set; }
        public List<Antlr4ParserRuleElement> AllElements
        {
            get
            {
                List<Antlr4ParserRuleElement> result = new List<Antlr4ParserRuleElement>();
                foreach (var elem in this.Elements)
                {
                    if (elem.IsBlock && !elem.IsFixedTokenAltBlock)
                    {
                        foreach (var blockElem in elem.BlockItems)
                        {
                            result.Add(blockElem);
                        }
                    }
                    else
                    {
                        result.Add(elem);
                    }
                }
                return result;
            }
        }

        public bool HasElementAnnotations()
        {
            foreach (var elem in this.Elements)
            {
                if (elem.Annotations.Annotations.Count > 0) return true;
            }
            return false;
        }
    }
    public class Antlr4ParserRuleElement : Antlr4AnnotatedObject
    {
        public Antlr4ParserRuleElement(object node)
        {
            this.Node = node;
            this.BlockItems = new List<Antlr4ParserRuleElement>();
        }
        public Antlr4Grammar Grammar
        {
            get
            {
                if (this.Rule != null) return this.Rule.Grammar;
                if (this.ParentBlock != null) return this.ParentBlock.Grammar;
                return null;
            }
        }
        public Antlr4ParserRule Rule { get; internal set; }
        public Antlr4ParserRuleElement ParentBlock { get; internal set; }
        public object Node { get; private set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string OriginalType { get; set; }
        public bool IsOptional { get; set; }
        public bool IsFixedToken
        {
            get
            {
                return this.IsToken && this.Grammar.FixedTokens.Any(ft => ft.Name == this.Name);
            }
        }
        public bool IsList { get; set; }
        public bool IsSeparated { get; set; }
        public bool IsSimplified { get; set; }
        public Antlr4SeparatedListEndToken EndToken { get; set; }
        public Antlr4ParserRuleElement Separator { get; set; }
        public bool IsToken { get { return !string.IsNullOrEmpty(this.Type) && char.IsUpper(this.Type[0]); } }
        public bool IsParserRule { get { return !string.IsNullOrEmpty(this.Type) && char.IsLower(this.Type[0]); } }
        public bool IsBlock { get; set; }
        public bool IsFixedTokenAltBlock { get; set; }
        public List<Antlr4ParserRuleElement> BlockItems { get; private set; }
        public string GetAccessorName()
        {
            bool method = false;
            string result;
            if ((!this.IsSimplified && this.Name != this.Type) ||
                (this.IsSimplified && this.Name != this.OriginalType))
            {
                result = this.Name;
            }
            else
            {
                if (this.Type == "EOF") result = "Eof";
                else if (this.IsSimplified) result = this.OriginalType;
                else result = this.Type;
                method = true;
            }
            if (Antlr4RoslynCompiler.reservedNames.Contains(result)) result = "@"+result;
            if (method) result += "()";
            return result;
        }
    }
    public class Antlr4Mode : Antlr4AnnotatedObject
    {
        public Antlr4Mode(Antlr4Grammar grammar)
        {
            this.Grammar = grammar;
            this.LexerRules = new List<Antlr4LexerRule>();
        }
        public Antlr4Grammar Grammar { get; private set; }
        public string Name { get; set; }
        public List<Antlr4LexerRule> LexerRules { get; private set; }
    }
    public class Antlr4LexerRule : Antlr4AnnotatedObject
    {
        public Antlr4LexerRule(Antlr4Mode mode)
        {
            this.Mode = mode;
        }
        public Antlr4Grammar Grammar { get { return this.Mode.Grammar; } }
        public Antlr4Mode Mode { get; private set; }
        public string Name { get; set; }
        public string FixedToken { get; set; }
        public int Kind { get; set; }
        public bool Artificial { get; set; }
    }
}
