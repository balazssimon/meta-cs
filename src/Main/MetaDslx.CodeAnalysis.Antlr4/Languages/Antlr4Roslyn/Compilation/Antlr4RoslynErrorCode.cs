using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.CodeAnalysis;
using Microsoft.CodeAnalysis;

namespace MetaDslx.Languages.Antlr4Roslyn.Compilation
{
    public class Antlr4RoslynErrorCode : ErrorCode
    {
        public new const string Category = "Antlr4Roslyn";
        public new const string MessagePrefix = "AR";

        public static readonly Antlr4RoslynErrorCode ERR_SyntaxError = new Antlr4RoslynErrorCode(1, DiagnosticSeverity.Error, "Syntax error", "Syntax error: {0}");
        public static readonly Antlr4RoslynErrorCode ERR_UnnamedElement = new Antlr4RoslynErrorCode(2, DiagnosticSeverity.Error, "Element must have a name", "Element '{0}' must have a name. Elements with the same type in a rule must have different names.");
        public static readonly Antlr4RoslynErrorCode ERR_UnnamedBlock = new Antlr4RoslynErrorCode(3, DiagnosticSeverity.Error, "Block must have a name", "This block must have a name.");
        public static readonly Antlr4RoslynErrorCode ERR_RuleMapUnnamedAlt = new Antlr4RoslynErrorCode(4, DiagnosticSeverity.Error, "Invalid Roslyn rule", "Rule '{0}' cannot be mapped to Roslyn. Give labels to the alternatives.");
        public static readonly Antlr4RoslynErrorCode ERR_RuleMapTooComplex = new Antlr4RoslynErrorCode(5, DiagnosticSeverity.Error, "Invalid Roslyn rule", "Rule '{0}' cannot be mapped to Roslyn. Consider simplifying it by breaking it up to smaller rules.");
        public static readonly Antlr4RoslynErrorCode ERR_BlockMap = new Antlr4RoslynErrorCode(6, DiagnosticSeverity.Error, "Invalid Roslyn block", "This block cannot be mapped to Roslyn. Create a separate rule from the block.");
        public static readonly Antlr4RoslynErrorCode ERR_BlockMapSuffix = new Antlr4RoslynErrorCode(7, DiagnosticSeverity.Error, "Invalid Roslyn block", "A block cannot have a '*' or '+' suffix. Create a separate rule from the block.");
        public static readonly Antlr4RoslynErrorCode ERR_BlockUnhandled = new Antlr4RoslynErrorCode(8, DiagnosticSeverity.Error, "Unhandled block", "Unhandled block.");
        public static readonly Antlr4RoslynErrorCode ERR_ElementMap = new Antlr4RoslynErrorCode(9, DiagnosticSeverity.Error, "Invalid Roslyn element", "Cannot map this element in the block to a Roslyn rule. Create a separate rule from this element.");
        public static readonly Antlr4RoslynErrorCode ERR_Antlr4ToolError = new Antlr4RoslynErrorCode(10, DiagnosticSeverity.Error, "ANTLR4 tool error", "Running the ANTLR4 tool failed: {0}");
        public static readonly Antlr4RoslynErrorCode ERR_Antlr4Error = new Antlr4RoslynErrorCode(11, DiagnosticSeverity.Error, "ANTLR4 error", "ANTLR4 error: {0}");
        public static readonly Antlr4RoslynErrorCode WRN_Antlr4Warning = new Antlr4RoslynErrorCode(12, DiagnosticSeverity.Warning, "ANTLR4 warning", "ANTLR4 warning: {0}");
        public static readonly Antlr4RoslynErrorCode INF_Antlr4Info = new Antlr4RoslynErrorCode(13, DiagnosticSeverity.Info, "ANTLR4 info", "ANTLR4 info: {0}");
        public static readonly Antlr4RoslynErrorCode ERR_MainRuleMustEndWithEof = new Antlr4RoslynErrorCode(14, DiagnosticSeverity.Error, "Missing EOF", "The first rule (main rule) must end with EOF.");

        public Antlr4RoslynErrorCode(int code, DiagnosticSeverity defaultSeverity, string title, string messageFormat, bool isEnabledByDefault = true, string description = null, string helpLinkUri = null, params string[] customTags) 
            : base(code, MessagePrefix, title, messageFormat, Category, defaultSeverity, isEnabledByDefault, description, helpLinkUri, customTags)
        {
        }
    }
}
