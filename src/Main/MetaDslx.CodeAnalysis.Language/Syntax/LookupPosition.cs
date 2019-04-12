// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Diagnostics;
using Roslyn.Utilities;

namespace Microsoft.CodeAnalysis.CSharp.Syntax
{
    /// <summary>
    /// This class contains a variety of helper methods for determining whether a
    /// position is within the scope (and not just the span) of a node.  In general,
    /// general, the scope extends from the first token up to, but not including,
    /// the last token. For example, the open brace of a block is within the scope
    /// of the block, but the close brace is not.
    /// </summary>
    internal static class LookupPosition
    {
        internal static bool IsBetweenTokens(int position, SyntaxToken firstIncluded, SyntaxToken firstExcluded)
        {
            return position >= firstIncluded.SpanStart && IsBeforeToken(position, firstExcluded);
        }

        /// <summary>
        /// Returns true if position is within the given node and before the first excluded token.
        /// </summary>
        private static bool IsBeforeToken(int position, CSharpSyntaxNode node, SyntaxToken firstExcluded)
        {
            return IsBeforeToken(position, firstExcluded) && position >= node.SpanStart;
        }

        private static bool IsBeforeToken(int position, SyntaxToken firstExcluded)
        {
            return firstExcluded.Kind() == SyntaxKind.None || position < firstExcluded.SpanStart;
        }
    }
}
