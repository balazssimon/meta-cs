﻿using MetaDslx.CodeAnalysis.Symbols.Source;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    internal static class SymbolExtensions
    {
        public static string GetKindText(this Symbol symbol)
        {
            return symbol.ModelSymbolInfo.ImmutableType.Name;
        }

        internal static TDestination EnsureLanguageSymbolOrNull<TSource, TDestination>(this TSource symbol, string paramName)
            where TSource : ISymbol
            where TDestination : Symbol, TSource
        {
            var csSymbol = symbol as TDestination;

            if ((object)csSymbol == null && (object)symbol != null)
            {
                throw new ArgumentException(Microsoft.CodeAnalysis.CSharp.CSharpResources.NotACSharpSymbol, paramName);
            }

            return csSymbol;
        }

        /// <summary>
        /// The immediately containing namespace or named type, or null
        /// if the containing symbol is neither a namespace or named type.
        /// </summary>
        internal static NamespaceOrTypeSymbol ContainingNamespaceOrType(this Symbol symbol)
        {
            var containingSymbol = symbol.ContainingSymbol;
            if ((object)containingSymbol != null)
            {
                switch (containingSymbol.Kind.Switch())
                {
                    case LanguageSymbolKind.Namespace:
                    case LanguageSymbolKind.NamedType:
                    case LanguageSymbolKind.ErrorType:
                        return (NamespaceOrTypeSymbol)containingSymbol;
                }
            }
            return null;
        }

        public static bool IsTypeOrTypeAlias(this Symbol symbol)
        {
            switch (symbol.Kind.Switch())
            {
                case LanguageSymbolKind.ConstructedType:
                case LanguageSymbolKind.DynamicType:
                case LanguageSymbolKind.ErrorType:
                case LanguageSymbolKind.NamedType:
                    return true;
                case LanguageSymbolKind.Alias:
                    return IsTypeOrTypeAlias(((AliasSymbol)symbol).Target);
                default:
                    Debug.Assert(!(symbol is TypeSymbol));
                    return false;
            }
        }

        /// <summary>
        /// Return true if the type contains any dynamic type reference.
        /// </summary>
        public static bool ContainsDynamic(this TypeSymbol type)
        {
            return false; // TODO:MetaDslx
            /*
            var result type.VisitType(s_containsDynamicPredicate, null, canDigThroughNullable: true);
            return (object)result != null;*/
        }

        private static readonly Func<TypeSymbol, object, bool, bool> s_containsDynamicPredicate = (type, unused1, unused2) => type.TypeKind == LanguageTypeKind.Dynamic;
    }
}
