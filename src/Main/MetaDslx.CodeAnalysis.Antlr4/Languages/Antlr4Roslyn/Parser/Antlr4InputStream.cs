using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax
{
    public class Antlr4InputStream : ICharStream, IIntStream
    {
        private readonly SlidingTextWindow _textWindow;                 

        public Antlr4InputStream(SlidingTextWindow textWindow)
        {
            _textWindow = textWindow;
        }

        public int La(int i)
        {
            char pch;
            if (i > 0) pch = _textWindow.PeekChar(i - 1);
            else if (i < 0) pch = _textWindow.PeekChar(i);
            else pch = SlidingTextWindow.InvalidCharacter;
            if (pch == SlidingTextWindow.InvalidCharacter) return IntStreamConstants.Eof;
            else return pch;
        }

        public int Index => _textWindow.Position;
        public int Size => _textWindow.Text.Length;
        public string SourceName => "<unknown>";

        [return: NotNull]
        public string GetText([NotNull] Interval interval)
        {
            var length = interval.Length;
            if (interval.b >= _textWindow.Text.Length) length = _textWindow.Text.Length - interval.a;
            if (length < 0 || interval.a >= _textWindow.Text.Length) return string.Empty;
            return _textWindow.GetText(interval.a, length, false);
        }

        public void Consume()
        {
            _textWindow.NextChar();
        }

        public int Mark()
        {
            return _textWindow.GetResetPoint();
        }

        public void Release(int marker)
        {
            _textWindow.ReleaseResetPoint(marker);
        }

        public void Seek(int index)
        {
            _textWindow.ResetTo(index);
        }
    }
}
