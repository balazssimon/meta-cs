﻿using Antlr4.Runtime;
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
using MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax;
using MetaDslx.Languages.Antlr4Roslyn.Generator;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using MetaDslx.Languages.Meta;
using System.Reflection;

namespace MetaDslx.Languages.Antlr4Roslyn.Compilation
{
    public class Antlr4RoslynCompiler : Antlr4Compiler<Antlr4RoslynLexer, Antlr4RoslynParser>
    {
        private Antlr4Tool _antlr4Tool;

        private Antlr4AnnotationRemover remover;
        public string GeneratedAntlr4GrammarFile { get; private set; }
        public string Antlr4GrammarSource { get; private set; }

        public Antlr4Grammar Grammar { get; private set; }
        public string LanguageName { get; private set; }

        public string SyntaxDirectory { get; private set; }
        public string InternalSyntaxDirectory { get; private set; }

        public bool IsLexer { get; private set; }
        public bool IsParser { get; private set; }
        public bool GenerateCompiler { get; private set; }
        public bool GenerateLanguageService { get; private set; }
        public bool IgnoreRoslynRules { get; private set; }

        public bool GenerateAntlr4 { get; private set; }
        public bool HasAntlr4Errors { get; private set; }

        public string GeneratedSyntaxKind { get; private set; }
        public string GeneratedInternalSyntax { get; private set; }
        public string GeneratedSyntaxFacts { get; private set; }
        public string GeneratedSyntax { get; private set; }
        public string GeneratedSyntaxTree { get; private set; }
        public string GeneratedLanguage { get; private set; }
        public string GeneratedErrorCode { get; private set; }
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
        public string GeneratedSymbolBuilder { get; private set; }

        //public string GeneratedLanguageService { get; private set; }

        public IEnumerable<string> GeneratedRoslynFiles { get; private set; }

        public Antlr4RoslynCompiler(string inputFilePath, string outputDirectory, string defaultNamespace, Antlr4Tool antlr4Tool)
            : base(inputFilePath, outputDirectory, defaultNamespace)
        {
            this._antlr4Tool = antlr4Tool;
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

            if (this.OutputDirectory != null)
            {
                string directory = this.OutputDirectory;
                DirectoryInfo info = new DirectoryInfo(directory);
                if (info.Name == "InternalSyntax")
                {
                    info = info.Parent;
                }
                if (info.Name == "Syntax")
                {
                    info = info.Parent;
                }
                directory = info.FullName;

                this.SyntaxDirectory = Path.Combine(directory, "Syntax");
                this.InternalSyntaxDirectory = Path.Combine(this.SyntaxDirectory, "InternalSyntax");
                Directory.CreateDirectory(Path.Combine(directory, this.InternalSyntaxDirectory));

                this.OutputDirectory = directory;
            }
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
            this.remover = new Antlr4AnnotationRemover(this.CommonTokenStream);
            this.remover.Visit(this.ParseTree);
            this.Antlr4GrammarSource = remover.GetText();
            this.GeneratedAntlr4GrammarFile = Path.Combine(this.InternalSyntaxDirectory, Path.ChangeExtension(this.FileName, ".g4"));
            File.WriteAllText(this.GeneratedAntlr4GrammarFile, this.Antlr4GrammarSource);
            _antlr4Tool.GenerateVisitor = true;
            _antlr4Tool.OutputPath = this.InternalSyntaxDirectory;
            _antlr4Tool.SourceCodeFiles.Add(this.GeneratedAntlr4GrammarFile);
            _antlr4Tool.Diagnostics = this.DiagnosticBag;
            if (!_antlr4Tool.Execute())
            {
                this.DiagnosticBag.Add(Antlr4RoslynErrorCode.ERR_Antlr4ToolError, "could not generate C# files");
                return false;
            }
            return true;
        }

        protected override void DoCompile()
        {
            if (!this.PreCompile()) return;

            RoslynRuleCollector ruleCollector = new RoslynRuleCollector(this);
            ruleCollector.Visit(this.ParseTree);
            this.IsLexer = ruleCollector.IsLexer;
            this.IsParser = ruleCollector.IsParser;
            this.GenerateCompiler = ruleCollector.GenerateCompiler;
            this.GenerateLanguageService = ruleCollector.GenerateLanguageService;
            this.IgnoreRoslynRules = ruleCollector.IgnoreRoslynRules;
            this.Grammar = ruleCollector.Grammar;

            this.PostCompile();
        }

        protected virtual bool PostCompile()
        {
            string antlr4TokensFile = Path.ChangeExtension(this.GeneratedAntlr4GrammarFile, ".tokens");
            if (!File.Exists(antlr4TokensFile))
            {
                this.DiagnosticBag.Add(Antlr4RoslynErrorCode.ERR_Antlr4ToolError, string.Format("Tokens file '{0}' is missing.", antlr4TokensFile));
                return false;
            }
            string antlr4TokensSource = File.ReadAllText(antlr4TokensFile);
            this.ReadTokens(antlr4TokensSource);

            this.Grammar.FirstParserRuleSyntaxKind = this.Grammar.ParserRules.FirstOrDefault()?.Name;
            this.Grammar.LastParserRuleSyntaxKind = this.Grammar.ParserRules.LastOrDefault()?.Name;
            this.Grammar.LexerRules.Sort((r1, r2) => r1.Kind.CompareTo(r2.Kind));
            this.Grammar.FirstTokenSyntaxKind = this.Grammar.LexerRules.FirstOrDefault(r => r.Kind > 0)?.Name;
            this.Grammar.LastTokenSyntaxKind = this.Grammar.LexerRules.LastOrDefault(r => r.Kind > 0)?.Name;

            if (this.IsLexer)
            {
                this.CollectLexerTokenKinds();
            }
            if (this.IsParser)
            {
                this.CollectCustomAnnotations();
                this.CollectHasAnnotationFlags();
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
                                rule = new Antlr4LexerRule(this.Grammar.LexerModes.FirstOrDefault());
                                rule.Name = tokenName;
                                rule.Artificial = true;
                                this.Grammar.LexerRules.Add(rule);
                            }
                            rule.Kind = tokenKind;
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
            this.GeneratedSyntaxFacts = generator.GenerateSyntaxFacts();
            this.GeneratedSyntaxKind = generator.GenerateSyntaxKind();
            //this.GeneratedLanguageService = this.GetLanguageService();

            if (this.OutputDirectory == null) return;

            List<string> generatedRoslynFiles = new List<string>();
            this.GeneratedRoslynFiles = generatedRoslynFiles;

            if (this.GenerateCompiler)
            {
                string outputFileName = Path.Combine(this.SyntaxDirectory, this.LanguageName + "SyntaxFacts.cs");
                generatedRoslynFiles.Add(outputFileName);
                using (StreamWriter writer = new StreamWriter(outputFileName))
                {
                    writer.WriteLine(this.GeneratedSyntaxFacts);
                }
                outputFileName = Path.Combine(this.SyntaxDirectory, this.LanguageName + "SyntaxKind.cs");
                generatedRoslynFiles.Add(outputFileName);
                using (StreamWriter writer = new StreamWriter(outputFileName))
                {
                    writer.WriteLine(this.GeneratedSyntaxKind);
                }
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

            List<string> generatedRoslynFiles = new List<string>();
            this.GeneratedRoslynFiles = generatedRoslynFiles;

            this.GeneratedSyntaxKind = generator.GenerateSyntaxKind();

            this.GeneratedInternalSyntax = generator.GenerateInternalSyntax();
            this.GeneratedSyntax = generator.GenerateSyntax();
            this.GeneratedSyntaxTree = generator.GenerateSyntaxTree();
            this.GeneratedErrorCode = generator.GenerateErrorCode();
            this.GeneratedSyntaxParser = generator.GenerateSyntaxParser();
            this.GeneratedLanguage = generator.GenerateLanguage();
            this.GeneratedLanguageVersion = generator.GenerateLanguageVersion();
            this.GeneratedParseOptions = generator.GenerateParseOptions();
            this.GeneratedFeature = generator.GenerateFeature();

            this.GeneratedCompilation = generator.GenerateCompilation();
            this.GeneratedCompilationFactory = generator.GenerateCompilationFactory();
            this.GeneratedCompilationOptions = generator.GenerateCompilationOptions();
            this.GeneratedScriptCompilationInfo = generator.GenerateScriptCompilationInfo();

            this.GeneratedDeclarationTreeBuilder = generator.GenerateDeclarationTreeBuilder();
            this.GeneratedBinderFactoryVisitor = generator.GenerateBinderFactoryVisitor();
            this.GeneratedSymbolBuilder = generator.GenerateSymbolBuilder();

            if (this.OutputDirectory == null) return;

            if (this.GenerateCompiler)
            {
                Directory.CreateDirectory(Path.Combine(this.OutputDirectory, @"Errors"));
                Directory.CreateDirectory(Path.Combine(this.OutputDirectory, @"Parser"));
                Directory.CreateDirectory(Path.Combine(this.OutputDirectory, @"Compilation"));
                Directory.CreateDirectory(Path.Combine(this.OutputDirectory, @"Binding"));
                string outputFileName = Path.Combine(this.InternalSyntaxDirectory, this.LanguageName + "InternalSyntax.cs");
                generatedRoslynFiles.Add(outputFileName);
                using (StreamWriter writer = new StreamWriter(outputFileName))
                {
                    writer.WriteLine(this.GeneratedInternalSyntax);
                }
                outputFileName = Path.Combine(this.SyntaxDirectory, this.LanguageName + "SyntaxKind.cs");
                generatedRoslynFiles.Add(outputFileName);
                using (StreamWriter writer = new StreamWriter(outputFileName))
                {
                    writer.WriteLine(this.GeneratedSyntaxKind);
                }
                outputFileName = Path.Combine(this.SyntaxDirectory, this.LanguageName + "Syntax.cs");
                generatedRoslynFiles.Add(outputFileName);
                using (StreamWriter writer = new StreamWriter(outputFileName))
                {
                    writer.WriteLine(this.GeneratedSyntax);
                }
                outputFileName = Path.Combine(this.SyntaxDirectory, this.LanguageName + "SyntaxTree.cs");
                generatedRoslynFiles.Add(outputFileName);
                using (StreamWriter writer = new StreamWriter(outputFileName))
                {
                    writer.WriteLine(this.GeneratedSyntaxTree);
                }
                outputFileName = Path.Combine(this.OutputDirectory, @"Errors\" + this.LanguageName + @"ErrorCode.cs");
                generatedRoslynFiles.Add(outputFileName);
                using (StreamWriter writer = new StreamWriter(outputFileName))
                {
                    writer.WriteLine(this.GeneratedErrorCode);
                }
                outputFileName = Path.Combine(this.OutputDirectory, @"Parser\" + this.LanguageName + @"SyntaxParser.cs");
                generatedRoslynFiles.Add(outputFileName);
                using (StreamWriter writer = new StreamWriter(outputFileName))
                {
                    writer.WriteLine(this.GeneratedSyntaxParser);
                }
                outputFileName = Path.Combine(this.OutputDirectory, @"Compilation\" + this.LanguageName + @"Language.cs");
                generatedRoslynFiles.Add(outputFileName);
                if (!File.Exists(outputFileName))
                {
                    using (StreamWriter writer = new StreamWriter(outputFileName))
                    {
                        writer.WriteLine(this.GeneratedLanguage);
                    }
                }
                outputFileName = Path.Combine(this.OutputDirectory, @"Compilation\" + this.LanguageName + @"Compilation.cs");
                generatedRoslynFiles.Add(outputFileName);
                using (StreamWriter writer = new StreamWriter(outputFileName))
                {
                    writer.WriteLine(this.GeneratedCompilation);
                }
                outputFileName = Path.Combine(this.OutputDirectory, @"Compilation\" + this.LanguageName + @"CompilationFactory.cs");
                generatedRoslynFiles.Add(outputFileName);
                using (StreamWriter writer = new StreamWriter(outputFileName))
                {
                    writer.WriteLine(this.GeneratedCompilationFactory);
                }
                outputFileName = Path.Combine(this.OutputDirectory, @"Compilation\" + this.LanguageName + @"CompilationOptions.cs");
                generatedRoslynFiles.Add(outputFileName);
                using (StreamWriter writer = new StreamWriter(outputFileName))
                {
                    writer.WriteLine(this.GeneratedCompilationOptions);
                }
                outputFileName = Path.Combine(this.OutputDirectory, @"Compilation\" + this.LanguageName + @"ScriptCompilationInfo.cs");
                generatedRoslynFiles.Add(outputFileName);
                using (StreamWriter writer = new StreamWriter(outputFileName))
                {
                    writer.WriteLine(this.GeneratedScriptCompilationInfo);
                }
                outputFileName = Path.Combine(this.OutputDirectory, @"Compilation\" + this.LanguageName + @"LanguageVersion.cs");
                generatedRoslynFiles.Add(outputFileName);
                using (StreamWriter writer = new StreamWriter(outputFileName))
                {
                    writer.WriteLine(this.GeneratedLanguageVersion);
                }
                outputFileName = Path.Combine(this.OutputDirectory, @"Compilation\" + this.LanguageName + @"ParseOptions.cs");
                generatedRoslynFiles.Add(outputFileName);
                using (StreamWriter writer = new StreamWriter(outputFileName))
                {
                    writer.WriteLine(this.GeneratedParseOptions);
                }
                outputFileName = Path.Combine(this.OutputDirectory, @"Compilation\" + this.LanguageName + @"Feature.cs");
                generatedRoslynFiles.Add(outputFileName);
                using (StreamWriter writer = new StreamWriter(outputFileName))
                {
                    writer.WriteLine(this.GeneratedFeature);
                }
                outputFileName = Path.Combine(this.OutputDirectory, @"Binding\" + this.LanguageName + @"DeclarationTreeBuilderVisitor.cs");
                generatedRoslynFiles.Add(outputFileName);
                using (StreamWriter writer = new StreamWriter(outputFileName))
                {
                    writer.WriteLine(this.GeneratedDeclarationTreeBuilder);
                }
                outputFileName = Path.Combine(this.OutputDirectory, @"Binding\" + this.LanguageName + @"BinderFactoryVisitor.cs");
                generatedRoslynFiles.Add(outputFileName);
                using (StreamWriter writer = new StreamWriter(outputFileName))
                {
                    writer.WriteLine(this.GeneratedBinderFactoryVisitor);
                }
                outputFileName = Path.Combine(this.OutputDirectory, @"Binding\" + this.LanguageName + @"SymbolBuilder.cs");
                generatedRoslynFiles.Add(outputFileName);
                using (StreamWriter writer = new StreamWriter(outputFileName))
                {
                    writer.WriteLine(this.GeneratedSymbolBuilder);
                }
            }
        }

        private void CollectCustomAnnotations()
        {
            this.DefineCustomAnnotations();
            //this.ReferenceCustomAnnotations();
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
                        this.Grammar.DefaultWhitespace = rule;
                    }
                    if (tokenAnnot.GetValue("defaultEndOfLine") == "true")
                    {
                        this.Grammar.DefaultEndOfLine = rule;
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
            bool foundNewFlag = true;
            while (foundNewFlag)
            {
                foundNewFlag = false;
                foreach (var rule in this.Grammar.ParserRules)
                {
                    bool foundRuleFlag = this.CollectHasAnnotationFlags(rule);
                    if (rule.Annotations.Annotations.Count > 0)
                    {
                        if (!rule.ContainsAnnotations) foundRuleFlag = true;
                        rule.HasAnnotations = true;
                    }
                    if (foundRuleFlag)
                    {
                        rule.ContainsAnnotations = true;
                        foundNewFlag = true;
                    }
                    foreach (var alt in rule.Alternatives)
                    {
                        foundRuleFlag = this.CollectHasAnnotationFlags(alt);
                        if (alt.Annotations.Annotations.Count > 0)
                        {
                            if (!alt.ContainsAnnotations) foundRuleFlag = true;
                            alt.HasAnnotations = true;
                        }
                        if (foundRuleFlag)
                        {
                            alt.ContainsAnnotations = true;
                            rule.ContainsAnnotations = true;
                            foundNewFlag = true;
                        }
                    }
                }
            }
        }

        private bool CollectHasAnnotationFlags(Antlr4ParserRule rule)
        {
            bool foundElemFlag = false;
            foreach (var elem in rule.AllElements)
            {
                if (!elem.ContainsAnnotations)
                {
                    if (elem.Annotations.Annotations.Count > 0)
                    {
                        this.Grammar.ParserRuleElemUses.Add(elem.RedName());
                        elem.ContainsAnnotations = true;
                        elem.HasAnnotations = true;
                        foundElemFlag = true;
                    }
                    if (elem.BlockItems.Count > 0)
                    {
                        foreach (var item in elem.BlockItems)
                        {
                            if (item.Annotations.Annotations.Count > 0)
                            {
                                this.Grammar.ParserRuleElemUses.Add(elem.RedName());
                                item.HasAnnotations = true;
                                elem.HasAnnotations = true;
                                elem.ContainsAnnotations = true;
                                foundElemFlag = true;
                            }
                        }
                    }
                }
                if (!elem.ContainsAnnotations)
                {
                    Antlr4ParserRule elemTypeRule = this.Grammar.FindParserRule(elem.Type);
                    if (elemTypeRule != null && elemTypeRule.ContainsAnnotations)
                    {
                        elem.ContainsAnnotations = true;
                        foundElemFlag = true;
                    }
                }
            }
            return foundElemFlag;
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
            currentMode = new Antlr4LexerMode(this.currentGrammar);
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
                    this.currentLexerRule = new Antlr4LexerRule(this.currentMode);
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
            currentMode = new Antlr4LexerMode(this.currentGrammar);
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
            Antlr4RoslynParser.ElementContext[] elems = context.alternative().element().Where(e => !this.IsActionBlock(e)).ToArray();
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
        public Antlr4AnnotatedObject()
        {
            this.Annotations = MetaCompilerAnnotations.Empty;
        }
        public MetaCompilerAnnotations Annotations { get; internal set; }
        public bool ContainsDeclarationTreeAnnotations { get; internal set; }
        public bool ContainsAnnotations { get; internal set; }
        public bool HasAnnotations { get; internal set; }
    }
    public class Antlr4Grammar : Antlr4AnnotatedObject
    {
        public Antlr4Grammar()
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
        public List<MetaCompilerAnnotation> CustomAnnotations { get; private set; }
        public HashSet<string> Imports { get; private set; }
        public HashSet<string> ParserRuleElemUses { get; private set; }
        public List<string> VirtualTokenKinds { get; private set; }
        public Dictionary<string, List<Antlr4LexerRule>> LexerTokenKinds { get; private set; }
        public string FirstTokenSyntaxKind { get; set; }
        public string LastTokenSyntaxKind { get; set; }
        public string FirstParserRuleSyntaxKind { get; set; }
        public string LastParserRuleSyntaxKind { get; set; }
        public List<Antlr4ParserRule> ParserRules { get; private set; }
        public List<Antlr4LexerRule> LexerRules { get; private set; }
        public Antlr4LexerRule DefaultWhitespace { get; set; }
        public Antlr4LexerRule DefaultEndOfLine { get; set; }
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
    public class Antlr4LexerMode : Antlr4AnnotatedObject
    {
        public Antlr4LexerMode(Antlr4Grammar grammar)
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
        public Antlr4LexerRule(Antlr4LexerMode mode)
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