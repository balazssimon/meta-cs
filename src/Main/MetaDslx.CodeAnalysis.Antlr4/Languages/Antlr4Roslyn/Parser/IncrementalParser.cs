﻿using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
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

        /// <summary>
        /// Guard a rule's previous context from being reused.
        /// </summary>
        /// <returns></returns>
        public bool TryGetIncrementalContext<TContext>(ParserRuleContext parentContext, int state, int ruleIndex, out TContext existingContext)
            where TContext : ParserRuleContext
        {
            if (_incrementalParser != null)
            {
                return _incrementalParser.TryGetIncrementalContext(parentContext, state, ruleIndex, out existingContext);
            }
            else
            {
                existingContext = null;
                return false;
            }
        }

        #region Regular parser API

        public override void PushNewRecursionContext(ParserRuleContext localctx, int state, int ruleIndex)
        {
            if (_incrementalParser != null)
            {
                _incrementalParser.PushNewRecursionContext(_ctx, localctx, state, ruleIndex);
            }
            base.PushNewRecursionContext(localctx, state, ruleIndex);
        }

        #endregion
    }
}
