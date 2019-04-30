﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MetaDslx.CodeAnalysis.Syntax.InternalSyntax
{
    using Microsoft.CodeAnalysis;
    using Internal = Microsoft.CodeAnalysis.Syntax.InternalSyntax;

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

            return trivia.WithAnnotationsGreen(new[] { Microsoft.CodeAnalysis.SyntaxAnnotation.ElasticAnnotation });
        }

        public InternalSyntaxTrivia Whitespace(string text, bool elastic = false)
        {
            var trivia = this.Trivia(SyntaxKind.DefaultWhitespace, text);
            if (!elastic)
            {
                return trivia;
            }

            return trivia.WithAnnotationsGreen(new[] { Microsoft.CodeAnalysis.SyntaxAnnotation.ElasticAnnotation });
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

        public Internal.SyntaxList<TNode> List<TNode>() where TNode : InternalSyntaxNode
        {
            return default(Internal.SyntaxList<TNode>);
        }

        public Internal.SyntaxList<TNode> List<TNode>(TNode node) where TNode : InternalSyntaxNode
        {
            return new Internal.SyntaxList<TNode>(Internal.SyntaxList.List(node));
        }

        public Internal.SyntaxList<TNode> List<TNode>(TNode node0, TNode node1) where TNode : InternalSyntaxNode
        {
            return new Internal.SyntaxList<TNode>(Internal.SyntaxList.List(node0, node1));
        }

        public GreenNode ListNode(InternalSyntaxNode node0, InternalSyntaxNode node1)
        {
            return Internal.SyntaxList.List(node0, node1);
        }

        public Internal.SyntaxList<TNode> List<TNode>(TNode node0, TNode node1, TNode node2) where TNode : InternalSyntaxNode
        {
            return new Internal.SyntaxList<TNode>(Internal.SyntaxList.List(node0, node1, node2));
        }

        public GreenNode ListNode(InternalSyntaxNode node0, InternalSyntaxNode node1, InternalSyntaxNode node2)
        {
            return Internal.SyntaxList.List(node0, node1, node2);
        }

        public Internal.SyntaxList<TNode> List<TNode>(params TNode[] nodes) where TNode : InternalSyntaxNode
        {
            if (nodes != null)
            {
                return new Internal.SyntaxList<TNode>(Internal.SyntaxList.List(nodes));
            }

            return default(Internal.SyntaxList<TNode>);
        }

        public GreenNode ListNode(params ArrayElement<GreenNode>[] nodes)
        {
            return Internal.SyntaxList.List(nodes);
        }

        public Internal.SeparatedSyntaxList<TNode> SeparatedList<TNode>(TNode node) where TNode : InternalSyntaxNode
        {
            return new Internal.SeparatedSyntaxList<TNode>(new Internal.SyntaxList<InternalSyntaxNode>(node));
        }

        public Internal.SeparatedSyntaxList<TNode> SeparatedList<TNode>(InternalSyntaxToken token) where TNode : InternalSyntaxNode
        {
            return new Internal.SeparatedSyntaxList<TNode>(new Internal.SyntaxList<InternalSyntaxNode>(token));
        }

        public Internal.SeparatedSyntaxList<TNode> SeparatedList<TNode>(TNode node1, InternalSyntaxToken token, TNode node2) where TNode : InternalSyntaxNode
        {
            return new Internal.SeparatedSyntaxList<TNode>(new Internal.SyntaxList<InternalSyntaxNode>(Internal.SyntaxList.List(node1, token, node2)));
        }

        public Internal.SeparatedSyntaxList<TNode> SeparatedList<TNode>(params InternalSyntaxNode[] nodes) where TNode : InternalSyntaxNode
        {
            if (nodes != null)
            {
                return new Internal.SeparatedSyntaxList<TNode>(Internal.SyntaxList.List(nodes));
            }

            return default(Internal.SeparatedSyntaxList<TNode>);
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