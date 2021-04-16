// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

#nullable disable

using System;
using System.Collections.Immutable;
using System.Globalization;
using System.Threading;
using Microsoft.CodeAnalysis.PooledObjects;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Symbols.PublicModel
{
    internal abstract class Symbol : ISymbol
    {
        internal abstract Symbols.Symbol UnderlyingSymbol { get; }

        protected static ImmutableArray<TypeWithAnnotations> ConstructTypeArguments(ITypeSymbol[] typeArguments)
        {
            var builder = ArrayBuilder<TypeWithAnnotations>.GetInstance(typeArguments.Length);
            foreach (var typeArg in typeArguments)
            {
                var type = typeArg.EnsureLanguageSymbolOrNull(nameof(typeArguments));
                builder.Add(TypeWithAnnotations.Create(type, (typeArg?.NullableAnnotation.ToInternalAnnotation() ?? NullableAnnotation.NotAnnotated)));
            }

            return builder.ToImmutableAndFree();
        }

        protected static ImmutableArray<TypeWithAnnotations> ConstructTypeArguments(ImmutableArray<ITypeSymbol> typeArguments, ImmutableArray<Microsoft.CodeAnalysis.NullableAnnotation> typeArgumentNullableAnnotations)
        {
            if (typeArguments.IsDefault)
            {
                throw new ArgumentException(nameof(typeArguments));
            }

            int n = typeArguments.Length;
            if (!typeArgumentNullableAnnotations.IsDefault && typeArgumentNullableAnnotations.Length != n)
            {
                throw new ArgumentException(nameof(typeArgumentNullableAnnotations));
            }

            var builder = ArrayBuilder<TypeWithAnnotations>.GetInstance(n);
            for (int i = 0; i < n; i++)
            {
                var type = typeArguments[i].EnsureLanguageSymbolOrNull(nameof(typeArguments));
                var annotation = typeArgumentNullableAnnotations.IsDefault ? NullableAnnotation.Oblivious : typeArgumentNullableAnnotations[i].ToInternalAnnotation();
                builder.Add(TypeWithAnnotations.Create(type, annotation));
            }

            return builder.ToImmutableAndFree();
        }

        ISymbol ISymbol.OriginalDefinition
        {
            get
            {
                return UnderlyingSymbol.OriginalDefinition.GetPublicSymbol();
            }
        }

        ISymbol ISymbol.ContainingSymbol
        {
            get
            {
                return UnderlyingSymbol.ContainingSymbol.GetPublicSymbol();
            }
        }

        INamedTypeSymbol ISymbol.ContainingType
        {
            get
            {
                return UnderlyingSymbol.ContainingType.GetPublicSymbol();
            }
        }

        public sealed override int GetHashCode()
        {
            return UnderlyingSymbol.GetHashCode();
        }

        public sealed override bool Equals(object obj)
        {
            return this.Equals(obj as Symbol, Microsoft.CodeAnalysis.SymbolEqualityComparer.Default);
        }

        bool IEquatable<ISymbol>.Equals(ISymbol other)
        {
            return this.Equals(other as Symbol, SymbolEqualityComparer.Default);
        }

        bool ISymbol.Equals(ISymbol other, SymbolEqualityComparer equalityComparer)
        {
            return this.Equals(other as Symbol, equalityComparer);
        }

        protected bool Equals(Symbol other, SymbolEqualityComparer equalityComparer)
        {
            return other is object && UnderlyingSymbol.Equals(other.UnderlyingSymbol, equalityComparer.CompareKind);
        }

        ImmutableArray<Location> ISymbol.Locations
        {
            get
            {
                return UnderlyingSymbol.Locations;
            }
        }

        ImmutableArray<SyntaxReference> ISymbol.DeclaringSyntaxReferences
        {
            get
            {
                return UnderlyingSymbol.DeclaringSyntaxReferences;
            }
        }

        ImmutableArray<AttributeData> ISymbol.GetAttributes()
        {
            return StaticCast<AttributeData>.From(UnderlyingSymbol.GetAttributes());
        }

        Accessibility ISymbol.DeclaredAccessibility => (UnderlyingSymbol as DeclaredSymbol)?.DeclaredAccessibility ?? Accessibility.NotApplicable;

        void ISymbol.Accept(Microsoft.CodeAnalysis.SymbolVisitor visitor)
        {
            Accept(visitor);
        }

        protected abstract void Accept(Microsoft.CodeAnalysis.SymbolVisitor visitor);

        TResult ISymbol.Accept<TResult>(Microsoft.CodeAnalysis.SymbolVisitor<TResult> visitor)
        {
            return Accept(visitor);
        }

        protected abstract TResult Accept<TResult>(Microsoft.CodeAnalysis.SymbolVisitor<TResult> visitor);

        string ISymbol.GetDocumentationCommentId()
        {
            return UnderlyingSymbol.GetDocumentationCommentId();
        }

        string ISymbol.GetDocumentationCommentXml(CultureInfo preferredCulture, bool expandIncludes, CancellationToken cancellationToken)
        {
            return UnderlyingSymbol.GetDocumentationCommentXml(preferredCulture, expandIncludes, cancellationToken);
        }

        string ISymbol.ToDisplayString(SymbolDisplayFormat format)
        {
            return SymbolDisplay.ToDisplayString(this, format);
        }

        ImmutableArray<SymbolDisplayPart> ISymbol.ToDisplayParts(SymbolDisplayFormat format)
        {
            return SymbolDisplay.ToDisplayParts(this, format);
        }

        string ISymbol.ToMinimalDisplayString(SemanticModel semanticModel, int position, SymbolDisplayFormat format)
        {
            return SymbolDisplay.ToMinimalDisplayString(this, GetCSharpSemanticModel(semanticModel), position, format);
        }

        ImmutableArray<SymbolDisplayPart> ISymbol.ToMinimalDisplayParts(SemanticModel semanticModel, int position, SymbolDisplayFormat format)
        {
            return SymbolDisplay.ToMinimalDisplayParts(this, GetCSharpSemanticModel(semanticModel), position, format);
        }

        internal static CSharpSemanticModel GetCSharpSemanticModel(SemanticModel semanticModel)
        {
            var csharpModel = semanticModel as CSharpSemanticModel;
            if (csharpModel == null)
            {
                throw new ArgumentException(CSharpResources.WrongSemanticModelType, LanguageNames.CSharp);
            }

            return csharpModel;
        }

        Microsoft.CodeAnalysis.SymbolKind ISymbol.Kind => UnderlyingSymbol.Kind.ToCSharp();

        string ISymbol.Language => LanguageNames.CSharp;

        string ISymbol.Name => UnderlyingSymbol.Name;

        string ISymbol.MetadataName => UnderlyingSymbol.MetadataName;

        IAssemblySymbol ISymbol.ContainingAssembly => UnderlyingSymbol.ContainingAssembly.GetPublicSymbol();

        IModuleSymbol ISymbol.ContainingModule => UnderlyingSymbol.ContainingModule.GetPublicSymbol();

        INamespaceSymbol ISymbol.ContainingNamespace => UnderlyingSymbol.ContainingNamespace.GetPublicSymbol();

        bool ISymbol.IsDefinition => (UnderlyingSymbol as DeclaredSymbol)?.IsDefinition ?? true;

        bool ISymbol.IsStatic => (UnderlyingSymbol as DeclaredSymbol)?.IsStatic ?? false;

        bool ISymbol.IsVirtual => (UnderlyingSymbol as DeclaredSymbol)?.IsVirtual ?? false;

        bool ISymbol.IsOverride => (UnderlyingSymbol as DeclaredSymbol)?.IsOverride ?? false;

        bool ISymbol.IsAbstract => (UnderlyingSymbol as DeclaredSymbol)?.IsAbstract ?? false;

        bool ISymbol.IsSealed => (UnderlyingSymbol as DeclaredSymbol)?.IsSealed ?? false;

        bool ISymbol.IsExtern => (UnderlyingSymbol as DeclaredSymbol)?.IsExtern ?? false;

        bool ISymbol.IsImplicitlyDeclared => (UnderlyingSymbol as DeclaredSymbol)?.IsImplicitlyDeclared ?? false;

        bool ISymbol.CanBeReferencedByName => (UnderlyingSymbol as DeclaredSymbol)?.CanBeReferencedByName ?? false;

        bool ISymbol.HasUnsupportedMetadata => UnderlyingSymbol.HasUnsupportedMetadata;

        public sealed override string ToString()
        {
            return SymbolDisplay.ToDisplayString(this);
        }
    }
}
