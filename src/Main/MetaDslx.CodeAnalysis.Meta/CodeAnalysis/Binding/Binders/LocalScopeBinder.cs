using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.Modeling;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding
{
    public class LocalScopeBinder : Binder
    {
        public LocalScopeBinder(Binder next, SyntaxNodeOrToken syntax, bool forCompletion)
            : base(next, syntax, forCompletion)
        {

        }

        protected override LookupConstraints AdjustConstraints(LookupConstraints constraints)
        {
            return base.AdjustConstraints(constraints).WithAdditionalValidators(this);
        }

        protected override void AddLookupCandidateSymbolsInScope(LookupCandidates result, LookupConstraints constraints)
        {
            var currentSymbol = this.ContainingSymbol;
            while (currentSymbol is not null && currentSymbol is not ILocalDeclarator) currentSymbol = currentSymbol.ContainingSymbol;
            if (currentSymbol is ILocalDeclarator localDeclarator)
            {
                var lookupLocation = constraints.Location as SourceLocation;
                foreach (var local in localDeclarator.DeclaredLocals)
                {
                    if (lookupLocation is null || local is IRandomAccessLocal)
                    {
                        result.Add(local);
                    }
                    else
                    {
                        foreach (var location in local.Locations)
                        {
                            if (location is SourceLocation sourceLocation)
                            {
                                if (sourceLocation.SourceTree == lookupLocation.SourceTree)
                                {
                                    result.Add(local);
                                }
                            }
                        }
                    }
                }
            }
        }

        protected override SingleLookupResult CheckSingleResultViability(SingleLookupResult result, AliasSymbol aliasSymbol, LookupConstraints constraints)
        {
            var lookupLocation = constraints.Location as SourceLocation;
            var local = result.Symbol;
            if (lookupLocation is not null && local is not IRandomAccessLocal)
            {
                var valid = false;
                foreach (var location in local.Locations)
                {
                    if (location is SourceLocation sourceLocation)
                    {
                        if (sourceLocation.SourceTree == lookupLocation.SourceTree && sourceLocation.SourceSpan.End < lookupLocation.SourceSpan.Start)
                        {
                            valid = true;
                            break;
                        }
                    }
                }
                if (!valid)
                {
                    return LookupResult.Inaccessible(local, ModelErrorCode.ERR_CannotUseLocalBeforeDeclaration.ToDiagnosticInfo(result.Symbol.Name));
                }
            }
            return base.CheckSingleResultViability(result, aliasSymbol, constraints);
        }
    }
}
