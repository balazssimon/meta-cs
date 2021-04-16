// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

#nullable disable

using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Symbols.PublicModel
{
    internal abstract class TypeSymbol : NamespaceOrTypeSymbol, ISymbol, ITypeSymbol
    {
        protected TypeSymbol(Microsoft.CodeAnalysis.NullableAnnotation nullableAnnotation)
        {
            NullableAnnotation = nullableAnnotation;
        }

        protected Microsoft.CodeAnalysis.NullableAnnotation NullableAnnotation { get; }

        protected abstract ITypeSymbol WithNullableAnnotation(Microsoft.CodeAnalysis.NullableAnnotation nullableAnnotation);

        internal abstract Symbols.TypeSymbol UnderlyingTypeSymbol { get; }

        Microsoft.CodeAnalysis.NullableAnnotation ITypeSymbol.NullableAnnotation => NullableAnnotation;

        ITypeSymbol ITypeSymbol.WithNullableAnnotation(Microsoft.CodeAnalysis.NullableAnnotation nullableAnnotation)
        {
            if (NullableAnnotation == nullableAnnotation)
            {
                return this;
            }
            else if (nullableAnnotation == UnderlyingTypeSymbol.DefaultNullableAnnotation)
            {
                return (ITypeSymbol)UnderlyingSymbol.ISymbol;
            }

            return WithNullableAnnotation(nullableAnnotation);
        }

        bool ISymbol.IsDefinition
        {
            get
            {
                return (object)this == ((ISymbol)this).OriginalDefinition;
            }
        }

        bool ISymbol.Equals(ISymbol other, Microsoft.CodeAnalysis.SymbolEqualityComparer equalityComparer)
        {
            return this.Equals(other as TypeSymbol, equalityComparer);
        }

        protected bool Equals(TypeSymbol otherType, Microsoft.CodeAnalysis.SymbolEqualityComparer equalityComparer)
        {
            if (otherType is null)
            {
                return false;
            }
            else if ((object)otherType == this)
            {
                return true;
            }

            var compareKind = equalityComparer.CompareKind;

            if (NullableAnnotation != otherType.NullableAnnotation && (compareKind & Microsoft.CodeAnalysis.TypeCompareKind.IgnoreNullableModifiersForReferenceTypes) == 0 &&
                ((compareKind & Microsoft.CodeAnalysis.TypeCompareKind.ObliviousNullableModifierMatchesAny) == 0 ||
                    (NullableAnnotation != Microsoft.CodeAnalysis.NullableAnnotation.None && otherType.NullableAnnotation != Microsoft.CodeAnalysis.NullableAnnotation.None)) &&
                !(UnderlyingTypeSymbol.IsValueType && !UnderlyingTypeSymbol.IsNullableType()))
            {
                return false;
            }

            return UnderlyingTypeSymbol.Equals(otherType.UnderlyingTypeSymbol, compareKind);
        }

        ITypeSymbol ITypeSymbol.OriginalDefinition
        {
            get
            {
                return UnderlyingTypeSymbol.OriginalDefinition.GetPublicSymbol();
            }
        }

        INamedTypeSymbol ITypeSymbol.BaseType
        {
            get
            {
                return UnderlyingTypeSymbol.BaseTypesNoUseSiteDiagnostics.FirstOrDefault(t => t.Kind == SymbolKind.Class).GetPublicSymbol();
            }
        }

        ImmutableArray<INamedTypeSymbol> ITypeSymbol.Interfaces
        {
            get
            {
                return UnderlyingTypeSymbol.BaseTypesNoUseSiteDiagnostics.Where(t => t.Kind == SymbolKind.Interface).ToImmutableArray().GetPublicSymbols();
            }
        }

        ImmutableArray<INamedTypeSymbol> ITypeSymbol.AllInterfaces
        {
            get
            {
                return UnderlyingTypeSymbol.AllBaseTypesNoUseSiteDiagnostics.Where(t => t.Kind == SymbolKind.Interface).ToImmutableArray().GetPublicSymbols();
            }
        }

        ISymbol ITypeSymbol.FindImplementationForInterfaceMember(ISymbol interfaceMember)
        {
            return interfaceMember is Symbol symbol
                ? UnderlyingTypeSymbol.FindImplementationForBaseTypeMember(symbol.UnderlyingSymbol).GetPublicSymbol()
                : null;
        }

        bool ITypeSymbol.IsUnmanagedType => !UnderlyingTypeSymbol.IsManagedTypeNoUseSiteDiagnostics;

        bool ITypeSymbol.IsReferenceType
        {
            get
            {
                return UnderlyingTypeSymbol.IsReferenceType;
            }
        }

        bool ITypeSymbol.IsValueType
        {
            get
            {
                return UnderlyingTypeSymbol.IsValueType;
            }
        }

        Microsoft.CodeAnalysis.TypeKind ITypeSymbol.TypeKind
        {
            get
            {
                return UnderlyingTypeSymbol.TypeKind.ToCSharp();
            }
        }

        bool ITypeSymbol.IsTupleType => UnderlyingTypeSymbol.IsTupleType;

        bool ITypeSymbol.IsNativeIntegerType => UnderlyingTypeSymbol.IsNativeIntegerType;

        string ITypeSymbol.ToDisplayString(Microsoft.CodeAnalysis.NullableFlowState topLevelNullability, SymbolDisplayFormat format)
        {
            return SymbolDisplay.ToDisplayString(this, topLevelNullability, format);
        }

        ImmutableArray<SymbolDisplayPart> ITypeSymbol.ToDisplayParts(Microsoft.CodeAnalysis.NullableFlowState topLevelNullability, SymbolDisplayFormat format)
        {
            return SymbolDisplay.ToDisplayParts(this, topLevelNullability, format);
        }

        string ITypeSymbol.ToMinimalDisplayString(SemanticModel semanticModel, Microsoft.CodeAnalysis.NullableFlowState topLevelNullability, int position, SymbolDisplayFormat format)
        {
            return SymbolDisplay.ToMinimalDisplayString(this, topLevelNullability, semanticModel, position, format);
        }

        ImmutableArray<SymbolDisplayPart> ITypeSymbol.ToMinimalDisplayParts(SemanticModel semanticModel, Microsoft.CodeAnalysis.NullableFlowState topLevelNullability, int position, SymbolDisplayFormat format)
        {
            return SymbolDisplay.ToMinimalDisplayParts(this, topLevelNullability, semanticModel, position, format);
        }

        bool ITypeSymbol.IsAnonymousType => UnderlyingTypeSymbol.IsAnonymousType;

        SpecialType ITypeSymbol.SpecialType => UnderlyingTypeSymbol.SpecialType;

        bool ITypeSymbol.IsRefLikeType => UnderlyingTypeSymbol.IsRefLikeType;

        bool ITypeSymbol.IsReadOnly => UnderlyingTypeSymbol.IsReadOnly;

        bool ITypeSymbol.IsRecord => UnderlyingTypeSymbol.IsRecord;
    }
}
