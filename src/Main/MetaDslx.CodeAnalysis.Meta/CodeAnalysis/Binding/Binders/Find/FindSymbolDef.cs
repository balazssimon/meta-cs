using MetaDslx.CodeAnalysis.Symbols;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding.Binders.Find
{
    public class FindSymbolDef : FindBinderAncestors<SymbolDefBinder>
    {
        private Symbol _symbol;

        public FindSymbolDef(BinderPosition origin, Symbol symbol)
            : base(origin)
        {
            _symbol = symbol;
        }

        public override bool IsValidBinder(SymbolDefBinder binder)
        {
            return binder.DefinedSymbol == _symbol;
        }

        public override bool IsSearchBoundary(Binder binder)
        {
            return Results.Count > 0;
        }
    }
}
