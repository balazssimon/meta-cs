using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using System.Threading;

namespace MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax
{
    public abstract class IncrementalAntlr4Parser : SyntaxParser, IParseTreeListener
    {
        private readonly IncrementalAntlr4Lexer _lexer;
        private readonly Parser _parser;
        private readonly bool _isIncremental;
        private readonly IncrementalAntlr4Parser _oldParser;
        private readonly int _version;
        private SyntaxNode _syntaxTree;
        private Dictionary<(int depth, int state, int ruleIndex, int currentTokenIndex), IncrementalParserRuleContext> _ruleStartMap;

        public IncrementalAntlr4Parser(Language language, SourceText text, LanguageParseOptions options, ImmutableArray<TextChangeRange> changes, IncrementalAntlr4Parser oldParser, CancellationToken cancellationToken = default)
            : base(text, language, options, oldParser?._syntaxTree, changes, cancellationToken)
        {
            _isIncremental = changes.Length > 0 && oldParser != null;
            _version = _isIncremental ? oldParser._version + 1 : 1;
            _oldParser = oldParser;
            _lexer = new IncrementalAntlr4Lexer(language, text, changes, oldParser?.Lexer, cancellationToken);
            _parser = ((IAntlr4SyntaxFactory)language.InternalSyntaxFactory).CreateAntlr4Parser(_lexer);
            ((IncrementalParser)_parser)._incrementalParser = this;
            _parser.AddParseListener(this);
            _ruleStartMap = new Dictionary<(int depth, int state, int ruleIndex, int currentTokenIndex), IncrementalParserRuleContext>();
        }

        public IncrementalAntlr4Lexer Lexer => _lexer;

        public Parser Antlr4Parser => _parser;

        public int CurrentTokenIndex => _lexer.Index;

        public override DirectiveStack Directives => DirectiveStack.Empty;

        public bool TryGetContext<TContext>(int depth, int state, int ruleIndex, int currentTokenIndex, out TContext existingContext)
            where TContext : IncrementalParserRuleContext
        {
            if (_oldParser != null)
            {
                var key = (depth, state, ruleIndex, currentTokenIndex);
                if (_oldParser._ruleStartMap.TryGetValue(key, out var ctx))
                {
                    if (ctx is TContext typedCtx)
                    {
                        existingContext = typedCtx;
                        return true;
                    }
                }
            }
            existingContext = null;
            return false;
        }

        public bool IsAffected(int start, int length)
        {
            return _lexer.AffectedOldTokenRange.Intersection(Interval.Of(start, start + length - 1)).Length > 0;
        }

        #region ParseTreeListener API

        void IParseTreeListener.VisitTerminal(ITerminalNode node)
        {
        }

        void IParseTreeListener.VisitErrorNode(IErrorNode node)
        {
        }

        void IParseTreeListener.EnterEveryRule(ParserRuleContext ctx)
        {
            // During rule entry, we push a new min/max token state.
            Lexer.PushIncrementalRuleInfo();
        }

        void IParseTreeListener.ExitEveryRule(ParserRuleContext ctx)
        {
            // On exit, we need to merge the min max into the current context,
            // and then merge the current context interval into our parent.
            var incrementalRuleInfo = Lexer.PopIncrementalRuleInfo();

            // First merge with the interval on the top of the stack.
            var incCtx = ctx as IncrementalParserRuleContext;
            if (incCtx._version == 0)
            {
                incCtx._version = _version;

                incCtx.MinMaxTokenIndex = incCtx.MinMaxTokenIndex.Union(incrementalRuleInfo.minMaxTokens);
                incCtx._tokenCount = incrementalRuleInfo.startEndTokens.Length;
            }
            else
            {
                incCtx.MinMaxTokenIndex = Interval.Of(Lexer.GetNewTokenIndex(incCtx.MinMaxTokenIndex.a), Lexer.GetNewTokenIndex(incCtx.MinMaxTokenIndex.b));
            }

            // Popped interval is wrong because there may have been child
            // intervals already merged into this ctx.
            var interval = incCtx.MinMaxTokenIndex;

            // Now merge with our parent interval.
            if (incCtx.parent != null)
            {
                var parentIncCtx = incCtx.parent as IncrementalParserRuleContext;
                parentIncCtx.MinMaxTokenIndex = parentIncCtx.MinMaxTokenIndex.Union(interval);
            }

            var key = (ctx.Depth(), ctx.invokingState, ctx.RuleIndex, incrementalRuleInfo.startEndTokens.a);
            _ruleStartMap[key] = incCtx;
        }

        #endregion
    }
}
