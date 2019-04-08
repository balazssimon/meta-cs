// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MetaDslx.Compiler.Syntax.InternalSyntax;
using System;
using System.Diagnostics;

namespace MetaDslx.Compiler.Syntax
{
    using Green = InternalSyntax;

    internal static class SyntaxEquivalence
    {
        internal static bool AreEquivalent(SyntaxTree before, SyntaxTree after, Func<int, bool> ignoreChildNode)
        {
            if (before == after)
            {
                return true;
            }

            if (before == null || after == null)
            {
                return false;
            }

            return AreEquivalent(before.GetRoot(), after.GetRoot(), ignoreChildNode);
        }

        public static bool AreEquivalent(SyntaxNode before, SyntaxNode after, Func<int, bool> ignoreChildNode)
        {
            if (before == null || after == null)
            {
                return before == after;
            }

            return AreEquivalentRecursive(before.Green, after.Green, ignoreChildNode: ignoreChildNode);
        }

        public static bool AreEquivalent(SyntaxTokenList before, SyntaxTokenList after)
        {
            return AreEquivalentRecursive(before.Node, after.Node, ignoreChildNode: null);
        }

        public static bool AreEquivalent(SyntaxToken before, SyntaxToken after)
        {
            return before.RawKind == after.RawKind && (before.Node == null || AreTokensEquivalent(before.Node, after.Node));
        }

        private static bool AreTokensEquivalent(GreenNode before, GreenNode after)
        {
            // NOTE(cyrusn): Do we want to drill into trivia?  Can documentation ever affect the
            // global meaning of symbols?  This can happen in java with things like the "@obsolete"
            // clause in doc comment.  However, i don't know if anything like that exists in C#. 

            // NOTE(cyrusn): I don't believe we need to examine pp directives.  We actually want to
            // intentionally ignore them as we're only paying attention to the trees that affect
            // symbolic information.

            // NOTE(cyrusn): I don't believe we need to examine skipped text.  It isn't relevant from
            // the perspective of global symbolic information.
            Debug.Assert(before.RawKind == after.RawKind);

            if (before.IsMissing != after.IsMissing)
            {
                return false;
            }

            if (!before.Language.SyntaxFacts.IsFixedToken(before.RawKind))
            {
                return ((InternalSyntaxToken)before).Text == ((InternalSyntaxToken)after).Text;
            }

            return true;
        }

        private static bool AreEquivalentRecursive(GreenNode before, GreenNode after, Func<int, bool> ignoreChildNode)
        {
            if (before == after)
            {
                return true;
            }

            if (before == null || after == null)
            {
                return false;
            }

            if (before.RawKind != after.RawKind)
            {
                return false;
            }

            if (before.IsToken)
            {
                Debug.Assert(after.IsToken);
                return AreTokensEquivalent(before, after);
            }

            if (ignoreChildNode != null)
            {
                var e1 = before.ChildNodesAndTokens().GetEnumerator();
                var e2 = after.ChildNodesAndTokens().GetEnumerator();
                while (true)
                {
                    GreenNode child1 = null;
                    GreenNode child2 = null;

                    // skip ignored children:
                    while (e1.MoveNext())
                    {
                        var c = e1.Current;
                        if (c != null && (c.IsToken || !ignoreChildNode(c.RawKind)))
                        {
                            child1 = c;
                            break;
                        }
                    }

                    while (e2.MoveNext())
                    {
                        var c = e2.Current;
                        if (c != null && (c.IsToken || !ignoreChildNode(c.RawKind)))
                        {
                            child2 = c;
                            break;
                        }
                    }

                    if (child1 == null || child2 == null)
                    {
                        // false if some children remained
                        return child1 == child2;
                    }

                    if (!AreEquivalentRecursive(child1, child2, ignoreChildNode))
                    {
                        return false;
                    }
                }
            }
            else
            {
                // simple comparison - not ignoring children

                int slotCount = before.SlotCount;
                if (slotCount != after.SlotCount)
                {
                    return false;
                }

                for (int i = 0; i < slotCount; i++)
                {
                    var child1 = before.GetSlot(i);
                    var child2 = after.GetSlot(i);

                    if (!AreEquivalentRecursive(child1, child2, ignoreChildNode))
                    {
                        return false;
                    }
                }

                return true;
            }
        }
    }
}
