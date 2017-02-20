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

    public class RootBinder : BodyBinder, IRootBinder
    {
        public RootBinder(Binder next, RedNode node, IMetaSymbol container) 
            : base(next, node, container)
        {
        }

        protected override void LookupSymbolsInSingleBinder(LookupResult result, string name, ConsList<IMetaSymbol> basesBeingResolved, BindingOptions options, Binder originalBinder, bool diagnose, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            base.LookupSymbolsInSingleBinder(result, name, basesBeingResolved, options, originalBinder, diagnose, ref useSiteDiagnostics);
            if (result.IsClear)
            {
                IMetaSymbol symbol = this.Compilation.Language.CompilationFactory.GetWellKnownSymbol(name);
                if (symbol != null)
                {
                    result.MergeEqual(new SingleLookupResult(LookupResultKind.Viable, symbol, null));
                }
            }
        }
    }
}
