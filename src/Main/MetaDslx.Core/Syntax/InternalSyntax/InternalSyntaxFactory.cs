// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax
{
    using Microsoft.CodeAnalysis.Syntax.InternalSyntax;

    public abstract class InternalSyntaxFactory
    {
        private const string CrLf = "\r\n";

        public readonly InternalSyntaxTrivia CarriageReturnLineFeed;
        public readonly InternalSyntaxTrivia LineFeed;
        public readonly InternalSyntaxTrivia CarriageReturn;
        public readonly InternalSyntaxTrivia Space;
        public readonly InternalSyntaxTrivia Tab;

        public readonly InternalSyntaxTrivia ElasticCarriageReturnLineFeed;
        public readonly InternalSyntaxTrivia ElasticLineFeed;
        public readonly InternalSyntaxTrivia ElasticCarriageReturn;
        public readonly InternalSyntaxTrivia ElasticSpace;
        public readonly InternalSyntaxTrivia ElasticTab;

        public readonly InternalSyntaxTrivia ElasticZeroSpace;

        protected InternalSyntaxFactory()
        {
            CarriageReturnLineFeed = EndOfLine(CrLf);
            LineFeed = EndOfLine("\n");
            CarriageReturn = EndOfLine("\r");
            Space = Whitespace(" ");
            Tab = Whitespace("\t");

            ElasticCarriageReturnLineFeed = EndOfLine(CrLf, elastic: true);
            ElasticLineFeed = EndOfLine("\n", elastic: true);
            ElasticCarriageReturn = EndOfLine("\r", elastic: true);
            ElasticSpace = Whitespace(" ", elastic: true);
            ElasticTab = Whitespace("\t", elastic: true);

            ElasticZeroSpace = Whitespace(string.Empty, elastic: true);
        }

        public abstract Language Language { get; }

        public virtual InternalSyntaxToken DefaultSeparator
        {
            get { return this.Token(SyntaxKind.DefaultSeparator); }
        }

        // NOTE: it would be nice to have constants for OmittedArraySizeException and OmittedTypeArgument,
        // but it's non-trivial to introduce such constants, since they would make this class take a dependency
        // on the static fields of SyntaxToken (specifically, TokensWithNoTrivia via SyntaxToken.Create).  That
        // could cause unpredictable behavior, since SyntaxToken's static constructor already depends on the 
        // static fields of this class (specifically, ElasticZeroSpace).

        public InternalSyntaxTrivia EndOfLine(string text, bool elastic = false)
        {
            InternalSyntaxTrivia trivia = null;

            // use predefined trivia
            switch (text)
            {
                case "\r":
                    trivia = elastic ? ElasticCarriageReturn : CarriageReturn;
                    break;
                case "\n":
                    trivia = elastic ? ElasticLineFeed : LineFeed;
                    break;
                case "\r\n":
                    trivia = elastic ? ElasticCarriageReturnLineFeed : CarriageReturnLineFeed;
                    break;
            }

            // note: predefined trivia might not yet be defined during initialization
            if (trivia != null)
            {
                return trivia;
            }

            trivia = this.Trivia(SyntaxKind.DefaultEndOfLine, text);
            if (!elastic)
            {
                return trivia;
            }

            return trivia.WithAnnotationsGreen(new[] { SyntaxAnnotation.ElasticAnnotation });
        }

        public InternalSyntaxTrivia Whitespace(string text, bool elastic = false)
        {
            var trivia = this.Trivia(SyntaxKind.DefaultWhitespace, text);
            if (!elastic)
            {
                return trivia;
            }

            return trivia.WithAnnotationsGreen(new[] { SyntaxAnnotation.ElasticAnnotation });
        }

        public abstract InternalSyntaxTrivia Trivia(int kind, string text, bool elastic = false);
        public abstract InternalSyntaxTrivia ConflictMarker(string text);
        public abstract InternalSyntaxTrivia DisabledText(string text);
        public abstract InternalSyntaxToken Token(int kind);
        public abstract InternalSyntaxToken Token(GreenNode leading, int kind, GreenNode trailing);
        public abstract InternalSyntaxToken Token(GreenNode leading, int kind, string text, GreenNode trailing);
        public abstract InternalSyntaxToken Token(GreenNode leading, int kind, string text, string valueText, GreenNode trailing);
        public abstract InternalSyntaxToken Token(GreenNode leading, int kind, string text, object value, GreenNode trailing);
        public abstract InternalSyntaxToken MissingToken(int kind);
        public abstract InternalSyntaxToken MissingToken(GreenNode leading, int kind, GreenNode trailing);
        public abstract InternalSyntaxToken BadToken(GreenNode leading, string text, GreenNode trailing);

        public SyntaxList<TNode> List<TNode>() where TNode : CSharpSyntaxNode
        {
            return default(SyntaxList<TNode>);
        }

        public SyntaxList<TNode> List<TNode>(TNode node) where TNode : CSharpSyntaxNode
        {
            return new SyntaxList<TNode>(SyntaxList.List(node));
        }

        public SyntaxList<TNode> List<TNode>(TNode node0, TNode node1) where TNode : CSharpSyntaxNode
        {
            return new SyntaxList<TNode>(SyntaxList.List(node0, node1));
        }

        public GreenNode ListNode(CSharpSyntaxNode node0, CSharpSyntaxNode node1)
        {
            return SyntaxList.List(node0, node1);
        }

        public SyntaxList<TNode> List<TNode>(TNode node0, TNode node1, TNode node2) where TNode : CSharpSyntaxNode
        {
            return new SyntaxList<TNode>(SyntaxList.List(node0, node1, node2));
        }

        public GreenNode ListNode(CSharpSyntaxNode node0, CSharpSyntaxNode node1, CSharpSyntaxNode node2)
        {
            return SyntaxList.List(node0, node1, node2);
        }

        public SyntaxList<TNode> List<TNode>(params TNode[] nodes) where TNode : CSharpSyntaxNode
        {
            if (nodes != null)
            {
                return new SyntaxList<TNode>(SyntaxList.List(nodes));
            }

            return default(SyntaxList<TNode>);
        }

        public GreenNode ListNode(params ArrayElement<GreenNode>[] nodes)
        {
            return SyntaxList.List(nodes);
        }

        public SeparatedSyntaxList<TNode> SeparatedList<TNode>(TNode node) where TNode : CSharpSyntaxNode
        {
            return new SeparatedSyntaxList<TNode>(new SyntaxList<CSharpSyntaxNode>(node));
        }

        public SeparatedSyntaxList<TNode> SeparatedList<TNode>(InternalSyntaxToken token) where TNode : CSharpSyntaxNode
        {
            return new SeparatedSyntaxList<TNode>(new SyntaxList<CSharpSyntaxNode>(token));
        }

        public SeparatedSyntaxList<TNode> SeparatedList<TNode>(TNode node1, InternalSyntaxToken token, TNode node2) where TNode : CSharpSyntaxNode
        {
            return new SeparatedSyntaxList<TNode>(new SyntaxList<CSharpSyntaxNode>(SyntaxList.List(node1, token, node2)));
        }

        public SeparatedSyntaxList<TNode> SeparatedList<TNode>(params CSharpSyntaxNode[] nodes) where TNode : CSharpSyntaxNode
        {
            if (nodes != null)
            {
                return new SeparatedSyntaxList<TNode>(SyntaxList.List(nodes));
            }

            return default(SeparatedSyntaxList<TNode>);
        }

        public virtual IEnumerable<InternalSyntaxTrivia> GetWellKnownTrivia()
        {
            yield return CarriageReturnLineFeed;
            yield return LineFeed;
            yield return CarriageReturn;
            yield return Space;
            yield return Tab;

            yield return ElasticCarriageReturnLineFeed;
            yield return ElasticLineFeed;
            yield return ElasticCarriageReturn;
            yield return ElasticSpace;
            yield return ElasticTab;

            yield return ElasticZeroSpace;
        }

        public abstract IEnumerable<InternalSyntaxToken> GetWellKnownTokens();
    }
}
