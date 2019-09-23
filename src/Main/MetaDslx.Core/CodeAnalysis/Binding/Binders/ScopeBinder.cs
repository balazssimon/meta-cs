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
        private NamespaceOrTypeSymbol _container;

        public ScopeBinder(Binder next, LanguageSyntaxNode syntax)
            : base(next)
        {
        }

        public NamespaceOrTypeSymbol Container
        {
            get
            {
                if (_container == null)
                {
                    var container = GetContainerScope(this.Next);
                    Interlocked.CompareExchange(ref _container, container, null);
                }
                return _container;
            }
        }

        public override NamespaceOrTypeSymbol ContainingSymbol
        {
            get
            {
                var merged = this.Container as MergedNamespaceSymbol;
                return ((object)merged != null) ? merged.GetConstituentForCompilation(this.Compilation) : this.Container;
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

        public override bool IsAccessibleHelper(Symbol symbol, TypeSymbol accessThroughType, out bool failedThroughTypeCheck, ref HashSet<DiagnosticInfo> useSiteDiagnostics, ConsList<TypeSymbol> basesBeingResolved)
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

            if (IsSubmission)
            {
                this.LookupMembersInternal(result, constraints.WithQualifier(this.Container));
                return;
            }

            // first lookup members of the namespace
            if ((constraints.Options & LookupOptions.NamespaceAliasesOnly) == 0 && this.Container != null)
            {
                this.LookupMembersInternal(result, constraints.WithQualifier(this.Container));
            }
        }

        protected override void AddLookupSymbolsInfoInSingleBinder(LookupSymbolsInfo result, LookupConstraints constraints)
        {
            if (this.Container != null)
            {
                this.AddMemberLookupSymbolsInfo(result, constraints.WithQualifier(this.Container));
            }
        }

        private static NamespaceOrTypeSymbol GetContainerScope(Binder binder)
        {
            /*var current = binder;
            while (current != null)
            {
                if (current is SymbolDefBinder symbolDefBinder)
                {
                    var result = symbolDefBinder.LastDeclaredSymbol as NamespaceOrTypeSymbol;
                    if (result != null) return result;
                    else break;
                }
                current = current.Next;
            }*/
            if (binder.ParentDeclarationSymbol is NamespaceOrTypeSymbol namespaceOrTypeSymbol) return namespaceOrTypeSymbol;
            else return (NamespaceOrTypeSymbol)binder.Compilation.CreateErrorNamespaceSymbol(binder.Compilation.GlobalNamespace, string.Empty);
        }

    }
}
