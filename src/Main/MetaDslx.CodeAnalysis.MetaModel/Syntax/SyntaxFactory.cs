using MetaDslx.CodeAnalysis.MetaModel.Syntax.InternalSyntax;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.MetaModel.Syntax
{
    public class MetaModelSyntaxFactory : SyntaxFactory
    {
        public override Microsoft.CodeAnalysis.SyntaxToken DefaultSeparator => throw new NotImplementedException();

        public override Microsoft.CodeAnalysis.SyntaxNode CreateStructure(Microsoft.CodeAnalysis.SyntaxTrivia trivia)
        {
            throw new NotImplementedException();
        }
    }
}
