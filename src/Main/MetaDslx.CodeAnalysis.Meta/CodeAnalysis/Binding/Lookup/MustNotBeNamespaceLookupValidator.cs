using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Symbols.Source;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding
{
    public class MustNotBeNamespaceLookupValidator : ILookupValidator
    {
        public void CheckFinalResultViability(LookupResult result, LookupConstraints constraints)
        {
           
        }

        public SingleLookupResult CheckSingleResultViability(SingleLookupResult result, AliasSymbol aliasSymbol, LookupConstraints constraints)
        {
            var symbol = result.Symbol;
            if (symbol.Kind == LanguageSymbolKind.Namespace)
            {
                return LookupResult.StaticInstanceMismatch(symbol, new LanguageDiagnosticInfo(InternalErrorCode.ERR_BadSKunknown, symbol, symbol.GetKindText()));
            }
            return result;
        }

        public bool IsViable(DeclaredSymbol symbol, LookupConstraints constraints)
        {
            return true;
        }
    }
}
