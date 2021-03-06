﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Diagnostics;
using Microsoft.CodeAnalysis;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Syntax
{
    /// <summary>
    /// This class contains a variety of helper methods for determining whether a
    /// position is within the scope (and not just the span) of a node.  In general,
    /// general, the scope extends from the first token up to, but not including,
    /// the last token. For example, the open brace of a block is within the scope
    /// of the block, but the close brace is not.
    /// </summary>
    public static class LookupPosition
    {
        public static bool IsBetweenTokens(int position, SyntaxToken firstIncluded, SyntaxToken firstExcluded)
        {
            return position >= firstIncluded.SpanStart && IsBeforeToken(position, firstExcluded);
        }

        /// <summary>
        /// Returns true if position is within the given node and before the first excluded token.
        /// </summary>
        private static bool IsBeforeToken(int position, LanguageSyntaxNode node, SyntaxToken firstExcluded)
        {
            return IsBeforeToken(position, firstExcluded) && position >= node.SpanStart;
        }

        private static bool IsBeforeToken(int position, SyntaxToken firstExcluded)
        {
            return firstExcluded.GetKind() == SyntaxKind.None || position < firstExcluded.SpanStart;
        }

        public static bool IsInNode(int position, SyntaxNode node)
        {
            if (node == null) return false;
            return node.FullSpan.Contains(position);
        }

        public static bool IsInNode(int position, SyntaxToken token)
        {
            if (token == null) return false;
            return token.FullSpan.Contains(position);
        }
    }
}
