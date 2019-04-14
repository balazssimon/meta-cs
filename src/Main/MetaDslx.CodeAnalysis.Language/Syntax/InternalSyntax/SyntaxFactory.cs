// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax
{
    using Microsoft.CodeAnalysis.Syntax.InternalSyntax;

    public abstract class SyntaxFactory
    {
        private const string CrLf = "\r\n";

        public readonly SyntaxTrivia CarriageReturnLineFeed;
        public readonly SyntaxTrivia LineFeed;
        public readonly SyntaxTrivia CarriageReturn;
        public readonly SyntaxTrivia Space;
        public readonly SyntaxTrivia Tab;

        public readonly SyntaxTrivia ElasticCarriageReturnLineFeed;
        public readonly SyntaxTrivia ElasticLineFeed;
        public readonly SyntaxTrivia ElasticCarriageReturn;
        public readonly SyntaxTrivia ElasticSpace;
        public readonly SyntaxTrivia ElasticTab;

        public readonly SyntaxTrivia ElasticZeroSpace;

        protected SyntaxFactory()
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

        public virtual SyntaxToken DefaultSeparator
        {
            get { return this.Token(SyntaxKind.DefaultSeparator); }
        }

        // NOTE: it would be nice to have constants for OmittedArraySizeException and OmittedTypeArgument,
        // but it's non-trivial to introduce such constants, since they would make this class take a dependency
        // on the static fields of SyntaxToken (specifically, TokensWithNoTrivia via SyntaxToken.Create).  That
        // could cause unpredictable behavior, since SyntaxToken's static constructor already depends on the 
        // static fields of this class (specifically, ElasticZeroSpace).

        public SyntaxTrivia EndOfLine(string text, bool elastic = false)
        {
            SyntaxTrivia trivia = null;

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

        public SyntaxTrivia Whitespace(string text, bool elastic = false)
        {
            var trivia = this.Trivia(SyntaxKind.DefaultWhitespace, text);
            if (!elastic)
            {
                return trivia;
            }

            return trivia.WithAnnotationsGreen(new[] { SyntaxAnnotation.ElasticAnnotation });
        }

        public abstract SyntaxTrivia Trivia(int kind, string text, bool elastic = false);
        public abstract SyntaxTrivia ConflictMarker(string text);
        public abstract SyntaxTrivia DisabledText(string text);
        public abstract SyntaxToken Token(int kind);
        public abstract SyntaxToken Token(GreenNode leading, int kind, GreenNode trailing);
        public abstract SyntaxToken Token(GreenNode leading, int kind, string text, GreenNode trailing);
        public abstract SyntaxToken Token(GreenNode leading, int kind, string text, string valueText, GreenNode trailing);
        public abstract SyntaxToken Token(GreenNode leading, int kind, string text, object value, GreenNode trailing);
        public abstract SyntaxToken MissingToken(int kind);
        public abstract SyntaxToken MissingToken(GreenNode leading, int kind, GreenNode trailing);
        public abstract SyntaxToken BadToken(GreenNode leading, string text, GreenNode trailing);

        internal SyntaxList<TNode> List<TNode>() where TNode : CSharpSyntaxNode
        {
            return default(SyntaxList<TNode>);
        }

        internal SyntaxList<TNode> List<TNode>(TNode node) where TNode : CSharpSyntaxNode
        {
            return new SyntaxList<TNode>(SyntaxList.List(node));
        }

        internal SyntaxList<TNode> List<TNode>(TNode node0, TNode node1) where TNode : CSharpSyntaxNode
        {
            return new SyntaxList<TNode>(SyntaxList.List(node0, node1));
        }

        internal GreenNode ListNode(CSharpSyntaxNode node0, CSharpSyntaxNode node1)
        {
            return SyntaxList.List(node0, node1);
        }

        internal SyntaxList<TNode> List<TNode>(TNode node0, TNode node1, TNode node2) where TNode : CSharpSyntaxNode
        {
            return new SyntaxList<TNode>(SyntaxList.List(node0, node1, node2));
        }

        internal GreenNode ListNode(CSharpSyntaxNode node0, CSharpSyntaxNode node1, CSharpSyntaxNode node2)
        {
            return SyntaxList.List(node0, node1, node2);
        }

        internal SyntaxList<TNode> List<TNode>(params TNode[] nodes) where TNode : CSharpSyntaxNode
        {
            if (nodes != null)
            {
                return new SyntaxList<TNode>(SyntaxList.List(nodes));
            }

            return default(SyntaxList<TNode>);
        }

        internal GreenNode ListNode(params ArrayElement<GreenNode>[] nodes)
        {
            return SyntaxList.List(nodes);
        }

        internal SeparatedSyntaxList<TNode> SeparatedList<TNode>(TNode node) where TNode : CSharpSyntaxNode
        {
            return new SeparatedSyntaxList<TNode>(new SyntaxList<CSharpSyntaxNode>(node));
        }

        internal SeparatedSyntaxList<TNode> SeparatedList<TNode>(SyntaxToken token) where TNode : CSharpSyntaxNode
        {
            return new SeparatedSyntaxList<TNode>(new SyntaxList<CSharpSyntaxNode>(token));
        }

        internal SeparatedSyntaxList<TNode> SeparatedList<TNode>(TNode node1, SyntaxToken token, TNode node2) where TNode : CSharpSyntaxNode
        {
            return new SeparatedSyntaxList<TNode>(new SyntaxList<CSharpSyntaxNode>(SyntaxList.List(node1, token, node2)));
        }

        internal SeparatedSyntaxList<TNode> SeparatedList<TNode>(params CSharpSyntaxNode[] nodes) where TNode : CSharpSyntaxNode
        {
            if (nodes != null)
            {
                return new SeparatedSyntaxList<TNode>(SyntaxList.List(nodes));
            }

            return default(SeparatedSyntaxList<TNode>);
        }

        internal protected virtual IEnumerable<SyntaxTrivia> GetWellKnownTrivia()
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

        internal protected abstract IEnumerable<SyntaxToken> GetWellKnownTokens();
    }
}
