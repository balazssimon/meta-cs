using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Analyzers
{
    using Microsoft.CodeAnalysis;

    internal static class GeneratorUtils
    {
        public static bool IsSymbol(INamedTypeSymbol namedType)
        {
            if (namedType == null) return false;
            if (namedType.DeclaringSyntaxReferences.IsDefaultOrEmpty) return false;
            if (namedType.TypeKind != TypeKind.Class) return false;
            var type = namedType;
            while (type != null)
            {
                if (type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat) == "global::MetaDslx.CodeAnalysis.Symbols.Symbol") return true;
                type = type.BaseType;
            }
            return false;
        }

        public static bool IsAnnotatedSymbol(INamedTypeSymbol namedType, out AttributeData symbolAttribute)
        {
            symbolAttribute = null;
            if (!IsSymbol(namedType)) return false;
            foreach (var attr in namedType.GetAttributes())
            {
                if (attr.AttributeClass.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat) == "global::MetaDslx.CodeAnalysis.Symbols.SymbolAttribute")
                {
                    symbolAttribute = attr;
                    return true;
                }
            }
            return false;
        }

        public static bool IsSymbolProperty(IPropertySymbol property, out AttributeData symbolPropertyAttribute)
        {
            symbolPropertyAttribute = null;
            if (property.DeclaringSyntaxReferences.IsDefaultOrEmpty) return false;
            foreach (var attr in property.GetAttributes())
            {
                if (attr.AttributeClass.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat) == "global::MetaDslx.CodeAnalysis.Symbols.SymbolPropertyAttribute")
                {
                    symbolPropertyAttribute = attr;
                    return true;
                }
            }
            return false;
        }

        public static string GetFullName(INamespaceOrTypeSymbol namedType)
        {
            return namedType.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat).Substring(8);
        }

        public static IEnumerable<INamedTypeSymbol> GetNamedTypeSymbols(Compilation compilation)
        {
            var stack = new Stack<INamespaceSymbol>();
            stack.Push(compilation.GlobalNamespace);

            while (stack.Count > 0)
            {
                var @namespace = stack.Pop();

                foreach (var member in @namespace.GetMembers())
                {
                    if (member is INamespaceSymbol memberAsNamespace)
                    {
                        stack.Push(memberAsNamespace);
                    }
                    else if (member is INamedTypeSymbol memberAsNamedTypeSymbol)
                    {
                        yield return memberAsNamedTypeSymbol;
                    }
                }
            }
        }

    }
}
