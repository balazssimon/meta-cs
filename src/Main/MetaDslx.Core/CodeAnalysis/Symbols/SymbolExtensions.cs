using MetaDslx.CodeAnalysis.Symbols.Source;
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
                switch (containingSymbol.Kind)
                {
                    case SymbolKind.Namespace:
                    case SymbolKind.NamedType:
                    case SymbolKind.ErrorType:
                        return (NamespaceOrTypeSymbol)containingSymbol;
                }
            }
            return null;
        }

        public static bool IsTypeOrTypeAlias(this Symbol symbol)
        {
            switch (symbol.Kind)
            {
                case SymbolKind.ArrayType:
                case SymbolKind.DynamicType:
                case SymbolKind.ErrorType:
                case SymbolKind.NamedType:
                case SymbolKind.PointerType:
                case SymbolKind.TypeParameter:
                    return true;
                case SymbolKind.Alias:
                    return IsTypeOrTypeAlias(((AliasSymbol)symbol).Target);
                default:
                    Debug.Assert(!(symbol is TypeSymbol));
                    return false;
            }
        }
    }
}
