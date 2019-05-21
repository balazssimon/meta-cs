using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.CodeAnalysis.Syntax.InternalSyntax;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace MetaDslx.Languages.MetaModel.Syntax.InternalSyntax
{
    internal class MetaModelSyntaxParser : SyntaxParser
    {
        public MetaModelSyntaxParser(SourceText text, MetaModelParseOptions options, SyntaxNode oldTree, IEnumerable<TextChangeRange> changes, CancellationToken cancellationToken = default) 
            : base(text, MetaModelLanguage.Instance, options, oldTree, changes, cancellationToken)
        {
        }

        public override DirectiveStack Directives => throw new NotImplementedException();

        public override GreenNode Parse()
        {
            throw new NotImplementedException();
        }

        internal GreenSyntaxNode ParseCompilationUnit()
        {
            throw new NotImplementedException();
        }
    }
}
