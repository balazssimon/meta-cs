using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeGeneration
{
    public class CodeBuilder
    {
        private StringBuilder _sb;
        private string _indent;

        public CodeBuilder()
        {
            _sb = new StringBuilder();
            _indent = "";
        }

        public void IncIndent()
        {
            _indent += "    ";
        }

        public void DecIndent()
        {
            if (_indent.Length >= 4) _indent = _indent.Substring(4);
        }

        public void WriteIndent()
        {
            _sb.Append(_indent);
        }

        public void Write(string text)
        {
            _sb.Append(text);
        }

        public void Write(string format, params object[] args)
        {
            _sb.Append(string.Format(format, args));
        }

        public void WriteLine()
        {
            _sb.AppendLine();
        }

        public void WriteLine(string text)
        {
            this.WriteIndent();
            this.Write(text);
            this.WriteLine();
        }

        public void WriteLine(string format, params object[] args)
        {
            this.WriteIndent();
            this.Write(format, args);
            this.WriteLine();
        }

        public override string ToString()
        {
            return _sb.ToString();
        }
    }
}
