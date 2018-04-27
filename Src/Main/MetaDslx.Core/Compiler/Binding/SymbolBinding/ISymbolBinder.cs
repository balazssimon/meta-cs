using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Utilities;
using MetaDslx.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Compiler.Binding.SymbolBinding
{
    public interface ISymbolBinder : IBinder
    {
        new ISymbolBinder Next { get; }

        bool IsSubmissionClass { get; }
        bool IgnoreAccessibility { get; }
        ISymbol ContainingSymbol { get; }
        OverloadResolution OverloadResolution { get; }
        Conversions Conversions { get; }

        Optional<ISymbol> GetSymbol();
        Optional<object> GetValue();

        ISymbol UnwrapAlias(ISymbol alias, DiagnosticBag diagnostics, RedNode where);

        Imports GetImports(ConsList<ISymbol> basesBeingResolved);

        ISymbolBinder LookupSymbols(LookupResult result, string name, ConsList<ISymbol> basesBeingResolved, SymbolBindingOptions options, bool diagnose, ref HashSet<DiagnosticInfo> useSiteDiagnostics);
        ISymbolBinder LookupSymbolsWithFallback(LookupResult result, string name, ConsList<ISymbol> basesBeingResolved, SymbolBindingOptions options, ref HashSet<DiagnosticInfo> useSiteDiagnostics);
        ISymbolBinder LookupSymbolsCore(LookupResult result, string name, ConsList<ISymbol> basesBeingResolved, SymbolBindingOptions options, bool diagnose, ref HashSet<DiagnosticInfo> useSiteDiagnostics);
        void LookupSymbolsInSingleBinder(LookupResult result, string name, ConsList<ISymbol> basesBeingResolved, SymbolBindingOptions options, ISymbolBinder originalBinder, bool diagnose, ref HashSet<DiagnosticInfo> useSiteDiagnostics);
        void AddLookupSymbolsInfo(ArrayBuilder<ISymbol> result, SymbolBindingOptions options);
        void AddLookupSymbolsInfoInSingleBinder(ArrayBuilder<ISymbol> result, SymbolBindingOptions options, ISymbolBinder originalBinder);

        bool IsAccessible(ISymbol symbol, ref HashSet<DiagnosticInfo> useSiteDiagnostics, ISymbol accessThroughType = null, ConsList<ISymbol> basesBeingResolved = null);
        bool IsAccessible(ISymbol symbol, ISymbol accessThroughType, out bool failedThroughTypeCheck, ref HashSet<DiagnosticInfo> useSiteDiagnostics, ConsList<ISymbol> basesBeingResolved = null);
        bool IsAccessibleHelper(ISymbol symbol, ISymbol accessThroughType, out bool failedThroughTypeCheck, ref HashSet<DiagnosticInfo> useSiteDiagnostics, ConsList<ISymbol> basesBeingResolved);

        void LookupMembers(LookupResult result, ISymbol qualifierOpt, string name, ConsList<ISymbol> basesBeingResolved, SymbolBindingOptions options, bool diagnose, ref HashSet<DiagnosticInfo> useSiteDiagnostics);
        void LookupMembersWithFallback(LookupResult result, ISymbol qualifierOpt, string name, ConsList<ISymbol> basesBeingResolved, SymbolBindingOptions options, ref HashSet<DiagnosticInfo> useSiteDiagnostics);
        void LookupMembersCore(LookupResult result, ISymbol qualifierOpt, string name, ConsList<ISymbol> basesBeingResolved, SymbolBindingOptions options, ISymbolBinder originalBinder, bool diagnose, ref HashSet<DiagnosticInfo> useSiteDiagnostics);
        void AddMemberLookupSymbolsInfo(ArrayBuilder<ISymbol> result, ISymbol container, SymbolBindingOptions options, ISymbolBinder originalBinder);

        SingleLookupResult CheckViability(ISymbol symbol, SymbolBindingOptions options, ISymbol accessThroughType, bool diagnose, ref HashSet<DiagnosticInfo> useSiteDiagnostics);

        bool AddNameBinder(ArrayBuilder<ISymbolBinder> result);
        bool AddPropertyBinder(ArrayBuilder<ISymbolBinder> result);
        bool AddValueBinder(ArrayBuilder<ISymbolBinder> result);
        bool AddIdentifierBinder(ArrayBuilder<ISymbolBinder> result);
    }
}
