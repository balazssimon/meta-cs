using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public class SymbolFacts
    {
        public virtual bool IsEntryPointCandidate(MethodSymbol method)
        {
            return false;
        }

    }
}
