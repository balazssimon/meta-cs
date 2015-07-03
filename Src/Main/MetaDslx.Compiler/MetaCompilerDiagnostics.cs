using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler
{
    [Flags]
    public enum Severity
    {
        Error = 1,
        Warning = 2,
        Info = 4,
        All = Error | Warning | Info
    }

    public class DiagnosticMessage : IComparable<DiagnosticMessage>
    {
        public string FileName { get; set; }
        public TextSpan TextSpan { get; set; }
        public string Message { get; set; }
        public Severity Severity { get; set; }
        public bool IsLog { get; set; }

        public int CompareTo(DiagnosticMessage other)
        {
            if (other == this) return 0;
            if (other == null) return 1;
            if (this.FileName == null && other.FileName != null) return -1;
            if (this.FileName != null && other.FileName == null) return 1;
            int cmp;
            if (this.FileName != null && other.FileName != null)
            {
                cmp = this.FileName.CompareTo(other.FileName);
                if (cmp != 0) return cmp;
            }
            cmp = this.TextSpan.CompareTo(other.TextSpan);
            return cmp;
        }

        public override string ToString()
        {
            return string.Format("{0} in '{1}' ({2},{3}): {4}", this.Severity, this.FileName, this.TextSpan.StartLine, this.TextSpan.StartPosition, this.Message);
        }
    }

    public struct TextSpan : IComparable<TextSpan>
    {
        public TextSpan(int startLine, int startPosition, int endLine, int endPosition) 
            : this()
        {
            this.StartLine = startLine;
            this.StartPosition = startPosition;
            this.EndLine = endLine;
            this.EndPosition = endPosition;
        }

        public TextSpan(IToken token)
            : this()
        {
            this.CreateFromToken(token);
        }

        public TextSpan(Antlr4.Runtime.Tree.IParseTree context)
            : this()
        {
            ITerminalNode terminal = context as ITerminalNode;
            if (terminal != null)
            {
                this.CreateFromToken(terminal.Symbol);
            }
            else
            {
                ParserRuleContext prc = context as ParserRuleContext;
                this.CreateFromRule(prc);
            }
        }

        private void CreateFromToken(IToken token)
        {
            if (token == null) return;
            this.StartLine = token.Line;
            this.StartPosition = token.Column + 1;
            string text = token.Text;
            if (!text.Contains('\n'))
            {
                this.EndLine = this.StartLine;
                this.EndPosition = this.StartPosition + token.Text.Length;
            }
            else
            {
                this.EndLine = token.Line + token.Text.Count(c => c == '\n');
                int index = text.LastIndexOf('\n');
                this.EndPosition = text.Length - index;
            }
        }

        private void CreateFromRule(ParserRuleContext rule)
        {
            if (rule == null) return;
            this.StartLine = rule.Start.Line;
            this.StartPosition = rule.Start.Column + 1;
            this.EndLine = rule.Stop.Line;
            this.EndPosition = rule.Stop.Column + rule.Stop.Text.Length + 1;
        }

        public int StartLine { get; private set; }
        public int StartPosition { get; private set; }
        public int EndLine { get; private set; }
        public int EndPosition { get; private set; }

        public int CompareTo(TextSpan other)
        {
            int cmp;
            cmp = this.StartLine.CompareTo(other.StartLine);
            if (cmp != 0) return cmp;
            cmp = this.StartPosition.CompareTo(other.StartPosition);
            if (cmp != 0) return cmp;
            cmp = this.EndLine.CompareTo(other.EndLine);
            if (cmp != 0) return cmp;
            cmp = this.EndPosition.CompareTo(other.EndPosition);
            if (cmp != 0) return cmp;
            return 0;
        }

        public override string ToString()
        {
            return string.Format("({0},{1})", this.StartLine, this.StartPosition);
        }
    }


    public class MetaCompilerDiagnostics
    {
        private List<DiagnosticMessage> messages;

        private bool sorted = false;
        private bool logsIncluded = false;
        private bool hasErrors = false;
        private bool hasWarnings = false;
        private List<DiagnosticMessage> sortedMessages;

        public bool HasErrors()
        {
            return this.hasErrors;
        }

        public bool HasWarnings()
        {
            return this.hasWarnings;
        }

        public IEnumerable<DiagnosticMessage> GetMessages(bool includeLog = false)
        {
            if (!this.sorted || this.logsIncluded != includeLog)
            {
                this.sortedMessages =
                    this.messages.Where(m => !m.IsLog || includeLog).OrderBy(m => m.FileName).ThenBy(m => m.TextSpan).ToList();
                this.logsIncluded = includeLog;
                this.sorted = true;
            }
            return this.sortedMessages;
        }

        public IEnumerable<DiagnosticMessage> GetMessages(Severity severity, bool includeLog = false)
        {
            this.GetMessages(includeLog);
            return this.sortedMessages.Where(m => (m.Severity | severity) == m.Severity && (!m.IsLog || includeLog));
        }

        public MetaCompilerDiagnostics()
        {
            this.messages = new List<DiagnosticMessage>();
        }

        public void AddMessage(Severity severity, string message, string fileName, TextSpan textSpan, bool isLog = false)
        {
            if (severity == Severity.Error)
            {
                this.hasErrors = true;
            }
            if (severity == Severity.Warning)
            {
                this.hasWarnings = true;
            }
            this.messages.Add(
                new DiagnosticMessage()
                {
                    Message = message,
                    FileName = fileName,
                    TextSpan = textSpan,
                    Severity = severity,
                    IsLog = isLog
                });
            this.sorted = false;
        }

        public void AddError(string message, string fileName, TextSpan textSpan, bool isLog = false)
        {
            this.AddMessage(Severity.Error, message, fileName, textSpan, isLog);
        }

        public void AddWarning(string message, string fileName, TextSpan textSpan, bool isLog = false)
        {
            this.AddMessage(Severity.Warning, message, fileName, textSpan, isLog);
        }

        public void AddInfo(string message, string fileName, TextSpan textSpan, bool isLog = false)
        {
            this.AddMessage(Severity.Info, message, fileName, textSpan, isLog);
        }
    }
}
