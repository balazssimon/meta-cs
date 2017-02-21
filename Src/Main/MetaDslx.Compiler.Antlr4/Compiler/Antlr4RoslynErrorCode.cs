using MetaDslx.Compiler.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Antlr4Roslyn
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

        public Antlr4RoslynErrorCode(int id, DiagnosticSeverity defaultSeverity, int warningLevel, string defaultMessage) 
            : base(Antlr4RoslynCategory, id, defaultSeverity, warningLevel, defaultMessage)
        {
        }
    }
}
