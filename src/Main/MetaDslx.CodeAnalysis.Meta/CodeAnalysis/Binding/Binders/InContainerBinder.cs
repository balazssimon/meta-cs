// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Symbols.Source;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.PooledObjects;
using Roslyn.Utilities;
using System.Collections.Immutable;

namespace MetaDslx.CodeAnalysis.Binding.Binders
{
    /// <summary>
    /// A binder that places the members of a symbol in scope.  If there is a container declaration
    /// with using directives, those are merged when looking up names.
    /// </summary>
    public class InContainerBinder : Binder
    {
        private readonly DeclaredSymbol _container;
        private readonly Func<ConsList<TypeSymbol>, Imports> _computeImports;
        private Imports _lazyImports;
        private ImportChain _lazyImportChain;

        /// <summary>
        /// Creates a binder for a container with imports (usings and extern aliases) that can be
        /// retrieved from <paramref name="declarationSyntax"/>.
        /// </summary>
        public InContainerBinder(Binder next, DeclaredSymbol container, LanguageSyntaxNode declarationSyntax, bool inUsing)
            : base(next, null)
        {
            Debug.Assert((object)container != null);
            Debug.Assert(declarationSyntax != null);

            _container = container;
            _computeImports = basesBeingResolved => Imports.FromSyntax(declarationSyntax, container, this, basesBeingResolved, inUsing);
        }

        /// <summary>
        /// Creates a binder with given imports.
        /// </summary>
        public InContainerBinder(DeclaredSymbol container, Binder next, Imports imports = null)
            : base(next, null)
        {
            Debug.Assert((object)container != null || imports != null);

            _container = container;
            _lazyImports = imports ?? Imports.Empty;
        }

        /// <summary>
        /// Creates a binder with given import computation function.
        /// </summary>
        public InContainerBinder(Binder next, Func<ConsList<TypeSymbol>, Imports> computeImports)
            : base(next, null)
        {
            Debug.Assert(computeImports != null);

            _container = null;
            _computeImports = computeImports;
        }

        public DeclaredSymbol Container
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

        protected override void AddLookupCandidateSymbolsInScope(LookupCandidates result, LookupConstraints constraints)
        {
            if (_container != null)
            {
                base.AddLookupCandidateSymbolsInScope(result, constraints.WithQualifier(_container));
            }
            var imports = GetImports(basesBeingResolved: null);
            imports.AddLookupCandidateSymbols(result, constraints);
        }

    }
}
