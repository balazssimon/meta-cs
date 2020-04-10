using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace Antlr4Intellisense
{
    public class CompletionTokenStream
    {
        internal const int CARET_TOKEN_TYPE = -10;

        private IList<IToken> _tokens;
        private readonly int _index;
        private readonly int _position;

        public CompletionTokenStream(IList<IToken> tokens)
        {
            _tokens = tokens;
            _index = 0;
            _position = 0;
        }

        private CompletionTokenStream(IList<IToken> tokens, int index, int position)
        {
            _tokens = tokens;
            _index = index;
            _position = position;
        }

        public int Next
        {
            get
            {
                return _index < _tokens.Count ? _tokens[_index].Type : CARET_TOKEN_TYPE;
                /*if (_index < _tokens.Count)
                {
                    var token = _tokens[_index];
                    return token.Text[_position - token.StartIndex];
                }
                else return -1;*/
            }
        }

        public bool AtCaret => _index >= _tokens.Count;

        public CompletionTokenStream Move()
        {
            /*if (_index < _tokens.Count)
            {
                var token = _tokens[_index];
                if (_position < token.StopIndex)
                {
                    return new CompletionTokenStream(_tokens, _index, _position + 1);
                }
                else
                {
                    var index = _index + 1;
                    while (index < _tokens.Count && _tokens[index].StopIndex <= _tokens[index].StartIndex) ++index;
                    return new CompletionTokenStream(_tokens, index, _position + 1);
                }
            }*/
            if (_index < _tokens.Count) return new CompletionTokenStream(_tokens, _index + 1, 0);
            else return this;
        }
    }
}
