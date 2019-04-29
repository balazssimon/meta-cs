// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// An WrappedTypeSymbol represents an wrapped type, such as int[] or int?
    /// </summary>
    internal abstract partial class WrappedTypeSymbol : TypeSymbol
    {
        private readonly TypeSymbol _wrappedType;

        protected WrappedTypeSymbol(TypeSymbol wrappedType)
        {
            _wrappedType = wrappedType;
        }

        public TypeSymbol WrappedType => _wrappedType;

        internal WrappedTypeSymbol WithWrappedType(TypeSymbol wrappedType)
        {
            return (object)_wrappedType == (object)wrappedType ? this : WithWrappedTypeCore(wrappedType);
        }

        protected abstract WrappedTypeSymbol WithWrappedTypeCore(TypeSymbol wrappedType);

        public override bool IsReferenceType
        {
            get
            {
                return true;
            }
        }

        public override bool IsValueType
        {
            get
            {
                return false;
            }
        }

        internal sealed override ManagedKind ManagedKind => ManagedKind.Managed;

        public sealed override bool IsRefLikeType
        {
            get
            {
                return false;
            }
        }

        public sealed override bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        internal sealed override ObsoleteAttributeData ObsoleteAttributeData
        {
            get { return null; }
        }

        public override ImmutableArray<Symbol> GetMembers()
        {
            return ImmutableArray<Symbol>.Empty;
        }

        public override ImmutableArray<Symbol> GetMembers(string name)
        {
            return ImmutableArray<Symbol>.Empty;
        }

        public override ImmutableArray<NamedTypeSymbol> GetTypeMembers()
        {
            return ImmutableArray<NamedTypeSymbol>.Empty;
        }

        public override ImmutableArray<NamedTypeSymbol> GetTypeMembers(string name)
        {
            return ImmutableArray<NamedTypeSymbol>.Empty;
        }

        public override ImmutableArray<NamedTypeSymbol> GetTypeMembers(string name, string metadataName)
        {
            return ImmutableArray<NamedTypeSymbol>.Empty;
        }

        public override Symbol ContainingSymbol
        {
            get
            {
                return null;
            }
        }

        public override ImmutableArray<Location> Locations
        {
            get
            {
                return ImmutableArray<Location>.Empty;
            }
        }

        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences
        {
            get
            {
                return ImmutableArray<SyntaxReference>.Empty;
            }
        }

        internal override bool Equals(TypeSymbol t2, TypeCompareKind comparison)
        {
            return this.Equals(t2 as WrappedTypeSymbol, comparison);
        }

        internal bool Equals(WrappedTypeSymbol other)
        {
            return Equals(other, TypeCompareKind.ConsiderEverything);
        }

        private bool Equals(WrappedTypeSymbol other, TypeCompareKind comparison)
        {
            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if ((object)other == null || other.GetType() != this.GetType() || !this.WrappedType.Equals(other.WrappedType, comparison))
            {
                return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            // We don't want to blow the stack if we have a type like T[][][][][][][][]....[][],
            // so we do not recurse until we have a non-array. Rather, hash all the ranks together
            // and then hash that with the "T" type.

            int hash = 0;
            WrappedTypeSymbol current = this;
            while (current != null)
            {
                var wrapped = current.WrappedType as WrappedTypeSymbol;
                if (wrapped == null) return current.GetHashCode();
                else if (object.ReferenceEquals(current, wrapped)) return hash;
                else current = wrapped;
            }

            return hash;
        }

        public override Accessibility DeclaredAccessibility
        {
            get
            {
                return Accessibility.NotApplicable;
            }
        }

        public override bool IsStatic
        {
            get
            {
                return false;
            }
        }

        public override bool IsAbstract
        {
            get
            {
                return false;
            }
        }

        public override bool IsSealed
        {
            get
            {
                return false;
            }
        }

        #region Use-Site Diagnostics

        internal override DiagnosticInfo GetUseSiteDiagnostic()
        {
            DiagnosticInfo result = null;

            // check element type
            // check custom modifiers
            if (DeriveUseSiteDiagnosticFromType(ref result, this.WrappedType))
            {
                return result;
            }

            return result;
        }

        internal override bool GetUnificationUseSiteDiagnosticRecursive(ref DiagnosticInfo result, Symbol owner, ref HashSet<TypeSymbol> checkedTypes)
        {
            return _wrappedType.GetUnificationUseSiteDiagnosticRecursive(ref result, owner, ref checkedTypes) ||
                   ((object)_wrappedType != null && _wrappedType.GetUnificationUseSiteDiagnosticRecursive(ref result, owner, ref checkedTypes)) ||
                   GetUnificationUseSiteDiagnosticRecursive(ref result, this.InterfacesNoUseSiteDiagnostics(), owner, ref checkedTypes);
        }

        #endregion
    }
}
