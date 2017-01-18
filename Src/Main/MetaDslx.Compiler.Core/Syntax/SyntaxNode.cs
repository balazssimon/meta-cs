using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Compiler.Syntax.InternalSyntax;
using System.Diagnostics;
using System.Threading;
using MetaDslx.Compiler.Utilities;
using MetaDslx.Compiler.Text;
using MetaDslx.Compiler.Diagnostics;

namespace MetaDslx.Compiler.Syntax
{
    public abstract class SyntaxNode : RedNode
    {
        private SyntaxTree _syntaxTree;

        protected SyntaxNode(InternalSyntaxNode green, SyntaxTree syntaxTree, int position) 
            : base(green, null, position)
        {
            Debug.Assert(syntaxTree != null, "syntaxTree cannot be null");

            this._syntaxTree = syntaxTree;
        }

        protected SyntaxNode(InternalSyntaxNode green, SyntaxNode parent, int position) 
            : base(green, parent, position)
        {
            Debug.Assert(parent != null, "parent cannot be null");
        }

        internal InternalSyntaxNode GreenNode
        {
            get { return (InternalSyntaxNode)this.Green; }
        }

        public override SyntaxTree SyntaxTree 
        {
            get
            {
                if (this._syntaxTree != null) return this._syntaxTree;
                Interlocked.CompareExchange(ref this._syntaxTree, this.Parent?.SyntaxTree, null);
                return this._syntaxTree;
            }
        }

        internal SyntaxNavigator Navigator
        {
            get
            {
                return SyntaxNavigator.Instance;
            }
        }

        public SyntaxNode WithAnnotations(params SyntaxAnnotation[] annotations)
        {
            return (SyntaxNode)((InternalSyntaxNode)this.Green.WithAnnotations(annotations)).CreateRed();
        }

        public Location GetLocation()
        {
            return this.SyntaxTree.GetLocation(this.Span);
        }

        /// <summary>
        /// Gets a list of all the diagnostics in the sub tree that has this node as its root.
        /// This method does not filter diagnostics based on #pragmas and compiler options
        /// like nowarn, warnaserror etc.
        /// </summary>
        public IEnumerable<Diagnostic> GetDiagnostics()
        {
            return this.SyntaxTree.GetDiagnostics(this);
        }

        /// <summary>
        /// Gets a <see cref="SyntaxReference"/> for this syntax node. CommonSyntaxReferences can be used to
        /// regain access to a syntax node without keeping the entire tree and source text in
        /// memory.
        /// </summary>
        public SyntaxReference GetReference()
        {
            return this.SyntaxTree.GetReference(this);
        }

        /// <summary>
        /// Determines whether this node has any leading trivia.
        /// </summary>
        public bool HasLeadingTrivia
        {
            get
            {
                return this.GetLeadingTrivia().Count > 0;
            }
        }

        /// <summary>
        /// Determines whether this node has any trailing trivia.
        /// </summary>
        public bool HasTrailingTrivia
        {
            get
            {
                return this.GetTrailingTrivia().Count > 0;
            }
        }

        /// <summary>
        /// The list of child nodes and tokens of this node, where each element is a RedNode instance.
        /// </summary>
        public ChildSyntaxList ChildNodesAndTokens()
        {
            return new ChildSyntaxList(this);
        }

        /// <summary>
        /// Returns child node or token that contains given position.
        /// </summary>
        public RedNode ChildThatContainsPosition(int position)
        {
            //PERF: it is very important to keep this method fast.

            if (!FullSpan.Contains(position))
            {
                throw new ArgumentOutOfRangeException(nameof(position));
            }

            RedNode childNodeOrToken = ChildSyntaxList.ChildThatContainsPosition(this, position);
            Debug.Assert(childNodeOrToken.FullSpan.Contains(position), "ChildThatContainsPosition's return value does not contain the requested position.");
            return childNodeOrToken;
        }

        /// <summary>
        /// Gets a list of the child nodes in prefix document order.
        /// </summary>
        public IEnumerable<SyntaxNode> ChildNodes()
        {
            foreach (var nodeOrToken in this.ChildNodesAndTokens())
            {
                if (nodeOrToken.IsNode)
                {
                    yield return (SyntaxNode)nodeOrToken;
                }
            }
        }

        /// <summary>
        /// Gets a list of the direct child tokens of this node.
        /// </summary>
        public IEnumerable<SyntaxToken> ChildTokens()
        {
            foreach (var nodeOrToken in this.ChildNodesAndTokens())
            {
                if (nodeOrToken.IsToken)
                {
                    yield return (SyntaxToken)nodeOrToken;
                }
            }
        }

        /// <summary>
        /// Gets a list of ancestor nodes
        /// </summary>
        public IEnumerable<SyntaxNode> Ancestors(bool ascendOutOfTrivia = true)
        {
            return this.Parent?.AncestorsAndSelf(ascendOutOfTrivia) ?? EmptyCollections.Enumerable<SyntaxNode>();
        }

        /// <summary>
        /// Gets a list of ancestor nodes (including this node) 
        /// </summary>
        public IEnumerable<SyntaxNode> AncestorsAndSelf(bool ascendOutOfTrivia = true)
        {
            for (var node = this; node != null; node = GetParent(node, ascendOutOfTrivia))
            {
                yield return node;
            }
        }

        private static SyntaxNode GetParent(SyntaxNode node, bool ascendOutOfTrivia)
        {
            var parent = node.Parent;
            if (parent == null && ascendOutOfTrivia)
            {
                var structuredTrivia = node as IStructuredTriviaSyntax;
                if (structuredTrivia != null)
                {
                    parent = structuredTrivia.ParentTrivia.Token.Parent;
                }
            }

            return parent;
        }

        /// <summary>
        /// Gets the first node of type TNode that matches the predicate.
        /// </summary>
        public TNode FirstAncestorOrSelf<TNode>(Func<TNode, bool> predicate = null, bool ascendOutOfTrivia = true)
            where TNode : SyntaxNode
        {
            for (var node = this; node != null; node = GetParent(node, ascendOutOfTrivia))
            {
                var tnode = node as TNode;
                if (tnode != null && (predicate == null || predicate(tnode)))
                {
                    return tnode;
                }
            }

            return null;
        }

        /// <summary>
        /// Gets a list of descendant nodes in prefix document order.
        /// </summary>
        /// <param name="descendIntoChildren">An optional function that determines if the search descends into the argument node's children.</param>
        /// <param name="descendIntoTrivia">Determines if nodes that are part of structured trivia are included in the list.</param>
        public IEnumerable<SyntaxNode> DescendantNodes(Func<SyntaxNode, bool> descendIntoChildren = null, bool descendIntoTrivia = false)
        {
            return DescendantNodesImpl(this.FullSpan, descendIntoChildren, descendIntoTrivia, includeSelf: false);
        }

        /// <summary>
        /// Gets a list of descendant nodes in prefix document order.
        /// </summary>
        /// <param name="span">The span the node's full span must intersect.</param>
        /// <param name="descendIntoChildren">An optional function that determines if the search descends into the argument node's children.</param>
        /// <param name="descendIntoTrivia">Determines if nodes that are part of structured trivia are included in the list.</param>
        public IEnumerable<SyntaxNode> DescendantNodes(TextSpan span, Func<SyntaxNode, bool> descendIntoChildren = null, bool descendIntoTrivia = false)
        {
            return DescendantNodesImpl(span, descendIntoChildren, descendIntoTrivia, includeSelf: false);
        }

        /// <summary>
        /// Gets a list of descendant nodes (including this node) in prefix document order.
        /// </summary>
        /// <param name="descendIntoChildren">An optional function that determines if the search descends into the argument node's children.</param>
        /// <param name="descendIntoTrivia">Determines if nodes that are part of structured trivia are included in the list.</param>
        public IEnumerable<SyntaxNode> DescendantNodesAndSelf(Func<SyntaxNode, bool> descendIntoChildren = null, bool descendIntoTrivia = false)
        {
            return DescendantNodesImpl(this.FullSpan, descendIntoChildren, descendIntoTrivia, includeSelf: true);
        }

        /// <summary>
        /// Gets a list of descendant nodes (including this node) in prefix document order.
        /// </summary>
        /// <param name="span">The span the node's full span must intersect.</param>
        /// <param name="descendIntoChildren">An optional function that determines if the search descends into the argument node's children.</param>
        /// <param name="descendIntoTrivia">Determines if nodes that are part of structured trivia are included in the list.</param>
        public IEnumerable<SyntaxNode> DescendantNodesAndSelf(TextSpan span, Func<SyntaxNode, bool> descendIntoChildren = null, bool descendIntoTrivia = false)
        {
            return DescendantNodesImpl(span, descendIntoChildren, descendIntoTrivia, includeSelf: true);
        }

        /// <summary>
        /// Gets a list of descendant nodes and tokens in prefix document order.
        /// </summary>
        /// <param name="descendIntoChildren">An optional function that determines if the search descends into the argument node's children.</param>
        /// <param name="descendIntoTrivia">Determines if nodes that are part of structured trivia are included in the list.</param>
        public IEnumerable<RedNode> DescendantNodesAndTokens(Func<SyntaxNode, bool> descendIntoChildren = null, bool descendIntoTrivia = false)
        {
            return DescendantNodesAndTokensImpl(this.FullSpan, descendIntoChildren, descendIntoTrivia, includeSelf: false);
        }

        /// <summary>
        /// Gets a list of the descendant nodes and tokens in prefix document order.
        /// </summary>
        /// <param name="span">The span the node's full span must intersect.</param>
        /// <param name="descendIntoChildren">An optional function that determines if the search descends into the argument node's children.</param>
        /// <param name="descendIntoTrivia">Determines if nodes that are part of structured trivia are included in the list.</param>
        public IEnumerable<RedNode> DescendantNodesAndTokens(TextSpan span, Func<SyntaxNode, bool> descendIntoChildren = null, bool descendIntoTrivia = false)
        {
            return DescendantNodesAndTokensImpl(span, descendIntoChildren, descendIntoTrivia, includeSelf: false);
        }

        /// <summary>
        /// Gets a list of descendant nodes and tokens (including this node) in prefix document order.
        /// </summary>
        /// <param name="descendIntoChildren">An optional function that determines if the search descends into the argument node's children.</param>
        /// <param name="descendIntoTrivia">Determines if nodes that are part of structured trivia are included in the list.</param>
        public IEnumerable<RedNode> DescendantNodesAndTokensAndSelf(Func<SyntaxNode, bool> descendIntoChildren = null, bool descendIntoTrivia = false)
        {
            return DescendantNodesAndTokensImpl(this.FullSpan, descendIntoChildren, descendIntoTrivia, includeSelf: true);
        }

        /// <summary>
        /// Gets a list of the descendant nodes and tokens (including this node) in prefix document order.
        /// </summary>
        /// <param name="span">The span the node's full span must intersect.</param>
        /// <param name="descendIntoChildren">An optional function that determines if the search descends into the argument node's children.</param>
        /// <param name="descendIntoTrivia">Determines if nodes that are part of structured trivia are included in the list.</param>
        public IEnumerable<RedNode> DescendantNodesAndTokensAndSelf(TextSpan span, Func<SyntaxNode, bool> descendIntoChildren = null, bool descendIntoTrivia = false)
        {
            return DescendantNodesAndTokensImpl(span, descendIntoChildren, descendIntoTrivia, includeSelf: true);
        }

        /// <summary>
        /// Finds the node with the smallest <see cref="FullSpan"/> that contains <paramref name="span"/>.
        /// <paramref name="getInnermostNodeForTie"/> is used to determine the behavior in case of a tie (i.e. a node having the same span as its parent).
        /// If <paramref name="getInnermostNodeForTie"/> is true, then it returns lowest descending node encompassing the given <paramref name="span"/>.
        /// Otherwise, it returns the outermost node encompassing the given <paramref name="span"/>.
        /// </summary>
        /// <remarks>
        /// TODO: This should probably be reimplemented with <see cref="ChildThatContainsPosition"/>
        /// </remarks>
        /// <exception cref="ArgumentOutOfRangeException">This exception is thrown if <see cref="FullSpan"/> doesn't contain the given span.</exception>
        public SyntaxNode FindNode(TextSpan span, bool findInsideTrivia = false, bool getInnermostNodeForTie = false)
        {
            if (!this.FullSpan.Contains(span))
            {
                throw new ArgumentOutOfRangeException(nameof(span));
            }

            var node = FindToken(span.Start, findInsideTrivia)
                .Parent
                .FirstAncestorOrSelf<SyntaxNode>(a => a.FullSpan.Contains(span));

            var cuRoot = node.SyntaxTree?.GetRoot();

            // Tie-breaking.
            if (!getInnermostNodeForTie)
            {
                while (true)
                {
                    var parent = node.Parent;
                    // NOTE: We care about FullSpan equality, but FullWidth is cheaper and equivalent.
                    if (parent == null || parent.FullWidth != node.FullWidth) break;
                    // prefer child over compilation unit
                    if (parent == cuRoot) break;
                    node = parent;
                }
            }

            return node;
        }

        #region Token Lookup
        /// <summary>
        /// Finds a descendant token of this node whose span includes the supplied position. 
        /// </summary>
        /// <param name="position">The character position of the token relative to the beginning of the file.</param>
        /// <param name="findInsideTrivia">
        /// True to return tokens that are part of trivia. If false finds the token whose full span (including trivia)
        /// includes the position.
        /// </param>
        public SyntaxToken FindToken(int position, bool findInsideTrivia = false)
        {
            return FindTokenCore(position, findInsideTrivia);
        }

        /// <summary>
        /// Gets the first token of the tree rooted by this node. Skips zero-width tokens.
        /// </summary>
        /// <returns>The first token or <c>default(SyntaxToken)</c> if it doesn't exist.</returns>
        public SyntaxToken GetFirstToken(bool includeZeroWidth = false)
        {
            return this.Navigator.GetFirstToken(this, includeZeroWidth);
        }

        /// <summary>
        /// Gets the last token of the tree rooted by this node. Skips zero-width tokens.
        /// </summary>
        /// <returns>The last token or <c>default(SyntaxToken)</c> if it doesn't exist.</returns>
        public SyntaxToken GetLastToken(bool includeZeroWidth = false)
        {
            return this.Navigator.GetLastToken(this, includeZeroWidth);
        }

        /// <summary>
        /// Gets a list of all the tokens in the span of this node.
        /// </summary>
        public IEnumerable<SyntaxToken> DescendantTokens(Func<SyntaxNode, bool> descendIntoChildren = null, bool descendIntoTrivia = false)
        {
            return this.DescendantNodesAndTokens(descendIntoChildren, descendIntoTrivia).Where(sn => sn.IsToken).Select(sn => (SyntaxToken)sn);
        }

        /// <summary>
        /// Gets a list of all the tokens in the full span of this node.
        /// </summary>
        public IEnumerable<SyntaxToken> DescendantTokens(TextSpan span, Func<SyntaxNode, bool> descendIntoChildren = null, bool descendIntoTrivia = false)
        {
            return this.DescendantNodesAndTokens(span, descendIntoChildren, descendIntoTrivia).Where(sn => sn.IsToken).Select(sn => (SyntaxToken)sn);
        }

        #endregion

        #region Trivia Lookup
        /// <summary>
        /// The list of trivia that appears before this node in the source code and are attached to a token that is a
        /// descendant of this node.
        /// </summary>
        public SyntaxTriviaList GetLeadingTrivia()
        {
            return GetFirstToken(includeZeroWidth: true).LeadingTrivia;
        }

        /// <summary>
        /// The list of trivia that appears after this node in the source code and are attached to a token that is a
        /// descendant of this node.
        /// </summary>
        public SyntaxTriviaList GetTrailingTrivia()
        {
            return GetLastToken(includeZeroWidth: true).TrailingTrivia;
        }

        /// <summary>
        /// Finds a descendant trivia of this node whose span includes the supplied position.
        /// </summary>
        /// <param name="position">The character position of the trivia relative to the beginning of the file.</param>
        /// <param name="findInsideTrivia">
        /// True to return tokens that are part of trivia. If false finds the token whose full span (including trivia)
        /// includes the position.
        /// </param>
        public SyntaxTrivia FindTrivia(int position, bool findInsideTrivia = false)
        {
            return FindTrivia(position, findInsideTrivia ? SyntaxTrivia.Any : null);
        }

        /// <summary>
        /// Finds a descendant trivia of this node at the specified position, where the position is
        /// within the span of the node.
        /// </summary>
        /// <param name="position">The character position of the trivia relative to the beginning of
        /// the file.</param>
        /// <param name="stepInto">Specifies a function that determines per trivia node, whether to
        /// descend into structured trivia of that node.</param>
        /// <returns></returns>
        public SyntaxTrivia FindTrivia(int position, Func<SyntaxTrivia, bool> stepInto)
        {
            if (this.FullSpan.Contains(position))
            {
                return FindTriviaByOffset(this, position - this.Position, stepInto);
            }

            return null;
        }

        internal static SyntaxTrivia FindTriviaByOffset(SyntaxNode node, int textOffset, Func<SyntaxTrivia, bool> stepInto = null)
        {
        recurse:
            if (textOffset >= 0)
            {
                foreach (var element in node.ChildNodesAndTokens())
                {
                    var fullWidth = element.FullWidth;
                    if (textOffset < fullWidth)
                    {
                        if (element.IsNode)
                        {
                            node = (SyntaxNode)element;
                            goto recurse;
                        }
                        else if (element.IsToken)
                        {
                            var token = (SyntaxToken)element;
                            var leading = token.LeadingWidth;
                            if (textOffset < token.LeadingWidth)
                            {
                                foreach (var trivia in token.LeadingTrivia)
                                {
                                    if (textOffset < trivia.FullWidth)
                                    {
                                        if (trivia.HasStructure && stepInto != null && stepInto(trivia))
                                        {
                                            node = trivia.GetStructure();
                                            goto recurse;
                                        }

                                        return trivia;
                                    }

                                    textOffset -= trivia.FullWidth;
                                }
                            }
                            else if (textOffset >= leading + token.Width)
                            {
                                textOffset -= leading + token.Width;
                                foreach (var trivia in token.TrailingTrivia)
                                {
                                    if (textOffset < trivia.FullWidth)
                                    {
                                        if (trivia.HasStructure && stepInto != null && stepInto(trivia))
                                        {
                                            node = trivia.GetStructure();
                                            goto recurse;
                                        }

                                        return trivia;
                                    }

                                    textOffset -= trivia.FullWidth;
                                }
                            }

                            return null;
                        }
                    }

                    textOffset -= fullWidth;
                }
            }

            return null;
        }

        /// <summary>
        /// Get a list of all the trivia associated with the descendant nodes and tokens.
        /// </summary>
        public IEnumerable<SyntaxTrivia> DescendantTrivia(Func<SyntaxNode, bool> descendIntoChildren = null, bool descendIntoTrivia = false)
        {
            return DescendantTriviaImpl(this.FullSpan, descendIntoChildren, descendIntoTrivia);
        }

        /// <summary>
        /// Get a list of all the trivia associated with the descendant nodes and tokens.
        /// </summary>
        public IEnumerable<SyntaxTrivia> DescendantTrivia(TextSpan span, Func<SyntaxNode, bool> descendIntoChildren = null, bool descendIntoTrivia = false)
        {
            return DescendantTriviaImpl(span, descendIntoChildren, descendIntoTrivia);
        }

        #endregion

        #region Annotations

        /// <summary>
        /// Gets all nodes and tokens with an annotation of the specified annotation kind.
        /// </summary>
        public IEnumerable<RedNode> GetAnnotatedNodesAndTokens(string annotationKind)
        {
            return this.DescendantNodesAndTokensAndSelf(n => n.ContainsAnnotations, descendIntoTrivia: true)
                .Where(t => t.HasAnnotations(annotationKind));
        }

        /// <summary>
        /// Gets all nodes and tokens with an annotation of the specified annotation kinds.
        /// </summary>
        public IEnumerable<RedNode> GetAnnotatedNodesAndTokens(params string[] annotationKinds)
        {
            return this.DescendantNodesAndTokensAndSelf(n => n.ContainsAnnotations, descendIntoTrivia: true)
                .Where(t => t.HasAnnotations(annotationKinds));
        }

        /// <summary>
        /// Gets all nodes and tokens with the specified annotation.
        /// </summary>
        public IEnumerable<RedNode> GetAnnotatedNodesAndTokens(SyntaxAnnotation annotation)
        {
            return this.DescendantNodesAndTokensAndSelf(n => n.ContainsAnnotations, descendIntoTrivia: true)
                .Where(t => t.HasAnnotation(annotation));
        }

        /// <summary>
        /// Gets all nodes with the specified annotation.
        /// </summary>
        public IEnumerable<SyntaxNode> GetAnnotatedNodes(SyntaxAnnotation syntaxAnnotation)
        {
            return this.GetAnnotatedNodesAndTokens(syntaxAnnotation).Where(n => n.IsNode).Select(n => (SyntaxNode)n);
        }

        /// <summary>
        /// Gets all nodes with the specified annotation kind.
        /// </summary>
        /// <param name="annotationKind"></param>
        /// <returns></returns>
        public IEnumerable<SyntaxNode> GetAnnotatedNodes(string annotationKind)
        {
            return this.GetAnnotatedNodesAndTokens(annotationKind).Where(n => n.IsNode).Select(n => (SyntaxNode)n);
        }

        /// <summary>
        /// Gets all tokens with the specified annotation.
        /// </summary>
        public IEnumerable<SyntaxToken> GetAnnotatedTokens(SyntaxAnnotation syntaxAnnotation)
        {
            return this.GetAnnotatedNodesAndTokens(syntaxAnnotation).Where(n => n.IsToken).Select(n => (SyntaxToken)n);
        }

        /// <summary>
        /// Gets all tokens with the specified annotation kind.
        /// </summary>
        public IEnumerable<SyntaxToken> GetAnnotatedTokens(string annotationKind)
        {
            return this.GetAnnotatedNodesAndTokens(annotationKind).Where(n => n.IsToken).Select(n => (SyntaxToken)n);
        }

        /// <summary>
        /// Gets all trivia with an annotation of the specified annotation kind.
        /// </summary>
        public IEnumerable<SyntaxTrivia> GetAnnotatedTrivia(string annotationKind)
        {
            return this.DescendantTrivia(n => n.ContainsAnnotations, descendIntoTrivia: true)
                       .Where(tr => tr.HasAnnotations(annotationKind));
        }

        /// <summary>
        /// Gets all trivia with an annotation of the specified annotation kinds.
        /// </summary>
        public IEnumerable<SyntaxTrivia> GetAnnotatedTrivia(params string[] annotationKinds)
        {
            return this.DescendantTrivia(n => n.ContainsAnnotations, descendIntoTrivia: true)
                       .Where(tr => tr.HasAnnotations(annotationKinds));
        }

        /// <summary>
        /// Gets all trivia with the specified annotation.
        /// </summary>
        public IEnumerable<SyntaxTrivia> GetAnnotatedTrivia(SyntaxAnnotation annotation)
        {
            return this.DescendantTrivia(n => n.ContainsAnnotations, descendIntoTrivia: true)
                       .Where(tr => tr.HasAnnotation(annotation));
        }

        internal SyntaxNode WithAdditionalAnnotationsInternal(IEnumerable<SyntaxAnnotation> annotations)
        {
            return (SyntaxNode)this.Green.WithAdditionalAnnotationsGreen(annotations).CreateRed();
        }

        internal SyntaxNode GetNodeWithoutAnnotations(IEnumerable<SyntaxAnnotation> annotations)
        {
            return (SyntaxNode)this.Green.WithoutAnnotationsGreen(annotations).CreateRed();
        }

        /// <summary>
        /// Copies all SyntaxAnnotations, if any, from this SyntaxNode instance and attaches them to a new instance based on <paramref name="node" />.
        /// </summary>
        /// <remarks>
        /// <para>
        /// If no annotations are copied, just returns <paramref name="node" />.
        /// </para>
        /// <para>
        /// It can also be used manually to preserve annotations in a more complex tree
        /// modification, even if the type of a node changes.
        /// </para>
        /// </remarks>
        public T CopyAnnotationsTo<T>(T node) where T : SyntaxNode
        {
            if (node == null)
            {
                return null;
            }

            var annotations = this.Green.GetAnnotations();
            if (annotations?.Length > 0)
            {
                return (T)(node.Green.WithAdditionalAnnotationsGreen(annotations)).CreateRed();
            }
            return node;
        }

        #endregion

        /// Finds a descendant token of this node whose span includes the supplied position. 
        /// </summary>
        /// <param name="position">The character position of the token relative to the beginning of the file.</param>
        /// <param name="findInsideTrivia">
        /// True to return tokens that are part of trivia.
        /// If false finds the token whose full span (including trivia) includes the position.
        /// </param>
        protected virtual SyntaxToken FindTokenCore(int position, bool findInsideTrivia)
        {
            if (findInsideTrivia)
            {
                return this.FindToken(position, SyntaxTrivia.Any);
            }

            SyntaxToken EoF;
            if (this.TryGetEofAt(position, out EoF))
            {
                return EoF;
            }

            if (!this.FullSpan.Contains(position))
            {
                throw new ArgumentOutOfRangeException(nameof(position));
            }

            return this.FindTokenInternal(position);
        }

        private bool TryGetEofAt(int position, out SyntaxToken Eof)
        {
            if (position == this.EndPosition)
            {
                var compilationUnit = this as ICompilationUnitSyntax;
                if (compilationUnit != null)
                {
                    Eof = compilationUnit.Eof;
                    Debug.Assert(Eof.EndPosition == position);
                    return true;
                }
            }

            Eof = null;
            return false;
        }

        internal SyntaxToken FindTokenInternal(int position)
        {
            // While maintaining invariant   curNode.Position <= position < curNode.FullSpan.End
            // go down the tree until a token is found
            RedNode curNode = this;

            while (true)
            {
                Debug.Assert(curNode.RawKind != 0);
                Debug.Assert(curNode.FullSpan.Contains(position));

                var node = curNode as SyntaxNode;

                if (node != null)
                {
                    //find a child that includes the position
                    curNode = node.ChildThatContainsPosition(position);
                }
                else
                {
                    return curNode as SyntaxToken;
                }
            }
        }

        private SyntaxToken FindToken(int position, Func<SyntaxTrivia, bool> findInsideTrivia)
        {
            return FindTokenCore(position, findInsideTrivia);
        }

        /// <summary>
        /// Finds a descendant token of this node whose span includes the supplied position. 
        /// </summary>
        /// <param name="position">The character position of the token relative to the beginning of the file.</param>
        /// <param name="stepInto">
        /// Applied on every structured trivia. Return false if the tokens included in the trivia should be skipped. 
        /// Pass null to skip all structured trivia.
        /// </param>
        protected virtual SyntaxToken FindTokenCore(int position, Func<SyntaxTrivia, bool> stepInto)
        {
            var token = this.FindToken(position, findInsideTrivia: false);
            if (stepInto != null)
            {
                var trivia = GetTriviaFromSyntaxToken(position, token);

                if (trivia.HasStructure && stepInto(trivia))
                {
                    token = trivia.GetStructure().FindTokenInternal(position);
                }
            }

            return token;
        }

        internal static SyntaxTrivia GetTriviaFromSyntaxToken(int position, SyntaxToken token)
        {
            var span = token.Span;
            SyntaxTrivia trivia = null;
            if (position < span.Start && token.HasLeadingTrivia)
            {
                trivia = GetTriviaThatContainsPosition(token.LeadingTrivia, position);
            }
            else if (position >= span.End && token.HasTrailingTrivia)
            {
                trivia = GetTriviaThatContainsPosition(token.TrailingTrivia, position);
            }

            return trivia;
        }

        internal static SyntaxTrivia GetTriviaThatContainsPosition(SyntaxTriviaList list, int position)
        {
            foreach (var trivia in list)
            {
                if (trivia.FullSpan.Contains(position))
                {
                    return trivia;
                }

                if (trivia.Position > position)
                {
                    break;
                }
            }

            return null;
        }

        /// <summary>
        /// Finds a descendant trivia of this node whose span includes the supplied position.
        /// </summary>
        /// <param name="position">The character position of the trivia relative to the beginning of the file.</param>
        /// <param name="findInsideTrivia">Whether to search inside structured trivia.</param>
        protected virtual SyntaxTrivia FindTriviaCore(int position, bool findInsideTrivia)
        {
            return FindTrivia(position, findInsideTrivia);
        }


        public abstract TResult Accept<TResult>(SyntaxVisitor<TResult> visitor);

        public abstract void Accept(SyntaxVisitor visitor);



        #region Iterators

        private IEnumerable<SyntaxNode> DescendantNodesImpl(TextSpan span, Func<SyntaxNode, bool> descendIntoChildren, bool descendIntoTrivia, bool includeSelf)
        {
            return descendIntoTrivia
                ? DescendantNodesAndTokensImpl(span, descendIntoChildren, true, includeSelf).Where(e => e.IsNode).Select(e => (SyntaxNode)e)
                : DescendantNodesOnly(span, descendIntoChildren, includeSelf);
        }

        private IEnumerable<RedNode> DescendantNodesAndTokensImpl(TextSpan span, Func<SyntaxNode, bool> descendIntoChildren, bool descendIntoTrivia, bool includeSelf)
        {
            return descendIntoTrivia
                ? DescendantNodesAndTokensIntoTrivia(span, descendIntoChildren, includeSelf)
                : DescendantNodesAndTokensOnly(span, descendIntoChildren, includeSelf);
        }

        private IEnumerable<SyntaxTrivia> DescendantTriviaImpl(TextSpan span, Func<SyntaxNode, bool> descendIntoChildren = null, bool descendIntoTrivia = false)
        {
            return descendIntoTrivia
                ? DescendantTriviaIntoTrivia(span, descendIntoChildren)
                : DescendantTriviaOnly(span, descendIntoChildren);
        }

        private static bool IsInSpan(ref TextSpan span, TextSpan childSpan)
        {
            return span.OverlapsWith(childSpan)
                // special case for zero-width tokens (OverlapsWith never returns true for these)
                || (childSpan.Length == 0 && span.IntersectsWith(childSpan));
        }

        private struct ChildSyntaxListEnumeratorStack : IDisposable
        {
            private static readonly ObjectPool<ChildSyntaxList.Enumerator[]> s_stackPool = new ObjectPool<ChildSyntaxList.Enumerator[]>(() => new ChildSyntaxList.Enumerator[16]);

            private ChildSyntaxList.Enumerator[] _stack;
            private int _stackPtr;

            public ChildSyntaxListEnumeratorStack(SyntaxNode startingNode, Func<SyntaxNode, bool> descendIntoChildren)
            {
                if (descendIntoChildren == null || descendIntoChildren(startingNode))
                {
                    _stack = s_stackPool.Allocate();
                    _stackPtr = 0;
                    _stack[0].InitializeFrom(startingNode);
                }
                else
                {
                    _stack = null;
                    _stackPtr = -1;
                }
            }

            public bool IsNotEmpty { get { return _stackPtr >= 0; } }

            public bool TryGetNextInSpan(ref /*readonly*/ TextSpan span, out RedNode value)
            {
                value = default(RedNode);

                while (_stack[_stackPtr].MoveToNextNode())
                {
                    value = _stack[_stackPtr].Current;
                    if (IsInSpan(ref span, value.FullSpan))
                    {
                        return true;
                    }
                }

                _stackPtr--;
                return false;
            }

            public SyntaxNode TryGetNextAsNodeInSpan(ref /*readonly*/ TextSpan span)
            {
                SyntaxNode nodeValue;
                while (_stack[_stackPtr].MoveToNextNode())
                {
                    nodeValue = _stack[_stackPtr].Current as SyntaxNode;
                    if (IsInSpan(ref span, nodeValue.FullSpan))
                    {
                        return nodeValue;
                    }
                }

                _stackPtr--;
                return null;
            }

            public void PushChildren(SyntaxNode node)
            {
                if (++_stackPtr >= _stack.Length)
                {
                    // Geometric growth
                    Array.Resize(ref _stack, checked(_stackPtr * 2));
                }

                _stack[_stackPtr].InitializeFrom(node);
            }

            public void PushChildren(SyntaxNode node, Func<SyntaxNode, bool> descendIntoChildren)
            {
                if (descendIntoChildren == null || descendIntoChildren(node))
                {
                    PushChildren(node);
                }
            }

            public void Dispose()
            {
                // Return only reasonably-sized stacks to the pool.
                if (_stack?.Length < 256)
                {
                    Array.Clear(_stack, 0, _stack.Length);
                    s_stackPool.Free(_stack);
                }
            }
        }

        private struct TriviaListEnumeratorStack : IDisposable
        {
            private static readonly ObjectPool<SyntaxTriviaList.Enumerator[]> s_stackPool = new ObjectPool<SyntaxTriviaList.Enumerator[]>(() => new SyntaxTriviaList.Enumerator[16]);

            private SyntaxTriviaList.Enumerator[] _stack;
            private int _stackPtr;

            public bool TryGetNext(out SyntaxTrivia value)
            {
                value = default(SyntaxTrivia);

                if (_stack[_stackPtr].MoveNext())
                {
                    value = _stack[_stackPtr].Current;
                    return true;
                }

                _stackPtr--;
                return false;
            }

            public void PushLeadingTrivia(ref SyntaxToken token)
            {
                Grow();
                _stack[_stackPtr].InitializeFromLeadingTrivia(token);
            }

            public void PushTrailingTrivia(ref SyntaxToken token)
            {
                Grow();
                _stack[_stackPtr].InitializeFromTrailingTrivia(token);
            }

            private void Grow()
            {
                if (_stack == null)
                {
                    _stack = s_stackPool.Allocate();
                    _stackPtr = -1;
                }

                if (++_stackPtr >= _stack.Length)
                {
                    // Geometric growth
                    Array.Resize(ref _stack, checked(_stackPtr * 2));
                }
            }

            public void Dispose()
            {
                // Return only reasonably-sized stacks to the pool.
                if (_stack?.Length < 256)
                {
                    Array.Clear(_stack, 0, _stack.Length);
                    s_stackPool.Free(_stack);
                }
            }
        }

        private struct TwoEnumeratorListStack : IDisposable
        {
            public enum Which : byte
            {
                Node,
                Trivia
            }

            private ChildSyntaxListEnumeratorStack _nodeStack;
            private TriviaListEnumeratorStack _triviaStack;
            private readonly ArrayBuilder<Which> _discriminatorStack;

            public TwoEnumeratorListStack(SyntaxNode startingNode, Func<SyntaxNode, bool> descendIntoChildren)
            {
                _nodeStack = new ChildSyntaxListEnumeratorStack(startingNode, descendIntoChildren);
                _triviaStack = new TriviaListEnumeratorStack();
                if (_nodeStack.IsNotEmpty)
                {
                    _discriminatorStack = ArrayBuilder<Which>.GetInstance();
                    _discriminatorStack.Push(Which.Node);
                }
                else
                {
                    _discriminatorStack = null;
                }
            }

            public bool IsNotEmpty { get { return _discriminatorStack?.Count > 0; } }

            public Which PeekNext()
            {
                return _discriminatorStack.Peek();
            }

            public bool TryGetNextInSpan(ref TextSpan span, out RedNode value)
            {
                if (_nodeStack.TryGetNextInSpan(ref span, out value))
                {
                    return true;
                }

                _discriminatorStack.Pop();
                return false;
            }

            public bool TryGetNext(out SyntaxTrivia value)
            {
                if (_triviaStack.TryGetNext(out value))
                {
                    return true;
                }

                _discriminatorStack.Pop();
                return false;
            }

            public void PushChildren(SyntaxNode node, Func<SyntaxNode, bool> descendIntoChildren)
            {
                if (descendIntoChildren == null || descendIntoChildren(node))
                {
                    _nodeStack.PushChildren(node);
                    _discriminatorStack.Push(Which.Node);
                }
            }

            public void PushLeadingTrivia(ref SyntaxToken token)
            {
                _triviaStack.PushLeadingTrivia(ref token);
                _discriminatorStack.Push(Which.Trivia);
            }

            public void PushTrailingTrivia(ref SyntaxToken token)
            {
                _triviaStack.PushTrailingTrivia(ref token);
                _discriminatorStack.Push(Which.Trivia);
            }

            public void Dispose()
            {
                _nodeStack.Dispose();
                _triviaStack.Dispose();
                _discriminatorStack?.Free();
            }
        }

        private struct ThreeEnumeratorListStack : IDisposable
        {
            public enum Which : byte
            {
                Node,
                Trivia,
                Token
            }

            private ChildSyntaxListEnumeratorStack _nodeStack;
            private TriviaListEnumeratorStack _triviaStack;
            private readonly ArrayBuilder<RedNode> _tokenStack;
            private readonly ArrayBuilder<Which> _discriminatorStack;

            public ThreeEnumeratorListStack(SyntaxNode startingNode, Func<SyntaxNode, bool> descendIntoChildren)
            {
                _nodeStack = new ChildSyntaxListEnumeratorStack(startingNode, descendIntoChildren);
                _triviaStack = new TriviaListEnumeratorStack();
                if (_nodeStack.IsNotEmpty)
                {
                    _tokenStack = ArrayBuilder<RedNode>.GetInstance();
                    _discriminatorStack = ArrayBuilder<Which>.GetInstance();
                    _discriminatorStack.Push(Which.Node);
                }
                else
                {
                    _tokenStack = null;
                    _discriminatorStack = null;
                }
            }

            public bool IsNotEmpty { get { return _discriminatorStack?.Count > 0; } }

            public Which PeekNext()
            {
                return _discriminatorStack.Peek();
            }

            public bool TryGetNextInSpan(ref TextSpan span, out RedNode value)
            {
                if (_nodeStack.TryGetNextInSpan(ref span, out value))
                {
                    return true;
                }

                _discriminatorStack.Pop();
                return false;
            }

            public bool TryGetNext(out SyntaxTrivia value)
            {
                if (_triviaStack.TryGetNext(out value))
                {
                    return true;
                }

                _discriminatorStack.Pop();
                return false;
            }

            public RedNode PopToken()
            {
                _discriminatorStack.Pop();
                return _tokenStack.Pop();
            }

            public void PushChildren(SyntaxNode node, Func<SyntaxNode, bool> descendIntoChildren)
            {
                if (descendIntoChildren == null || descendIntoChildren(node))
                {
                    _nodeStack.PushChildren(node);
                    _discriminatorStack.Push(Which.Node);
                }
            }

            public void PushLeadingTrivia(ref SyntaxToken token)
            {
                _triviaStack.PushLeadingTrivia(ref token);
                _discriminatorStack.Push(Which.Trivia);
            }

            public void PushTrailingTrivia(ref SyntaxToken token)
            {
                _triviaStack.PushTrailingTrivia(ref token);
                _discriminatorStack.Push(Which.Trivia);
            }

            public void PushToken(ref RedNode value)
            {
                _tokenStack.Push(value);
                _discriminatorStack.Push(Which.Token);
            }

            public void Dispose()
            {
                _nodeStack.Dispose();
                _triviaStack.Dispose();
                _tokenStack?.Free();
                _discriminatorStack?.Free();
            }
        }

        private IEnumerable<SyntaxNode> DescendantNodesOnly(TextSpan span, Func<SyntaxNode, bool> descendIntoChildren, bool includeSelf)
        {
            if (includeSelf && IsInSpan(ref span, this.FullSpan))
            {
                yield return this;
            }

            using (var stack = new ChildSyntaxListEnumeratorStack(this, descendIntoChildren))
            {
                while (stack.IsNotEmpty)
                {
                    SyntaxNode nodeValue = stack.TryGetNextAsNodeInSpan(ref span);
                    if (nodeValue != null)
                    {
                        // PERF: Push before yield return so that "nodeValue" is 'dead' after the yield
                        // and therefore doesn't need to be stored in the iterator state machine. This
                        // saves a field.
                        stack.PushChildren(nodeValue, descendIntoChildren);

                        yield return nodeValue;
                    }
                }
            }
        }

        private IEnumerable<RedNode> DescendantNodesAndTokensOnly(TextSpan span, Func<SyntaxNode, bool> descendIntoChildren, bool includeSelf)
        {
            if (includeSelf && IsInSpan(ref span, this.FullSpan))
            {
                yield return this;
            }

            using (var stack = new ChildSyntaxListEnumeratorStack(this, descendIntoChildren))
            {
                while (stack.IsNotEmpty)
                {
                    RedNode value;
                    if (stack.TryGetNextInSpan(ref span, out value))
                    {
                        // PERF: Push before yield return so that "value" is 'dead' after the yield
                        // and therefore doesn't need to be stored in the iterator state machine. This
                        // saves a field.
                        var nodeValue = value as SyntaxNode;
                        if (nodeValue != null)
                        {
                            stack.PushChildren(nodeValue, descendIntoChildren);
                        }

                        yield return value;
                    }
                }
            }
        }

        private IEnumerable<RedNode> DescendantNodesAndTokensIntoTrivia(TextSpan span, Func<SyntaxNode, bool> descendIntoChildren, bool includeSelf)
        {
            if (includeSelf && IsInSpan(ref span, this.FullSpan))
            {
                yield return this;
            }

            using (var stack = new ThreeEnumeratorListStack(this, descendIntoChildren))
            {
                while (stack.IsNotEmpty)
                {
                    switch (stack.PeekNext())
                    {
                        case ThreeEnumeratorListStack.Which.Node:
                            RedNode value;
                            if (stack.TryGetNextInSpan(ref span, out value))
                            {
                                // PERF: The following code has an unusual structure (note the 'break' out of
                                // the case statement from inside an if body) in order to convince the compiler
                                // that it can save a field in the iterator machinery.
                                if (value.IsNode)
                                {
                                    // parent nodes come before children (prefix document order)
                                    stack.PushChildren((SyntaxNode)value, descendIntoChildren);
                                }
                                else if (value.IsToken)
                                {
                                    var token = (SyntaxToken)value;

                                    // only look through trivia if this node has structured trivia
                                    if (token.HasStructuredTrivia)
                                    {
                                        // trailing trivia comes last
                                        if (token.HasTrailingTrivia)
                                        {
                                            stack.PushTrailingTrivia(ref token);
                                        }

                                        // tokens come between leading and trailing trivia
                                        stack.PushToken(ref value);

                                        // leading trivia comes first
                                        if (token.HasLeadingTrivia)
                                        {
                                            stack.PushLeadingTrivia(ref token);
                                        }

                                        // Exit the case block without yielding (see PERF note above)
                                        break;
                                    }
                                    // no structure trivia, so just yield this token now
                                }

                                // PERF: Yield here (rather than inside the if bodies above) so that it's
                                // obvious to the compiler that 'value' is not used beyond this point and,
                                // therefore, doesn't need to be kept in a field.
                                yield return value;
                            }

                            break;

                        case ThreeEnumeratorListStack.Which.Trivia:
                            // yield structure nodes and enumerate their children
                            SyntaxTrivia trivia;
                            if (stack.TryGetNext(out trivia))
                            {
                                if (trivia.HasStructure && IsInSpan(ref span, trivia.FullSpan))
                                {
                                    var structureNode = trivia.GetStructure();

                                    // parent nodes come before children (prefix document order)

                                    // PERF: Push before yield return so that "structureNode" is 'dead' after the yield
                                    // and therefore doesn't need to be stored in the iterator state machine. This
                                    // saves a field.
                                    stack.PushChildren(structureNode, descendIntoChildren);

                                    yield return structureNode;
                                }
                            }
                            break;

                        case ThreeEnumeratorListStack.Which.Token:
                            yield return stack.PopToken();
                            break;
                    }
                }
            }
        }

        private IEnumerable<SyntaxTrivia> DescendantTriviaOnly(TextSpan span, Func<SyntaxNode, bool> descendIntoChildren)
        {
            using (var stack = new ChildSyntaxListEnumeratorStack(this, descendIntoChildren))
            {
                while (stack.IsNotEmpty)
                {
                    RedNode value;
                    if (stack.TryGetNextInSpan(ref span, out value))
                    {
                        if (value.IsNode)
                        {
                            var nodeValue = (SyntaxNode)value;

                            stack.PushChildren(nodeValue, descendIntoChildren);
                        }
                        else if (value.IsToken)
                        {
                            var token = (SyntaxToken)value;

                            foreach (var trivia in token.LeadingTrivia)
                            {
                                if (IsInSpan(ref span, trivia.FullSpan))
                                {
                                    yield return trivia;
                                }
                            }

                            foreach (var trivia in token.TrailingTrivia)
                            {
                                if (IsInSpan(ref span, trivia.FullSpan))
                                {
                                    yield return trivia;
                                }
                            }
                        }
                    }
                }
            }
        }

        private IEnumerable<SyntaxTrivia> DescendantTriviaIntoTrivia(TextSpan span, Func<SyntaxNode, bool> descendIntoChildren)
        {
            using (var stack = new TwoEnumeratorListStack(this, descendIntoChildren))
            {
                while (stack.IsNotEmpty)
                {
                    switch (stack.PeekNext())
                    {
                        case TwoEnumeratorListStack.Which.Node:
                            RedNode value;
                            if (stack.TryGetNextInSpan(ref span, out value))
                            {
                                if (value.IsNode)
                                {
                                    var nodeValue = (SyntaxNode)value;
                                    stack.PushChildren(nodeValue, descendIntoChildren);
                                }
                                else if (value.IsToken)
                                {
                                    var token = (SyntaxToken)value;

                                    if (token.HasTrailingTrivia)
                                    {
                                        stack.PushTrailingTrivia(ref token);
                                    }

                                    if (token.HasLeadingTrivia)
                                    {
                                        stack.PushLeadingTrivia(ref token);
                                    }
                                }
                            }

                            break;

                        case TwoEnumeratorListStack.Which.Trivia:
                            // yield structure nodes and enumerate their children
                            SyntaxTrivia trivia;
                            if (stack.TryGetNext(out trivia))
                            {
                                // PERF: Push before yield return so that "trivia" is 'dead' after the yield
                                // and therefore doesn't need to be stored in the iterator state machine. This
                                // saves a field.
                                if (trivia.HasStructure)
                                {
                                    var structureNode = trivia.GetStructure();
                                    stack.PushChildren(structureNode, descendIntoChildren);
                                }

                                if (IsInSpan(ref span, trivia.FullSpan))
                                {
                                    yield return trivia;
                                }
                            }

                            break;
                    }
                }
            }
        }

        #endregion
    }
}
