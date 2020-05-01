using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Syntax.InternalSyntax
{
    internal class IncrementalSyntaxTree
    {
        private readonly IncrementalSyntaxNode _root;
        private readonly int _minLexerLookahead;
        private readonly int _maxLexerLookahead;
#if DEBUG
        private int _version;
#endif

#if DEBUG
        public IncrementalSyntaxTree(IncrementalSyntaxNode root, int minLexerLookahead, int maxLexerLookahead, int version)
#else
        public IncrementalSyntaxTree(IncrementalSyntaxNode root, int minLexerLookahead, int maxLexerLookahead)
#endif
        {
            _root = root;
            _minLexerLookahead = minLexerLookahead;
            _maxLexerLookahead = maxLexerLookahead;
#if DEBUG
            _version = version;
#endif
        }

        public IncrementalSyntaxNode Root => _root;
        public int MinLexerLookahead => _minLexerLookahead;
        public int MaxLexerLookahead => _maxLexerLookahead;
#if DEBUG
        public int Version => _version;
#endif
    }
}
