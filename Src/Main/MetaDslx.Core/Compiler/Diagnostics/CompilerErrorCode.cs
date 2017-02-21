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
        public static readonly CompilerErrorCode HDN_UnusedSymbol = new CompilerErrorCode(2, DiagnosticSeverity.Hidden, 1, "Unused symbol: {0}");
        public static readonly CompilerErrorCode ERR_WrongSymbolKind = new CompilerErrorCode(3, DiagnosticSeverity.Error, 0, "Wrong symbol '{0}' ({1}).");
        public static readonly CompilerErrorCode ERR_WrongSymbolType = new CompilerErrorCode(4, DiagnosticSeverity.Error, 0, "Wrong symbol '{0}' ({1}).");
        public static readonly CompilerErrorCode WRN_SameFullNameThisNsAgg = new CompilerErrorCode(5, DiagnosticSeverity.Warning, 1, "The namespace '{1}' in '{0}' conflicts with the imported type '{3}' in '{2}'. Using the namespace defined in '{0}'.");
        public static readonly CompilerErrorCode WRN_SameFullNameThisAggNs = new CompilerErrorCode(6, DiagnosticSeverity.Warning, 1, "The type '{1}' in '{0}' conflicts with the imported namespace '{3}' in '{2}'. Using the type defined in '{0}'.");
        public static readonly CompilerErrorCode WRN_SameFullNameThisAggAgg = new CompilerErrorCode(7, DiagnosticSeverity.Warning, 1, "The type '{1}' in '{0}' conflicts with the imported type '{3}' in '{2}'. Using the type defined in '{0}'.");
        public static readonly CompilerErrorCode ERR_SameFullNameAggAgg = new CompilerErrorCode(8, DiagnosticSeverity.Error, 0, "The type '{1}' exists in both '{0}' and '{2}'.");
        public static readonly CompilerErrorCode ERR_SameFullNameNsAgg = new CompilerErrorCode(9, DiagnosticSeverity.Error, 0, "The namespace '{1}' in '{0}' conflicts with the type '{3}' in '{2}'.");
        public static readonly CompilerErrorCode ERR_SameFullNameThisAggThisNs = new CompilerErrorCode(10, DiagnosticSeverity.Error, 0, "The type '{1}' in '{0}' conflicts with the namespace '{3}' in '{2}'.");
        public static readonly CompilerErrorCode ERR_AmbigMember = new CompilerErrorCode(11, DiagnosticSeverity.Error, 0, "Ambiguity between '{0}' and '{1}'.");
        public static readonly CompilerErrorCode ERR_NotFound = new CompilerErrorCode(11, DiagnosticSeverity.Error, 0, "Cannot resolve symbol '{0}'.");

        public CompilerErrorCode(int code, DiagnosticSeverity defaultSeverity, int warningLevel, string defaultMessage)
            : base(CompilerCategory, code, defaultSeverity, warningLevel, defaultMessage)
        {
        }
    }
}
