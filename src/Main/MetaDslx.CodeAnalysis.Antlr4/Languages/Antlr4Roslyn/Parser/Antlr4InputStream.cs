using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax
{
    public class Antlr4InputStream : ICharStream, IIntStream
    {
        private readonly Antlr4SyntaxLexer _lexer;
        private readonly SlidingTextWindow _textWindow;                 

        public Antlr4InputStream(Antlr4SyntaxLexer lexer, SlidingTextWindow textWindow)
        {
            _textWindow = textWindow;
            _lexer = lexer;
        }

        public int LA(int i)
        {
            char pch;
            if (i > 0) pch = _textWindow.PeekChar(i - 1);
            else if (i < 0) pch = _textWindow.PeekChar(i);
            else pch = SlidingTextWindow.InvalidCharacter;
            if (pch == SlidingTextWindow.InvalidCharacter) return IntStreamConstants.EOF;
            else return pch;
        }

        public int Index => _textWindow.Position;
        public int Size => _textWindow.SourceText.Length;
        public string SourceName => "<unknown>";

        [return: NotNull]
        public string GetText([NotNull] Interval interval)
        {
            var length = interval.Length;
            if (interval.b >= _textWindow.SourceText.Length) length = _textWindow.SourceText.Length - interval.a;
            if (length < 0 || interval.a >= _textWindow.SourceText.Length) return string.Empty;
            return _textWindow.GetText(interval.a, length, false);
        }

        public void Consume()
        {
            _textWindow.NextChar();
        }

        public int Mark()
        {
            return _lexer.MarkResetPoint();
        }

        public void Release(int marker)
        {
            _lexer.ReleaseResetPoint(marker);
        }

        public void Seek(int index)
        {
            if (!_lexer.Resetting) _textWindow.ResetTo(index);
        }
    }
}
