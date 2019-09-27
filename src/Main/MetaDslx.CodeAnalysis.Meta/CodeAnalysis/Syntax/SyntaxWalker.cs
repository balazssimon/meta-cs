﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Diagnostics;
using Microsoft.CodeAnalysis;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis
{
    /// <summary>
    /// Represents a <see cref="SyntaxVisitor"/> that descends an entire <see cref="LanguageSyntaxNode"/> graph
    /// visiting each CSharpSyntaxNode and its child SyntaxNodes and <see cref="SyntaxToken"/>s in depth-first order.
    /// </summary>
    public abstract class SyntaxWalker : SyntaxVisitor
    {
        protected SyntaxWalkerDepth Depth { get; }

        protected SyntaxWalker(SyntaxWalkerDepth depth = SyntaxWalkerDepth.Node)
        {
            this.Depth = depth;
        }

        private int _recursionDepth;

        public override void Visit(SyntaxNode node)
        {
            if (node != null)
            {
                _recursionDepth++;
                StackGuard.EnsureSufficientExecutionStack(_recursionDepth);

                ((LanguageSyntaxNode)node).Accept(this);

                _recursionDepth--;
            }
        }

        public override void DefaultVisit(SyntaxNode node)
        {
            var childCnt = node.ChildNodesAndTokens().Count;
            int i = 0;

            do
            {
                var child = ChildSyntaxList.ItemInternal((LanguageSyntaxNode)node, i);
                i++;

                var asNode = child.AsNode();
                if (asNode != null)
                {
                    if (this.Depth >= SyntaxWalkerDepth.Node)
                    {
                        this.Visit(asNode);
                    }
                }
                else
                {
                    if (this.Depth >= SyntaxWalkerDepth.Token)
                    {
                        this.VisitToken(child.AsToken());
                    }
                }
            } while (i < childCnt);
        }

        public virtual void VisitToken(SyntaxToken token)
        {
            if (this.Depth >= SyntaxWalkerDepth.Trivia)
            {
                this.VisitLeadingTrivia(token);
                this.VisitTrailingTrivia(token);
            }
        }

        public virtual void VisitLeadingTrivia(SyntaxToken token)
        {
            if (token.HasLeadingTrivia)
            {
                foreach (var tr in token.LeadingTrivia)
                {
                    this.VisitTrivia(tr);
                }
            }
        }

        public virtual void VisitTrailingTrivia(SyntaxToken token)
        {
            if (token.HasTrailingTrivia)
            {
                foreach (var tr in token.TrailingTrivia)
                {
                    this.VisitTrivia(tr);
                }
            }
        }

        public virtual void VisitTrivia(SyntaxTrivia trivia)
        {
            if (this.Depth >= SyntaxWalkerDepth.StructuredTrivia && trivia.HasStructure)
            {
                this.Visit((LanguageSyntaxNode)trivia.GetStructure());
            }
        }
    }
}