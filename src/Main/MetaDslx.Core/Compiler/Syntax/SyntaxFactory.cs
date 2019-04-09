// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using MetaDslx.Compiler.Text;
using InternalSyntax = MetaDslx.Compiler.Syntax.InternalSyntax;
using System.Xml.Linq;
using MetaDslx.Compiler.Utilities;
using MetaDslx.Compiler.Syntax.InternalSyntax;

namespace MetaDslx.Compiler.Syntax
{
    /// <summary>
    /// A class containing factory methods for constructing syntax nodes, tokens and trivia.
    /// </summary>
    public abstract class SyntaxFactory
    {
        private readonly InternalSyntaxFactory InternalSyntaxFactory;

        public SyntaxFactory(InternalSyntaxFactory internalSyntaxFactory)
        {
            this.InternalSyntaxFactory = internalSyntaxFactory;
            CarriageReturnLineFeed = InternalSyntaxFactory.CarriageReturnLineFeed;
            LineFeed = InternalSyntaxFactory.LineFeed;
            CarriageReturn = InternalSyntaxFactory.CarriageReturn;
            Space = InternalSyntaxFactory.Space;
            Tab = InternalSyntaxFactory.Tab;
            ElasticCarriageReturnLineFeed = InternalSyntaxFactory.ElasticCarriageReturnLineFeed;
            ElasticLineFeed = InternalSyntaxFactory.ElasticLineFeed;
            ElasticCarriageReturn = InternalSyntaxFactory.ElasticCarriageReturn;
            ElasticSpace = InternalSyntaxFactory.ElasticSpace;
            ElasticTab = InternalSyntaxFactory.ElasticTab;
            ElasticMarker = InternalSyntaxFactory.ElasticZeroSpace;
        }

        public Language Language
        {
            get { return this.InternalSyntaxFactory.Language; }
        }

        internal protected abstract SyntaxToken DefaultToken { get; }
        internal protected abstract SyntaxTrivia DefaultTrivia { get; }
        internal protected abstract SyntaxTrivia DefaultEndOfLineTrivia { get; }
        internal protected abstract SyntaxToken DefaultSeparator { get; }
        internal protected virtual SyntaxToken Separator<TNode>(TNode item) where TNode : SyntaxNode
        {
            return this.DefaultSeparator;
        }
        internal protected abstract SyntaxToken Token(int kind);
        internal protected abstract SyntaxToken Token(SyntaxNode tokenStructure);
        internal protected abstract SyntaxTrivia Trivia(SyntaxNode triviaStructure);
        internal protected abstract SyntaxNode StructuredToken(SyntaxToken token);
        internal protected abstract SyntaxNode StructuredTrivia(SyntaxTrivia trivia);

        public abstract string ExtractName(SyntaxNode node);
        public abstract string ExtractName(SyntaxToken token);

        public abstract SyntaxNormalizer Normalizer(TextSpan consideredSpan, int initialDepth, string indentWhitespace, string eolWhitespace, bool useElasticTrivia);

        protected abstract SyntaxTree ParseSyntaxTreeCore(SourceText text, ParseOptions options = null, string path = "", CancellationToken cancellationToken = default(CancellationToken));
        public abstract SyntaxParser MakeParser(SourceText text, ParseOptions options, SyntaxNode oldTree, IReadOnlyList<TextChangeRange> changes);
        public abstract SyntaxParser MakeParser(string text);

        /// <summary>
        /// A trivia with kind EndOfLineTrivia containing both the carriage return and line feed characters.
        /// </summary>
        public readonly SyntaxTrivia CarriageReturnLineFeed;

        /// <summary>
        /// A trivia with kind EndOfLineTrivia containing a single line feed character.
        /// </summary>
        public readonly SyntaxTrivia LineFeed;

        /// <summary>
        /// A trivia with kind EndOfLineTrivia containing a single carriage return character.
        /// </summary>
        public readonly SyntaxTrivia CarriageReturn;

        /// <summary>
        ///  A trivia with kind WhitespaceTrivia containing a single space character.
        /// </summary>
        public readonly SyntaxTrivia Space;

        /// <summary>
        /// A trivia with kind WhitespaceTrivia containing a single tab character.
        /// </summary>
        public readonly SyntaxTrivia Tab;

        /// <summary>
        /// An elastic trivia with kind EndOfLineTrivia containing both the carriage return and line feed characters.
        /// Elastic trivia are used to denote trivia that was not produced by parsing source text, and are usually not
        /// preserved during formatting.
        /// </summary>
        public readonly SyntaxTrivia ElasticCarriageReturnLineFeed;

        /// <summary>
        /// An elastic trivia with kind EndOfLineTrivia containing a single line feed character. Elastic trivia are used
        /// to denote trivia that was not produced by parsing source text, and are usually not preserved during
        /// formatting.
        /// </summary>
        public readonly SyntaxTrivia ElasticLineFeed;

        /// <summary>
        /// An elastic trivia with kind EndOfLineTrivia containing a single carriage return character. Elastic trivia
        /// are used to denote trivia that was not produced by parsing source text, and are usually not preserved during
        /// formatting.
        /// </summary>
        public readonly SyntaxTrivia ElasticCarriageReturn;

        /// <summary>
        /// An elastic trivia with kind WhitespaceTrivia containing a single space character. Elastic trivia are used to
        /// denote trivia that was not produced by parsing source text, and are usually not preserved during formatting.
        /// </summary>
        public readonly SyntaxTrivia ElasticSpace;

        /// <summary>
        /// An elastic trivia with kind WhitespaceTrivia containing a single tab character. Elastic trivia are used to
        /// denote trivia that was not produced by parsing source text, and are usually not preserved during formatting.
        /// </summary>
        public readonly SyntaxTrivia ElasticTab;

        /// <summary>
        /// An elastic trivia with kind WhitespaceTrivia containing no characters. Elastic marker trivia are included
        /// automatically by factory methods when trivia is not specified. Syntax formatting will replace elastic
        /// markers with appropriate trivia.
        /// </summary>
        public readonly SyntaxTrivia ElasticMarker;

        /// <summary>
        /// Creates a trivia with kind EndOfLineTrivia containing the specified text. 
        /// </summary>
        /// <param name="text">The text of the end of line. Any text can be specified here, however only carriage return and
        /// line feed characters are recognized by the parser as end of line.</param>
        public SyntaxTrivia EndOfLine(string text)
        {
            return InternalSyntaxFactory.EndOfLine(text, elastic: false);
        }

        /// <summary>
        /// Creates a trivia with kind EndOfLineTrivia containing the specified text. Elastic trivia are used to
        /// denote trivia that was not produced by parsing source text, and are usually not preserved during formatting.
        /// </summary>
        /// <param name="text">The text of the end of line. Any text can be specified here, however only carriage return and
        /// line feed characters are recognized by the parser as end of line.</param>
        public SyntaxTrivia ElasticEndOfLine(string text)
        {
            return InternalSyntaxFactory.EndOfLine(text, elastic: true);
        }

        /// <summary>
        /// Creates a trivia with kind WhitespaceTrivia containing the specified text.
        /// </summary>
        /// <param name="text">The text of the whitespace. Any text can be specified here, however only specific
        /// whitespace characters are recognized by the parser.</param>
        public SyntaxTrivia Whitespace(string text)
        {
            return InternalSyntaxFactory.Whitespace(text, elastic: false);
        }

        /// <summary>
        /// Creates a trivia with kind WhitespaceTrivia containing the specified text. Elastic trivia are used to
        /// denote trivia that was not produced by parsing source text, and are usually not preserved during formatting.
        /// </summary>
        /// <param name="text">The text of the whitespace. Any text can be specified here, however only specific
        /// whitespace characters are recognized by the parser.</param>
        public SyntaxTrivia ElasticWhitespace(string text)
        {
            return InternalSyntaxFactory.Whitespace(text, elastic: false);
        }

        public virtual bool IsWeaklyReferencedChild(SyntaxNode languageSyntaxNode)
        {
            return false;
        }

        /// <summary>
        /// Creates an empty list of syntax nodes.
        /// </summary>
        /// <typeparam name="TNode">The specific type of the element nodes.</typeparam>
        public SyntaxList<TNode> List<TNode>() where TNode : SyntaxNode
        {
            return default(SyntaxList<TNode>);
        }

        /// <summary>
        /// Creates a singleton list of syntax nodes.
        /// </summary>
        /// <typeparam name="TNode">The specific type of the element nodes.</typeparam>
        /// <param name="node">The single element node.</param>
        /// <returns></returns>
        public SyntaxList<TNode> SingletonList<TNode>(TNode node) where TNode : SyntaxNode
        {
            return new SyntaxList<TNode>(node);
        }

        /// <summary>
        /// Creates a list of syntax nodes.
        /// </summary>
        /// <typeparam name="TNode">The specific type of the element nodes.</typeparam>
        /// <param name="nodes">A sequence of element nodes.</param>
        public SyntaxList<TNode> List<TNode>(IEnumerable<TNode> nodes) where TNode : SyntaxNode
        {
            return new SyntaxList<TNode>(nodes);
        }

        /// <summary>
        /// Creates an empty list of tokens.
        /// </summary>
        public SyntaxTokenList TokenList()
        {
            return default(SyntaxTokenList);
        }

        /// <summary>
        /// Creates a singleton list of tokens.
        /// </summary>
        /// <param name="token">The single token.</param>
        public SyntaxTokenList TokenList(SyntaxToken token)
        {
            return new SyntaxTokenList(token);
        }

        /// <summary>
        /// Creates a list of tokens.
        /// </summary>
        /// <param name="tokens">An array of tokens.</param>
        public SyntaxTokenList TokenList(params SyntaxToken[] tokens)
        {
            return new SyntaxTokenList(tokens);
        }

        /// <summary>
        /// Creates a list of tokens.
        /// </summary>
        /// <param name="tokens"></param>
        /// <returns></returns>
        public SyntaxTokenList TokenList(IEnumerable<SyntaxToken> tokens)
        {
            return new SyntaxTokenList(tokens);
        }

        /// <summary>
        /// Creates an empty list of trivia.
        /// </summary>
        public SyntaxTriviaList TriviaList()
        {
            return default(SyntaxTriviaList);
        }

        /// <summary>
        /// Creates a singleton list of trivia.
        /// </summary>
        /// <param name="trivia">A single trivia.</param>
        public SyntaxTriviaList TriviaList(SyntaxTrivia trivia)
        {
            return new SyntaxTriviaList(trivia);
        }

        /// <summary>
        /// Creates a list of trivia.
        /// </summary>
        /// <param name="trivias">An array of trivia.</param>
        public SyntaxTriviaList TriviaList(params SyntaxTrivia[] trivias)
        => new SyntaxTriviaList(trivias);

        /// <summary>
        /// Creates a list of trivia.
        /// </summary>
        /// <param name="trivias">A sequence of trivia.</param>
        public SyntaxTriviaList TriviaList(IEnumerable<SyntaxTrivia> trivias)
        => new SyntaxTriviaList(trivias);

        /// <summary>
        /// Creates an empty separated list.
        /// </summary>
        /// <typeparam name="TNode">The specific type of the element nodes.</typeparam>
        public SeparatedSyntaxList<TNode> SeparatedList<TNode>() where TNode : SyntaxNode
        {
            return default(SeparatedSyntaxList<TNode>);
        }

        /// <summary>
        /// Creates a singleton separated list.
        /// </summary>
        /// <typeparam name="TNode">The specific type of the element nodes.</typeparam>
        /// <param name="node">A single node.</param>
        public SeparatedSyntaxList<TNode> SingletonSeparatedList<TNode>(TNode node) where TNode : SyntaxNode
        {
            return new SeparatedSyntaxList<TNode>(new SyntaxNodeOrTokenList(node, index: 0));
        }

        /// <summary>
        /// Creates a separated list of nodes from a sequence of nodes, synthesizing separators in between.
        /// </summary>
        /// <typeparam name="TNode">The specific type of the element nodes.</typeparam>
        /// <param name="nodes">A sequence of syntax nodes.</param>
        /// <param name="separatorKind">The SyntaxKind of the separator between nodes.</param>
        public SeparatedSyntaxList<TNode> SeparatedList<TNode>(IEnumerable<TNode> nodes, int separatorKind) where TNode : SyntaxNode
        {
            if (nodes == null)
            {
                return default(SeparatedSyntaxList<TNode>);
            }

            var collection = nodes as ICollection<TNode>;

            if (collection != null && collection.Count == 0)
            {
                return default(SeparatedSyntaxList<TNode>);
            }

            using (var enumerator = nodes.GetEnumerator())
            {
                if (!enumerator.MoveNext())
                {
                    return default(SeparatedSyntaxList<TNode>);
                }

                var firstNode = enumerator.Current;

                if (!enumerator.MoveNext())
                {
                    return SingletonSeparatedList<TNode>(firstNode);
                }

                var builder = new SeparatedSyntaxListBuilder<TNode>(collection != null ? collection.Count : 3);

                builder.Add(firstNode);

                var commaToken = Token(separatorKind);

                do
                {
                    builder.AddSeparator(commaToken);
                    builder.Add(enumerator.Current);
                }
                while (enumerator.MoveNext());

                return builder.ToList();
            }
        }

        /// <summary>
        /// Creates a separated list of nodes from a sequence of nodes and a sequence of separator tokens.
        /// </summary>
        /// <typeparam name="TNode">The specific type of the element nodes.</typeparam>
        /// <param name="nodes">A sequence of syntax nodes.</param>
        /// <param name="separators">A sequence of token to be interleaved between the nodes. The number of tokens must
        /// be one less than the number of nodes.</param>
        public SeparatedSyntaxList<TNode> SeparatedList<TNode>(IEnumerable<TNode> nodes, IEnumerable<SyntaxToken> separators) where TNode : SyntaxNode
        {
            // Interleave the nodes and the separators.  The number of separators must be equal to or 1 less than the number of nodes or
            // an argument exception is thrown.

            if (nodes != null)
            {
                IEnumerator<TNode> enumerator = nodes.GetEnumerator();
                SeparatedSyntaxListBuilder<TNode> builder = SeparatedSyntaxListBuilder<TNode>.Create();
                if (separators != null)
                {
                    foreach (SyntaxToken token in separators)
                    {
                        if (!enumerator.MoveNext())
                        {
                            throw new ArgumentException($"{nameof(nodes)} must not be empty.", nameof(nodes));
                        }

                        builder.Add(enumerator.Current);
                        builder.AddSeparator(token);
                    }
                }

                if (enumerator.MoveNext())
                {
                    builder.Add(enumerator.Current);
                    if (enumerator.MoveNext())
                    {
                        throw new ArgumentException($"{nameof(separators)} must have 1 fewer element than {nameof(nodes)}", nameof(separators));
                    }
                }

                return builder.ToList();
            }

            if (separators != null)
            {
                throw new ArgumentException($"When {nameof(nodes)} is null, {nameof(separators)} must also be null.", nameof(separators));
            }

            return default(SeparatedSyntaxList<TNode>);
        }

        /// <summary>
        /// Creates a separated list from a sequence of nodes and tokens, starting with a node and alternating between additional nodes and separator tokens.
        /// </summary>
        /// <typeparam name="TNode">The specific type of the element nodes.</typeparam>
        /// <param name="nodesAndTokens">A sequence of nodes or tokens, alternating between nodes and separator tokens.</param>
        public SeparatedSyntaxList<TNode> SeparatedList<TNode>(IEnumerable<SyntaxNodeOrToken> nodesAndTokens) where TNode : SyntaxNode
        {
            return SeparatedList<TNode>(NodeOrTokenList(nodesAndTokens));
        }

        /// <summary>
        /// Creates a separated list from a <see cref="SyntaxNodeOrTokenList"/>, where the list elements start with a node and then alternate between
        /// additional nodes and separator tokens.
        /// </summary>
        /// <typeparam name="TNode">The specific type of the element nodes.</typeparam>
        /// <param name="nodesAndTokens">The list of nodes and tokens.</param>
        public SeparatedSyntaxList<TNode> SeparatedList<TNode>(SyntaxNodeOrTokenList nodesAndTokens) where TNode : SyntaxNode
        {
            if (!HasSeparatedNodeTokenPattern(nodesAndTokens))
            {
                throw new ArgumentException(CompilerResources.NodeOrTokenOutOfSequence);
            }

            if (!NodesAreCorrectType<TNode>(nodesAndTokens))
            {
                throw new ArgumentException(CompilerResources.UnexpectedTypeOfNodeInList);
            }

            return new SeparatedSyntaxList<TNode>(nodesAndTokens);
        }

        private bool NodesAreCorrectType<TNode>(SyntaxNodeOrTokenList list)
        {
            for (int i = 0, n = list.Count; i < n; i++)
            {
                var element = list[i];
                if (element.IsNode && !(element.AsNode() is TNode))
                {
                    return false;
                }
            }

            return true;
        }

        private bool HasSeparatedNodeTokenPattern(SyntaxNodeOrTokenList list)
        {
            for (int i = 0, n = list.Count; i < n; i++)
            {
                var element = list[i];
                if (element.IsToken == ((i & 1) == 0))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Creates an empty <see cref="SyntaxNodeOrTokenList"/>.
        /// </summary>
        public SyntaxNodeOrTokenList NodeOrTokenList()
        {
            return default(SyntaxNodeOrTokenList);
        }

        /// <summary>
        /// Create a <see cref="SyntaxNodeOrTokenList"/> from a sequence of <see cref="SyntaxNodeOrToken"/>.
        /// </summary>
        /// <param name="nodesAndTokens">The sequence of nodes and tokens</param>
        public SyntaxNodeOrTokenList NodeOrTokenList(IEnumerable<SyntaxNodeOrToken> nodesAndTokens)
        {
            return new SyntaxNodeOrTokenList(nodesAndTokens);
        }

        /// <summary>
        /// Create a <see cref="SyntaxNodeOrTokenList"/> from one or more <see cref="SyntaxNodeOrToken"/>.
        /// </summary>
        /// <param name="nodesAndTokens">The nodes and tokens</param>
        public SyntaxNodeOrTokenList NodeOrTokenList(params SyntaxNodeOrToken[] nodesAndTokens)
        {
            return new SyntaxNodeOrTokenList(nodesAndTokens);
        }

        /// <summary>
        /// Determines if two trees are the same, disregarding trivia differences.
        /// </summary>
        /// <param name="oldTree">The original tree.</param>
        /// <param name="newTree">The new tree.</param>
        /// <param name="topLevel"> 
        /// If true then the trees are equivalent if the contained nodes and tokens declaring
        /// metadata visible symbolic information are equivalent, ignoring any differences of nodes inside method bodies
        /// or initializer expressions, otherwise all nodes and tokens must be equivalent. 
        /// </param>
        public bool AreEquivalent(SyntaxTree oldTree, SyntaxTree newTree)
        {
            if (oldTree == null && newTree == null)
            {
                return true;
            }

            if (oldTree == null || newTree == null)
            {
                return false;
            }

            return SyntaxEquivalence.AreEquivalent(oldTree, newTree, ignoreChildNode: null);
        }

        /// <summary>
        /// Determines if two syntax nodes are the same, disregarding trivia differences.
        /// </summary>
        /// <param name="oldNode">The old node.</param>
        /// <param name="newNode">The new node.</param>
        /// <param name="topLevel"> 
        /// If true then the nodes are equivalent if the contained nodes and tokens declaring
        /// metadata visible symbolic information are equivalent, ignoring any differences of nodes inside method bodies
        /// or initializer expressions, otherwise all nodes and tokens must be equivalent. 
        /// </param>
        public bool AreEquivalent(SyntaxNode oldNode, SyntaxNode newNode)
        {
            return SyntaxEquivalence.AreEquivalent(oldNode, newNode, ignoreChildNode: null);
        }

        /// <summary>
        /// Determines if two syntax nodes are the same, disregarding trivia differences.
        /// </summary>
        /// <param name="oldNode">The old node.</param>
        /// <param name="newNode">The new node.</param>
        /// <param name="ignoreChildNode">
        /// If specified called for every child syntax node (not token) that is visited during the comparison. 
        /// If it returns true the child is recursively visited, otherwise the child and its subtree is disregarded.
        /// </param>
        public bool AreEquivalent(SyntaxNode oldNode, SyntaxNode newNode, Func<int, bool> ignoreChildNode = null)
        {
            return SyntaxEquivalence.AreEquivalent(oldNode, newNode, ignoreChildNode: ignoreChildNode);
        }

        /// <summary>
        /// Determines if two syntax tokens are the same, disregarding trivia differences.
        /// </summary>
        /// <param name="oldToken">The old token.</param>
        /// <param name="newToken">The new token.</param>
        public bool AreEquivalent(SyntaxToken oldToken, SyntaxToken newToken)
        {
            return SyntaxEquivalence.AreEquivalent(oldToken, newToken);
        }

        /// <summary>
        /// Determines if two lists of tokens are the same, disregarding trivia differences.
        /// </summary>
        /// <param name="oldList">The old token list.</param>
        /// <param name="newList">The new token list.</param>
        public bool AreEquivalent(SyntaxTokenList oldList, SyntaxTokenList newList)
        {
            return SyntaxEquivalence.AreEquivalent(oldList, newList);
        }

        /// <summary>
        /// Determines if two lists of syntax nodes are the same, disregarding trivia differences.
        /// </summary>
        /// <param name="oldList">The old list.</param>
        /// <param name="newList">The new list.</param>
        /// <param name="topLevel"> 
        /// If true then the nodes are equivalent if the contained nodes and tokens declaring
        /// metadata visible symbolic information are equivalent, ignoring any differences of nodes inside method bodies
        /// or initializer expressions, otherwise all nodes and tokens must be equivalent. 
        /// </param>
        public bool AreEquivalent<TNode>(SyntaxList<TNode> oldList, SyntaxList<TNode> newList)
            where TNode : SyntaxNode
        {
            return SyntaxEquivalence.AreEquivalent(oldList.Node, newList.Node, null);
        }

        /// <summary>
        /// Determines if two lists of syntax nodes are the same, disregarding trivia differences.
        /// </summary>
        /// <param name="oldList">The old list.</param>
        /// <param name="newList">The new list.</param>
        /// <param name="ignoreChildNode">
        /// If specified called for every child syntax node (not token) that is visited during the comparison. 
        /// If it returns true the child is recursively visited, otherwise the child and its subtree is disregarded.
        /// </param>
        public bool AreEquivalent<TNode>(SyntaxList<TNode> oldList, SyntaxList<TNode> newList, Func<int, bool> ignoreChildNode = null)
            where TNode : SyntaxNode
        {
            return SyntaxEquivalence.AreEquivalent(oldList.Node, newList.Node, ignoreChildNode);
        }

        /// <summary>
        /// Determines if two lists of syntax nodes are the same, disregarding trivia differences.
        /// </summary>
        /// <param name="oldList">The old list.</param>
        /// <param name="newList">The new list.</param>
        /// <param name="topLevel"> 
        /// If true then the nodes are equivalent if the contained nodes and tokens declaring
        /// metadata visible symbolic information are equivalent, ignoring any differences of nodes inside method bodies
        /// or initializer expressions, otherwise all nodes and tokens must be equivalent. 
        /// </param>
        public bool AreEquivalent<TNode>(SeparatedSyntaxList<TNode> oldList, SeparatedSyntaxList<TNode> newList)
        where TNode : SyntaxNode
        {
            return SyntaxEquivalence.AreEquivalent(oldList.Node, newList.Node, null);
        }

        /// <summary>
        /// Determines if two lists of syntax nodes are the same, disregarding trivia differences.
        /// </summary>
        /// <param name="oldList">The old list.</param>
        /// <param name="newList">The new list.</param>
        /// <param name="ignoreChildNode">
        /// If specified called for every child syntax node (not token) that is visited during the comparison. 
        /// If it returns true the child is recursively visited, otherwise the child and its subtree is disregarded.
        /// </param>
        public bool AreEquivalent<TNode>(SeparatedSyntaxList<TNode> oldList, SeparatedSyntaxList<TNode> newList, Func<int, bool> ignoreChildNode = null)
            where TNode : SyntaxNode
        {
            return SyntaxEquivalence.AreEquivalent(oldList.Node, newList.Node, ignoreChildNode);
        }

        public TNode Normalize<TNode>(TNode node, string indentWhitespace, string eolWhitespace, bool useElasticTrivia = false)
            where TNode : SyntaxNode
        {
            var normalizer = this.Normalizer(node.FullSpan, GetDeclarationDepth(node), indentWhitespace, eolWhitespace, useElasticTrivia);
            var result = (TNode)normalizer.Visit(node);
            normalizer.Free();
            return result;
        }

        public SyntaxToken Normalize(SyntaxToken token, string indentWhitespace, string eolWhitespace, bool useElasticTrivia = false)
        {
            var normalizer = this.Normalizer(token.FullSpan, GetDeclarationDepth(token), indentWhitespace, eolWhitespace, useElasticTrivia);
            var result = normalizer.VisitToken(token);
            normalizer.Free();
            return result;
        }

        public SyntaxTriviaList Normalize(SyntaxTriviaList trivia, string indentWhitespace, string eolWhitespace, bool useElasticTrivia = false)
        {
            var normalizer = this.Normalizer(trivia.FullSpan, GetDeclarationDepth(trivia.Token), indentWhitespace, eolWhitespace, useElasticTrivia);
            var result = normalizer.RewriteTrivia(
                trivia,
                GetDeclarationDepth((SyntaxToken)trivia.ElementAt(0).Token),
                isTrailing: false,
                indentAfterLineBreak: false,
                mustHaveSeparator: false,
                lineBreaksAfter: 0);
            normalizer.Free();
            return result;
        }

        public virtual int GetDeclarationDepth(SyntaxToken token)
        {
            return GetDeclarationDepth(token.Parent);
        }

        public virtual int GetDeclarationDepth(SyntaxTrivia trivia)
        {
            if (Language.SyntaxFacts.IsPreprocessorDirective(trivia.RawKind))
            {
                return 0;
            }

            return GetDeclarationDepth((SyntaxToken)trivia.Token);
        }

        public virtual int GetDeclarationDepth(SyntaxNode node)
        {
            if (node != null)
            {
                if (node.IsStructuredTrivia)
                {
                    var tr = ((IStructuredTriviaSyntax)node).ParentTrivia;
                    return GetDeclarationDepth(tr);
                }
                else if (node.Parent != null)
                {
                    return GetDeclarationDepth(node.Parent);
                }
            }
            return 0;
        }
        /*

/// <summary>
/// Creates a trivia with kind DisabledTextTrivia. Disabled text corresponds to any text between directives that
/// is not considered active.
/// </summary>
public SyntaxTrivia DisabledText(string text)
{
return InternalSyntaxFactory.DisabledText(text);
}

/// <summary>
/// Trivia nodes represent parts of the program text that are not parts of the
/// syntactic grammar, such as spaces, newlines, comments, preprocessor
/// directives, and disabled code.
/// </summary>
/// <param name="kind">
/// A <see cref="SyntaxKind"/> representing the specific kind of <see cref="SyntaxTrivia"/>. One of
/// <see cref="SyntaxKind.WhitespaceTrivia"/>, <see cref="SyntaxKind.EndOfLineTrivia"/>,
/// <see cref="SyntaxKind.SingleLineCommentTrivia"/>, <see cref="SyntaxKind.MultiLineCommentTrivia"/>,
/// <see cref="SyntaxKind.DocumentationCommentExteriorTrivia"/>, <see cref="SyntaxKind.DisabledTextTrivia"/>
/// </param>
/// <param name="text">
/// The actual text of this token.
/// </param>
public SyntaxTrivia SyntaxTrivia(SyntaxKind kind, string text)
{
if (text == null)
{
throw new ArgumentNullException(nameof(text));
}

switch (kind)
{
case SyntaxKind.DisabledTextTrivia:
case SyntaxKind.DocumentationCommentExteriorTrivia:
case SyntaxKind.EndOfLineTrivia:
case SyntaxKind.MultiLineCommentTrivia:
case SyntaxKind.SingleLineCommentTrivia:
case SyntaxKind.WhitespaceTrivia:
return new SyntaxTrivia(default(SyntaxToken), new Syntax.InternalSyntax.SyntaxTrivia(kind, text, null, null), 0, 0);
default:
throw new ArgumentException("kind");
}
}

/// <summary>
/// Creates a token corresponding to a syntax kind. This method can be used for token syntax kinds whose text
/// can be inferred by the kind alone.
/// </summary>
/// <param name="kind">A syntax kind value for a token. These have the suffix Token or Keyword.</param>
/// <returns></returns>
public SyntaxToken Token(SyntaxKind kind)
{
return new SyntaxToken(InternalSyntaxFactory.Token(ElasticMarker.UnderlyingNode, kind, ElasticMarker.UnderlyingNode));
}

/// <summary>
/// Creates a token corresponding to syntax kind. This method can be used for token syntax kinds whose text can
/// be inferred by the kind alone.
/// </summary>
/// <param name="leading">A list of trivia immediately preceding the token.</param>
/// <param name="kind">A syntax kind value for a token. These have the suffix Token or Keyword.</param>
/// <param name="trailing">A list of trivia immediately following the token.</param>
public SyntaxToken Token(SyntaxTriviaList leading, SyntaxKind kind, SyntaxTriviaList trailing)
{
return new SyntaxToken(InternalSyntaxFactory.Token(leading.Node, kind, trailing.Node));
}

/// <summary>
/// Creates a token corresponding to syntax kind. This method gives control over token Text and ValueText.
/// 
/// For example, consider the text '&lt;see cref="operator &amp;#43;"/&gt;'.  To create a token for the value of
/// the operator symbol (&amp;#43;), one would call 
/// Token(default(SyntaxTriviaList), SyntaxKind.PlusToken, "&amp;#43;", "+", default(SyntaxTriviaList)).
/// </summary>
/// <param name="leading">A list of trivia immediately preceding the token.</param>
/// <param name="kind">A syntax kind value for a token. These have the suffix Token or Keyword.</param>
/// <param name="text">The text from which this token was created (e.g. lexed).</param>
/// <param name="valueText">How C# should interpret the text of this token.</param>
/// <param name="trailing">A list of trivia immediately following the token.</param>
public SyntaxToken Token(SyntaxTriviaList leading, SyntaxKind kind, string text, string valueText, SyntaxTriviaList trailing)
{
switch (kind)
{
case SyntaxKind.IdentifierToken:
// Have a different representation.
throw new ArgumentException(CSharpResources.UseVerbatimIdentifier, nameof(kind));
case SyntaxKind.CharacterLiteralToken:
// Value should not have type string.
throw new ArgumentException(CSharpResources.UseLiteralForTokens, nameof(kind));
case SyntaxKind.NumericLiteralToken:
// Value should not have type string.
throw new ArgumentException(CSharpResources.UseLiteralForNumeric, nameof(kind));
}

if (!SyntaxFacts.IsAnyToken(kind))
{
throw new ArgumentException(string.Format(CSharpResources.ThisMethodCanOnlyBeUsedToCreateTokens, kind), nameof(kind));
}

return new SyntaxToken(InternalSyntaxFactory.Token(leading.Node, kind, text, valueText, trailing.Node));
}

/// <summary>
/// Creates a missing token corresponding to syntax kind. A missing token is produced by the parser when an
/// expected token is not found. A missing token has no text and normally has associated diagnostics.
/// </summary>
/// <param name="kind">A syntax kind value for a token. These have the suffix Token or Keyword.</param>
public SyntaxToken MissingToken(SyntaxKind kind)
{
return new SyntaxToken(InternalSyntaxFactory.MissingToken(ElasticMarker.UnderlyingNode, kind, ElasticMarker.UnderlyingNode));
}

/// <summary>
/// Creates a missing token corresponding to syntax kind. A missing token is produced by the parser when an
/// expected token is not found. A missing token has no text and normally has associated diagnostics.
/// </summary>
/// <param name="leading">A list of trivia immediately preceding the token.</param>
/// <param name="kind">A syntax kind value for a token. These have the suffix Token or Keyword.</param>
/// <param name="trailing">A list of trivia immediately following the token.</param>
public SyntaxToken MissingToken(SyntaxTriviaList leading, SyntaxKind kind, SyntaxTriviaList trailing)
{
return new SyntaxToken(InternalSyntaxFactory.MissingToken(leading.Node, kind, trailing.Node));
}

/// <summary>
/// Creates a token with kind IdentifierToken containing the specified text.
/// <param name="text">The raw text of the identifier name, including any escapes or leading '@'
/// character.</param>
/// </summary>
public SyntaxToken Identifier(string text)
{
return new SyntaxToken(InternalSyntaxFactory.Identifier(ElasticMarker.UnderlyingNode, text, ElasticMarker.UnderlyingNode));
}

/// <summary>
/// Creates a token with kind IdentifierToken containing the specified text.
/// </summary>
/// <param name="leading">A list of trivia immediately preceding the token.</param>
/// <param name="text">The raw text of the identifier name, including any escapes or leading '@'
/// character.</param>
/// <param name="trailing">A list of trivia immediately following the token.</param>
public SyntaxToken Identifier(SyntaxTriviaList leading, string text, SyntaxTriviaList trailing)
{
return new SyntaxToken(InternalSyntaxFactory.Identifier(leading.Node, text, trailing.Node));
}

/// <summary>
/// Creates a token with kind IdentifierToken containing the specified text.
/// </summary>
/// <param name="leading">A list of trivia immediately preceding the token.</param>
/// <param name="contextualKind">An alternative SyntaxKind that can be inferred for this token in special
/// contexts. These are usually keywords.</param>
/// <param name="text">The raw text of the identifier name, including any escapes or leading '@'
/// character.</param>
/// <param name="valueText">The text of the identifier name without escapes or leading '@' character.</param>
/// <param name="trailing">A list of trivia immediately following the token.</param>
/// <returns></returns>
public SyntaxToken Identifier(SyntaxTriviaList leading, SyntaxKind contextualKind, string text, string valueText, SyntaxTriviaList trailing)
{
return new SyntaxToken(InternalSyntax.LanguageSyntaxFactory.Identifier(contextualKind, leading.Node, text, valueText, trailing.Node));
}

/// <summary>
/// Creates a token with kind NumericLiteralToken from a 4-byte signed integer value.
/// </summary>
/// <param name="value">The 4-byte signed integer value to be represented by the returned token.</param>
public SyntaxToken Literal(int value)
{
return Literal(ObjectDisplay.FormatLiteral(value, ObjectDisplayOptions.None), value);
}

/// <summary>
/// Creates a token with kind NumericLiteralToken from the text and corresponding 4-byte signed integer value.
/// </summary>
/// <param name="text">The raw text of the literal.</param>
/// <param name="value">The 4-byte signed integer value to be represented by the returned token.</param>
public SyntaxToken Literal(string text, int value)
{
return new SyntaxToken(InternalSyntaxFactory.Literal(ElasticMarker.UnderlyingNode, text, value, ElasticMarker.UnderlyingNode));
}

/// <summary>
/// Creates a token with kind NumericLiteralToken from the text and corresponding 4-byte signed integer value.
/// </summary>
/// <param name="leading">A list of trivia immediately preceding the token.</param>
/// <param name="text">The raw text of the literal.</param>
/// <param name="value">The 4-byte signed integer value to be represented by the returned token.</param>
/// <param name="trailing">A list of trivia immediately following the token.</param>
public SyntaxToken Literal(SyntaxTriviaList leading, string text, int value, SyntaxTriviaList trailing)
{
return new SyntaxToken(InternalSyntaxFactory.Literal(leading.Node, text, value, trailing.Node));
}

/// <summary>
/// Creates a token with kind NumericLiteralToken from a 4-byte unsigned integer value.
/// </summary>
/// <param name="value">The 4-byte unsigned integer value to be represented by the returned token.</param>
public SyntaxToken Literal(uint value)
{
return Literal(ObjectDisplay.FormatLiteral(value, ObjectDisplayOptions.IncludeTypeSuffix), value);
}

/// <summary>
/// Creates a token with kind NumericLiteralToken from the text and corresponding 4-byte unsigned integer value.
/// </summary>
/// <param name="text">The raw text of the literal.</param>
/// <param name="value">The 4-byte unsigned integer value to be represented by the returned token.</param>
public SyntaxToken Literal(string text, uint value)
{
return new SyntaxToken(InternalSyntaxFactory.Literal(ElasticMarker.UnderlyingNode, text, value, ElasticMarker.UnderlyingNode));
}

/// <summary>
/// Creates a token with kind NumericLiteralToken from the text and corresponding 4-byte unsigned integer value.
/// </summary>
/// <param name="leading">A list of trivia immediately preceding the token.</param>
/// <param name="text">The raw text of the literal.</param>
/// <param name="value">The 4-byte unsigned integer value to be represented by the returned token.</param>
/// <param name="trailing">A list of trivia immediately following the token.</param>
public SyntaxToken Literal(SyntaxTriviaList leading, string text, uint value, SyntaxTriviaList trailing)
{
return new SyntaxToken(InternalSyntaxFactory.Literal(leading.Node, text, value, trailing.Node));
}

/// <summary>
/// Creates a token with kind NumericLiteralToken from an 8-byte signed integer value.
/// </summary>
/// <param name="value">The 8-byte signed integer value to be represented by the returned token.</param>
public SyntaxToken Literal(long value)
{
return Literal(ObjectDisplay.FormatLiteral(value, ObjectDisplayOptions.IncludeTypeSuffix), value);
}

/// <summary>
/// Creates a token with kind NumericLiteralToken from the text and corresponding 8-byte signed integer value.
/// </summary>
/// <param name="text">The raw text of the literal.</param>
/// <param name="value">The 8-byte signed integer value to be represented by the returned token.</param>
public SyntaxToken Literal(string text, long value)
{
return new SyntaxToken(InternalSyntaxFactory.Literal(ElasticMarker.UnderlyingNode, text, value, ElasticMarker.UnderlyingNode));
}

/// <summary>
/// Creates a token with kind NumericLiteralToken from the text and corresponding 8-byte signed integer value.
/// </summary>
/// <param name="leading">A list of trivia immediately preceding the token.</param>
/// <param name="text">The raw text of the literal.</param>
/// <param name="value">The 8-byte signed integer value to be represented by the returned token.</param>
/// <param name="trailing">A list of trivia immediately following the token.</param>
public SyntaxToken Literal(SyntaxTriviaList leading, string text, long value, SyntaxTriviaList trailing)
{
return new SyntaxToken(InternalSyntaxFactory.Literal(leading.Node, text, value, trailing.Node));
}

/// <summary>
/// Creates a token with kind NumericLiteralToken from an 8-byte unsigned integer value.
/// </summary>
/// <param name="value">The 8-byte unsigned integer value to be represented by the returned token.</param>
public SyntaxToken Literal(ulong value)
{
return Literal(ObjectDisplay.FormatLiteral(value, ObjectDisplayOptions.IncludeTypeSuffix), value);
}

/// <summary>
/// Creates a token with kind NumericLiteralToken from the text and corresponding 8-byte unsigned integer value.
/// </summary>
/// <param name="text">The raw text of the literal.</param>
/// <param name="value">The 8-byte unsigned integer value to be represented by the returned token.</param>
public SyntaxToken Literal(string text, ulong value)
{
return new SyntaxToken(InternalSyntaxFactory.Literal(ElasticMarker.UnderlyingNode, text, value, ElasticMarker.UnderlyingNode));
}

/// <summary>
/// Creates a token with kind NumericLiteralToken from the text and corresponding 8-byte unsigned integer value.
/// </summary>
/// <param name="leading">A list of trivia immediately preceding the token.</param>
/// <param name="text">The raw text of the literal.</param>
/// <param name="value">The 8-byte unsigned integer value to be represented by the returned token.</param>
/// <param name="trailing">A list of trivia immediately following the token.</param>
public SyntaxToken Literal(SyntaxTriviaList leading, string text, ulong value, SyntaxTriviaList trailing)
{
return new SyntaxToken(InternalSyntaxFactory.Literal(leading.Node, text, value, trailing.Node));
}

/// <summary>
/// Creates a token with kind NumericLiteralToken from a 4-byte floating point value.
/// </summary>
/// <param name="value">The 4-byte floating point value to be represented by the returned token.</param>
public SyntaxToken Literal(float value)
{
return Literal(ObjectDisplay.FormatLiteral(value, ObjectDisplayOptions.IncludeTypeSuffix), value);
}

/// <summary>
/// Creates a token with kind NumericLiteralToken from the text and corresponding 4-byte floating point value.
/// </summary>
/// <param name="text">The raw text of the literal.</param>
/// <param name="value">The 4-byte floating point value to be represented by the returned token.</param>
public SyntaxToken Literal(string text, float value)
{
return new SyntaxToken(InternalSyntaxFactory.Literal(ElasticMarker.UnderlyingNode, text, value, ElasticMarker.UnderlyingNode));
}

/// <summary>
/// Creates a token with kind NumericLiteralToken from the text and corresponding 4-byte floating point value.
/// </summary>
/// <param name="leading">A list of trivia immediately preceding the token.</param>
/// <param name="text">The raw text of the literal.</param>
/// <param name="value">The 4-byte floating point value to be represented by the returned token.</param>
/// <param name="trailing">A list of trivia immediately following the token.</param>
public SyntaxToken Literal(SyntaxTriviaList leading, string text, float value, SyntaxTriviaList trailing)
{
return new SyntaxToken(InternalSyntaxFactory.Literal(leading.Node, text, value, trailing.Node));
}

/// <summary>
/// Creates a token with kind NumericLiteralToken from an 8-byte floating point value.
/// </summary>
/// <param name="value">The 8-byte floating point value to be represented by the returned token.</param>
public SyntaxToken Literal(double value)
{
return Literal(ObjectDisplay.FormatLiteral(value, ObjectDisplayOptions.None), value);
}

/// <summary>
/// Creates a token with kind NumericLiteralToken from the text and corresponding 8-byte floating point value.
/// </summary>
/// <param name="text">The raw text of the literal.</param>
/// <param name="value">The 8-byte floating point value to be represented by the returned token.</param>
public SyntaxToken Literal(string text, double value)
{
return new SyntaxToken(InternalSyntaxFactory.Literal(ElasticMarker.UnderlyingNode, text, value, ElasticMarker.UnderlyingNode));
}

/// <summary>
/// Creates a token with kind NumericLiteralToken from the text and corresponding 8-byte floating point value.
/// </summary>
/// <param name="leading">A list of trivia immediately preceding the token.</param>
/// <param name="text">The raw text of the literal.</param>
/// <param name="value">The 8-byte floating point value to be represented by the returned token.</param>
/// <param name="trailing">A list of trivia immediately following the token.</param>
public SyntaxToken Literal(SyntaxTriviaList leading, string text, double value, SyntaxTriviaList trailing)
{
return new SyntaxToken(InternalSyntaxFactory.Literal(leading.Node, text, value, trailing.Node));
}

/// <summary>
/// Creates a token with kind NumericLiteralToken from a decimal value.
/// </summary>
/// <param name="value">The decimal value to be represented by the returned token.</param>
public SyntaxToken Literal(decimal value)
{
return Literal(ObjectDisplay.FormatLiteral(value, ObjectDisplayOptions.IncludeTypeSuffix), value);
}

/// <summary>
/// Creates a token with kind NumericLiteralToken from the text and corresponding decimal value.
/// </summary>
/// <param name="text">The raw text of the literal.</param>
/// <param name="value">The decimal value to be represented by the returned token.</param>
public SyntaxToken Literal(string text, decimal value)
{
return new SyntaxToken(InternalSyntaxFactory.Literal(ElasticMarker.UnderlyingNode, text, value, ElasticMarker.UnderlyingNode));
}

/// <summary>
/// Creates a token with kind NumericLiteralToken from the text and corresponding decimal value.
/// </summary>
/// <param name="leading">A list of trivia immediately preceding the token.</param>
/// <param name="text">The raw text of the literal.</param>
/// <param name="value">The decimal value to be represented by the returned token.</param>
/// <param name="trailing">A list of trivia immediately following the token.</param>
public SyntaxToken Literal(SyntaxTriviaList leading, string text, decimal value, SyntaxTriviaList trailing)
{
return new SyntaxToken(InternalSyntaxFactory.Literal(leading.Node, text, value, trailing.Node));
}

/// <summary>
/// Creates a token with kind StringLiteralToken from a string value.
/// </summary>
/// <param name="value">The string value to be represented by the returned token.</param>
public SyntaxToken Literal(string value)
{
return Literal(SymbolDisplay.FormatLiteral(value, quote: true), value);
}

/// <summary>
/// Creates a token with kind StringLiteralToken from the text and corresponding string value.
/// </summary>
/// <param name="text">The raw text of the literal, including quotes and escape sequences.</param>
/// <param name="value">The string value to be represented by the returned token.</param>
public SyntaxToken Literal(string text, string value)
{
return new SyntaxToken(InternalSyntaxFactory.Literal(ElasticMarker.UnderlyingNode, text, value, ElasticMarker.UnderlyingNode));
}

/// <summary>
/// Creates a token with kind StringLiteralToken from the text and corresponding string value.
/// </summary>
/// <param name="leading">A list of trivia immediately preceding the token.</param>
/// <param name="text">The raw text of the literal, including quotes and escape sequences.</param>
/// <param name="value">The string value to be represented by the returned token.</param>
/// <param name="trailing">A list of trivia immediately following the token.</param>
public SyntaxToken Literal(SyntaxTriviaList leading, string text, string value, SyntaxTriviaList trailing)
{
return new SyntaxToken(InternalSyntaxFactory.Literal(leading.Node, text, value, trailing.Node));
}

/// <summary>
/// Creates a token with kind CharacterLiteralToken from a character value.
/// </summary>
/// <param name="value">The character value to be represented by the returned token.</param>
public SyntaxToken Literal(char value)
{
return Literal(ObjectDisplay.FormatLiteral(value, ObjectDisplayOptions.UseQuotes | ObjectDisplayOptions.EscapeNonPrintableCharacters), value);
}

/// <summary>
/// Creates a token with kind CharacterLiteralToken from the text and corresponding character value.
/// </summary>
/// <param name="text">The raw text of the literal, including quotes and escape sequences.</param>
/// <param name="value">The character value to be represented by the returned token.</param>
public SyntaxToken Literal(string text, char value)
{
return new SyntaxToken(InternalSyntaxFactory.Literal(ElasticMarker.UnderlyingNode, text, value, ElasticMarker.UnderlyingNode));
}

/// <summary>
/// Creates a token with kind CharacterLiteralToken from the text and corresponding character value.
/// </summary>
/// <param name="leading">A list of trivia immediately preceding the token.</param>
/// <param name="text">The raw text of the literal, including quotes and escape sequences.</param>
/// <param name="value">The character value to be represented by the returned token.</param>
/// <param name="trailing">A list of trivia immediately following the token.</param>
public SyntaxToken Literal(SyntaxTriviaList leading, string text, char value, SyntaxTriviaList trailing)
{
return new SyntaxToken(InternalSyntaxFactory.Literal(leading.Node, text, value, trailing.Node));
}

/// <summary>
/// Creates a token with kind BadToken.
/// </summary>
/// <param name="leading">A list of trivia immediately preceding the token.</param>
/// <param name="text">The raw text of the bad token.</param>
/// <param name="trailing">A list of trivia immediately following the token.</param>
public SyntaxToken BadToken(SyntaxTriviaList leading, string text, SyntaxTriviaList trailing)
{
return new SyntaxToken(InternalSyntaxFactory.BadToken(leading.Node, text, trailing.Node));
}

// direct access to parsing for common grammar areas

/// <summary>
/// Create a new syntax tree from a syntax node.
/// </summary>
public SyntaxTree SyntaxTree(SyntaxNode root, ParseOptions options = null, string path = "", Encoding encoding = null)
{
return CSharpSyntaxTree.Create((CSharpSyntaxNode)root, (CSharpParseOptions)options, path, encoding);
}

/// <summary>
/// Produces a syntax tree by parsing the source text.
/// </summary>
public SyntaxTree ParseSyntaxTree(
string text,
ParseOptions options = null,
string path = "",
Encoding encoding = null,
CancellationToken cancellationToken = default(CancellationToken))
{
return ParseSyntaxTree(SourceText.From(text, encoding), options, path, cancellationToken);
}

/// <summary>
/// Produces a syntax tree by parsing the source text.
/// </summary>
public SyntaxTree ParseSyntaxTree(
SourceText text,
ParseOptions options = null,
string path = "",
CancellationToken cancellationToken = default(CancellationToken))
{
return CSharpSyntaxTree.ParseText(text, (CSharpParseOptions)options, path, cancellationToken);
}

/// <summary>
/// Helper method for wrapping a string in an SourceText.
/// </summary>
private SourceText MakeSourceText(string text, int offset)
{
return SourceText.From(text, Encoding.UTF8).GetSubText(offset);
}

private InternalSyntax.SyntaxParser MakeParser(string text, int offset, CSharpParseOptions options = null)
{
return new InternalSyntax.Lexer(
text: MakeSourceText(text, offset),
options: options ?? CSharpParseOptions.Default);
}

private InternalSyntax.SyntaxParser MakeParser(string text)
{
return new InternalSyntax.LanguageParser(lexer, oldTree: null, changes: null);
}


/// <summary>
/// Determines whether the given text is considered a syntactically complete submission.
/// Throws <see cref="ArgumentException"/> if the tree was not compiled as an interactive submission.
/// </summary>
public bool IsCompleteSubmission(SyntaxTree tree)
{
if (tree == null)
{
throw new ArgumentNullException(nameof(tree));
}
if (tree.Options.Kind != SourceCodeKind.Script)
{
throw new ArgumentException(CSharpResources.SyntaxTreeIsNotASubmission);
}

if (!tree.HasCompilationUnitRoot)
{
return false;
}

var compilation = (CompilationUnitSyntax)tree.GetRoot();
if (!compilation.HasErrors)
{
return true;
}

foreach (var error in compilation.EndOfFileToken.GetDiagnostics())
{
switch ((ErrorCode)error.Code)
{
case ErrorCode.ERR_OpenEndedComment:
case ErrorCode.ERR_EndifDirectiveExpected:
case ErrorCode.ERR_EndRegionDirectiveExpected:
return false;
}
}

var lastNode = compilation.ChildNodes().LastOrDefault();
if (lastNode == null)
{
return true;
}

// unterminated multi-line comment:
if (lastNode.HasTrailingTrivia && lastNode.ContainsDiagnostics && HasUnterminatedMultiLineComment(lastNode.GetTrailingTrivia()))
{
return false;
}

if (lastNode.IsKind(SyntaxKind.IncompleteMember))
{
return false;
}

// All top-level constructs but global statement (i.e. extern alias, using directive, global attribute, and declarations)
// should have a closing token (semicolon, closing brace or bracket) to be complete.
if (!lastNode.IsKind(SyntaxKind.GlobalStatement))
{
var closingToken = lastNode.GetLastToken(includeZeroWidth: true, includeSkipped: true, includeDirectives: true, includeDocumentationComments: true);
return !closingToken.IsMissing;
}

var globalStatement = (GlobalStatementSyntax)lastNode;
var token = lastNode.GetLastToken(includeZeroWidth: true, includeSkipped: true, includeDirectives: true, includeDocumentationComments: true);

if (token.IsMissing)
{
// expression statement terminating semicolon might be missing in script code:
if (tree.Options.Kind == SourceCodeKind.Regular ||
!globalStatement.Statement.IsKind(SyntaxKind.ExpressionStatement) ||
!token.IsKind(SyntaxKind.SemicolonToken))
{
return false;
}

token = token.GetPreviousToken(predicate: SyntaxToken.Any, stepInto: CodeAnalysis.SyntaxTrivia.Any);
if (token.IsMissing)
{
return false;
}
}

foreach (var error in token.GetDiagnostics())
{
switch ((ErrorCode)error.Code)
{
// unterminated character or string literal:
case ErrorCode.ERR_NewlineInConst:

// unterminated verbatim string literal:
case ErrorCode.ERR_UnterminatedStringLit:

// unexpected token following a global statement:
case ErrorCode.ERR_GlobalDefinitionOrStatementExpected:
case ErrorCode.ERR_EOFExpected:
return false;
}
}

return true;
}

private bool HasUnterminatedMultiLineComment(SyntaxTriviaList triviaList)
{
foreach (var trivia in triviaList)
{
if (trivia.ContainsDiagnostics && trivia.Kind() == SyntaxKind.MultiLineCommentTrivia)
{
return true;
}
}

return false;
}
*/
    }
}
