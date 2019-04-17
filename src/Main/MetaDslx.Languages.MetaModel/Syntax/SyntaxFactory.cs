using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.MetaModel.Syntax
{
    public class MetaModelSyntaxFactory : SyntaxFactory
    {
        public override Language Language => MetaModelLanguage.Instance;

        public override Microsoft.CodeAnalysis.SyntaxToken DefaultSeparator => throw new NotImplementedException();

        public override Microsoft.CodeAnalysis.SyntaxNode CreateStructure(Microsoft.CodeAnalysis.SyntaxTrivia trivia)
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
        public virtual SyntaxTree SyntaxTree(SyntaxNode root, ParseOptions options = null, string path = "", Encoding encoding = null)
        {
            return MetaModelSyntaxTree.Create((MetaModelSyntaxNode)root, (MetaModelParseOptions)options, path, encoding);
        }

        /// <summary>
        /// Produces a syntax tree by parsing the source text.
        /// </summary>
        public virtual SyntaxTree ParseSyntaxTree(
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
        public virtual SyntaxTree ParseSyntaxTree(
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

        private InternalSyntax.MetaModelSyntaxParser MakeParser(SourceText text)
        {
            return new InternalSyntax.MetaModelSyntaxParser(text, MetaModelParseOptions.Default, oldTree: null, changes: null);
        }

    }
}
