using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.CodeAnalysis;

namespace MetaDslx.CodeAnalysis.MetaModel.Syntax
{
    public abstract class CompilationUnitSyntax : MetaModelSyntaxNode
    {
        internal CompilationUnitSyntax(GreenNode green, SyntaxNode parent, int position) : base(green, parent, position)
        {
        }

        internal CompilationUnitSyntax(GreenNode green, int position, SyntaxTree syntaxTree) : base(green, position, syntaxTree)
        {
        }
    }
}
