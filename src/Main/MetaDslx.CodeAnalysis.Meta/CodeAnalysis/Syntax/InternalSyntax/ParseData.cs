using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace MetaDslx.CodeAnalysis.Syntax.InternalSyntax
{
    public sealed class ParseData
    {
        public static readonly ParseData Empty = new ParseData(0, null, null, DirectiveStack.Empty, 0, 0, null);

        private int _version;
        private LexerStateManager? _lexerStateManager;
        private ParserStateManager? _parserStateManager;
        private DirectiveStack _directives;
        private int _minLexerLookahead;
        private int _maxLexerLookahead;
        private ConditionalWeakTable<GreenNode, IncrementalNodeData>? _incrementalData;

        internal ParseData(int version, LexerStateManager? lexerStateManager, ParserStateManager? parserStateManager, DirectiveStack directives, int minLexerLookahead, int maxLexerLookahead, ConditionalWeakTable<GreenNode, IncrementalNodeData>? incrementalData)
        {
            _version = version;
            _lexerStateManager = lexerStateManager;
            _parserStateManager = parserStateManager;
            _directives = directives;
            _minLexerLookahead = minLexerLookahead;
            _maxLexerLookahead = maxLexerLookahead;
            _incrementalData = incrementalData;
        }


        public bool IsIncremental => _version > 0;

        public int Version => _version;

        public DirectiveStack Directives => _directives;

        public int MinLexerLookahead => _minLexerLookahead;

        public int MaxLexerLookahead => _maxLexerLookahead;

        public LexerStateManager? LexerStateManager => _lexerStateManager;

        public ParserStateManager? ParserStateManager => _parserStateManager;

        internal ConditionalWeakTable<GreenNode, IncrementalNodeData>? IncrementalData => _incrementalData;

        public ParseData WithDirectives(DirectiveStack directives)
        {
            return new ParseData(this.Version, _lexerStateManager, _parserStateManager, directives, _minLexerLookahead, _maxLexerLookahead, _incrementalData);
        }

        public bool TryGetIncrementalData(GreenNode green, out IncrementalNodeData? data)
        {
            if (_incrementalData == null)
            {
                data = null;
                return false;
            }
            return _incrementalData.TryGetValue(green, out data);
        }

    }
}
