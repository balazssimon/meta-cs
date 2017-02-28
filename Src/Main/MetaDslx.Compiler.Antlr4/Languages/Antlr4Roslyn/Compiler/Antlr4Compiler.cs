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
using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Text;

namespace MetaDslx.Languages.Antlr4Roslyn.Compiler
{
    public abstract class Antlr4Compiler<TLexer, TParser> : IAntlrErrorListener<int>, IAntlrErrorListener<IToken>
        where TLexer: Lexer
        where TParser: Parser
    {
        private bool compiled;
        private bool generated;

        protected TLexer Lexer { get; private set; }
        protected TParser Parser { get; private set; }
        protected CommonTokenStream CommonTokenStream { get; private set; }
        protected ParserRuleContext ParseTree { get; private set; }
        public string Source { get; private set; }
        public string DefaultNamespace { get; private set; }
        public string FileName { get; private set; }
        public string InputDirectory { get; private set; }
        public string OutputDirectory { get; private set; }
        public bool GenerateOutput { get; set; }
        protected DiagnosticBag DiagnosticBag { get; private set; }
        public ImmutableArray<Diagnostic> Diagnostics { get; private set; }

        public Antlr4Compiler(string source, string defaultNamespace, string inputDirectory, string outputDirectory, string fileName)
        {
            this.Source = source;
            this.DefaultNamespace = defaultNamespace;
            this.InputDirectory = inputDirectory;
            this.OutputDirectory = outputDirectory;
            this.FileName = fileName;
            this.GenerateOutput = true;
        }

        public void Compile()
        {
            if (this.compiled) return;
            this.compiled = true;
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

            this.DoCompile();

            if (this.GenerateOutput) this.Generate();

            this.Diagnostics = this.DiagnosticBag.ToReadOnlyAndFree();
        }

        public void Generate()
        {
            if (this.generated) return;
            this.generated = true;
            if (!this.compiled)
            {
                this.Compile();
            }
            if (this.DiagnosticBag.HasAnyErrors()) return;
            this.DoGenerate();
        }

        protected abstract TLexer CreateLexer(AntlrInputStream stream);
        protected abstract TParser CreateParser(CommonTokenStream stream);
        protected abstract ParserRuleContext CreateTree();
        protected abstract void DoCompile();
        protected abstract void DoGenerate();

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
                this.DiagnosticBag.Add(Location.Create(this.FileName, this.GetTextSpan(token), this.GetLinePositionSpan(token)), Antlr4RoslynErrorCode.ERR_SyntaxError, msg);
            }
            else
            {
                this.DiagnosticBag.Add(Location.Create(this.FileName, this.GetTextSpan(recognizer.InputStream.Index), this.GetLinePositionSpan(line, charPositionInLine)), Antlr4RoslynErrorCode.ERR_SyntaxError, msg);
            }
        }

        public void SyntaxError(IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            if (offendingSymbol != null)
            {
                this.DiagnosticBag.Add(Location.Create(this.FileName, this.GetTextSpan(offendingSymbol), this.GetLinePositionSpan(offendingSymbol)), Antlr4RoslynErrorCode.ERR_SyntaxError, msg);
            }
            else
            {
                this.DiagnosticBag.Add(Location.Create(this.FileName, this.GetTextSpan(recognizer.InputStream.Index), this.GetLinePositionSpan(line, charPositionInLine)), Antlr4RoslynErrorCode.ERR_SyntaxError, msg);
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
            this.DiagnosticBag.Add(Location.Create(this.FileName, TextSpan.Default, LinePositionSpan.Zero), code, args);
        }

        internal void AddDiagnostic(LinePositionSpan position, Antlr4RoslynErrorCode code, params object[] args)
        {
            this.DiagnosticBag.Add(Location.Create(this.FileName, TextSpan.Default, position), code, args);
        }

        internal void AddDiagnostic(ITerminalNode token, Antlr4RoslynErrorCode code, params object[] args)
        {
            this.DiagnosticBag.Add(Location.Create(this.FileName, this.GetTextSpan(token.Symbol), this.GetLinePositionSpan(token.Symbol)), code, args);
        }

        internal void AddDiagnostic(ParserRuleContext rule, Antlr4RoslynErrorCode code, params object[] args)
        {
            this.DiagnosticBag.Add(Location.Create(this.FileName, this.GetTextSpan(rule), this.GetLinePositionSpan(rule)), code, args);
        }
    }
}
