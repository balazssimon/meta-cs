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

        public override Conversions Conversions => null;

        public override bool IgnoreAccessibility => true;

        public override ISymbol ContainingSymbol => null;

        public override void AddLookupSymbolsInfo(ArrayBuilder<ISymbol> result, SymbolBindingOptions options)
        {
        }

        public override void AddMemberLookupSymbolsInfo(ArrayBuilder<ISymbol> result, ISymbol container, SymbolBindingOptions options, ISymbolBinder originalBinder)
        {
        }

        public override Imports GetImports(ConsList<ISymbol> basesBeingResolved)
        {
            return Imports.Empty;
        }

        public override bool IsAccessible(ISymbol symbol, ref HashSet<DiagnosticInfo> useSiteDiagnostics, ISymbol accessThroughType = null, ConsList<ISymbol> basesBeingResolved = null)
        {
            return false;
        }

        public override bool IsAccessible(ISymbol symbol, ISymbol accessThroughType, out bool failedThroughTypeCheck, ref HashSet<DiagnosticInfo> useSiteDiagnostics, ConsList<ISymbol> basesBeingResolved = null)
        {
            failedThroughTypeCheck = false;
            return false;
        }

        public override void LookupMembers(LookupResult result, ISymbol qualifierOpt, string name, ConsList<ISymbol> basesBeingResolved, SymbolBindingOptions options, bool diagnose, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
        }

        public override void LookupMembersWithFallback(LookupResult result, ISymbol qualifierOpt, string name, ConsList<ISymbol> basesBeingResolved, SymbolBindingOptions options, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
        }

        public override ISymbolBinder LookupSymbols(LookupResult result, string name, ConsList<ISymbol> basesBeingResolved, SymbolBindingOptions options, bool diagnose, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            return null;
        }

        public override ISymbolBinder LookupSymbolsWithFallback(LookupResult result, string name, ConsList<ISymbol> basesBeingResolved, SymbolBindingOptions options, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            return null;
        }

        public override ISymbol UnwrapAlias(ISymbol alias, DiagnosticBag diagnostics, RedNode where)
        {
            return null;
        }
    }
}
