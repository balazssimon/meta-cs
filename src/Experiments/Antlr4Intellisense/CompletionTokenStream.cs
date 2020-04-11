﻿using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace Antlr4Intellisense
{
    /*public class CompletionTokenStream
    {
        internal const int CARET_TOKEN_TYPE = -10;

        private IList<IToken> _tokens;
        private readonly int _index;

        public CompletionTokenStream(IList<IToken> tokens)
        {
            _tokens = tokens;
            _index = 0;
        }

        private CompletionTokenStream(IList<IToken> tokens, int index)
        {
            _tokens = tokens;
            _index = index;
        }

        public int Next
        {
            get
            {
                return _index < _tokens.Count ? _tokens[_index].Type : CARET_TOKEN_TYPE;
            }
        }

        public bool AtCaret => _index >= _tokens.Count;

        public CompletionTokenStream Move()
        {
            if (_index < _tokens.Count) return new CompletionTokenStream(_tokens, _index + 1);
            else return this;
        }
 
    }*/

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
