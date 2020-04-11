using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.VisualStudio.Intellisense
{
    internal class CompletionTokenStream
    {
        private IList<IToken> _tokens;
        private readonly int _index;
        private readonly int _position;

        public CompletionTokenStream(IList<IToken> tokens, int position)
        {
            _tokens = tokens;
            _index = 0;
            _position = position;
        }

        private CompletionTokenStream(IList<IToken> tokens, int index, int position)
        {
            _tokens = tokens;
            _index = index;
            _position = position;
        }

        public IToken Next
        {
            get
            {
                return _index < _tokens.Count && _tokens[_index].StartIndex < _position ? _tokens[_index] : null;
            }
        }

        public bool AtCaret => _index >= _tokens.Count || _tokens[_index].StartIndex >= _position;

        public CompletionTokenStream Move()
        {
            if (_index < _tokens.Count && _tokens[_index].StartIndex < _position) return new CompletionTokenStream(_tokens, _index + 1, _position);
            else return this;
        }
    }
}
