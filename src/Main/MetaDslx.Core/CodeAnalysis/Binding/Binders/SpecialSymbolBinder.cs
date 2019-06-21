using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis;
using Roslyn.Utilities;
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

        public override void LookupSymbolsInSingleBinder(
            LookupResult result, string name, string metadataName, ConsList<TypeSymbol> basesBeingResolved, LookupOptions options, Binder originalBinder, bool diagnose, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            Debug.Assert(result.IsClear);

            if (Compilation.SourceAssembly.SpecialSymbolMap.TryGetValue(metadataName, out Symbol specialSymbol))
            {
                result.SetFrom(LookupResult.Good(specialSymbol));
            }
        }

        protected override void AddLookupSymbolsInfoInSingleBinder(LookupSymbolsInfo result, LookupOptions options, Binder originalBinder)
        {
            foreach (var symbol in Compilation.SourceAssembly.SpecialSymbolMap.Values)
            {
                result.AddSymbol(symbol, symbol.Name, symbol.MetadataName);
            }
        }
    }
}
