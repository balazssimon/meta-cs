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

        protected override LookupConstraints AdjustConstraints(LookupConstraints constraints)
        {
            return base.AdjustConstraints(constraints).WithAdditionalValidators(this);
        }

        protected override void AddLookupCandidateSymbolsInScope(LookupCandidates result, LookupConstraints constraints)
        {
            if (Container != null)
            {
                base.AddLookupCandidateSymbolsInScope(result, constraints.WithQualifier(Container));
            }
            var imports = GetImports(constraints);
            if (imports != null)
            { 
                imports.AddLookupCandidateSymbols(result, constraints);
            }
        }

        protected override void CheckFinalResultViability(LookupResult result, LookupConstraints constraints)
        {
            if (result.IsMultiViable)
            {
                // symbols cannot conflict with using alias names
                var imports = GetImports(constraints);
                if (imports != null && imports.IsUsingAlias(constraints.Name, this.IsSemanticModelBinder))
                {
                    LanguageDiagnosticInfo diagInfo = new LanguageDiagnosticInfo(InternalErrorCode.ERR_ConflictAliasAndMember, constraints.Name, constraints.QualifierOpt);
                    var error = this.SymbolFactory.MakeMetadataErrorSymbol<AliasSymbol>(null, constraints.Name, constraints.MetadataName, ErrorKind.Ambiguous, diagInfo, unreported: true);
                    result.SetFrom(LookupResult.Good(error));
                }
            }
        }
    }
}
