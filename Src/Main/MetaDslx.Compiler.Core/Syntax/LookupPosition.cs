using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Syntax
{
    public static class LookupPosition
    {
        public static bool IsInNode(int position, RedNode node)
        {
            if (node == null) return false;
            return node.FullSpan.Contains(position);
        }

        /// <summary>
        /// A position is considered to be inside a block if it is on or after
        /// the first token and strictly before the last token.
        /// </summary>
        public static bool IsInBlock(int position, SyntaxToken block)
        {
            if (block == null) return false;
            return block.Span.Contains(position);
        }

        public static bool IsInBlock(int position, SyntaxNode block)
        {
            if (block == null) return false;
            return IsBetweenTokens(position, block.GetFirstToken(), block.GetLastToken());
        }

        public static bool IsBetweenTokens(int position, SyntaxToken firstIncluded, SyntaxToken firstExcluded)
        {
            if (firstIncluded == null || firstExcluded == null) return false;
            return position >= firstIncluded.SpanStart && IsBeforeToken(position, firstExcluded);
        }

        /// <summary>
        /// Returns true if position is within the given node and before the first excluded token.
        /// </summary>
        private static bool IsBeforeToken(int position, SyntaxNode node, SyntaxToken firstExcluded)
        {
            return IsBeforeToken(position, firstExcluded) && position >= node.SpanStart;
        }

        private static bool IsBeforeToken(int position, SyntaxToken firstExcluded)
        {
            return firstExcluded.RawKind == SyntaxKind.None || position < firstExcluded.SpanStart;
        }
    }
}
