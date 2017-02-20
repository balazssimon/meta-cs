using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Diagnostics
{
    public class CompilerErrorCode : ErrorCode
    {
        public const string CompilerCategory = "MetaDslx.Compiler.Core";
        public static readonly CompilerErrorCode ERR_SyntaxError = new CompilerErrorCode(1, DiagnosticSeverity.Error, 0, "Syntax error: {0}");
        public static readonly CompilerErrorCode HDN_UnusedSymbol = new CompilerErrorCode(2, DiagnosticSeverity.Hidden, -1, "Unused symbol: {0}");
        public static readonly CompilerErrorCode ERR_WrongSymbolKind = new CompilerErrorCode(3, DiagnosticSeverity.Error, 0, "Wrong symbol kind: {0}");
        public static readonly CompilerErrorCode ERR_WrongSymbolType = new CompilerErrorCode(4, DiagnosticSeverity.Error, 0, "Wrong symbol type: {0}");

        public CompilerErrorCode(int code, DiagnosticSeverity defaultSeverity, int warningLevel, string defaultMessage)
            : base(CompilerCategory, code, defaultSeverity, warningLevel, defaultMessage)
        {
        }
    }
}
