using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Utilities;
using MetaDslx.Core;

namespace MetaDslx.Compiler.Binding.SymbolBinding
{
    /// <summary>
    /// A binder that knows no symbols and will not delegate further.
    /// </summary>
    public sealed class BuckStopsHereBinder : SymbolBinder
    {
        internal BuckStopsHereBinder(CompilationBase compilation)
            : base(compilation)
        {
        }

        public override OverloadResolution OverloadResolution => null;

        public override bool IsSubmissionClass => false;

        public override Conversions Conversions => null;

        public override bool IgnoreAccessibility => true;

        public override ISymbol ContainingSymbol => null;

    }
}
