using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Analyzers.Symbols
{
    public class SymbolMethodGenerationInfo : CompletionPartGenerationInfo
    {
        public SymbolMethodGenerationInfo(string containingTypeFullName, string name, CompleteMethodParameters completeMethodParameters, bool locked)
            : base(containingTypeFullName, name, name, completeMethodParameters, false, locked)
        {
        }
    }
}
