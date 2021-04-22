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
using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Microsoft.CodeAnalysis.PooledObjects;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.CodeGeneration;

namespace MetaDslx.Languages.Antlr4Roslyn.Compilation
{
    public abstract class Antlr4Compiler<TLexer, TParser> : CodeGenerator, ICompilerForBuildTask, IAntlrErrorListener<int>, IAntlrErrorListener<IToken>
        where TLexer: Antlr4.Runtime.Lexer
        where TParser: Antlr4.Runtime.Parser
    {
        private bool compiled;
        private bool generated;
        private ImmutableArray<Diagnostic> diagnostics;
        private ArrayBuilder<string> generatedFileList;

        protected TLexer Lexer { get; private set; }
        protected TParser Parser { get; private set; }
        protected CommonTokenStream CommonTokenStream { get; private set; }
        protected ParserRuleContext ParseTree { get; private set; }
        public string Source { get; private set; }
        public string DefaultNamespace { get; protected set; }
        public string FileName { get; private set; }
        public string InputDirectory { get; private set; }
        public string InputFilePath { get; private set; }
        public bool GenerateOutput { get; set; }
        protected DiagnosticBag DiagnosticBag { get; set; }

        public bool HasErrors
        {
            get { return this.DiagnosticBag?.HasAnyErrors() ?? false; }
        }

        public Antlr4Compiler(string manualOutputDirectory, string automaticOutputDirectory, string inputFilePath, string defaultNamespace = null)
            : base(manualOutputDirectory, automaticOutputDirectory)
        {
            this.InputFilePath = inputFilePath;
            this.Source = File.ReadAllText(inputFilePath);
            this.DefaultNamespace = defaultNamespace;
            this.InputDirectory = Path.GetDirectoryName(inputFilePath);
            this.FileName = Path.GetFileName(inputFilePath);
            this.GenerateOutput = true;
            this.diagnostics = ImmutableArray<Diagnostic>.Empty;
            this.generatedFileList = new ArrayBuilder<string>();
        }

        public ImmutableArray<Diagnostic> GetDiagnostics()
        {
            return this.diagnostics;
        }

        protected virtual void InitLexer()
        {
            if (this.Lexer != null) return;
            AntlrInputStream inputStream = new AntlrInputStream(this.Source);
            this.Lexer = this.CreateLexer(inputStream);
            this.CommonTokenStream = new CommonTokenStream(this.Lexer);
            this.Lexer.RemoveErrorListeners();
            this.Lexer.AddErrorListener(this);
        }

        protected virtual void InitParser()
        {
            if (this.Lexer == null) this.InitLexer();
            if (this.Parser != null) return;
            this.Parser = this.CreateParser(this.CommonTokenStream);
            this.Parser.RemoveErrorListeners();
            this.Parser.AddErrorListener(this);
        }

        protected virtual void InitDiagnostics()
        {
            if (this.DiagnosticBag != null) return;
            this.DiagnosticBag = new DiagnosticBag();
        }

        protected virtual void InitSyntaxTree()
        {
            if (this.ParseTree != null) return;
            this.InitDiagnostics();
            this.InitParser();
            this.ParseTree = this.DoCreateTree();
        }

        public void Compile()
        {
            if (this.compiled) return;
            else this.compiled = true;
            this.InitSyntaxTree();

            if (this.HasErrors)
            {
                this.diagnostics = this.DiagnosticBag.ToReadOnly();
                return;
            }

            this.DoCompile();

            if (this.HasErrors)
            {
                this.diagnostics = this.DiagnosticBag.ToReadOnly();
                return;
            }

            if (this.GenerateOutput) this.Generate();

            this.diagnostics = this.DiagnosticBag.ToReadOnly();
        }

        public void Generate()
        {
            if (!this.compiled)
            {
                this.Compile();
            }
            if (!this.GenerateOutput) return;
            if (this.generated) return;
            else this.generated = true;
            if (this.HasErrors) return;
            this.DoGenerate();
        }

        protected abstract TLexer CreateLexer(AntlrInputStream stream);
        protected abstract TParser CreateParser(CommonTokenStream stream);
        protected abstract ParserRuleContext DoCreateTree();
        protected abstract void DoCompile();
        protected abstract void DoGenerate();

        private TextSpan GetTextSpan(int position)
        {
            return new TextSpan(position, 0);
        }

        private LinePositionSpan GetLinePositionSpan(int line, int charPositionInLine)
        {
            return new LinePositionSpan(new LinePosition(line, charPositionInLine), new LinePosition(line, charPositionInLine));
        }

        protected IToken FindToken(int position)
        {
            if (position < 0) return null;
            var stream = this.CommonTokenStream;
            int start = 0;
            int end = stream.Size - 1;
            while (start <= end)
            {
                int index = (start + end) / 2;
                IToken token = stream.Get(index);
                if (token == null) return null;
                if (token.StartIndex >= position && position <= token.StopIndex) return token;
                else if (position < token.StartIndex) end = index - 1;
                else start = index + 1;
            }
            return null;
        }

        protected IToken FindToken(int line, int column)
        {
            if (line < 0 || column < 0) return null;
            var stream = this.CommonTokenStream;
            int start = 0;
            int end = stream.Size - 1;
            while (start <= end)
            {
                int index = (start + end) / 2;
                IToken token = stream.Get(index);
                if (token == null) return null;
                if (token.Line == line && column >= token.Column && column <= token.Column + token.StopIndex - token.StartIndex) return token;
                else if (line < token.Line) end = index - 1;
                else if (line == token.Line && column < token.Column) end = index - 1;
                else start = index + 1;
            }
            return null;
        }

        protected void AddDiagnostic(Antlr4Tool.Antlr4Message diagnostic, string originalAG4FilePath)
        {
            Antlr4RoslynErrorCode errorCode;
            switch (diagnostic.Severity)
            {
                case DiagnosticSeverity.Error:
                    errorCode = Antlr4RoslynErrorCode.ERR_Antlr4Error;
                    break;
                case DiagnosticSeverity.Warning:
                    errorCode = Antlr4RoslynErrorCode.WRN_Antlr4Warning;
                    break;
                default:
                case DiagnosticSeverity.Info:
                case DiagnosticSeverity.Hidden:
                    errorCode = Antlr4RoslynErrorCode.INF_Antlr4Info;
                    break;
            }
            IToken token = this.FindToken(diagnostic.Line, diagnostic.Column);
            if (diagnostic.ErrorCode > 0 && token != null)
            {
                this.DiagnosticBag.Add(errorCode, Location.Create(originalAG4FilePath ?? string.Empty, token.GetTextSpan(), token.GetLinePositionSpan()), diagnostic.Message);
            }
            else
            {
                this.DiagnosticBag.Add(errorCode, Location.Create(originalAG4FilePath ?? string.Empty, new TextSpan(0, 1), new LinePositionSpan(new LinePosition(0, 0), new LinePosition(0, 1))), diagnostic.Message);
            }
        }

        internal void AddDiagnostic(object node, Antlr4RoslynErrorCode code, params object[] args)
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
                this.AddDiagnostic(code, args);
            }
        }

        internal void AddDiagnostic(Antlr4RoslynErrorCode code, params object[] args)
        {
            this.DiagnosticBag.Add(code, Location.Create(this.InputFilePath, default, default), args);
        }

        internal void AddDiagnostic(IToken token, Antlr4RoslynErrorCode code, params object[] args)
        {
            this.DiagnosticBag.Add(code, Location.Create(this.InputFilePath, token.GetTextSpan(), token.GetLinePositionSpan()), args);
        }

        internal void AddDiagnostic(ITerminalNode token, Antlr4RoslynErrorCode code, params object[] args)
        {
            this.DiagnosticBag.Add(code, Location.Create(this.InputFilePath, token.Symbol.GetTextSpan(), token.Symbol.GetLinePositionSpan()), args);
        }

        internal void AddDiagnostic(ParserRuleContext rule, Antlr4RoslynErrorCode code, params object[] args)
        {
            this.DiagnosticBag.Add(code, Location.Create(this.InputFilePath, rule.GetTextSpan(), rule.GetLinePositionSpan()), args);
        }

        public void SyntaxError(TextWriter output, IRecognizer recognizer, int offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            IToken token = e.OffendingToken;
            if (token != null)
            {
                this.DiagnosticBag.Add(Antlr4RoslynErrorCode.ERR_SyntaxError, Location.Create(this.InputFilePath, token.GetTextSpan(), token.GetLinePositionSpan()), msg);
            }
            else
            {
                this.DiagnosticBag.Add(Antlr4RoslynErrorCode.ERR_SyntaxError, Location.Create(this.InputFilePath, this.GetTextSpan(recognizer.InputStream.Index), this.GetLinePositionSpan(line, charPositionInLine)), msg);
            }
        }

        public void SyntaxError(TextWriter output, IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            if (offendingSymbol != null)
            {
                this.DiagnosticBag.Add(Antlr4RoslynErrorCode.ERR_SyntaxError, Location.Create(this.InputFilePath, offendingSymbol.GetTextSpan(), offendingSymbol.GetLinePositionSpan()), msg);
            }
            else
            {
                this.DiagnosticBag.Add(Antlr4RoslynErrorCode.ERR_SyntaxError, Location.Create(this.InputFilePath, this.GetTextSpan(recognizer.InputStream.Index), this.GetLinePositionSpan(line, charPositionInLine)), msg);
            }
        }
    }
}
