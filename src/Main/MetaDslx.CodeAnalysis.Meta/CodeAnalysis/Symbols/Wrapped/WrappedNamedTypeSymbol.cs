// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MetaDslx.CodeAnalysis;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Symbols.Wrapped
{
    /// <summary>
    /// Represents a named type that is based on another named type.
    /// When inheriting from this class, one shouldn't assume that 
    /// the default behavior it has is appropriate for every case.
    /// That behavior should be carefully reviewed and derived type
    /// should override behavior as appropriate.
    /// </summary>
    internal abstract class WrappedNamedTypeSymbol : NamedTypeSymbol
    {
        /// <summary>
        /// The underlying NamedTypeSymbol.
        /// </summary>
        protected readonly NamedTypeSymbol _underlyingType;

        public WrappedNamedTypeSymbol(NamedTypeSymbol underlyingType)
        {
            Debug.Assert((object)underlyingType != null);
            _underlyingType = underlyingType;
        }

        public NamedTypeSymbol UnderlyingNamedType
        {
            get
            {
                return _underlyingType;
            }
        }

        public override bool IsImplicitlyDeclared
        {
            get { return _underlyingType.IsImplicitlyDeclared; }
        }

        public override int Arity
        {
            get
            {
                return _underlyingType.Arity;
            }
        }

        public override bool MightContainExtensionMethods
        {
            get
            {
                return _underlyingType.MightContainExtensionMethods;
            }
        }

        public override string Name
        {
            get
            {
                return _underlyingType.Name;
            }
        }

        public override string MetadataName
        {
            get
            {
                return _underlyingType.MetadataName;
            }
        }

        public override bool MangleName
        {
            get
            {
                return _underlyingType.MangleName;
            }
        }

        public override string GetDocumentationCommentXml(CultureInfo preferredCulture = null, bool expandIncludes = false, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _underlyingType.GetDocumentationCommentXml(preferredCulture, expandIncludes, cancellationToken);
        }

        public override Accessibility DeclaredAccessibility
        {
            get
            {
                return _underlyingType.DeclaredAccessibility;
            }
        }

        public override TypeKind TypeKind
        {
            get
            {
                return _underlyingType.TypeKind;
            }
        }

        public override ImmutableArray<Location> Locations
        {
            get
            {
                return _underlyingType.Locations;
            }
        }

        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences
        {
            get
            {
                return _underlyingType.DeclaringSyntaxReferences;
            }
        }

        public override bool IsStatic
        {
            get
            {
                return _underlyingType.IsStatic;
            }
        }

        public override bool IsAbstract
        {
            get
            {
                return _underlyingType.IsAbstract;
            }
        }

        public override bool IsSealed
        {
            get
            {
                return _underlyingType.IsSealed;
            }
        }

        public override ObsoleteAttributeData ObsoleteAttributeData
        {
            get { return _underlyingType.ObsoleteAttributeData; }
        }

        public override bool IsRefLikeType
        {
            get { return _underlyingType.IsRefLikeType; }
        }

        public override bool IsReadOnly
        {
            get { return _underlyingType.IsReadOnly; }
        }

    }
}
