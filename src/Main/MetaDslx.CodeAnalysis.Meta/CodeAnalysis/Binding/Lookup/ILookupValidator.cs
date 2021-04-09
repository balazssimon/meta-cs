using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Symbols.Source;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding
{
    public interface ILookupValidator
    {
        bool IsViable(DeclaredSymbol symbol, LookupConstraints constraints);
        SingleLookupResult CheckSingleResultViability(SingleLookupResult result, AliasSymbol aliasSymbol, LookupConstraints constraints);
        void CheckFinalResultViability(LookupResult result, LookupConstraints constraints);
    }
}
