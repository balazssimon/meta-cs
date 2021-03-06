﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Symbols.Source
{
    public sealed partial class DynamicTypeSymbol : TypeSymbol, IDynamicTypeSymbol
    {
        public static readonly DynamicTypeSymbol Instance = new DynamicTypeSymbol();

        private DynamicTypeSymbol()
        {
        }

        public override string Name
        {
            get
            {
                return "dynamic";
            }
        }

        public override bool IsAbstract
        {
            get
            {
                return false;
            }
        }

        public override bool IsReferenceType
        {
            get
            {
                return true;
            }
        }

        public override bool IsSealed
        {
            get
            {
                return false;
            }
        }

        public override LanguageSymbolKind Kind
        {
            get
            {
                return LanguageSymbolKind.DynamicType;
            }
        }

        public override LanguageTypeKind TypeKind
        {
            get
            {
                return LanguageTypeKind.Dynamic;
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

        public override ImmutableArray<NamedTypeSymbol> GetBaseTypesNoUseSiteDiagnostics(ConsList<TypeSymbol> basesBeingResolved)
        {
            return ImmutableArray<NamedTypeSymbol>.Empty;
        }

        public override bool IsStatic
        {
            get
            {
                return false;
            }
        }

        public override bool IsValueType
        {
            get
            {
                return false;
            }
        }

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

        public override ImmutableArray<Symbol> GetMembers()
        {
            return ImmutableArray<Symbol>.Empty;
        }

        public override ImmutableArray<Symbol> GetMembers(string name)
        {
            return ImmutableArray<Symbol>.Empty;
        }

        public override ImmutableArray<NamedTypeSymbol> GetTypeMembers(string name)
        {
            return ImmutableArray<NamedTypeSymbol>.Empty;
        }

        public override ImmutableArray<NamedTypeSymbol> GetTypeMembers()
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

        public override Accessibility DeclaredAccessibility
        {
            get
            {
                return Accessibility.NotApplicable;
            }
        }

        public override bool GetUnificationUseSiteDiagnosticRecursive(ref DiagnosticInfo result, Symbol owner, ref HashSet<TypeSymbol> checkedTypes)
        {
            return false;
        }

        public override int GetHashCode()
        {
            // return the distinguished value for 'object' because the hash code ignores the distinction
            // between dynamic and object.  It also ignores custom modifiers.
            return (int)Microsoft.CodeAnalysis.SpecialType.System_Object;
        }

        public override bool Equals(TypeSymbol t2, TypeCompareKind comparison)
        {
            if ((object)t2 == null)
            {
                return false;
            }

            if (ReferenceEquals(this, t2) || t2.TypeKind == LanguageTypeKind.Dynamic)
            {
                return true;
            }

            if ((comparison & TypeCompareKind.IgnoreDynamic) != 0)
            {
                var other = t2 as NamedTypeSymbol;
                return (object)other != null && other.SpecialType == Microsoft.CodeAnalysis.SpecialType.System_Object;
            }

            return false;
        }

        #region ISymbol Members

        public override void Accept(SymbolVisitor visitor)
        {
            visitor.VisitDynamicType(this);
        }

        public override TResult Accept<TResult>(SymbolVisitor<TResult> visitor)
        {
            return visitor.VisitDynamicType(this);
        }

        public override TResult Accept<TArgument, TResult>(SymbolVisitor<TArgument, TResult> visitor, TArgument argument)
        {
            return visitor.VisitDynamicType(this, argument);
        }

        public override void Accept(Microsoft.CodeAnalysis.SymbolVisitor visitor)
        {
            visitor.VisitDynamicType(this);
        }

        public override TResult Accept<TResult>(Microsoft.CodeAnalysis.SymbolVisitor<TResult> visitor)
        {
            return visitor.VisitDynamicType(this);
        }

        #endregion
    }
}
