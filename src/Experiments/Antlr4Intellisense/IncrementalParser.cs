using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Antlr4Intellisense
{
    /// <summary>
    /// Incremental parser implementation for ANTLR4.
    /// </summary>
    /// 
    /// There are only two differences between this parser and the underlying regular
    /// Parser - guard rules and min/max tracking
    /// 
    /// The guard rule API is used in incremental mode to know when a rule context
    /// can be reused. It looks for token changes in the bounds of the rule.
    /// 
    /// The min/max tracking is used to track how far ahead/behind the parser looked
    /// to correctly detect whether a token change can affect a parser rule in the future (IE when
    /// handed to the guard rule of the next parse)
    public abstract class IncrementalParser : Parser, IParseTreeListener
    {
        private static int GlobalParserEpoch = 0;
        public readonly int ParserEpoch;
        private IncrementalParserData _parserData;

        public IncrementalParser(IncrementalTokenStream input, IncrementalParserData parserData) 
            : base(input)
        {
            ParserEpoch = Interlocked.Increment(ref GlobalParserEpoch);
            _parserData = parserData;
        }

        private IncrementalTokenStream IncrementalStream => (IncrementalTokenStream)this._input;

        /// <summary>
        /// Push the current token data onto the min max stack for the stream.
        /// </summary>
        private void PushCurrentTokenToMinMax()
        {
            var token = IncrementalStream.Lt(1);
            IncrementalStream.PushMinMax(token.TokenIndex, token.TokenIndex);
        }

        /// <summary>
        /// Pop the min max stack the stream is using and return the interval.
        /// </summary>
        /// <param name="ctx"></param>
        /// <returns></returns>
        private Interval PopCurrentMinMax(IncrementalParserRuleContext ctx)
        {
            return IncrementalStream.PopMinMax();
        }

        /// <summary>
        /// Guard a rule's previous context from being reused.
        /// </summary>
        /// <returns></returns>
        public IncrementalParserRuleContext GuardRule(IncrementalParserRuleContext parentCtx, int state, int ruleIndex)
        {
            // If we have no previous parse data, the rule needs to be run.
            if (_parserData == null) return null;

            // See if we have seen this state before at this starting point.
            // If we haven't seen it, we need to rerun this rule.
            var parentDepth = parentCtx?.Depth() ?? 0;
            if (!_parserData.TryGetContext(parentDepth + 1, state, ruleIndex, _input.Lt(1).TokenIndex, out var existingCtx)) return null;

            // We have seen it, see if it was affected by the parse
            if (_parserData.IsAffected(existingCtx)) return null;

            // Everything checked out, reuse the rule context - we add it to the
            // parent context as enterRule would have
            var parent = _ctx as IncrementalParserRuleContext;
            // add current context to parent if we have a parent
            if (parent != null) parent.AddChild(existingCtx);

            return existingCtx;
        }

        /// <summary>
        /// Pop the min max stack the stream is using and union the interval
	    /// into the passed in context. Return the interval for the context.
        /// </summary>
        /// <param name="ctx"></param>
        /// <returns></returns>
        private Interval PopAndHandleMinMax(IncrementalParserRuleContext ctx)
        {
            var interval = this.PopCurrentMinMax(ctx);
            ctx.MinMaxTokenIndex = ctx.MinMaxTokenIndex.Union(interval);
            // Returning interval is wrong because there may have been child
            // intervals already merged into this ctx.
            return ctx.MinMaxTokenIndex;
        }

        #region Regular parser API

        //The new recursion context reparents the relationship between the contexts,
        //so we need to merge intervals here.
        public override void PushNewRecursionContext(ParserRuleContext localctx, int state, int ruleIndex)
        {
            var previous = _ctx as IncrementalParserRuleContext;
            var incLocalCtx = localctx as IncrementalParserRuleContext;
            incLocalCtx.MinMaxTokenIndex = incLocalCtx.MinMaxTokenIndex.Union(previous.MinMaxTokenIndex);
            base.PushNewRecursionContext(localctx, state, ruleIndex);
        }

        #endregion

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
            this.PushCurrentTokenToMinMax();
            var incCtx = ctx as IncrementalParserRuleContext;
            incCtx._epoch = this.ParserEpoch;
        }

        void IParseTreeListener.ExitEveryRule(ParserRuleContext ctx)
        {
            // On exit, we need to merge the min max into the current context,
            // and then merge the current context interval into our parent.

            // First merge with the interval on the top of the stack.
            var incCtx = ctx as IncrementalParserRuleContext;
            var interval = this.PopAndHandleMinMax(incCtx);

            // Now merge with our parent interval.
            if (incCtx.parent != null)
            {
                var parentIncCtx = incCtx.parent as IncrementalParserRuleContext;
                parentIncCtx.MinMaxTokenIndex = parentIncCtx.MinMaxTokenIndex.Union(interval);
            }
        }

        #endregion
    }
}
