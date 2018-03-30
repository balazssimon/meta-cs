using System;
using System.Collections.Generic;
using System.Text;
using MetaDslx.Compiler.Binding.Binders;
using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Utilities;
using MetaDslx.Core;

namespace MetaDslx.Compiler.Binding.MetaBinders
{
    public class MetaSymbolBinder : MetaBinder
    {
        private SymbolBinderPart<MetaBinder> _part;

        internal MetaSymbolBinder(MetaBinder next, RedNode node) : base(next, node)
        {
            _part = new SymbolBinderPart<MetaBinder>(this);
        }

        public override MetaBinder LookupSymbols(LookupResult result, string name, ConsList<ISymbol> basesBeingResolved, BindingOptions options, bool diagnose, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            return _part.LookupSymbols(result, name, basesBeingResolved, options, diagnose, ref useSiteDiagnostics);
        }

        public override MetaBinder LookupSymbolsWithFallback(LookupResult result, string name, ConsList<ISymbol> basesBeingResolved, BindingOptions options, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            return _part.LookupSymbolsWithFallback(result, name, basesBeingResolved, options, ref useSiteDiagnostics);
        }

        public override void AddLookupSymbolsInfo(ArrayBuilder<ISymbol> result, BindingOptions options)
        {
            _part.AddLookupSymbolsInfo(result, options);
        }
    }
}
