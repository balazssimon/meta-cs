using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Syntax
{
    public class SyntaxKind
    {
        public const int None = 0;
        public const int List = -1;
        public const int BadToken = -2;
        public const int Eof = -3;
        public const int WhitespaceTrivia = -4;
        public const int EndOfLineTrivia = -5;
    }
}
