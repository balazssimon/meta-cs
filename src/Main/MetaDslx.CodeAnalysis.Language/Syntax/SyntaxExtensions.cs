// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using Roslyn.Utilities;

namespace Microsoft.CodeAnalysis.CSharp
{
    public static class SyntaxExtensions
    {
        public static Language Language(this SyntaxNode node)
        {
            return ((Syntax.InternalSyntax.CSharpSyntaxNode)node.Green).Language;
        }

        public static Language Language(this SyntaxToken token)
        {
            return ((Syntax.InternalSyntax.CSharpSyntaxNode)token.Node).Language;
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
            return SyntaxNormalizer.Normalize(token, indentation, Microsoft.CodeAnalysis.SyntaxNodeExtensions.DefaultEOL, elasticTrivia);
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
            string indentation = Microsoft.CodeAnalysis.SyntaxNodeExtensions.DefaultIndentation,
            string eol = Microsoft.CodeAnalysis.SyntaxNodeExtensions.DefaultEOL,
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
            return SyntaxNormalizer.Normalize(list, indentation, Microsoft.CodeAnalysis.SyntaxNodeExtensions.DefaultEOL, elasticTrivia);
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
            string indentation = Microsoft.CodeAnalysis.SyntaxNodeExtensions.DefaultIndentation,
            string eol = Microsoft.CodeAnalysis.SyntaxNodeExtensions.DefaultEOL,
            bool elasticTrivia = false)
        {
            return SyntaxNormalizer.Normalize(list, indentation, eol, elasticTrivia);
        }

        public static SyntaxTriviaList ToSyntaxTriviaList(this IEnumerable<SyntaxTrivia> sequence)
        {
            SyntaxTrivia? first = sequence.FirstOrNullable();
            if (first == null) return default(SyntaxTriviaList);
            else return ((Syntax.InternalSyntax.CSharpSyntaxNode)first.Value.UnderlyingNode).Language.SyntaxFactory.TriviaList(sequence);
        }

        internal static bool ReportDocumentationCommentDiagnostics(this SyntaxTree tree)
        {
            return tree.Options.DocumentationMode >= DocumentationMode.Diagnose;
        }

    }
}
