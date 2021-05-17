using MetaDslx.CodeAnalysis.InternalUtilities;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using Microsoft.CodeAnalysis.Syntax.InternalSyntax;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Syntax.InternalSyntax
{
    public abstract partial class SyntaxParser : AbstractParser
    {
        internal protected readonly SyntaxLexer Lexer;
        public readonly bool IsIncremental;
        protected readonly CancellationToken CancellationToken;

        private LanguageSyntaxNode? _oldRoot;
        private BlendedNode _currentNode;
        private InternalSyntaxToken _currentToken;
        private GreenNode _prevTokenTrailingTrivia;
        private int _resetCount;
        private int _position;
        private SyntaxListBuilder _skippedTokens;
        private ParseData? _oldParseData;
        private ParseData? _parseData;
        private ConditionalWeakTable<GreenNode, IncrementalNodeData>? _incrementalData;

        private SlidingBuffer<(InternalSyntaxToken Token, object CustomToken)> _lexedTokens;
        private SlidingBuffer<BlendedNode> _blendedTokens;

        private int _version;
        private Stack<(int minTokenLookahead, int maxTokenLookahead, int minLookahead, int maxLookahead, int position, LexerState? lexerState, ParserState? state)> _incrementalStateStack = new Stack<(int minTokenLookahead, int maxTokenLookahead, int minLookahead, int maxLookahead, int position, LexerState? lexerState, ParserState? state)>();
        private int _minTokenLookahead;
        private int _maxTokenLookahead;
        private int _minLookahead;
        private int _maxLookahead;

        protected SyntaxParser(
            Language language,
            SourceText text,
            LanguageParseOptions options,
            LanguageSyntaxNode? oldTree,
            ParseData? oldParseData,
            IEnumerable<TextChangeRange>? changes,
            CancellationToken cancellationToken = default)
            : base(language)
        {
            Lexer = language.InternalSyntaxFactory.CreateLexer(text, options);
            IsIncremental = options.Incremental || oldTree != null && changes != null && oldParseData != null && oldParseData.IsIncremental;
            CancellationToken = cancellationToken;
            _currentNode = default;
            _position = 0;
            _skippedTokens = SyntaxListBuilder.Create();

            if (IsIncremental)
            {
                _blendedTokens = new SlidingBuffer<BlendedNode>(this, new BlendedNode(null, null, null, new Blender(this, oldTree, oldParseData, changes)));
                _oldRoot = oldTree;
                _version = oldParseData != null ? oldParseData.Version + 1 : 1;
                _incrementalData = new ConditionalWeakTable<GreenNode, IncrementalNodeData>();
            }
            else
            {
                _lexedTokens = new SlidingBuffer<(InternalSyntaxToken Token, object CustomToken)>(this, default);
                _version = 0;
            }
        }


        public abstract LanguageSyntaxNode Parse();

        protected SourceText SourceText => Lexer.SourceText;

        public bool IsScript => Options != null && Options.Kind == SourceCodeKind.Script;

        public ParseData? ParseData => _parseData;

        public LanguageSyntaxNode OldRoot => _oldRoot;

        public int LexerPosition => Lexer.Position;

        public LanguageParseOptions Options => Lexer.Options;

        public int Position => _position;

        public ParserState? State
        {
            get
            {
                StateManager?.InternalChanged();
                return StateManager?.State;
            }
        }

        protected virtual ParserStateManager? StateManager => null;

        protected override int TokenIndex => _blendedTokens != null ? _blendedTokens.Index : _lexedTokens.Index;
        protected override int TokenCount => _blendedTokens != null ? _blendedTokens.Count : _lexedTokens.Count;
        protected InternalSyntaxToken LastCreatedToken => _blendedTokens != null ? _blendedTokens.LastCreatedItem.Token : _lexedTokens.LastCreatedItem.Token;
        internal protected int SkippedTokenCount => _skippedTokens.Count;
        protected override GreenNode PrevTokenTrailingTrivia => _prevTokenTrailingTrivia;

        public override void Dispose()
        {
            var blendedTokens = _blendedTokens;
            if (blendedTokens != null)
            {
                _blendedTokens = null;
                blendedTokens.Dispose();
            }
            else
            {
                var lexedTokens = _lexedTokens;
                if (lexedTokens != null)
                {
                    _lexedTokens = null;
                    lexedTokens.Dispose();
                }
            }
            base.Dispose();
        }

        protected void BeginRoot()
        {

        }

        protected void EndRoot(ref GreenNode root)
        {
            var directives = ((InternalSyntaxNode)root).ApplyDirectives(DirectiveStack.Empty);
            if (IsIncremental)
            {
                var minLookahead = Math.Min(Lexer.MinLookahead, _oldParseData?.MinLexerLookahead ?? int.MaxValue);
                var maxLookahead = Math.Max(Lexer.MaxLookahead, _oldParseData?.MaxLexerLookahead ?? int.MinValue);
                _parseData = new ParseData(_version, directives, minLookahead, maxLookahead, _incrementalData);
            }
            else
            {
                _parseData = new ParseData(0, directives, 0, 0, null);
            }
        }

        protected void BeginNode()
        {
            if (IsIncremental)
            {
                _minTokenLookahead = int.MaxValue;
                _maxTokenLookahead = int.MinValue;
                _minLookahead = _position;
                _maxLookahead = _position;
                _incrementalStateStack.Push((_minTokenLookahead, _maxTokenLookahead, _minLookahead, _maxLookahead, _position, this.Lexer.State, this.State));
            }
        }

        protected void EndNode(ref GreenNode green)
        {
            var state = this.State;
            var lexerState = this.Lexer.State;
            if (IsIncremental)
            {
                var incrementalState = _incrementalStateStack.Pop();
                var minTokenLookahead = Math.Min(incrementalState.minTokenLookahead, _minTokenLookahead);
                var maxTokenLookahead = Math.Max(incrementalState.maxTokenLookahead, _maxTokenLookahead);
                var minLookahead = Math.Min(incrementalState.minLookahead, _minLookahead);
                var maxLookahead = Math.Max(incrementalState.maxLookahead, _maxLookahead);

                if (green != null)
                {
                    var lookaheadBefore = minLookahead - incrementalState.position;
                    var lookaheadAfter = maxLookahead - incrementalState.position - green.FullWidth;
                    var exists = _incrementalData.TryGetValue(green, out var existingData);
                    if (exists && !existingData.Equals(incrementalState.lexerState, lexerState, incrementalState.state, state, minTokenLookahead, maxTokenLookahead, lookaheadBefore, lookaheadAfter))
                    {
                        green = ((InternalSyntaxNode)green).Clone();
                        exists = false;
                    }
                    if (!exists)
                    {
#if DEBUG
                        var data = new IncrementalNodeData(incrementalState.lexerState, lexerState, incrementalState.state, state, minTokenLookahead, maxTokenLookahead, lookaheadBefore, lookaheadAfter, _version);
#else
                        var data = new IncrementalNodeData(incrementalState.state, state, minTokenLookahead, maxTokenLookahead, lookaheadBefore, lookaheadAfter);
#endif
                        _incrementalData.Add(green, data);
                    }
                }
                if (_incrementalStateStack.Count > 0)
                {
                    var parentState = _incrementalStateStack.Pop();
                    _minLookahead = Math.Min(minLookahead, parentState.minLookahead);
                    _maxLookahead = Math.Max(maxLookahead, parentState.maxLookahead);
                    _incrementalStateStack.Push((_minTokenLookahead, _maxTokenLookahead, _minLookahead, _maxLookahead, parentState.position, parentState.lexerState, parentState.state));
                }
            }
        }

        protected void RestoreParserState(ParserState? state)
        {
            StateManager?.InternalRestoreState(state);
        }

        protected ResetPoint GetResetPoint()
        {
            var index = TokenIndex;
            if (_resetCount == 0)
            {
                if (_blendedTokens != null) _blendedTokens.MarkResetPoint();
                else _lexedTokens.MarkResetPoint();
            }
            _resetCount++;
            return new ResetPoint(_resetCount, this.State, index, _position, _skippedTokens.ToArray(), _prevTokenTrailingTrivia);
        }

        protected void Reset(ref ResetPoint point)
        {
            _position = point.Position;
            _prevTokenTrailingTrivia = point.PrevTokenTrailingTrivia;
            _skippedTokens.Clear();
            _skippedTokens.AddRange(point.SkippedTokens);
            if (_blendedTokens != null)
            {
                _blendedTokens.ResetTo(point.Index);
                RestoreParserState(point.State);
                _currentToken = default;
                _currentNode = default;
            }
            else
            {
                _lexedTokens.ResetTo(point.Index);
                _currentToken = default;
            }
        }

        protected void Release(ref ResetPoint point)
        {
            Debug.Assert(_resetCount == point.ResetCount);
            _resetCount--;
        }

        protected LanguageSyntaxNode CurrentNode
        {
            get
            {
                // we will fail anyways. Assert is just to catch that earlier.
                Debug.Assert(_blendedTokens != null);

                //PERF: currentNode is a BlendedNode, which is a fairly large struct.
                // the following code tries not to pull the whole struct into a local
                // we only need .Node
                var node = _currentNode.Node;
                if (node != null)
                {
                    return node;
                }

                this.ReadCurrentNode();
                return _currentNode.Node;
            }
        }

        protected SyntaxKind CurrentNodeKind
        {
            get
            {
                var cn = this.CurrentNode;
                return cn != null ? cn.GetKind() : SyntaxKind.None;
            }
        }

        private void ReadCurrentNode()
        {
            _currentNode = _blendedTokens.PreviousItem.Blender.ReadNode();
        }

        protected GreenNode EatNode()
        {
            // we will fail anyways. Assert is just to catch that earlier.
            Debug.Assert(_blendedTokens != null);

            // remember result
            var result = CurrentNode.Green;
            var currentNode = _currentNode;

            if (this.TryGetIncrementalData(currentNode.Node.Green, out var incrementalData) && incrementalData != null)
            {
                _minTokenLookahead = Math.Min(_minTokenLookahead, incrementalData.LookaheadTokensBefore);
                _maxTokenLookahead = Math.Max(_maxTokenLookahead, incrementalData.LookaheadTokensAfter);
                _minLookahead = Math.Min(_minLookahead, _position + incrementalData.LookaheadBefore);
                _maxLookahead = Math.Max(_maxLookahead, _position + currentNode.Node.FullWidth + incrementalData.LookaheadAfter);
            }

            _blendedTokens.InsertItem(currentNode);
            _skippedTokens.Clear();
            MoveToNextToken();

            // erase current state
            RestoreParserState(currentNode.Blender.ParserState);
            EraseState();

            // TODO:MetaDslx: correct Peek before this position

            return result;
        }

        internal bool TryGetIncrementalData(GreenNode green, out IncrementalNodeData? data)
        {
            data = null;
            return (_incrementalData != null && _incrementalData.TryGetValue(green, out data) ||
                _oldParseData != null && _oldParseData.TryGetIncrementalData(green, out data)) &&
                data != null;
        }

        protected void EraseState()
        {
            _currentNode = default;
            _currentToken = default;
            if (_blendedTokens != null) _blendedTokens.ForgetFollowingItems();
            else _lexedTokens.ForgetFollowingItems();
        }

        protected override InternalSyntaxToken CurrentToken
        {
            get
            {
                return _currentToken ?? (_currentToken = this.FetchCurrentToken());
            }
        }

        private InternalSyntaxToken FetchCurrentToken()
        {
            if (_blendedTokens != null)
            {
                return _blendedTokens.GetCurrentItem().Token;
            }
            else
            {
                return _lexedTokens.GetCurrentItem().Token;
            }
        }

        protected virtual bool ReadNewToken()
        {
            if (_blendedTokens != null)
            {
                if (_currentNode.Token != null && _blendedTokens.Index == _blendedTokens.Count)
                {
                    _blendedTokens.AddItem(_currentNode);
                    return true;
                }
                else
                {
                    var token = _blendedTokens.LastCreatedItem.Blender.ReadToken();
                    if (token.Token == null) return false;
                    if (token.Token.Kind == SyntaxKind.Eof)
                    {
                        if (_blendedTokens.LastCreatedItem.Token == null || _blendedTokens.LastCreatedItem.Token.Kind != SyntaxKind.Eof)
                        {
                            _blendedTokens.AddItem(token);
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    _blendedTokens.AddItem(token);
                    return true;
                }
            }
            else
            {
                var token = Lexer.Lex();
                if (token == null) return false;
                _lexedTokens.AddItem((token, CreateCustomTokenCore(token, _position)));
                return true;
            }
        }

        protected void RegisterLookahead(int n)
        {
            var skippedTokenCount = _skippedTokens.Count;
            int lookaheadCount = skippedTokenCount + n + 1;

            if (lookaheadCount < _minTokenLookahead)
            {
                if (_minTokenLookahead > 0)
                {
                    _minLookahead = _position;
                    _minTokenLookahead = 0;
                }
                for (int i = lookaheadCount; i < _minTokenLookahead; i++)
                {
                    var peekToken = _blendedTokens.PeekItem(i - skippedTokenCount).Token;
                    if (peekToken != null) _minLookahead -= peekToken.FullWidth;
                }
                _minTokenLookahead = lookaheadCount;
            }
            else if (lookaheadCount > _maxTokenLookahead)
            {
                if (_maxTokenLookahead < 0)
                {
                    _maxLookahead = _position;
                    if (CurrentToken != null) _maxLookahead += CurrentToken.FullWidth;
                    _maxTokenLookahead = 0;
                }
                for (int i = lookaheadCount; i > _maxTokenLookahead; i--)
                {
                    var peekToken = _blendedTokens.PeekItem(i - skippedTokenCount).Token;
                    if (peekToken != null) _maxLookahead += peekToken.FullWidth;
                }
                _maxTokenLookahead = lookaheadCount;
            }
        }

        protected InternalSyntaxToken PeekToken(int n)
        {
            if (_blendedTokens != null)
            {
#if DEBUG
                if (n < 0)
                {
                    for (int i = 0; i >= n; i--)
                    {
                        var index = _blendedTokens.Index + i;
                        if (index >= _blendedTokens.FirstIndex && index < _blendedTokens.FirstIndex + _blendedTokens.Count)
                        {
                            Debug.Assert(_blendedTokens[index].Token != null);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i <= n; i++)
                    {
                        var index = _blendedTokens.Index + i;
                        if (index >= _blendedTokens.FirstIndex && index < _blendedTokens.FirstIndex + _blendedTokens.Count)
                        {
                            Debug.Assert(_blendedTokens[index].Token != null);
                        }
                    }
                }
#endif
                RegisterLookahead(n);
                return _blendedTokens.PeekItem(n).Token;
            }
            else
            {
                return _lexedTokens.PeekItem(n).Token;
            }
        }

        //this method is called very frequently
        //we should keep it simple so that it can be inlined.
        protected InternalSyntaxToken EatToken()
        {
            var ct = this.EatCurrentTokenWithAndErrors(eatSkippedTokens: true);
            MoveToNextToken();
            return ct;
        }

        private InternalSyntaxToken EatCurrentTokenWithAndErrors(bool eatSkippedTokens)
        {
            var ct = this.CurrentToken;
            if (eatSkippedTokens && _skippedTokens.Count > 0)
            {
                ct = AddSkippedSyntax(ct, _skippedTokens.ToListNode(), false);
                _skippedTokens.Clear();
            }
            ct = (InternalSyntaxToken)WithCurrentSyntaxErrors(ct, 0);
            if (ct.ContainsDiagnostics)
            {
                var customToken = this.CreateCustomTokenCore(ct, _position);
                if (_blendedTokens != null)
                {
                    var bt = _blendedTokens.GetCurrentItem();
                    _blendedTokens.UpdateCurrentItem(new BlendedNode(null, ct, customToken, bt.Blender));
                }
                else
                {
                    _lexedTokens.UpdateCurrentItem((ct, customToken));
                }
            }
            return ct;
        }

        protected void MoveToNextToken()
        {
            if (_currentNode.Node != null)
            {
                _position += _currentNode.Node.FullWidth;
                _prevTokenTrailingTrivia = _currentNode.Node.GetTrailingTrivia().Node;
            }
            else
            {
                _position += _currentToken.FullWidth;
                _prevTokenTrailingTrivia = _currentToken.GetTrailingTrivia();
            }
            _currentToken = default;
            if (_blendedTokens != null)
            {
                _blendedTokens.EatItem();
                _currentNode = default;
            }
            else
            {
                _lexedTokens.EatItem();
            }
        }

        protected void ForceEndOfFile()
        {
            _currentToken = Language.InternalSyntaxFactory.EndOfFile;
        }

        //this method is called very frequently
        //we should keep it simple so that it can be inlined.
        protected InternalSyntaxToken EatToken(SyntaxKind kind)
        {
            Debug.Assert(Language.SyntaxFacts.IsToken(kind));

            var ct = this.EatCurrentTokenWithAndErrors(eatSkippedTokens: true);
            if (ct.Kind == kind)
            {
                MoveToNextToken();
                return ct;
            }

            //slow part of EatToken(SyntaxKind kind)
            return CreateMissingToken(kind, this.CurrentToken.Kind, reportError: true);
        }

        protected InternalSyntaxToken SkipToken()
        {
            var ct = this.EatCurrentTokenWithAndErrors(eatSkippedTokens: false);
            _skippedTokens.Add(ct);
            MoveToNextToken();
            return ct;
        }

        private InternalSyntaxToken CreateMissingToken(SyntaxKind expected)
        {
            var token = Language.InternalSyntaxFactory.MissingToken(expected);
            return token;
        }

        protected InternalSyntaxToken CreateMissingToken(SyntaxKind expected, SyntaxKind actual, bool reportError)
        {
            // should we eat the current ParseToken's leading trivia?
            var token = CreateMissingToken(expected);
            if (reportError)
            {
                token = WithAdditionalDiagnostics(token, this.GetExpectedTokenError(expected, actual));
            }
            return token;
        }

        internal protected virtual object CreateCustomTokenCore(InternalSyntaxToken token, int position)
        {
            return null;
        }

        public object GetCurrentCustomToken()
        {
            if (_blendedTokens != null) return _blendedTokens.GetCurrentItem().CustomToken;
            else return _lexedTokens.GetCurrentItem().CustomToken;
        }

        public object PeekCustomToken(int n)
        {
            if (_blendedTokens != null)
            {
                RegisterLookahead(n);
                return _blendedTokens.PeekItem(n).CustomToken;
            }
            else
            {
                return _lexedTokens.PeekItem(n).CustomToken;
            }
        }
    }

}
