using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Analyzers
{
    using Microsoft.CodeAnalysis;

    internal static class GeneratorUtils
    {
        public static bool IsSourceSymbol(INamedTypeSymbol namedType)
        {
            if (namedType.DeclaringSyntaxReferences.IsDefaultOrEmpty) return false;
            if (namedType.TypeKind != TypeKind.Class) return false;
            foreach (var intf in namedType.Interfaces)
            {
                if (intf.Name == "ISourceSymbol") return true;
            }
            return false;
        }

        public static bool IsSymbol(INamedTypeSymbol namedType, out AttributeData symbolAttribute)
        {
            symbolAttribute = null;
            if (namedType.DeclaringSyntaxReferences.IsDefaultOrEmpty) return false;
            if (namedType.TypeKind != TypeKind.Class) return false;
            foreach (var attr in namedType.GetAttributes())
            {
                if (attr.AttributeClass.Name == "SymbolAttribute")
                {
                    symbolAttribute = attr;
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
