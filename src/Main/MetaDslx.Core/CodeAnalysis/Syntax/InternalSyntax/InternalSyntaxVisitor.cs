// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

namespace MetaDslx.CodeAnalysis.Syntax.InternalSyntax
{
    public abstract partial class InternalSyntaxVisitor<TResult>
    {
        public virtual TResult Visit(InternalSyntaxNode node)
        {
            if (node == null)
            {
                return default(TResult);
            }

            return node.Accept(this);
        }

        public virtual TResult VisitToken(InternalSyntaxToken token)
        {
            return this.DefaultVisit(token);
        }

        public virtual TResult VisitTrivia(InternalSyntaxTrivia trivia)
        {
            return this.DefaultVisit(trivia);
        }

        public virtual TResult DefaultVisit(InternalSyntaxNode node)
        {
            return default(TResult);
        }
    }

    public abstract partial class InternalSyntaxVisitor
    {
        public virtual void Visit(InternalSyntaxNode node)
        {
            if (node == null)
            {
                return;
            }

            node.Accept(this);
        }

        public virtual void VisitToken(InternalSyntaxToken token)
        {
            this.DefaultVisit(token);
        }

        public virtual void VisitTrivia(InternalSyntaxTrivia trivia)
        {
            this.DefaultVisit(trivia);
        }

        public virtual void DefaultVisit(InternalSyntaxNode node)
        {
        }
    }
}
