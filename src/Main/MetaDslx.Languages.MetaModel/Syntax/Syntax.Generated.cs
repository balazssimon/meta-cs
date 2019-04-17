using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.CodeAnalysis;

namespace MetaDslx.Languages.MetaModel.Syntax
{
    public abstract class CompilationUnitSyntax : MetaModelSyntaxNode
    {
        internal CompilationUnitSyntax(GreenNode green, MetaModelSyntaxNode parent, int position) : base(green, parent, position)
        {
        }

        internal CompilationUnitSyntax(GreenNode green, int position, MetaModelSyntaxTree syntaxTree) : base(green, position, syntaxTree)
        {
        }
    }
}
