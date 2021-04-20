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
            var csSymbol = symbol as PublicModel.Symbol;

            if (csSymbol is null)
            {
                if (symbol is object)
                {
                    throw new ArgumentException(Microsoft.CodeAnalysis.CSharp.CSharpResources.NotACSharpSymbol, paramName);
                }

                return null;
            }

            return csSymbol.UnderlyingSymbol;
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

        [return: NotNullIfNotNull("symbol")]
        private static TISymbol? GetPublicSymbol<TISymbol>(this Symbol? symbol)
            where TISymbol : class, ISymbol
        {
            return (TISymbol?)symbol?.ISymbol;
        }

        [return: NotNullIfNotNull("symbol")]
        internal static ISymbol? GetPublicSymbol(this Symbol? symbol)
        {
            return symbol.GetPublicSymbol<ISymbol>();
        }

        [return: NotNullIfNotNull("symbol")]
        internal static IMethodSymbol? GetPublicSymbol(this MethodSymbol? symbol)
        {
            return symbol.GetPublicSymbol<IMethodSymbol>();
        }

        [return: NotNullIfNotNull("symbol")]
        internal static IPropertySymbol? GetPublicSymbol(this PropertySymbol? symbol)
        {
            return symbol.GetPublicSymbol<IPropertySymbol>();
        }

        [return: NotNullIfNotNull("symbol")]
        internal static INamedTypeSymbol? GetPublicSymbol(this NamedTypeSymbol? symbol)
        {
            return symbol.GetPublicSymbol<INamedTypeSymbol>();
        }

        [return: NotNullIfNotNull("symbol")]
        internal static INamespaceSymbol? GetPublicSymbol(this NamespaceSymbol? symbol)
        {
            return symbol.GetPublicSymbol<INamespaceSymbol>();
        }

        [return: NotNullIfNotNull("symbol")]
        internal static ITypeSymbol? GetPublicSymbol(this TypeSymbol? symbol)
        {
            return symbol.GetPublicSymbol<ITypeSymbol>();
        }

        [return: NotNullIfNotNull("symbol")]
        internal static ILocalSymbol? GetPublicSymbol(this LocalSymbol? symbol)
        {
            return symbol.GetPublicSymbol<ILocalSymbol>();
        }

        [return: NotNullIfNotNull("symbol")]
        internal static IAssemblySymbol? GetPublicSymbol(this AssemblySymbol? symbol)
        {
            return symbol.GetPublicSymbol<IAssemblySymbol>();
        }

        [return: NotNullIfNotNull("symbol")]
        internal static ISymbol? GetPublicSymbol(this DeclaredSymbol? symbol)
        {
            return symbol.GetPublicSymbol<ISymbol>();
        }

        [return: NotNullIfNotNull("symbol")]
        internal static INamespaceOrTypeSymbol? GetPublicSymbol(this NamespaceOrTypeSymbol? symbol)
        {
            return symbol.GetPublicSymbol<INamespaceOrTypeSymbol>();
        }

        [return: NotNullIfNotNull("symbol")]
        internal static IDiscardSymbol? GetPublicSymbol(this DiscardSymbol? symbol)
        {
            return symbol.GetPublicSymbol<IDiscardSymbol>();
        }

        [return: NotNullIfNotNull("symbol")]
        internal static IFieldSymbol? GetPublicSymbol(this FieldSymbol? symbol)
        {
            return symbol.GetPublicSymbol<IFieldSymbol>();
        }

        [return: NotNullIfNotNull("symbol")]
        internal static IParameterSymbol? GetPublicSymbol(this ParameterSymbol? symbol)
        {
            return symbol.GetPublicSymbol<IParameterSymbol>();
        }

        [return: NotNullIfNotNull("symbol")]
        internal static IRangeVariableSymbol? GetPublicSymbol(this RangeVariableSymbol? symbol)
        {
            return symbol.GetPublicSymbol<IRangeVariableSymbol>();
        }

        [return: NotNullIfNotNull("symbol")]
        internal static ILabelSymbol? GetPublicSymbol(this LabelSymbol? symbol)
        {
            return symbol.GetPublicSymbol<ILabelSymbol>();
        }

        [return: NotNullIfNotNull("symbol")]
        internal static IAliasSymbol? GetPublicSymbol(this AliasSymbol? symbol)
        {
            return symbol.GetPublicSymbol<IAliasSymbol>();
        }

        [return: NotNullIfNotNull("symbol")]
        internal static IModuleSymbol? GetPublicSymbol(this ModuleSymbol? symbol)
        {
            return symbol.GetPublicSymbol<IModuleSymbol>();
        }

        [return: NotNullIfNotNull("symbol")]
        internal static ITypeParameterSymbol? GetPublicSymbol(this TypeParameterSymbol? symbol)
        {
            return symbol.GetPublicSymbol<ITypeParameterSymbol>();
        }

        [return: NotNullIfNotNull("symbol")]
        internal static IArrayTypeSymbol? GetPublicSymbol(this ArrayTypeSymbol? symbol)
        {
            return symbol.GetPublicSymbol<IArrayTypeSymbol>();
        }

        [return: NotNullIfNotNull("symbol")]
        internal static IPointerTypeSymbol? GetPublicSymbol(this PointerTypeSymbol? symbol)
        {
            return symbol.GetPublicSymbol<IPointerTypeSymbol>();
        }

        [return: NotNullIfNotNull("symbol")]
        internal static IFunctionPointerTypeSymbol? GetPublicSymbol(this FunctionPointerTypeSymbol? symbol)
        {
            return symbol.GetPublicSymbol<IFunctionPointerTypeSymbol>();
        }

        [return: NotNullIfNotNull("symbol")]
        internal static IEventSymbol? GetPublicSymbol(this EventSymbol? symbol)
        {
            return symbol.GetPublicSymbol<IEventSymbol>();
        }

        internal static IEnumerable<ISymbol?> GetPublicSymbols(this IEnumerable<Symbol?> symbols)
        {
            return symbols.Select(p => p.GetPublicSymbol<ISymbol>());
        }

        private static ImmutableArray<TISymbol> GetPublicSymbols<TISymbol>(this ImmutableArray<Symbol> symbols)
            where TISymbol : class, ISymbol
        {
            if (symbols.IsDefault)
            {
                return default;
            }

            return symbols.SelectAsArray(p => p.GetPublicSymbol<TISymbol>());
        }

        internal static ImmutableArray<ISymbol> GetPublicSymbols(this ImmutableArray<Symbol> symbols)
        {
            return GetPublicSymbols<ISymbol>(symbols);
        }

        internal static ImmutableArray<ISymbol> GetPublicSymbols(this ImmutableArray<DeclaredSymbol> symbols)
        {
            return GetPublicSymbols<ISymbol>(StaticCast<Symbol>.From(symbols));
        }

        internal static ImmutableArray<IPropertySymbol> GetPublicSymbols(this ImmutableArray<PropertySymbol> symbols)
        {
            return GetPublicSymbols<IPropertySymbol>(StaticCast<Symbol>.From(symbols));
        }

        internal static ImmutableArray<ITypeSymbol> GetPublicSymbols(this ImmutableArray<TypeSymbol> symbols)
        {
            return GetPublicSymbols<ITypeSymbol>(StaticCast<Symbol>.From(symbols));
        }

        internal static ImmutableArray<INamedTypeSymbol> GetPublicSymbols(this ImmutableArray<NamedTypeSymbol> symbols)
        {
            return GetPublicSymbols<INamedTypeSymbol>(StaticCast<Symbol>.From(symbols));
        }

        internal static ImmutableArray<ILocalSymbol> GetPublicSymbols(this ImmutableArray<LocalSymbol> symbols)
        {
            return GetPublicSymbols<ILocalSymbol>(StaticCast<Symbol>.From(symbols));
        }

        internal static ImmutableArray<IEventSymbol> GetPublicSymbols(this ImmutableArray<EventSymbol> symbols)
        {
            return GetPublicSymbols<IEventSymbol>(StaticCast<Symbol>.From(symbols));
        }

        internal static ImmutableArray<ITypeParameterSymbol> GetPublicSymbols(this ImmutableArray<TypeParameterSymbol> symbols)
        {
            return GetPublicSymbols<ITypeParameterSymbol>(StaticCast<Symbol>.From(symbols));
        }

        internal static ImmutableArray<IParameterSymbol> GetPublicSymbols(this ImmutableArray<ParameterSymbol> symbols)
        {
            return GetPublicSymbols<IParameterSymbol>(StaticCast<Symbol>.From(symbols));
        }

        internal static ImmutableArray<IMethodSymbol> GetPublicSymbols(this ImmutableArray<MethodSymbol> symbols)
        {
            return GetPublicSymbols<IMethodSymbol>(StaticCast<Symbol>.From(symbols));
        }

        internal static ImmutableArray<IAssemblySymbol> GetPublicSymbols(this ImmutableArray<AssemblySymbol> symbols)
        {
            return GetPublicSymbols<IAssemblySymbol>(StaticCast<Symbol>.From(symbols));
        }

        internal static ImmutableArray<IFieldSymbol> GetPublicSymbols(this ImmutableArray<FieldSymbol> symbols)
        {
            return GetPublicSymbols<IFieldSymbol>(StaticCast<Symbol>.From(symbols));
        }

        internal static ImmutableArray<INamespaceSymbol> GetPublicSymbols(this ImmutableArray<NamespaceSymbol> symbols)
        {
            return GetPublicSymbols<INamespaceSymbol>(StaticCast<Symbol>.From(symbols));
        }

        [return: NotNullIfNotNull("symbol")]
        internal static TSymbol? GetSymbol<TSymbol>(this ISymbol? symbol)
            where TSymbol : Symbol
        {
            return (TSymbol?)((PublicModel.Symbol?)symbol)?.UnderlyingSymbol;
        }

        [return: NotNullIfNotNull("symbol")]
        internal static Symbol? GetSymbol(this ISymbol? symbol)
        {
            return symbol.GetSymbol<Symbol>();
        }

        [return: NotNullIfNotNull("symbol")]
        internal static TypeSymbol? GetSymbol(this ITypeSymbol? symbol)
        {
            return symbol.GetSymbol<TypeSymbol>();
        }

        [return: NotNullIfNotNull("symbol")]
        internal static NamedTypeSymbol? GetSymbol(this INamedTypeSymbol? symbol)
        {
            return symbol.GetSymbol<NamedTypeSymbol>();
        }

        [return: NotNullIfNotNull("symbol")]
        internal static AliasSymbol? GetSymbol(this IAliasSymbol? symbol)
        {
            return symbol.GetSymbol<AliasSymbol>();
        }

        [return: NotNullIfNotNull("symbol")]
        internal static LocalSymbol? GetSymbol(this ILocalSymbol? symbol)
        {
            return symbol.GetSymbol<LocalSymbol>();
        }

        [return: NotNullIfNotNull("symbol")]
        internal static AssemblySymbol? GetSymbol(this IAssemblySymbol? symbol)
        {
            return symbol.GetSymbol<AssemblySymbol>();
        }

        [return: NotNullIfNotNull("symbol")]
        internal static MethodSymbol? GetSymbol(this IMethodSymbol? symbol)
        {
            return symbol.GetSymbol<MethodSymbol>();
        }

        [return: NotNullIfNotNull("symbol")]
        internal static PropertySymbol? GetSymbol(this IPropertySymbol? symbol)
        {
            return symbol.GetSymbol<PropertySymbol>();
        }

        [return: NotNullIfNotNull("symbol")]
        internal static FunctionPointerTypeSymbol? GetSymbol(this IFunctionPointerTypeSymbol? symbol)
        {
            return symbol.GetSymbol<FunctionPointerTypeSymbol>();
        }

    }
}
