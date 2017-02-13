using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Syntax
{
    public class ErrorCode
    {
        public const int ERR_SyntaxError = 1;
        public const int HDN_UnusedSymbol = 2;
        public const int ERR_WrongSymbolKind = 3;
        public const int ERR_WrongSymbolType = 4;
    }
}
