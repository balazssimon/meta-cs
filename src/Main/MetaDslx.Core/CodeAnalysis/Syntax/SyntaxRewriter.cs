﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using MetaDslx.CodeAnalysis.Syntax;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Syntax;

namespace MetaDslx.CodeAnalysis
{
    /// <summary>
    /// Represents a <see cref="SyntaxVisitor{TResult}"/> which descends an entire <see cref="LanguageSyntaxNode"/> graph and
    /// may replace or remove visited SyntaxNodes in depth-first order.
    /// </summary>
    public abstract partial class SyntaxRewriter : SyntaxVisitor<SyntaxNode>
    {
        private readonly Language _language;
        private readonly bool _visitIntoStructuredTrivia;

        public SyntaxRewriter(Language language, bool visitIntoStructuredTrivia = false)
        {
            Debug.Assert(language != null);
            _language = language;
            _visitIntoStructuredTrivia = visitIntoStructuredTrivia;
        }

        public Language Language => _language;

        protected SyntaxFactory SyntaxFactory => _language.SyntaxFactory;

        public virtual bool VisitIntoStructuredTrivia
        {
            get { return _visitIntoStructuredTrivia; }
        }

        private int _recursionDepth;

        public override SyntaxNode Visit(SyntaxNode node)
        {
            if (node != null)
            {
                _recursionDepth++;
                StackGuard.EnsureSufficientExecutionStack(_recursionDepth);

                var result = ((LanguageSyntaxNode)node).Accept(this);

                _recursionDepth--;
                return result;
            }
            else
            {
                return null;
            }
        }

        public virtual SyntaxToken VisitToken(SyntaxToken token)
        {
            // PERF: This is a hot method, so it has been written to minimize the following:
            // 1. Virtual method calls
            // 2. Copying of structs
            // 3. Repeated null checks

            // PERF: Avoid testing node for null more than once
            var node = token.Node;
            if (node == null)
            {
                return token;
            }

            // PERF: Make one virtual method call each to get the leading and trailing trivia
            var leadingTrivia = node.GetLeadingTriviaCore();
            var trailingTrivia = node.GetTrailingTriviaCore();

            // Trivia is either null or a non-empty list (there's no such thing as an empty green list)
            Debug.Assert(leadingTrivia == null || !leadingTrivia.IsList || leadingTrivia.SlotCount > 0);
            Debug.Assert(trailingTrivia == null || !trailingTrivia.IsList || trailingTrivia.SlotCount > 0);

            if (leadingTrivia != null)
            {
                // PERF: Expand token.LeadingTrivia when node is not null.
                var leading = this.VisitList(new SyntaxTriviaList(token, leadingTrivia));

                if (trailingTrivia != null)
                {
                    // Both leading and trailing trivia

                    // PERF: Expand token.TrailingTrivia when node is not null and leadingTrivia is not null.
                    // Also avoid node.Width because it makes a virtual call to GetText. Instead use node.FullWidth - trailingTrivia.FullWidth.
                    var index = leadingTrivia.IsList ? leadingTrivia.SlotCount : 1;
                    var trailing = this.VisitList(new SyntaxTriviaList(token, trailingTrivia, token.Position + node.FullWidth - trailingTrivia.FullWidth, index));

                    if (leading.Node != leadingTrivia)
                    {
                        token = token.WithLeadingTrivia(leading);
                    }

                    return trailing.Node != trailingTrivia ? token.WithTrailingTrivia(trailing) : token;
                }
                else
                {
                    // Leading trivia only
                    return leading.Node != leadingTrivia ? token.WithLeadingTrivia(leading) : token;
                }
            }
            else if (trailingTrivia != null)
            {
                // Trailing trivia only
                // PERF: Expand token.TrailingTrivia when node is not null and leading is null.
                // Also avoid node.Width because it makes a virtual call to GetText. Instead use node.FullWidth - trailingTrivia.FullWidth.
                var trailing = this.VisitList(new SyntaxTriviaList(token, trailingTrivia, token.Position + node.FullWidth - trailingTrivia.FullWidth, index: 0));
                return trailing.Node != trailingTrivia ? token.WithTrailingTrivia(trailing) : token;
            }
            else
            {
                // No trivia
                return token;
            }
        }

        public virtual SyntaxTrivia VisitTrivia(SyntaxTrivia trivia)
        {
            if (this.VisitIntoStructuredTrivia && trivia.HasStructure)
            {
                var structure = (LanguageSyntaxNode)trivia.GetStructure();
                var newStructure = (IStructuredTriviaSyntax)this.Visit(structure);
                if (newStructure != structure)
                {
                    if (newStructure != null)
                    {
                        return SyntaxFactory.Trivia((LanguageSyntaxNode)newStructure);
                    }
                    else
                    {
                        return default(SyntaxTrivia);
                    }
                }
            }

            return trivia;
        }

        public virtual SyntaxList<TNode> VisitList<TNode>(SyntaxList<TNode> list) where TNode : SyntaxNode
        {
            SyntaxListBuilder alternate = null;
            for (int i = 0, n = list.Count; i < n; i++)
            {
                var item = list[i];
                var visited = this.VisitListElement(item);
                if (item != visited && alternate == null)
                {
                    alternate = new SyntaxListBuilder(n);
                    alternate.AddRange(list, 0, i);
                }

                if (alternate != null && visited != null && visited.RawKind != SyntaxKind.None)
                {
                    alternate.Add(visited);
                }
            }

            if (alternate != null)
            {
                return alternate.ToList();
            }

            return list;
        }

        public virtual TNode VisitListElement<TNode>(TNode node) where TNode : SyntaxNode
        {
            return (TNode)(SyntaxNode)this.Visit(node);
        }

        public virtual SeparatedSyntaxList<TNode> VisitList<TNode>(SeparatedSyntaxList<TNode> list) where TNode : SyntaxNode
        {
            var count = list.Count;
            var sepCount = list.SeparatorCount;

            SeparatedSyntaxListBuilder<TNode> alternate = default(SeparatedSyntaxListBuilder<TNode>);

            int i = 0;
            for (; i < sepCount; i++)
            {
                var node = list[i];
                var visitedNode = this.VisitListElement(node);

                var separator = list.GetSeparator(i);
                var visitedSeparator = this.VisitListSeparator(separator);

                if (alternate.IsNull)
                {
                    if (node != visitedNode || separator != visitedSeparator)
                    {
                        alternate = new SeparatedSyntaxListBuilder<TNode>(count);
                        alternate.AddRange(list, i);
                    }
                }

                if (!alternate.IsNull)
                {
                    if (visitedNode != null)
                    {
                        alternate.Add(visitedNode);

                        if (visitedSeparator.RawKind == 0)
                        {
                            throw new InvalidOperationException(CodeAnalysisResources.SeparatorIsExpected);
                        }
                        alternate.AddSeparator(visitedSeparator);
                    }
                    else
                    {
                        if (visitedNode == null)
                        {
                            throw new InvalidOperationException(CodeAnalysisResources.ElementIsExpected);
                        }
                    }
                }
            }

            if (i < count)
            {
                var node = list[i];
                var visitedNode = this.VisitListElement(node);

                if (alternate.IsNull)
                {
                    if (node != visitedNode)
                    {
                        alternate = new SeparatedSyntaxListBuilder<TNode>(count);
                        alternate.AddRange(list, i);
                    }
                }

                if (!alternate.IsNull && visitedNode != null)
                {
                    alternate.Add(visitedNode);
                }
            }

            if (!alternate.IsNull)
            {
                return alternate.ToList();
            }

            return list;
        }

        public virtual SyntaxToken VisitListSeparator(SyntaxToken separator)
        {
            return this.VisitToken(separator);
        }

        public virtual SyntaxTokenList VisitList(SyntaxTokenList list)
        {
            SyntaxTokenListBuilder alternate = null;
            var count = list.Count;
            var index = -1;

            foreach (var item in list)
            {
                index++;
                var visited = this.VisitToken(item);
                if (item != visited && alternate == null)
                {
                    alternate = new SyntaxTokenListBuilder(count);
                    alternate.Add(list, 0, index);
                }

                if (alternate != null && visited.RawKind != SyntaxKind.None) //skip the null check since SyntaxToken is a value type
                {
                    alternate.Add(visited);
                }
            }

            if (alternate != null)
            {
                return alternate.ToList();
            }

            return list;
        }

        public virtual SyntaxTriviaList VisitList(SyntaxTriviaList list)
        {
            var count = list.Count;
            if (count != 0)
            {
                SyntaxTriviaListBuilder alternate = null;
                var index = -1;

                foreach (var item in list)
                {
                    index++;
                    var visited = this.VisitListElement(item);

                    //skip the null check since SyntaxTrivia is a value type
                    if (visited != item && alternate == null)
                    {
                        alternate = new SyntaxTriviaListBuilder(count);
                        alternate.Add(list, 0, index);
                    }

                    if (alternate != null && visited.RawKind != SyntaxKind.None)
                    {
                        alternate.Add(visited);
                    }
                }

                if (alternate != null)
                {
                    return alternate.ToList();
                }
            }

            return list;
        }

        public virtual SyntaxTrivia VisitListElement(SyntaxTrivia element)
        {
            return this.VisitTrivia(element);
        }
    }
}
