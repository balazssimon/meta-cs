using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.InternalUtilities;
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
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax
{
    public abstract partial class Antlr4SyntaxParser : SyntaxParser<IncrementalToken>, ITokenStream, ITokenSource, IAntlrErrorListener<IToken>
    {
        private readonly Antlr4SyntaxLexer _lexer;
        private readonly IncrementalParser _parser;
        private readonly Dictionary<ParserRuleContext, GreenNode> _nodeCache;
        private Stack<ResetPoint> _resetPoints;
        private bool _matchedToken;

        public Antlr4SyntaxParser(Language language, SourceText text, LanguageParseOptions options, LanguageSyntaxNode oldTree, IEnumerable<TextChangeRange> changes, CancellationToken cancellationToken = default)
            : base(language, text, options, oldTree, changes, cancellationToken)
        {
            _nodeCache = new Dictionary<ParserRuleContext, GreenNode>();
            _lexer = (Antlr4SyntaxLexer)this.Lexer;
            _parser = (IncrementalParser)((IAntlr4SyntaxFactory)language.InternalSyntaxFactory).CreateAntlr4Parser(this);
            _parser._incrementalParser = this;
            _parser.RemoveErrorListeners();
            _parser.AddErrorListener(this);
            _parser.ErrorHandler = new Antlr4ErrorStrategy(this);
            _resetPoints = new Stack<ResetPoint>();
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

        protected override IncrementalToken CreateCustomToken(InternalSyntaxToken green)
        {
            var token = new IncrementalToken(green.Kind.ToAntlr4(), green.Kind == SyntaxKind.Eof ? "<EOF>" : green.Text);
            token.SetGreenToken(green);
            token.TokenIndex = this.TokenCount;
            token.StartIndex = Lexer.Position - green.FullWidth + green.GetLeadingTriviaWidth();
            token.StopIndex = Lexer.Position - green.GetTrailingTriviaWidth() - 1;
            return token;
        }

        #region ITokenStream

        ITokenSource ITokenStream.TokenSource => null;// (ITokenSource)this;

        IToken ITokenStream.LT(int k)
        {
            if (k > 0) return this.PeekCustomToken(k - 1) ?? Antlr4SyntaxLexer.InvalidToken;
            else if (k < 0) return this.PeekCustomToken(k) ?? Antlr4SyntaxLexer.InvalidToken;
            else return Antlr4SyntaxLexer.InvalidToken;
        }

        IToken ITokenStream.Get(int i)
        {
            return this.PeekCustomToken(i - this.TokenIndex);
        }

        string ITokenStream.GetText(Interval interval)
        {
            if (interval.b < interval.a) return string.Empty;
            else return this.Text.ToString(TextSpan.FromBounds(interval.a, interval.b + 1));
        }

        string ITokenStream.GetText()
        {
            return this.Text.ToString();
        }

        string ITokenStream.GetText(RuleContext ctx)
        {
            if (ctx.SourceInterval.b < ctx.SourceInterval.a) return string.Empty;
            else return this.Text.ToString(TextSpan.FromBounds(ctx.SourceInterval.a, ctx.SourceInterval.b + 1));
        }

        string ITokenStream.GetText(IToken start, IToken stop)
        {
            if (stop.StopIndex < start.StartIndex) return string.Empty;
            else return this.Text.ToString(TextSpan.FromBounds(start.StartIndex, stop.StopIndex + 1));
        }

        #endregion

        #region IIntStream

        int IIntStream.Index => this.TokenIndex;

        int IIntStream.Size => this.TokenCount;

        string IIntStream.SourceName => ((ITokenStream)_lexer).SourceName;

        void IIntStream.Consume()
        {
            var token = this.GetCurrentCustomToken();
            if (token != null)
            {
                token.TokenIndex = this.TokenIndex;
                var green = _matchedToken ? this.EatToken() : this.SkipToken();
                //var green = this.EatToken();
                token.SetGreenToken(green);
            }
            _matchedToken = false;
        }

        int IIntStream.LA(int i)
        {
            if (i > 0) return this.PeekCustomToken(i - 1)?.Type ?? 0;
            else if (i < 0) return this.PeekCustomToken(i)?.Type ?? 0;
            else return 0;
        }

        int IIntStream.Mark()
        {
            var result = _resetPoints.Count;
            _resetPoints.Push(this.GetResetPoint());
            return result;
        }

        void IIntStream.Release(int marker)
        {
            var index = _resetPoints.Count - 1;
            Debug.Assert(marker == index);
            var rp = _resetPoints.Pop();
            this.Release(ref rp);
        }

        void IIntStream.Seek(int index)
        {
            if (_resetPoints.Count > 0)
            {
                var rp = _resetPoints.Peek();
                Debug.Assert(rp.Index == index);
                this.Reset(ref rp);
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

        void IAntlrErrorListener<IToken>.SyntaxError(TextWriter output, IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            this.AddError(offendingSymbol.StartIndex, offendingSymbol.StopIndex - offendingSymbol.StartIndex + 1, Antlr4RoslynErrorCode.ERR_SyntaxError, msg);
            CallLogger.Instance.Log("  Parser error: " + msg);
        }

        #endregion
    }
}
