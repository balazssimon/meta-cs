using MetaDslx.CodeAnalysis.Symbols;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding.Binders
{
    public class SpecialSymbolBinder : Binder
    {
        public SpecialSymbolBinder(Binder next, Conversions conversions = null) 
            : base(next, conversions)
        {
        }

        public override void LookupSymbolsInSingleBinder(LookupResult result, LookupConstraints constraints)
        {
            Debug.Assert(result.IsClear);

            var specialSymbol = Compilation.GetSpecialSymbol(constraints.MetadataName) as DeclaredSymbol;
            if (specialSymbol != null && specialSymbol.Kind != LanguageSymbolKind.ErrorType)
            {
                result.SetFrom(LookupResult.Good(specialSymbol));
            }
        }

        protected override void AddLookupSymbolsInfoInSingleBinder(LookupSymbolsInfo result, LookupConstraints constraints)
        {
            foreach (var symbol in Compilation.SourceAssembly.SpecialSymbols)
            {
                if (symbol is DeclaredSymbol ds)
                {
                    result.AddSymbol(ds, symbol.Name, symbol.MetadataName);
                }
            }
        }

    }
}
