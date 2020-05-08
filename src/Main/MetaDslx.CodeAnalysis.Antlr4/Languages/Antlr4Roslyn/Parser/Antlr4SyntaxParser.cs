using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using MetaDslx.Languages.Antlr4Roslyn.Compilation;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax
{
    public abstract class Antlr4SyntaxParser : SyntaxParser, ITokenStream, ITokenSource, IAntlrErrorListener<IToken>
    {
        private readonly Antlr4SyntaxLexer _lexer;
        private readonly IncrementalParser _parser;
        private readonly Dictionary<ParserRuleContext, GreenNode> _nodeCache;
        private Stack<(ResetPoint, SlidingBufferResetPoint)> _resetPoints;
        private SlidingBuffer<IncrementalToken> _tokens;

        public Antlr4SyntaxParser(Language language, SourceText text, LanguageParseOptions options, LanguageSyntaxNode oldTree, IEnumerable<TextChangeRange> changes, CancellationToken cancellationToken = default) 
            : base(language, text, options, oldTree, changes, cancellationToken)
        {
            _nodeCache = new Dictionary<ParserRuleContext, GreenNode>();
            _lexer = (Antlr4SyntaxLexer)this.Lexer;
            _parser = (IncrementalParser)((IAntlr4SyntaxFactory)language.InternalSyntaxFactory).CreateAntlr4Parser(this);
            _parser._incrementalParser = this;
            _parser.RemoveErrorListeners();
            _parser.AddErrorListener(this);
            _parser.ErrorHandler = new ErrorStrategy(this);
            _resetPoints = new Stack<(ResetPoint, SlidingBufferResetPoint)>();
            _tokens = new SlidingBuffer<IncrementalToken>(new IncrementalTokenSource(this));
        }

        protected IncrementalParser Parser => _parser;

        protected override ParserState SaveParserState(ParserState previousState)
        {
            var oldState = previousState as Antlr4ParserState;
            if (oldState == null || oldState.State != _parser.State) return new Antlr4ParserState(_parser.State);
            else return previousState;
        }

        protected override void RestoreParserState(ParserState state)
        {
            base.RestoreParserState(state);
            var newState = state as Antlr4ParserState;
            if (newState != null)
            {
                _parser.State = newState.State;
            }
        }

        protected void CacheGreenNode(ParserRuleContext context, GreenNode greenNode)
        {
            if (context != null) _nodeCache.Add(context, greenNode);
        }

        protected bool TryGetGreenNode(ParserRuleContext context, out GreenNode existingGreenNode)
        {
            if (context == null)
            {
                existingGreenNode = null;
                return false;
            }
            return _nodeCache.TryGetValue(context, out existingGreenNode);
        }

        #region ITokenSource

        ITokenSource ITokenStream.TokenSource => (ITokenSource)this;

        IToken ITokenStream.Lt(int k)
        {
            if (k > 0)
            {
                return ((ITokenStream)this).Get(_tokens.Index + k - 1);
            }
            else if (k < 0)
            {
                return ((ITokenStream)this).Get(_tokens.Index + k);
            }
            else
            {
                return null;
            }
        }

        IToken ITokenStream.Get(int i)
        {
            return _tokens.PeekItem(i - _tokens.Index);
        }

        string ITokenStream.GetText(Interval interval)
        {
            return ((ITokenStream)_lexer).GetText(interval);
        }

        string ITokenStream.GetText()
        {
            return ((ITokenStream)_lexer).GetText();
        }

        string ITokenStream.GetText(RuleContext ctx)
        {
            return ((ITokenStream)_lexer).GetText(ctx);
        }

        string ITokenStream.GetText(IToken start, IToken stop)
        {
            return ((ITokenStream)_lexer).GetText(start, stop);
        }

        #endregion

        #region IIntStream

        int IIntStream.Index => this.TokenIndex;

        int IIntStream.Size => this.TokenCount;

        string IIntStream.SourceName => ((ITokenStream)_lexer).SourceName;

        void IIntStream.Consume()
        {
            var green = this.EatToken();
            var token = _tokens.EatItem();
            token.SetGreenToken(green);
        }

        int IIntStream.La(int i)
        {
            if (i > 0) return this.PeekToken(i - 1).Kind.ToAntlr4();
            else if (i < 0) return this.PeekToken(i).Kind.ToAntlr4();
            else return -1;
        }

        int IIntStream.Mark()
        {
            var result = _resetPoints.Count;
            _resetPoints.Push((this.GetResetPoint(), _tokens.GetResetPoint()));
            return result;
        }

        void IIntStream.Release(int marker)
        {
            var index = _resetPoints.Count - 1;
            Debug.Assert(marker == index);
            var rp = _resetPoints.Pop();
            this.Release(ref rp.Item1);
            _tokens.Release(ref rp.Item2);
        }

        void IIntStream.Seek(int index)
        {
            if (_resetPoints.Count > 0)
            {
                var rp = _resetPoints.Peek();
                Debug.Assert(rp.Item1.Position == index);
                this.Reset(ref rp.Item1);
                _tokens.Reset(ref rp.Item2);
            }
            else
            {
                Debug.Assert(false);
            }
        }

        #endregion

        #region ITokenSource


        int ITokenSource.Line => throw new NotImplementedException();

        int ITokenSource.Column => throw new NotImplementedException();

        ICharStream ITokenSource.InputStream => throw new NotImplementedException();

        string ITokenSource.SourceName => throw new NotImplementedException();

        ITokenFactory ITokenSource.TokenFactory { get => (ITokenFactory)this; set => throw new NotImplementedException(); }

        IToken ITokenSource.NextToken()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IAntlrErrorListener

        void IAntlrErrorListener<IToken>.SyntaxError(IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            this.AddErrorToCurrentToken(Antlr4RoslynErrorCode.ERR_SyntaxError, msg);
        }

        #endregion

        #region ITokenFactory

        /*IToken ITokenFactory.Create(Tuple<ITokenSource, ICharStream> source, int type, string text, int channel, int start, int stop, int line, int charPositionInLine)
        {
            var green = CreateMissingToken(type.FromAntlr4(Language.SyntaxFacts.SyntaxKindType), Antlr4RoslynErrorCode.ERR_SyntaxError, false);
            if (green == null) return null;
            var token = new IncrementalToken(source, type, channel, start, stop);
            token.SetGreenToken(green);
            return token;
        }

        IToken ITokenFactory.Create(int type, string text)
        {
            var green = CreateMissingToken(type.FromAntlr4(Language.SyntaxFacts.SyntaxKindType), Antlr4RoslynErrorCode.ERR_SyntaxError, false);
            if (green == null) return null;
            var token = new IncrementalToken(type, green.Text);
            token.SetGreenToken(green);
            return token;
        }*/

        #endregion

        private class IncrementalTokenSource : IEnumerable<IncrementalToken>
        {
            private Antlr4SyntaxParser _parser;
            private int _index;

            public IncrementalTokenSource(Antlr4SyntaxParser parser)
            {
                _parser = parser;
                _index = 0;
            }

            public IEnumerator<IncrementalToken> GetEnumerator()
            {
                while (true)
                {
                    var green = _parser.PeekToken(_index - _parser.TokenIndex);
                    if (green == null) yield break;
                    else yield return new IncrementalToken(green.Kind.ToAntlr4(), green.Text);
                    ++_index;
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
        }

        private class ErrorStrategy : DefaultErrorStrategy
        {
            private Antlr4SyntaxParser _parser;

            public ErrorStrategy(Antlr4SyntaxParser parser)
            {
                _parser = parser;
            }

            [return: Nullable]
            protected override IToken SingleTokenDeletion([NotNull] Parser recognizer)
            {
                int nextTokenType = ((ITokenStream)recognizer.InputStream).La(2);
                IntervalSet expecting = GetExpectedTokens(recognizer);
                if (expecting.Contains(nextTokenType))
                {
                    ReportUnwantedToken(recognizer);
                    // simply delete extra token
                    _parser.SkipToken();
                    _parser._tokens.EatItem();
                    var matchedSymbol = _parser._tokens.CurrentItem;
                    // we want to return the token we're actually matching
                    ReportMatch(recognizer);
                    // we know current token is correct
                    return matchedSymbol;
                }
                return null;
            }

            protected override bool SingleTokenInsertion([NotNull] Parser recognizer)
            {
                int currentSymbolType = ((ITokenStream)recognizer.InputStream).La(1);
                // if current token is consistent with what could come after current
                // ATN state, then we know we're missing a token; error recovery
                // is free to conjure up and insert the missing token
                ATNState currentState = recognizer.Interpreter.atn.states[recognizer.State];
                ATNState next = currentState.Transition(0).target;
                ATN atn = recognizer.Interpreter.atn;
                PredictionContext predictionContext = PredictionContext.FromRuleContext(atn, recognizer.RuleContext);
                IntervalSet expectingAtLL2 = atn.NextTokens(next,  predictionContext);
                if (expectingAtLL2.Contains(currentSymbolType))
                {
                    ReportMissingToken(recognizer);
                    return true;
                }
                return false;
            }

            protected override IToken ConstructToken(ITokenSource tokenSource, int expectedTokenType, string tokenText, IToken current)
            {
                var green = _parser.CreateMissingToken(expectedTokenType.FromAntlr4(_parser.Language.SyntaxFacts.SyntaxKindType), current.Type.FromAntlr4(_parser.Language.SyntaxFacts.SyntaxKindType), true);
                var missingToken = new IncrementalToken(green.Kind.ToAntlr4(), green.Text);
                missingToken.SetGreenToken(green);
                _parser._tokens.InsertItem(missingToken);
                return _parser._tokens.EatItem();
            }
        }
    }
}
