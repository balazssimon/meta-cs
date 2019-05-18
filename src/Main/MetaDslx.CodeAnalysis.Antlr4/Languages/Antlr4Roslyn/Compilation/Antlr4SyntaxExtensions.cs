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
            return kind.GetValue() - SyntaxKind.__LastPredefinedSyntaxKindValue + 1;
        }

        public static SyntaxKind FromAntlr4(this int token)
        {
            return EnumObject.FromIntUnsafe<SyntaxKind>(token + SyntaxKind.__LastPredefinedSyntaxKindValue - 1);
        }
    }
}
