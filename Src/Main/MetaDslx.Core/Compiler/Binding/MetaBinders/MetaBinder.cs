using MetaDslx.Compiler.Binding.Binders;
using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Utilities;
using MetaDslx.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Compiler.Binding.MetaBinders
{
    public class MetaBinder : Binder<MetaBinder>, IImportBinder<MetaBinder>, ISymbolBinder<MetaBinder>, IMemberBinder<MetaBinder>, ITypeBinder<MetaBinder>
    {
        public MetaBinder(CompilationBase compilation) 
            : base(compilation)
        {
        }

        public MetaBinder(MetaBinder next, RedNode node) 
            : base(next, node)
        {
        }

        public virtual ISymbol ContainingSymbol => Next.ContainingSymbol;

        public virtual bool IgnoreAccessibility => Next.IgnoreAccessibility;

        public virtual OverloadResolution<MetaBinder> OverloadResolution => Next.OverloadResolution;

        public virtual Conversions<MetaBinder> Conversions => Next.Conversions;


        public virtual void AddLookupSymbolsInfo(ArrayBuilder<ISymbol> result, BindingOptions options)
        {
            Next.AddLookupSymbolsInfo(result, options);
        }

        public virtual void AddMemberLookupSymbolsInfo(ArrayBuilder<ISymbol> result, ISymbol container, BindingOptions options, MetaBinder originalBinder)
        {
            Next.AddMemberLookupSymbolsInfo(result, container, options, originalBinder);
        }

        public virtual Imports GetImports(ConsList<ISymbol> basesBeingResolved)
        {
            return Next.GetImports(basesBeingResolved);
        }

        public virtual bool IsAccessible(ISymbol symbol, ref HashSet<DiagnosticInfo> useSiteDiagnostics, ISymbol accessThroughType = null, ConsList<ISymbol> basesBeingResolved = null)
        {
            return Next.IsAccessible(symbol, ref useSiteDiagnostics, accessThroughType, basesBeingResolved);
        }

        public virtual bool IsAccessible(ISymbol symbol, ISymbol accessThroughType, out bool failedThroughTypeCheck, ref HashSet<DiagnosticInfo> useSiteDiagnostics, ConsList<ISymbol> basesBeingResolved = null)
        {
            return Next.IsAccessible(symbol, accessThroughType, out failedThroughTypeCheck, ref useSiteDiagnostics, basesBeingResolved);
        }

        public virtual void LookupMembers(LookupResult result, ISymbol qualifierOpt, string name, ConsList<ISymbol> basesBeingResolved, BindingOptions options, bool diagnose, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            Next.LookupMembers(result, qualifierOpt, name, basesBeingResolved, options, diagnose, ref useSiteDiagnostics);
        }

        public virtual void LookupMembersWithFallback(LookupResult result, ISymbol qualifierOpt, string name, ConsList<ISymbol> basesBeingResolved, BindingOptions options, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            Next.LookupMembersWithFallback(result, qualifierOpt, name, basesBeingResolved, options, ref useSiteDiagnostics);
        }

        public virtual MetaBinder LookupSymbols(LookupResult result, string name, ConsList<ISymbol> basesBeingResolved, BindingOptions options, bool diagnose, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            return Next.LookupSymbols(result, name, basesBeingResolved, options, diagnose, ref useSiteDiagnostics);
        }

        public virtual MetaBinder LookupSymbolsWithFallback(LookupResult result, string name, ConsList<ISymbol> basesBeingResolved, BindingOptions options, ref HashSet<DiagnosticInfo> useSiteDiagnostics)
        {
            return Next.LookupSymbolsWithFallback(result, name, basesBeingResolved, options, ref useSiteDiagnostics);
        }

        public virtual ISymbol UnwrapAlias(ISymbol alias, DiagnosticBag diagnostics, RedNode where)
        {
            return Next.UnwrapAlias(alias, diagnostics, where);
        }
    }
}
