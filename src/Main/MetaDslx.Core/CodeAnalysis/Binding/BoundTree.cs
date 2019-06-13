﻿using MetaDslx.CodeAnalysis.Binding.Binders;
using MetaDslx.CodeAnalysis.Binding.BoundNodes;
using MetaDslx.CodeAnalysis.Syntax;
using Microsoft.CodeAnalysis;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Binding
{
    using CSharpResources = Microsoft.CodeAnalysis.CSharp.CSharpResources;

    public class BoundTree
    {
        private readonly LanguageCompilation _compilation;
        private readonly LanguageSyntaxTree _syntaxTree;
        private readonly DiagnosticBag _diagnostics;
        private readonly Binder _rootBinder;

        private readonly ReaderWriterLockSlim _nodeMapLock = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);
        // The bound nodes associated with a syntax node, from highest in the tree to lowest.
        private readonly Dictionary<SyntaxNode, ImmutableArray<BoundNode>> _guardedNodeMap = new Dictionary<SyntaxNode, ImmutableArray<BoundNode>>();
        private Dictionary<SyntaxNode, BoundNode> _lazyGuardedSynthesizedNodesMap;

        public BoundTree(LanguageCompilation compilation, LanguageSyntaxTree syntaxTree, Binder rootBinder, DiagnosticBag diagnostics)
        {
            _compilation = compilation;
            _syntaxTree = syntaxTree;
            _rootBinder = rootBinder;
            _diagnostics = diagnostics;
        }

        public Language Language => _compilation.Language;

        public LanguageCompilation Compilation => _compilation;

        public LanguageSyntaxTree SyntaxTree => _syntaxTree;

        public virtual LanguageSyntaxNode Root => _syntaxTree.GetRootNode();

        protected SyntaxFacts SyntaxFacts => _compilation.Language.SyntaxFacts;

        public DiagnosticBag DiagnosticBag => _diagnostics;

        internal bool IsInTree(SyntaxNode node)
        {
            return node.SyntaxTree == this.SyntaxTree;
        }

        /// <summary>
        /// Given a position, locates the containing token.  If the position is actually within the
        /// leading trivia of the containing token or if that token is EOF, moves one token to the
        /// left.  Returns the start position of the resulting token.
        /// 
        /// This has the effect of moving the position left until it hits the beginning of a non-EOF
        /// token.
        /// 
        /// Throws an ArgumentOutOfRangeException if position is not within the root of this model.
        /// </summary>
        internal protected int CheckAndAdjustPosition(int position)
        {
            SyntaxToken unused;
            return CheckAndAdjustPosition(position, out unused);
        }

        internal protected int CheckAndAdjustPosition(int position, out SyntaxToken token)
        {
            int fullStart = this.Root.Position;
            int fullEnd = this.Root.FullSpan.End;
            bool atEOF = position == fullEnd && position == this.SyntaxTree.GetRoot().FullSpan.End;

            if ((fullStart <= position && position < fullEnd) || atEOF) // allow for EOF
            {
                token = (atEOF ? (LanguageSyntaxNode)this.SyntaxTree.GetRoot() : Root).FindToken(position);

                if (position < token.SpanStart) // NB: Span, not FullSpan
                {
                    // If this is already the first token, then the result will be default(SyntaxToken)
                    token = token.GetPreviousToken();
                }

                // If the first token in the root is missing, it's possible to step backwards
                // past the start of the root.  All sorts of bad things will happen in that case,
                // so just use the start of the root span.
                // CONSIDER: this should only happen when we step past the first token found, so
                // the start of that token would be another possible return value.
                return Math.Max(token.SpanStart, fullStart);
            }
            else if (fullStart == fullEnd && position == fullEnd)
            {
                // The root is an empty span and isn't the full compilation unit. No other choice here.
                token = default(SyntaxToken);
                return fullStart;
            }

            throw new ArgumentOutOfRangeException(nameof(position), position,
                string.Format(CSharpResources.PositionIsNotWithinSyntax, Root.FullSpan));
        }

        /// <summary>
        /// A convenience method that determines a position from a node.  If the node is missing,
        /// then its position will be adjusted using CheckAndAdjustPosition.
        /// </summary>
        internal protected int GetAdjustedNodePosition(SyntaxNode node)
        {
            Debug.Assert(IsInTree(node));

            var fullSpan = this.Root.FullSpan;
            var position = node.SpanStart;

            // skip zero-width tokens to get the position, but never get past the end of the node
            int betterPosition = node.GetFirstToken(includeZeroWidth: false).SpanStart;
            if (betterPosition < node.Span.End)
            {
                position = betterPosition;
            }

            if (fullSpan.IsEmpty)
            {
                Debug.Assert(position == fullSpan.Start);
                // At end of zero-width full span. No need to call
                // CheckAndAdjustPosition since that will simply 
                // return the original position.
                return position;
            }
            else if (position == fullSpan.End)
            {
                Debug.Assert(node.Width == 0);
                // For zero-width node at the end of the full span,
                // check and adjust the preceding position.
                return CheckAndAdjustPosition(position - 1);
            }
            else if (node.IsMissing || node.HasErrors || node.Width == 0 || node.IsPartOfStructuredTrivia())
            {
                return CheckAndAdjustPosition(position);
            }
            else
            {
                // No need to adjust position.
                return position;
            }
        }

        [Conditional("DEBUG")]
        protected void AssertPositionAdjusted(int position)
        {
            Debug.Assert(position == CheckAndAdjustPosition(position), "Expected adjusted position");
        }

        internal protected void CheckSyntaxNode(LanguageSyntaxNode syntax)
        {
            if (syntax == null)
            {
                throw new ArgumentNullException(nameof(syntax));
            }

            if (!IsInTree(syntax))
            {
                throw new ArgumentException(CSharpResources.SyntaxNodeIsNotWithinSynt);
            }
        }

        public Binder GetEnclosingBinderWithinRoot(SyntaxNode node, int position)
        {
            AssertPositionAdjusted(position);
            return GetEnclosingBinderInternalWithinRoot(node, position, _rootBinder, this.Root);
        }

        internal static Binder GetEnclosingBinderInternalWithinRoot(SyntaxNode node, int position, Binder rootBinder, SyntaxNode root)
        {
            if (node == root)
            {
                return rootBinder.GetBinder(node) ?? rootBinder;
            }

            Debug.Assert(root.Contains(node));

            Binder binder = null;
            for (var current = node; binder == null; current = current.ParentOrStructuredTriviaParent)
            {
                Debug.Assert(current != null); // Why were we asked for an enclosing binder for a node outside our root?
                binder = rootBinder.GetBinder(current);
                if (current == root)
                {
                    break;
                }
            }

            binder = binder ?? rootBinder.GetBinder(root) ?? rootBinder;
            Debug.Assert(binder != null);

            return binder;
        }

        /// <summary>
        /// Get the bound node corresponding to the root.
        /// </summary> 
        internal virtual BoundNode GetBoundRoot()
        {
            return GetUpperBoundNode(GetBindableSyntaxNode(this.Root));
        }

        /// <summary>
        /// Get the highest bound node in the tree associated with a particular syntax node.
        /// </summary>
        internal BoundNode GetUpperBoundNode(LanguageSyntaxNode node, bool promoteToBindable = false)
        {
            if (promoteToBindable)
            {
                node = GetBindableSyntaxNode(node);
            }
            else
            {
                Debug.Assert(node == GetBindableSyntaxNode(node));
            }

            // The bound nodes are stored in the map from highest to lowest, so the first bound node is the highest.
            var boundNodes = GetBoundNodes(node);

            if (boundNodes.Length == 0)
            {
                return null;
            }
            else
            {
                return boundNodes[0];
            }
        }

        /// <summary>
        /// Get the lowest bound node in the tree associated with a particular syntax node. Lowest is defined as last
        /// in a pre-order traversal of the bound tree.
        /// </summary>
        internal BoundNode GetLowerBoundNode(LanguageSyntaxNode node)
        {
            Debug.Assert(node == GetBindableSyntaxNode(node));

            // The bound nodes are stored in the map from highest to lowest, so the last bound node is the lowest.
            var boundNodes = GetBoundNodes(node);

            if (boundNodes.Length == 0)
            {
                return null;
            }
            else
            {
                return GetLowerBoundNode(boundNodes);
            }
        }

        private static BoundNode GetLowerBoundNode(ImmutableArray<BoundNode> boundNodes)
        {
            return boundNodes[boundNodes.Length - 1];
        }

        internal ImmutableArray<BoundNode> GuardedGetBoundNodesFromMap(LanguageSyntaxNode node)
        {
            Debug.Assert(_nodeMapLock.IsWriteLockHeld || _nodeMapLock.IsReadLockHeld);
            ImmutableArray<BoundNode> result;
            return _guardedNodeMap.TryGetValue(node, out result) ? result : default(ImmutableArray<BoundNode>);
        }

        /// <summary>
        /// Internal for test purposes only
        /// </summary>
        internal ImmutableArray<BoundNode> TestOnlyTryGetBoundNodesFromMap(LanguageSyntaxNode node)
        {
            ImmutableArray<BoundNode> result;
            return _guardedNodeMap.TryGetValue(node, out result) ? result : default(ImmutableArray<BoundNode>);
        }

        // Adds every syntax/bound pair in a tree rooted at the given bound node to the map, and the
        // performs a lookup of the given syntax node in the map. 
        private ImmutableArray<BoundNode> GuardedAddBoundTreeAndGetBoundNodeFromMap(LanguageSyntaxNode syntax, BoundNode bound)
        {
            Debug.Assert(_nodeMapLock.IsWriteLockHeld);

            bool alreadyInTree = false;

            if (bound != null)
            {
                alreadyInTree = _guardedNodeMap.ContainsKey(bound.Syntax);
            }

            // check if we already have node in the cache.
            // this may happen if we have races and in such case we are no longer interested in adding
            if (!alreadyInTree)
            {
                BoundNodeMapBuilder.AddToMap(bound, _guardedNodeMap);
            }

            ImmutableArray<BoundNode> result;
            return _guardedNodeMap.TryGetValue(syntax, out result) ? result : default(ImmutableArray<BoundNode>);
        }

        protected void UnguardedAddBoundTreeForStandaloneSyntax(SyntaxNode syntax, BoundNode bound)
        {
            using (_nodeMapLock.DisposableWrite())
            {
                GuardedAddBoundTreeForStandaloneSyntax(syntax, bound);
            }
        }

        protected void GuardedAddBoundTreeForStandaloneSyntax(SyntaxNode syntax, BoundNode bound)
        {
            Debug.Assert(_nodeMapLock.IsWriteLockHeld);
            bool alreadyInTree = false;

            // check if we already have node in the cache.
            // this may happen if we have races and in such case we are no longer interested in adding
            if (bound != null)
            {
                alreadyInTree = _guardedNodeMap.ContainsKey(bound.Syntax);
            }

            if (!alreadyInTree)
            {
                if (syntax == this.Root || this.IsBindableRoot(syntax))
                {
                    // Note: For speculative model we want to always cache the entire bound tree.
                    // If syntax is a statement, we need to add all its children.
                    // Node cache assumes that if statement is cached, then all 
                    // its children are cached too.
                    BoundNodeMapBuilder.AddToMap(bound, _guardedNodeMap);
                }
                else
                {
                    // expressions can be added individually.
                    BoundNodeMapBuilder.AddToMap(bound, _guardedNodeMap, syntax);
                }
            }
        }

        // We might not have actually been given a bindable expression or statement; the caller can
        // give us variable declaration nodes, for example. If we're not at an expression or
        // statement, back up until we find one.
        public LanguageSyntaxNode GetBindingRoot(LanguageSyntaxNode node)
        {
            Debug.Assert(node != null);

#if DEBUG
            for (LanguageSyntaxNode current = node; current != this.Root; current = current.ParentOrStructuredTriviaParent)
            {
                // make sure we never go out of Root
                Debug.Assert(current != null, "How did we get outside the root?");
            }
#endif

            for (LanguageSyntaxNode current = node; current != this.Root; current = current.ParentOrStructuredTriviaParent)
            {
                if (this.IsBindableRoot(current))
                {
                    return current;
                }
            }

            return this.Root;
        }

        protected virtual bool IsBindableRoot(SyntaxNode node)
        {
            return SyntaxFacts.IsStatement(node);
        }

        // We want the binder in which this syntax node is going to be bound, NOT the binder which
        // this syntax node *produces*. That is, suppose we have
        //
        // void M() { int x; { int y; { int z; } } } 
        //
        // We want the enclosing binder of the syntax node for { int z; }.  We do not want the binder
        // that has local z, but rather the binder that has local y. The inner block is going to be
        // bound in the context of its enclosing binder; it's contents are going to be bound in the
        // context of its binder.
        public Binder GetEnclosingBinder(int position)
        {
            AssertPositionAdjusted(position);

            // If we have a root binder with no tokens in it, position can be outside the span event
            // after position is adjusted. If this happens, there can't be any 
            if (!this.Root.FullSpan.Contains(position))
                return _rootBinder;

            SyntaxToken token = this.Root.FindToken(position);
            LanguageSyntaxNode node = (LanguageSyntaxNode)token.Parent;

            return GetEnclosingBinderInternal(node, position);
        }

        /// <summary>
        /// This overload exists for callers who already have a node in hand 
        /// and don't want to search through the tree.
        /// </summary>
        internal Binder GetEnclosingBinderInternal(LanguageSyntaxNode node, int position)
        {
            AssertPositionAdjusted(position);
            return GetEnclosingBinderWithinRoot(node, position);
        }

        /// <summary>
        /// Get all bounds nodes associated with a node, ordered from highest to lowest in the bound tree.
        /// Strictly speaking, the order is that of a pre-order traversal of the bound tree.
        /// </summary>
        public ImmutableArray<BoundNode> GetBoundNodes(LanguageSyntaxNode node)
        {
            // If this method is called with a null parameter, that implies that the Root should be
            // bound, but make sure that the Root is bindable.
            if (node == null)
            {
                node = GetBindableSyntaxNode(Root);
            }
            Debug.Assert(node == GetBindableSyntaxNode(node));

            // We have one SemanticModel for each method.
            //
            // The SemanticModel contains a lazily-built immutable map from scope-introducing 
            // syntactic statements (such as blocks) to binders, but not from lambdas to binders.
            //
            // The SemanticModel also contains a mutable map from syntax to bound nodes; that is 
            // declared here. Since the map is not thread-safe we ensure that it is guarded with a
            // reader-writer lock.
            //
            // Have we already got the desired bound node in the mutable map? If so, return it.
            ImmutableArray<BoundNode> results;

            using (_nodeMapLock.DisposableRead())
            {
                results = GuardedGetBoundNodesFromMap(node);
            }

            if (!results.IsDefaultOrEmpty)
            {
                return results;
            }

            // We might not actually have been given an expression or statement even though we were
            // allegedly given something that is "bindable".

            // If we didn't find in the cached bound nodes, find a binding root and bind it.
            // This will cache bound nodes under the binding root.
            LanguageSyntaxNode nodeToBind = GetBindingRoot(node);
            var statementBinder = GetEnclosingBinder(GetAdjustedNodePosition(nodeToBind));
            Binder incrementalBinder = new IncrementalBinder(this, statementBinder);

            using (_nodeMapLock.DisposableWrite())
            {
                BoundNode boundStatement = this.Bind(incrementalBinder, nodeToBind);
                results = GuardedAddBoundTreeAndGetBoundNodeFromMap(node, boundStatement);
            }

            if (!results.IsDefaultOrEmpty)
            {
                return results;
            }

            // If we still didn't find it, its still possible we could bind it directly.
            // For example, types are usually not represented by bound nodes, and some error conditions and
            // not yet implemented features do not create bound nodes for everything underneath them.
            //
            // In this case, however, we only add the single bound node we found to the map, not any child bound nodes,
            // to avoid duplicates in the map if a parent of this node comes through this code path also.

            var binder = GetEnclosingBinder(GetAdjustedNodePosition(node));

            using (_nodeMapLock.DisposableRead())
            {
                results = GuardedGetBoundNodesFromMap(node);
            }

            if (results.IsDefaultOrEmpty)
            {
                using (_nodeMapLock.DisposableWrite())
                {
                    var boundNode = this.Bind(binder, node);
                    GuardedAddBoundTreeForStandaloneSyntax(node, boundNode);
                    results = GuardedGetBoundNodesFromMap(node);
                }

                if (!results.IsDefaultOrEmpty)
                {
                    return results;
                }
            }
            else
            {
                return results;
            }

            return ImmutableArray<BoundNode>.Empty;
        }

        public void GetBoundNodes(LanguageSyntaxNode node, out LanguageSyntaxNode bindableNode, out BoundNode lowestBoundNode, out BoundNode highestBoundNode, out BoundNode boundParent)
        {
            bindableNode = this.GetBindableSyntaxNode(node);

            LanguageSyntaxNode bindableParent = this.GetBindableParentNode(bindableNode);

            // Special handling for the Color Color case.
            //
            // Suppose we have:
            // public class Color {
            //   public void M(int x) {}
            //   public static void M(params int[] x) {}
            // }
            // public class C {
            //   public void Test() {
            //     Color Color = new Color();
            //     System.Action<int> d = Color.M;
            //   }
            // }
            //
            // We actually don't know how to interpret the "Color" in "Color.M" until we
            // perform overload resolution on the method group.  Now, if we were getting
            // the semantic info for the method group, then bindableParent would be the
            // variable declarator "d = Color.M" and so we would be able to pull the result
            // of overload resolution out of the bound (method group) conversion.  However,
            // if we are getting the semantic info for just the "Color" part, then
            // bindableParent will be the member access, which doesn't have enough information
            // to determine which "Color" to use (since no overload resolution has been
            // performed).  We resolve this problem by detecting the case where we're looking
            // up the LHS of a member access and calling GetBindableParentNode one more time.
            // This gets us up to the level where the method group conversion occurs.
            /* TODO:MetaDslx
            if (bindableParent != null && bindableParent.Kind() == SyntaxKind.SimpleMemberAccessExpression && ((MemberAccessExpressionSyntax)bindableParent).Expression == bindableNode)
            {
                bindableParent = this.GetBindableParentNode(bindableParent);
            }*/

            boundParent = bindableParent == null ? null : this.GetLowerBoundNode(bindableParent);

            lowestBoundNode = this.GetLowerBoundNode(bindableNode);
            highestBoundNode = this.GetUpperBoundNode(bindableNode);
        }

        // some nodes don't have direct semantic meaning by themselves and so we need to bind a different node that does
        internal protected virtual LanguageSyntaxNode GetBindableSyntaxNode(LanguageSyntaxNode node)
        {
            return node;
        }

        /// <summary>
        /// If the node is an expression, return the nearest parent node
        /// with semantic meaning. Otherwise return null.
        /// </summary>
        internal protected LanguageSyntaxNode GetBindableParentNode(LanguageSyntaxNode node, bool allowNullParent = false)
        {
            if (!SyntaxFacts.IsExpression(node))
            {
                return null;
            }

            // The node is an expression, but its parent is null
            LanguageSyntaxNode parent = node.Parent;
            if (parent == null)
            {
                // For speculative model, expression might be the root of the syntax tree, in which case it can have a null parent.
                if (allowNullParent && this.Root == node)
                {
                    return null;
                }

                throw new ArgumentException($"The parent of {nameof(node)} must not be null unless this is a speculative semantic model.", nameof(node));
            }

            var bindableParent = this.GetBindableSyntaxNode(parent);
            Debug.Assert(bindableParent != null);
            return bindableParent;
        }


        internal void GuardedAddSynthesizedNodeToMap(LanguageSyntaxNode node, BoundNode boundNode)
        {
            if (_lazyGuardedSynthesizedNodesMap == null)
            {
                _lazyGuardedSynthesizedNodesMap = new Dictionary<SyntaxNode, BoundNode>();
            }

            _lazyGuardedSynthesizedNodesMap.Add(node, boundNode);
        }

        internal BoundNode GuardedGetSynthesizedNodeFromMap(LanguageSyntaxNode node)
        {
            if (_lazyGuardedSynthesizedNodesMap != null &&
                _lazyGuardedSynthesizedNodesMap.TryGetValue(node, out BoundNode result))
            {
                return result;
            }

            return null;
        }

        protected virtual BoundNode Bind(Binder binder, LanguageSyntaxNode node)
        {
            return binder.Bind(node, _diagnostics);
        }

        public void Complete(CancellationToken cancellationToken)
        {
            // TODO: call complete on all BoundNodes, which should call complete on all Symbols
            throw new NotImplementedException("TODO:MetaDslx");
        }
    }
}
