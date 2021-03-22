// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Diagnostics;

namespace MetaDslx.CodeAnalysis.Syntax.InternalSyntax
{
    using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;

    internal partial class InternalSyntaxRewriter : InternalSyntaxVisitor<InternalSyntaxNode>
    {
        protected readonly bool VisitIntoStructuredTrivia;

        public InternalSyntaxRewriter(bool visitIntoStructuredTrivia = false)
        {
            this.VisitIntoStructuredTrivia = visitIntoStructuredTrivia;
        }

        public override InternalSyntaxNode VisitToken(InternalSyntaxToken token)
        {
            var leading = this.VisitList(token.LeadingTrivia);
            var trailing = this.VisitList(token.TrailingTrivia);

            if (leading != token.LeadingTrivia || trailing != token.TrailingTrivia)
            {
                if (leading != token.LeadingTrivia)
                {
                    token = token.TokenWithLeadingTrivia(leading.Node);
                }

                if (trailing != token.TrailingTrivia)
                {
                    token = token.TokenWithTrailingTrivia(trailing.Node);
                }
            }

            return token;
        }

        public SyntaxList<TNode> VisitList<TNode>(SyntaxList<TNode> list) where TNode : InternalSyntaxNode
        {
            SyntaxListBuilder alternate = null;
            for (int i = 0, n = list.Count; i < n; i++)
            {
                var item = list[i];
                var visited = this.Visit(item);
                if (item != visited && alternate == null)
                {
                    alternate = new SyntaxListBuilder(n);
                    alternate.AddRange(list, 0, i);
                }

                if (alternate != null)
                {
                    Debug.Assert(visited != null && visited.GetKind() != SyntaxKind.None, "Cannot remove node using Syntax.InternalSyntax.SyntaxRewriter.");
                    alternate.Add(visited);
                }
            }

            if (alternate != null)
            {
                return alternate.ToList();
            }

            return list;
        }

        public SeparatedSyntaxList<TNode> VisitList<TNode>(SeparatedSyntaxList<TNode> list) where TNode : InternalSyntaxNode
        {
            // A separated list is filled with C# nodes and C# tokens.  Both of which
            // derive from InternalSyntax.CSharpSyntaxNode.  So this cast is appropriately
            // typesafe.
            var withSeps = (SyntaxList<InternalSyntaxNode>)list.GetWithSeparators();
            var result = this.VisitList(withSeps);
            if (result != withSeps)
            {
                return result.AsSeparatedList<TNode>();
            }

            return list;
        }
    }
}
