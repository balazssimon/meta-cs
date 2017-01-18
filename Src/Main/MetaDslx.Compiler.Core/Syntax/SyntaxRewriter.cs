using MetaDslx.Compiler.Syntax.InternalSyntax;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Syntax
{
    /// <summary>
    /// Represents a <see cref="CSharpSyntaxVisitor{TResult}"/> which descends an entire <see cref="AbstractSyntaxNode"/> graph and
    /// may replace or remove visited SyntaxNodes in depth-first order.
    /// </summary>
    public abstract partial class SyntaxRewriter : SyntaxVisitor<SyntaxNode>
    {
        private readonly bool _visitIntoStructuredToken;
        private readonly bool _visitIntoStructuredTrivia;

        public SyntaxRewriter(bool visitIntoStructuredToken = false, bool visitIntoStructuredTrivia = false)
        {
            _visitIntoStructuredToken = visitIntoStructuredToken;
            _visitIntoStructuredTrivia = visitIntoStructuredTrivia;
        }

        public virtual bool VisitIntoStructuredToken
        {
            get { return _visitIntoStructuredToken; }
        }

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
                //StackGuard.EnsureSufficientExecutionStack(_recursionDepth);

                var result = node.Accept(this);

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
            var node = token.GreenToken;

            // PERF: Make one virtual method call each to get the leading and trailing trivia
            var leadingTrivia = node.GetLeadingTrivia();
            var trailingTrivia = node.GetTrailingTrivia();

            // Trivia is either null or a non-empty list (there's no such thing as an empty green list)
            Debug.Assert(leadingTrivia == null || !leadingTrivia.IsList || leadingTrivia.SlotCount > 0);
            Debug.Assert(trailingTrivia == null || !trailingTrivia.IsList || trailingTrivia.SlotCount > 0);

            SyntaxToken originalToken = token;
            SyntaxTriviaList leading = null;
            SyntaxTriviaList trailing = null;
            int index = 0;
            if (leadingTrivia != null)
            {
                // PERF: Expand token.LeadingTrivia when node is not null.
                leading = this.VisitList(new SyntaxTriviaList(leadingTrivia, originalToken, 0, 0));
                index = leadingTrivia.IsList ? leadingTrivia.SlotCount : 1;
            }

            if (this.VisitIntoStructuredToken && token.HasStructure)
            {
                var structure = originalToken.GetStructure();
                var newStructure = this.Visit(structure);
                if (newStructure != structure)
                {
                    if (newStructure != null)
                    {
                        token = token.Language.SyntaxFactory.Token(newStructure);
                    }
                    else
                    {
                        token = token.Language.SyntaxFactory.DefaultToken;
                    }
                }
            }

            if (trailingTrivia != null)
            {
                trailing = this.VisitList(new SyntaxTriviaList(trailingTrivia, originalToken, originalToken.Position + node.FullWidth - trailingTrivia.FullWidth, index));
            }

            if (leadingTrivia != null && leading.Green != leadingTrivia)
            {
                token = token.WithLeadingTrivia(leading);
            }
            if (trailingTrivia != null && trailing.Green != trailingTrivia)
            {
                token = token.WithTrailingTrivia(trailing);
            }
            return token;
        }

        public virtual SyntaxTrivia VisitTrivia(SyntaxTrivia trivia)
        {
            if (this.VisitIntoStructuredTrivia && trivia.HasStructure)
            {
                var structure = trivia.GetStructure();
                var newStructure = this.Visit(structure);
                if (newStructure != structure)
                {
                    if (newStructure != null)
                    {
                        return trivia.Language.SyntaxFactory.Trivia(newStructure);
                    }
                    else
                    {
                        return trivia.Language.SyntaxFactory.DefaultTrivia;
                    }
                }
            }

            return trivia;
        }

        public virtual SyntaxNodeList<TNode> VisitList<TNode>(SyntaxNodeList<TNode> list) where TNode : SyntaxNode
        {
            NodeListBuilder<TNode> alternate = null;
            for (int i = 0, n = list.Count; i < n; i++)
            {
                var item = list[i];
                var visited = this.VisitListElement(item);
                if (item != visited && alternate == null)
                {
                    alternate = new NodeListBuilder<TNode>(n);
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
            return (TNode)this.Visit(node);
        }

        public virtual SeparatedSyntaxNodeList<TNode> VisitList<TNode>(SeparatedSyntaxNodeList<TNode> list) where TNode : SyntaxNode
        {
            var count = list.Count;
            var sepCount = list.SeparatorCount;

            SeparatedNodeListBuilder<TNode> alternate = null;

            int i = 0;
            for (; i < sepCount; i++)
            {
                var node = list[i];
                var visitedNode = this.VisitListElement(node);

                var separator = list.GetSeparator(i);
                var visitedSeparator = this.VisitListSeparator(separator);

                if (alternate == null)
                {
                    if (node != visitedNode || separator != visitedSeparator)
                    {
                        alternate = new SeparatedNodeListBuilder<TNode>(count);
                        alternate.AddRange(list, i);
                    }
                }

                if (alternate != null)
                {
                    if (visitedNode != null)
                    {
                        alternate.Add(visitedNode);

                        if (visitedSeparator.RawKind == 0)
                        {
                            throw new InvalidOperationException("Separator is expected.");
                        }
                        alternate.AddSeparator(visitedSeparator);
                    }
                    else
                    {
                        if (visitedNode == null)
                        {
                            throw new InvalidOperationException("Element is expected.");
                        }
                    }
                }
            }

            if (i < count)
            {
                var node = list[i];
                var visitedNode = this.VisitListElement(node);

                if (alternate == null)
                {
                    if (node != visitedNode)
                    {
                        alternate = new SeparatedNodeListBuilder<TNode>(count);
                        alternate.AddRange(list, i);
                    }
                }

                if (alternate != null && visitedNode != null)
                {
                    alternate.Add(visitedNode);
                }
            }

            if (alternate != null)
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
            TokenListBuilder alternate = null;
            var count = list.Count;
            var index = -1;

            foreach (var item in list)
            {
                index++;
                var visited = this.VisitToken(item);
                if (item != visited && alternate == null)
                {
                    alternate = new TokenListBuilder(count);
                    alternate.AddRange(list, 0, index);
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

        public virtual SyntaxTriviaList VisitList(SyntaxTriviaList list)
        {
            var count = list.Count;
            if (count != 0)
            {
                TriviaListBuilder alternate = null;
                var index = -1;

                foreach (var item in list)
                {
                    index++;
                    var visited = this.VisitListElement(item);
                    if (visited != item && alternate == null)
                    {
                        alternate = new TriviaListBuilder(count);
                        alternate.AddRange(list, 0, index);
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
            }

            return list;
        }

        public virtual SyntaxTrivia VisitListElement(SyntaxTrivia element)
        {
            return this.VisitTrivia(element);
        }
    }
}
