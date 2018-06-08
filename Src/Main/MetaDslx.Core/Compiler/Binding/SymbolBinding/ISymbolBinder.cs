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
        new ISymbolBinder Parent { get; }

        bool IsSubmissionClass { get; }
        bool IgnoreAccessibility { get; }
        ISymbol ContainingSymbol { get; }
        OverloadResolution OverloadResolution { get; }
        Conversions Conversions { get; }

        /*
        ISymbol UnwrapAlias(ISymbol alias, DiagnosticBag diagnostics, RedNode where);

        Imports GetImports(ConsList<ISymbol> basesBeingResolved);

        ISymbolBinder LookupSymbols(LookupResult<ISymbol> result, string name, ConsList<ISymbol> basesBeingResolved, SymbolBindingOptions options, bool diagnose, ref HashSet<DiagnosticInfo> useSiteDiagnostics);
        ISymbolBinder LookupSymbolsWithFallback(LookupResult<ISymbol> result, string name, ConsList<ISymbol> basesBeingResolved, SymbolBindingOptions options, ref HashSet<DiagnosticInfo> useSiteDiagnostics);
        ISymbolBinder LookupSymbolsCore(LookupResult<ISymbol> result, string name, ConsList<ISymbol> basesBeingResolved, SymbolBindingOptions options, bool diagnose, ref HashSet<DiagnosticInfo> useSiteDiagnostics);
        void LookupSymbolsInSingleBinder(LookupResult<ISymbol> result, string name, ConsList<ISymbol> basesBeingResolved, SymbolBindingOptions options, ISymbolBinder originalBinder, bool diagnose, ref HashSet<DiagnosticInfo> useSiteDiagnostics);
        void AddLookupSymbolsInfo(ArrayBuilder<ISymbol> result, SymbolBindingOptions options);
        void AddLookupSymbolsInfoInSingleBinder(ArrayBuilder<ISymbol> result, SymbolBindingOptions options, ISymbolBinder originalBinder);

        bool IsAccessible(ISymbol symbol, ref HashSet<DiagnosticInfo> useSiteDiagnostics, ISymbol accessThroughType = null, ConsList<ISymbol> basesBeingResolved = null);
        bool IsAccessible(ISymbol symbol, ISymbol accessThroughType, out bool failedThroughTypeCheck, ref HashSet<DiagnosticInfo> useSiteDiagnostics, ConsList<ISymbol> basesBeingResolved = null);
        bool IsAccessibleHelper(ISymbol symbol, ISymbol accessThroughType, out bool failedThroughTypeCheck, ref HashSet<DiagnosticInfo> useSiteDiagnostics, ConsList<ISymbol> basesBeingResolved);

        void LookupMembers(LookupResult<ISymbol> result, ISymbol qualifierOpt, string name, ConsList<ISymbol> basesBeingResolved, SymbolBindingOptions options, bool diagnose, ref HashSet<DiagnosticInfo> useSiteDiagnostics);
        void LookupMembersWithFallback(LookupResult<ISymbol> result, ISymbol qualifierOpt, string name, ConsList<ISymbol> basesBeingResolved, SymbolBindingOptions options, ref HashSet<DiagnosticInfo> useSiteDiagnostics);
        void LookupMembersCore(LookupResult<ISymbol> result, ISymbol qualifierOpt, string name, ConsList<ISymbol> basesBeingResolved, SymbolBindingOptions options, ISymbolBinder originalBinder, bool diagnose, ref HashSet<DiagnosticInfo> useSiteDiagnostics);
        void AddMemberLookupSymbolsInfo(ArrayBuilder<ISymbol> result, ISymbol container, SymbolBindingOptions options, ISymbolBinder originalBinder);

        SingleLookupResult<ISymbol> CheckViability(ISymbol symbol, SymbolBindingOptions options, ISymbol accessThroughType, bool diagnose, ref HashSet<DiagnosticInfo> useSiteDiagnostics);
        */

        // Methods:
        bool GetImportsCore(LookupResult<Imports> result, ConsList<ISymbol> basesBeingResolved);
        bool LookupSymbolsCore(LookupResult<ISymbol> result, string name, SymbolBindingOptions options);
        bool LookupSymbolsCore(LookupResult<ISymbol> result, Qualifier qualifier, SymbolBindingOptions options);
        bool LookupMembersCore(LookupResult<ISymbol> result, ISymbol qualifierOpt, string name, SymbolBindingOptions options);

        bool IsAccessibleCore(LookupResult<bool> result, ISymbol symbol);
        bool AddLookupSymbolsInfoCore(LookupResult<ISymbol> result, SymbolBindingOptions options);
        bool AddMemberLookupSymbolsInfoCore(LookupResult<ISymbol> result, ISymbol container, SymbolBindingOptions options);

        // Inherited methods:
        Imports GetImports(ConsList<ISymbol> basesBeingResolved);
        void LookupSymbols(LookupResult<ISymbol> result, string name, SymbolBindingOptions options);
        void LookupSymbols(LookupResult<ISymbol> result, Qualifier qualifier, SymbolBindingOptions options);
        void LookupMembers(LookupResult<ISymbol> result, ISymbol qualifierOpt, string name, SymbolBindingOptions options);

        bool IsAccessible(ISymbol symbol);
        void AddLookupSymbolsInfo(LookupResult<ISymbol> result, SymbolBindingOptions options);
        void AddMemberLookupSymbolsInfo(LookupResult<ISymbol> result, ISymbol container, SymbolBindingOptions options);

        // Synthesized methods:

        // Properties:
        bool GetProperty(LookupResult<Property> result);
        bool GetName(LookupResult<Qualifier> result);
        bool GetQualifier(LookupResult<Qualifier> result);
        bool GetIdentifier(LookupResult<string> result);
        bool GetValue(LookupResult<object> result);
        bool GetSymbol(LookupResult<ISymbol> result);

        // Inherited properties:

        // Synthesized properties:
    }
}
