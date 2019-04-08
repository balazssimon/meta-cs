// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MetaDslx.Compiler.Text;
using MetaDslx.Compiler.Utilities;

namespace MetaDslx.Compiler
{
    /// <summary>
    /// Walks the syntax tree, allowing subclasses to operate on all nodes, token and trivia.  The
    /// walker will perform a depth first walk of the tree.
    /// </summary>
    public abstract class SyntaxWalker<TNode> : SyntaxVisitor<TNode>
        where TNode : LanguageSyntaxNode
    {
        /// <summary>
        /// Syntax the <see cref="SyntaxWalker"/> should descend into.
        /// </summary>
        protected SyntaxWalkerDepth Depth { get; }

        /// <summary>
        /// Creates a new walker instance.
        /// </summary>
        /// <param name="depth">Syntax the <see cref="SyntaxWalker"/> should descend into.</param>
        protected SyntaxWalker(SyntaxWalkerDepth depth = SyntaxWalkerDepth.Node)
        {
            this.Depth = depth;
        }

        private int _recursionDepth;

        /// <summary>
        /// Called when the walker visits a node.  This method may be overridden if subclasses want
        /// to handle the node.  Overrides should call back into this base method if they want the
        /// children of this node to be visited.
        /// </summary>
        /// <param name="node">The current node that the walker is visiting.</param>
        public override void Visit(TNode node)
        {
            if (node != null)
            {
                _recursionDepth++;
                StackGuard.EnsureSufficientExecutionStack(_recursionDepth);

                node.Accept(this);

                _recursionDepth--;
            }
        }

        /// <summary>
        /// Called when the walker visits a token.  This method may be overridden if subclasses want
        /// to handle the token.  Overrides should call back into this base method if they want the 
        /// trivia of this token to be visited.
        /// </summary>
        /// <param name="token">The current token that the walker is visiting.</param>
        protected virtual void VisitToken(SyntaxToken token)
        {
            if (this.Depth >= SyntaxWalkerDepth.Trivia)
            {
                this.VisitLeadingTrivia(token);
                if (this.Depth >= SyntaxWalkerDepth.StructuredTokenOrTrivia && token.HasStructure)
                {
                    this.Visit((TNode)token.GetStructure());
                }
                this.VisitTrailingTrivia(token);
            }
        }

        private void VisitLeadingTrivia(in SyntaxToken token)
        {
            if (token.HasLeadingTrivia)
            {
                foreach (var trivia in token.LeadingTrivia)
                {
                    VisitTrivia(trivia);
                }
            }
        }

        private void VisitTrailingTrivia(in SyntaxToken token)
        {
            if (token.HasTrailingTrivia)
            {
                foreach (var trivia in token.TrailingTrivia)
                {
                    VisitTrivia(trivia);
                }
            }
        }
        
        /// <summary>
        /// Called when the walker visits a trivia syntax.  This method may be overridden if
        /// subclasses want to handle the token.  Overrides should call back into this base method if
        /// they want the children of this trivia syntax to be visited.
        /// </summary>
        /// <param name="trivia">The current trivia syntax that the walker is visiting.</param>
        protected virtual void VisitTrivia(SyntaxTrivia trivia)
        {
            if (this.Depth >= SyntaxWalkerDepth.StructuredTokenOrTrivia && trivia.HasStructure)
            {
                this.Visit((TNode)trivia.GetStructure());
            }
        }
    }
}
