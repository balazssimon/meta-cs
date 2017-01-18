using MetaDslx.Compiler.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Syntax
{
    // TODO: Structured token and trivia
    public sealed class SyntaxNavigator
    {
        public static readonly SyntaxNavigator Instance = new SyntaxNavigator();

        //protected abstract Func<SyntaxTrivia, bool> GetStepIntoFunction(bool skipped, bool directives, bool docComments);

        private SyntaxNavigator()
        {
        }

        private static Func<SyntaxToken, bool> GetPredicateFunction(bool includeZeroWidth)
        {
            return includeZeroWidth ? SyntaxToken.Any : SyntaxToken.NonZeroWidth;
        }

        private static bool Matches(Func<SyntaxToken, bool> predicate, SyntaxToken token)
        {
            return predicate == null || ReferenceEquals(predicate, SyntaxToken.Any) || predicate(token);
        }

        internal SyntaxToken GetFirstToken(SyntaxNode current, bool includeZeroWidth)
        {
            return GetFirstToken(current, GetPredicateFunction(includeZeroWidth), null);
        }

        internal SyntaxToken GetLastToken(SyntaxNode current, bool includeZeroWidth)
        {
            return GetLastToken(current, GetPredicateFunction(includeZeroWidth), null);
        }

        internal SyntaxToken GetPreviousToken(SyntaxToken current, bool includeZeroWidth)
        {
            return GetPreviousToken(current, GetPredicateFunction(includeZeroWidth), null);
        }

        internal SyntaxToken GetNextToken(SyntaxToken current, bool includeZeroWidth)
        {
            return GetNextToken(current, GetPredicateFunction(includeZeroWidth), null);
        }

        internal SyntaxToken GetPreviousToken(SyntaxToken current, Func<SyntaxToken, bool> predicate, Func<SyntaxTrivia, bool> stepInto)
        {
            return GetPreviousToken(current, predicate, stepInto != null, stepInto);
        }

        internal SyntaxToken GetNextToken(SyntaxToken current, Func<SyntaxToken, bool> predicate, Func<SyntaxTrivia, bool> stepInto)
        {
            return GetNextToken(current, predicate, stepInto != null, stepInto);
        }

        private static readonly ObjectPool<Stack<ChildSyntaxList.Enumerator>> s_childEnumeratorStackPool
            = new ObjectPool<Stack<ChildSyntaxList.Enumerator>>(() => new Stack<ChildSyntaxList.Enumerator>(), 10);

        internal SyntaxToken GetFirstToken(SyntaxNode current, Func<SyntaxToken, bool> predicate, Func<SyntaxTrivia, bool> stepInto)
        {
            var stack = s_childEnumeratorStackPool.Allocate();
            try
            {
                stack.Push(current.ChildNodesAndTokens().GetEnumerator());

                while (stack.Count > 0)
                {
                    var en = stack.Pop();
                    if (en.MoveNext())
                    {
                        var child = en.Current;

                        if (child.IsToken)
                        {
                            var token = GetFirstToken((SyntaxToken)child, predicate, stepInto);
                            if (token != null)
                            {
                                return token;
                            }
                        }

                        // push this enumerator back, not done yet
                        stack.Push(en);

                        if (child.IsNode)
                        {
                            stack.Push(((SyntaxNode)child).ChildNodesAndTokens().GetEnumerator());
                        }
                    }
                }

                return null;
            }
            finally
            {
                stack.Clear();
                s_childEnumeratorStackPool.Free(stack);
            }
        }

        private static readonly ObjectPool<Stack<ChildSyntaxList.Reversed.Enumerator>> s_childReversedEnumeratorStackPool
            = new ObjectPool<Stack<ChildSyntaxList.Reversed.Enumerator>>(() => new Stack<ChildSyntaxList.Reversed.Enumerator>(), 10);

        internal SyntaxToken GetLastToken(SyntaxNode current, Func<SyntaxToken, bool> predicate, Func<SyntaxTrivia, bool> stepInto)
        {
            var stack = s_childReversedEnumeratorStackPool.Allocate();
            try
            {
                stack.Push(current.ChildNodesAndTokens().Reverse().GetEnumerator());

                while (stack.Count > 0)
                {
                    var en = stack.Pop();

                    if (en.MoveNext())
                    {
                        var child = en.Current;

                        if (child.IsToken)
                        {
                            var token = GetLastToken((SyntaxToken)child, predicate, stepInto);
                            if (token != null)
                            {
                                return token;
                            }
                        }

                        // push this enumerator back, not done yet
                        stack.Push(en);

                        if (child.IsNode)
                        {
                            stack.Push(((SyntaxNode)child).ChildNodesAndTokens().Reverse().GetEnumerator());
                        }
                    }
                }

                return null;
            }
            finally
            {
                stack.Clear();
                s_childReversedEnumeratorStackPool.Free(stack);
            }
        }

        private SyntaxToken GetFirstToken(
            SyntaxTriviaList triviaList,
            Func<SyntaxToken, bool> predicate,
            Func<SyntaxTrivia, bool> stepInto)
        {
            Debug.Assert(stepInto != null);
            foreach (var trivia in triviaList)
            {
                if (trivia.HasStructure && stepInto(trivia))
                {
                    var structure = trivia.GetStructure();
                    var token = GetFirstToken(structure, predicate, stepInto);
                    if (token != null)
                    {
                        return token;
                    }
                }
            }

            return null;
        }

        private SyntaxToken GetLastToken(
            SyntaxTriviaList list,
            Func<SyntaxToken, bool> predicate,
            Func<SyntaxTrivia, bool> stepInto)
        {
            Debug.Assert(stepInto != null);

            foreach (var trivia in list.Reverse())
            {
                SyntaxToken token;
                if (TryGetLastTokenForStructuredTrivia(trivia, predicate, stepInto, out token))
                {
                    return token;
                }
            }

            return null;
        }

        private bool TryGetLastTokenForStructuredTrivia(
            SyntaxTrivia trivia,
            Func<SyntaxToken, bool> predicate,
            Func<SyntaxTrivia, bool> stepInto,
            out SyntaxToken token)
        {
            token = null;

            if (!trivia.HasStructure || stepInto == null || !stepInto(trivia))
            {
                return false;
            }

            token = GetLastToken(trivia.GetStructure(), predicate, stepInto);

            return token != null;
        }

        private SyntaxToken GetFirstToken(
            SyntaxToken token,
            Func<SyntaxToken, bool> predicate,
            Func<SyntaxTrivia, bool> stepInto)
        {
            // find first token that matches (either specified token or token inside related trivia)
            if (stepInto != null)
            {
                // search in leading trivia
                var firstToken = GetFirstToken(token.LeadingTrivia, predicate, stepInto);
                if (firstToken != null)
                {
                    return firstToken;
                }
            }

            if (Matches(predicate, token))
            {
                return token;
            }

            if (stepInto != null)
            {
                // search in trailing trivia
                var firstToken = GetFirstToken(token.TrailingTrivia, predicate, stepInto);
                if (firstToken != null)
                {
                    return firstToken;
                }
            }

            return null;
        }

        private SyntaxToken GetLastToken(
            SyntaxToken token,
            Func<SyntaxToken, bool> predicate,
            Func<SyntaxTrivia, bool> stepInto)
        {
            // find first token that matches (either specified token or token inside related trivia)
            if (stepInto != null)
            {
                // search in leading trivia
                var lastToken = GetLastToken(token.TrailingTrivia, predicate, stepInto);
                if (lastToken != null)
                {
                    return lastToken;
                }
            }

            if (Matches(predicate, token))
            {
                return token;
            }

            if (stepInto != null)
            {
                // search in trailing trivia
                var lastToken = GetLastToken(token.LeadingTrivia, predicate, stepInto);
                if (lastToken != null)
                {
                    return lastToken;
                }
            }

            return null;
        }

        internal SyntaxToken GetNextToken(
            SyntaxTrivia current,
            Func<SyntaxToken, bool> predicate,
            Func<SyntaxTrivia, bool> stepInto)
        {
            bool returnNext = false;

            // look inside leading trivia for current & next
            var token = GetNextToken(current, current.Token.LeadingTrivia, predicate, stepInto, ref returnNext);
            if (token != null)
            {
                return token;
            }

            // consider containing token if current trivia was in the leading trivia
            if (returnNext && (predicate == null || predicate == SyntaxToken.Any || predicate(current.Token)))
            {
                return current.Token;
            }

            // look inside trailing trivia for current & next (or just next)
            token = GetNextToken(current, current.Token.TrailingTrivia, predicate, stepInto, ref returnNext);
            if (token != null)
            {
                return token;
            }

            // did not find next inside trivia, try next sibling token 
            // (don't look in trailing trivia of token since it was already searched above)
            return GetNextToken(current.Token, predicate, false, stepInto);
        }

        internal SyntaxToken GetPreviousToken(
            SyntaxTrivia current,
            Func<SyntaxToken, bool> predicate,
            Func<SyntaxTrivia, bool> stepInto)
        {
            bool returnPrevious = false;

            // look inside leading trivia for current & next
            var token = GetPreviousToken(current, current.Token.TrailingTrivia, predicate, stepInto, ref returnPrevious);
            if (token != null)
            {
                return token;
            }

            // consider containing token if current trivia was in the leading trivia
            if (returnPrevious && Matches(predicate, current.Token))
            {
                return current.Token;
            }

            // look inside trailing trivia for current & next (or just next)
            token = GetPreviousToken(current, current.Token.LeadingTrivia, predicate, stepInto, ref returnPrevious);
            if (token != null)
            {
                return token;
            }

            // did not find next inside trivia, try next sibling token 
            // (don't look in trailing trivia of token since it was already searched above)
            return GetPreviousToken(current.Token, predicate, false, stepInto);
        }

        private SyntaxToken GetNextToken(
            SyntaxTrivia current,
            SyntaxTriviaList list,
            Func<SyntaxToken, bool> predicate,
            Func<SyntaxTrivia, bool> stepInto,
            ref bool returnNext)
        {
            foreach (var trivia in list)
            {
                if (returnNext)
                {
                    if (trivia.HasStructure && stepInto != null && stepInto(trivia))
                    {
                        var structure = trivia.GetStructure();
                        var token = GetFirstToken(structure, predicate, stepInto);
                        if (token != null)
                        {
                            return token;
                        }
                    }
                }
                else if (trivia == current)
                {
                    returnNext = true;
                }
            }

            return null;
        }

        private SyntaxToken GetPreviousToken(
            SyntaxTrivia current,
            SyntaxTriviaList list,
            Func<SyntaxToken, bool> predicate,
            Func<SyntaxTrivia, bool> stepInto,
            ref bool returnPrevious)
        {
            foreach (var trivia in list.Reverse())
            {
                if (returnPrevious)
                {
                    SyntaxToken token;
                    if (TryGetLastTokenForStructuredTrivia(trivia, predicate, stepInto, out token))
                    {
                        return token;
                    }
                }
                else if (trivia == current)
                {
                    returnPrevious = true;
                }
            }

            return null;
        }

        internal SyntaxToken GetNextToken(
            SyntaxNode node,
            Func<SyntaxToken, bool> predicate,
            Func<SyntaxTrivia, bool> stepInto)
        {
            while (node.Parent != null)
            {
                // walk forward in parent's child list until we find ourselves and then return the
                // next token
                bool returnNext = false;
                foreach (var child in node.Parent.ChildNodesAndTokens())
                {
                    if (returnNext)
                    {
                        if (child.IsToken)
                        {
                            var token = GetFirstToken((SyntaxToken)child, predicate, stepInto);
                            if (token != null)
                            {
                                return token;
                            }
                        }
                        else
                        {
                            var token = GetFirstToken((SyntaxNode)child, predicate, stepInto);
                            if (token != null)
                            {
                                return token;
                            }
                        }
                    }
                    else if (child.IsNode && child == node)
                    {
                        returnNext = true;
                    }
                }

                // didn't find the next token in my parent's children, look up the tree
                node = node.Parent;
            }

            if (node.IsStructuredTrivia)
            {
                return GetNextToken(((IStructuredTriviaSyntax)node).ParentTrivia, predicate, stepInto);
            }

            return null;
        }

        internal SyntaxToken GetPreviousToken(
            SyntaxNode node,
            Func<SyntaxToken, bool> predicate,
            Func<SyntaxTrivia, bool> stepInto)
        {
            while (node.Parent != null)
            {
                // walk forward in parent's child list until we find ourselves and then return the
                // previous token
                bool returnPrevious = false;
                foreach (var child in node.Parent.ChildNodesAndTokens().Reverse())
                {
                    if (returnPrevious)
                    {
                        if (child.IsToken)
                        {
                            var token = GetLastToken((SyntaxToken)child, predicate, stepInto);
                            if (token != null)
                            {
                                return token;
                            }
                        }
                        else
                        {
                            var token = GetLastToken((SyntaxNode)child, predicate, stepInto);
                            if (token != null)
                            {
                                return token;
                            }
                        }
                    }
                    else if (child.IsNode && child == node)
                    {
                        returnPrevious = true;
                    }
                }

                // didn't find the previous token in my parent's children, look up the tree
                node = node.Parent;
            }

            if (node.IsStructuredTrivia)
            {
                return GetPreviousToken(((IStructuredTriviaSyntax)node).ParentTrivia, predicate, stepInto);
            }

            return null;
        }

        internal SyntaxToken GetNextToken(SyntaxToken current, Func<SyntaxToken, bool> predicate, bool searchInsideCurrentTokenTrailingTrivia, Func<SyntaxTrivia, bool> stepInto)
        {
            Debug.Assert(searchInsideCurrentTokenTrailingTrivia == false || stepInto != null);
            if (current.Parent != null)
            {
                // look inside trailing trivia for structure
                if (searchInsideCurrentTokenTrailingTrivia)
                {
                    var firstToken = GetFirstToken(current.TrailingTrivia, predicate, stepInto);
                    if (firstToken != null)
                    {
                        return firstToken;
                    }
                }

                // walk forward in parent's child list until we find ourself 
                // and then return the next token
                bool returnNext = false;
                foreach (var child in current.Parent.ChildNodesAndTokens())
                {
                    if (returnNext)
                    {
                        if (child.IsToken)
                        {
                            var token = GetFirstToken((SyntaxToken)child, predicate, stepInto);
                            if (token != null)
                            {
                                return token;
                            }
                        }
                        else
                        {
                            var token = GetFirstToken((SyntaxNode)child, predicate, stepInto);
                            if (token != null)
                            {
                                return token;
                            }
                        }
                    }
                    else if (child.IsToken && current.Equals((SyntaxToken)child))
                    {
                        returnNext = true;
                    }
                }

                // otherwise get next token from the parent's parent, and so on
                return GetNextToken(current.Parent, predicate, stepInto);
            }

            return null;
        }

        internal SyntaxToken GetPreviousToken(SyntaxToken current, Func<SyntaxToken, bool> predicate, bool searchInsideCurrentTokenLeadingTrivia,
            Func<SyntaxTrivia, bool> stepInto)
        {
            Debug.Assert(searchInsideCurrentTokenLeadingTrivia == false || stepInto != null);
            if (current.Parent != null)
            {
                // look inside trailing trivia for structure
                if (searchInsideCurrentTokenLeadingTrivia)
                {
                    var lastToken = GetLastToken(current.LeadingTrivia, predicate, stepInto);
                    if (lastToken != null)
                    {
                        return lastToken;
                    }
                }

                // walk forward in parent's child list until we find ourself 
                // and then return the next token
                bool returnPrevious = false;
                foreach (var child in current.Parent.ChildNodesAndTokens().Reverse())
                {
                    if (returnPrevious)
                    {
                        if (child.IsToken)
                        {
                            var token = GetLastToken((SyntaxToken)child, predicate, stepInto);
                            if (token != null)
                            {
                                return token;
                            }
                        }
                        else
                        {
                            var token = GetLastToken((SyntaxNode)child, predicate, stepInto);
                            if (token != null)
                            {
                                return token;
                            }
                        }
                    }
                    else if (child.IsToken && current.Equals((SyntaxToken)child))
                    {
                        returnPrevious = true;
                    }
                }

                // otherwise get next token from the parent's parent, and so on
                return GetPreviousToken(current.Parent, predicate, stepInto);
            }

            return null;
        }
    }
}
