using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis;
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
            Debug.Assert(!syntax.IsNull);
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
                var merged = Container as MergedNamespaceSymbol;
                return ((object)merged != null) ? merged.GetConstituentForCompilation(this.Compilation) : Container;
            }
        }

        private bool IsSubmission
        {
            get { return (Container?.Kind == LanguageSymbolKind.NamedType) && ((NamedTypeSymbol)Container).IsSubmission; }
        }

        private bool IsScript
        {
            get { return (Container?.Kind == LanguageSymbolKind.NamedType) && ((NamedTypeSymbol)Container).IsScript; }
        }

        public override bool IsAccessibleHelper(DeclaredSymbol symbol, TypeSymbol accessThroughType, out bool failedThroughTypeCheck, ref HashSet<DiagnosticInfo> useSiteDiagnostics, ConsList<TypeSymbol> basesBeingResolved)
        {
            var type = Container as NamedTypeSymbol;
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
                this.LookupMembersInternal(result, constraints.WithQualifier(Container));
                return;
            }

            var imports = GetImports(constraints.BasesBeingResolved);

            // first lookup members of the namespace
            if ((constraints.Options & LookupOptions.NamespaceAliasesOnly) == 0 && Container != null)
            {
                this.LookupMembersInternal(result, constraints.WithQualifier(Container));

                if (result.IsMultiViable)
                {
                    // symbols cannot conflict with using alias names
                    if (constraints.MetadataName == constraints.Name && imports.IsUsingAlias(constraints.Name, constraints.OriginalBinder.IsSemanticModelBinder))
                    {
                        LanguageDiagnosticInfo diagInfo = new LanguageDiagnosticInfo(InternalErrorCode.ERR_ConflictAliasAndMember, constraints.Name, Container);
                        var error = new ExtendedErrorTypeSymbol((DeclaredSymbol)null, constraints.Name, constraints.MetadataName, diagInfo, unreported: true);
                        result.SetFrom(LookupResult.Good(error)); // force lookup to be done w/ error symbol as result
                    }

                    return;
                }
            }

            // next try using aliases or symbols in imported namespaces
            imports.LookupSymbol(result, constraints);
        }

        protected override void AddLookupSymbolsInfoInSingleBinder(LookupSymbolsInfo result, LookupConstraints constraints)
        {
            if (Container != null)
            {
                this.AddMemberLookupSymbolsInfo(result, constraints.WithQualifier(Container));
            }

            // If we are looking only for labels we do not need to search through the imports.
            // Submission imports are handled by AddMemberLookupSymbolsInfo (above).
            if (!IsSubmission && ((constraints.Options & LookupOptions.LabelsOnly) == 0))
            {
                var imports = GetImports(basesBeingResolved: null);
                imports.AddLookupSymbolsInfo(result, constraints);
            }
        }


    }
}
