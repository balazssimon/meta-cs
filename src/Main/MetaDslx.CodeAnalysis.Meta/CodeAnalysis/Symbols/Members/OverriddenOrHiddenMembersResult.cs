// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System.Diagnostics;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Groups the information computed by MakeOverriddenOrHiddenMembers.
    /// </summary>
    public sealed class OverriddenOrHiddenMembersResult
    {
        public static readonly OverriddenOrHiddenMembersResult Empty =
            new OverriddenOrHiddenMembersResult(
                ImmutableArray<MemberSymbol>.Empty,
                ImmutableArray<MemberSymbol>.Empty,
                ImmutableArray<MemberSymbol>.Empty);

        private readonly ImmutableArray<MemberSymbol> _overriddenMembers;
        public ImmutableArray<MemberSymbol> OverriddenMembers { get { return _overriddenMembers; } }

        private readonly ImmutableArray<MemberSymbol> _hiddenMembers;
        public ImmutableArray<MemberSymbol> HiddenMembers { get { return _hiddenMembers; } }

        private readonly ImmutableArray<MemberSymbol> _runtimeOverriddenMembers;
        public ImmutableArray<MemberSymbol> RuntimeOverriddenMembers { get { return _runtimeOverriddenMembers; } }

        private OverriddenOrHiddenMembersResult(
            ImmutableArray<MemberSymbol> overriddenMembers,
            ImmutableArray<MemberSymbol> hiddenMembers,
            ImmutableArray<MemberSymbol> runtimeOverriddenMembers)
        {
            _overriddenMembers = overriddenMembers;
            _hiddenMembers = hiddenMembers;
            _runtimeOverriddenMembers = runtimeOverriddenMembers;
        }

        public static OverriddenOrHiddenMembersResult Create(
            ImmutableArray<MemberSymbol> overriddenMembers,
            ImmutableArray<MemberSymbol> hiddenMembers,
            ImmutableArray<MemberSymbol> runtimeOverriddenMembers)
        {
            if (overriddenMembers.IsEmpty && hiddenMembers.IsEmpty && runtimeOverriddenMembers.IsEmpty)
            {
                return Empty;
            }
            else
            {
                return new OverriddenOrHiddenMembersResult(overriddenMembers, hiddenMembers, runtimeOverriddenMembers);
            }
        }

        internal static MemberSymbol GetOverriddenMember(MemberSymbol substitutedOverridingMember, MemberSymbol overriddenByDefinitionMember)
        {
            Debug.Assert(!substitutedOverridingMember.IsDefinition);

            if ((object)overriddenByDefinitionMember != null)
            {
                NamedTypeSymbol overriddenByDefinitionContaining = overriddenByDefinitionMember.ContainingType;
                NamedTypeSymbol overriddenByDefinitionContainingTypeDefinition = overriddenByDefinitionContaining.OriginalDefinition;
                foreach (var baseType in substitutedOverridingMember.ContainingType.AllBaseTypesNoUseSiteDiagnostics)
                {
                    if (TypeSymbol.Equals(baseType.OriginalDefinition, overriddenByDefinitionContainingTypeDefinition, TypeCompareKind.ConsiderEverything2))
                    {
                        if (TypeSymbol.Equals(baseType, overriddenByDefinitionContaining, TypeCompareKind.ConsiderEverything2))
                        {
                            return overriddenByDefinitionMember;
                        }
                        return overriddenByDefinitionMember.OriginalDefinition.AsMember(baseType);
                    }
                }

                throw ExceptionUtilities.Unreachable;
            }

            return null;
        }

        /// <summary>
        /// It is not suitable to call this method on a <see cref="OverriddenOrHiddenMembersResult"/> object
        /// associated with a member within substituted type, <see cref="GetOverriddenMember(MemberSymbol, MemberSymbol)"/>
        /// should be used instead.
        /// </summary>
        internal MemberSymbol GetOverriddenMember()
        {
            foreach (var overriddenMember in _overriddenMembers)
            {
                if (overriddenMember.IsAbstract || overriddenMember.IsVirtual || overriddenMember.IsOverride)
                {
                    return overriddenMember;
                }
            }

            return null;
        }
    }
}
