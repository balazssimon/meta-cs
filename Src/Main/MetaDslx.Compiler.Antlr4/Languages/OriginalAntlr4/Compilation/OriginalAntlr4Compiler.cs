﻿using Antlr4.Runtime;
using MetaDslx.Compiler.Antlr4.Properties;
using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Text;
using MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Languages.Antlr4Roslyn.Compilation
{
    public class OriginalAntlr4Compiler : Antlr4Compiler<Antlr4RoslynLexer, Antlr4RoslynParser>
    {
        public string Antlr4Jar { get; private set; }
        public string CSharpSource { get; private set; }
        public string TokensSource { get; private set; }
        public string VisitorSource { get; private set; }
        public string ListenerSource { get; private set; }
        public string BaseVisitorSource { get; private set; }
        public string BaseListenerSource { get; private set; }

        public bool GenerateCSharpSource { get; set; }

        public bool IsParser { get; private set; }
        public bool IsLexer { get; private set; }
        public List<string> Imports { get; private set; }

        public OriginalAntlr4Compiler(string source, string defaultNamespace, string inputDirectory, string outputDirectory, string fileName)
            : base(source, defaultNamespace, inputDirectory, outputDirectory, fileName)
        {
            this.Imports = new List<string>();
            this.GenerateCSharpSource = true;
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
            ExternalAntlr4Visitor v = new ExternalAntlr4Visitor();
            v.Visit(this.ParseTree);

            this.IsParser = v.IsParser;
            this.IsLexer = v.IsLexer;
            this.Imports.AddRange(v.Imports);

            this.CompileAntlr4();
        }

        private IToken GetTokenAt(int line, int column)
        {
            foreach (var token in this.CommonTokenStream.GetTokens())
            {
                if (token.Line == line && token.Column == column) return token;
            }
            return this.CommonTokenStream.GetTokens().FirstOrDefault();
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
                    File.WriteAllBytes(Antlr4Jar, Resources.antlr_4_7_complete);
                }
                return new FileInfo(Antlr4Jar).Length == Resources.antlr_4_7_complete.Length;
            }
            catch (Exception ex)
            {
                this.AddDiagnostic(Antlr4RoslynErrorCode.ERR_Antlr4LoadError, ex.Message, this.FileName);
                return false;
            }
        }

        private string GetTemporaryDirectory()
        {
            string tempDirectory = Path.Combine(Path.GetTempPath(), Path.GetFileNameWithoutExtension(Path.GetRandomFileName()));
            Directory.CreateDirectory(tempDirectory);
            return tempDirectory;
        }

        private bool ProcessAntlr4ErrorLine(string antlr4Line)
        {
            string line = antlr4Line;
            if (string.IsNullOrWhiteSpace(line)) return true;
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
                            IToken token = this.GetTokenAt(lineIndex, colIndex);
                            this.AddDiagnostic(token, errorCode, line);
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private void CompileAntlr4()
        {
            try
            {
                this.PrepareAntlr4();
                string bareFileName = Path.GetFileNameWithoutExtension(this.FileName);
                string grammarFileName = bareFileName + ".g4";
                string tmpDir = this.GetTemporaryDirectory();
                try
                {
                    foreach (var import in this.Imports)
                    {
                        string importFile = Path.Combine(this.InputDirectory, import);
                        string tmpImportFile = Path.Combine(tmpDir, import);
                        if (File.Exists(importFile))
                        {
                            File.Copy(importFile, tmpImportFile, true);
                        }
                    }
                    string antlr4File = Path.Combine(tmpDir, grammarFileName);
                    File.WriteAllText(antlr4File, this.Source);
                    Process proc = new Process();
                    proc.StartInfo.UseShellExecute = false;
                    proc.StartInfo.RedirectStandardOutput = true;
                    proc.StartInfo.RedirectStandardError = true;
                    proc.StartInfo.CreateNoWindow = true;
                    proc.StartInfo.WorkingDirectory = tmpDir;
                    proc.StartInfo.FileName = "java";
                    if (!string.IsNullOrWhiteSpace(this.DefaultNamespace))
                    {
                        proc.StartInfo.Arguments = "-jar \"" + this.Antlr4Jar + "\" -Dlanguage=CSharp \"" + grammarFileName + "\" -lib . -listener -visitor -package " + this.DefaultNamespace + " -o \"" + tmpDir + "\"";
                    }
                    else
                    {
                        proc.StartInfo.Arguments = "-jar \"" + this.Antlr4Jar + "\" -Dlanguage=CSharp \"" + grammarFileName + "\" -lib . -listener -visitor -o \"" + tmpDir + "\"";
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
                        catch (Exception)
                        {
                            // nop
                        }
                    }
                    if (!proc.StandardError.EndOfStream)
                    {
                        StringBuilder unprocessedLines = new StringBuilder();
                        while (!proc.StandardError.EndOfStream)
                        {
                            string line = proc.StandardError.ReadLine();
                            if (!this.ProcessAntlr4ErrorLine(line))
                            {
                                unprocessedLines.AppendLine(line);
                            }
                        }
                        string unprocessed = unprocessedLines.ToString();
                        if (!string.IsNullOrWhiteSpace(unprocessed))
                        {
                            this.AddDiagnostic(Antlr4RoslynErrorCode.ERR_Antlr4CallError, unprocessed, this.FileName);
                        }
                    }
                    if (terminated && !this.DiagnosticBag.HasAnyErrors())
                    {
                        string tokensFileName = Path.Combine(tmpDir, bareFileName + ".tokens");
                        if (File.Exists(tokensFileName))
                        {
                            this.TokensSource = File.ReadAllText(tokensFileName);
                        }
                        string csFileName = Path.Combine(tmpDir, bareFileName + ".cs");
                        if (File.Exists(csFileName))
                        {
                            this.CSharpSource = File.ReadAllText(csFileName);
                        }
                        if (this.IsParser)
                        {
                            string baseVisitorFileName = Path.Combine(tmpDir, bareFileName + "BaseVisitor.cs");
                            if (File.Exists(baseVisitorFileName))
                            {
                                this.BaseVisitorSource = File.ReadAllText(baseVisitorFileName);
                            }
                            string baseListenerFileName = Path.Combine(tmpDir, bareFileName + "BaseListener.cs");
                            if (File.Exists(baseListenerFileName))
                            {
                                this.BaseListenerSource = File.ReadAllText(baseListenerFileName);
                            }
                            string visitorFileName = Path.Combine(tmpDir, bareFileName + "Visitor.cs");
                            if (File.Exists(visitorFileName))
                            {
                                this.VisitorSource = File.ReadAllText(visitorFileName);
                            }
                            string listenerFileName = Path.Combine(tmpDir, bareFileName + "Listener.cs");
                            if (File.Exists(listenerFileName))
                            {
                                this.ListenerSource = File.ReadAllText(listenerFileName);
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


        protected override void DoGenerate()
        {
            if (this.OutputDirectory != null)
            {
                string bareFileName = Path.GetFileNameWithoutExtension(this.FileName);
                this.WriteToOutput(this.TokensSource, this.OutputDirectory, bareFileName + ".tokens");
                if (this.GenerateCSharpSource)
                {
                    this.WriteToOutput(this.CSharpSource, this.OutputDirectory, bareFileName + ".cs");
                }
                if (this.IsParser)
                {
                    this.WriteToOutput(this.BaseVisitorSource, this.OutputDirectory, bareFileName + "BaseVisitor.cs");
                    this.WriteToOutput(this.BaseListenerSource, this.OutputDirectory, bareFileName + "BaseListener.cs");
                    this.WriteToOutput(this.VisitorSource, this.OutputDirectory, bareFileName + "Visitor.cs");
                    this.WriteToOutput(this.ListenerSource, this.OutputDirectory, bareFileName + "Listener.cs");
                }
            }
        }

        private bool WriteToOutput(string sourceText, string targetDir, string fileName)
        {
            string outputFile = Path.Combine(targetDir, fileName);
            using (StreamWriter writer = new StreamWriter(outputFile))
            {
                writer.WriteLine(sourceText);
            }
            return false;
        }

    }

    internal class ExternalAntlr4Visitor : Antlr4RoslynParserBaseVisitor<object>
    {
        private string parserName;
        private string lexerName;

        public bool IsParser { get; private set; }
        public bool IsLexer { get; private set; }
        public List<string> Imports { get; private set; }

        public ExternalAntlr4Visitor()
        {
            this.Imports = new List<string>();
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
            return base.VisitGrammarSpec(context);
        }

        public override object VisitOption(Antlr4RoslynParser.OptionContext context)
        {
            string optionName = context.identifier().GetText();
            string optionValue = context.optionValue().GetText();
            if (optionName == "tokenVocab")
            {
                this.lexerName = optionValue;
                string import = optionValue;
                this.Imports.Add(import + ".tokens");
            }
            return base.VisitOption(context);
        }

        public override object VisitDelegateGrammar(Antlr4RoslynParser.DelegateGrammarContext context)
        {
            var identifiers = context.identifier();
            if (identifiers.Length >= 2)
            {
                string import = identifiers[1].GetText();
                this.Imports.Add(import + ".g4");
            }
            else if (identifiers.Length >= 1)
            {
                string import = identifiers[0].GetText();
                this.Imports.Add(import + ".g4");
            }
            return base.VisitDelegateGrammar(context);
        }
    }
}
