using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Symbols.Source;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding
{
    public class NamespaceOrTypeLookupValidator : ILookupValidator
    {
        public void CheckFinalResultViability(LookupResult result, LookupConstraints constraints)
        {
            
        }

        public SingleLookupResult CheckSingleResultViability(SingleLookupResult result, AliasSymbol aliasSymbol, LookupConstraints constraints)
        {
            var symbol = result.Symbol;
            if (!(symbol is NamespaceOrTypeSymbol))
            {
                return LookupResult.NotTypeOrNamespace(symbol, aliasSymbol, true);
            }
            return result;
        }

        public bool IsViable(DeclaredSymbol symbol, LookupConstraints constraints)
        {
            return true;
        }
    }
}
