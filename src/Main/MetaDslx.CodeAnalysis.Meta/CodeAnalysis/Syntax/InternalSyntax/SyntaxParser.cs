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
    public abstract partial class SyntaxParser : IDisposable
    {
        public const string IncrementalTreeAnnotationKind = "MetaDslx.IncementalTree";
        public const string IncrementalNodeAnnotationKind = "MetaDslx.IncementalNode";

        public readonly SyntaxLexer Lexer;
        public readonly bool IsIncremental;
        protected readonly CancellationToken CancellationToken;

        private LexerMode _mode;
        private ParserState _state;
        private LanguageSyntaxNode _oldRoot;
        private BlendedNode _currentNode;
        private InternalSyntaxToken _currentToken;
        private GreenNode _prevTokenTrailingTrivia;
        private int _resetCount;
        private int _resetStart;
        private List<SyntaxDiagnosticInfo> _currentTokenErrors;
        private SyntaxListBuilder _currentSkippedTokens;

        private static readonly ObjectPool<BlendedNode[]> s_blendedNodesPool = new ObjectPool<BlendedNode[]>(() => new BlendedNode[32], 2);

        private SlidingBuffer<InternalSyntaxToken> _lexedTokens;
        private SlidingBuffer<BlendedNode> _blendedTokens;

#if DEBUG
        private int _version;
#endif
        private Stack<(int minLookahead, int maxLookahead, ParserState state)> _incrementalStateStack = new Stack<(int minLookahead, int maxLookahead, ParserState state)>();
        private int _minLookahead;
        private int _maxLookahead;

        protected SyntaxParser(
            Language language,
            SourceText text,
            LanguageParseOptions options,
            LanguageSyntaxNode oldTree,
            IEnumerable<TextChangeRange> changes,
            CancellationToken cancellationToken = default)
        {
            Lexer = language.InternalSyntaxFactory.CreateLexer(text, options);
            IsIncremental = options.Incremental || oldTree != null && changes != null && GetTreeAnnotation(oldTree.Green) != null;
            CancellationToken = cancellationToken;
            _currentNode = default;
            _currentTokenErrors = new List<SyntaxDiagnosticInfo>();
            _currentSkippedTokens = SyntaxListBuilder.Create();
#if DEBUG
            _version = 1;
#endif

            if (IsIncremental)
            {
                _blendedTokens = new SlidingBuffer<BlendedNode>(this, new BlendedNode(null, null, new Blender(this, oldTree, changes)));
                _oldRoot = oldTree;
#if DEBUG
                var oldRootAnnot = GetNodeAnnotation(oldTree?.Green);
                if (oldRootAnnot != null)
                {
                    _version = oldRootAnnot.Version + 1;
                }
#endif
            }
            else
            {
                _lexedTokens = new SlidingBuffer<InternalSyntaxToken>(this, default);
            }
        }


        public abstract LanguageSyntaxNode Parse();

        public Language Language => Lexer.Language;

        public LanguageParseOptions Options => Lexer.Options;

        public SourceText Text => Lexer.Text;

        public bool IsScript => Options != null && Options.Kind == SourceCodeKind.Script;

        public virtual DirectiveStack Directives => Lexer.Directives;

        public LanguageSyntaxNode OldRoot => _oldRoot;

        public virtual void Dispose()
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
        }

        protected void ReInitialize()
        {
            _resetCount = 0;
            _resetStart = 0;
            _currentToken = null;
            _prevTokenTrailingTrivia = null;
            SlidingBuffer_Reset();
        }

        protected virtual void SlidingBuffer_Reset()
        {
            if (_blendedTokens != null) _blendedTokens.Reset();
            else _lexedTokens.Reset();
        }

        protected void BeginRoot()
        {

        }

        protected void EndRoot(ref GreenNode root)
        {
            if (IsIncremental)
            {
                (int minLookahead, int maxLookahead) = Blender.GetLexerLookahead(_oldRoot);
                minLookahead = Math.Min(Lexer.MinLookahead, minLookahead);
                maxLookahead = Math.Max(Lexer.MaxLookahead, maxLookahead);
                root = root.WithAdditionalAnnotationsGreen(new SyntaxAnnotation(IncrementalTreeAnnotationKind, new IncrementalTreeAnnotation(null, null, _mode, _state, minLookahead, maxLookahead)));
            }
        }

        protected void BeginNode()
        {
            _state = SaveParserState();
            if (IsIncremental)
            {
                _minLookahead = int.MaxValue;
                _maxLookahead = int.MinValue;
                _incrementalStateStack.Push((_minLookahead, _maxLookahead, _state));
            }
        }

        protected void BeginNode(ParserState state)
        {
            RestoreParserState(state);
            if (IsIncremental)
            {
                _minLookahead = int.MaxValue;
                _maxLookahead = int.MinValue;
                _incrementalStateStack.Push((_minLookahead, _maxLookahead, state));
            }
        }

        protected ParserState EndNode(ref GreenNode green)
        {
            if (green == null) return null;

            if (IsIncremental)
            {
                var incrementalState = _incrementalStateStack.Pop();
                var minLookahead = Math.Min(incrementalState.minLookahead, _minLookahead);
                var maxLookahead = Math.Max(incrementalState.maxLookahead, _maxLookahead);

                var nodeAnnot = GetNodeAnnotation(green);
                if (nodeAnnot == null)
                {
#if DEBUG
                    green = green.WithAdditionalAnnotationsGreen(new SyntaxAnnotation(IncrementalNodeAnnotationKind, new IncrementalNodeAnnotation(incrementalState.state, minLookahead, maxLookahead, _version)));
#else
                    green = green.WithAdditionalAnnotationsGreen(new SyntaxAnnotation(IncrementalNodeAnnotationKind, new IncrementalNodeAnnotation(incrementalState.state, minLookahead, maxLookahead)));
#endif
                }
                if (_incrementalStateStack.Count > 0)
                {
                    var parentState = _incrementalStateStack.Pop();
                    var parentMinLookahead = Math.Min(minLookahead, parentState.minLookahead);
                    var parentMaxLookahead = Math.Max(maxLookahead, parentState.maxLookahead);
                    _incrementalStateStack.Push((parentMinLookahead, parentMaxLookahead, parentState.state));
                }
            }

            _state = SaveParserState();
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
                this.SlidingBuffer_ForgetFollowingTokens();
                this.EraseState();
                _state = state;
            }
        }

        protected virtual void SlidingBuffer_ForgetFollowingTokens()
        {
            if (_blendedTokens != null) _blendedTokens.ForgetFollowingTokens();
            else _lexedTokens.ForgetFollowingTokens();
        }

        protected ResetPoint GetResetPoint()
        {
            var pos = TokenIndex;
            if (_resetCount == 0)
            {
                _resetStart = pos; // low water mark
                SlidingBuffer_MarkResetPoint();
            }

            _resetCount++;
            return new ResetPoint(_resetCount, _state, pos, _prevTokenTrailingTrivia);
        }

        protected virtual void SlidingBuffer_MarkResetPoint()
        {
            if (_blendedTokens != null) _blendedTokens.MarkResetPoint();
            else _lexedTokens.MarkResetPoint();
        }

        protected void Reset(ref ResetPoint point)
        {
            RestoreParserState(point.State);
            EraseState();
            _prevTokenTrailingTrivia = point.PrevTokenTrailingTrivia;
            SlidingBuffer_ResetTo(point.Position);
        }

        protected virtual void SlidingBuffer_ResetTo(int position)
        {
            if (_blendedTokens != null) _blendedTokens.ResetTo(position);
            else _lexedTokens.ResetTo(position);
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

        public ParserState State
        {
            get
            {
                return _state;
            }

            protected set
            {
                if (_state != value)
                {
                    Debug.Assert(IsIncremental);
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
            _currentNode = _blendedTokens.LastCreatedItem.Blender.ReadNode();
        }

        protected GreenNode EatNode()
        {
            // we will fail anyways. Assert is just to catch that earlier.
            Debug.Assert(_blendedTokens != null);

            // remember result
            var result = CurrentNode.Green;
            RestoreParserState(_currentNode.Blender.State);
            _mode = _currentNode.Blender.Mode;

            // erase current state
            this.EraseState();

            return result;
        }

        protected virtual void EraseState()
        {
            _currentNode = default;
            _currentToken = default;
            _currentTokenErrors.Clear();
            _currentSkippedTokens.Clear();
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
            if (_blendedTokens != null)
            {
                return _blendedTokens.CurrentItem.Token;
            }
            else
            {
                return _lexedTokens.CurrentItem;
            }
        }

        protected virtual bool SlidingBuffer_ReadNewToken()
        {
            if (_blendedTokens != null)
            {
                if (_currentNode.Token != null)
                {
                    _blendedTokens.AddItem(_currentNode);
                }
                else
                {
                    var token = _blendedTokens.LastCreatedItem.Blender.ReadToken();
                    if (token.Token == null) return false;
                    _blendedTokens.AddItem(token);
                }
            }
            else
            {
                var token = Lexer.Lex(ref _mode);
                if (token == null) return false;
                _lexedTokens.AddItem(token);
            }
            return true;
        }

        protected void RegisterLookahead(int n)
        {
            _minLookahead = Math.Min(n, _minLookahead);
            _maxLookahead = Math.Max(n, _maxLookahead);
        }

        protected InternalSyntaxToken PeekToken(int n)
        {
            RegisterLookahead(n);
            return SlidingBuffer_PeekToken(n);
        }

        protected virtual InternalSyntaxToken SlidingBuffer_PeekToken(int n)
        {
            if (_blendedTokens != null)
            {
                return _blendedTokens.PeekItem(n).Token;
            }
            else
            {
                return _lexedTokens.PeekItem(n);
            }
        }

        //this method is called very frequently
        //we should keep it simple so that it can be inlined.
        protected InternalSyntaxToken EatToken()
        {
            var ct = this.EatCurrentToken();
            MoveToNextToken();
            return ct;
        }

        private InternalSyntaxToken EatCurrentToken()
        {
            var ct = this.CurrentToken;
            if (_currentSkippedTokens.Count > 0)
            {
                ct = AddSkippedSyntax(ct, _currentSkippedTokens.ToListNode(), false);
                _currentSkippedTokens.Clear();
            }
            if (_currentTokenErrors.Count > 0)
            {
                ct = WithAdditionalDiagnostics(ct, _currentTokenErrors.ToArray());
                _currentTokenErrors.Clear();
            }
            return ct;
        }

        protected void MoveToNextToken()
        {
            _prevTokenTrailingTrivia = _currentToken.GetTrailingTrivia();

            _currentToken = default;
            if (_blendedTokens != null) _currentNode = default;

            SlidingBuffer_EatItem();
        }

        protected virtual void SlidingBuffer_EatItem()
        {
            if (_blendedTokens != null)
            {
                _blendedTokens.EatItem();
                _mode = _blendedTokens.CurrentItem.Blender.Mode;
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

            var ct = this.EatCurrentToken();
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

            var ct = this.EatCurrentToken();
            if (ct.Kind == expected)
            {
                MoveToNextToken();
                return ct;
            }

            var replacement = CreateMissingToken(expected, this.CurrentToken.Kind, reportError: true);
            return AddTrailingSkippedSyntax(replacement, this.EatToken());
        }

        protected InternalSyntaxToken SkipToken()
        {
            var ct = this.CurrentToken;
            _currentSkippedTokens.Add(ct);
            MoveToNextToken();
            return ct;
        }

        protected InternalSyntaxToken CreateMissingToken(SyntaxKind expected)
        {
            var token = Language.InternalSyntaxFactory.MissingToken(expected);
            //SlidingBuffer_InsertItem(token);
            return token;
        }

        /*
        protected virtual InternalSyntaxToken SlidingBuffer_InsertItem(InternalSyntaxToken token)
        {
            if (_blendedTokens != null) _blendedTokens.InsertItem(new BlendedNode(null, token, default));
            else _lexedTokens.InsertItem(token);
            return token;
        }*/

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

        protected InternalSyntaxToken CreateMissingToken(SyntaxKind expected, ErrorCode code, bool reportError)
        {
            // should we eat the current ParseToken's leading trivia?
            var token = CreateMissingToken(expected);
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

        protected void AddErrorToCurrentToken(int position, int width, ErrorCode code)
        {
            this.AddErrorToCurrentToken(MakeError(position, width, code));
        }

        protected void AddErrorToCurrentToken(int position, int width, ErrorCode code, params object[] args)
        {
            this.AddErrorToCurrentToken(MakeError(position, width, code, args));
        }

        protected void AddErrorToCurrentToken(ErrorCode code)
        {
            this.AddErrorToCurrentToken(MakeError(code));
        }

        protected void AddErrorToCurrentToken(ErrorCode code, params object[] args)
        {
            this.AddErrorToCurrentToken(MakeError(code, args));
        }

        protected void AddErrorToCurrentToken(SyntaxDiagnosticInfo error)
        {
            if (error != null)
            {
                if (_currentTokenErrors == null)
                {
                    _currentTokenErrors = new List<SyntaxDiagnosticInfo>(8);
                }

                _currentTokenErrors.Add(error);
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
        protected bool IsMakingProgress(ref int lastTokenIndex)
        {
            var index = TokenIndex;
            if (index > lastTokenIndex)
            {
                lastTokenIndex = index;
                return true;
            }

            Debug.Assert(false);
            return false;
        }

        protected int TokenIndex => _blendedTokens != null ? _blendedTokens.Index : _lexedTokens.Index;
        protected int TokenCount => _blendedTokens != null ? _blendedTokens.Count : _lexedTokens.Count;
        protected InternalSyntaxToken LastCreatedToken => _blendedTokens != null ? _blendedTokens.LastCreatedItem.Token : _lexedTokens.LastCreatedItem;

        public static IncrementalTreeAnnotation GetTreeAnnotation(GreenNode node)
        {
            if (node == null) return null;
            var annot = node.GetAnnotations(IncrementalTreeAnnotationKind).FirstOrDefault();
            return annot?.ObjectData as IncrementalTreeAnnotation;
        }

        public static IncrementalNodeAnnotation GetNodeAnnotation(GreenNode node)
        {
            if (node == null) return null;
            var annot = node.GetAnnotations(IncrementalNodeAnnotationKind).FirstOrDefault();
            return annot?.ObjectData as IncrementalNodeAnnotation;
        }
    }

}
