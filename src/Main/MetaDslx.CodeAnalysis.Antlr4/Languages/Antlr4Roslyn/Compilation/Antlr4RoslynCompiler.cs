using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using System.Diagnostics;
using MetaDslx.Languages.Antlr4Roslyn.Generator;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using MetaDslx.Languages.Meta;
using System.Reflection;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax;
using Roslyn.Utilities;

namespace MetaDslx.Languages.Antlr4Roslyn.Compilation
{
    public class Antlr4RoslynCompiler : Antlr4Compiler<Antlr4RoslynLexer, Antlr4RoslynParser>
    {
        private Antlr4Tool _antlr4Tool;
        private string _antlr4TempPath;
        internal Location _noLocation;

        private Antlr4AnnotationRemover remover;
        public string GeneratedAntlr4GrammarFile { get; private set; }
        public string Antlr4GrammarSource { get; private set; }

        public Antlr4Grammar Grammar { get; private set; }
        public string LanguageName { get; private set; }

        public string BaseDirectory { get; private set; }
        public string SyntaxDirectory { get; private set; }
        public string InternalSyntaxDirectory { get; private set; }

        public bool IsLexer { get; private set; }
        public bool IsParser { get; private set; }
        public string LexerHeader { get; private set; }
        public string ParserHeader { get; private set; }
        public bool GenerateCompiler { get; private set; }
        public bool GenerateLanguageService { get; private set; }
        public bool IgnoreRoslynRules { get; private set; }

        public bool GenerateAntlr4 { get; private set; }
        public bool HasAntlr4Errors { get; private set; }

        public string GeneratedSyntaxKind { get; private set; }
        public string GeneratedInternalSyntax { get; private set; }
        public string GeneratedTokenSyntaxFacts { get; private set; }
        public string GeneratedNodeSyntaxFacts { get; private set; }
        public string GeneratedSyntax { get; private set; }
        public string GeneratedSyntaxTree { get; private set; }
        public string GeneratedLanguage { get; private set; }
        public string GeneratedLanguageServicesBase { get; private set; }
        public string GeneratedLanguageServices { get; private set; }
        public string GeneratedErrorCode { get; private set; }
        public string GeneratedSyntaxLexer { get; private set; }
        public string GeneratedSyntaxParser { get; private set; }
        public string GeneratedLanguageVersion { get; private set; }
        public string GeneratedParseOptions { get; private set; }
        public string GeneratedFeature { get; private set; }

        public string GeneratedCompilation { get; private set; }
        public string GeneratedCompilationFactory { get; private set; }
        public string GeneratedCompilationOptions { get; private set; }
        public string GeneratedScriptCompilationInfo { get; private set; }

        public string GeneratedDeclarationTreeBuilder { get; private set; }
        public string GeneratedBinderFactoryVisitor { get; private set; }
        public string GeneratedBoundKind { get; private set; }
        public string GeneratedBoundNodeFactoryVisitor { get; private set; }
        public string GeneratedIsBindableNodeVisitor { get; private set; }
        public string GeneratedSymbolFacts { get; private set; }
        //public string GeneratedLanguageService { get; private set; }

        public Antlr4RoslynCompiler(string manualOutputDirectory, string automaticOutputDirectory, string inputFilePath, string defaultNamespace, Antlr4Tool antlr4Tool)
            : base(manualOutputDirectory, automaticOutputDirectory, inputFilePath, defaultNamespace)
        {
            _antlr4Tool = antlr4Tool;
            this.GenerateAntlr4 = true;
            string languageName = Path.GetFileNameWithoutExtension(this.FileName);
            if (languageName.EndsWith("Parser")) languageName = languageName.Substring(0, languageName.Length - 6);
            else if (languageName.EndsWith("Lexer")) languageName = languageName.Substring(0, languageName.Length - 5);
            this.LanguageName = languageName;

            if (defaultNamespace == null) defaultNamespace = string.Empty;
            if (defaultNamespace.EndsWith(".InternalSyntax"))
            {
                defaultNamespace = defaultNamespace.Substring(0, defaultNamespace.Length - 15);
            }
            if (defaultNamespace.EndsWith(".Syntax"))
            {
                defaultNamespace = defaultNamespace.Substring(0, defaultNamespace.Length - 7);
            }
            this.DefaultNamespace = defaultNamespace;

            this.BaseDirectory = Path.GetDirectoryName(inputFilePath);
            if (!string.IsNullOrWhiteSpace(this.BaseDirectory))
            {
                string directory = this.BaseDirectory;
                DirectoryInfo info = new DirectoryInfo(directory);
                if (info.Name == "InternalSyntax")
                {
                    info = info.Parent;
                }
                if (info.Name == "Syntax")
                {
                    info = info.Parent;
                }
                this.BaseDirectory = info.ToString();
            }

            this.SyntaxDirectory = Path.Combine(this.BaseDirectory, "Syntax"); 
            this.InternalSyntaxDirectory = Path.Combine(this.SyntaxDirectory, "InternalSyntax");

            _noLocation = new ExternalFileLocation(this.InputFilePath, TextSpan.FromBounds(0, 1), new LinePositionSpan(LinePosition.Zero, LinePosition.Zero));
        }

        protected override Antlr4RoslynLexer CreateLexer(AntlrInputStream stream)
        {
            return new Antlr4RoslynLexer(stream);
        }

        protected override Antlr4RoslynParser CreateParser(CommonTokenStream stream)
        {
            return new Antlr4RoslynParser(stream);
        }

        protected override ParserRuleContext DoCreateTree()
        {
            return this.Parser.grammarSpec();
        }

        protected virtual bool PreCompile()
        {
            if (this.Antlr4GrammarSource != null) return true;
            this.InitSyntaxTree();
            if (this.HasErrors) return false;
            if (_antlr4Tool != null)
            {
                var Antlr4Directory = Path.Combine(this.AutomaticOutputDirectory, this.InternalSyntaxDirectory);
                this.remover = new Antlr4AnnotationRemover(this.CommonTokenStream);
                this.remover.Visit(this.ParseTree);
                this.Antlr4GrammarSource = remover.GetText();
                this.GeneratedAntlr4GrammarFile = Path.Combine(this.InternalSyntaxDirectory, Path.ChangeExtension(this.FileName, ".g4"));
                this.WriteOutputFile(this.GeneratedAntlr4GrammarFile, this.Antlr4GrammarSource, omitCodeGenerationWarning: true);
                _antlr4Tool.GenerateVisitor = true;
                if (!this.GenerateAntlr4)
                {
                    _antlr4TempPath = Path.GetTempPath();
                    _antlr4Tool.OutputPath = _antlr4TempPath;
                }
                else
                {
                    _antlr4Tool.OutputPath = null;
                    //if (_antlr4Tool.OutputPath == null) _antlr4Tool.OutputPath = Antlr4Directory;
                }
                _antlr4Tool.SourceCodeFiles.Add(Path.Combine(Antlr4Directory, Path.ChangeExtension(this.FileName, ".g4")));
                _antlr4Tool.TargetNamespace = this.DefaultNamespace + ".Syntax.InternalSyntax";
                bool success = _antlr4Tool.Execute();
                foreach (var diag in _antlr4Tool.Diagnostics)
                {
                    this.AddDiagnostic(diag, this.InputFilePath);
                    if (diag.Severity == DiagnosticSeverity.Error) success = false;
                }
                if (!success)
                {
                    this.AddDiagnostic(Antlr4RoslynErrorCode.ERR_Antlr4ToolError, "could not generate C# files");
                    return false;
                }
                else
                {
                    foreach (var filePath in _antlr4Tool.GeneratedCodeFiles)
                    {
                        this.RegisterGeneratedFile(filePath);
                    }
                }
            }
            return true;
        }

        private void IncrementalParserFix(string parserFilePath)
        {
            StringBuilder sb = new StringBuilder();
            using(StreamReader reader = new StreamReader(parserFilePath))
            {
                string prevLine1 = null;
                string prevLine2 = null;
                string prevLine3 = null;
                while(!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line.Contains("global::MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax.IncrementalParser")) return;
                    if (line.Contains(": Parser {"))
                    {
                        line = line.Replace(": Parser {", $": global::MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax.IncrementalParser {{\r\n    private {LanguageName}SyntaxParser SyntaxParser => ({LanguageName}SyntaxParser)this.IncrementalAntlr4Parser;");
                    }
                    if (line.Contains("Context _localctx = new "))
                    {
                        var contextTypeName = line.Substring(0, line.IndexOf("_localctx")).Trim();
                        var indent = line.Substring(0, line.IndexOf(contextTypeName));
                        var smallIndent = indent.Length >= 1 ? indent.Substring(1) : indent;
                        var ruleName = contextTypeName.Substring(0, contextTypeName.Length - 7);
                        bool recursive = false;
                        if (prevLine1 != null && prevLine1.Contains(") {"))
                        {
                            if (prevLine3 != null)
                            {
                                sb.AppendLine(prevLine3);
                                prevLine3 = null;
                            }
                            if (prevLine2 != null)
                            {
                                sb.AppendLine(prevLine2);
                                prevLine2 = null;
                            }
                            sb.AppendLine(prevLine1);
                            prevLine1 = null;
                        }
                        else if (prevLine3 != null && prevLine3.Contains(") {"))
                        {
                            sb.AppendLine(prevLine3);
                            prevLine3 = null;
                            recursive = true;
                            var findRuleName = ruleName.ToCamelCase();
                            foreach (var rule in this.Grammar.ParserRules)
                            {
                                if (rule.Name == findRuleName)
                                {
                                    rule.IsRecursive = true;
                                    break;
                                }
                            }
                        }
                        //sb.AppendLine($"{indent}BeginRuleContext();");
                        //sb.AppendLine($"{indent}if (this.TryGetIncrementalContext(_ctx, State, RULE_{ruleName.ToCamelCase()}, out {contextTypeName} existingContext)) return existingContext;");
                        if (recursive) sb.AppendLine($"{indent}return this.SyntaxParser != null && this.SyntaxParser.IsIncremental ? this.SyntaxParser._Antlr4Parse{ruleName}(_p) : _DoParse{ruleName}(_p);");
                        else sb.AppendLine($"{indent}return this.SyntaxParser != null && this.SyntaxParser.IsIncremental ? this.SyntaxParser._Antlr4Parse{ruleName}() : _DoParse{ruleName}();");
                        //sb.AppendLine($"{indent}EndRuleContext();");
                        sb.AppendLine($"{smallIndent}}}");
                        sb.AppendLine();
                        if (recursive) sb.AppendLine($"{smallIndent}internal {contextTypeName} _DoParse{ruleName}(int _p) {{");
                        else sb.AppendLine($"{smallIndent}internal {contextTypeName} _DoParse{ruleName}() {{");
                    }
                    if (prevLine3 != null) sb.AppendLine(prevLine3);
                    prevLine3 = prevLine2;
                    prevLine2 = prevLine1;
                    prevLine1 = line;
                }
                if (prevLine3 != null) sb.AppendLine(prevLine3);
                if (prevLine2 != null) sb.AppendLine(prevLine2);
                if (prevLine1 != null) sb.AppendLine(prevLine1);
            }
            File.WriteAllText(parserFilePath, sb.ToString());
        }

        protected override void DoCompile()
        {
            if (!this.PreCompile()) return;

            RoslynRuleCollector ruleCollector = new RoslynRuleCollector(this);
            ruleCollector.Visit(this.ParseTree);
            this.IsLexer = ruleCollector.IsLexer;
            this.LexerHeader = ruleCollector.LexerHeader;
            this.IsParser = ruleCollector.IsParser;
            this.ParserHeader = ruleCollector.ParserHeader;
            this.GenerateCompiler = ruleCollector.GenerateCompiler;
            this.GenerateLanguageService = ruleCollector.GenerateLanguageService;
            this.IgnoreRoslynRules = ruleCollector.IgnoreRoslynRules;
            this.Grammar = ruleCollector.Grammar;

            this.PostCompile();
        }

        protected virtual bool PostCompile()
        {
            this.Grammar.ErrorCodeCategory = this.LanguageName;
            this.Grammar.MessagePrefix = new string(this.LanguageName.Where(c => char.IsUpper(c) || char.IsNumber(c)).ToArray());
            string antlr4TokensFile = Path.Combine(this.AutomaticOutputDirectory, Path.ChangeExtension(this.GeneratedAntlr4GrammarFile, ".tokens"));
            if (!File.Exists(antlr4TokensFile))
            {
                this.AddDiagnostic(Antlr4RoslynErrorCode.ERR_Antlr4ToolError, string.Format("Tokens file '{0}' is missing.", antlr4TokensFile));
                return false;
            }
            string antlr4TokensSource = File.ReadAllText(antlr4TokensFile);
            this.ReadTokens(antlr4TokensSource);

            this.Grammar.FirstParserRuleSyntaxKind = this.Grammar.ParserRules.FirstOrDefault();
            this.Grammar.LastParserRuleSyntaxKind = this.Grammar.ParserRules.LastOrDefault();
            this.Grammar.LexerRules.Sort((r1, r2) => r1.Kind.CompareTo(r2.Kind));
            this.Grammar.FirstTokenSyntaxKind = this.Grammar.LexerRules.FirstOrDefault(r => r.Kind > 0);
            this.Grammar.LastTokenSyntaxKind = this.Grammar.LexerRules.LastOrDefault(r => r.Kind > 0);
            this.Grammar.FirstFixedTokenSyntaxKind = this.Grammar.LexerRules.FirstOrDefault(r => r.Kind > 0 && this.Grammar.FixedTokens.Contains(r));
            this.Grammar.LastFixedTokenSyntaxKind = this.Grammar.LexerRules.LastOrDefault(r => r.Kind > 0 && this.Grammar.FixedTokens.Contains(r));

            if (this.IsLexer)
            {
                this.CollectLexerTokenKinds();
            }
            if (this.IsParser)
            {
                this.FindFirstNonAbstractAlternatives();
                this.CollectCustomAnnotations();
                this.CollectHasAnnotationFlags();
            }

            if (_antlr4TempPath != null)
            {
                Directory.Delete(_antlr4TempPath, true);
            }
            return true;
        }

        protected override void DoGenerate()
        {
            this.GenerateLexer();
            this.GenerateParser();
        }

        private void ReadTokens(string tokensSource)
        {
            if (tokensSource == null) return;
            Dictionary<string, int> fixedTokens = new Dictionary<string, int>();
            using (StringReader reader = new StringReader(tokensSource))
            {
                while (true)
                {
                    string line = reader.ReadLine();
                    if (line == null) break;
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
                            Antlr4LexerRule rule = this.Grammar.LexerRules.FirstOrDefault(r => r.Name == tokenName);
                            if (rule == null)
                            {
                                rule = new Antlr4LexerRule(this.Grammar.LexerModes.FirstOrDefault(), _noLocation);
                                rule.Name = tokenName;
                                rule.Artificial = true;
                                this.Grammar.LexerRules.Add(rule);
                            }
                            rule.Kind = tokenKind;
                        }
                        if (!this.IgnoreRoslynRules)
                        {
                            var collidingRule = this.Grammar.ParserRules.FirstOrDefault(pr => pr.Name?.ToPascalCase() == tokenName);
                            if (collidingRule != null)
                            {
                                this.DiagnosticBag.Add(Antlr4RoslynErrorCode.ERR_RuleNameTokenNameCollision, collidingRule.Location, tokenName, collidingRule.Name);
                            }
                        }
                    }
                }
            }
            foreach (var fixedToken in fixedTokens)
            {
                Antlr4LexerRule rule = this.Grammar.LexerRules.FirstOrDefault(r => r.Kind == fixedToken.Value);
                if (rule != null)
                {
                    rule.FixedToken = fixedToken.Key;
                    this.Grammar.FixedTokens.Add(rule);
                }
            }
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
                index = tokenLine.LastIndexOf('=');
            }
            else
            {
                index = tokenLine.IndexOf('=');
                if (index < 0) return false;
                tokenName = tokenLine.Substring(0, index).Trim();
            }
            return tokenName != null && int.TryParse(tokenLine.Substring(index + 1).Trim(), out tokenKind) && tokenKind > 0;
        }

        private void GenerateLexer()
        {
            if (!this.IsLexer) return;
            if (this.DiagnosticBag.HasAnyErrors()) return;
            CompilerGenerator generator = new CompilerGenerator(this.Grammar);
            generator.Properties.DefaultNamespace = this.DefaultNamespace;
            generator.Properties.LanguageName = this.LanguageName;
            this.GeneratedTokenSyntaxFacts = generator.GenerateTokenSyntaxFacts();
            this.GeneratedSyntaxKind = generator.GenerateSyntaxKind(false, this.LanguageName + "TokensSyntaxKind", "SyntaxKind");
            //this.GeneratedLanguageService = this.GetLanguageService();

            if (this.AutomaticOutputDirectory == null || this.ManualOutputDirectory == null) return;

            if (this.GenerateCompiler)
            {
                this.WriteOutputFile(Path.Combine(this.SyntaxDirectory, this.LanguageName + "SyntaxFacts.Tokens.cs"), this.GeneratedTokenSyntaxFacts);
                this.WriteOutputFile(Path.Combine(this.SyntaxDirectory, this.LanguageName + "SyntaxKind.Tokens.cs"), this.GeneratedSyntaxKind);
            }
        }

        private void GenerateParser()
        {
            if (!this.IsParser) return;
            if (!this.GenerateCompiler) return;
            if (this.DiagnosticBag.HasAnyErrors()) return;
            CompilerGenerator generator = new CompilerGenerator(this.Grammar);
            generator.Properties.DefaultNamespace = this.DefaultNamespace;
            generator.Properties.LanguageName = this.LanguageName;

            string antlr4ParserFile = Path.Combine(this.AutomaticOutputDirectory, Path.ChangeExtension(this.GeneratedAntlr4GrammarFile, ".cs"));
            IncrementalParserFix(antlr4ParserFile);

            this.GeneratedSyntaxKind = generator.GenerateSyntaxKind(true, this.LanguageName + "SyntaxKind", this.LanguageName + "TokensSyntaxKind");
            this.GeneratedNodeSyntaxFacts = generator.GenerateNodeSyntaxFacts();

            this.GeneratedInternalSyntax = generator.GenerateInternalSyntax();
            this.GeneratedSyntax = generator.GenerateSyntax();
            this.GeneratedSyntaxTree = generator.GenerateSyntaxTree();
            this.GeneratedErrorCode = generator.GenerateErrorCode();
            this.GeneratedSymbolFacts = generator.GenerateSymbolFacts();
            this.GeneratedSyntaxLexer = generator.GenerateSyntaxLexer();
            this.GeneratedSyntaxParser = generator.GenerateSyntaxParser();
            this.GeneratedLanguage = generator.GenerateLanguage();
            this.GeneratedLanguageVersion = generator.GenerateLanguageVersion();
            this.GeneratedParseOptions = generator.GenerateParseOptions();
            this.GeneratedFeature = generator.GenerateFeature();
            this.GeneratedLanguageServicesBase = generator.GenerateLanguageServicesBase();
            this.GeneratedLanguageServices = generator.GenerateLanguageServices();

            this.GeneratedCompilation = generator.GenerateCompilation();
            this.GeneratedCompilationFactory = generator.GenerateCompilationFactory();
            this.GeneratedCompilationOptions = generator.GenerateCompilationOptions();
            this.GeneratedScriptCompilationInfo = generator.GenerateScriptCompilationInfo();

            this.GeneratedDeclarationTreeBuilder = generator.GenerateDeclarationTreeBuilder();
            this.GeneratedBinderFactoryVisitor = generator.GenerateBinderFactoryVisitor();
            this.GeneratedBoundKind = generator.GenerateBoundKind();
            this.GeneratedBoundNodeFactoryVisitor = generator.GenerateBoundNodeFactoryVisitor();
            this.GeneratedIsBindableNodeVisitor = generator.GenerateIsBindableNodeVisitor();

            if (this.AutomaticOutputDirectory == null || this.ManualOutputDirectory == null) return;

            if (this.GenerateCompiler)
            {
                var CompilationDirectory = Path.Combine(this.BaseDirectory, "Compilation"); 
                var ErrorsDirectory = Path.Combine(this.BaseDirectory, "Errors"); 
                var SymbolsDirectory = Path.Combine(this.BaseDirectory, "Symbols");
                var BindingDirectory = Path.Combine(this.BaseDirectory, "Binding");
                this.WriteOutputFile(Path.Combine(this.InternalSyntaxDirectory, this.LanguageName + "InternalSyntax.cs"), this.GeneratedInternalSyntax);
                this.WriteOutputFile(Path.Combine(this.InternalSyntaxDirectory, this.LanguageName + @"SyntaxLexer.cs"), this.GeneratedSyntaxLexer);
                this.WriteOutputFile(Path.Combine(this.InternalSyntaxDirectory, this.LanguageName + @"SyntaxParser.cs"), this.GeneratedSyntaxParser);
                this.WriteOutputFile(Path.Combine(this.SyntaxDirectory, this.LanguageName + "SyntaxKind.Nodes.cs"), this.GeneratedSyntaxKind);
                this.WriteOutputFile(Path.Combine(this.SyntaxDirectory, this.LanguageName + "SyntaxFacts.Nodes.cs"), this.GeneratedNodeSyntaxFacts);
                this.WriteOutputFile(Path.Combine(this.SyntaxDirectory, this.LanguageName + "Syntax.cs"), this.GeneratedSyntax);
                this.WriteOutputFile(Path.Combine(this.SyntaxDirectory, this.LanguageName + "SyntaxTree.cs"), this.GeneratedSyntaxTree);
                this.WriteOutputFile(Path.Combine(this.SyntaxDirectory, this.LanguageName + @"ParseOptions.cs"), this.GeneratedParseOptions);
                this.WriteOutputFile(Path.Combine(ErrorsDirectory, this.LanguageName + @"ErrorCode.cs"), this.GeneratedErrorCode);
                this.WriteOutputFile(Path.Combine(SymbolsDirectory, this.LanguageName + @"SymbolFacts.cs"), this.GeneratedSymbolFacts);
                this.WriteOutputFile(Path.Combine(CompilationDirectory, this.LanguageName + @"CompilationOptions.cs"), this.GeneratedCompilationOptions);
                this.WriteOutputFile(Path.Combine(CompilationDirectory, this.LanguageName + @"Compilation.cs"), this.GeneratedCompilation);
                this.WriteOutputFile(Path.Combine(CompilationDirectory, this.LanguageName + @"CompilationFactory.cs"), this.GeneratedCompilationFactory);
                this.WriteOutputFile(Path.Combine(CompilationDirectory, this.LanguageName + @"Language.cs"), this.GeneratedLanguage);
                this.WriteOutputFile(Path.Combine(CompilationDirectory, this.LanguageName + @"LanguageVersion.cs"), this.GeneratedLanguageVersion);
                this.WriteOutputFile(Path.Combine(CompilationDirectory, this.LanguageName + @"LanguageServicesBase.cs"), this.GeneratedLanguageServicesBase);
                this.WriteOutputFile(Path.Combine(CompilationDirectory, this.LanguageName + @"LanguageServices.cs"), this.GeneratedLanguageServices, automatic: false);
                this.WriteOutputFile(Path.Combine(BindingDirectory, this.LanguageName + @"DeclarationTreeBuilderVisitor.cs"), this.GeneratedDeclarationTreeBuilder);
                this.WriteOutputFile(Path.Combine(BindingDirectory, this.LanguageName + @"BinderFactoryVisitor.cs"), this.GeneratedBinderFactoryVisitor);
                this.WriteOutputFile(Path.Combine(BindingDirectory, this.LanguageName + @"BoundKind.cs"), this.GeneratedBoundKind);
                this.WriteOutputFile(Path.Combine(BindingDirectory, this.LanguageName + @"BoundNodeFactoryVisitor.cs"), this.GeneratedBoundNodeFactoryVisitor);
                this.WriteOutputFile(Path.Combine(BindingDirectory, this.LanguageName + @"IsBindableNodeVisitor.cs"), this.GeneratedIsBindableNodeVisitor);
                /*this.WriteOutputFile(Path.Combine(this.AutomaticManualOutputDirectory, @"Compilation\" + this.LanguageName + @"ScriptCompilationInfo.cs"), this.GeneratedScriptCompilationInfo);
                this.WriteOutputFile(Path.Combine(this.AutomaticManualOutputDirectory, @"Compilation\" + this.LanguageName + @"Feature.cs"), this.GeneratedFeature);*/
            }
        }

        private void CollectCustomAnnotations()
        {
            this.DefineCustomAnnotations();
            //this.ReferenceCustomAnnotations();
        }

        private void FindFirstNonAbstractAlternatives()
        {
            foreach (var rule in this.Grammar.ParserRules)
            {
                if (rule.Alternatives.Count > 0 && rule.FirstNonAbstractAlternative == null)
                {
                    FindFirstNonAbstractAlternative(rule);
                }
            }
        }

        private void FindFirstNonAbstractAlternative(Antlr4ParserRule rule)
        {
            rule.FirstNonAbstractAlternative = rule.Alternatives.Where(alt => alt.Alternatives.Count == 0).FirstOrDefault();
            if (rule.FirstNonAbstractAlternative == null)
            {
                foreach (var alt in rule.Alternatives)
                {
                    if (alt.Alternatives.Count > 0 && alt.FirstNonAbstractAlternative == null)
                    {
                        FindFirstNonAbstractAlternative(alt);
                    }
                }
                rule.FirstNonAbstractAlternative = rule.Alternatives.Where(alt => alt.FirstNonAbstractAlternative != null).FirstOrDefault()?.FirstNonAbstractAlternative;
            }
        }

        private void DefineCustomAnnotations()
        {
            foreach (var rule in this.Grammar.ParserRules)
            {
                this.DefineCustomAnnotations(rule.Annotations.GetCustomAnnotations());
                foreach (var elem in rule.AllElements)
                {
                    this.DefineCustomAnnotations(elem.Annotations.GetCustomAnnotations());
                }
                foreach (var alt in rule.Alternatives)
                {
                    this.DefineCustomAnnotations(alt.Annotations.GetCustomAnnotations());
                    foreach (var elem in alt.AllElements)
                    {
                        this.DefineCustomAnnotations(elem.Annotations.GetCustomAnnotations());
                    }
                }
            }
        }

        private void DefineCustomAnnotations(ImmutableArray<MetaCompilerAnnotation> annots)
        {
            foreach (var annot in annots)
            {
                MetaCompilerAnnotation existing = this.Grammar.CustomAnnotations.FirstOrDefault(a => a.Name == annot.Name);
                if (existing == null)
                {
                    existing = new MetaCompilerAnnotation(annot.Name, new MetaAnnotationProperty[0]);
                    this.Grammar.CustomAnnotations.Add(existing);
                }
            }
        }

        private void CollectLexerTokenKinds()
        {
            if (this.DiagnosticBag.HasAnyErrors()) return;
            this.CollectVirtualTokenKinds();
            List<Antlr4LexerRule> defaultWhitespace = new List<Antlr4LexerRule>();
            List<Antlr4LexerRule> defaultEndOfLine = new List<Antlr4LexerRule>();
            List<Antlr4LexerRule> defaultSeparator = new List<Antlr4LexerRule>();
            List<Antlr4LexerRule> defaultIdentifier = new List<Antlr4LexerRule>();
            foreach (var rule in this.Grammar.LexerRules)
            {
                var tokenAnnot = rule.Annotations.GetAnnotation("Token");
                if (tokenAnnot != null)
                {
                    string kind = tokenAnnot.GetValue("kind");
                    if (kind != null)
                    {
                        List<Antlr4LexerRule> rules = null;
                        if (!this.Grammar.LexerTokenKinds.TryGetValue(kind, out rules))
                        {
                            rules = new List<Antlr4LexerRule>();
                            this.Grammar.LexerTokenKinds.Add(kind, rules);
                        }
                        rules.Add(rule);
                    }
                    if (tokenAnnot.GetValue("defaultWhitespace") == "true")
                    {
                        this.Grammar.DefaultWhitespaceKind = rule;
                        defaultWhitespace.Add(rule);
                    }
                    if (tokenAnnot.GetValue("defaultEndOfLine") == "true")
                    {
                        this.Grammar.DefaultEndOfLineKind = rule;
                        defaultEndOfLine.Add(rule);
                    }
                    if (tokenAnnot.GetValue("defaultIdentifier") == "true")
                    {
                        this.Grammar.DefaultIdentifierKind = rule;
                        defaultIdentifier.Add(rule);
                    }
                    if (tokenAnnot.GetValue("defaultSeparator") == "true")
                    {
                        this.Grammar.DefaultSeparatorKind = rule;
                        defaultSeparator.Add(rule);
                    }
                }
            }
            foreach (var mode in this.Grammar.LexerModes)
            {
                var tokenAnnot = mode.Annotations.GetAnnotation("Token");
                if (tokenAnnot != null)
                {
                    string kind = tokenAnnot.GetValue("kind");
                    if (kind != null)
                    {
                        List<Antlr4LexerRule> rules = null;
                        if (!this.Grammar.LexerTokenKinds.TryGetValue(kind, out rules))
                        {
                            rules = new List<Antlr4LexerRule>();
                            this.Grammar.LexerTokenKinds.Add(kind, rules);
                        }
                    }
                }
            }
            this.CheckDefaultAnnotations(defaultWhitespace, "Whitespace");
            this.CheckDefaultAnnotations(defaultEndOfLine, "EndOfLine");
            this.CheckDefaultAnnotations(defaultSeparator, "Separator");
            this.CheckDefaultAnnotations(defaultIdentifier, "Identifier");
        }

        private void CheckDefaultAnnotations(List<Antlr4LexerRule> rules, string annot)
        {
            if (this.IgnoreRoslynRules) return;
            if (rules.Count == 0)
            {
                this.AddDiagnostic(Antlr4RoslynErrorCode.ERR_MissingDefaultAnnotation, _noLocation, string.Format("$Token(default{0}=true)", annot));
            }
            else if (rules.Count >= 2)
            {
                foreach (var rule in rules)
                {
                    this.AddDiagnostic(Antlr4RoslynErrorCode.ERR_MultipleDefaultAnnotation, rule.Location, string.Format("$Token(default{0}=true)", annot));
                }
            }
        }

        private void CollectVirtualTokenKinds()
        {
            var syntaxFactsType = typeof(CodeAnalysis.Syntax.SyntaxFacts);
            foreach (var method in syntaxFactsType.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
            {
                if ((method.IsAbstract || method.IsVirtual) && method.Name.StartsWith("Is") && method.ReturnType == typeof(bool))
                {
                    var parameters = method.GetParameters();
                    if (parameters.Length == 1 && parameters[0].ParameterType == typeof(CodeAnalysis.Syntax.SyntaxKind))
                    {
                        string tokenKindName = method.Name.Substring(2);
                        this.Grammar.VirtualTokenKinds.Add(tokenKindName);
                        this.Grammar.LexerTokenKinds.Add(tokenKindName, new List<Antlr4LexerRule>());
                    }
                }
            }
            this.Grammar.LexerTokenKinds.Remove("TriviaWithEndOfLine");
        }

        private void CollectHasAnnotationFlags()
        {
            if (this.DiagnosticBag.HasAnyErrors()) return;
            foreach (var rule in this.Grammar.ParserRules)
            {
                foreach (var alt in rule.Alternatives)
                {
                    alt.Annotations = rule.Annotations.AddRange(alt.Annotations.Annotations);
                }
            }
            foreach (var rule in this.Grammar.ParserRules)
            {
                this.SetAnnotationFlags(rule);
                foreach (var alt in rule.Alternatives)
                {
                    this.SetAnnotationFlags(alt);
                }
            }
            bool foundNewFlag = true;
            while (foundNewFlag)
            {
                foundNewFlag = false;
                foreach (var rule in this.Grammar.ParserRules)
                {
                    bool oldContainsAnnotations = rule.ContainsAnnotations;
                    bool oldContainsBinderAnnotations = rule.ContainsBinderAnnotations;
                    bool oldContainsBoundNodeAnnotations = rule.ContainsBoundNodeAnnotations;
                    foundNewFlag = this.CollectHasAnnotationFlags(rule) | foundNewFlag;
                    foreach (var alt in rule.Alternatives)
                    {
                        foundNewFlag = this.CollectHasAnnotationFlags(alt) | foundNewFlag;
                        MergeContainsAnnotationsFrom(rule, alt);
                    }
                    foundNewFlag = 
                        (rule.ContainsAnnotations && !oldContainsAnnotations) |
                        (rule.ContainsBinderAnnotations && !oldContainsBinderAnnotations) |
                        (rule.ContainsBoundNodeAnnotations && !oldContainsBoundNodeAnnotations) |
                        foundNewFlag;
                }
            }
        }

        private bool CollectHasAnnotationFlags(Antlr4ParserRule rule)
        {
            bool foundElemFlag = false;
            foreach (var elem in rule.Elements)
            {
                bool oldContainsAnnotations = elem.ContainsAnnotations;
                bool oldContainsBinderAnnotations = elem.ContainsBinderAnnotations;
                bool oldContainsBoundNodeAnnotations = elem.ContainsBoundNodeAnnotations;
                this.SetAnnotationFlags(elem);
                if (elem.ContainsAnnotations)
                {
                    this.Grammar.ParserRuleElemUses.Add(elem.RedName());
                }
                if (elem.BlockItems.Count > 0)
                {
                    foreach (var item in elem.BlockItems)
                    {
                        bool oldItemContainsAnnotations = item.ContainsAnnotations;
                        bool oldItemContainsBinderAnnotations = item.ContainsBinderAnnotations;
                        bool oldItemContainsBoundNodeAnnotations = item.ContainsBoundNodeAnnotations;
                        this.SetAnnotationFlags(item);
                        if (item.ContainsAnnotations)
                        {
                            this.Grammar.ParserRuleElemUses.Add(item.RedName());
                        }
                        Antlr4ParserRule itemTypeRule = this.Grammar.FindParserRule(item.Type);
                        if (itemTypeRule != null)
                        {
                            MergeContainsAnnotationsFrom(item, itemTypeRule);
                        }
                        MergeContainsAnnotationsFrom(elem, item);
                        foundElemFlag =
                            (item.ContainsAnnotations && !oldItemContainsAnnotations) |
                            (item.ContainsBinderAnnotations && !oldItemContainsBinderAnnotations) |
                            (item.ContainsBoundNodeAnnotations && !oldItemContainsBoundNodeAnnotations) |
                            foundElemFlag;
                    }
                }
                Antlr4ParserRule elemTypeRule = this.Grammar.FindParserRule(elem.Type);
                if (elemTypeRule != null)
                {
                    MergeContainsAnnotationsFrom(elem, elemTypeRule);
                }
                MergeContainsAnnotationsFrom(rule, elem);
                foundElemFlag =
                        (elem.ContainsAnnotations && !oldContainsAnnotations) |
                        (elem.ContainsBinderAnnotations && !oldContainsBinderAnnotations) |
                        (elem.ContainsBoundNodeAnnotations && !oldContainsBoundNodeAnnotations) |
                        foundElemFlag;
            }
            return foundElemFlag;
        }

        private void SetAnnotationFlags(Antlr4AnnotatedObject obj)
        {
            int binderAnnotationCount = obj.Annotations.Annotations.Count(a => MetaCompilerAnnotationInfo.BinderAnnotations.Contains(a.Name));
            int boundNodeAnnotationCount = obj.Annotations.Annotations.Count(a => MetaCompilerAnnotationInfo.BoundNodeAnnotations.Contains(a.Name));
            int customAnnotationCount = obj.Annotations.Annotations.Count(a => !MetaCompilerAnnotationInfo.WellKnownAnnotations.Contains(a.Name));

            obj.HasAnnotations = obj.Annotations.Annotations.Count > 0;
            obj.HasBinderAnnotations = binderAnnotationCount + customAnnotationCount > 0;
            obj.HasBoundNodeAnnotations = boundNodeAnnotationCount + customAnnotationCount > 0;

            obj.ContainsAnnotations |= obj.HasAnnotations;
            obj.ContainsBinderAnnotations |= obj.HasBinderAnnotations;
            obj.ContainsBoundNodeAnnotations |= obj.HasBoundNodeAnnotations;
        }

        private void MergeContainsAnnotationsFrom(Antlr4AnnotatedObject target, Antlr4AnnotatedObject source)
        {
            target.ContainsAnnotations |= source.ContainsAnnotations;
            target.ContainsBinderAnnotations |= source.ContainsBinderAnnotations;
            target.ContainsBoundNodeAnnotations |= source.ContainsBoundNodeAnnotations;
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
        private Antlr4LexerMode currentMode;
        private Antlr4LexerRule currentLexerRule;

        private bool firstRule;
        private int modeCounter;

        public Antlr4Grammar Grammar { get { return this.currentGrammar; } }
        public bool IsParser { get; private set; }
        public bool IsLexer { get; private set; }
        public bool GenerateCompiler { get; private set; }
        public bool GenerateLanguageService { get; private set; }
        public bool IgnoreRoslynRules { get; private set; }
        public string LexerHeader => this.lexerHeader;
        public string ParserHeader => this.parserHeader;

        public RoslynRuleCollector(Antlr4RoslynCompiler compiler)
        {
            this.firstRule = true;
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
                            CheckAnnotationParameters(attr.annotationIdentifier(), annotationName, propertyName);
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

        private void CheckAnnotationParameters(ParserRuleContext context, string annotationName, string parameterName)
        {
            int index = MetaCompilerAnnotationInfo.WellKnownAnnotations.IndexOf(annotationName);
            if (index >= 0)
            {
                if (!MetaCompilerAnnotationInfo.WellKnownAnnotationProperties[index].Contains(parameterName))
                {
                    this.compiler.AddDiagnostic(context, Antlr4RoslynErrorCode.WRN_InvalidWellKnownAnnotationParameter, annotationName, parameterName);
                }
            }
        }
        private Location GetLocation(ParserRuleContext context)
        {
            return new ExternalFileLocation(this.compiler.InputFilePath, context.GetTextSpan(), context.GetLinePositionSpan());
        }

        private Location GetLocation(ITerminalNode terminalNode)
        {
            return new ExternalFileLocation(this.compiler.InputFilePath, terminalNode.Symbol.GetTextSpan(), terminalNode.Symbol.GetLinePositionSpan());
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
            currentGrammar = new Antlr4Grammar(this.compiler._noLocation);
            currentGrammar.Name = context.identifier().GetText();
            currentMode = new Antlr4LexerMode(this.currentGrammar, this.GetLocation(context.identifier()));
            currentMode.Name = "DEFAULT_MODE";
            this.modeCounter = 0;
            currentMode.Kind = this.modeCounter;
            currentGrammar.LexerModes.Add(currentMode);
            this.CollectAnnotations(currentGrammar, context.annotation());
            return base.VisitGrammarSpec(context);
        }

        public override object VisitTokensSpec([NotNull] Antlr4RoslynParser.TokensSpecContext context)
        {
            if (context.idList() != null)
            {
                foreach (var id in context.idList().annotatedIdentifier())
                {
                    this.currentLexerRule = new Antlr4LexerRule(this.currentMode, this.GetLocation(id.identifier()));
                    this.currentLexerRule.Name = id.identifier().GetText();
                    //this.currentLexerRule.FixedToken = id.identifier().GetText();
                    if (this.currentLexerRule != null)
                    {
                        //this.currentGrammar.FixedTokens.Add(this.currentLexerRule);
                        this.currentGrammar.LexerRules.Add(this.currentLexerRule);
                        this.currentMode.LexerRules.Add(this.currentLexerRule);
                        this.CollectAnnotations(this.currentLexerRule, id.annotation());
                        this.currentLexerRule = null;
                    }
                }
            }
            return null;
        }

        public override object VisitOption(Antlr4RoslynParser.OptionContext context)
        {
            string optionName = context.identifier().GetText();
            string optionValue = context.optionValue().GetText();
            if (optionName == "generateCompiler")
            {
                this.GenerateCompiler = optionValue == "true";
            }
            if (optionName == "generateLanguageService")
            {
                this.GenerateLanguageService = optionValue == "true";
            }
            if (optionName == "ignoreRoslynRules")
            {
                this.IgnoreRoslynRules = optionValue == "true";
            }
            if (optionName == "tokenVocab")
            {
                this.lexerName = optionValue;
                string import = optionValue;
                this.Grammar.Imports.Add(import + ".tokens");
            }
            return base.VisitOption(context);
        }

        public override object VisitDelegateGrammar([NotNull] Antlr4RoslynParser.DelegateGrammarContext context)
        {
            var identifiers = context.identifier();
            if (identifiers.Length >= 2)
            {
                string import = identifiers[1].GetText();
                this.Grammar.Imports.Add(import + ".g4");
            }
            else if (identifiers.Length >= 1)
            {
                string import = identifiers[0].GetText();
                this.Grammar.Imports.Add(import + ".g4");
            }
            return base.VisitDelegateGrammar(context);
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
                    this.Grammar.ParserHeader = action;
                }
                if (scopeName == null || scopeName == "lexer")
                {
                    this.lexerHeader = action;
                    this.Grammar.LexerHeader = action;
                }
            }
            return base.VisitAction(context);
        }

        public override object VisitModeSpec(Antlr4RoslynParser.ModeSpecContext context)
        {
            currentMode = new Antlr4LexerMode(this.currentGrammar, this.GetLocation(context.identifier()));
            if (context.identifier() != null)
            {
                currentMode.Name = context.identifier().GetText();
            }
            ++this.modeCounter;
            currentMode.Kind = this.modeCounter;
            currentGrammar.LexerModes.Add(currentMode);
            this.CollectAnnotations(currentMode, context.annotation());
            return base.VisitModeSpec(context);
        }

        public override object VisitLexerRuleSpec(Antlr4RoslynParser.LexerRuleSpecContext context)
        {
            if (context.FRAGMENT() == null)
            {
                this.currentLexerRule = new Antlr4LexerRule(this.currentMode, this.GetLocation(context.TOKEN_REF()));
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
                                /*if (lexerAtom != null && lexerAtom.terminal() != null && !this.HasModeCommand(lexerAlt))
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
                                }*/
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

        private bool HasModeCommand(Antlr4RoslynParser.LexerAltContext lexerAlt)
        {
            if (lexerAlt.lexerCommands() != null)
            {
                foreach (var lexCmd in lexerAlt.lexerCommands().lexerCommand())
                {
                    if (lexCmd.lexerCommandName().GetText() == "mode")
                    {
                        return true;
                    }
                }
            }
            return false;
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
                        rule.Location = GetLocation(ruleSpec.RULE_REF());
                        handled = true;
                    }
                }
                if (!reportedError && !handled && this.IsRoslynAltList(context, TokenOrRule.Rule, false, ref reportedError, out rule))
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
                        if (!this.IgnoreRoslynRules) this.compiler.AddDiagnostic(ruleSpec.RULE_REF(), Antlr4RoslynErrorCode.ERR_RuleMapUnnamedAlt, ruleName);
                    }
                }
                if (!reportedError && !handled)
                {
                    if (!this.IgnoreRoslynRules) this.compiler.AddDiagnostic(ruleSpec.RULE_REF(), Antlr4RoslynErrorCode.ERR_RuleMapTooComplex, ruleName);
                }
                if (!reportedError && handled && rule != null)
                {
                    this.CollectAnnotations(rule, ruleSpec.annotation());
                    this.Grammar.ParserRules.Add(rule);
                    rule.Name = ruleName;
                }
                if (this.firstRule)
                {
                    this.firstRule = false;
                    Antlr4RoslynParser.LabeledAltContext[] labeledAlts = context.ruleAltList().labeledAlt();
                    bool endsWithEof = false;
                    if (labeledAlts != null && labeledAlts.Length > 0)
                    {
                        endsWithEof = true;
                        for (int i = 0; i < labeledAlts.Length; i++)
                        {
                            if (!EndsWithEof(labeledAlts[i]))
                            {
                                endsWithEof = false;
                                break;
                            }
                        }
                    }
                    if (!endsWithEof)
                    {
                        if (!this.IgnoreRoslynRules) this.compiler.AddDiagnostic(context, Antlr4RoslynErrorCode.ERR_MainRuleMustEndWithEof);
                    }
                }
            }
            else
            {
                if (!this.IgnoreRoslynRules) this.compiler.AddDiagnostic(context, Antlr4RoslynErrorCode.ERR_BlockUnhandled);
            }
            return base.VisitRuleBlock(context);
        }

        public override object VisitElement([NotNull] Antlr4RoslynParser.ElementContext elem)
        {
            if (elem.labeledElement() != null && elem.labeledElement().PLUS_ASSIGN() == null && elem.labeledElement().ASSIGN() != null && IsEbnfList(elem.ebnfSuffix()))
            {
                if (!this.IgnoreRoslynRules) this.compiler.AddDiagnostic(elem.labeledElement().ASSIGN(), Antlr4RoslynErrorCode.ERR_LabeledListMustUsePlusAssign);
            }
            return base.VisitElement(elem);
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
                    if (elements[j].Name == elements[i].Name || elements[j].Type == elements[i].Name)
                    {
                        renameNeeded = true;
                        break;
                    }
                }
                if (renameNeeded)
                {
                    result = false;
                    reportedErrors = true;
                    if (!this.IgnoreRoslynRules) this.compiler.AddDiagnostic(elements[i].Node, Antlr4RoslynErrorCode.ERR_UnnamedElement, elements[i].Type);
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
            rule = new Antlr4ParserRule(this.currentGrammar, this.GetLocation(context));
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
            Antlr4RoslynParser.ElementContext[] elems = context.alternative().element().Where(e => !this.IsActionBlock(e)).ToArray();
            rule = new Antlr4ParserRule(this.Grammar, this.GetLocation(context.identifier()));
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

        private bool IsActionBlock(Antlr4RoslynParser.ElementContext elem)
        {
            return elem.actionBlock() != null;
        }

        private bool EndsWithEof(Antlr4RoslynParser.LabeledAltContext context)
        {
            Antlr4RoslynParser.ElementContext[] elems = context.alternative().element().Where(e => !this.IsActionBlock(e)).ToArray();
            if (elems.Length > 0)
            {
                Antlr4RoslynParser.ElementContext elem = elems[elems.Length - 1];
                if (elem.atom() != null)
                {
                    if (elem.atom().terminal() != null && elem.atom().terminal().TOKEN_REF() != null)
                    {
                        string name = elem.atom().terminal().TOKEN_REF().GetText();
                        return name == "EOF";
                    }
                }
                else if (elem.labeledElement() != null && elem.labeledElement().atom() != null)
                {
                    if (elem.labeledElement().atom().terminal() != null && elem.labeledElement().atom().terminal().TOKEN_REF() != null)
                    {
                        string name = elem.labeledElement().atom().terminal().TOKEN_REF().GetText();
                        return name == "EOF";
                    }
                }
            }
            return false;
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
                if (!this.IgnoreRoslynRules) this.compiler.AddDiagnostic(elem.labeledElement().identifier(), Antlr4RoslynErrorCode.ERR_BlockMap);
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
                        if (!this.IgnoreRoslynRules) this.compiler.AddDiagnostic(blockSuffix, Antlr4RoslynErrorCode.ERR_BlockMapSuffix);
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
                    if (!this.IgnoreRoslynRules) this.compiler.AddDiagnostic(elem.ebnf().block(), Antlr4RoslynErrorCode.ERR_UnnamedBlock);
                    return 0;
                }
                if (!this.IgnoreRoslynRules) this.compiler.AddDiagnostic(elem.ebnf().block(), Antlr4RoslynErrorCode.ERR_BlockMap);
                return 0;
            }
            return 0;
        }

        private bool IsEbnfOptional(Antlr4RoslynParser.EbnfSuffixContext context)
        {
            if (context == null) return false;
            return context.PLUS() == null && (context.STAR() != null || context.QUESTION().Length == 1);
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
            rule = new Antlr4ParserRule(this.Grammar, this.GetLocation(context));
            Antlr4ParserRuleElement blockElem = null;
            if (kind == TokenOrRule.Token)
            {
                var ruleRef = ((Antlr4RoslynParser.ParserRuleSpecContext)(context.Parent)).RULE_REF();
                blockElem = new Antlr4ParserRuleElement(context, this.GetLocation(ruleRef));
                blockElem.Rule = rule;
                blockElem.Name = ruleRef.GetText();
                blockElem.IsFixedTokenAltBlock = true;
                blockElem.IsBlock = true;
                rule.Elements.Add(blockElem);
            }
            var alts = context.ruleAltList().labeledAlt().Select(la => la.alternative()).ToList();
            foreach (var alt in alts)
            {
                Antlr4ParserRuleElement element;
                if (this.IsRoslynSingleTokenOrRuleElementAlt(alt, kind, false, out element))
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
            block = new Antlr4ParserRuleElement(context, this.GetLocation(context));
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
                block = new Antlr4ParserRuleElement(context, this.GetLocation(context));
                block.IsBlock = true;
                var alt = context.altList().alternative()[0];
                Antlr4RoslynParser.ElementContext[] elems = alt.element().Where(e => !this.IsActionBlock(e)).ToArray();
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
                        if (!this.IgnoreRoslynRules) this.compiler.AddDiagnostic(elems[i], Antlr4RoslynErrorCode.ERR_ElementMap);
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
            Antlr4RoslynParser.ElementContext[] elems = context.element().Where(e => !this.IsActionBlock(e)).ToArray();
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
            Antlr4RoslynParser.ElementContext[] elems = context.element().Where(e => !this.IsActionBlock(e)).ToArray();
            if (elems.Length == 1)
            {
                Antlr4RoslynParser.ElementContext elem = elems[0];
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
                    if (elem.labeledElement().atom() != null)
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
                        element = new Antlr4ParserRuleElement(elem, this.GetLocation(atom.terminal()));
                        element.Type = atom.terminal().GetText();
                        this.CollectAnnotations(element, elem.annotation());
                    }
                    else if (atom.ruleref() != null)
                    {
                        if (kind == TokenOrRule.Token) return false;
                        element = new Antlr4ParserRuleElement(elem, this.GetLocation(atom.ruleref()));
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
                        if (!element.IsOptional)
                        {
                            var alternativeContext = elem.Parent as Antlr4RoslynParser.AlternativeContext;
                            if (alternativeContext != null)
                            {
                                var altListContext = alternativeContext.Parent as Antlr4RoslynParser.AltListContext;
                                if (altListContext != null)
                                {
                                    var blockContext = altListContext.Parent as Antlr4RoslynParser.BlockContext;
                                    if (blockContext != null)
                                    {
                                        var ebnfContext= blockContext.Parent as Antlr4RoslynParser.EbnfContext;
                                        if (ebnfContext != null)
                                        {
                                            if (IsEbnfOptional(ebnfContext?.blockSuffix()?.ebnfSuffix()))
                                            {
                                                element.IsOptional = true;
                                            }
                                        }
                                    }
                                }
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
                    second.ebnf().block().altList().alternative().Length == 1)
                {
                    Antlr4RoslynParser.ElementContext[] secondBlockElements = second.ebnf().block().altList().alternative()[0].element().Where(e => !this.IsActionBlock(e)).ToArray();
                    if (secondBlockElements.Length == 2)
                    {
                        Antlr4RoslynParser.ElementContext token = secondBlockElements[0];
                        Antlr4RoslynParser.ElementContext ruleRep = secondBlockElements[1];
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
            }
            if (first != null)
            {
                if (first.ebnf() != null && first.ebnf().blockSuffix() != null && first.ebnf().blockSuffix().ebnfSuffix() != null &&
                    (first.ebnf().blockSuffix().ebnfSuffix().PLUS() != null ||
                    first.ebnf().blockSuffix().ebnfSuffix().STAR() != null) &&
                    first.ebnf().blockSuffix().ebnfSuffix().QUESTION().Length == 0 &&
                    first.ebnf().block().altList().alternative().Length == 1)
                {
                    Antlr4RoslynParser.ElementContext[] firstBlockElements = first.ebnf().block().altList().alternative()[0].element().Where(e => !this.IsActionBlock(e)).ToArray();
                    if (firstBlockElements.Length == 2)
                    {
                        Antlr4RoslynParser.ElementContext ruleRep = firstBlockElements[0];
                        Antlr4RoslynParser.ElementContext token = firstBlockElements[1];
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
        public Antlr4AnnotatedObject(Location location)
        {
            this.Annotations = MetaCompilerAnnotations.Empty;
            this.Location = location;
        }
        public MetaCompilerAnnotations Annotations { get; internal set; }
        public bool ContainsDeclarationTreeAnnotations { get; internal set; }
        public bool ContainsAnnotations { get; internal set; }
        public bool HasAnnotations { get; internal set; }
        public bool ContainsBinderAnnotations { get; internal set; }
        public bool HasBinderAnnotations { get; internal set; }
        public bool ContainsBoundNodeAnnotations { get; internal set; }
        public bool HasBoundNodeAnnotations { get; internal set; }
        public Location Location { get; internal set; }
    }
    public class Antlr4Grammar : Antlr4AnnotatedObject
    {
        public Antlr4Grammar(Location location)
            : base(location)
        {
            this.CustomAnnotations = new List<MetaCompilerAnnotation>();
            this.Imports = new HashSet<string>();
            this.ParserRuleElemUses = new HashSet<string>();
            this.ParserRules = new List<Antlr4ParserRule>();
            this.LexerRules = new List<Antlr4LexerRule>();
            this.VirtualTokenKinds = new List<string>();
            this.LexerTokenKinds = new Dictionary<string, List<Antlr4LexerRule>>();
            this.LexerModes = new List<Antlr4LexerMode>();
            this.FixedTokenCandidates = new List<Antlr4LexerRule>();
            this.FixedTokens = new List<Antlr4LexerRule>();
        }
        public string Name { get; set; }
        public string ErrorCodeCategory { get; set; }
        public string MessagePrefix { get; set; }
        public string LexerHeader { get; set; }
        public string ParserHeader { get; set; }
        public List<MetaCompilerAnnotation> CustomAnnotations { get; private set; }
        public HashSet<string> Imports { get; private set; }
        public HashSet<string> ParserRuleElemUses { get; private set; }
        public List<string> VirtualTokenKinds { get; private set; }
        public Dictionary<string, List<Antlr4LexerRule>> LexerTokenKinds { get; private set; }
        public Antlr4LexerRule FirstTokenSyntaxKind { get; set; }
        public Antlr4LexerRule LastTokenSyntaxKind { get; set; }
        public Antlr4LexerRule FirstFixedTokenSyntaxKind { get; set; }
        public Antlr4LexerRule LastFixedTokenSyntaxKind { get; set; }
        public Antlr4ParserRule FirstParserRuleSyntaxKind { get; set; }
        public Antlr4ParserRule LastParserRuleSyntaxKind { get; set; }
        public List<Antlr4ParserRule> ParserRules { get; private set; }
        public List<Antlr4LexerRule> LexerRules { get; private set; }
        public Antlr4LexerRule DefaultWhitespaceKind { get; set; }
        public Antlr4LexerRule DefaultEndOfLineKind { get; set; }
        public Antlr4LexerRule DefaultIdentifierKind { get; set; }
        public Antlr4LexerRule DefaultSeparatorKind { get; set; }
        public List<Antlr4LexerMode> LexerModes { get; private set; }
        internal List<Antlr4LexerRule> FixedTokenCandidates { get; private set; }
        public List<Antlr4LexerRule> FixedTokens { get; private set; }
        public Antlr4ParserRule FindParserRule(string type)
        {
            return this.ParserRules.FirstOrDefault(rule => rule.Name == type);
        }
    }
    public class Antlr4ParserRule : Antlr4AnnotatedObject
    {
        public Antlr4ParserRule(Antlr4Grammar grammar, Location location)
            : base(location)
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
        public Antlr4ParserRule FirstNonAbstractAlternative { get; internal set; }
        public bool IsSimpleAlt { get; internal set; }
        public bool IsRecursive { get; internal set; }
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

    }
    public class Antlr4ParserRuleElement : Antlr4AnnotatedObject
    {
        public Antlr4ParserRuleElement(object node, Location location)
            : base(location)
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
                if (this.IsList) result = "_" + this.Name;
                else result = this.Name;
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
        public bool IsMappedToIList()
        {
            if (this.IsList)
            {
                if ((!this.IsSimplified && this.Name != this.Type) ||
                (this.IsSimplified && this.Name != this.OriginalType))
                {
                    return true;
                }
            }
            return false;
        }
    }
    public class Antlr4LexerMode : Antlr4AnnotatedObject
    {
        public Antlr4LexerMode(Antlr4Grammar grammar, Location location)
            : base(location)
        {
            this.Grammar = grammar;
            this.LexerRules = new List<Antlr4LexerRule>();
        }
        public Antlr4Grammar Grammar { get; private set; }
        public string Name { get; set; }
        public int Kind { get; set; }
        public List<Antlr4LexerRule> LexerRules { get; private set; }
    }
    public class Antlr4LexerRule : Antlr4AnnotatedObject
    {
        public Antlr4LexerRule(Antlr4LexerMode mode, Location location)
            : base(location)
        {
            this.Mode = mode;
        }
        public Antlr4Grammar Grammar { get { return this.Mode.Grammar; } }
        public Antlr4LexerMode Mode { get; private set; }
        public string Name { get; set; }
        public string FixedToken { get; set; }
        public int Kind { get; set; }
        public bool Artificial { get; set; }
    }


    internal class Antlr4AnnotationRemover : Antlr4RoslynParserBaseVisitor<object>
    {
        private TokenStreamRewriter rewriter;
        private BufferedTokenStream tokens;

        public Antlr4AnnotationRemover(BufferedTokenStream tokens)
        {
            this.tokens = tokens;
            rewriter = new TokenStreamRewriter(tokens);
        }

        public string GetText()
        {
            return rewriter.GetText();
        }

        public LinePositionSpan GetTokenSpanAt(int line, int column)
        {
            foreach (var token in tokens.GetTokens())
            {
                if (token.Line == line && token.Column == column) return new LinePositionSpan(new LinePosition(token.Line - 1, token.Column), new LinePosition(token.Line - 1, token.Column + token.StopIndex - token.StartIndex + 1));
            }
            return default;
        }

        private void RemoveText(ParserRuleContext context)
        {
            string text = this.tokens.GetText(context);
            StringBuilder sb = new StringBuilder();
            foreach (char ch in text)
            {
                if (ch == '\r' || ch == '\n')
                {
                    sb.Append(ch);
                }
                else
                {
                    sb.Append(' ');
                }
            }
            //rewriter.Delete(context.Start, context.Stop);
            string newText = sb.ToString();
            rewriter.Replace(context.Start, context.Stop, newText);
        }

        public override object VisitOption(Antlr4RoslynParser.OptionContext context)
        {
            if (context.identifier().GetText() == "generateCompiler")
            {
                this.RemoveText(context);
            }
            else if (context.identifier().GetText() == "generateCompilerBase")
            {
                this.RemoveText(context);
            }
            else if (context.identifier().GetText() == "ignoreRoslynRules")
            {
                this.RemoveText(context);
            }
            else if (context.identifier().GetText() == "generateLanguageService")
            {
                this.RemoveText(context);
            }
            return null;
        }

        public override object VisitAnnotation(Antlr4RoslynParser.AnnotationContext context)
        {
            this.RemoveText(context);
            return null;
        }

    }
}
