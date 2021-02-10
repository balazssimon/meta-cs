// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Symbols.Source;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Binding.Binders
{
    /// <summary>
    /// A binder that places the members of a symbol in scope.  If there is a container declaration
    /// with using directives, those are merged when looking up names.
    /// </summary>
    public class InContainerBinder : Binder
    {
        private readonly NamespaceOrTypeSymbol _container;
        private readonly Func<ConsList<TypeSymbol>, Imports> _computeImports;
        private Imports _lazyImports;
        private ImportChain _lazyImportChain;

        /// <summary>
        /// Creates a binder for a container with imports (usings and extern aliases) that can be
        /// retrieved from <paramref name="declarationSyntax"/>.
        /// </summary>
        public InContainerBinder(Binder next, NamespaceOrTypeSymbol container, LanguageSyntaxNode declarationSyntax, bool inUsing)
            : base(next, null)
        {
            Debug.Assert((object)container != null);
            Debug.Assert(declarationSyntax != null);

            _container = container;
            _computeImports = basesBeingResolved => Imports.FromSyntax(declarationSyntax, this, basesBeingResolved, inUsing);
        }

        /// <summary>
        /// Creates a binder with given imports.
        /// </summary>
        public InContainerBinder(NamespaceOrTypeSymbol container, Binder next, Imports imports = null)
            : base(next, null, null)
        {
            Debug.Assert((object)container != null || imports != null);

            _container = container;
            _lazyImports = imports ?? Imports.Empty;
        }

        /// <summary>
        /// Creates a binder with given import computation function.
        /// </summary>
        public InContainerBinder(Binder next, Func<ConsList<TypeSymbol>, Imports> computeImports)
            : base(next, null, null)
        {
            Debug.Assert(computeImports != null);

            _container = null;
            _computeImports = computeImports;
        }

        public NamespaceOrTypeSymbol Container
        {
            get
            {
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
                    if ((object)_container == null || _container.Kind == LanguageSymbolKind.Namespace)
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
                var merged = _container as MergedNamespaceSymbol;
                return ((object)merged != null) ? merged.GetConstituentForCompilation(this.Compilation) : _container;
            }
        }

        private bool IsSubmission
        {
            get { return (_container?.Kind == LanguageSymbolKind.NamedType) && ((NamedTypeSymbol)_container).IsSubmission; }
        }

        private bool IsScript
        {
            get { return (_container?.Kind == LanguageSymbolKind.NamedType) && ((NamedTypeSymbol)_container).IsScript; }
        }

        public override bool IsAccessibleHelper(DeclaredSymbol symbol, TypeSymbol accessThroughType, out bool failedThroughTypeCheck, ref HashSet<DiagnosticInfo> useSiteDiagnostics, ConsList<TypeSymbol> basesBeingResolved)
        {
            var type = _container as NamedTypeSymbol;
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
                this.LookupMembersInternal(result, constraints.WithQualifier(_container));
                return;
            }

            var imports = GetImports(constraints.BasesBeingResolved);

            // first lookup members of the namespace
            if ((constraints.Options & LookupOptions.NamespaceAliasesOnly) == 0 && _container != null)
            {
                this.LookupMembersInternal(result, constraints.WithQualifier(_container));

                if (result.IsMultiViable)
                {
                    // symbols cannot conflict with using alias names
                    if (constraints.MetadataName == constraints.Name && imports.IsUsingAlias(constraints.Name, constraints.OriginalBinder.IsSemanticModelBinder))
                    {
                        LanguageDiagnosticInfo diagInfo = new LanguageDiagnosticInfo(InternalErrorCode.ERR_ConflictAliasAndMember, constraints.Name, _container);
                        var error = new ExtendedErrorTypeSymbol((NamespaceOrTypeSymbol)null, constraints.Name, constraints.MetadataName, diagInfo, unreported: true);
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
            if (_container != null)
            {
                this.AddMemberLookupSymbolsInfo(result, constraints.WithQualifier(_container));
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
