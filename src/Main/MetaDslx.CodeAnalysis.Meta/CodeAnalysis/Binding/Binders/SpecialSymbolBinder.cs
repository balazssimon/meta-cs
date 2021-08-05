using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Collections.Immutable;

namespace MetaDslx.CodeAnalysis.Binding.Binders
{
    public class SpecialSymbolBinder : Binder
    {
        public SpecialSymbolBinder(Binder next, SyntaxNodeOrToken syntax) 
            : base(next, syntax)
        {
        }

        protected override void AddLookupCandidateSymbolsInScope(LookupCandidates result, LookupConstraints constraints)
        {
            //result.AddRange(Compilation.Language.SymbolFacts.SpecialSymbols);
        }
    }
}
