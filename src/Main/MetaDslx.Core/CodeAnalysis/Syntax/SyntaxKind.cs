using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Syntax
{
    public class SyntaxKind
    {
        public const int None = 0;
        public const int Eof = -1;
        public const int List = -2;
        public const int BadToken = -3;
        public const int SkippedTokensTrivia = -4;
        public const int DisabledTextTrivia = -5;
        public const int ConflictMarkerTrivia = -6;
        public const int DefaultWhitespace = -7;
        public const int DefaultEndOfLine = -8;
        public const int DefaultSeparator = -9;
        public const int DefaultIdentifier = -10;
        public const int EndOfDirectiveToken = -11;
        public const int CompilationUnit = -12;
    }
}
