using MetaDslx.Compiler.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Languages.Antlr4Roslyn.Compilation
{
    public class Antlr4RoslynErrorCode : ErrorCode
    {
        public const string Antlr4RoslynCategory = "Antlr4Roslyn";
        public static readonly Antlr4RoslynErrorCode ERR_SyntaxError = new Antlr4RoslynErrorCode(1, DiagnosticSeverity.Error, 0, "Syntax error: {0}");
        public static readonly Antlr4RoslynErrorCode ERR_UnnamedElement = new Antlr4RoslynErrorCode(2, DiagnosticSeverity.Error, 0, "Element '{0}' must have a name. Elements with the same type in a rule must have different names.");
        public static readonly Antlr4RoslynErrorCode ERR_UnnamedBlock = new Antlr4RoslynErrorCode(3, DiagnosticSeverity.Error, 0, "This block must have a name.");
        public static readonly Antlr4RoslynErrorCode ERR_RuleMapUnnamedAlt = new Antlr4RoslynErrorCode(4, DiagnosticSeverity.Error, 0, "Rule '{0}' cannot be mapped to Roslyn. Give labels to the alternatives.");
        public static readonly Antlr4RoslynErrorCode ERR_RuleMapTooComplex = new Antlr4RoslynErrorCode(5, DiagnosticSeverity.Error, 0, "Rule '{0}' cannot be mapped to Roslyn. Consider simplifying it by breaking it up to smaller rules.");
        public static readonly Antlr4RoslynErrorCode ERR_BlockMap = new Antlr4RoslynErrorCode(6, DiagnosticSeverity.Error, 0, "This block cannot be mapped to Roslyn. Create a separate rule from the block.");
        public static readonly Antlr4RoslynErrorCode ERR_BlockMapSuffix = new Antlr4RoslynErrorCode(7, DiagnosticSeverity.Error, 0, "A block cannot have a '*' or '+' suffix. Create a separate rule from the block.");
        public static readonly Antlr4RoslynErrorCode ERR_BlockUnhandled = new Antlr4RoslynErrorCode(8, DiagnosticSeverity.Error, 0, "Unhandled block.");
        public static readonly Antlr4RoslynErrorCode ERR_ElementMap = new Antlr4RoslynErrorCode(9, DiagnosticSeverity.Error, 0, "Cannot map this element in the block to a Roslyn rule. Create a separate rule from this element.");
        public static readonly Antlr4RoslynErrorCode ERR_Antlr4LoadError = new Antlr4RoslynErrorCode(10, DiagnosticSeverity.Error, 0, "Cannot create ANTLR4 jar: {0} ({1})");
        public static readonly Antlr4RoslynErrorCode ERR_Antlr4Error = new Antlr4RoslynErrorCode(11, DiagnosticSeverity.Error, 0, "{0}");
        public static readonly Antlr4RoslynErrorCode WRN_Antlr4Warning = new Antlr4RoslynErrorCode(12, DiagnosticSeverity.Warning, 1, "{0}");
        public static readonly Antlr4RoslynErrorCode INF_Antlr4Info = new Antlr4RoslynErrorCode(13, DiagnosticSeverity.Info, 0, "{0}");
        public static readonly Antlr4RoslynErrorCode ERR_Antlr4TimeoutError = new Antlr4RoslynErrorCode(14, DiagnosticSeverity.Error, 0, "ANTLR4 timed out after 30 seconds. Please, try compiling again. ({0})");
        public static readonly Antlr4RoslynErrorCode ERR_Antlr4CallError = new Antlr4RoslynErrorCode(15, DiagnosticSeverity.Error, 0, "Error calling ANTLR4: {0} ({1})");

        public Antlr4RoslynErrorCode(int id, DiagnosticSeverity defaultSeverity, int warningLevel, string defaultMessage) 
            : base(Antlr4RoslynCategory, id, defaultSeverity, warningLevel, defaultMessage)
        {
        }
    }
}
