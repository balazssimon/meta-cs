// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Symbols;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Syntax.InternalSyntax
{
    internal readonly partial struct Blender
    {
        private readonly IncrementalLexer _lexer;
        private readonly Cursor _oldTreeCursor;
        private readonly ImmutableStack<TextChangeRange> _changes;

        /// <summary>
        /// newPosition represents the position we are in the final SourceText.  As we consume and reuse
        /// nodes from the old tree we will update our position in the new text accordingly.
        /// Likewise, when we must lex tokens out of the new tree we will update as well.
        /// 
        /// NOTE(cyrusn): We do not need an oldPosition because it is redundant given the
        /// oldTreeCursor.  The oldPosition is implicitly defined by the position of the cursor.
        /// </summary>
        private readonly int _newPosition;
        private readonly int _changeDelta;
        private readonly DirectiveStack _newDirectives;
        private readonly DirectiveStack _oldDirectives;
        private readonly LexerMode _mode;
        private readonly ParserState _state;

        public Blender(IncrementalLexer lexer, LanguageSyntaxNode oldTree, IncrementalSyntaxTree oldIncrementalTree, IEnumerable<TextChangeRange> changes)
        {
            Debug.Assert(lexer != null);
            Debug.Assert((oldTree == null && oldIncrementalTree == null && changes == null) || (oldTree != null && oldIncrementalTree != null && changes != null));
            _lexer = lexer;
            _changes = ImmutableStack.Create<TextChangeRange>();

            if (changes != null)
            {
                // TODO: Consider implementing NormalizedChangeCollection for TextSpan. the real
                // reason why we are collapsing is because we want to extend change ranges and
                // cannot allow them to overlap. This does not seem to be a big deal since multiple
                // changes are infrequent and typically close to each other. However if we have
                // NormalizedChangeCollection for TextSpan we can have both - we can extend ranges
                // and not require collapsing them. NormalizedChangeCollection would also ensure
                // that changes are always normalized.

                // TODO: this is a temporary measure to prevent individual change spans from
                // overlapping after they are widened to effective width (+1 token at the start).
                // once we have normalized collection for TextSpan we will not need to collapse all
                // the change spans.

                var collapsed = TextChangeRange.Collapse(changes);

                // extend the change to its affected range. This will make it easier 
                // to filter out affected nodes since we will be able simply check 
                // if node intersects with a change.
                var affectedRange = ExtendToAffectedRange(oldTree, oldIncrementalTree, collapsed);
                _changes = _changes.Push(affectedRange);
            }

            if (oldTree == null)
            {
                // start at lexer current position if no nodes specified
                _oldTreeCursor = new Cursor();
                _newPosition = lexer.TextWindow.Position;
            }
            else
            {
                _oldTreeCursor = Cursor.FromRoot(oldTree, oldIncrementalTree.Root).MoveToFirstChild();
                _newPosition = 0;
            }

            _changeDelta = 0;
            _newDirectives = default;
            _oldDirectives = default;
            _mode = null;
            _state = null;
        }

        private Blender(
            IncrementalLexer lexer,
            Cursor oldTreeCursor,
            ImmutableStack<TextChangeRange> changes,
            int newPosition,
            int changeDelta,
            DirectiveStack newDirectives,
            DirectiveStack oldDirectives,
            LexerMode mode,
            ParserState state)
        {
            Debug.Assert(lexer != null);
            Debug.Assert(changes != null);
            Debug.Assert(newPosition >= 0);
            _lexer = lexer;
            _oldTreeCursor = oldTreeCursor;
            _changes = changes;
            _newPosition = newPosition;
            _changeDelta = changeDelta;
            _newDirectives = newDirectives;
            _oldDirectives = oldDirectives;
            _mode = mode;
            _state = state;
        }

        internal IncrementalSyntaxNode IncrementalSyntaxNode => _oldTreeCursor.CurrentIncrementalNode as IncrementalSyntaxNode;

        /// <summary>
        /// Affected range of a change is the range within which nodes can be affected by a change
        /// and cannot be reused. Because of lookahead effective range of a change is larger than
        /// the change itself.
        /// </summary>
        private static TextChangeRange ExtendToAffectedRange(
            LanguageSyntaxNode oldTree,
            IncrementalSyntaxTree oldIncrementalTree,
            TextChangeRange changeRange)
        {
            int minLexerLookahead = oldIncrementalTree.MinLexerLookahead;
            int maxLexerLookahead = oldIncrementalTree.MaxLexerLookahead;

            // check if change is not after the end. TODO: there should be an assert somewhere about
            // changes starting at least at the End of old tree
            var lastCharIndex = oldTree.FullWidth - 1;

            // Move the start and end of the change range so that it is contained within oldTree.
            var start = Math.Max(Math.Min(changeRange.Span.Start - maxLexerLookahead, lastCharIndex), 0);
            var end = Math.Max(Math.Min(changeRange.Span.End - Math.Min(minLexerLookahead, 0), lastCharIndex), 0);

            // The first iteration aligns us with the change start. Subsequent iteration move us to
            // the left until we find a token of non-zero width.  We only need to do this as long as 
            // we're not at the start of the tree.
            while (start > 0)
            {
                var token = oldTree.FindToken(start, findInsideTrivia: false);
                Debug.Assert(token.GetKind() != SyntaxKind.None, "how could we not get a real token back?");

                start = Math.Max(0, token.Position - 1);

                // Only stop if we got a non-zero width token.  Otherwise, we want to just do
                // this again having moved back one space.
                if (token.FullWidth > 0) break;
            }

            // The first iteration aligns us with the change end. Subsequent iteration move us to
            // the right until we find a token of non-zero width.  We only need to do this as long as 
            // we're not at the end of the tree.
            while (end < lastCharIndex)
            {
                var token = oldTree.FindToken(end, findInsideTrivia: false);
                Debug.Assert(token.GetKind() != SyntaxKind.None, "how could we not get a real token back?");

                end = Math.Min(lastCharIndex, token.Position + Math.Max(token.FullWidth, 1));

                // Only stop if we got a non-zero width token.  Otherwise, we want to just do
                // this again having moved forward one space.
                if (token.FullWidth > 0) break;
            }

            start = FindLastReusableNodeBefore(start, oldTree, oldIncrementalTree.Root)?.FullSpan.End ?? 0;
            end = FindFirstReusableNodeAfter(end, oldTree, oldIncrementalTree.Root)?.FullSpan.Start ?? oldTree.FullWidth;

            var finalSpan = TextSpan.FromBounds(start, end);
            var finalLength = changeRange.NewLength + (changeRange.Span.Start - start) + (end - changeRange.Span.End);
            return new TextChangeRange(finalSpan, finalLength);
        }

        private static LanguageSyntaxNode FindLastReusableNodeBefore(
            int position,
            LanguageSyntaxNode oldNode,
            IncrementalSyntaxNode oldIncrementalNode)
        {
            if (oldNode.FullSpan.End <= position) return oldNode;
            if (oldNode.FullSpan.Start >= position) return null;
            var children = oldNode.Parent.ChildNodesAndTokens();
            LanguageSyntaxNode prevChild = null;
            for (int i = 0; i < children.Count; i++)
            {
                var child = children[i];
                if (child.FullSpan.Contains(position))
                {
                    if (child.IsToken) return prevChild;
                    else return FindLastReusableNodeBefore(position, (LanguageSyntaxNode)child.AsNode(), (IncrementalSyntaxNode)oldIncrementalNode.Children[i]);
                }
                else if (child.FullSpan.End <= position)
                {
                    if (child.IsNode) prevChild = (LanguageSyntaxNode)child.AsNode();
                }
                else
                {
                    Debug.Assert(false);
                    return null;
                }
            }
            return prevChild;
        }

        private static LanguageSyntaxNode FindFirstReusableNodeAfter(
            int position,
            LanguageSyntaxNode oldNode,
            IncrementalSyntaxNode oldIncrementalNode)
        {
            if (oldNode.FullSpan.Start >= position) return oldNode;
            if (oldNode.FullSpan.End <= position) return null;
            var children = oldNode.Parent.ChildNodesAndTokens();
            LanguageSyntaxNode nextChild = null;
            for (int i = children.Count - 1; i >= 0; i--)
            {
                var child = children[i];
                if (child.FullSpan.Contains(position))
                {
                    if (child.IsToken) return nextChild;
                    else return FindFirstReusableNodeAfter(position, (LanguageSyntaxNode)child.AsNode(), (IncrementalSyntaxNode)oldIncrementalNode.Children[i]);
                }
                else if (child.FullSpan.Start >= position)
                {
                    if (child.IsNode) nextChild = (LanguageSyntaxNode)child.AsNode();
                }
                else
                {
                    Debug.Assert(false);
                    return null;
                }
            }
            return nextChild;
        }

        public BlendedNode ReadNode()
        {
            return ReadNodeOrToken(asToken: false);
        }

        public BlendedNode ReadToken()
        {
            return ReadNodeOrToken(asToken: true);
        }

        private BlendedNode ReadNodeOrToken(bool asToken)
        {
            var reader = new Reader(this);
            return reader.ReadNodeOrToken(asToken);
        }

        public LexerMode Mode => _mode;
        public ParserState State => _state;
    }
}
