using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Symbols.Metadata;
using MetaDslx.CodeAnalysis.Symbols.Source;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    internal static class SymbolExtensions
    {
        public static string GetKindText(this Symbol symbol)
        {
            if (symbol is IModelSymbol ms && ms.ModelObject != null) return ms.ModelObject.GetType().Name;
            else return symbol.Kind.ToString();
        }

        [return: NotNullIfNotNull("symbol")]
        internal static Symbol? EnsureLanguageSymbolOrNull(this ISymbol? symbol, string paramName)
        {
            var csSymbol = symbol as Symbol;

            if (csSymbol is null)
            {
                if (symbol is object)
                {
                    throw new ArgumentException(Microsoft.CodeAnalysis.CSharp.CSharpResources.NotACSharpSymbol, paramName);
                }

                return null;
            }

            return csSymbol;
        }

        [return: NotNullIfNotNull("symbol")]
        internal static AssemblySymbol? EnsureLanguageSymbolOrNull(this IAssemblySymbol? symbol, string paramName)
        {
            return (AssemblySymbol?)EnsureLanguageSymbolOrNull((ISymbol?)symbol, paramName);
        }

        [return: NotNullIfNotNull("symbol")]
        internal static NamespaceOrTypeSymbol? EnsureLanguageSymbolOrNull(this INamespaceOrTypeSymbol? symbol, string paramName)
        {
            return (NamespaceOrTypeSymbol?)EnsureLanguageSymbolOrNull((ISymbol?)symbol, paramName);
        }

        [return: NotNullIfNotNull("symbol")]
        internal static NamespaceSymbol? EnsureLanguageSymbolOrNull(this INamespaceSymbol? symbol, string paramName)
        {
            return (NamespaceSymbol?)EnsureLanguageSymbolOrNull((ISymbol?)symbol, paramName);
        }

        [return: NotNullIfNotNull("symbol")]
        internal static TypeSymbol? EnsureLanguageSymbolOrNull(this ITypeSymbol? symbol, string paramName)
        {
            return (TypeSymbol?)EnsureLanguageSymbolOrNull((ISymbol?)symbol, paramName);
        }

        [return: NotNullIfNotNull("symbol")]
        internal static NamedTypeSymbol? EnsureLanguageSymbolOrNull(this INamedTypeSymbol? symbol, string paramName)
        {
            return (NamedTypeSymbol?)EnsureLanguageSymbolOrNull((ISymbol?)symbol, paramName);
        }

        [return: NotNullIfNotNull("symbol")]
        internal static TypeParameterSymbol? EnsureLanguageSymbolOrNull(this ITypeParameterSymbol? symbol, string paramName)
        {
            return (TypeParameterSymbol?)EnsureLanguageSymbolOrNull((ISymbol?)symbol, paramName);
        }

        [return: NotNullIfNotNull("symbol")]
        internal static EventSymbol? EnsureLanguageSymbolOrNull(this IEventSymbol? symbol, string paramName)
        {
            return (EventSymbol?)EnsureLanguageSymbolOrNull((ISymbol?)symbol, paramName);
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
            switch (symbol.Kind.Switch())
            {
                case SymbolKind.ConstructedType:
                case SymbolKind.DynamicType:
                case SymbolKind.ErrorType:
                case SymbolKind.NamedType:
                    return true;
                case SymbolKind.Alias:
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

        private static readonly Func<TypeSymbol, object, bool, bool> s_containsDynamicPredicate = (type, unused1, unused2) => type.TypeKind == TypeKind.Dynamic;

        public static BinderPosition ToBinderPosition(this SyntaxReference reference, LanguageCompilation compilation)
        {
            if (reference == null || compilation == null) return default;
            var syntax = reference.Resolve();
            var binder = compilation.GetBinder(syntax);
            return new BinderPosition(binder, binder, syntax);
        }

    }
}
