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
            return _textWindow.GetText(interval.a, interval.Length - 1, false);
        }

        public void Consume()
        {
            _textWindow.NextChar();
        }

        public int Mark()
        {
            // do nothing: SlidingTextWindow does the buffering
            return -1;
        }

        public void Release(int marker)
        {
            // do nothing: SlidingTextWindow does the buffering
        }

        public void Seek(int index)
        {
            _textWindow.Reset(index);
        }
    }
}
