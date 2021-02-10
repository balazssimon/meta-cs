using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Binding.Binders
{
    public class ScopeBinder : Binder
    {
        private DeclaredSymbol _container;

        public ScopeBinder(Binder next, SyntaxNodeOrToken syntax)
            : base(next, syntax)
        {
        }

        public DeclaredSymbol Container
        {
            get
            {
                if (_container == null)
                {
                    Binder binder = this.Next;
                    var container = this.GetDefinedSymbol() as DeclaredSymbol;
                    while (binder != null && container == null)
                    {
                        container = binder.GetDefinedSymbol() as DeclaredSymbol;
                        binder = binder.Next;
                    }
                    Interlocked.CompareExchange(ref _container, container, null);
                }
                return _container;
            }
        }

        public override DeclaredSymbol ContainingDeclaration
        {
            get
            {
                var merged = this.Container as MergedNamespaceSymbol;
                return ((object)merged != null) ? merged.GetConstituentForCompilation(this.Compilation) : this.Container as NamespaceOrTypeSymbol;
            }
        }

        private bool IsSubmission
        {
            get { return (this.Container?.Kind == LanguageSymbolKind.NamedType) && ((NamedTypeSymbol)this.Container).IsSubmission; }
        }

        private bool IsScript
        {
            get { return (this.Container?.Kind == LanguageSymbolKind.NamedType) && ((NamedTypeSymbol)this.Container).IsScript; }
        }

        public override bool IsAccessibleHelper(DeclaredSymbol symbol, TypeSymbol accessThroughType, out bool failedThroughTypeCheck, ref HashSet<DiagnosticInfo> useSiteDiagnostics, ConsList<TypeSymbol> basesBeingResolved)
        {
            var type = this.Container as NamedTypeSymbol;
            if ((object)type != null)
            {
                return this.IsSymbolAccessibleConditional(symbol, type, accessThroughType, out failedThroughTypeCheck, ref useSiteDiagnostics);
            }
            else
            {
                return Next.IsAccessibleHelper(symbol, accessThroughType, out failedThroughTypeCheck, ref useSiteDiagnostics, basesBeingResolved);  // delegate to containing Binder, eventually checking assembly.
            }
        }


        public override void LookupSymbolsInSingleBinder(LookupResult result, LookupConstraints constraints)
        {
            Debug.Assert(result.IsClear);

            if (this.ContainingSymbol == null) return;

            if (IsSubmission)
            {
                this.LookupMembersInternal(result, constraints.WithQualifier(this.Container));
                return;
            }

            // first lookup members of the namespace
            if ((constraints.Options & LookupOptions.NamespaceAliasesOnly) == 0)
            {
                this.LookupMembersInternal(result, constraints.WithQualifier(this.Container));
            }
        }

        protected override void AddLookupSymbolsInfoInSingleBinder(LookupSymbolsInfo result, LookupConstraints constraints)
        {
            if (this.ContainingSymbol != null)
            {
                this.AddMemberLookupSymbolsInfo(result, constraints.WithQualifier(this.Container));
            }
        }

    }
}
