using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Syntax
{
    public class DetailedSyntaxVisitor : SyntaxVisitor
    {
        private readonly bool _visitIntoStructuredToken;
        private readonly bool _visitIntoStructuredTrivia;

        public DetailedSyntaxVisitor(bool visitIntoStructuredToken, bool visitIntoStructuredTrivia)
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

        public override void Visit(SyntaxNode node)
        {
            if (node != null)
            {
                _recursionDepth++;
                //StackGuard.EnsureSufficientExecutionStack(_recursionDepth);

                node.Accept(this);

                _recursionDepth--;
            }
        }

        public virtual void VisitToken(SyntaxToken token)
        {
            if (token == null) return;
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

            int index = 0;
            if (leadingTrivia != null)
            {
                // PERF: Expand token.LeadingTrivia when node is not null.
                this.VisitList(new SyntaxTriviaList(leadingTrivia, token, 0, 0));
                index = leadingTrivia.IsList ? leadingTrivia.SlotCount : 1;
            }

            if (this.VisitIntoStructuredToken && token.HasStructure)
            {
                var structure = token.GetStructure();
                this.Visit(structure);
            }

            if (trailingTrivia != null)
            {
                this.VisitList(new SyntaxTriviaList(trailingTrivia, token, token.Position + node.FullWidth - trailingTrivia.FullWidth, index));
            }
        }

        public virtual void VisitTrivia(SyntaxTrivia trivia)
        {
            if (trivia == null) return;
            if (this.VisitIntoStructuredTrivia && trivia.HasStructure)
            {
                var structure = trivia.GetStructure();
                this.Visit(structure);
            }
        }

        public virtual void VisitList<TNode>(SyntaxNodeList<TNode> list) where TNode : SyntaxNode
        {
            if (list == null) return;
            for (int i = 0, n = list.Count; i < n; i++)
            {
                var item = list[i];
                this.VisitListElement(item);
            }
        }

        public virtual void VisitListElement<TNode>(TNode node) where TNode : SyntaxNode
        {
            if (node == null) return;
            this.Visit(node);
        }

        public virtual void VisitList<TNode>(SeparatedSyntaxNodeList<TNode> list) where TNode : SyntaxNode
        {
            if (list == null) return;
            var count = list.Count;
            var sepCount = list.SeparatorCount;

            int i = 0;
            for (; i < sepCount; i++)
            {
                var node = list[i];
                this.VisitListElement(node);

                var separator = list.GetSeparator(i);
                this.VisitListSeparator(separator);
            }

            if (i < count)
            {
                var node = list[i];
                this.VisitListElement(node);
            }
        }

        public virtual void VisitListSeparator(SyntaxToken separator)
        {
            if (separator == null) return;
            this.VisitToken(separator);
        }

        public virtual void VisitList(SyntaxTokenList list)
        {
            if (list == null) return;
            foreach (var item in list)
            {
                this.VisitToken(item);
            }
        }

        public virtual void VisitList(SyntaxTriviaList list)
        {
            if (list == null) return;
            foreach (var item in list)
            {
                this.VisitListElement(item);
            }
        }

        public virtual void VisitListElement(SyntaxTrivia element)
        {
            if (element == null) return;
            this.VisitTrivia(element);
        }
    }

    public class DetailedSyntaxVisitor<TResult> : SyntaxVisitor<TResult>
    {
        private readonly bool _visitIntoStructuredToken;
        private readonly bool _visitIntoStructuredTrivia;

        public DetailedSyntaxVisitor(bool visitIntoStructuredToken, bool visitIntoStructuredTrivia)
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

        public override TResult Visit(SyntaxNode node)
        {
            TResult result = default(TResult);
            if (node != null)
            {
                _recursionDepth++;
                //StackGuard.EnsureSufficientExecutionStack(_recursionDepth);

                result = node.Accept(this);

                _recursionDepth--;
            }
            return result;
        }

        public virtual TResult VisitToken(SyntaxToken token)
        {
            if (token == null) return default(TResult);
            // PERF: This is a hot method, so it has been written to minimize the following:
            // 1. Virtual method calls
            // 2. Copying of structs
            // 3. Repeated null checks

            TResult result = default(TResult);

            // PERF: Avoid testing node for null more than once
            var node = token.GreenToken;

            // PERF: Make one virtual method call each to get the leading and trailing trivia
            var leadingTrivia = node.GetLeadingTrivia();
            var trailingTrivia = node.GetTrailingTrivia();

            // Trivia is either null or a non-empty list (there's no such thing as an empty green list)
            Debug.Assert(leadingTrivia == null || !leadingTrivia.IsList || leadingTrivia.SlotCount > 0);
            Debug.Assert(trailingTrivia == null || !trailingTrivia.IsList || trailingTrivia.SlotCount > 0);

            int index = 0;
            if (leadingTrivia != null)
            {
                // PERF: Expand token.LeadingTrivia when node is not null.
                this.VisitList(new SyntaxTriviaList(leadingTrivia, token, 0, 0));
                index = leadingTrivia.IsList ? leadingTrivia.SlotCount : 1;
            }

            if (this.VisitIntoStructuredToken && token.HasStructure)
            {
                var structure = token.GetStructure();
                result = this.Visit(structure);
            }

            if (trailingTrivia != null)
            {
                this.VisitList(new SyntaxTriviaList(trailingTrivia, token, token.Position + node.FullWidth - trailingTrivia.FullWidth, index));
            }
            return result;
        }

        public virtual TResult VisitTrivia(SyntaxTrivia trivia)
        {
            if (trivia == null) return default(TResult);
            if (this.VisitIntoStructuredTrivia && trivia.HasStructure)
            {
                var structure = trivia.GetStructure();
                return this.Visit(structure);
            }
            return default(TResult);
        }

        public virtual TResult VisitList<TNode>(SyntaxNodeList<TNode> list) where TNode : SyntaxNode
        {
            if (list == null) return default(TResult);
            for (int i = 0, n = list.Count; i < n; i++)
            {
                var item = list[i];
                this.VisitListElement(item);
            }
            return default(TResult);
        }

        public virtual TResult VisitListElement<TNode>(TNode node) where TNode : SyntaxNode
        {
            if (node == null) return default(TResult);
            return this.Visit(node);
        }

        public virtual TResult VisitList<TNode>(SeparatedSyntaxNodeList<TNode> list) where TNode : SyntaxNode
        {
            if (list == null) return default(TResult);
            var count = list.Count;
            var sepCount = list.SeparatorCount;

            int i = 0;
            for (; i < sepCount; i++)
            {
                var node = list[i];
                this.VisitListElement(node);

                var separator = list.GetSeparator(i);
                this.VisitListSeparator(separator);
            }

            if (i < count)
            {
                var node = list[i];
                this.VisitListElement(node);
            }
            return default(TResult);
        }

        public virtual TResult VisitListSeparator(SyntaxToken separator)
        {
            if (separator == null) return default(TResult);
            return this.VisitToken(separator);
        }

        public virtual TResult VisitList(SyntaxTokenList list)
        {
            if (list == null) return default(TResult);
            foreach (var item in list)
            {
                this.VisitToken(item);
            }
            return default(TResult);
        }

        public virtual TResult VisitList(SyntaxTriviaList list)
        {
            if (list == null) return default(TResult);
            foreach (var item in list)
            {
                this.VisitListElement(item);
            }
            return default(TResult);
        }

        public virtual TResult VisitListElement(SyntaxTrivia element)
        {
            if (element == null) return default(TResult);
            return this.VisitTrivia(element);
        }
    }
}
