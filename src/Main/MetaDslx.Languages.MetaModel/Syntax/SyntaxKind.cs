using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.MetaModel.Syntax
{
    public enum SyntaxKind
    {
        None = Microsoft.CodeAnalysis.CSharp.Syntax.SyntaxKind.None,
        Eof = Microsoft.CodeAnalysis.CSharp.Syntax.SyntaxKind.Eof,
        List = Microsoft.CodeAnalysis.CSharp.Syntax.SyntaxKind.List,
        BadToken = Microsoft.CodeAnalysis.CSharp.Syntax.SyntaxKind.BadToken,
        SkippedTokensTrivia = Microsoft.CodeAnalysis.CSharp.Syntax.SyntaxKind.SkippedTokensTrivia,
        DisabledTextTrivia = Microsoft.CodeAnalysis.CSharp.Syntax.SyntaxKind.DisabledTextTrivia,
        ConflictMarkerTrivia = Microsoft.CodeAnalysis.CSharp.Syntax.SyntaxKind.ConflictMarkerTrivia,
        DefaultWhitespaceSyntaxKind = Microsoft.CodeAnalysis.CSharp.Syntax.SyntaxKind.DefaultWhitespace,
        DefaultEndOfLineSyntaxKind = Microsoft.CodeAnalysis.CSharp.Syntax.SyntaxKind.DefaultEndOfLine,
        CompilationUnit,

        FirstTokenWithWellKnownText = 0,
        LastTokenWithWellKnownText = 0,
    }
}
