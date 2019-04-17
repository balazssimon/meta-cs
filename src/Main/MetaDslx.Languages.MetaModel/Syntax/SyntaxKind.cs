using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Languages.MetaModel.Syntax
{
    public enum SyntaxKind
    {
        None = MetaDslx.CodeAnalysis.Syntax.SyntaxKind.None,
        Eof = MetaDslx.CodeAnalysis.Syntax.SyntaxKind.Eof,
        List = MetaDslx.CodeAnalysis.Syntax.SyntaxKind.List,
        BadToken = MetaDslx.CodeAnalysis.Syntax.SyntaxKind.BadToken,
        SkippedTokensTrivia = MetaDslx.CodeAnalysis.Syntax.SyntaxKind.SkippedTokensTrivia,
        DisabledTextTrivia = MetaDslx.CodeAnalysis.Syntax.SyntaxKind.DisabledTextTrivia,
        ConflictMarkerTrivia = MetaDslx.CodeAnalysis.Syntax.SyntaxKind.ConflictMarkerTrivia,
        DefaultWhitespaceSyntaxKind = MetaDslx.CodeAnalysis.Syntax.SyntaxKind.DefaultWhitespace,
        DefaultEndOfLineSyntaxKind = MetaDslx.CodeAnalysis.Syntax.SyntaxKind.DefaultEndOfLine,
        CompilationUnit,

        FirstTokenWithWellKnownText = 0,
        LastTokenWithWellKnownText = 0,
    }
}
