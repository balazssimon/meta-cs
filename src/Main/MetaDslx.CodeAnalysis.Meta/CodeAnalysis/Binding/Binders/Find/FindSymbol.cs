using MetaDslx.CodeAnalysis.Symbols;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding.Binders.Find
{
    public class FindSymbol : FindBinderAncestors<SymbolBinder>
    {
        private Symbol _symbol;

        public FindSymbol(BinderPosition origin, Symbol symbol)
            : base(origin)
        {
            _symbol = symbol;
        }

        public override bool IsValidBinder(SymbolBinder binder)
        {
            return binder.DefinedSymbols.Contains(_symbol);
        }

        public override bool IsSearchBoundary(Binder binder)
        {
            return Results.Count > 0;
        }
    }
}
