using MetaDslx.CodeAnalysis.Binding.Binders;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using Roslyn.Utilities;
using System;
using System.Collections.Concurrent;
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
        private readonly SyntaxNodeOrToken _rootSyntax;
        private readonly BoundNode _rootNode;
        private readonly Binder _rootBinder;

        public BoundTree(LanguageCompilation compilation, SyntaxNodeOrToken rootSyntax, Binder rootBinder)
        {
            _compilation = compilation;
            _syntaxTree = (LanguageSyntaxTree)rootSyntax.SyntaxTree;
            _rootSyntax = rootSyntax;
            _rootNode = new BoundNode(this);
            _rootBinder = new BoundTreeRootBinder(rootSyntax, rootBinder, _rootNode);
        }

        public Language Language => _compilation.Language;

        public LanguageCompilation Compilation => _compilation;

        public LanguageSyntaxTree SyntaxTree => _syntaxTree;

        public bool InScript => _syntaxTree.Options.Kind == SourceCodeKind.Script;

        public SyntaxNodeOrToken RootSyntax => _rootSyntax;

        public BoundNode RootNode => _rootNode;

        protected SyntaxFacts SyntaxFacts => _compilation.Language.SyntaxFacts;

        internal bool IsInTree(SyntaxNodeOrToken node)
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
            int fullStart = this.RootSyntax.Position;
            int fullEnd = this.RootSyntax.FullSpan.End;
            bool atEOF = position == fullEnd && position == this.SyntaxTree.GetRoot().FullSpan.End;

            if ((fullStart <= position && position < fullEnd) || atEOF) // allow for EOF
            {
                token = ((LanguageSyntaxNode)(atEOF ?this.SyntaxTree.GetRoot() : RootSyntax.NodeOrParent)).FindToken(position);

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
                string.Format(CSharpResources.PositionIsNotWithinSyntax, RootSyntax.FullSpan));
        }

        /// <summary>
        /// A convenience method that determines a position from a node.  If the node is missing,
        /// then its position will be adjusted using CheckAndAdjustPosition.
        /// </summary>
        internal protected int GetAdjustedNodePosition(SyntaxNodeOrToken node)
        {
            Debug.Assert(IsInTree(node));

            var fullSpan = this.RootSyntax.FullSpan;
            var position = node.SpanStart;

            // skip zero-width tokens to get the position, but never get past the end of the node
            int betterPosition = node.NodeOrParent.GetFirstToken(includeZeroWidth: false).SpanStart;
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
            else if (node.IsMissing || node.NodeOrParent.HasErrors || node.Width == 0 || node.NodeOrParent.IsPartOfStructuredTrivia())
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

        internal protected void CheckSyntaxNode(SyntaxNodeOrToken syntax)
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

        public virtual BoundTree GetEnclosingBoundTree(SyntaxNodeOrToken syntax)
        {
            return this;
        }

        public Binder GetEnclosingBinderWithinRoot(SyntaxNode node, int position)
        {
            AssertPositionAdjusted(position);
            return GetEnclosingBinderInternalWithinRoot(node, position, _rootBinder, this.RootSyntax);
        }

        internal static Binder GetEnclosingBinderInternalWithinRoot(SyntaxNode node, int position, Binder rootBinder, SyntaxNodeOrToken root)
        {
            if (node == root)
            {
                return rootBinder.GetBinder(node) ?? rootBinder;
            }

            Debug.Assert(root.NodeOrParent.Contains(node));

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
        public virtual BoundNode GetBoundRoot()
        {
            // TODO:MetaDslx
            return _rootBinder.Bind(_rootSyntax);
        }

        // We might not have actually been given a bindable expression or statement; the caller can
        // give us variable declaration nodes, for example. If we're not at an expression or
        // statement, back up until we find one.
        public SyntaxNodeOrToken GetBindingRoot(SyntaxNodeOrToken node)
        {
            Debug.Assert(node != null);
            // TODO:MetaDslx
            if (node == null) return this.RootSyntax;
            else return node;
        }


        // some nodes don't have direct semantic meaning by themselves and so we need to bind a different node that does
        internal protected SyntaxNodeOrToken GetBindableSyntaxNode(SyntaxNodeOrToken node)
        {
            Debug.Assert(node != null);
            // TODO:MetaDslx
            if (node == null) return this.RootSyntax;
            else return node;
        }

        /// <summary>
        /// Return the nearest parent node with semantic meaning.
        /// </summary>
        internal protected SyntaxNodeOrToken GetBindableParentNode(SyntaxNodeOrToken node, bool allowNullParent = false)
        {
            // The node is an expression, but its parent is null
            LanguageSyntaxNode parent = (LanguageSyntaxNode)node.NodeOrParent;
            if (parent == null)
            {
                // For speculative model, expression might be the root of the syntax tree, in which case it can have a null parent.
                if (allowNullParent && this.RootSyntax == node)
                {
                    return null;
                }

                throw new ArgumentException($"The parent of {nameof(node)} must not be null.", nameof(node));
            }

            var bindableParent = this.GetBindableSyntaxNode(parent);
            Debug.Assert(bindableParent != null);
            return bindableParent;
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
            if (!this.RootSyntax.FullSpan.Contains(position))
                return _rootBinder;

            SyntaxToken token = this.RootSyntax.NodeOrParent.FindToken(position);
            LanguageSyntaxNode node = (LanguageSyntaxNode)token.Parent;

            return GetEnclosingBinderInternal(node, position);
        }

        public Binder GetEnclosingBinder(SyntaxNode node)
        {
            return GetEnclosingBinder(GetAdjustedNodePosition(node));
        }

        public Binder GetEnclosingBinder(SyntaxToken token)
        {
            return GetEnclosingBinder(GetAdjustedNodePosition(token.Parent));
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
        public ImmutableArray<BoundNode> GetBoundNodes(SyntaxNodeOrToken node)
        {
            // TODO:MetaDslx
            return ImmutableArray<BoundNode>.Empty;
        }

        public void GetBoundNodes(SyntaxNodeOrToken node, out SyntaxNodeOrToken bindableNode, out ImmutableArray<BoundNode> boundNodes, out BoundNode boundParent)
        {
            bindableNode = node;
            boundNodes = ImmutableArray<BoundNode>.Empty;
            boundParent = default;
            // TODO:MetaDslx
        }


    }
}
