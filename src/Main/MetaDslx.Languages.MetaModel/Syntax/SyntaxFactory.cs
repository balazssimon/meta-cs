using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.Languages.MetaModel.Syntax.InternalSyntax;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MetaDslx.Languages.MetaModel.Syntax
{
    public class MetaModelSyntaxFactory : SyntaxFactory
    {
        public override Language Language => MetaModelLanguage.Instance;

        public override SyntaxToken DefaultSeparator => throw new NotImplementedException();

        public override SyntaxNode CreateStructure(SyntaxTrivia trivia)
        {
            throw new NotImplementedException();
        }

        internal MetaModelSyntaxNode ParseCompilationUnit(string empty)
        {
            throw new NotImplementedException();
        }

        // direct access to parsing for common grammar areas

        /// <summary>
        /// Create a new syntax tree from a syntax node.
        /// </summary>
        public override LanguageSyntaxTree SyntaxTree(LanguageSyntaxNode root, ParseOptions options = null, string path = "", Encoding encoding = null)
        {
            return MetaModelSyntaxTree.Create((MetaModelSyntaxNode)root, (MetaModelParseOptions)options, path, encoding);
        }

        /// <summary>
        /// Produces a syntax tree by parsing the source text.
        /// </summary>
        public override LanguageSyntaxTree ParseSyntaxTree(
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
        public override LanguageSyntaxTree ParseSyntaxTree(
            SourceText text,
            ParseOptions options = null,
            string path = "",
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return MetaModelSyntaxTree.ParseText(text, (MetaModelParseOptions)options, path, cancellationToken);
        }

        /// <summary>
        /// Helper method for wrapping a string in an SourceText.
        /// </summary>
        private SourceText MakeSourceText(string text, int offset)
        {
            return SourceText.From(text, Encoding.UTF8).GetSubText(offset);
        }

        private MetaModelSyntaxParser MakeParser(SourceText text)
        {
            return new MetaModelSyntaxParser(text, MetaModelParseOptions.Default, oldTree: null, changes: null);
        }
    }
}
