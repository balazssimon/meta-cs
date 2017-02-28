using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Utilities;
using MetaDslx.Core;

namespace MetaDslx.Compiler.Binding.Binders
{
    /// <summary>
    /// A binder that knows no symbols and will not delegate further.
    /// </summary>
    public sealed class BuckStopsHereBinder : Binder
    {
        internal BuckStopsHereBinder(CompilationBase compilation)
            : base(compilation)
        {
        }

        public override ISymbol ContainingSymbol
        {
            get
            {
                return null;
            }
        }

        public override BindingOptions BindingOptions
        {
            get
            {
                return BindingOptions.Default;
            }
        }

        protected override bool IsAccessibleHelper(ISymbol symbol, ISymbol accessThroughType, out bool failedThroughTypeCheck, ref HashSet<DiagnosticInfo> useSiteDiagnostics, ConsList<ISymbol> basesBeingResolved)
        {
            failedThroughTypeCheck = false;
            return true;
        }
    }
}
