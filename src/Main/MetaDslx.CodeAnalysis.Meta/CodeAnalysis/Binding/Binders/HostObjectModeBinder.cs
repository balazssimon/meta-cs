// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Binding.Binders
{
    internal sealed class HostObjectModelBinder : Binder
    {
        public HostObjectModelBinder(Binder next)
            : base(next, null)
        {
        }

        private TypeSymbol GetHostObjectType()
        {
            TypeSymbol result = this.Compilation.GetHostObjectTypeSymbol();

            // This binder shouldn't be created if the compilation doesn't have host object type:
            Debug.Assert((object)result != null);

            return result;
        }

        public override void LookupSymbolsInSingleBinder(LookupResult result, LookupConstraints constraints)
        {
            var hostObjectType = GetHostObjectType();
            if (hostObjectType.Kind == LanguageSymbolKind.ErrorType)
            {
                // The name '{0}' does not exist in the current context (are you missing a reference to assembly '{1}'?)
                result.SetFrom(new LanguageDiagnosticInfo(
                    InternalErrorCode.ERR_NameNotInContextPossibleMissingReference,
                    new object[] { constraints.Name, ((MissingMetadataTypeSymbol)hostObjectType).ContainingAssembly.Identity },
                    ImmutableArray<Symbol>.Empty,
                    ImmutableArray<Location>.Empty
                ));
            }
            else
            {
                LookupMembersInternal(result, constraints.WithQualifier(hostObjectType));
            }
        }

        protected override void AddLookupSymbolsInfoInSingleBinder(LookupSymbolsInfo result, LookupConstraints constraints)
        {
            var hostObjectType = GetHostObjectType();
            if (hostObjectType.Kind != LanguageSymbolKind.ErrorType)
            {
                AddMemberLookupSymbolsInfo(result, constraints.WithQualifier(hostObjectType));
            }
        }
    }
}
