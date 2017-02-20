using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Utilities;
using MetaDslx.Core;
using MetaDslx.Compiler.Binding.Binders;

namespace MetaDslx.Compiler.Binding
{
    /// <summary>
    /// Represents symbols imported to the binding scope via using namespace, using alias, and extern alias.
    /// </summary>
    [DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
    public sealed class Imports
    {
        public static readonly Imports Empty = new Imports();

        public static Imports FromGlobalUsings(CompilationBase compilationBase)
        {
            return Imports.Empty;
        }

        public static Imports ExpandPreviousSubmissionImports(Imports imports, CompilationBase compilationBase)
        {
            return imports;
        }

        public Imports Concat(Imports imports)
        {
            return this;
        }

        internal void Complete(CancellationToken cancellationToken)
        {
            
        }

        internal void AddLookupSymbolsInfo(ArrayBuilder<IMetaSymbol> result, BindingOptions options, Binder originalBinder)
        {
            
        }

        internal void LookupSymbol(Binder originalBinder, LookupResult result, string name, ConsList<IMetaSymbol> basesBeingResolved, BindingOptions options, bool diagnose, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            
        }
    }
}
