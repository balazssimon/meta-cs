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
    public abstract class IncrementalAntlr4Parser : MetaDslx.CodeAnalysis.Syntax.InternalSyntax.IncrementalParser, ITokenStream, IParseTreeListener
    {
        private readonly IncrementalAntlr4Lexer _lexer;
        private readonly IncrementalParser _parser;
        private readonly Dictionary<IncrementalParserRuleContext, GreenNode> _nodeCache;
        private int _currentState;
        private bool _disableIncrementalContext;
        private List<IToken> _tokens;
        private Stack<ResetPoint> _resetPoints;

        public IncrementalAntlr4Parser(Language language, SourceText text, LanguageParseOptions options, LanguageSyntaxNode oldTree, IEnumerable<TextChangeRange> changes, CancellationToken cancellationToken = default) 
            : base(language, text, options, oldTree, changes, cancellationToken)
        {
            _nodeCache = new Dictionary<IncrementalParserRuleContext, GreenNode>();
            _lexer = (IncrementalAntlr4Lexer)language.InternalSyntaxFactory.CreateLexer(text, options, changes);
            _parser = (IncrementalParser)((IAntlr4SyntaxFactory)language.InternalSyntaxFactory).CreateAntlr4Parser(this);
            _parser._incrementalParser = this;
            //_parser.RemoveErrorListeners();
            _parser.AddParseListener(this);
            _currentState = -1;
            _tokens = new List<IToken>();
            _resetPoints = new Stack<ResetPoint>();
        }

        protected IncrementalParser Parser => _parser;

        protected override ParserState SaveParserState(ParserState previousState)
        {
            var oldState = previousState as Antlr4ParserState;
            if (oldState == null || oldState.Mode != Mode || oldState.State != _currentState) return new Antlr4ParserState(Mode, _currentState);
            else return previousState;
        }

        protected override void RestoreParserState(ParserState state)
        {
            base.RestoreParserState(state);
            var newState = state as Antlr4ParserState;
            if (newState != null)
            {
                _currentState = newState.State;
            }
        }

        public bool TryGetIncrementalContext<TContext>(ParserRuleContext parentContext, int state, int ruleIndex, out TContext existingContext)
            where TContext : ParserRuleContext
        {
            if (!IsIncremental || state != _currentState)
            {
                existingContext = null;
                return false;
            }
            else
            {
                var incrementalContext = (TContext)GetIncrementalContext(parentContext, state, ruleIndex);
                if (incrementalContext != null)
                {
                    existingContext = incrementalContext;
                    return true;
                }
                else
                {
                    existingContext = null;
                    return false;
                }
            }
        }

        protected abstract ParserRuleContext GetIncrementalContext(ParserRuleContext parent, int invokingState, int ruleIndex);

        protected void CacheGreenNode(IncrementalParserRuleContext context, GreenNode greenNode)
        {
            _nodeCache.Add(context, greenNode);
        }

        protected bool TryGetGreenNode(IncrementalParserRuleContext context, out GreenNode existingGreenNode)
        {
            return _nodeCache.TryGetValue(context, out existingGreenNode);
        }

        protected override void TokenAdded(InternalSyntaxToken token, bool incremental)
        {
            var index = this.TokenCount - 1;
            if (incremental) _tokens.Add(null);
            else _tokens.Add(((ITokenStream)_lexer).Get(index));
        }

        protected IToken GetAntlr4TokenAt(int index)
        {
            var result = _tokens[index];
            if (result == null)
            {
                result = ((ITokenStream)_lexer).Get(index);
                _tokens[index] = result;
            }
            return result;
        }

        #region ITokenSource

        ITokenSource ITokenStream.TokenSource => ((ITokenStream)_lexer).TokenSource;

        IToken ITokenStream.Lt(int k)
        {
            if (k > 0)
            {
                this.PeekToken(k - 1);
                return ((ITokenStream)this).Get(this.TokenIndex + k - 1);
            }
            else if (k < 0)
            {
                this.PeekToken(k);
                return ((ITokenStream)this).Get(this.TokenIndex + k);
            }
            else
            {
                return null;
            }
        }

        IToken ITokenStream.Get(int i)
        {
            return GetAntlr4TokenAt(i);
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

        int IIntStream.Index => this.TokenOffset;

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
            this.Seek(index);
        }

        void IParseTreeListener.VisitTerminal(ITerminalNode node)
        {
            
        }

        void IParseTreeListener.VisitErrorNode(IErrorNode node)
        {
            
        }

        void IParseTreeListener.EnterEveryRule(ParserRuleContext ctx)
        {
            _currentState = ctx.invokingState;
        }

        void IParseTreeListener.ExitEveryRule(ParserRuleContext ctx)
        {
        }

        #endregion
    }
}
