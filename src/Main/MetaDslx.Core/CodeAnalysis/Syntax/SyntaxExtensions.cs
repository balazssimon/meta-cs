// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Syntax;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Syntax;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis
{
    using CSharpSyntaxTree = Microsoft.CodeAnalysis.CSharp.CSharpSyntaxTree;

    public static class SyntaxExtensions
    {
        public static Language Language(this SyntaxNode node)
        {
            return ((Syntax.InternalSyntax.InternalSyntaxNode)node.Green).Language;
        }

        public static Language Language(this SyntaxToken token)
        {
            return ((Syntax.InternalSyntax.InternalSyntaxNode)token.Node).Language;
        }

        public static Language Language(this GreenNode node)
        {
            return ((Syntax.InternalSyntax.InternalSyntaxNode)node).Language;
        }

        public static bool IsExpression(this LanguageSyntaxNode node)
        {
            return node.Language.SyntaxFacts.IsExpression(node);
        }

        public static bool IsStatement(this LanguageSyntaxNode node)
        {
            return node.Language.SyntaxFacts.IsStatement(node);
        }

        public static TNode WithAnnotations<TNode>(this TNode node, params SyntaxAnnotation[] annotations) where TNode : LanguageSyntaxNode
        {
            return (TNode)node.Green.SetAnnotations(annotations).CreateRed();
        }

        /// <summary>
        /// Creates a new syntax token with all whitespace and end of line trivia replaced with
        /// regularly formatted trivia.
        /// </summary>
        /// <param name="token">The token to normalize.</param>
        /// <param name="indentation">A sequence of whitespace characters that defines a single level of indentation.</param>
        /// <param name="elasticTrivia">If true the replaced trivia is elastic trivia.</param>
        public static SyntaxToken NormalizeWhitespace(this SyntaxToken token, string indentation, bool elasticTrivia)
        {
            return SyntaxNormalizer.Normalize(token, indentation, SyntaxNodeExtensions.DefaultEOL, elasticTrivia);
        }

        /// <summary>
        /// Creates a new syntax token with all whitespace and end of line trivia replaced with
        /// regularly formatted trivia.
        /// </summary>
        /// <param name="token">The token to normalize.</param>
        /// <param name="indentation">An optional sequence of whitespace characters that defines a
        /// single level of indentation.</param>
        /// <param name="eol">An optional sequence of whitespace characters used for end of line.</param>
        /// <param name="elasticTrivia">If true the replaced trivia is elastic trivia.</param>
        public static SyntaxToken NormalizeWhitespace(this SyntaxToken token,
            string indentation = SyntaxNodeExtensions.DefaultIndentation,
            string eol = SyntaxNodeExtensions.DefaultEOL,
            bool elasticTrivia = false)
        {
            return SyntaxNormalizer.Normalize(token, indentation, eol, elasticTrivia);
        }

        /// <summary>
        /// Creates a new syntax trivia list with all whitespace and end of line trivia replaced with
        /// regularly formatted trivia.
        /// </summary>
        /// <param name="list">The trivia list to normalize.</param>
        /// <param name="indentation">A sequence of whitespace characters that defines a single level of indentation.</param>
        /// <param name="elasticTrivia">If true the replaced trivia is elastic trivia.</param>
        public static SyntaxTriviaList NormalizeWhitespace(this SyntaxTriviaList list, string indentation, bool elasticTrivia)
        {
            return SyntaxNormalizer.Normalize(list, indentation, SyntaxNodeExtensions.DefaultEOL, elasticTrivia);
        }

        /// <summary>
        /// Creates a new syntax trivia list with all whitespace and end of line trivia replaced with
        /// regularly formatted trivia.
        /// </summary>
        /// <param name="list">The trivia list to normalize.</param>
        /// <param name="indentation">An optional sequence of whitespace characters that defines a
        /// single level of indentation.</param>
        /// <param name="eol">An optional sequence of whitespace characters used for end of line.</param>
        /// <param name="elasticTrivia">If true the replaced trivia is elastic trivia.</param>
        public static SyntaxTriviaList NormalizeWhitespace(this SyntaxTriviaList list,
            string indentation = SyntaxNodeExtensions.DefaultIndentation,
            string eol = SyntaxNodeExtensions.DefaultEOL,
            bool elasticTrivia = false)
        {
            return SyntaxNormalizer.Normalize(list, indentation, eol, elasticTrivia);
        }

        public static SyntaxTriviaList ToSyntaxTriviaList(this IEnumerable<SyntaxTrivia> sequence)
        {
            SyntaxTrivia? first = sequence.FirstOrNullable();
            if (first == null) return default(SyntaxTriviaList);
            else return ((Syntax.InternalSyntax.InternalSyntaxNode)first.Value.UnderlyingNode).Language.SyntaxFactory.TriviaList(sequence);
        }

        internal static bool ReportDocumentationCommentDiagnostics(this SyntaxTree tree)
        {
            return tree.Options.DocumentationMode >= DocumentationMode.Diagnose;
        }

        /// <summary>
        /// Returns the index of the first node of a specified kind in the node list.
        /// </summary>
        /// <param name="list">Node list.</param>
        /// <param name="kind">The <see cref="SyntaxKind"/> to find.</param>
        /// <returns>Returns non-negative index if the list contains a node which matches <paramref name="kind"/>, -1 otherwise.</returns>
        public static int IndexOf<TNode>(this SyntaxList<TNode> list, int kind)
            where TNode : SyntaxNode
        {
            return list.IndexOf((int)kind);
        }

        /// <summary>
        /// True if the list has at least one node of the specified kind.
        /// </summary>
        public static bool Any<TNode>(this SyntaxList<TNode> list, int kind)
            where TNode : SyntaxNode
        {
            return list.IndexOf(kind) >= 0;
        }

        /// <summary>
        /// Returns the index of the first node of a specified kind in the node list.
        /// </summary>
        /// <param name="list">Node list.</param>
        /// <param name="kind">The <see cref="SyntaxKind"/> to find.</param>
        /// <returns>Returns non-negative index if the list contains a node which matches <paramref name="kind"/>, -1 otherwise.</returns>
        public static int IndexOf<TNode>(this SeparatedSyntaxList<TNode> list, int kind)
            where TNode : SyntaxNode
        {
            return list.IndexOf((int)kind);
        }

        /// <summary>
        /// True if the list has at least one node of the specified kind.
        /// </summary>
        public static bool Any<TNode>(this SeparatedSyntaxList<TNode> list, int kind)
            where TNode : SyntaxNode
        {
            return list.IndexOf(kind) >= 0;
        }

        /// <summary>
        /// Returns the index of the first trivia of a specified kind in the trivia list.
        /// </summary>
        /// <param name="list">Trivia list.</param>
        /// <param name="kind">The <see cref="SyntaxKind"/> to find.</param>
        /// <returns>Returns non-negative index if the list contains a trivia which matches <paramref name="kind"/>, -1 otherwise.</returns>
        public static int IndexOf(this SyntaxTriviaList list, int kind)
        {
            return list.IndexOf((int)kind);
        }

        /// <summary>
        /// True if the list has at least one trivia of the specified kind.
        /// </summary>
        public static bool Any(this SyntaxTriviaList list, int kind)
        {
            return list.IndexOf(kind) >= 0;
        }

        /// <summary>
        /// Returns the index of the first token of a specified kind in the token list.
        /// </summary>
        /// <param name="list">Token list.</param>
        /// <param name="kind">The <see cref="SyntaxKind"/> to find.</param>
        /// <returns>Returns non-negative index if the list contains a token which matches <paramref name="kind"/>, -1 otherwise.</returns>
        public static int IndexOf(this SyntaxTokenList list, int kind)
        {
            return list.IndexOf((int)kind);
        }

        /// <summary>
        /// Tests whether a list contains a token of a particular kind.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="kind">The <see cref="CSharp.SyntaxKind"/> to test for.</param>
        /// <returns>Returns true if the list contains a token which matches <paramref name="kind"/></returns>
        public static bool Any(this SyntaxTokenList list, int kind)
        {
            return list.IndexOf(kind) >= 0;
        }

        internal static SyntaxToken FirstOrDefault(this SyntaxTokenList list, int kind)
        {
            int index = list.IndexOf(kind);
            return (index >= 0) ? list[index] : default(SyntaxToken);
        }

        /// <summary>
        /// Insert one or more tokens in the list at the specified index.
        /// </summary>
        /// <returns>A new list with the tokens inserted.</returns>
        public static SyntaxTokenList Insert(this SyntaxTokenList list, int index, params SyntaxToken[] items)
        {
            if (index < 0 || index > list.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            if (items.Length == 0)
            {
                return list;
            }

            if (list.Count == 0)
            {
                var first = (Syntax.InternalSyntax.InternalSyntaxToken)items[0].Node;
                return first.Language.SyntaxFactory.TokenList(items);
            }
            else
            {
                var builder = new SyntaxTokenListBuilder(list.Count + items.Length);
                if (index > 0)
                {
                    builder.Add(list, 0, index);
                }

                builder.Add(items);

                if (index < list.Count)
                {
                    builder.Add(list, index, list.Count - index);
                }

                return builder.ToList();
            }
        }

        /// <summary>
        /// Creates a new token with the specified old trivia replaced with computed new trivia.
        /// </summary>
        /// <param name="token"></param>
        /// <param name="trivia">The trivia to be replaced; descendants of the root token.</param>
        /// <param name="computeReplacementTrivia">A function that computes a replacement trivia for
        /// the argument trivia. The first argument is the original trivia. The second argument is
        /// the same trivia rewritten with replaced structure.</param>
        public static SyntaxToken ReplaceTrivia(this SyntaxToken token, IEnumerable<SyntaxTrivia> trivia, Func<SyntaxTrivia, SyntaxTrivia, SyntaxTrivia> computeReplacementTrivia)
        {
            return SyntaxReplacer.Replace(token, trivia: trivia, computeReplacementTrivia: computeReplacementTrivia);
        }

        /// <summary>
        /// Creates a new token with the specified old trivia replaced with a new trivia. The old trivia may appear in
        /// the token's leading or trailing trivia.
        /// </summary>
        /// <param name="token"></param>
        /// <param name="oldTrivia">The trivia to be replaced.</param>
        /// <param name="newTrivia">The new trivia to use in the new tree in place of the old
        /// trivia.</param>
        public static SyntaxToken ReplaceTrivia(this SyntaxToken token, SyntaxTrivia oldTrivia, SyntaxTrivia newTrivia)
        {
            return Syntax.SyntaxReplacer.Replace(token, trivia: new[] { oldTrivia }, computeReplacementTrivia: (o, r) => newTrivia);
        }

        internal static DirectiveStack ApplyDirectives(this SyntaxNode node, DirectiveStack stack)
        {
            return ((Syntax.InternalSyntax.InternalSyntaxNode)node.Green).ApplyDirectives(stack);
        }

        internal static DirectiveStack ApplyDirectives(this SyntaxToken token, DirectiveStack stack)
        {
            return ((Syntax.InternalSyntax.InternalSyntaxNode)token.Node).ApplyDirectives(stack);
        }

        internal static DirectiveStack ApplyDirectives(this SyntaxNodeOrToken nodeOrToken, DirectiveStack stack)
        {
            if (nodeOrToken.IsToken)
            {
                return nodeOrToken.AsToken().ApplyDirectives(stack);
            }

            if (nodeOrToken.IsNode)
            {
                return nodeOrToken.AsNode().ApplyDirectives(stack);
            }

            return stack;
        }

        /// <summary>
        /// Returns this list as a <see cref="MetaDslx.CodeAnalysis.SeparatedSyntaxList&lt;TNode&gt;"/>.
        /// </summary>
        /// <typeparam name="TOther">The type of the list elements in the separated list.</typeparam>
        /// <returns></returns>
        internal static SeparatedSyntaxList<TOther> AsSeparatedList<TOther>(this SyntaxNodeOrTokenList list) where TOther : SyntaxNode
        {
            var builder = SeparatedSyntaxListBuilder<TOther>.Create();
            foreach (var i in list)
            {
                var node = i.AsNode();
                if (node != null)
                {
                    builder.Add((TOther)node);
                }
                else
                {
                    builder.AddSeparator(i.AsToken());
                }
            }

            return builder.ToList();
        }

        #region SyntaxTree
        public static ICompilationUnitRootSyntax GetCompilationUnitRoot(this SyntaxTree tree, CancellationToken cancellationToken = default(CancellationToken))
        {
            return (ICompilationUnitRootSyntax)tree.GetRoot(cancellationToken);
        }

        public static bool HasReferenceDirectives(this SyntaxTree tree)
        {
            if (tree is LanguageSyntaxTree languageTree) return languageTree.HasReferenceDirectives;
            if (tree is CSharpSyntaxTree csharpTree) return csharpTree.HasReferenceDirectives;
            return false;
        }

        public static bool HasReferenceOrLoadDirectives(this SyntaxTree tree)
        {
            if (tree is LanguageSyntaxTree languageTree) return languageTree.HasReferenceOrLoadDirectives;
            if (tree is CSharpSyntaxTree csharpTree) return csharpTree.HasReferenceOrLoadDirectives;
            return false;
        }

        public static bool IsAnyPreprocessorSymbolDefined(this SyntaxTree tree, ImmutableArray<string> conditionalSymbols)
        {
            if (tree is LanguageSyntaxTree languageTree) return languageTree.IsAnyPreprocessorSymbolDefined(conditionalSymbols);
            if (tree is CSharpSyntaxTree csharpTree) return csharpTree.IsAnyPreprocessorSymbolDefined(conditionalSymbols);
            return false;
        }

        public static bool IsPreprocessorSymbolDefined(this SyntaxTree tree, string symbolName, int position)
        {
            if (tree is LanguageSyntaxTree languageTree) return languageTree.IsPreprocessorSymbolDefined(symbolName, position);
            if (tree is CSharpSyntaxTree csharpTree) return csharpTree.IsPreprocessorSymbolDefined(symbolName, position);
            return false;
        }

        // Given the error code and the source location, get the warning state based on pragma warning directives.
        public static PragmaWarningState GetPragmaDirectiveWarningState(this SyntaxTree tree, string id, int position)
        {
            if (tree is LanguageSyntaxTree languageTree) return languageTree.GetPragmaDirectiveWarningState(id, position);
            if (tree is CSharpSyntaxTree csharpTree)
            {
                switch (csharpTree.GetPragmaDirectiveWarningState(id, position))
                {
                    case Microsoft.CodeAnalysis.CSharp.Syntax.PragmaWarningState.Default:
                        return PragmaWarningState.Default;
                    case Microsoft.CodeAnalysis.CSharp.Syntax.PragmaWarningState.Enabled:
                        return PragmaWarningState.Enabled;
                    case Microsoft.CodeAnalysis.CSharp.Syntax.PragmaWarningState.Disabled:
                        return PragmaWarningState.Disabled;
                    default:
                        break;
                }
            }
            return PragmaWarningState.Default;
        }

        #endregion

    }
}
