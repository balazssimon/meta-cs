using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Symbols.Metadata;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding
{
    public class MustBeModelObjectLookupValidator : ILookupValidator
    {
        public void CheckFinalResultViability(LookupResult result, LookupConstraints constraints)
        {
        }

        public SingleLookupResult CheckSingleResultViability(SingleLookupResult result, AliasSymbol aliasSymbol, LookupConstraints constraints)
        {
            var symbol = result.Symbol;
            if (symbol is not IModelSymbol)
            {
                return LookupResult.WrongSymbol(symbol, aliasSymbol, ImmutableArray.Create(typeof(IModelSymbol)), true);
            }
            return result;
        }

        public bool IsViable(DeclaredSymbol symbol, LookupConstraints constraints)
        {
            return symbol is IModelSymbol;
        }
    }
}
