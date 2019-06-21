﻿using MetaDslx.CodeAnalysis.Symbols;
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

        public override void LookupSymbolsInSingleBinder(LookupResult result, LookupConstraints constraints)
        {
            Debug.Assert(result.IsClear);

            if (Compilation.SourceAssembly.SpecialSymbolMap.TryGetValue(constraints.MetadataName, out Symbol specialSymbol))
            {
                result.SetFrom(LookupResult.Good(specialSymbol));
            }
        }

        protected override void AddLookupSymbolsInfoInSingleBinder(LookupSymbolsInfo result, LookupConstraints constraints)
        {
            foreach (var symbol in Compilation.SourceAssembly.SpecialSymbolMap.Values)
            {
                result.AddSymbol(symbol, symbol.Name, symbol.MetadataName);
            }
        }
    }
}
