using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols.CodeGeneration
{
    public class SymbolMethodGenerationInfo : CompletionPartGenerationInfo
    {
        public SymbolMethodGenerationInfo(string name, CompleteMethodParameters completeMethodParameters, bool locked)
            : base(name, name, completeMethodParameters, false, locked)
        {
        }
    }
}
