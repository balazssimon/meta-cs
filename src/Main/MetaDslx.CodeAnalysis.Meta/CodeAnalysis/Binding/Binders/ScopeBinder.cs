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

        protected override void AddLookupCandidateSymbolsInSingleBinder(LookupCandidates result, LookupConstraints constraints)
        {
            if (_container != null)
            {
                base.AddLookupCandidateSymbolsInSingleBinder(result, constraints.WithQualifier(_container));
            }

            // If we are looking only for labels we do not need to search through the imports.
            // Submission imports are handled by AddMemberLookupSymbolsInfo (above).
            if (!IsSubmission && ((constraints.Options & LookupOptions.LabelsOnly) == 0))
            {
                var imports = GetImports(basesBeingResolved: null);
                imports.AddLookupCandidateSymbols(result, constraints);
            }
        }

    }
}
