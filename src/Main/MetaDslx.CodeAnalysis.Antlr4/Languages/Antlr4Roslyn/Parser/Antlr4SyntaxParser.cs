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
        private readonly Antlr4Parser _parser;
        private readonly Dictionary<ParserRuleContext, GreenNode> _nodeCache;
        private Stack<ResetPoint> _resetPoints;
        private bool _matchedToken;

        public Antlr4SyntaxParser(Language language, SourceText text, LanguageParseOptions options, LanguageSyntaxNode? oldTree, ParseData? oldParseData, IEnumerable<TextChangeRange>? changes, CancellationToken cancellationToken = default)
            : base(language, text, options, oldTree, oldParseData, changes, cancellationToken)
        {
            _nodeCache = new Dictionary<ParserRuleContext, GreenNode>();
            _lexer = (Antlr4SyntaxLexer)this.Lexer;
            _parser = ((IAntlr4SyntaxFactory)language.InternalSyntaxFactory).CreateAntlr4Parser(this);
            _parser._incrementalParser = this;
            _parser.RemoveErrorListeners();
            _parser.AddErrorListener(this);
            _parser.ErrorHandler = new Antlr4ErrorStrategy(this);
            _resetPoints = new Stack<ResetPoint>();
        }

        protected Antlr4Parser Antlr4Parser => _parser;

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

        protected override IncrementalToken CreateCustomToken(InternalSyntaxToken green, int index, int position)
        {
            var token = new IncrementalToken(green.Kind.ToAntlr4(), green.Kind == SyntaxKind.Eof ? "<EOF>" : green.Text);
            token.SetGreenToken(green);
            token.TokenIndex = index;
            token.StartIndex = position + green.GetLeadingTriviaWidth();
            token.StopIndex = token.StartIndex + green.Width - 1;
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
            else return this.SourceText.ToString(TextSpan.FromBounds(interval.a, interval.b + 1));
        }

        string ITokenStream.GetText()
        {
            return this.SourceText.ToString();
        }

        string ITokenStream.GetText(RuleContext ctx)
        {
            if (ctx.SourceInterval.b < ctx.SourceInterval.a) return string.Empty;
            else return this.SourceText.ToString(TextSpan.FromBounds(ctx.SourceInterval.a, ctx.SourceInterval.b + 1));
        }

        string ITokenStream.GetText(IToken start, IToken stop)
        {
            if (stop.TokenIndex < start.TokenIndex) return string.Empty;
            if (start.TokenIndex == stop.TokenIndex) return this.PeekCustomToken(0).Text;
            var sb = new StringBuilder();
            for (int i = start.TokenIndex; i <= stop.TokenIndex; i++)
            {
                var token = this.PeekToken(i - this.TokenIndex);
                if (i == start.TokenIndex) sb.Append(token.TokenWithLeadingTrivia(null).ToFullString());
                else if (i == stop.TokenIndex) sb.Append(token.TokenWithTrailingTrivia(null).ToFullString());
                else sb.Append(token.ToFullString());
            }
            return sb.ToString();
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
            IToken startToken;
            IToken endToken;
            if (e is NoViableAltException nvae)
            {
                startToken = nvae.StartToken;
                endToken = nvae.OffendingToken;
            }
            else
            {
                startToken = offendingSymbol;
                endToken = offendingSymbol;
            }
            var greenStart = ((IncrementalToken)startToken).GreenToken;
            var greenEnd = ((IncrementalToken)endToken).GreenToken;
            var position = startToken.StartIndex;
            var width = Math.Max(endToken.StopIndex - startToken.StartIndex + 1, 0);
            this.AddError(position, width, Antlr4RoslynErrorCode.ERR_SyntaxError, msg);
            CallLogger.Instance.Log("  Parser error: " + msg);
        }

        #endregion

        protected override ParserStateManager? CreateStateManager()
        {
            return new Antlr4ParserStateManager(this);
        }

        protected class Antlr4ParserStateManager : ParserStateManager
        {
            public Antlr4ParserStateManager(Antlr4SyntaxParser parser)
                : base(parser)
            {
            }

            public new Antlr4SyntaxParser Parser => (Antlr4SyntaxParser)base.Parser;
            public Antlr4Parser Antlr4Parser => Parser.Antlr4Parser;

            protected override int ComputeStateHash()
            {
                return this.Antlr4Parser.State.GetHashCode();
            }

            protected override bool IsInState(ParserState? state)
            {
                var antlr4Parser = Antlr4Parser;
                if (state == null) return antlr4Parser.State == -1;
                var antlr4State = (Antlr4ParserState)state;
                if (antlr4Parser.State != antlr4State.State) return false;
                return true;
            }

            protected override void RestoreState(ParserState? state)
            {
                var antlr4State = state as Antlr4ParserState;
                var antlr4Parser = Antlr4Parser;
                if (antlr4State != null)
                {
                    antlr4Parser.State = antlr4State.State;
                }
                else
                {
                    antlr4Parser.State = -1;
                }
            }

            protected override ParserState? SaveState(int hashCode)
            {
                var antlr4Parser = Antlr4Parser;
                if (antlr4Parser.State == -1) return null;
                else return new Antlr4ParserState(hashCode, antlr4Parser.State);
            }
        }
    }
}
