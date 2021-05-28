using Microsoft.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeGeneration
{
    public sealed class CodeBuilder
    {
        private static readonly ObjectPool<CodeBuilder> s_pool = new ObjectPool<CodeBuilder>(() => new CodeBuilder(), 20);

        private StringBuilder _sb;
        private string _indent;
        private bool _newLine;

        public CodeBuilder()
        {
            _sb = new StringBuilder();
            _indent = "";
            _newLine = true;
        }

        public static CodeBuilder GetInstance()
        {
            return s_pool.Allocate();
        }

        public void Free()
        {
            _sb.Clear();
            s_pool.Free(this);
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
            if (!string.IsNullOrEmpty(_indent)) _newLine = false;
        }

        public void Write(bool value)
        {
            _sb.Append(value);
            _newLine = false;
        }

        public void Write(byte value)
        {
            _sb.Append(value);
            _newLine = false;
        }

        public void Write(sbyte value)
        {
            _sb.Append(value);
            _newLine = false;
        }

        public void Write(short value)
        {
            _sb.Append(value);
            _newLine = false;
        }

        public void Write(int value)
        {
            _sb.Append(value);
            _newLine = false;
        }

        public void Write(long value)
        {
            _sb.Append(value);
            _newLine = false;
        }

        public void Write(ushort value)
        {
            _sb.Append(value);
            _newLine = false;
        }

        public void Write(uint value)
        {
            _sb.Append(value);
            _newLine = false;
        }

        public void Write(ulong value)
        {
            _sb.Append(value);
            _newLine = false;
        }

        public void Write(float value)
        {
            _sb.Append(value);
            _newLine = false;
        }

        public void Write(double value)
        {
            _sb.Append(value);
            _newLine = false;
        }

        public void Write(decimal value)
        {
            _sb.Append(value);
            _newLine = false;
        }

        public void Write(char value)
        {
            _sb.Append(value);
            _newLine = false;
        }

        public void Write(char[] value)
        {
            _sb.Append(value);
            _newLine = false;
        }

        public void Write(ReadOnlySpan<char> value)
        {
            _sb.Append(value.ToString());
            _newLine = false;
        }

        public void Write(object obj)
        {
            if (obj == null) return;
            else Write(obj.ToString());
        }

        public void Write(string text)
        {
            _sb.Append(text);
            if (!string.IsNullOrEmpty(text)) _newLine = false;
        }

        public void Write(string format, params object[] args)
        {
            Write(string.Format(format, args));
        }

        public void WriteLine()
        {
            _sb.AppendLine();
            _newLine = true;
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

        public void AppendLine(bool force = false)
        {
            if (force || !_newLine)
            {
                _sb.AppendLine();
                _newLine = true;
            }
        }

        public override string ToString()
        {
            return _sb.ToString();
        }

        public string ToStringAndFree()
        {
            var result = _sb.ToString();
            this.Free();
            return result;
        }
    }
}
