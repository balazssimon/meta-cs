using Antlr4.Runtime;
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
        private int _recursionDepth;

        public IncrementalParser(ITokenStream input) 
            : base(input)
        {
        }

        protected IncrementalAntlr4Parser IncrementalAntlr4Parser => _incrementalParser;

        /// <summary>
        /// Guard a rule's previous context from being reused.
        /// </summary>
        /// <returns></returns>
        public bool TryGetIncrementalContext<TContext>(ParserRuleContext parentContext, int state, int ruleIndex, out TContext existingContext)
            where TContext : ParserRuleContext
        {
            existingContext = null;
            return false;
        }

        public override void PushNewRecursionContext(ParserRuleContext localctx, int state, int ruleIndex)
        {
            ++_recursionDepth;
            _incrementalParser.BeginRecursiveRule();
            base.PushNewRecursionContext(localctx, state, ruleIndex);
        }

    }
}
