using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.MetaModel.Syntax.InternalSyntax
{
    internal class MetaModelSyntaxParser : SyntaxParser
    {
        public MetaModelSyntaxParser(SourceText text, CSharpParseOptions options, Microsoft.CodeAnalysis.SyntaxNode oldTree, IEnumerable<TextChangeRange> changes, CancellationToken cancellationToken = default) 
            : base(text, MetaModelLanguage.Instance, options, oldTree, changes, cancellationToken)
        {
        }

        public override DirectiveStack Directives => throw new NotImplementedException();

        public override GreenNode Parse()
        {
            throw new NotImplementedException();
        }

        internal SyntaxNode ParseCompilationUnit()
        {
            throw new NotImplementedException();
        }
    }
}
