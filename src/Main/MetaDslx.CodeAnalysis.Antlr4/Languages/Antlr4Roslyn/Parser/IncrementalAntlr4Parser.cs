using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using Microsoft.CodeAnalysis.Text;
using System;
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
    public abstract class IncrementalAntlr4Parser : MetaDslx.CodeAnalysis.Syntax.InternalSyntax.IncrementalParser, ITokenStream
    {
        private readonly IncrementalAntlr4Lexer _lexer;
        private readonly IncrementalParser _parser;
        private readonly Dictionary<ParserRuleContext, GreenNode> _nodeCache;
        private List<IToken> _tokens;
        private Stack<ResetPoint> _resetPoints;
        private string indent = string.Empty;

        public IncrementalAntlr4Parser(Language language, SourceText text, LanguageParseOptions options, LanguageSyntaxNode oldTree, IEnumerable<TextChangeRange> changes, CancellationToken cancellationToken = default) 
            : base(language, text, options, oldTree, changes, cancellationToken)
        {
            _nodeCache = new Dictionary<ParserRuleContext, GreenNode>();
            _lexer = (IncrementalAntlr4Lexer)language.InternalSyntaxFactory.CreateLexer(text, options, changes);
            _parser = (IncrementalParser)((IAntlr4SyntaxFactory)language.InternalSyntaxFactory).CreateAntlr4Parser(this);
            _parser._incrementalParser = this;
            //_parser.RemoveErrorListeners();
            _tokens = new List<IToken>();
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
            _nodeCache.Add(context, greenNode);
        }

        protected bool TryGetGreenNode(ParserRuleContext context, out GreenNode existingGreenNode)
        {
            return _nodeCache.TryGetValue(context, out existingGreenNode);
        }

        #region ITokenSource

        ITokenSource ITokenStream.TokenSource => ((ITokenStream)_lexer).TokenSource;

        IToken ITokenStream.Lt(int k)
        {
            if (k > 0)
            {
                return ((ITokenStream)this).Get(this.TokenIndex + k - 1);
            }
            else if (k < 0)
            {
                return ((ITokenStream)this).Get(this.TokenIndex + k);
            }
            else
            {
                return null;
            }
        }

        IToken ITokenStream.Get(int i)
        {
            var green = this.PeekToken(i - this.TokenIndex);
            if (green == null) return null;
            var token = new IncrementalToken(green.Kind.ToAntlr4(), green.Text);
            token.SetGreenToken(green);
            return token;
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
            this.EatToken();
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
                Debug.Assert(rp.Position == index);
                this.Reset(ref rp);
            }
            else
            {
                Debug.Assert(false);
            }
        }

        #endregion
    }
}
