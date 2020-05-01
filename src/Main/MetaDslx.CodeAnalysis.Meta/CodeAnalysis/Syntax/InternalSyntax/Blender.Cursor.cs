// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Diagnostics;
using Microsoft.CodeAnalysis.CSharp.Symbols;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using Roslyn.Utilities;
using System;
using Microsoft.CodeAnalysis;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace MetaDslx.CodeAnalysis.Syntax.InternalSyntax
{
    internal partial struct Blender
    {
        /// <summary>
        /// THe cursor represents a location in the tree that we can move around to indicate where
        /// we are in the original tree as we're incrementally parsing.  When it is at a node or
        /// token, it can either move forward to that entity's next sibling.  It can also move down
        /// to a node's first child or first token.
        /// 
        /// Once the cursor hits the end of file, it's done.  Note: the cursor will skip any other
        /// zero length nodes in the tree.
        /// </summary>
        private struct Cursor
        {
            public readonly SyntaxNodeOrToken CurrentNodeOrToken;
            private readonly ImmutableStack<IncrementalSyntaxNode> _incrementalNodeStack;
            private readonly int _indexInParent;
            private readonly int _incrementalIndexInParent;

            private Cursor(SyntaxNodeOrToken node, int indexInParent, int incrementalIndexInParent, ImmutableStack<IncrementalSyntaxNode> incrementalNodeStack)
            {
                CurrentNodeOrToken = node;
                _incrementalIndexInParent = incrementalIndexInParent;
                _incrementalNodeStack = incrementalNodeStack;
                _indexInParent = indexInParent;
            }

            public static Cursor FromRoot(LanguageSyntaxNode node, IncrementalSyntaxNode incrementalSyntaxNode)
            {
                return new Cursor(node, 0, 0, ImmutableStack.Create(incrementalSyntaxNode));
            }

            public IncrementalSyntaxNode CurrentIncrementalNode
            {
                get
                {
                    if (!_incrementalNodeStack.IsEmpty) return _incrementalNodeStack.Peek();
                    else return null;
                }
            }

            public bool IsFinished
            {
                get
                {
                    return
                        this.CurrentNodeOrToken.GetKind() == SyntaxKind.None ||
                        this.CurrentNodeOrToken.GetKind() == SyntaxKind.Eof;
                }
            }

            private static bool IsNonZeroWidthOrIsEndOfFile(SyntaxNodeOrToken token)
            {
                return token.GetKind() == SyntaxKind.Eof || token.FullWidth != 0;
            }

            public Cursor MoveToNextSibling()
            {
                if (this.CurrentNodeOrToken.Parent != null)
                {
                    // First, look to the nodes to the right of this one in our parent's child list
                    // to get the next sibling.
                    var siblings = this.CurrentNodeOrToken.Parent.ChildNodesAndTokens();
                    var incrementalStack = _incrementalNodeStack.Pop();
                    var incrementalParent = incrementalStack.Peek();
                    var incrementalSiblings = incrementalParent.Children;
                    var incrementalIndex = _incrementalIndexInParent;
                    if (this.CurrentNodeOrToken.IsNode) ++incrementalIndex;
                    for (int i = _indexInParent + 1, n = siblings.Count; i < n; i++)
                    {
                        var sibling = siblings[i];
                        if (IsNonZeroWidthOrIsEndOfFile(sibling))
                        {
                            if (sibling.IsNode)
                            {
                                return new Cursor(sibling, i, incrementalIndex, _incrementalNodeStack.Push(incrementalSiblings[incrementalIndex]));
                            }
                            else
                            {
                                return new Cursor(sibling, i, -1, _incrementalNodeStack.Push(null));
                            }
                        }
                        if (sibling.IsNode) ++incrementalIndex;
                    }

                    // We're at the end of this sibling chain.  Walk up to the parent and see who is
                    // the next sibling of that.
                    return MoveToParent().MoveToNextSibling();
                }

                return default;
            }

            private Cursor MoveToParent()
            {
                var parent = this.CurrentNodeOrToken.Parent;
                var index = IndexOfNodeInParent(parent);
                var incrementalStack = _incrementalNodeStack.Pop();
                var incrementalParentStack = incrementalStack.Pop();
                var incrementalNode = incrementalStack.Peek();
                var incrementalParent = incrementalParentStack.Peek();
                var incrementalIndex = incrementalParent.Children.IndexOf(incrementalNode);
                return new Cursor(parent, index, incrementalIndex, incrementalStack);
            }

            private static int IndexOfNodeInParent(SyntaxNode node)
            {
                if (node.Parent == null)
                {
                    return 0;
                }

                var children = node.Parent.ChildNodesAndTokens();
                var index = SyntaxNodeOrToken.GetFirstChildIndexSpanningPosition(children, ((LanguageSyntaxNode)node).Position);
                for (int i = index, n = children.Count; i < n; i++)
                {
                    var child = children[i];
                    if (child == node)
                    {
                        return i;
                    }
                }

                throw ExceptionUtilities.Unreachable;
            }

            public Cursor MoveToFirstChild()
            {
                Debug.Assert(this.CurrentNodeOrToken.IsNode);

                // Just try to get the first node directly.  This is faster than getting the list of
                // child nodes and tokens (which forces all children to be enumerated for the sake
                // of counting.  It should always be safe to index the 0th element of a node.  But
                // just to make sure that this is not a problem, we verify that the slot count of the
                // node is greater than 0.
                var node = CurrentNodeOrToken.AsNode();

                if (node.SlotCount > 0)
                {
                    var child = Microsoft.CodeAnalysis.ChildSyntaxList.ItemInternal(node, 0);
                    if (IsNonZeroWidthOrIsEndOfFile(child))
                    {
                        return new Cursor(child, 0, 0, _incrementalNodeStack.Push(child.IsNode ? CurrentIncrementalNode.Children[0] : null));
                    }
                }

                // Fallback to enumerating all children.
                int index = 0;
                int nodeIndex = 0;
                foreach (var child in this.CurrentNodeOrToken.ChildNodesAndTokens())
                {
                    if (IsNonZeroWidthOrIsEndOfFile(child))
                    {
                        return new Cursor(child, index, nodeIndex, _incrementalNodeStack.Push(child.IsNode ? CurrentIncrementalNode.Children[nodeIndex] : null));
                    }

                    index++;
                    if (child.IsNode) ++nodeIndex;
                }

                return new Cursor();
            }

            public Cursor MoveToFirstToken()
            {
                var cursor = this;
                if (!cursor.IsFinished)
                {
                    for (var node = cursor.CurrentNodeOrToken; node.GetKind() != SyntaxKind.None && !Language.SyntaxFacts.IsToken(node.GetKind()); node = cursor.CurrentNodeOrToken)
                    {
                        cursor = cursor.MoveToFirstChild();
                    }
                }

                return cursor;
            }

            private Language Language => ((InternalSyntaxNode)CurrentNodeOrToken.NodeOrParent.Green).Language;
        }
    }
}
