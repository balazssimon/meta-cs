using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;

namespace MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax
{
    public class IncrementalAntlr4Lexer : IncrementalLexer, IAntlr4Lexer, ITokenStream
    {
        private const int SaveStateWindow = 1;

        private readonly IncrementalInputStream _stream;
        private readonly SourceText _text;
        private readonly Antlr4.Runtime.Lexer _lexer;
        private readonly IncrementalAntlr4Lexer _oldLexer;
        private readonly RangeEdgeState _beforeChange;
        private readonly RangeEdgeState _afterChange;

        private readonly SyntaxFacts _syntaxFacts;
        private readonly InternalSyntaxFactory _syntaxFactory;
        private readonly List<(IToken Antlr4Token, InternalSyntaxToken RoslynToken)> _tokens;
        private readonly List<(int position, int index, Antlr4LexerState state)> _states;
        private readonly bool _isIncremental;
        private IToken _lastToken;
        private int _lastFetchedPosition;
        private bool _fetchedEof;
        private int _index;
        private int _position;
        private Antlr4LexerState _currentState;

        public IncrementalAntlr4Lexer(Language language, SourceText text, ImmutableArray<TextChangeRange> changes, IncrementalAntlr4Lexer oldLexer)
            : base(language, text, oldLexer, changes)
        {
            _stream = oldLexer != null ? new IncrementalInputStream(text, oldLexer._stream.OverallMinMaxLookahead) : new IncrementalInputStream(text);
            _text = text;
            _lexer = ((IAntlr4SyntaxFactory)language.InternalSyntaxFactory).CreateAntlr4Lexer(_stream);
            _syntaxFacts = language.SyntaxFacts;
            _syntaxFactory = language.InternalSyntaxFactory;
            _tokens = new List<(IToken, InternalSyntaxToken)>();
            _index = 0;
            _position = 0;
            _fetchedEof = false;
            _oldLexer = oldLexer;
            _states = new List<(int, int, Antlr4LexerState)>();

            if (changes != null && oldLexer != null)
            {
                // TODO: Consider implementing NormalizedChangeCollection for TextSpan. the real
                // reason why we are collapsing is because we want to extend change ranges and
                // cannot allow them to overlap. This does not seem to be a big deal since multiple
                // changes are infrequent and typically close to each other. However if we have
                // NormalizedChangeCollection for TextSpan we can have both - we can extend ranges
                // and not require collapsing them. NormalizedChangeCollection would also ensure
                // that changes are always normalized.

                // TODO: this is a temporary measure to prevent individual change spans from
                // overlapping after they are widened to effective width (+1 token at the start).
                // once we have normalized collection for TextSpan we will not need to collapse all
                // the change spans.
                var collapsed = TextChangeRange.Collapse(changes);

                // extend the change to its affected range. This will make it easier 
                // to filter out affected nodes since we will be able simply check 
                // if node intersects with a change.
                (_beforeChange, _afterChange) = ComputeChange(oldLexer, collapsed);

                _isIncremental = true;
            }
        }

        public int Count
        {
            get
            {
                FetchAllTokens();
                return _tokens.Count;
            }
        }

        public Antlr4.Runtime.Lexer Antlr4Lexer => _lexer;

        ITokenSource ITokenStream.TokenSource => _lexer;

        int IIntStream.Index => _index;

        int IIntStream.Size => this.Count;

        string IIntStream.SourceName => _lexer.SourceName;

        public override InternalSyntaxToken Lex()
        {
            return ReadNextToken().RoslynToken;
        }

        private (IToken Antlr4Token, InternalSyntaxToken RoslynToken) ReadNextToken()
        {
            EnsureTokensFetchedAtIndex(_index);
            if (_index < 0 || _index >= _tokens.Count) return (null, null);
            var result = _tokens[_index];
            _position += result.RoslynToken?.FullWidth ?? 0;
            ++_index;
            return result;
        }

        private bool EndsWithLineEnd(IToken token)
        {
            var text = token.Text;
            return text != null && (text.EndsWith("\r") || text.EndsWith("\n"));
        }

        public object GetState(int index)
        {
            var state = FindStateAtIndex(index);
            return state.state;
        }

        public void RestoreState(object state)
        {
            if (state == null) throw new ArgumentNullException(nameof(state));
            if (state is Antlr4LexerState antlr4LexerState)
            {
                _lexer._mode = antlr4LexerState.Mode;
                _lexer._modeStack.Clear();
                _lexer._modeStack.AddRange(antlr4LexerState.ModeStack);
            }
            else throw new ArgumentException($"Invalid state type '{state.GetType()}' for IncrementalAntlr4Lexer", nameof(state));
        }

        private void EnsureTokensFetchedAtIndex(int index)
        {
            while (!_fetchedEof && index >= _tokens.Count) Fetch();
        }

        private void EnsureTokensFetchedAtPosition(int position)
        {
            while (!_fetchedEof && position > _lastFetchedPosition) Fetch();
        }

        private void FetchAllTokens()
        {
            while (!_fetchedEof) Fetch();
        }

        private void Fetch()
        {
            if (_position == 0) SaveState();
            if (_isIncremental)
            {
                if (_position < _beforeChange.Position || _position >= _afterChange.Position)
                {
                    if (_position == 0)
                    {
                        _oldLexer.Seek(0);
                    }
                    if (_position == _afterChange.Position)
                    {
                        _oldLexer.Seek(_afterChange.Index);
                    }
                    this.FetchFromOldLexer();
                }
                else
                {
                    if (_position == _beforeChange.Position)
                    {
                        _lexer.InputStream.Seek(_beforeChange.Position);
                        RestoreState(_beforeChange.State);
                    }
                    this.FetchFromNewLexer();
                }
            }
            else
            {
                this.FetchFromNewLexer();
            }
            SaveState();
        }

        private void FetchFromNewLexer()
        {
            if (_fetchedEof) return;
            Console.WriteLine("NewLexer:");
            var token = _lastToken ?? _lexer.NextToken();
            var leadingTriviaBuilder = ArrayBuilder<InternalSyntaxTrivia>.GetInstance();
            while (token != null && token.Type >= 0 && (token.Channel != 0 || string.IsNullOrWhiteSpace(token.Text)))
            {
                var triviaKind = token.Type.FromAntlr4(_syntaxFacts.SyntaxKindType);
                var trivia = _syntaxFactory.Trivia(triviaKind, token.Text);
                leadingTriviaBuilder.Add(trivia);
                token = _lexer.NextToken();
            }
            var leadingTriviaArray = leadingTriviaBuilder.ToArrayAndFree();
            var leadingTrivia = leadingTriviaArray.Length > 0 ? _syntaxFactory.List(leadingTriviaArray).Node : null;
            InternalSyntaxToken result;
            if (token == null || token.Type < 0)
            {
                result = _syntaxFactory.EndOfFile;
                _fetchedEof = true;
                if (leadingTrivia != null) result = (InternalSyntaxToken)result.WithLeadingTrivia(leadingTrivia);
            }
            else
            {
                _lastToken = token;
                bool reachedLineEnd = EndsWithLineEnd(_lastToken);
                var trailingTriviaBuilder = ArrayBuilder<InternalSyntaxTrivia>.GetInstance();
                _lastToken = _lexer.NextToken();
                while (_lastToken != null && _lastToken.Type >= 0 && (_lastToken.Channel != 0 || string.IsNullOrWhiteSpace(_lastToken.Text)) && !reachedLineEnd)
                {
                    if (EndsWithLineEnd(_lastToken)) reachedLineEnd = true;
                    var triviaKind = _lastToken.Type.FromAntlr4(_syntaxFacts.SyntaxKindType);
                    var trivia = _syntaxFactory.Trivia(triviaKind, _lastToken.Text);
                    trailingTriviaBuilder.Add(trivia);
                    _lastToken = _lexer.NextToken();
                }
                var trailingTriviaArray = trailingTriviaBuilder.ToArrayAndFree();
                var trailingTrivia = trailingTriviaArray.Length > 0 ? _syntaxFactory.List(trailingTriviaArray).Node : null;
                var kind = token.Type.FromAntlr4(_syntaxFacts.SyntaxKindType);
                if (this.Language.SyntaxFacts.IsFixedToken(kind))
                {
                    result = _syntaxFactory.Token(leadingTrivia, kind, trailingTrivia);
                }
                else
                {
                    string text = token.Text;
                    var value = this.Language.SyntaxFacts.ExtractValue(text);
                    result = _syntaxFactory.Token(leadingTrivia, kind, text, value, trailingTrivia);
                }
            }
            _tokens.Add((token, result));
            _lastFetchedPosition += result.FullWidth;
        }

        private int LastSaveIndex => _states.Count > 0 ? _states[_states.Count - 1].index : 0;

        private void SaveState(bool force = false)
        {
            if (_currentState == null)
            {
                _currentState = CreateState();
                _states.Add((_index, _lastFetchedPosition, _currentState));
            }
            else if (!_currentState.HasChanged(this))
            {
                _currentState = CreateState();
                _states.Add((_index, _lastFetchedPosition, _currentState));
            }
        }

        protected virtual Antlr4LexerState CreateState()
        {
            return new Antlr4LexerState(this);
        }

        private void FetchFromOldLexer()
        {
            if (_fetchedEof) return;
            Console.WriteLine("OldLexer:");
            var token = _oldLexer.ReadNextToken();
            _tokens.Add(token); // TODO: update ANTLR4 index and position
            if (token.RoslynToken.Kind == SyntaxKind.Eof) _fetchedEof = true;
            _lastToken = null;
            _lastFetchedPosition += token.RoslynToken?.FullWidth ?? 0;
        }

        private (IToken Antlr4Token, InternalSyntaxToken RoslynToken) GetToken(int index)
        {
            EnsureTokensFetchedAtIndex(index);
            if (index < 0 || index >= _tokens.Count) return (null, null);
            return _tokens[index];
        }

        public void Seek(int index)
        {
            EnsureTokensFetchedAtIndex(index);
            _index = index;
            _position = GetPositionAtIndex(index);
        }

        IToken ITokenStream.Lt(int k)
        {
            return ((ITokenStream)this).Get(_index + k);
        }

        IToken ITokenStream.Get(int i)
        {
            if (i < 0) return null;
            EnsureTokensFetchedAtIndex(i);
            if (i < _tokens.Count) return _tokens[i].Antlr4Token;
            else return null;
        }

        string ITokenStream.GetText(Interval interval)
        {
            var start = ((ITokenStream)this).Get(interval.a)?.StartIndex ?? -1;
            var stop = ((ITokenStream)this).Get(interval.b)?.StopIndex ?? -1;
            return GetText(start, stop);
        }

        string ITokenStream.GetText()
        {
            return _text.ToString();
        }

        string ITokenStream.GetText(RuleContext ctx)
        {
            var start = ((ITokenStream)this).Get(ctx.SourceInterval.a)?.StartIndex ?? -1;
            var stop = ((ITokenStream)this).Get(ctx.SourceInterval.b)?.StopIndex ?? -1;
            return GetText(start, stop);
        }

        string ITokenStream.GetText(IToken startToken, IToken stopToken)
        {
            var start = startToken?.StartIndex ?? -1;
            var stop = stopToken?.StartIndex ?? -1;
            return GetText(start, stop);
        }

        private string GetText(int start, int stop)
        {
            if (start >= 0 && start <= stop) return _text.GetSubText(new TextSpan(start, stop - start + 1)).ToString();
            else return null;
        }

        void IIntStream.Consume()
        {
            Lex();
        }

        int IIntStream.La(int i)
        {
            return ((ITokenStream)this).Get(_index + i)?.Type ?? -1;
        }

        int IIntStream.Mark()
        {
            // do nothing: we have buffering
            return -1;
        }

        void IIntStream.Release(int marker)
        {
            // do nothing: we have buffering
        }

        void IIntStream.Seek(int index)
        {
            this.Seek(index);
        }

        /// <summary>
        /// Affected range of a change is the range within which nodes can be affected by a change
        /// and cannot be reused. Because of lookahead effective range of a change is larger than
        /// the change itself.
        /// </summary>
        private static (RangeEdgeState, RangeEdgeState) ComputeChange(IncrementalAntlr4Lexer oldLexer, TextChangeRange changeRange)
        {
            var oldStream = oldLexer._stream;
            var minMaxLookahead = oldStream.OverallMinMaxLookahead;
            var start = changeRange.Span.Start;
            if (minMaxLookahead.a < 0) start = Math.Max(changeRange.Span.Start + minMaxLookahead.a, 0);
            var end = changeRange.Span.End;
            if (minMaxLookahead.b > 0) end = Math.Min(changeRange.Span.End + minMaxLookahead.b, oldLexer.SourceText.Length);

            var startIndex = oldLexer.GetIndexAtPosition(start);
            var endIndex = oldLexer.GetIndexAtPosition(end) + 1;
            var startPosition = oldLexer.GetPositionAtIndex(startIndex);
            var endPosition = oldLexer.GetPositionAtIndex(endIndex);
            var lastTokenBeforeChange = oldLexer.GetToken(startIndex);
            var firstTokenAfterChange = oldLexer.GetToken(endIndex);

            var finalLength = changeRange.NewLength + (changeRange.Span.Start - startPosition) + (endPosition - changeRange.Span.End);

            RangeEdgeState beforeChange;
            RangeEdgeState afterChange;
            if (lastTokenBeforeChange.Antlr4Token != null) beforeChange = new RangeEdgeState(startIndex, startPosition, oldLexer.GetState(startIndex));
            else beforeChange = new RangeEdgeState(0, 0, oldLexer.GetState(0));
            if (firstTokenAfterChange.Antlr4Token != null) afterChange = new RangeEdgeState(endIndex, startPosition + finalLength, oldLexer.GetState(endIndex));
            else afterChange = new RangeEdgeState(oldLexer.Count, oldLexer.SourceText.Length, oldLexer.GetState(oldLexer.Count));

            return (beforeChange, afterChange);
        }

        private int GetPositionAtIndex(int index)
        {
            EnsureTokensFetchedAtIndex(index);
            var state = FindStateAtIndex(index);
            var currentIndex = state.index;
            if (currentIndex < 0) return -1;
            var currentPosition = state.position;
            while (currentIndex < index && currentIndex < _tokens.Count)
            {
                currentPosition += _tokens[currentIndex].RoslynToken.FullWidth;
                ++currentIndex;
            }
            if (currentIndex < index) return -1;
            else return currentPosition;
        }

        private int GetIndexAtPosition(int position)
        {
            EnsureTokensFetchedAtPosition(position);
            var state = FindStateAtPosition(position);
            var currentIndex = state.index;
            if (currentIndex < 0) return -1;
            var currentPosition = state.position;
            while (currentPosition < position && currentIndex < _tokens.Count)
            {
                currentPosition += _tokens[currentIndex].RoslynToken.FullWidth;
                if (currentPosition > position) return currentIndex;
                ++currentIndex;
            }
            return currentIndex;
        }

        private (int position, int index, Antlr4LexerState state) FindStateAtPosition(int position)
        {
            if (position < 0) return (-1, -1, null);
            EnsureTokensFetchedAtPosition(position);
            if (position > _lastFetchedPosition) return _states[_states.Count - 1];
            int low = 0;
            int high = _states.Count - 1;
            while (low <= high)
            {
                var middle = (low + high) / 2;
                var middleState = _states[middle];
                if (middleState.position < position)
                {
                    low = middle + 1;
                }
                else if (middleState.position > position)
                {
                    high = middle - 1;
                }
                else
                {
                    return middleState;
                }
            }
            if (low < _states.Count && _states[low].position <= position) return _states[low];
            --low;
            if (low >= 0 && low < _states.Count && _states[low].position <= position) return _states[low];
            else return (-1, -1, null);
        }

        private (int position, int index, Antlr4LexerState state) FindStateAtIndex(int index)
        {
            if (index < 0) return (-1, -1, null);
            EnsureTokensFetchedAtIndex(index);
            if (index >= _tokens.Count) return _states[_states.Count - 1];
            int low = 0;
            int high = _states.Count - 1;
            while (low <= high)
            {
                var middle = (low + high) / 2;
                var middleState = _states[middle];
                if (middleState.index < index)
                {
                    low = middle + 1;
                }
                else if (middleState.index > index)
                {
                    high = middle - 1;
                }
                else
                {
                    return middleState;
                }
            }
            if (low < _states.Count && _states[low].index <= index) return _states[low];
            --low;
            if (low >= 0 && low < _states.Count && _states[low].index <= index) return _states[low];
            else return (-1, -1, null);
        }

        private struct RangeEdgeState
        {
            public readonly int Index;
            public readonly int Position;
            public readonly object State;

            public RangeEdgeState(int index, int position, object state)
            {
                Index = index;
                Position = position;
                State = state;
            }
        }
    }
}
