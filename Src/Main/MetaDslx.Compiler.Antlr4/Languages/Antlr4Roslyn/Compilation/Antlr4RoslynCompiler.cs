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
using System.Diagnostics;
using MetaDslx.Properties;
using MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax;
using MetaDslx.Languages.Antlr4Roslyn.Generator;

namespace MetaDslx.Languages.Antlr4Roslyn.Compilation
{
    public class Antlr4RoslynCompiler : Antlr4Compiler<Antlr4RoslynLexer, Antlr4RoslynParser>
    {
        private Antlr4AnnotationRemover remover;

        public string Antlr4Jar { get; private set; }

        public Antlr4Grammar Grammar { get; private set; }
        public string LanguageName { get; private set; }

        public bool IsLexer { get; private set; }
        public bool IsParser { get; private set; }
        public bool GenerateCompiler { get; private set; }
        public bool GenerateLanguageService { get; private set; }

        public string Antlr4Source { get; private set; }
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

        public Antlr4RoslynCompiler(string source, string defaultNamespace, string inputDirectory, string outputDirectory, string fileName)
            : base(source, defaultNamespace, inputDirectory, outputDirectory, fileName)
        {
            string languageName = Path.GetFileNameWithoutExtension(this.FileName);
            if (languageName.EndsWith("Parser")) languageName = languageName.Substring(0, languageName.Length - 6);
            else if (languageName.EndsWith("Lexer")) languageName = languageName.Substring(0, languageName.Length - 5);
            this.LanguageName = languageName;
        }

        protected override Antlr4RoslynLexer CreateLexer(AntlrInputStream stream)
        {
            return new Antlr4RoslynLexer(stream);
        }

        protected override Antlr4RoslynParser CreateParser(CommonTokenStream stream)
        {
            return new Antlr4RoslynParser(stream);
        }

        protected override ParserRuleContext CreateTree()
        {
            return this.Parser.grammarSpec();
        }

        protected override void DoCompile()
        {
            RoslynRuleCollector ruleCollector = new RoslynRuleCollector(this);
            ruleCollector.Visit(this.ParseTree);
            this.IsLexer = ruleCollector.IsLexer;
            this.IsParser = ruleCollector.IsParser;
            this.GenerateCompiler = ruleCollector.GenerateCompiler;
            this.GenerateLanguageService = ruleCollector.GenerateLanguageService;
            this.Grammar = ruleCollector.Grammar;

            if (this.IsLexer)
            {
                this.CollectLexerTokenKinds();
            }
            if (this.IsParser)
            {
                this.CollectCustomAnnotations();
                this.CollectHasAnnotationFlags();
            }

            this.remover = new Antlr4AnnotationRemover(this.CommonTokenStream);
            this.remover.Visit(this.ParseTree);
            this.Antlr4Source = remover.GetText();
        }

        protected override void DoGenerate()
        {
            this.GenerateAntlr4();
            this.GenerateLexer();
            this.GenerateParser();
        }

        private bool PrepareAntlr4()
        {
            try
            {
                string appDataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string metaDslxDir = Path.Combine(appDataDir, "MetaDslx");
                Directory.CreateDirectory(metaDslxDir);
                Antlr4Jar = Path.Combine(metaDslxDir, Resources.Antlr4JarName);
                if (!File.Exists(Antlr4Jar))
                {
                    File.WriteAllBytes(Antlr4Jar, Resources.antlr_4_5_3_complete);
                }
                return new FileInfo(Antlr4Jar).Length == Resources.antlr_4_5_3_complete.Length;
            }
            catch (Exception ex)
            {
                this.AddDiagnostic(Antlr4RoslynErrorCode.ERR_Antlr4LoadError, ex.Message, this.FileName);
                return false;
            }
        }

        private string GetTemporaryDirectory()
        {
            string tempDirectory = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory(tempDirectory);
            return tempDirectory;
        }

        private bool CopyToOutput(string tmpDir, string fileName)
        {
            if (this.OutputDirectory == null) return false;
            string tmpFile = Path.Combine(tmpDir, fileName);
            string outputFile = Path.Combine(this.OutputDirectory, fileName);
            if (File.Exists(tmpFile))
            {
                File.Copy(tmpFile, outputFile, true);
                return true;
            }
            return false;
        }

        private void ProcessAntlr4ErrorLine(string line)
        {
            if (string.IsNullOrWhiteSpace(line)) return;
            Antlr4RoslynErrorCode errorCode = Antlr4RoslynErrorCode.INF_Antlr4Info;
            if (line.StartsWith("error"))
            {
                errorCode = Antlr4RoslynErrorCode.ERR_Antlr4Error;
            }
            else if (line.StartsWith("warning"))
            {
                errorCode = Antlr4RoslynErrorCode.WRN_Antlr4Warning;
            }
            int colonIndex = line.IndexOf(':');
            if (colonIndex >= 0)
            {
                line = line.Substring(colonIndex + 1);
                colonIndex = line.IndexOf(':');
                if (colonIndex >= 0)
                {
                    string fileName = line.Substring(0, colonIndex).Trim();
                    line = line.Substring(colonIndex + 1);
                    colonIndex = line.IndexOf(':');
                    if (colonIndex >= 0)
                    {
                        string lineIndexStr = line.Substring(0, colonIndex).Trim();
                        line = line.Substring(colonIndex + 1);
                        colonIndex = line.IndexOf(':');
                        if (colonIndex >= 0)
                        {
                            string colIndexStr = line.Substring(0, colonIndex).Trim();
                            line = line.Substring(colonIndex + 1);
                            if (string.IsNullOrWhiteSpace(lineIndexStr)) lineIndexStr = "0";
                            if (string.IsNullOrWhiteSpace(colIndexStr)) colIndexStr = "0";
                            int lineIndex;
                            int.TryParse(lineIndexStr, out lineIndex);
                            int colIndex;
                            int.TryParse(colIndexStr, out colIndex);
                            if (lineIndex < 1)
                            {
                                lineIndex = 1;
                                colIndex = 0;
                            }
                            LinePositionSpan span = LinePositionSpan.Zero;
                            if (remover != null)
                            {
                                span = remover.GetTokenSpanAt(lineIndex, colIndex);
                            }
                            else
                            {
                                span = new LinePositionSpan(new LinePosition(lineIndex, colIndex + 1), new LinePosition(lineIndex, colIndex + 1));
                            }
                            this.AddDiagnostic(errorCode, line);
                        }
                    }
                }
            }
        }

        private void GenerateAntlr4()
        {
            try
            {
                this.PrepareAntlr4();
                string bareFileName = Path.GetFileNameWithoutExtension(this.FileName);
                string grammarFileName = bareFileName + ".g4";
                string tmpDir = this.GetTemporaryDirectory();
                try
                {
                    foreach (var import in this.Grammar.ImportedGrammars)
                    {
                        string importFile = Path.Combine(this.InputDirectory, import + ".g4");
                        string tmpImportFile = Path.Combine(tmpDir, import + ".g4");
                        if (File.Exists(importFile))
                        {
                            File.Copy(importFile, tmpImportFile, true);
                        }
                    }
                    string antlr4File = Path.Combine(tmpDir, grammarFileName);
                    File.WriteAllText(antlr4File, this.Antlr4Source);
                    Process proc = new Process();
                    proc.StartInfo.UseShellExecute = false;
                    proc.StartInfo.RedirectStandardOutput = true;
                    proc.StartInfo.RedirectStandardError = true;
                    proc.StartInfo.CreateNoWindow = true;
                    proc.StartInfo.WorkingDirectory = this.OutputDirectory;
                    proc.StartInfo.FileName = "java";
                    if (this.DefaultNamespace != null)
                    {
                        proc.StartInfo.Arguments = "-jar \"" + this.Antlr4Jar + "\" -Dlanguage=CSharp \"" + antlr4File + "\" -lib . -listener -visitor -package " + this.DefaultNamespace + " -o \"" + tmpDir + "\"";
                    }
                    else
                    {
                        proc.StartInfo.Arguments = "-jar \"" + this.Antlr4Jar + "\" -Dlanguage=CSharp \"" + antlr4File + "\" -lib . -listener -visitor -o \"" + tmpDir + "\"";
                    }
                    proc.Start();
                    int timeout = 30000;
                    bool terminated = proc.WaitForExit(timeout);
                    if (!terminated)
                    {
                        this.AddDiagnostic(Antlr4RoslynErrorCode.ERR_Antlr4TimeoutError, this.FileName);
                        try
                        {
                            proc.Kill();
                        }
                        catch(Exception)
                        {
                            // nop
                        }
                        while (!proc.StandardError.EndOfStream)
                        {
                            string line = proc.StandardError.ReadLine();
                            this.ProcessAntlr4ErrorLine(line);
                        }
                    }
                    if (terminated)
                    {
                        while (!proc.StandardError.EndOfStream)
                        {
                            string line = proc.StandardError.ReadLine();
                            this.ProcessAntlr4ErrorLine(line);
                        }
                        this.HasAntlr4Errors = this.DiagnosticBag.HasAnyErrors();
                        if (!this.HasAntlr4Errors)
                        {
                            this.ReadTokens(Path.Combine(tmpDir, bareFileName + ".tokens"));
                            if (this.GenerateOutput)
                            {
                                this.CopyToOutput(tmpDir, bareFileName + ".cs");
                                this.CopyToOutput(tmpDir, bareFileName + ".tokens");
                                if (this.IsParser)
                                {
                                    this.CopyToOutput(tmpDir, bareFileName + "BaseVisitor.cs");
                                    this.CopyToOutput(tmpDir, bareFileName + "BaseListener.cs");
                                    this.CopyToOutput(tmpDir, bareFileName + "Visitor.cs");
                                    this.CopyToOutput(tmpDir, bareFileName + "Listener.cs");
                                }
                            }
                        }
                    }
                }
                finally
                {
                    Directory.Delete(tmpDir, true);
                }
            }
            catch (Exception ex)
            {
                this.AddDiagnostic(Antlr4RoslynErrorCode.ERR_Antlr4CallError, ex.Message, this.FileName);
            }
        }

        private void ReadTokens(string tokensFileName)
        {
            int maxTokenKind = 0;
            if (File.Exists(tokensFileName))
            {
                Dictionary<string, int> fixedTokens = new Dictionary<string, int>();
                using (StreamReader reader = new StreamReader(tokensFileName))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        string tokenName;
                        int tokenKind;
                        bool fixedToken;
                        if (!string.IsNullOrEmpty(line) && this.TryGetToken(line, out tokenName, out tokenKind, out fixedToken))
                        {
                            if (tokenKind > maxTokenKind) maxTokenKind = tokenKind;
                            if (fixedToken)
                            {
                                fixedTokens.Add(tokenName, tokenKind);
                            }
                            else
                            {
                                Antlr4LexerRule rule = this.Grammar.LexerRules.FirstOrDefault(r => r.Name == tokenName);
                                if (rule == null)
                                {
                                    rule = new Antlr4LexerRule(this.Grammar.Modes.FirstOrDefault());
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
                //this.Grammar.LexerRules.RemoveAll(r => r.Kind == 0);
                this.Grammar.FirstRuleKind = maxTokenKind + 1;
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
                while (index < tokenLine.Length && tokenLine[index] != '=') ++index;
            }
            else
            {
                index = tokenLine.IndexOf('=');
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

            if (this.OutputDirectory == null) return;

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

            if (this.GenerateLanguageService)
            {
                Directory.CreateDirectory(Path.Combine(directory, @"Syntax"));
                string outputFileName = Path.Combine(directory, @"Syntax\" + this.LanguageName + "SyntaxFacts.cs");
                using (StreamWriter writer = new StreamWriter(outputFileName))
                {
                    writer.WriteLine(this.GeneratedSyntaxFacts);
                }
                outputFileName = Path.Combine(directory, @"Syntax\" + this.LanguageName + "SyntaxKind.cs");
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

            this.GeneratedSyntaxKind = generator.GenerateSyntaxKind();

            this.GeneratedInternalSyntax = generator.GenerateInternalSyntax();
            this.GeneratedSyntax = generator.GenerateSyntax();
            this.GeneratedSyntaxTree = generator.GenerateSyntaxTree();
            this.GeneratedErrorCode = generator.GenerateErrorCode();
            this.GeneratedSyntaxParser = generator.GenerateSyntaxParser();
            this.GeneratedLanguageVersion = generator.GenerateLanguageVersion();
            this.GeneratedParseOptions = generator.GenerateParseOptions();
            this.GeneratedFeature = generator.GenerateFeature();

            this.GeneratedCompilation = generator.GenerateCompilation();
            this.GeneratedCompilationFactory = generator.GenerateCompilationFactory();
            this.GeneratedCompilationOptions = generator.GenerateCompilationOptions();
            this.GeneratedScriptCompilationInfo = generator.GenerateScriptCompilationInfo();

            this.GeneratedDeclarationTreeBuilder = generator.GenerateDeclarationTreeBuilder();
            this.GeneratedBinderFactoryVisitor = generator.GenerateBinderFactoryVisitor();

            if (this.OutputDirectory == null) return;

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

            if (this.GenerateCompiler)
            {
                Directory.CreateDirectory(Path.Combine(directory, @"Syntax\InternalSyntax"));
                Directory.CreateDirectory(Path.Combine(directory, @"Errors"));
                Directory.CreateDirectory(Path.Combine(directory, @"Parser"));
                Directory.CreateDirectory(Path.Combine(directory, @"Compilation"));
                Directory.CreateDirectory(Path.Combine(directory, @"Binding"));
                string outputFileName = Path.Combine(directory, @"Syntax\InternalSyntax\" + this.LanguageName + "InternalSyntax.cs");
                using (StreamWriter writer = new StreamWriter(outputFileName))
                {
                    writer.WriteLine(this.GeneratedInternalSyntax);
                }
                outputFileName = Path.Combine(directory, @"Syntax\" + this.LanguageName + "SyntaxKind.cs");
                using (StreamWriter writer = new StreamWriter(outputFileName))
                {
                    writer.WriteLine(this.GeneratedSyntaxKind);
                }
                outputFileName = Path.Combine(directory, @"Syntax\" + this.LanguageName + "Syntax.cs");
                using (StreamWriter writer = new StreamWriter(outputFileName))
                {
                    writer.WriteLine(this.GeneratedSyntax);
                }
                outputFileName = Path.Combine(directory, @"Syntax\" + this.LanguageName + "SyntaxTree.cs");
                using (StreamWriter writer = new StreamWriter(outputFileName))
                {
                    writer.WriteLine(this.GeneratedSyntaxTree);
                }
                outputFileName = Path.Combine(directory, @"Errors\" + this.LanguageName + @"ErrorCode.cs");
                using (StreamWriter writer = new StreamWriter(outputFileName))
                {
                    writer.WriteLine(this.GeneratedErrorCode);
                }
                outputFileName = Path.Combine(directory, @"Parser\" + this.LanguageName + @"SyntaxParser.cs");
                using (StreamWriter writer = new StreamWriter(outputFileName))
                {
                    writer.WriteLine(this.GeneratedSyntaxParser);
                }
                outputFileName = Path.Combine(directory, @"Compilation\" + this.LanguageName + @"Language.cs");
                if (!File.Exists(outputFileName))
                {
                    using (StreamWriter writer = new StreamWriter(outputFileName))
                    {
                        writer.WriteLine(this.GeneratedLanguage);
                    }
                }
                outputFileName = Path.Combine(directory, @"Compilation\" + this.LanguageName + @"Compilation.cs");
                using (StreamWriter writer = new StreamWriter(outputFileName))
                {
                    writer.WriteLine(this.GeneratedCompilation);
                }
                outputFileName = Path.Combine(directory, @"Compilation\" + this.LanguageName + @"CompilationFactory.cs");
                using (StreamWriter writer = new StreamWriter(outputFileName))
                {
                    writer.WriteLine(this.GeneratedCompilationFactory);
                }
                outputFileName = Path.Combine(directory, @"Compilation\" + this.LanguageName + @"CompilationOptions.cs");
                using (StreamWriter writer = new StreamWriter(outputFileName))
                {
                    writer.WriteLine(this.GeneratedCompilationOptions);
                }
                outputFileName = Path.Combine(directory, @"Compilation\" + this.LanguageName + @"ScriptCompilationInfo.cs");
                using (StreamWriter writer = new StreamWriter(outputFileName))
                {
                    writer.WriteLine(this.GeneratedScriptCompilationInfo);
                }
                outputFileName = Path.Combine(directory, @"Compilation\" + this.LanguageName + @"LanguageVersion.cs");
                using (StreamWriter writer = new StreamWriter(outputFileName))
                {
                    writer.WriteLine(this.GeneratedLanguageVersion);
                }
                outputFileName = Path.Combine(directory, @"Compilation\" + this.LanguageName + @"ParseOptions.cs");
                using (StreamWriter writer = new StreamWriter(outputFileName))
                {
                    writer.WriteLine(this.GeneratedParseOptions);
                }
                outputFileName = Path.Combine(directory, @"Compilation\" + this.LanguageName + @"Feature.cs");
                using (StreamWriter writer = new StreamWriter(outputFileName))
                {
                    writer.WriteLine(this.GeneratedFeature);
                }
                outputFileName = Path.Combine(directory, @"Binding\" + this.LanguageName + @"DeclarationTreeBuilderVisitor.cs");
                using (StreamWriter writer = new StreamWriter(outputFileName))
                {
                    writer.WriteLine(this.GeneratedDeclarationTreeBuilder);
                }
                outputFileName = Path.Combine(directory, @"Binding\" + this.LanguageName + @"BinderFactoryVisitor.cs");
                using (StreamWriter writer = new StreamWriter(outputFileName))
                {
                    writer.WriteLine(this.GeneratedBinderFactoryVisitor);
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
        private Antlr4Mode currentMode;
        private Antlr4LexerRule currentLexerRule;

        public Antlr4Grammar Grammar { get { return this.currentGrammar; } }
        public bool IsParser { get; private set; }
        public bool IsLexer { get; private set; }
        public bool GenerateCompiler { get; private set; }
        public bool GenerateLanguageService { get; private set; }

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
            if (optionName == "tokenVocab")
            {
                this.lexerName = optionValue;
            }
            return base.VisitOption(context);
        }

        public override object VisitDelegateGrammar([NotNull] Antlr4RoslynParser.DelegateGrammarContext context)
        {
            var identifiers = context.identifier();
            if (identifiers.Length >= 2)
            {
                string import = identifiers[1].GetText();
                this.Grammar.ImportedGrammars.Add(import);
            }
            else if (identifiers.Length >= 1)
            {
                string import = identifiers[0].GetText();
                this.Grammar.ImportedGrammars.Add(import);
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
                        this.compiler.AddDiagnostic(ruleSpec.RULE_REF(), Antlr4RoslynErrorCode.ERR_RuleMapUnnamedAlt, ruleName);
                    }
                }
                if (!reportedError && !handled)
                {
                    this.compiler.AddDiagnostic(ruleSpec.RULE_REF(), Antlr4RoslynErrorCode.ERR_RuleMapTooComplex, ruleName);
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
                this.compiler.AddDiagnostic(context, Antlr4RoslynErrorCode.ERR_BlockUnhandled);
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
                    this.compiler.AddDiagnostic(elements[i].Node, Antlr4RoslynErrorCode.ERR_UnnamedElement, elements[i].Type);
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
                this.compiler.AddDiagnostic(elem.labeledElement().identifier(), Antlr4RoslynErrorCode.ERR_BlockMap);
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
                        this.compiler.AddDiagnostic(blockSuffix, Antlr4RoslynErrorCode.ERR_BlockMapSuffix);
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
                    this.compiler.AddDiagnostic(elem.ebnf().block(), Antlr4RoslynErrorCode.ERR_UnnamedBlock);
                    return 0;
                }
                this.compiler.AddDiagnostic(elem.ebnf().block(), Antlr4RoslynErrorCode.ERR_BlockMap);
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
                        this.compiler.AddDiagnostic(elems[i], Antlr4RoslynErrorCode.ERR_ElementMap);
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
        public bool ContainsDeclarationTreeAnnotations { get; internal set; }
        public bool ContainsAnnotations { get; internal set; }
        public bool HasAnnotations { get; internal set; }
    }
    public class Antlr4Grammar : Antlr4AnnotatedObject
    {
        public Antlr4Grammar()
        {
            this.CustomAnnotations = new List<MetaCompilerAnnotation>();
            this.ImportedGrammars = new HashSet<string>();
            this.ParserRuleElemUses = new HashSet<string>();
            this.ParserRules = new List<Antlr4ParserRule>();
            this.LexerRules = new List<Antlr4LexerRule>();
            this.LexerTokenKinds = new Dictionary<string, List<Antlr4LexerRule>>();
            this.Modes = new List<Antlr4Mode>();
            this.FixedTokenCandidates = new List<Antlr4LexerRule>();
            this.FixedTokens = new List<Antlr4LexerRule>();
            this.FirstRuleKind = 1;
        }
        public string Name { get; set; }
        public List<MetaCompilerAnnotation> CustomAnnotations { get; private set; }
        public HashSet<string> ImportedGrammars { get; private set; }
        public HashSet<string> ParserRuleElemUses { get; private set; }
        public Dictionary<string, List<Antlr4LexerRule>> LexerTokenKinds { get; private set; }
        public int FirstRuleKind { get; set; }
        public List<Antlr4ParserRule> ParserRules { get; private set; }
        public List<Antlr4LexerRule> LexerRules { get; private set; }
        public Antlr4LexerRule DefaultWhitespace { get; set; }
        public Antlr4LexerRule DefaultEndOfLine { get; set; }
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
                if (token.Line == line && token.Column == column) return new LinePositionSpan(new LinePosition(token.Line, token.Column), new LinePosition(token.Line, token.Column+token.StopIndex-token.StartIndex));
            }
            return LinePositionSpan.Zero;
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
