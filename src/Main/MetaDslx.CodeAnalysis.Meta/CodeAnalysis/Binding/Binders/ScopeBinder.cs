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
        private DeclaredSymbol _declaredSymbol;

        public ScopeBinder(Binder next, LanguageSyntaxNode syntax)
            : base(next)
        {
        }

        public DeclaredSymbol DeclaredSymbol
        {
            get
            {
                if (_declaredSymbol == null)
                {
                    var container = this.GetDeclarationSymbol();
                    Interlocked.CompareExchange(ref _declaredSymbol, container, null);
                }
                return _declaredSymbol;
            }
        }

        public override NamespaceOrTypeSymbol ContainingSymbol
        {
            get
            {
                var merged = this.DeclaredSymbol as MergedNamespaceSymbol;
                return ((object)merged != null) ? merged.GetConstituentForCompilation(this.Compilation) : this.DeclaredSymbol as NamespaceOrTypeSymbol;
            }
        }

        private bool IsSubmission
        {
            get { return (this.DeclaredSymbol?.Kind == LanguageSymbolKind.NamedType) && ((NamedTypeSymbol)this.DeclaredSymbol).IsSubmission; }
        }

        private bool IsScript
        {
            get { return (this.DeclaredSymbol?.Kind == LanguageSymbolKind.NamedType) && ((NamedTypeSymbol)this.DeclaredSymbol).IsScript; }
        }

        public override bool IsAccessibleHelper(Symbol symbol, TypeSymbol accessThroughType, out bool failedThroughTypeCheck, ref HashSet<DiagnosticInfo> useSiteDiagnostics, ConsList<TypeSymbol> basesBeingResolved)
        {
            var type = this.DeclaredSymbol as NamedTypeSymbol;
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
                this.LookupMembersInternal(result, constraints.WithQualifier(this.ContainingSymbol));
                return;
            }

            // first lookup members of the namespace
            if ((constraints.Options & LookupOptions.NamespaceAliasesOnly) == 0)
            {
                this.LookupMembersInternal(result, constraints.WithQualifier(this.ContainingSymbol));
            }
        }

        protected override void AddLookupSymbolsInfoInSingleBinder(LookupSymbolsInfo result, LookupConstraints constraints)
        {
            if (this.ContainingSymbol != null)
            {
                this.AddMemberLookupSymbolsInfo(result, constraints.WithQualifier(this.ContainingSymbol));
            }
        }

    }
}
