// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using Microsoft.CodeAnalysis;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Globalization;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Symbols.Wrapped
{
    /// <summary>
    /// Represents a member that is based on another member.
    /// When inheriting from this class, one shouldn't assume that 
    /// the default behavior it has is appropriate for every case.
    /// That behavior should be carefully reviewed and derived type
    /// should override behavior as appropriate.
    /// </summary>
    internal abstract class WrappedMemberSymbol : MemberSymbol
    {
        /// <summary>
        /// The underlying MemberSymbol.
        /// </summary>
        protected readonly MemberSymbol _underlyingMember;

        public WrappedMemberSymbol(MemberSymbol underlyingMember)
        {
            Debug.Assert((object)underlyingMember != null);
            _underlyingMember = underlyingMember;
        }

        public MemberSymbol UnderlyingMember
        {
            get
            {
                return _underlyingMember;
            }
        }

        public override bool IsImplicitlyDeclared
        {
            get { return _underlyingMember.IsImplicitlyDeclared; }
        }

        public override Accessibility DeclaredAccessibility
        {
            get
            {
                return _underlyingMember.DeclaredAccessibility;
            }
        }

        public override string Name
        {
            get
            {
                return _underlyingMember.Name;
            }
        }

        public override string GetDocumentationCommentXml(CultureInfo preferredCulture = null, bool expandIncludes = false, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _underlyingMember.GetDocumentationCommentXml(preferredCulture, expandIncludes, cancellationToken);
        }

        public override ObsoleteAttributeData ObsoleteAttributeData
        {
            get
            {
                return _underlyingMember.ObsoleteAttributeData;
            }
        }

        public override ImmutableArray<Location> Locations
        {
            get
            {
                return _underlyingMember.Locations;
            }
        }

        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences
        {
            get
            {
                return _underlyingMember.DeclaringSyntaxReferences;
            }
        }

        public override bool IsStatic
        {
            get
            {
                return _underlyingMember.IsStatic;
            }
        }
    }
}
