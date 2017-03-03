using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Core;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Utilities;

namespace MetaDslx.Compiler.Binding.Binders
{
    public interface IRootBinder : IBodyBinder
    {

    }

    public class RootBinder : ScopeBinder, IRootBinder
    {
        public RootBinder(Binder next, RedNode node, ISymbol container) 
            : base(next, node, container)
        {
        }

        protected override void LookupSymbolsInSingleBinder(LookupResult result, string name, ConsList<ISymbol> basesBeingResolved, BindingOptions options, Binder originalBinder, bool diagnose, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            base.LookupSymbolsInSingleBinder(result, name, basesBeingResolved, options, originalBinder, diagnose, ref useSiteDiagnostics);
            if (result.IsClear)
            {
                ISymbol symbol = this.Compilation.SymbolResolution.GetWellKnownSymbol(name);
                if (symbol != null)
                {
                    result.MergeEqual(new SingleLookupResult(LookupResultKind.Viable, symbol, null));
                }
            }
        }
    }
}
