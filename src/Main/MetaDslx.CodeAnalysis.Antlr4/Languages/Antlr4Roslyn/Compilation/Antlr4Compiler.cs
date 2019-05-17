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
using MetaDslx.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace MetaDslx.Languages.Antlr4Roslyn.Compilation
{
    public abstract class Antlr4Compiler<TLexer, TParser> : IAntlrErrorListener<int>, IAntlrErrorListener<IToken>
        where TLexer: Antlr4.Runtime.Lexer
        where TParser: Antlr4.Runtime.Parser
    {
        private bool compiled;
        private bool generated;
        private ImmutableArray<Diagnostic> diagnostics;

        protected TLexer Lexer { get; private set; }
        protected TParser Parser { get; private set; }
        protected CommonTokenStream CommonTokenStream { get; private set; }
        protected ParserRuleContext ParseTree { get; private set; }
        public string Source { get; private set; }
        public string DefaultNamespace { get; protected set; }
        public string FileName { get; private set; }
        public string InputDirectory { get; private set; }
        public string OutputDirectory { get; protected set; }
        public bool GenerateOutput { get; set; }
        protected DiagnosticBag DiagnosticBag { get; set; }

        public bool HasErrors
        {
            get { return this.DiagnosticBag.HasAnyErrors(); }
        }

        public Antlr4Compiler(string source, string defaultNamespace, string inputDirectory, string outputDirectory, string fileName)
        {
            this.Source = source;
            this.DefaultNamespace = defaultNamespace;
            this.InputDirectory = inputDirectory;
            this.OutputDirectory = outputDirectory;
            this.FileName = fileName;
            this.GenerateOutput = true;
            this.diagnostics = ImmutableArray<Diagnostic>.Empty;
        }

        public ImmutableArray<Diagnostic> GetDiagnostics()
        {
            return this.diagnostics;
        }

        public void Compile()
        {
            if (this.compiled) return;
            else this.compiled = true;
            AntlrInputStream inputStream = new AntlrInputStream(this.Source);
            this.Lexer = this.CreateLexer(inputStream);
            this.CommonTokenStream = new CommonTokenStream(this.Lexer);
            this.Parser = this.CreateParser(this.CommonTokenStream);
            this.Lexer.RemoveErrorListeners();
            this.Parser.RemoveErrorListeners();
            this.Lexer.AddErrorListener(this);
            this.Parser.AddErrorListener(this);
            this.DiagnosticBag = new DiagnosticBag();

            this.ParseTree = this.CreateTree();

            if (this.HasErrors)
            {
                this.diagnostics = this.DiagnosticBag.ToReadOnly();
                return;
            }

            this.DoCompile();

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
        protected abstract ParserRuleContext CreateTree();
        protected abstract void DoCompile();
        protected abstract void DoGenerate();

        private TextSpan GetTextSpan(IToken token)
        {
            if (token == null) return default;
            return new TextSpan(token.StartIndex, token.StopIndex - token.StartIndex + 1);
        }

        private LinePositionSpan GetLinePositionSpan(IToken token)
        {
            if (token == null) return default;
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
            this.DiagnosticBag.Add(code, Location.Create(this.FileName, default, default), args);
        }

        internal void AddDiagnostic(IToken token, Antlr4RoslynErrorCode code, params object[] args)
        {
            this.DiagnosticBag.Add(code, Location.Create(this.FileName, this.GetTextSpan(token), this.GetLinePositionSpan(token)), args);
        }

        internal void AddDiagnostic(ITerminalNode token, Antlr4RoslynErrorCode code, params object[] args)
        {
            this.DiagnosticBag.Add(code, Location.Create(this.FileName, this.GetTextSpan(token.Symbol), this.GetLinePositionSpan(token.Symbol)), args);
        }

        internal void AddDiagnostic(ParserRuleContext rule, Antlr4RoslynErrorCode code, params object[] args)
        {
            this.DiagnosticBag.Add(code, Location.Create(this.FileName, this.GetTextSpan(rule), this.GetLinePositionSpan(rule)), args);
        }

        public void SyntaxError(TextWriter output, IRecognizer recognizer, int offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            IToken token = e.OffendingToken;
            if (token != null)
            {
                this.DiagnosticBag.Add(Antlr4RoslynErrorCode.ERR_SyntaxError, Location.Create(this.FileName, this.GetTextSpan(token), this.GetLinePositionSpan(token)), msg);
            }
            else
            {
                this.DiagnosticBag.Add(Antlr4RoslynErrorCode.ERR_SyntaxError, Location.Create(this.FileName, this.GetTextSpan(recognizer.InputStream.Index), this.GetLinePositionSpan(line, charPositionInLine)), msg);
            }
        }

        public void SyntaxError(TextWriter output, IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            if (offendingSymbol != null)
            {
                this.DiagnosticBag.Add(Antlr4RoslynErrorCode.ERR_SyntaxError, Location.Create(this.FileName, this.GetTextSpan(offendingSymbol), this.GetLinePositionSpan(offendingSymbol)), msg);
            }
            else
            {
                this.DiagnosticBag.Add(Antlr4RoslynErrorCode.ERR_SyntaxError, Location.Create(this.FileName, this.GetTextSpan(recognizer.InputStream.Index), this.GetLinePositionSpan(line, charPositionInLine)), msg);
            }
        }
    }
}
