// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Syntax.InternalSyntax
{
    internal readonly partial struct Blender
    {
        private readonly SyntaxParser _parser;
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

        public Blender(SyntaxParser parser, LanguageSyntaxNode oldTree, IEnumerable<TextChangeRange> changes)
        {
            Debug.Assert(parser != null);
            //Debug.Assert((oldTree == null && changes == null) || (oldTree != null && changes != null));
            _parser = parser;
            _changes = ImmutableStack.Create<TextChangeRange>();

            if (changes != null && oldTree != null)
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
                var affectedRange = ExtendToAffectedRange(oldTree, collapsed);
                _changes = _changes.Push(affectedRange);
            }

            if (oldTree == null)
            {
                // start at lexer current position if no nodes specified
                _oldTreeCursor = new Cursor();
                _newPosition = _parser.Lexer.Position;
            }
            else
            {
                _oldTreeCursor = Cursor.FromRoot(oldTree);
                _newPosition = 0;
            }

            _changeDelta = 0;
            _newDirectives = default;
            _oldDirectives = default;
            _mode = null;
            _state = null;
        }

        private Blender(
            SyntaxParser parser,
            Cursor oldTreeCursor,
            ImmutableStack<TextChangeRange> changes,
            int newPosition,
            int changeDelta,
            DirectiveStack newDirectives,
            DirectiveStack oldDirectives,
            LexerMode mode,
            ParserState state)
        {
            Debug.Assert(parser != null);
            Debug.Assert(changes != null);
            Debug.Assert(newPosition >= 0);
            _parser = parser;
            _oldTreeCursor = oldTreeCursor;
            _changes = changes;
            _newPosition = newPosition;
            _changeDelta = changeDelta;
            _newDirectives = newDirectives;
            _oldDirectives = oldDirectives;
            _mode = mode;
            _state = state;
        }

        public LexerMode Mode => _mode;
        public ParserState State => _state;
        public int Position => _newPosition;
        public DirectiveStack Directives => _newDirectives;

        internal static (int minLexerLookahead, int maxLexerLookahead) GetLexerLookahead(LanguageSyntaxNode treeRoot)
        {
            if (treeRoot == null) return (int.MaxValue, int.MinValue);
            var treeAnnot = SyntaxParser.GetTreeAnnotation(treeRoot.Green);
            int minLexerLookahead = int.MaxValue;
            int maxLexerLookahead = int.MinValue;
            if (treeAnnot != null)
            {
                minLexerLookahead = treeAnnot.MinLexerLookahead;
                maxLexerLookahead = treeAnnot.MaxLexerLookahead;
            }
            return (minLexerLookahead, maxLexerLookahead);
        }

        /// <summary>
        /// Affected range of a change is the range within which nodes can be affected by a change
        /// and cannot be reused. Because of lookahead effective range of a change is larger than
        /// the change itself.
        /// </summary>
        private static TextChangeRange ExtendToAffectedRange(
            LanguageSyntaxNode oldRoot,
            TextChangeRange changeRange)
        {
            (int minLexerLookahead, int maxLexerLookahead) = GetLexerLookahead(oldRoot);

            // check if change is not after the end. TODO: there should be an assert somewhere about
            // changes starting at least at the End of old tree
            var lastCharIndex = oldRoot.FullWidth - 1;

            // Move the start and end of the change range so that it is contained within oldTree.
            var start = Math.Max(Math.Min(changeRange.Span.Start - maxLexerLookahead, lastCharIndex), 0);
            var end = Math.Max(Math.Min(changeRange.Span.End - Math.Min(minLexerLookahead, 0), lastCharIndex), 0);

            // The first iteration aligns us with the change start. Subsequent iteration move us to
            // the left until we find a token of non-zero width.  We only need to do this as long as 
            // we're not at the start of the tree.
            while (start > 0)
            {
                var token = oldRoot.FindToken(start, findInsideTrivia: false);
                Debug.Assert(token.GetKind() != SyntaxKind.None, "how could we not get a real token back?");

                // Only stop if we got a non-zero width token.  Otherwise, we want to just do
                // this again having moved back one space.
                if (token.FullWidth > 0) break;

                start = Math.Max(0, token.Position - 1);
            }

            // The first iteration aligns us with the change end. Subsequent iteration move us to
            // the right until we find a token of non-zero width.  We only need to do this as long as 
            // we're not at the end of the tree.
            while (end < lastCharIndex)
            {
                var token = oldRoot.FindToken(end, findInsideTrivia: false);
                Debug.Assert(token.GetKind() != SyntaxKind.None, "how could we not get a real token back?");

                // Only stop if we got a non-zero width token.  Otherwise, we want to just do
                // this again having moved forward one space.
                if (token.FullWidth > 0) break;

                end = Math.Min(lastCharIndex, token.Position + Math.Max(token.FullWidth, 1));
            }

            var startNode = FindLastReusableNodeBefore(start, oldRoot);
            var endNode = FindFirstReusableNodeAfter(end, oldRoot);

            start = startNode?.FullSpan.End ?? 0;
            end = endNode?.FullSpan.Start ?? oldRoot.FullWidth;

            var finalSpan = TextSpan.FromBounds(start, end);
            var finalLength = changeRange.NewLength + (changeRange.Span.Start - start) + (end - changeRange.Span.End);
            return new TextChangeRange(finalSpan, finalLength);
        }

        private static LanguageSyntaxNode FindLastReusableNodeBefore(
            int position,
            LanguageSyntaxNode oldNode)
        {
            if (oldNode.FullSpan.End <= position) return oldNode;
            if (oldNode.FullSpan.Start > position) return null;
            var children = oldNode.ChildNodes();
            LanguageSyntaxNode prevChild = null;
            int i = 0;
            foreach (var child in children)
            {
                if (child.FullSpan.Contains(position))
                {
                    var result = FindLastReusableNodeBefore(position, (LanguageSyntaxNode)child);
                    if (result != null) return result;
                    else return prevChild;
                }
                else if (child.FullSpan.End <= position)
                {
                    prevChild = (LanguageSyntaxNode)child;
                }
                else
                {
                    return prevChild;
                }
                ++i;
            }
            return prevChild;
        }

        private static LanguageSyntaxNode FindFirstReusableNodeAfter(
            int position,
            LanguageSyntaxNode oldNode)
        {
            if (oldNode.FullSpan.Start >= position) return oldNode;
            if (oldNode.FullSpan.End < position) return null;
            var children = oldNode.ChildNodes().Reverse();
            LanguageSyntaxNode nextChild = null;
            int i = 0;
            foreach (var child in children)
            {
                if (child.FullSpan.Contains(position))
                {
                    var result = FindFirstReusableNodeAfter(position, (LanguageSyntaxNode)child);
                    if (result != null) return result;
                    else return nextChild;
                }
                else if (child.FullSpan.Start > position)
                {
                    nextChild = (LanguageSyntaxNode)child;
                }
                else
                {
                    return nextChild;
                }
                ++i;
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
    }
}
