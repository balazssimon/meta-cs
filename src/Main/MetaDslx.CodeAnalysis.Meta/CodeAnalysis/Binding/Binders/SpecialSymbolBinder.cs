using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding.Binders
{
    public class SpecialSymbolBinder : Binder
    {
        public SpecialSymbolBinder(Binder next, SyntaxNodeOrToken syntax) 
            : base(next, syntax)
        {
        }

        protected override void AddLookupCandidateSymbolsInSingleBinder(LookupCandidates result, LookupConstraints constraints)
        {
            foreach (var symbol in Compilation.SourceAssembly.DeclaredSpecialSymbols)
            {
                if (symbol is DeclaredSymbol ds)
                {
                    if (constraints.IsViable(ds)) result.Add(ds);
                }
            }
        }

    }
}
