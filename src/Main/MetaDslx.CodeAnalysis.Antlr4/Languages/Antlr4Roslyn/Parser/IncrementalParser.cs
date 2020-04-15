using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax
{
    public abstract class IncrementalParser : Parser
    {
        internal IncrementalAntlr4Parser _incrementalParser;

        public IncrementalParser(ITokenStream input) 
            : base(input)
        {
        }

        // TODO: adjust index and state...

        /// <summary>
        /// Guard a rule's previous context from being reused.
        /// </summary>
        /// <returns></returns>
        public bool TryGetIncrementalContext<TContext>(global::Antlr4.Runtime.ParserRuleContext parentContext, int state, int ruleIndex, out TContext existingContext)
            where TContext : IncrementalParserRuleContext
        {
            existingContext = null;

            // If we have no previous parse data, the rule needs to be run.
            if (_incrementalParser == null) return false;

            // See if we have seen this state before at this starting point.
            // If we haven't seen it, we need to rerun this rule.
            var parentDepth = parentContext?.Depth() ?? 0;
            var oldTokenIndex = _incrementalParser.Lexer.GetOldTokenIndex(_incrementalParser.CurrentTokenIndex);
            if (!_incrementalParser.TryGetContext(parentDepth + 1, state, ruleIndex, oldTokenIndex, out existingContext)) return false;

            var tokenCount = existingContext.TokenCount;

            // We have seen it, see if it was affected by the parse
            if (_incrementalParser.IsAffected(oldTokenIndex, tokenCount)) return false;

            ((IParseTreeListener)_incrementalParser).EnterEveryRule(existingContext);

            for (int i = 0; i < tokenCount; i++)
            {
                _incrementalParser.Lexer.Lex();
            }

            // Everything checked out, reuse the rule context - we add it to the
            // parent context as enterRule would have
            var parent = _ctx as IncrementalParserRuleContext;

            // add current context to parent if we have a parent
            if (parent != null) parent.AddChild(existingContext);

            ((IParseTreeListener)_incrementalParser).ExitEveryRule(existingContext);
            return true;
        }

        #region Regular parser API

        //The new recursion context reparents the relationship between the contexts,
        //so we need to merge intervals here.
        public override void PushNewRecursionContext(global::Antlr4.Runtime.ParserRuleContext localctx, int state, int ruleIndex)
        {
            var previous = _ctx as IncrementalParserRuleContext;
            var incLocalCtx = localctx as IncrementalParserRuleContext;
            incLocalCtx.MinMaxTokenIndex = incLocalCtx.MinMaxTokenIndex.Union(previous.MinMaxTokenIndex);
            base.PushNewRecursionContext(localctx, state, ruleIndex);
        }

        #endregion
    }
}
