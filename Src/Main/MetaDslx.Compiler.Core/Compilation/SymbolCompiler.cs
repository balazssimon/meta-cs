using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Core;

namespace MetaDslx.Compiler
{
    public class SymbolCompiler
    {
        internal static void CompileSymbols(CompilationBase compilation, object moduleBeingBuiltOpt, bool hasDeclarationErrors, DiagnosticBag diagnostics, Func<IMetaSymbol, bool> filterOpt, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
