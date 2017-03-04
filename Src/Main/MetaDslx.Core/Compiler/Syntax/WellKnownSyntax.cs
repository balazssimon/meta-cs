using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Syntax
{
    public interface ICompilationUnitSyntax
    {
        SyntaxToken Eof { get; }
    }

    public interface IStructuredTokenSyntax
    {
        SyntaxToken ParentToken { get; }
    }

    public interface IStructuredTriviaSyntax
    {
        SyntaxTrivia ParentTrivia { get; }
    }
}
