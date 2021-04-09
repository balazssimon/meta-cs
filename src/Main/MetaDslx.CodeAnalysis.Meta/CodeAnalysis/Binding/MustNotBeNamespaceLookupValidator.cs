using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Symbols.Source;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding
{
    public class MustNotBeNamespaceLookupValidator : ILookupValidator
    {
        public static readonly MustNotBeNamespaceLookupValidator Instance = new MustNotBeNamespaceLookupValidator();

        public void CheckFinalResultViability(LookupResult result, LookupConstraints constraints)
        {
           
        }

        public SingleLookupResult CheckSingleResultViability(SingleLookupResult result, AliasSymbol aliasSymbol, LookupConstraints constraints)
        {
            return result;
        }

        public bool IsViable(DeclaredSymbol symbol, LookupConstraints constraints)
        {
            return symbol.Kind != LanguageSymbolKind.Namespace;
        }
    }
}
