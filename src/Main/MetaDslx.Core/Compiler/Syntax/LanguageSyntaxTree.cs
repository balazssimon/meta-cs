// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.PooledObjects;
using MetaDslx.Compiler.Text;
using MetaDslx.Compiler.Utilities;
using InternalSyntax = MetaDslx.Compiler.Syntax.InternalSyntax;
using MetaDslx.Compiler.Syntax.InternalSyntax;

namespace MetaDslx.Compiler
{
    /// <summary>
    /// The parsed representation of a source document.
    /// </summary>
    public abstract partial class LanguageSyntaxTree<TNode> : SyntaxTree
        where TNode: LanguageSyntaxNode
    {
        // REVIEW: I would prefer to not expose CloneAsRoot and make the functionality
        // internal to CaaS layer, to ensure that for a given SyntaxTree there can not
        // be multiple trees claiming to be its children.
        // 
        // However, as long as we provide GetRoot extensibility point on SyntaxTree
        // the guarantee above cannot be implemented and we have to provide some way for
        // creating root nodes.
        //
        // Therefore I place CloneAsRoot API on SyntaxTree and make it protected to
        // at least limit its visibility to SyntaxTree extenders.

        /// <summary>
        /// Produces a clone of a <see cref="TNode"/> which will have current syntax tree as its parent.
        /// 
        /// Caller must guarantee that if the same instance of <see cref="TNode"/> makes multiple calls
        /// to this function, only one result is observable.
        /// </summary>
        /// <typeparam name="T">Type of the syntax node.</typeparam>
        /// <param name="node">The original syntax node.</param>
        /// <returns>A clone of the original syntax node that has current <see cref="LanguageSyntaxTree"/> as its parent.</returns>
        protected T CloneNodeAsRoot<T>(T node) where T : TNode
        {
            return LanguageSyntaxNode.CloneNodeAsRoot(node, this);
        }

        /// <summary>
        /// Gets the root node of the syntax tree.
        /// </summary>
        public new abstract TNode GetRoot(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the root node of the syntax tree if it is already available.
        /// </summary>
        public abstract bool TryGetRoot(out TNode root);

        /// <summary>
        /// Gets the root node of the syntax tree asynchronously.
        /// </summary>
        /// <remarks>
        /// By default, the work associated with this method will be executed immediately on the current thread.
        /// Implementations that wish to schedule this work differently should override <see cref="GetRootAsync(CancellationToken)"/>.
        /// </remarks>
        public new virtual Task<TNode> GetRootAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            TNode node;
            return Task.FromResult(this.TryGetRoot(out node) ? node : this.GetRoot(cancellationToken));
        }

        /// <summary>
        /// Determines if two trees are the same, disregarding trivia differences.
        /// </summary>
        /// <param name="tree">The tree to compare against.</param>
        public bool IsEquivalentTo(SyntaxTree tree)
        {
            return this.Language.SyntaxFactory.AreEquivalent(this, tree);
        }

        #region Changes

        /// <summary>
        /// Produces a pessimistic list of spans that denote the regions of text in this tree that
        /// are changed from the text of the old tree.
        /// </summary>
        /// <param name="oldTree">The old tree. Cannot be <c>null</c>.</param>
        /// <remarks>The list is pessimistic because it may claim more or larger regions than actually changed.</remarks>
        public override IList<TextSpan> GetChangedSpans(SyntaxTree oldTree)
        {
            if (oldTree == null)
            {
                throw new ArgumentNullException(nameof(oldTree));
            }

            return SyntaxDiffer.GetPossiblyDifferentTextSpans(oldTree, this);
        }

        /// <summary>
        /// Gets a list of text changes that when applied to the old tree produce this tree.
        /// </summary>
        /// <param name="oldTree">The old tree. Cannot be <c>null</c>.</param>
        /// <remarks>The list of changes may be different than the original changes that produced this tree.</remarks>
        public override IList<TextChange> GetChanges(SyntaxTree oldTree)
        {
            if (oldTree == null)
            {
                throw new ArgumentNullException(nameof(oldTree));
            }

            return SyntaxDiffer.GetTextChanges(oldTree, this);
        }

        #endregion

        #region LinePositions and Locations

        /// <summary>
        /// Gets the location in terms of path, line and column for a given span.
        /// </summary>
        /// <param name="span">Span within the tree.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>
        /// <see cref="FileLinePositionSpan"/> that contains path, line and column information.
        /// </returns>
        /// <remarks>The values are not affected by line mapping directives (<c>#line</c>).</remarks>
        public override FileLinePositionSpan GetLineSpan(TextSpan span, CancellationToken cancellationToken = default(CancellationToken))
        {
            return new FileLinePositionSpan(this.FilePath, GetLinePosition(span.Start), GetLinePosition(span.End));
        }

        private LinePosition GetLinePosition(int position)
        {
            return this.GetText().Lines.GetLinePosition(position);
        }

        /// <summary>
        /// Gets a <see cref="Location"/> for the specified text <paramref name="span"/>.
        /// </summary>
        public override Location GetLocation(TextSpan span)
        {
            return new SourceLocation(this, span);
        }

        #endregion

        #region Diagnostics

        /// <summary>
        /// Gets a list of all the diagnostics in the sub tree that has the specified node as its root.
        /// </summary>
        /// <remarks>
        /// This method does not filter diagnostics based on <c>#pragma</c>s and compiler options
        /// like /nowarn, /warnaserror etc.
        /// </remarks>
        public override IEnumerable<Diagnostic> GetDiagnostics(SyntaxNode node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }

            return GetDiagnostics(node.Green, node.Position);
        }

        private IEnumerable<Diagnostic> GetDiagnostics(GreenNode greenNode, int position)
        {
            if (greenNode == null)
            {
                throw new InvalidOperationException();
            }

            if (greenNode.ContainsDiagnostics)
            {
                return EnumerateDiagnostics(greenNode, position);
            }

            return SpecializedCollections.EmptyEnumerable<Diagnostic>();
        }

        private IEnumerable<Diagnostic> EnumerateDiagnostics(GreenNode node, int position)
        {
            var enumerator = new SyntaxTreeDiagnosticEnumerator(this, node, position);
            while (enumerator.MoveNext())
            {
                yield return enumerator.Current;
            }
        }

        /// <summary>
        /// Gets a list of all the diagnostics associated with the token and any related trivia.
        /// </summary>
        /// <remarks>
        /// This method does not filter diagnostics based on <c>#pragma</c>s and compiler options
        /// like /nowarn, /warnaserror etc.
        /// </remarks>
        public override IEnumerable<Diagnostic> GetDiagnostics(SyntaxToken token)
        {
            return GetDiagnostics(token.Node, token.Position);
        }

        /// <summary>
        /// Gets a list of all the diagnostics associated with the trivia.
        /// </summary>
        /// <remarks>
        /// This method does not filter diagnostics based on <c>#pragma</c>s and compiler options
        /// like /nowarn, /warnaserror etc.
        /// </remarks>
        public override IEnumerable<Diagnostic> GetDiagnostics(SyntaxTrivia trivia)
        {
            return GetDiagnostics(trivia.UnderlyingNode, trivia.Position);
        }

        /// <summary>
        /// Gets a list of all the diagnostics in either the sub tree that has the specified node as its root or
        /// associated with the token and its related trivia. 
        /// </summary>
        /// <remarks>
        /// This method does not filter diagnostics based on <c>#pragma</c>s and compiler options
        /// like /nowarn, /warnaserror etc.
        /// </remarks>
        public override IEnumerable<Diagnostic> GetDiagnostics(SyntaxNodeOrToken nodeOrToken)
        {
            return GetDiagnostics(nodeOrToken.UnderlyingNode, nodeOrToken.Position);
        }

        /// <summary>
        /// Gets a list of all the diagnostics in the syntax tree.
        /// </summary>
        /// <remarks>
        /// This method does not filter diagnostics based on <c>#pragma</c>s and compiler options
        /// like /nowarn, /warnaserror etc.
        /// </remarks>
        public override IEnumerable<Diagnostic> GetDiagnostics(CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.GetDiagnostics(this.GetRoot(cancellationToken));
        }

        #endregion

        #region SyntaxTree

        protected override SyntaxNode GetRootCore(CancellationToken cancellationToken)
        {
            return this.GetRoot(cancellationToken);
        }

        protected override async Task<SyntaxNode> GetRootAsyncCore(CancellationToken cancellationToken)
        {
            return await this.GetRootAsync(cancellationToken).ConfigureAwait(false);
        }

        protected override bool TryGetRootCore(out SyntaxNode root)
        {
            TNode node;
            if (this.TryGetRoot(out node))
            {
                root = node;
                return true;
            }
            else
            {
                root = null;
                return false;
            }
        }

        protected override ParseOptions OptionsCore
        {
            get
            {
                return this.Options;
            }
        }

        #endregion
    }
}
