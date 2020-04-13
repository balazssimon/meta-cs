// Incremental parser data for incremental ANTLR4 parsing
// Based on:
//     https://github.com/dberlin/antlr4ts/blob/incremental/src/IncrementalParserData.ts

using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Antlr4Intellisense
{
    /// <summary>
    /// Stores data about the offsets between tokens in the new and old stream.
    /// </summary>
    internal struct TokenOffsetRange
    {
        public readonly Interval Interval;
        public readonly int IndexOffset;

        public TokenOffsetRange(Interval interval, int indexOffset)
        {
            Interval = interval;
            IndexOffset = indexOffset;
        }
    }
    
    /// <summary>
    /// Definition of a token change. Token changes may not overlap.
    /// You also need to account for hidden tokens (but not skipped ones).
    /// </summary>
    public enum TokenChangeType
    {
        /// <summary>
        /// A new token that did not exist before.
        /// </summary>
        ADDED,
        /// <summary>
        /// A token that was in the stream before but changed in some way.
        /// </summary>
        CHANGED,
        /// <summary>
        /// A token that no longer exists in the stream.
        /// </summary>
        REMOVED,
    }

    /// <summary>
    /// Stores data about the offsets between tokens in the new and old stream.
    /// </summary>
    public struct TokenChange
    {
        public readonly TokenChangeType ChangeType;
        public readonly IToken NewToken;
        public readonly IToken OldToken;

        public TokenChange(TokenChangeType changeType, IToken newToken, IToken oldToken)
        {
            ChangeType = changeType;
            NewToken = newToken;
            OldToken = oldToken;
        }
    }



    public class IncrementalParserData
    {

        internal bool IsAffected(IncrementalParserRuleContext existingCtx)
        {
            throw new NotImplementedException();
        }

        internal bool TryGetContext(int depth, int state, int ruleIndex, int tokenIndex, out IncrementalParserRuleContext existingCtx)
        {
            throw new NotImplementedException();
        }

        // This is a binary search variant, but instead of looking for a specific individual number,
        // we are looking to see if any of the values in the list fall into a given range.
        // Binary search through the changed token list looking for the a number with a
        // value >= rangeLow and <= rangeHigh. Terminate and return a value if we find
        // one. Return undefined if we did not find anything.
        private static int FindChangedTokenInRange(IList<int> tokens, int rangeLow, int rangeHigh)
        {
            var low = 0;
            var high = tokens.Count - 1;
            while(low <= high)
            {
                var middle = (low + high) / 2;
                var middleValue = tokens[middle];
                if (middleValue >= rangeLow)
                {
                    // If we found something in the range, terminate.
                    // Otherwise keep moving left.
                    if (middleValue <= rangeHigh)
                    {
                        return middle;
                    }
                    high = middle - 1;
                }
                else
                {
                    low = middle + 1;
                }
            }
            return -1;
        }

        // Given a token index in the old token stream, and an array of token changes, see what the
        // new token index should be.
        private static int FindAdjustedTokenIndex(IList<TokenOffsetRange> tokens, int tokenIndex)
        {
            var low = 0;
            var high = tokens.Count - 1;
            while(low <= high)
            {
                var middle = (low + high) / 2;
                var middleValue = tokens[middle];
                if (tokenIndex >= middleValue.Interval.a)
                {
                    // If we found something in the range, terminate.
                    if (tokenIndex <= middleValue.Interval.b)
                    {
                        return tokenIndex + middleValue.IndexOffset;
                    }
                    low = middle + 1;
                }
                else
                {
                    high = middle - 1;
                }
            }
            return -1;
        }
    }
}
