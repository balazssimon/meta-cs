using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Antlr4Roslyn
{
    public enum Antlr4RoslynErrors
    {
        ERR_SyntaxError,
        ERR_UnnamedElement,
        ERR_UnnamedBlock,
        ERR_RuleMapUnnamedAlt,
        ERR_RuleMapTooComplex,
        ERR_BlockMap,
        ERR_BlockMapSuffix,
        ERR_BlockUnhandled,
        ERR_ElementMap,
    }
}
