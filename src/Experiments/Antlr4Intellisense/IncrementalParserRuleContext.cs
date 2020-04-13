// Incremental parser rule context for incremental ANTLR4 parsing
// Based on:
//     https://github.com/dberlin/antlr4ts/blob/incremental/src/IncrementalParserRuleContext.ts

using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Antlr4Intellisense
{
    public class IncrementalParserRuleContext : ParserRuleContext
    {
        // Avoid having to recompute depth on every single depth call
        private int _cachedDepth = -1;
        private RuleContext _cachedParent = null;

        // This is an epoch number that can be used to tell which pieces were
        // modified during a given incremental parse. The incremental parser
        // adds the current epoch number to all rule contexts it creates.
        // The epoch number is incremented every time a new parser instance is created.
        internal int _epoch;

        private Interval _minMaxTokenIndex = Interval.Of(int.MinValue, int.MaxValue);

        /// <summary>
        /// Get the minimum token index this rule touched.
        /// </summary>
        public int MinTokenIndex => _minMaxTokenIndex.a;

        /// <summary>
        /// Get the maximum token index this rule touched.
        /// </summary>
        public int MaxTokenIndex => _minMaxTokenIndex.b;

        /// <summary>
        /// Get the interval this rule touched.
        /// </summary>
        public Interval MinMaxTokenIndex
        {
            get { return _minMaxTokenIndex; }
            internal set { _minMaxTokenIndex = value; }
        }

        /// <summary>
        /// Compute the depth of this context in the parse tree.
        /// </summary>
        public override int Depth()
        {
            if (_cachedParent != null && _cachedParent == this.parent) return _cachedDepth;
            if (this.parent != null)
            {
                var parentDepth = this.parent.Depth();
                _cachedParent = parent;
                _cachedDepth = parentDepth + 1;
            }
            else
            {
                _cachedDepth = 1;
            }
            return _cachedDepth;
        }
    }
}
