using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Compiler.Syntax.InternalSyntax
{
    public static class SyntaxKind 
    {
        public const int None = 0;
        public const int List = -1;
        public const int SkippedTokensTrivia = -2;
        public const int EndOfFileToken = -3;
    }
}
