using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Symbols.Source;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding
{
    public class NamespaceOrTypeLookupValidator : ILookupValidator
    {
        public static readonly NamespaceOrTypeLookupValidator Instance = new NamespaceOrTypeLookupValidator();

        public void CheckFinalResultViability(LookupResult result, LookupConstraints constraints)
        {
            
        }

        public SingleLookupResult CheckSingleResultViability(SingleLookupResult result, AliasSymbol aliasSymbol, LookupConstraints constraints)
        {
            return result;
        }

        public bool IsViable(DeclaredSymbol symbol, LookupConstraints constraints)
        {
            return symbol is NamespaceOrTypeSymbol;
        }
    }
}
