using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Syntax
{
    public static class Antlr4SyntaxExtensions
    {
        public static int ToAntlr4(this SyntaxKind kind)
        {
            return kind.GetValue() - SyntaxKind.__LastPredefinedSyntaxKindValue;
        }

        public static SyntaxKind FromAntlr4(this int token, Type syntaxKindType)
        {
            return (SyntaxKind)EnumObject.FromIntUnsafe(syntaxKindType, token + SyntaxKind.__LastPredefinedSyntaxKindValue);
        }
    }
}
