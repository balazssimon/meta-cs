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
    public abstract partial class IncrementalParser : SyntaxParser, IDisposable
    {
        private static ConditionalWeakTable<LanguageSyntaxNode, IncrementalSyntaxTree> s_incrementalSyntaxTree = new ConditionalWeakTable<LanguageSyntaxNode, IncrementalSyntaxTree>();

        protected readonly Language Language;
        protected readonly IncrementalLexer _lexer;
        private readonly bool _isIncremental;
        private readonly IncrementalSyntaxTree _oldIncrementalTree;
        protected readonly CancellationToken cancellationToken;

        private Blender _firstBlender;
        private BlendedNode _currentNode;
        private InternalSyntaxToken _currentToken;
        private ArrayElement<InternalSyntaxToken>[] _lexedTokens;
        private GreenNode _prevTokenTrailingTrivia;
        private int _firstToken; // The position of _lexedTokens[0] (or _blendedTokens[0]).
        private int _tokenOffset; // The index of the current token within _lexedTokens or _blendedTokens.
        private int _tokenCount;
        private int _resetCount;
        private int _resetStart;
        private LexerMode _mode;
        private ParserState _state;
        private Stack<object> _incrementalStack;
        private IncrementalSyntaxNode _previousIncrementalNode;
#if DEBUG
        private readonly int _version;
#endif

        private static readonly ObjectPool<BlendedNode[]> s_blendedNodesPool = new ObjectPool<BlendedNode[]>(() => new BlendedNode[32], 2);

        private BlendedNode[] _blendedTokens;

        protected IncrementalParser(
            Language language,
            SourceText text,
            LanguageParseOptions options,
            LanguageSyntaxNode oldTree,
            IEnumerable<TextChangeRange> changes,
            CancellationToken cancellationToken = default)
            : base(language, text, options, oldTree, changes, cancellationToken)
        {
            Language = language;
            _lexer = language.InternalSyntaxFactory.CreateLexer(text, options, changes);
            this.cancellationToken = cancellationToken;
            _currentNode = default;
            _incrementalStack = new Stack<object>();
            _oldIncrementalTree = oldTree != null ? GetIncrementalSyntaxTree(oldTree) : null;
            _isIncremental = _oldIncrementalTree != null;

            if (this.IsIncremental)
            {
                _firstBlender = new Blender(_lexer, oldTree, _oldIncrementalTree, changes);
                _blendedTokens = s_blendedNodesPool.Allocate();
#if DEBUG
                _version = _oldIncrementalTree.Version + 1;
#endif
            }
            else
            {
                _firstBlender = default;
                _lexedTokens = new ArrayElement<InternalSyntaxToken>[32];
#if DEBUG
                _version = 1;
#endif
            }
        }

        //public abstract LanguageSyntaxNode Parse();

        public ParseOptions Options => _lexer.Options;

        public SourceText SourceText => _lexer.TextWindow.Text;

        public bool IsScript => Options.Kind == SourceCodeKind.Script;

        public override DirectiveStack Directives => _lexer.Directives;

        protected int TokenOffset => _tokenOffset;

        protected int TokenCount => _tokenCount;

        protected int TokenIndex => _firstToken + _tokenOffset;

        protected int FirstTokenIndex => _firstToken;

        public void Dispose()
        {
            var blendedTokens = _blendedTokens;
            if (blendedTokens != null)
            {
                _blendedTokens = null;
                if (blendedTokens.Length < 4096)
                {
                    Array.Clear(blendedTokens, 0, blendedTokens.Length);
                    s_blendedNodesPool.Free(blendedTokens);
                }
                else
                {
                    s_blendedNodesPool.ForgetTrackedObject(blendedTokens);
                }
            }
        }

        protected void ReInitialize()
        {
            _firstToken = 0;
            _tokenOffset = 0;
            _tokenCount = 0;
            _resetCount = 0;
            _resetStart = 0;
            _currentToken = null;
            _prevTokenTrailingTrivia = null;
            if (this.IsIncremental)
            {
                _firstBlender = new Blender(_lexer, null, null, null);
            }
            RestoreParserState(null);
        }

        protected bool IsIncremental
        {
            get
            {
                return _isIncremental;
            }
        }

        private static IncrementalSyntaxTree GetIncrementalSyntaxTree(LanguageSyntaxNode syntaxTree)
        {
            if (s_incrementalSyntaxTree.TryGetValue(syntaxTree, out var result))
            {
                return result;
            }
            else
            {
                Debug.Assert(false);
                return null;
            }
        }

        protected void BeginRoot()
        {

        }

        protected void EndRoot(LanguageSyntaxNode root)
        {

            int minLookahead = _lexer.MinLookahead;
            int maxLookahead = _lexer.MaxLookahead;
            if (_oldIncrementalTree != null)
            {
                minLookahead = Math.Min(_oldIncrementalTree.MinLexerLookahead, minLookahead);
                maxLookahead = Math.Max(_oldIncrementalTree.MaxLexerLookahead, maxLookahead);
            }
            s_incrementalSyntaxTree.Add(root, new IncrementalSyntaxTree(_previousIncrementalNode, minLookahead, maxLookahead, _version));
        }

        protected void BeginNode(ParserState state)
        {
            RestoreParserState(state);
#if DEBUG
            _incrementalStack.Push(new IncrementalSyntaxNodeBuilder(_state, _version));
#else
            _incrementalStack.Push(new IncrementalSyntaxNodeBuilder(_state));
#endif
        }

        protected ParserState EndNode()
        {
            _state = this.SaveParserState();
            var incrementalNode = _incrementalStack.Pop();
            if (incrementalNode is IncrementalSyntaxNode incrementalSyntaxNode)
            {
                _previousIncrementalNode = incrementalSyntaxNode;
            }
            else if (incrementalNode is IncrementalSyntaxNodeBuilder incrementalSyntaxNodeBuilder)
            {
                _previousIncrementalNode = incrementalSyntaxNodeBuilder.ToImmutable(_state);
            }
            else
            {
                _previousIncrementalNode = null;
                Debug.Assert(false);
            }
            if (_incrementalStack.Count > 0)
            {
                var incrementalParent = _incrementalStack.Peek() as IncrementalSyntaxNodeBuilder;
                Debug.Assert(incrementalParent != null);
                incrementalParent.Children.Add(_previousIncrementalNode);
                incrementalParent.LookaheadBefore = Math.Min(incrementalParent.LookaheadBefore, _previousIncrementalNode.LookaheadBefore);
                incrementalParent.LookaheadAfter = Math.Max(incrementalParent.LookaheadAfter, _previousIncrementalNode.LookaheadAfter);
            }
            return _state;
        }

        protected ParserState SaveParserState()
        {
            return SaveParserState(_state);
        }

        protected virtual ParserState SaveParserState(ParserState previousState)
        {
            return _state;
        }

        protected virtual void RestoreParserState(ParserState state)
        {
            if (_state != state)
            {
                if (_mode != state?.Mode)
                {
                    _mode = state?.Mode;
                    _tokenCount = _tokenOffset;
                    _currentToken = default;
                    _currentNode = default;
                    ResetCurrentToken();
                }
                _state = state;
            }
        }

        private void ResetCurrentToken()
        {
            if (_blendedTokens != null)
            {
                // look forward for slots not holding a token
                for (int i = _tokenOffset; i < _tokenCount; i++)
                {
                    if (_blendedTokens[i].Token == null)
                    {
                        // forget anything after and including any slot not holding a token
                        _tokenCount = i;
                        if (_tokenCount == _tokenOffset)
                        {
                            FetchCurrentToken();
                        }
                        break;
                    }
                }
            }
        }

        protected ResetPoint GetResetPoint()
        {
            var pos = CurrentTokenPosition;
            if (_resetCount == 0)
            {
                _resetStart = pos; // low water mark
            }

            _resetCount++;
            return new ResetPoint(_resetCount, SaveParserState(), pos, _prevTokenTrailingTrivia);
        }

        protected void Reset(ref ResetPoint point)
        {
            var offset = point.Position - _firstToken;
            Debug.Assert(offset >= 0 && offset < _tokenCount);
            _tokenOffset = offset;
            _currentToken = default;
            _currentNode = default;
            _prevTokenTrailingTrivia = point.PrevTokenTrailingTrivia;
            RestoreParserState(point.State);
        }

        protected void Release(ref ResetPoint point)
        {
            Debug.Assert(_resetCount == point.ResetCount);
            _resetCount--;
            if (_resetCount == 0)
            {
                _resetStart = -1;
            }
        }

        protected LexerMode Mode => _mode;

        protected ParserState State
        {
            get
            {
                return _state;
            }

            set
            {
                if (_state != value)
                {
                    RestoreParserState(value);
                }
            }
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
            if (_tokenOffset == 0)
            {
                _currentNode = _firstBlender.ReadNode();
            }
            else
            {
                _currentNode = _blendedTokens[_tokenOffset - 1].Blender.ReadNode();
            }
        }

        protected GreenNode EatNode()
        {
            // we will fail anyways. Assert is just to catch that earlier.
            Debug.Assert(_blendedTokens != null);

            // remember result
            var result = CurrentNode.Green;

            // store possible non-token in token sequence 
            if (_tokenOffset >= _blendedTokens.Length)
            {
                this.AddTokenSlot();
            }

            _blendedTokens[_tokenOffset++] = _currentNode;
            _tokenCount = _tokenOffset; // forget anything after this slot

            // store incremental data
            var incrementalNode = _incrementalStack.Pop();
            Debug.Assert(incrementalNode is IncrementalSyntaxNodeBuilder);
            _incrementalStack.Push(_currentNode.Blender.IncrementalSyntaxNode);

            // erase current state
            _currentNode = default;
            _currentToken = default;
            RestoreParserState(_currentNode.Blender.IncrementalSyntaxNode.StateAfter);

            return result;
        }

        protected InternalSyntaxToken CurrentToken
        {
            get
            {
                return _currentToken ?? (_currentToken = this.FetchCurrentToken());
            }
        }

        private InternalSyntaxToken FetchCurrentToken()
        {
            if (_tokenOffset >= _tokenCount)
            {
                this.AddNewToken();
            }

            if (_blendedTokens != null)
            {
                return _blendedTokens[_tokenOffset].Token;
            }
            else
            {
                return _lexedTokens[_tokenOffset];
            }
        }

        private void AddNewToken()
        {
            if (_blendedTokens != null)
            {
                BlendedNode oldToken;
                if (_tokenCount > 0)
                {
                    oldToken = _blendedTokens[_tokenCount - 1].Blender.ReadToken();
                }
                else
                {
                    if (_currentNode.Token != null)
                    {
                        oldToken = _currentNode;
                    }
                    else
                    {
                        oldToken = _firstBlender.ReadToken();
                    }
                }
                this.AddToken(oldToken);
                _mode = oldToken.Blender.Mode;
                //RestoreParserState(oldToken.Blender.State);
            }
            else
            {
                this.AddLexedToken(_lexer.Lex(ref _mode));
            }
            var incrementalNode = _incrementalStack.Peek();
            if (incrementalNode is IncrementalSyntaxNodeBuilder incrementalNodeBuilder)
            {
                incrementalNodeBuilder.Children.Add(null);
            }
            else
            {
                Debug.Assert(incrementalNode is IncrementalSyntaxNodeBuilder);
            }
        }

        // adds token to end of current token array
        private void AddToken(in BlendedNode tokenResult)
        {
            Debug.Assert(tokenResult.Token != null);
            if (_tokenCount >= _blendedTokens.Length)
            {
                this.AddTokenSlot();
            }

            _blendedTokens[_tokenCount] = tokenResult;
            _tokenCount++;
            this.TokenAdded(tokenResult.Token, true);
        }

        private void AddLexedToken(InternalSyntaxToken token)
        {
            Debug.Assert(token != null);
            if (_tokenCount >= _lexedTokens.Length)
            {
                this.AddLexedTokenSlot();
            }

            _lexedTokens[_tokenCount].Value = token;
            _tokenCount++;
            this.TokenAdded(token, false);
        }

        protected virtual void TokenAdded(InternalSyntaxToken token, bool incremental)
        {
        }

        private void AddTokenSlot()
        {
            // shift tokens to left if we are far to the right
            // don't shift if reset points have fixed locked tge starting point at the token in the window
            if (_tokenOffset > (_blendedTokens.Length >> 1)
                && (_resetStart == -1 || _resetStart > _firstToken))
            {
                int shiftOffset = (_resetStart == -1) ? _tokenOffset : _resetStart - _firstToken;
                int shiftCount = _tokenCount - shiftOffset;
                Debug.Assert(shiftOffset > 0);
                _firstBlender = _blendedTokens[shiftOffset - 1].Blender;
                if (shiftCount > 0)
                {
                    Array.Copy(_blendedTokens, shiftOffset, _blendedTokens, 0, shiftCount);
                }

                _firstToken += shiftOffset;
                _tokenCount -= shiftOffset;
                _tokenOffset -= shiftOffset;
            }
            else
            {
                var old = _blendedTokens;
                Array.Resize(ref _blendedTokens, _blendedTokens.Length * 2);
                s_blendedNodesPool.ForgetTrackedObject(old, replacement: _blendedTokens);
            }
        }

        private void AddLexedTokenSlot()
        {
            // shift tokens to left if we are far to the right
            // don't shift if reset points have fixed locked tge starting point at the token in the window
            if (_tokenOffset > (_lexedTokens.Length >> 1)
                && (_resetStart == -1 || _resetStart > _firstToken))
            {
                int shiftOffset = (_resetStart == -1) ? _tokenOffset : _resetStart - _firstToken;
                int shiftCount = _tokenCount - shiftOffset;
                Debug.Assert(shiftOffset > 0);
                if (shiftCount > 0)
                {
                    Array.Copy(_lexedTokens, shiftOffset, _lexedTokens, 0, shiftCount);
                }

                _firstToken += shiftOffset;
                _tokenCount -= shiftOffset;
                _tokenOffset -= shiftOffset;
            }
            else
            {
                var tmp = new ArrayElement<InternalSyntaxToken>[_lexedTokens.Length * 2];
                Array.Copy(_lexedTokens, tmp, _lexedTokens.Length);
                _lexedTokens = tmp;
            }
        }

        protected void Seek(int index)
        {
            Debug.Assert(index >= _firstToken && index < _firstToken + _tokenCount);
            _tokenOffset = index - _firstToken;
            _currentNode = default;
            _currentToken = default;
        }

        protected InternalSyntaxToken PeekToken(int n)
        {
            var incrementalNode = _incrementalStack.Peek();
            if (incrementalNode is IncrementalSyntaxNodeBuilder builder)
            {
                builder.LookaheadBefore = Math.Min(n, builder.LookaheadBefore);
                builder.LookaheadAfter = Math.Max(n, builder.LookaheadAfter);
            }
            else
            {
                Debug.Assert(false);
            }

            //Debug.Assert(n >= 0);
            if (_tokenOffset + n < 0) return null;

            while (_tokenOffset + n >= _tokenCount)
            {
                var prevTokenCount = _tokenCount;
                this.AddNewToken();
                if (_tokenCount == prevTokenCount) return null; // no more tokens
            }

            if (_blendedTokens != null)
            {
                return _blendedTokens[_tokenOffset + n].Token;
            }
            else
            {
                return _lexedTokens[_tokenOffset + n];
            }
        }

        //this method is called very frequently
        //we should keep it simple so that it can be inlined.
        protected InternalSyntaxToken EatToken()
        {
            var ct = this.CurrentToken;
            MoveToNextToken();
            return ct;
        }

        /// <summary>
        /// Returns and consumes the current token if it has the requested <paramref name="kind"/>.
        /// Otherwise, returns <see langword="null"/>.
        /// </summary>
        protected InternalSyntaxToken TryEatToken(SyntaxKind kind)
            => this.CurrentToken.Kind == kind ? this.EatToken() : null;

        private void MoveToNextToken()
        {
            _prevTokenTrailingTrivia = _currentToken.GetTrailingTrivia();

            _currentToken = default;

            if (_blendedTokens != null)
            {
                _currentNode = default;
            }

            _tokenOffset++;
        }

        protected void ForceEndOfFile()
        {
            _currentToken = Language.InternalSyntaxFactory.Token(SyntaxKind.Eof);
        }

        //this method is called very frequently
        //we should keep it simple so that it can be inlined.
        protected InternalSyntaxToken EatToken(SyntaxKind kind)
        {
            Debug.Assert(Language.SyntaxFacts.IsToken(kind));

            var ct = this.CurrentToken;
            if (ct.Kind == kind)
            {
                MoveToNextToken();
                return ct;
            }

            //slow part of EatToken(SyntaxKind kind)
            return CreateMissingToken(kind, this.CurrentToken.Kind, reportError: true);
        }

        // Consume a token if it is the right kind. Otherwise skip a token and replace it with one of the correct kind.
        protected InternalSyntaxToken EatTokenAsKind(SyntaxKind expected)
        {
            Debug.Assert(Language.SyntaxFacts.IsToken(expected));

            var ct = this.CurrentToken;
            if (ct.Kind == expected)
            {
                MoveToNextToken();
                return ct;
            }

            var replacement = CreateMissingToken(expected, this.CurrentToken.Kind, reportError: true);
            return AddTrailingSkippedSyntax(replacement, this.EatToken());
        }

        private InternalSyntaxToken CreateMissingToken(SyntaxKind expected, SyntaxKind actual, bool reportError)
        {
            // should we eat the current ParseToken's leading trivia?
            var token = Language.InternalSyntaxFactory.MissingToken(expected);
            if (reportError)
            {
                token = WithAdditionalDiagnostics(token, this.GetExpectedTokenError(expected, actual));
            }

            return token;
        }

        private InternalSyntaxToken CreateMissingToken(SyntaxKind expected, ErrorCode code, bool reportError)
        {
            // should we eat the current ParseToken's leading trivia?
            var token = Language.InternalSyntaxFactory.MissingToken(expected);
            if (reportError)
            {
                token = AddError(token, code);
            }

            return token;
        }

        protected InternalSyntaxToken EatToken(SyntaxKind kind, bool reportError)
        {
            if (reportError)
            {
                return EatToken(kind);
            }

            Debug.Assert(Language.SyntaxFacts.IsToken(kind));
            if (this.CurrentToken.Kind != kind)
            {
                // should we eat the current ParseToken's leading trivia?
                return Language.InternalSyntaxFactory.MissingToken(kind);
            }
            else
            {
                return this.EatToken();
            }
        }

        protected InternalSyntaxToken EatToken(SyntaxKind kind, ErrorCode code, bool reportError = true)
        {
            Debug.Assert(Language.SyntaxFacts.IsToken(kind));
            if (this.CurrentToken.Kind != kind)
            {
                return CreateMissingToken(kind, code, reportError);
            }
            else
            {
                return this.EatToken();
            }
        }

        protected InternalSyntaxToken EatTokenWithPrejudice(SyntaxKind kind)
        {
            var token = this.CurrentToken;
            Debug.Assert(Language.SyntaxFacts.IsToken(kind));
            if (token.Kind != kind)
            {
                token = WithAdditionalDiagnostics(token, this.GetExpectedTokenError(kind, token.Kind));
            }

            this.MoveToNextToken();
            return token;
        }

        protected InternalSyntaxToken EatTokenWithPrejudice(ErrorCode errorCode, params object[] args)
        {
            var token = this.EatToken();
            token = WithAdditionalDiagnostics(token, MakeError(token.GetLeadingTriviaWidth(), token.Width, errorCode, args));
            return token;
        }

        protected InternalSyntaxToken EatContextualToken(SyntaxKind kind, ErrorCode code, bool reportError = true)
        {
            Debug.Assert(Language.SyntaxFacts.IsToken(kind));

            if (this.CurrentToken.ContextualKind != kind)
            {
                return CreateMissingToken(kind, code, reportError);
            }
            else
            {
                return ConvertToKeyword(this.EatToken());
            }
        }

        protected InternalSyntaxToken EatContextualToken(SyntaxKind kind, bool reportError = true)
        {
            Debug.Assert(Language.SyntaxFacts.IsToken(kind));

            var contextualKind = this.CurrentToken.ContextualKind;
            if (contextualKind != kind)
            {
                return CreateMissingToken(kind, contextualKind, reportError);
            }
            else
            {
                return ConvertToKeyword(this.EatToken());
            }
        }

        protected virtual SyntaxDiagnosticInfo GetExpectedTokenError(SyntaxKind expected, SyntaxKind actual, int offset, int width)
        {
            var code = GetExpectedTokenErrorCode(expected, actual);
            if (code == InternalErrorCode.ERR_SyntaxError || code == InternalErrorCode.ERR_IdentifierExpectedKW)
            {
                return new SyntaxDiagnosticInfo(offset, width, code, Language.SyntaxFacts.GetText(expected), Language.SyntaxFacts.GetText(actual));
            }
            else
            {
                return new SyntaxDiagnosticInfo(offset, width, code);
            }
        }

        protected virtual SyntaxDiagnosticInfo GetExpectedTokenError(SyntaxKind expected, SyntaxKind actual)
        {
            int offset, width;
            this.GetDiagnosticSpanForMissingToken(out offset, out width);

            return this.GetExpectedTokenError(expected, actual, offset, width);
        }

        private ErrorCode GetExpectedTokenErrorCode(SyntaxKind expected, SyntaxKind actual)
        {
            if (Language.SyntaxFacts.IsIdentifier(expected))
            {
                if (Language.SyntaxFacts.IsReservedKeyword(actual))
                {
                    return InternalErrorCode.ERR_IdentifierExpectedKW;   // A keyword -- use special message.
                }
                else
                {
                    return InternalErrorCode.ERR_IdentifierExpected;
                }
            }
            else
            {
                return InternalErrorCode.ERR_SyntaxError;
            }
        }

        protected void GetDiagnosticSpanForMissingToken(out int offset, out int width)
        {
            // If the previous token has a trailing EndOfLineTrivia,
            // the missing token diagnostic position is moved to the
            // end of line containing the previous token and
            // its width is set to zero.
            // Otherwise the diagnostic offset and width is set
            // to the corresponding values of the current token

            var trivia = _prevTokenTrailingTrivia;
            if (trivia != null)
            {
                var triviaList = new Microsoft.CodeAnalysis.Syntax.InternalSyntax.SyntaxList<InternalSyntaxNode>(trivia);
                bool prevTokenHasEndOfLineTrivia = triviaList.Any((int)(SyntaxKind)SyntaxKind.Eof);
                if (prevTokenHasEndOfLineTrivia)
                {
                    offset = -trivia.FullWidth;
                    width = 0;
                    return;
                }
            }

            InternalSyntaxToken ct = this.CurrentToken;
            offset = ct.GetLeadingTriviaWidth();
            width = ct.Width;
        }

        protected virtual TNode WithAdditionalDiagnostics<TNode>(TNode node, params DiagnosticInfo[] diagnostics) where TNode : GreenNode
        {
            DiagnosticInfo[] existingDiags = node.GetDiagnostics();
            int existingLength = existingDiags.Length;
            if (existingLength == 0)
            {
                return node.WithDiagnosticsGreen(diagnostics);
            }
            else
            {
                DiagnosticInfo[] result = new DiagnosticInfo[existingDiags.Length + diagnostics.Length];
                existingDiags.CopyTo(result, 0);
                diagnostics.CopyTo(result, existingLength);
                return node.WithDiagnosticsGreen(result);
            }
        }

        protected TNode AddError<TNode>(TNode node, ErrorCode code) where TNode : GreenNode
        {
            return AddError(node, code, Array.Empty<object>());
        }

        protected TNode AddError<TNode>(TNode node, ErrorCode code, params object[] args) where TNode : GreenNode
        {
            if (!node.IsMissing)
            {
                return WithAdditionalDiagnostics(node, MakeError(node, code, args));
            }

            int offset, width;

            InternalSyntaxToken token = node as InternalSyntaxToken;
            if (token != null && token.ContainsSkippedText)
            {
                // This code exists to clean up an anti-pattern:
                //   1) an undesirable token is parsed,
                //   2) a desirable missing token is created and the parsed token is appended as skipped text,
                //   3) an error is attached to the missing token describing the problem.
                // If this occurs, then this.previousTokenTrailingTrivia is still populated with the trivia 
                // of the undesirable token (now skipped text).  Since the trivia no longer precedes the
                // node to which the error is to be attached, the computed offset will be incorrect.

                offset = token.GetLeadingTriviaWidth(); // Should always be zero, but at least we'll do something sensible if it's not.
                Debug.Assert(offset == 0, "Why are we producing a missing token that has both skipped text and leading trivia?");

                width = 0;
                bool seenSkipped = false;
                foreach (var trivia in token.TrailingTrivia)
                {
                    if (trivia.Kind == SyntaxKind.SkippedTokensTrivia)
                    {
                        seenSkipped = true;
                        width += trivia.Width;
                    }
                    else if (seenSkipped)
                    {
                        break;
                    }
                    else
                    {
                        offset += trivia.Width;
                    }
                }
            }
            else
            {
                this.GetDiagnosticSpanForMissingToken(out offset, out width);
            }

            return WithAdditionalDiagnostics(node, MakeError(offset, width, code, args));
        }

        protected TNode AddError<TNode>(TNode node, int offset, int length, ErrorCode code, params object[] args) where TNode : InternalSyntaxNode
        {
            return WithAdditionalDiagnostics(node, MakeError(offset, length, code, args));
        }

        protected TNode AddError<TNode>(TNode node, InternalSyntaxNode location, ErrorCode code, params object[] args) where TNode : InternalSyntaxNode
        {
            // assumes non-terminals will at most appear once in sub-tree
            int offset;
            FindOffset(node, location, out offset);
            return WithAdditionalDiagnostics(node, MakeError(offset, location.Width, code, args));
        }

        protected TNode AddErrorToFirstToken<TNode>(TNode node, ErrorCode code) where TNode : InternalSyntaxNode
        {
            var firstToken = node.GetFirstToken();
            return WithAdditionalDiagnostics(node, MakeError(firstToken.GetLeadingTriviaWidth(), firstToken.Width, code));
        }

        protected TNode AddErrorToFirstToken<TNode>(TNode node, ErrorCode code, params object[] args) where TNode : InternalSyntaxNode
        {
            var firstToken = node.GetFirstToken();
            return WithAdditionalDiagnostics(node, MakeError(firstToken.GetLeadingTriviaWidth(), firstToken.Width, code, args));
        }

        protected TNode AddErrorToLastToken<TNode>(TNode node, ErrorCode code) where TNode : InternalSyntaxNode
        {
            int offset;
            int width;
            GetOffsetAndWidthForLastToken(node, out offset, out width);
            return WithAdditionalDiagnostics(node, MakeError(offset, width, code));
        }

        protected TNode AddErrorToLastToken<TNode>(TNode node, ErrorCode code, params object[] args) where TNode : InternalSyntaxNode
        {
            int offset;
            int width;
            GetOffsetAndWidthForLastToken(node, out offset, out width);
            return WithAdditionalDiagnostics(node, MakeError(offset, width, code, args));
        }

        private static void GetOffsetAndWidthForLastToken<TNode>(TNode node, out int offset, out int width) where TNode : InternalSyntaxNode
        {
            var lastToken = node.GetLastNonmissingToken();
            offset = node.FullWidth; //advance to end of entire node
            width = 0;
            if (lastToken != null) //will be null if all tokens are missing
            {
                offset -= lastToken.FullWidth; //rewind past last token
                offset += lastToken.GetLeadingTriviaWidth(); //advance past last token leading trivia - now at start of last token
                width += lastToken.Width;
            }
        }

        protected static SyntaxDiagnosticInfo MakeError(int offset, int width, ErrorCode code)
        {
            return new SyntaxDiagnosticInfo(offset, width, code);
        }

        protected static SyntaxDiagnosticInfo MakeError(int offset, int width, ErrorCode code, params object[] args)
        {
            return new SyntaxDiagnosticInfo(offset, width, code, args);
        }

        protected static SyntaxDiagnosticInfo MakeError(GreenNode node, ErrorCode code, params object[] args)
        {
            return new SyntaxDiagnosticInfo(node.GetLeadingTriviaWidth(), node.Width, code, args);
        }

        protected static SyntaxDiagnosticInfo MakeError(ErrorCode code, params object[] args)
        {
            return new SyntaxDiagnosticInfo(code, args);
        }

        protected TNode AddLeadingSkippedSyntax<TNode>(TNode node, GreenNode skippedSyntax) where TNode : InternalSyntaxNode
        {
            var oldToken = node as InternalSyntaxToken ?? node.GetFirstToken();
            var newToken = AddSkippedSyntax(oldToken, skippedSyntax, trailing: false);
            return SyntaxFirstTokenReplacer.Replace(node, oldToken, newToken, skippedSyntax.FullWidth);
        }

        protected void AddTrailingSkippedSyntax(SyntaxListBuilder list, GreenNode skippedSyntax)
        {
            list[list.Count - 1] = AddTrailingSkippedSyntax((InternalSyntaxNode)list[list.Count - 1], skippedSyntax);
        }

        protected void AddTrailingSkippedSyntax<TNode>(SyntaxListBuilder<TNode> list, GreenNode skippedSyntax) where TNode : InternalSyntaxNode
        {
            list[list.Count - 1] = AddTrailingSkippedSyntax(list[list.Count - 1], skippedSyntax);
        }

        protected TNode AddTrailingSkippedSyntax<TNode>(TNode node, GreenNode skippedSyntax) where TNode : InternalSyntaxNode
        {
            var token = node as InternalSyntaxToken;
            if (token != null)
            {
                return (TNode)(object)AddSkippedSyntax(token, skippedSyntax, trailing: true);
            }
            else
            {
                var lastToken = node.GetLastToken();
                var newToken = AddSkippedSyntax(lastToken, skippedSyntax, trailing: true);
                return SyntaxLastTokenReplacer.Replace(node, newToken);
            }
        }

        /// <summary>
        /// Converts skippedSyntax node into tokens and adds these as trivia on the target token.
        /// Also adds the first error (in depth-first preorder) found in the skipped syntax tree to the target token.
        /// </summary>
        internal InternalSyntaxToken AddSkippedSyntax(InternalSyntaxToken target, GreenNode skippedSyntax, bool trailing)
        {
            var builder = new SyntaxListBuilder(4);

            // the error in we'll attach to the node
            SyntaxDiagnosticInfo diagnostic = null;

            // the position of the error within the skippedSyntax node full tree
            int diagnosticOffset = 0;

            int currentOffset = 0;
            foreach (var node in skippedSyntax.EnumerateNodes())
            {
                InternalSyntaxToken token = node as InternalSyntaxToken;
                if (token != null)
                {
                    builder.Add(token.GetLeadingTrivia());

                    if (token.Width > 0)
                    {
                        // separate trivia from the tokens
                        InternalSyntaxToken tk = token.TokenWithLeadingTrivia(null).TokenWithTrailingTrivia(null);

                        // adjust relative offsets of diagnostics attached to the token:
                        int leadingWidth = token.GetLeadingTriviaWidth();
                        if (leadingWidth > 0)
                        {
                            var tokenDiagnostics = tk.GetDiagnostics();
                            for (int i = 0; i < tokenDiagnostics.Length; i++)
                            {
                                var d = (SyntaxDiagnosticInfo)tokenDiagnostics[i];
                                tokenDiagnostics[i] = new SyntaxDiagnosticInfo(d.Offset - leadingWidth, d.Width, d.ErrorCode, d.Arguments);
                            }
                        }

                        builder.Add(Language.InternalSyntaxFactory.SkippedToken(tk));
                    }
                    else
                    {
                        // do not create zero-width structured trivia, GetStructure doesn't work well for them
                        var existing = (SyntaxDiagnosticInfo)token.GetDiagnostics().FirstOrDefault();
                        if (existing != null)
                        {
                            diagnostic = existing;
                            diagnosticOffset = currentOffset;
                        }
                    }
                    builder.Add(token.GetTrailingTrivia());

                    currentOffset += token.FullWidth;
                }
                else if (node.ContainsDiagnostics && diagnostic == null)
                {
                    // only propagate the first error to reduce noise:
                    var existing = (SyntaxDiagnosticInfo)node.GetDiagnostics().FirstOrDefault();
                    if (existing != null)
                    {
                        diagnostic = existing;
                        diagnosticOffset = currentOffset;
                    }
                }
            }

            int triviaWidth = currentOffset;
            var trivia = builder.ToListNode();

            // total width of everything preceding the added trivia
            int triviaOffset;
            if (trailing)
            {
                var trailingTrivia = target.GetTrailingTrivia();
                triviaOffset = target.FullWidth; //added trivia is full width (before addition)
                target = target.TokenWithTrailingTrivia(SyntaxList.Concat(trailingTrivia, trivia));
            }
            else
            {
                // Since we're adding triviaWidth before the token, we have to add that much to
                // the offset of each of its diagnostics.
                if (triviaWidth > 0)
                {
                    var targetDiagnostics = target.GetDiagnostics();
                    for (int i = 0; i < targetDiagnostics.Length; i++)
                    {
                        var d = (SyntaxDiagnosticInfo)targetDiagnostics[i];
                        targetDiagnostics[i] = new SyntaxDiagnosticInfo(d.Offset + triviaWidth, d.Width, d.ErrorCode, d.Arguments);
                    }
                }

                var leadingTrivia = target.GetLeadingTrivia();
                target = target.TokenWithLeadingTrivia(SyntaxList.Concat(trivia, leadingTrivia));
                triviaOffset = 0; //added trivia is first, so offset is zero
            }

            if (diagnostic != null)
            {
                int newOffset = triviaOffset + diagnosticOffset + diagnostic.Offset;

                target = WithAdditionalDiagnostics(target,
                    new SyntaxDiagnosticInfo(newOffset, diagnostic.Width, diagnostic.ErrorCode, diagnostic.Arguments)
                );
            }

            return target;
        }

        /// <summary>
        /// This function searches for the given location node within the subtree rooted at root node. 
        /// If it finds it, the function computes the offset span of that child node within the root and returns true, 
        /// otherwise it returns false.
        /// </summary>
        /// <param name="root">Root node</param>
        /// <param name="location">Node to search in the subtree rooted at root node</param>
        /// <param name="offset">Offset of the location node within the subtree rooted at child</param>
        /// <returns></returns>
        private bool FindOffset(GreenNode root, InternalSyntaxNode location, out int offset)
        {
            int currentOffset = 0;
            offset = 0;
            if (root != null)
            {
                for (int i = 0, n = root.SlotCount; i < n; i++)
                {
                    var child = root.GetSlot(i);
                    if (child == null)
                    {
                        // ignore null slots
                        continue;
                    }

                    // check if the child node is the location node
                    if (child == location)
                    {
                        // Found the location node in the subtree
                        // Initialize offset with the offset of the location node within its parent
                        // and walk up the stack of recursive calls adding the offset of each node
                        // within its parent
                        offset = currentOffset;
                        return true;
                    }

                    // search for the location node in the subtree rooted at child node
                    if (this.FindOffset(child, location, out offset))
                    {
                        // Found the location node in child's subtree
                        // Add the offset of child node within its parent to offset
                        // and continue walking up the stack
                        offset += child.GetLeadingTriviaWidth() + currentOffset;
                        return true;
                    }

                    // We didn't find the location node in the subtree rooted at child
                    // Move on to the next child
                    currentOffset += child.FullWidth;
                }
            }

            // We didn't find the location node within the subtree rooted at root node
            return false;
        }

        protected InternalSyntaxToken ConvertToKeyword(InternalSyntaxToken token)
        {
            if (token.GetKind() != token.ContextualKind)
            {
                var kw = token.IsMissing
                        ? Language.InternalSyntaxFactory.MissingToken(token.LeadingTrivia.Node, token.ContextualKind, token.TrailingTrivia.Node)
                        : Language.InternalSyntaxFactory.Token(token.LeadingTrivia.Node, token.ContextualKind, token.TrailingTrivia.Node);
                var d = token.GetDiagnostics();
                if (d != null && d.Length > 0)
                {
                    kw = kw.WithDiagnosticsGreen(d);
                }

                return kw;
            }

            return token;
        }

        /// <summary>
        /// Whenever parsing in a <c>while (true)</c> loop and a bug could prevent the loop from making progress,
        /// this method can prevent the parsing from hanging.
        /// Use as:
        ///     int tokenProgress = -1;
        ///     while (IsMakingProgress(ref tokenProgress))
        /// It should be used as a guardrail, not as a crutch, so it asserts if no progress was made.
        /// </summary>
        protected bool IsMakingProgress(ref int lastTokenPosition)
        {
            var pos = CurrentTokenPosition;
            if (pos > lastTokenPosition)
            {
                lastTokenPosition = pos;
                return true;
            }

            Debug.Assert(false);
            return false;
        }

        private int CurrentTokenPosition => _firstToken + _tokenOffset;
    }

}
