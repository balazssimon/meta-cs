extern alias msca;
using msca::Microsoft.CodeAnalysis;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetaDslx.CodeAnalysis.Analyzers
{
    using INamedTypeSymbol = msca::Microsoft.CodeAnalysis.INamedTypeSymbol;

    internal static class GeneratorUtils
    {
        private const string SourceItemGroupMetadata = "build_metadata.AdditionalFiles.SourceItemGroup";

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

        public static bool IsCompletionMethod(IMethodSymbol method, out AttributeData symbolMethodAttribute)
        {
            symbolMethodAttribute = null;
            if (method.DeclaringSyntaxReferences.IsDefaultOrEmpty) return false;
            foreach (var attr in method.GetAttributes())
            {
                if (attr.AttributeClass.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat) == "global::MetaDslx.CodeAnalysis.Symbols.SymbolCompletionPartAttribute")
                {
                    symbolMethodAttribute = attr;
                    return true;
                }
            }
            return false;
        }

        public static string GetFullName(this INamespaceOrTypeSymbol namedType)
        {
            return namedType.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat).Substring(8);
        }

        public static IEnumerable<INamedTypeSymbol> GetSourceNamedTypeSymbols(Compilation compilation)
        {
            var stack = new Stack<INamespaceSymbol>();
            stack.Push(compilation.SourceModule.GlobalNamespace);

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

        public static bool IsExportedSymbol(INamedTypeSymbol namedType, out AttributeData attribute)
        {
            attribute = null;
            if (!IsSymbol(namedType)) return false;
            foreach (var attr in namedType.GetAttributes())
            {
                if (attr.AttributeClass.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat) == "global::System.ComponentModel.Composition.ExportAttribute")
                {
                    attribute = attr;
                    return true;
                }
            }
            return false;
        }


        public static string GetMSBuildProperty(
            this GeneratorExecutionContext context,
            string name,
            string defaultValue = "")
        {
            context.AnalyzerConfigOptions.GlobalOptions.TryGetValue($"build_property.{name}", out var value);
            return value ?? defaultValue;
        }

        public static string[] GetMSBuildItems(this GeneratorExecutionContext context, string name)
            => context
                .AdditionalFiles
                .Where(f => context.AnalyzerConfigOptions
                    .GetOptions(f)
                    .TryGetValue(SourceItemGroupMetadata, out var sourceItemGroup)
                    && sourceItemGroup == name)
                .Select(f => f.Path)
                .ToArray();


        public static string ToPascalCase(this string name)
        {
            if (string.IsNullOrEmpty(name)) return name;
            else return name[0].ToString().ToUpper() + name.Substring(1);
        }

        public static string ToCamelCase(this string name)
        {
            if (string.IsNullOrEmpty(name)) return name;
            else return name[0].ToString().ToLower() + name.Substring(1);
        }
    }
}
