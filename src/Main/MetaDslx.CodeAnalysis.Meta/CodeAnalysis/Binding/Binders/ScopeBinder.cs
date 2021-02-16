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
        private readonly Func<ConsList<TypeSymbol>, Imports> _computeImports;
        private Imports _lazyImports;
        private ImportChain _lazyImportChain;

        public ScopeBinder(Binder next, SyntaxNodeOrToken syntax)
            : base(next, syntax)
        {
            Debug.Assert(!syntax.IsNull);
        }

        /// <summary>
        /// Creates a binder for a container with imports (usings and extern aliases) that can be
        /// retrieved from <paramref name="declarationSyntax"/>.
        /// </summary>
        public ScopeBinder(Binder next, DeclaredSymbol container, SyntaxNodeOrToken syntax, bool inUsing)
            : base(next, null)
        {
            Debug.Assert((object)container != null);
            Debug.Assert(syntax != null);

            _container = container;
            _computeImports = basesBeingResolved => Imports.FromSyntax(syntax, container, this, basesBeingResolved, inUsing);
        }

        /// <summary>
        /// Creates a binder with given imports.
        /// </summary>
        public ScopeBinder(DeclaredSymbol container, Binder next, Imports imports = null)
            : base(next, null, null)
        {
            Debug.Assert((object)container != null || imports != null);

            _container = container;
            _lazyImports = imports ?? Imports.Empty;
        }

        /// <summary>
        /// Creates a binder with given import computation function.
        /// </summary>
        public ScopeBinder(Binder next, Func<ConsList<TypeSymbol>, Imports> computeImports)
            : base(next, null, null)
        {
            Debug.Assert(computeImports != null);

            _container = null;
            _computeImports = computeImports;
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

        public override Imports GetImports(ConsList<TypeSymbol> basesBeingResolved)
        {
            Debug.Assert(_lazyImports != null || _computeImports != null, "Have neither imports nor a way to compute them.");

            if (_lazyImports == null)
            {
                Interlocked.CompareExchange(ref _lazyImports, _computeImports(basesBeingResolved), null);
            }

            return _lazyImports;
        }

        public override ImportChain ImportChain
        {
            get
            {
                if (_lazyImportChain == null)
                {
                    ImportChain importChain = this.Next.ImportChain;
                    if ((object)Container == null || Container.Kind == LanguageSymbolKind.Namespace)
                    {
                        importChain = new ImportChain(GetImports(basesBeingResolved: null), importChain);
                    }

                    Interlocked.CompareExchange(ref _lazyImportChain, importChain, null);
                }

                Debug.Assert(_lazyImportChain != null);

                return _lazyImportChain;
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
