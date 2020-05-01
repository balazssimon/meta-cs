// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using InternalSyntax = MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using System.Xml.Linq;
using Roslyn.Utilities;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Syntax;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Text;
using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;

namespace MetaDslx.CodeAnalysis.Syntax
{
    /// <summary>
    /// A class containing factory methods for constructing syntax nodes, tokens and trivia.
    /// </summary>
    public abstract class SyntaxFactory
    {
        private SyntaxToken _endOfFile;
        private SyntaxToken _defaultSeparator;

        protected SyntaxFactory(InternalSyntaxFactory internalSyntaxFactory)
        {
            CarriageReturnLineFeed = internalSyntaxFactory.CarriageReturnLineFeed;
            LineFeed = internalSyntaxFactory.LineFeed;
            CarriageReturn = internalSyntaxFactory.CarriageReturn;
            Space = internalSyntaxFactory.Space;
            Tab = internalSyntaxFactory.Tab;

            ElasticCarriageReturnLineFeed = internalSyntaxFactory.ElasticCarriageReturnLineFeed;
            ElasticLineFeed = internalSyntaxFactory.ElasticLineFeed;
            ElasticCarriageReturn = internalSyntaxFactory.ElasticCarriageReturn;
            ElasticSpace = internalSyntaxFactory.ElasticSpace;
            ElasticTab = internalSyntaxFactory.ElasticTab;

            ElasticMarker = internalSyntaxFactory.ElasticZeroSpace;
        }

        public Language Language => this.LanguageCore;
        protected abstract Language LanguageCore { get; }
        public SyntaxToken EndOfFile
        {
            get
            {
                if ((object)_endOfFile.Node == null)
                {
                    _endOfFile = new SyntaxToken(Language.InternalSyntaxFactory.EndOfFile);
                }
                return _endOfFile;
            }
        }
        public SyntaxToken DefaultSeparator
        {
            get
            {
                if ((object)_defaultSeparator.Node == null)
                {
                    _defaultSeparator = new SyntaxToken(Language.InternalSyntaxFactory.DefaultSeparator);
                }
                return _defaultSeparator;
            }
        }
        public abstract SyntaxNode CreateStructure(SyntaxTrivia trivia);

        /// <summary>
        /// A trivia with kind EndOfLineTrivia containing both the carriage return and line feed characters.
        /// </summary>
        public SyntaxTrivia CarriageReturnLineFeed { get; }

        /// <summary>
        /// A trivia with kind EndOfLineTrivia containing a single line feed character.
        /// </summary>
        public SyntaxTrivia LineFeed { get; } 

        /// <summary>
        /// A trivia with kind EndOfLineTrivia containing a single carriage return character.
        /// </summary>
        public SyntaxTrivia CarriageReturn { get; }

        /// <summary>
        ///  A trivia with kind WhitespaceTrivia containing a single space character.
        /// </summary>
        public SyntaxTrivia Space { get; }

        /// <summary>
        /// A trivia with kind WhitespaceTrivia containing a single tab character.
        /// </summary>
        public SyntaxTrivia Tab { get; } 

        /// <summary>
        /// An elastic trivia with kind EndOfLineTrivia containing both the carriage return and line feed characters.
        /// Elastic trivia are used to denote trivia that was not produced by parsing source text, and are usually not
        /// preserved during formatting.
        /// </summary>
        public SyntaxTrivia ElasticCarriageReturnLineFeed { get; } 

        /// <summary>
        /// An elastic trivia with kind EndOfLineTrivia containing a single line feed character. Elastic trivia are used
        /// to denote trivia that was not produced by parsing source text, and are usually not preserved during
        /// formatting.
        /// </summary>
        public SyntaxTrivia ElasticLineFeed { get; } 

        /// <summary>
        /// An elastic trivia with kind EndOfLineTrivia containing a single carriage return character. Elastic trivia
        /// are used to denote trivia that was not produced by parsing source text, and are usually not preserved during
        /// formatting.
        /// </summary>
        public SyntaxTrivia ElasticCarriageReturn { get; } 

        /// <summary>
        /// An elastic trivia with kind WhitespaceTrivia containing a single space character. Elastic trivia are used to
        /// denote trivia that was not produced by parsing source text, and are usually not preserved during formatting.
        /// </summary>
        public SyntaxTrivia ElasticSpace { get; } 

        /// <summary>
        /// An elastic trivia with kind WhitespaceTrivia containing a single tab character. Elastic trivia are used to
        /// denote trivia that was not produced by parsing source text, and are usually not preserved during formatting.
        /// </summary>
        public SyntaxTrivia ElasticTab { get; } 

        /// <summary>
        /// An elastic trivia with kind WhitespaceTrivia containing no characters. Elastic marker trivia are included
        /// automatically by factory methods when trivia is not specified. Syntax formatting will replace elastic
        /// markers with appropriate trivia.
        /// </summary>
        public SyntaxTrivia ElasticMarker { get; } 

        /// <summary>
        /// Creates a trivia with kind EndOfLineTrivia containing the specified text. 
        /// </summary>
        /// <param name="text">The text of the end of line. Any text can be specified here, however only carriage return and
        /// line feed characters are recognized by the parser as end of line.</param>
        public virtual SyntaxTrivia EndOfLine(string text)
        {
            return Language.InternalSyntaxFactory.EndOfLine(text, elastic: false);
        }

        /// <summary>
        /// Creates a trivia with kind EndOfLineTrivia containing the specified text. Elastic trivia are used to
        /// denote trivia that was not produced by parsing source text, and are usually not preserved during formatting.
        /// </summary>
        /// <param name="text">The text of the end of line. Any text can be specified here, however only carriage return and
        /// line feed characters are recognized by the parser as end of line.</param>
        public virtual SyntaxTrivia ElasticEndOfLine(string text)
        {
            return Language.InternalSyntaxFactory.EndOfLine(text, elastic: true);
        }

        [Obsolete("Use SyntaxFactory.EndOfLine or SyntaxFactory.ElasticEndOfLine")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual SyntaxTrivia EndOfLine(string text, bool elastic)
        {
            return Language.InternalSyntaxFactory.EndOfLine(text, elastic);
        }

        /// <summary>
        /// Creates a trivia with kind WhitespaceTrivia containing the specified text.
        /// </summary>
        /// <param name="text">The text of the whitespace. Any text can be specified here, however only specific
        /// whitespace characters are recognized by the parser.</param>
        public virtual SyntaxTrivia Whitespace(string text)
        {
            return Language.InternalSyntaxFactory.Whitespace(text, elastic: false);
        }

        /// <summary>
        /// Creates a trivia with kind WhitespaceTrivia containing the specified text. Elastic trivia are used to
        /// denote trivia that was not produced by parsing source text, and are usually not preserved during formatting.
        /// </summary>
        /// <param name="text">The text of the whitespace. Any text can be specified here, however only specific
        /// whitespace characters are recognized by the parser.</param>
        public virtual SyntaxTrivia ElasticWhitespace(string text)
        {
            return Language.InternalSyntaxFactory.Whitespace(text, elastic: false);
        }

        [Obsolete("Use SyntaxFactory.Whitespace or SyntaxFactory.ElasticWhitespace")]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual SyntaxTrivia Whitespace(string text, bool elastic)
        {
            return Language.InternalSyntaxFactory.Whitespace(text, elastic);
        }

        /// <summary>
        /// Creates a trivia with kind DisabledTextTrivia. Disabled text corresponds to any text between directives that
        /// is not considered active.
        /// </summary>
        public virtual SyntaxTrivia DisabledText(string text)
        {
            return Language.InternalSyntaxFactory.DisabledText(text);
        }

        /// <summary>
        /// Trivia nodes represent parts of the program text that are not parts of the
        /// syntactic grammar, such as spaces, newlines, comments, preprocessor
        /// directives, and disabled code.
        /// </summary>
        /// <param name="kind">
        /// A <see cref="int"/> representing the specific kind of <see cref="SyntaxTrivia"/>. One of
        /// <see cref="int.WhitespaceTrivia"/>, <see cref="int.EndOfLineTrivia"/>,
        /// <see cref="int.SingleLineCommentTrivia"/>, <see cref="int.MultiLineCommentTrivia"/>,
        /// <see cref="int.DocumentationCommentExteriorTrivia"/>, <see cref="int.DisabledTextTrivia"/>
        /// </param>
        /// <param name="text">
        /// The actual text of this token.
        /// </param>
        public virtual SyntaxTrivia SyntaxTrivia(SyntaxKind kind, string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }
            if (!Language.SyntaxFacts.IsTrivia(kind))
            {
                throw new ArgumentException("kind");
            }
            return new SyntaxTrivia(default(SyntaxToken), Language.InternalSyntaxFactory.Trivia(kind, text), 0, 0);
        }

        /// <summary>
        /// Creates a token corresponding to a syntax kind. This method can be used for token syntax kinds whose text
        /// can be inferred by the kind alone.
        /// </summary>
        /// <param name="kind">A syntax kind value for a token. These have the suffix Token or Keyword.</param>
        /// <returns></returns>
        public virtual SyntaxToken Token(SyntaxKind kind)
        {
            return new SyntaxToken(Language.InternalSyntaxFactory.Token(ElasticMarker.UnderlyingNode, kind, ElasticMarker.UnderlyingNode));
        }

        /// <summary>
        /// Creates a token corresponding to syntax kind. This method can be used for token syntax kinds whose text can
        /// be inferred by the kind alone.
        /// </summary>
        /// <param name="leading">A list of trivia immediately preceding the token.</param>
        /// <param name="kind">A syntax kind value for a token. These have the suffix Token or Keyword.</param>
        /// <param name="trailing">A list of trivia immediately following the token.</param>
        public virtual SyntaxToken Token(SyntaxTriviaList leading, SyntaxKind kind, SyntaxTriviaList trailing)
        {
            return new SyntaxToken(Language.InternalSyntaxFactory.Token(leading.Node, kind, trailing.Node));
        }

        /// <summary>
        /// Creates a token corresponding to syntax kind. This method gives control over token Text and ValueText.
        /// 
        /// For example, consider the text '&lt;see cref="operator &amp;#43;"/&gt;'.  To create a token for the value of
        /// the operator symbol (&amp;#43;), one would call 
        /// Token(default(SyntaxTriviaList), int.PlusToken, "&amp;#43;", "+", default(SyntaxTriviaList)).
        /// </summary>
        /// <param name="leading">A list of trivia immediately preceding the token.</param>
        /// <param name="kind">A syntax kind value for a token. These have the suffix Token or Keyword.</param>
        /// <param name="text">The text from which this token was created (e.g. lexed).</param>
        /// <param name="valueText">How C# should interpret the text of this token.</param>
        /// <param name="trailing">A list of trivia immediately following the token.</param>
        public virtual SyntaxToken Token(SyntaxTriviaList leading, SyntaxKind kind, string text, string valueText, SyntaxTriviaList trailing)
        {
            return new SyntaxToken(Language.InternalSyntaxFactory.Token(leading.Node, kind, text, valueText, trailing.Node));
        }

        /// <summary>
        /// Creates a missing token corresponding to syntax kind. A missing token is produced by the parser when an
        /// expected token is not found. A missing token has no text and normally has associated diagnostics.
        /// </summary>
        /// <param name="kind">A syntax kind value for a token. These have the suffix Token or Keyword.</param>
        public virtual SyntaxToken MissingToken(SyntaxKind kind)
        {
            return new SyntaxToken(Language.InternalSyntaxFactory.MissingToken(ElasticMarker.UnderlyingNode, kind, ElasticMarker.UnderlyingNode));
        }

        /// <summary>
        /// Creates a missing token corresponding to syntax kind. A missing token is produced by the parser when an
        /// expected token is not found. A missing token has no text and normally has associated diagnostics.
        /// </summary>
        /// <param name="leading">A list of trivia immediately preceding the token.</param>
        /// <param name="kind">A syntax kind value for a token. These have the suffix Token or Keyword.</param>
        /// <param name="trailing">A list of trivia immediately following the token.</param>
        public virtual SyntaxToken MissingToken(SyntaxTriviaList leading, SyntaxKind kind, SyntaxTriviaList trailing)
        {
            return new SyntaxToken(Language.InternalSyntaxFactory.MissingToken(leading.Node, kind, trailing.Node));
        }
        
        /// <summary>
        /// Creates a token with kind IdentifierToken containing the specified text.
        /// </summary>
        /// <param name="leading">A list of trivia immediately preceding the token.</param>
        /// <param name="contextualKind">An alternative int that can be inferred for this token in special
        /// contexts. These are usually keywords.</param>
        /// <param name="text">The raw text of the identifier name, including any escapes or leading '@'
        /// character.</param>
        /// <param name="valueText">The text of the identifier name without escapes or leading '@' character.</param>
        /// <param name="trailing">A list of trivia immediately following the token.</param>
        /// <returns></returns>
        public virtual SyntaxToken Identifier(SyntaxTriviaList leading, SyntaxKind contextualKind, string text, string valueText, SyntaxTriviaList trailing)
        {
            return new SyntaxToken(Language.InternalSyntaxFactory.Token(leading.Node, contextualKind, text, valueText, trailing.Node));
        }

        /// <summary>
        /// Creates a token with kind BadToken.
        /// </summary>
        /// <param name="leading">A list of trivia immediately preceding the token.</param>
        /// <param name="text">The raw text of the bad token.</param>
        /// <param name="trailing">A list of trivia immediately following the token.</param>
        public virtual SyntaxToken BadToken(SyntaxTriviaList leading, string text, SyntaxTriviaList trailing)
        {
            return new SyntaxToken(Language.InternalSyntaxFactory.BadToken(leading.Node, text, trailing.Node));
        }

        /// <summary>
        /// Creates an empty list of syntax nodes.
        /// </summary>
        /// <typeparam name="TNode">The specific type of the element nodes.</typeparam>
        public virtual SyntaxList<TNode> List<TNode>() where TNode : SyntaxNode
        {
            return default(SyntaxList<TNode>);
        }

        /// <summary>
        /// Creates a singleton list of syntax nodes.
        /// </summary>
        /// <typeparam name="TNode">The specific type of the element nodes.</typeparam>
        /// <param name="node">The single element node.</param>
        /// <returns></returns>
        public virtual SyntaxList<TNode> SingletonList<TNode>(TNode node) where TNode : SyntaxNode
        {
            return new SyntaxList<TNode>(node);
        }

        /// <summary>
        /// Creates a list of syntax nodes.
        /// </summary>
        /// <typeparam name="TNode">The specific type of the element nodes.</typeparam>
        /// <param name="nodes">A sequence of element nodes.</param>
        public virtual SyntaxList<TNode> List<TNode>(IEnumerable<TNode> nodes) where TNode : SyntaxNode
        {
            return new SyntaxList<TNode>(nodes);
        }

        /// <summary>
        /// Creates an empty list of tokens.
        /// </summary>
        public virtual SyntaxTokenList TokenList()
        {
            return default(SyntaxTokenList);
        }

        /// <summary>
        /// Creates a singleton list of tokens.
        /// </summary>
        /// <param name="token">The single token.</param>
        public virtual SyntaxTokenList TokenList(SyntaxToken token)
        {
            return new SyntaxTokenList(token);
        }

        /// <summary>
        /// Creates a list of tokens.
        /// </summary>
        /// <param name="tokens">An array of tokens.</param>
        public virtual SyntaxTokenList TokenList(params SyntaxToken[] tokens)
        {
            return new SyntaxTokenList(tokens);
        }

        /// <summary>
        /// Creates a list of tokens.
        /// </summary>
        /// <param name="tokens"></param>
        /// <returns></returns>
        public virtual SyntaxTokenList TokenList(IEnumerable<SyntaxToken> tokens)
        {
            return new SyntaxTokenList(tokens);
        }

        /// <summary>
        /// Creates a trivia from a StructuredTriviaSyntax node.
        /// </summary>
        public virtual SyntaxTrivia Trivia(LanguageSyntaxNode node)
        {
            if (!node.IsStructuredTrivia) throw new ArgumentException("The node must be a structured trivia.", nameof(node));
            return new SyntaxTrivia(default(SyntaxToken), node.Green, position: 0, index: 0);
        }

        /// <summary>
        /// Creates an empty list of trivia.
        /// </summary>
        public virtual SyntaxTriviaList TriviaList()
        {
            return default(SyntaxTriviaList);
        }

        /// <summary>
        /// Creates a singleton list of trivia.
        /// </summary>
        /// <param name="trivia">A single trivia.</param>
        public virtual SyntaxTriviaList TriviaList(SyntaxTrivia trivia)
        {
            return new SyntaxTriviaList(trivia);
        }

        /// <summary>
        /// Creates a list of trivia.
        /// </summary>
        /// <param name="trivias">An array of trivia.</param>
        public virtual SyntaxTriviaList TriviaList(params SyntaxTrivia[] trivias)
            => new SyntaxTriviaList(trivias);

        /// <summary>
        /// Creates a list of trivia.
        /// </summary>
        /// <param name="trivias">A sequence of trivia.</param>
        public virtual SyntaxTriviaList TriviaList(IEnumerable<SyntaxTrivia> trivias)
            => new SyntaxTriviaList(trivias);

        /// <summary>
        /// Creates an empty separated list.
        /// </summary>
        /// <typeparam name="TNode">The specific type of the element nodes.</typeparam>
        public virtual SeparatedSyntaxList<TNode> SeparatedList<TNode>() where TNode : SyntaxNode
        {
            return default(SeparatedSyntaxList<TNode>);
        }

        /// <summary>
        /// Creates a singleton separated list.
        /// </summary>
        /// <typeparam name="TNode">The specific type of the element nodes.</typeparam>
        /// <param name="node">A single node.</param>
        public virtual SeparatedSyntaxList<TNode> SingletonSeparatedList<TNode>(TNode node) where TNode : SyntaxNode
        {
            return new SeparatedSyntaxList<TNode>(new SyntaxNodeOrTokenList(node, index: 0));
        }

        public SeparatedSyntaxList<TNode> SeparatedList<TNode>(IEnumerable<TNode> nodes) where TNode : SyntaxNode
        {
            return this.SeparatedList<TNode>(nodes, Language.SyntaxFacts.DefaultSeparatorKind);
        }

        /// <summary>
        /// Creates a separated list of nodes from a sequence of nodes, synthesizing comma separators in between.
        /// </summary>
        /// <typeparam name="TNode">The specific type of the element nodes.</typeparam>
        /// <param name="nodes">A sequence of syntax nodes.</param>
        public virtual SeparatedSyntaxList<TNode> SeparatedList<TNode>(IEnumerable<TNode> nodes, SyntaxKind separatorKind) where TNode : SyntaxNode
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
        public virtual SeparatedSyntaxList<TNode> SeparatedList<TNode>(IEnumerable<TNode> nodes, IEnumerable<SyntaxToken> separators) where TNode : SyntaxNode
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
        public virtual SeparatedSyntaxList<TNode> SeparatedList<TNode>(IEnumerable<SyntaxNodeOrToken> nodesAndTokens) where TNode : SyntaxNode
        {
            return SeparatedList<TNode>(NodeOrTokenList(nodesAndTokens));
        }

        /// <summary>
        /// Creates a separated list from a <see cref="SyntaxNodeOrTokenList"/>, where the list elements start with a node and then alternate between
        /// additional nodes and separator tokens.
        /// </summary>
        /// <typeparam name="TNode">The specific type of the element nodes.</typeparam>
        /// <param name="nodesAndTokens">The list of nodes and tokens.</param>
        public virtual SeparatedSyntaxList<TNode> SeparatedList<TNode>(SyntaxNodeOrTokenList nodesAndTokens) where TNode : SyntaxNode
        {
            if (!HasSeparatedNodeTokenPattern(nodesAndTokens))
            {
                throw new ArgumentException(CodeAnalysisResources.NodeOrTokenOutOfSequence);
            }

            if (!NodesAreCorrectType<TNode>(nodesAndTokens))
            {
                throw new ArgumentException(CodeAnalysisResources.UnexpectedTypeOfNodeInList);
            }

            return new SeparatedSyntaxList<TNode>(nodesAndTokens);
        }

        private static bool NodesAreCorrectType<TNode>(SyntaxNodeOrTokenList list)
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

        private static bool HasSeparatedNodeTokenPattern(SyntaxNodeOrTokenList list)
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
        public virtual SyntaxNodeOrTokenList NodeOrTokenList()
        {
            return default(SyntaxNodeOrTokenList);
        }

        /// <summary>
        /// Create a <see cref="SyntaxNodeOrTokenList"/> from a sequence of <see cref="SyntaxNodeOrToken"/>.
        /// </summary>
        /// <param name="nodesAndTokens">The sequence of nodes and tokens</param>
        public virtual SyntaxNodeOrTokenList NodeOrTokenList(IEnumerable<SyntaxNodeOrToken> nodesAndTokens)
        {
            return new SyntaxNodeOrTokenList(nodesAndTokens);
        }

        /// <summary>
        /// Create a <see cref="SyntaxNodeOrTokenList"/> from one or more <see cref="SyntaxNodeOrToken"/>.
        /// </summary>
        /// <param name="nodesAndTokens">The nodes and tokens</param>
        public virtual SyntaxNodeOrTokenList NodeOrTokenList(params SyntaxNodeOrToken[] nodesAndTokens)
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
        public virtual bool AreEquivalent(SyntaxTree oldTree, SyntaxTree newTree, bool topLevel)
        {
            if (oldTree == null && newTree == null)
            {
                return true;
            }

            if (oldTree == null || newTree == null)
            {
                return false;
            }

            return SyntaxEquivalence.AreEquivalent(oldTree, newTree, ignoreChildNode: null, topLevel: topLevel);
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
        public virtual bool AreEquivalent(SyntaxNode oldNode, SyntaxNode newNode, bool topLevel)
        {
            return SyntaxEquivalence.AreEquivalent(oldNode, newNode, ignoreChildNode: null, topLevel: topLevel);
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
        public virtual bool AreEquivalent(SyntaxNode oldNode, SyntaxNode newNode, Func<int, bool> ignoreChildNode = null)
        {
            return SyntaxEquivalence.AreEquivalent(oldNode, newNode, ignoreChildNode: ignoreChildNode, topLevel: false);
        }

        /// <summary>
        /// Determines if two syntax tokens are the same, disregarding trivia differences.
        /// </summary>
        /// <param name="oldToken">The old token.</param>
        /// <param name="newToken">The new token.</param>
        public virtual bool AreEquivalent(SyntaxToken oldToken, SyntaxToken newToken)
        {
            return SyntaxEquivalence.AreEquivalent(oldToken, newToken);
        }

        /// <summary>
        /// Determines if two lists of tokens are the same, disregarding trivia differences.
        /// </summary>
        /// <param name="oldList">The old token list.</param>
        /// <param name="newList">The new token list.</param>
        public virtual bool AreEquivalent(SyntaxTokenList oldList, SyntaxTokenList newList)
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
        public virtual bool AreEquivalent<TNode>(SyntaxList<TNode> oldList, SyntaxList<TNode> newList, bool topLevel)
            where TNode : LanguageSyntaxNode
        {
            return SyntaxEquivalence.AreEquivalent(oldList.Node, newList.Node, null, topLevel);
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
        public virtual bool AreEquivalent<TNode>(SyntaxList<TNode> oldList, SyntaxList<TNode> newList, Func<int, bool> ignoreChildNode = null)
            where TNode : SyntaxNode
        {
            return SyntaxEquivalence.AreEquivalent(oldList.Node, newList.Node, ignoreChildNode, topLevel: false);
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
        public virtual bool AreEquivalent<TNode>(SeparatedSyntaxList<TNode> oldList, SeparatedSyntaxList<TNode> newList, bool topLevel)
            where TNode : SyntaxNode
        {
            return SyntaxEquivalence.AreEquivalent(oldList.Node, newList.Node, null, topLevel);
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
        public virtual bool AreEquivalent<TNode>(SeparatedSyntaxList<TNode> oldList, SeparatedSyntaxList<TNode> newList, Func<int, bool> ignoreChildNode = null)
            where TNode : SyntaxNode
        {
            return SyntaxEquivalence.AreEquivalent(oldList.Node, newList.Node, ignoreChildNode, topLevel: false);
        }

        /// <summary>
        /// Gets the containing expression that is actually a language expression (or something that
        /// GetSymbolInfo can be applied to) and not just typed
        /// as an ExpressionSyntax for convenience. For example, NameSyntax nodes on the right side
        /// of qualified names and member access expressions are not language expressions, yet the
        /// containing qualified names or member access expressions are indeed expressions.
        /// Similarly, if the input node is a cref part that is not independently meaningful, then
        /// the result will be the full cref. Besides an expression, an input that is a NameSyntax
        /// of a SubpatternSyntax, e.g. in `name: 3` may cause this method to return the enclosing
        /// SubpatternSyntax.
        /// </summary>
        public virtual LanguageSyntaxNode GetStandaloneNode(LanguageSyntaxNode node)
        {
            return node;
        }


        /// <summary>
        /// Determines whether the given text is considered a syntactically complete submission.
        /// Throws <see cref="ArgumentException"/> if the tree was not compiled as an interactive submission.
        /// </summary>
        public virtual bool IsCompleteSubmission(SyntaxTree tree)
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

            var compilation = tree.GetRoot();
            return !compilation.HasErrors;
        }

        /// <summary>
        /// Produces a syntax tree by parsing the source text.
        /// </summary>
        public LanguageSyntaxTree ParseSyntaxTree(
            SourceText text,
            ParseOptions options = null,
            string path = "",
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.ParseSyntaxTreeCore(text, options, path, cancellationToken);
        }

        /// <summary>
        /// Produces a syntax tree by parsing the source text.
        /// </summary>
        protected abstract LanguageSyntaxTree ParseSyntaxTreeCore(
            SourceText text,
            ParseOptions options = null,
            string path = "",
            CancellationToken cancellationToken = default(CancellationToken));

        public abstract SyntaxParser MakeParser(SourceText text, ParseOptions options, SyntaxNode oldTree, IReadOnlyList<TextChangeRange> changes);
        public abstract SyntaxParser MakeParser(string text);
        public abstract LanguageSyntaxTree MakeSyntaxTree(LanguageSyntaxNode root, ParseOptions options = null, string path = "", Encoding encoding = null);
        public abstract LanguageSyntaxTree MakeSyntaxTree(SyntaxParser parser, string path = "", CancellationToken cancellationToken = default);

    }
}
