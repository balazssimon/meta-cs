﻿using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Languages.Antlr4Roslyn.Syntax.InternalSyntax
{
    public class IncrementalParserRuleContext : ParserRuleContext
    {
        // Avoid having to recompute depth on every single depth call
        private int _cachedDepth = -1;
        private int _version;
        private int _tokenCount;
        private Interval _minMaxTokenIndex = Interval.Of(int.MaxValue, int.MinValue);

        public IncrementalParserRuleContext()
        {

        }

        public IncrementalParserRuleContext(ParserRuleContext parent, int invokingState)
            : base(parent, invokingState)
        {
        }

#if DEBUG
        public int Version
        {
            get { return _version; }
            internal set { _version = value; }
        }
#endif

        public bool IsNew => _minMaxTokenIndex.a == int.MaxValue && _minMaxTokenIndex.b == int.MinValue;

        public int TokenCount
        {
            get { return _tokenCount; }
            internal set { _tokenCount = value; }
        }

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
            if (_cachedDepth >= 0) return _cachedDepth;
            if (this.parent != null)
            {
                var parentDepth = this.parent.Depth();
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