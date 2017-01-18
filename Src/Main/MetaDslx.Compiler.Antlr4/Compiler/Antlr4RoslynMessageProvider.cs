using MetaDslx.Compiler.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Core;

namespace MetaDslx.Compiler.Antlr4Roslyn
{
    public class Antlr4RoslynMessageProvider : MessageProvider
    {
        public static readonly Antlr4RoslynMessageProvider Instance = new Antlr4RoslynMessageProvider();

        public override string CodePrefix
        {
            get
            {
                return "AR";
            }
        }

        public override string GetMessageFormat(int code)
        {
            switch ((Antlr4RoslynErrors)code)
            {
                case Antlr4RoslynErrors.ERR_SyntaxError:
                    return "Syntax error: {0}";
                case Antlr4RoslynErrors.ERR_UnnamedElement:
                    return "Element '{0}' must have a name. Elements with the same type in a rule must have different names.";
                case Antlr4RoslynErrors.ERR_UnnamedBlock:
                    return "This block must have a name.";
                case Antlr4RoslynErrors.ERR_RuleMapUnnamedAlt:
                    return "Rule '{0}' cannot be mapped to Roslyn. Give labels to the alternatives.";
                case Antlr4RoslynErrors.ERR_RuleMapTooComplex:
                    return "Rule '{0}' cannot be mapped to Roslyn. Consider simplifying it by breaking it up to smaller rules.";
                case Antlr4RoslynErrors.ERR_BlockMap:
                    return "This block cannot be mapped to Roslyn. Create a separate rule from the block.";
                case Antlr4RoslynErrors.ERR_BlockMapSuffix:
                    return "A block cannot have a '*' or '+' suffix. Create a separate rule from the block.";
                case Antlr4RoslynErrors.ERR_BlockUnhandled:
                    return "Unhandled block.";
                case Antlr4RoslynErrors.ERR_ElementMap:
                    return "Cannot map this element in the block to a Roslyn rule. Create a separate rule from this element.";
                default:
                    throw new ArgumentOutOfRangeException(nameof(code));
            }
        }

        public override DiagnosticSeverity GetSeverity(int code)
        {
            switch ((Antlr4RoslynErrors)code)
            {
                case Antlr4RoslynErrors.ERR_SyntaxError:
                case Antlr4RoslynErrors.ERR_UnnamedElement:
                case Antlr4RoslynErrors.ERR_UnnamedBlock:
                case Antlr4RoslynErrors.ERR_RuleMapUnnamedAlt:
                case Antlr4RoslynErrors.ERR_RuleMapTooComplex:
                case Antlr4RoslynErrors.ERR_BlockMap:
                case Antlr4RoslynErrors.ERR_BlockMapSuffix:
                case Antlr4RoslynErrors.ERR_BlockUnhandled:
                case Antlr4RoslynErrors.ERR_ElementMap:
                    return DiagnosticSeverity.Error;
                default:
                    throw new ArgumentOutOfRangeException(nameof(code));
            }
        }

        public override int GetWarningLevel(int code)
        {
            switch ((Antlr4RoslynErrors)code)
            {
                case Antlr4RoslynErrors.ERR_SyntaxError:
                case Antlr4RoslynErrors.ERR_UnnamedElement:
                case Antlr4RoslynErrors.ERR_UnnamedBlock:
                case Antlr4RoslynErrors.ERR_RuleMapUnnamedAlt:
                case Antlr4RoslynErrors.ERR_RuleMapTooComplex:
                case Antlr4RoslynErrors.ERR_BlockMap:
                case Antlr4RoslynErrors.ERR_BlockMapSuffix:
                case Antlr4RoslynErrors.ERR_BlockUnhandled:
                case Antlr4RoslynErrors.ERR_ElementMap:
                    return 0;
                default:
                    throw new ArgumentOutOfRangeException(nameof(code));
            }
        }

        public Diagnostic CreateDiagnostic(Antlr4RoslynErrors code, Location location)
        {
            return this.CreateDiagnostic((int)code, location);
        }

        public Diagnostic CreateDiagnostic(Antlr4RoslynErrors code, Location location, params object[] args)
        {
            return this.CreateDiagnostic((int)code, location, args);
        }
    }
}
