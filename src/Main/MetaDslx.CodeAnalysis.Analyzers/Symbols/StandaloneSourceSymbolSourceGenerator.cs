using MetaDslx.CodeAnalysis.Analyzers.CodeGeneration;
using MetaDslx.CodeAnalysis.Symbols.CodeGeneration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MetaDslx.CodeAnalysis.Analyzers.Symbols
{
    using Microsoft.CodeAnalysis;
    using System.Collections.Immutable;

    public class StandaloneSourceSymbolSourceGenerator : IStandaloneSourceGenerator
    {
        private Dictionary<INamedTypeSymbol, SymbolGenerationInfo> _info = new Dictionary<INamedTypeSymbol, SymbolGenerationInfo>();

        public void Execute(StandaloneGeneratorExecutionContext context)
        {
            var generator = new SymbolGenerator();
            var symbols = new List<SymbolGenerationInfo>();
            foreach (var symbol in GeneratorUtils.GetNamedTypeSymbols(context.Compilation).Where(s => s.DeclaringSyntaxReferences.Length > 0))
            {
                var info = GetSymbolGenerationInfo(symbol);
                if (info != null)
                {
                    symbols.Add(info);
                    Debug.WriteLine($"Generating source symbol for: {info.NamespaceName}.{info.Name}");
                    var symbolCode = generator.GenerateSymbol(info);
                    context.AddSource(symbol.Name + ".Generated.cs", symbolCode);
                    var modelSymbolCode = generator.GenerateModelSymbol(info);
                    context.AddSource("Model" + symbol.Name + ".Generated.cs", modelSymbolCode);
                    var metaSymbolCode = generator.GenerateMetaSymbol(info);
                    context.AddSource("Meta" + symbol.Name + ".Generated.cs", metaSymbolCode);
                    var sourceSymbolCode = generator.GenerateSourceSymbol(info);
                    context.AddSource("Source" + symbol.Name + ".Generated.cs", sourceSymbolCode);
                }
            }
            var symbolsByNamespace = symbols.GroupBy(s => s.NamespaceName);
            foreach (var sns in symbolsByNamespace)
            {
                Debug.WriteLine($"Generating symbol visitor for: {sns.Key}");
                var visitorCode = generator.GenerateVisitor(sns.Key, sns);
                context.AddSource(sns.Key+".Visitor.Generated.cs", visitorCode);
            }
        }

        private SymbolGenerationInfo? GetSymbolGenerationInfo(INamedTypeSymbol symbol)
        {
            if (_info.TryGetValue(symbol, out var info)) return info;
            if (!GeneratorUtils.IsAnnotatedSymbol(symbol, out var symbolAttribute)) return null;
            var ns = GeneratorUtils.GetFullName(symbol.ContainingNamespace);
            string? subSymbolKindType = null;
            string? subSymbolKindName = null;
            foreach (var arg in symbolAttribute.NamedArguments)
            {
                if (arg.Key == "SubSymbolKindType")
                {
                    subSymbolKindType = (string?)arg.Value.Value;
                }
                if (arg.Key == "SubSymbolKindName")
                {
                    subSymbolKindName = (string?)arg.Value.Value;
                }
            }
            var baseSymbol = symbol.BaseType;
            SymbolGenerationInfo? parentInfo = null;
            while (baseSymbol is not null)
            {
                parentInfo = GetSymbolGenerationInfo(baseSymbol);
                if (parentInfo is not null) break;
                baseSymbol = baseSymbol.BaseType;
            }
            return new SymbolGenerationInfo(symbol.Name, ns, subSymbolKindType, subSymbolKindName, parentInfo, GetSymbolPropertyGenerationInfos(symbol));
        }

        private List<SymbolPropertyGenerationInfo> GetSymbolPropertyGenerationInfos(INamedTypeSymbol symbol)
        {
            var result = new List<SymbolPropertyGenerationInfo>();
            foreach (var member in symbol.GetMembers())
            {
                if (member.Kind == SymbolKind.Property && member is IPropertySymbol prop)
                {
                    if (GeneratorUtils.IsSymbolProperty(prop, out var attr))
                    {
                        var type = prop.Type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);
                        string? itemType = null;
                        var isSymbol = false;
                        var isImmutableArray = false;
                        if (prop.Type is INamedTypeSymbol nts)
                        {
                            var originalType = nts.OriginalDefinition.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);
                            isImmutableArray = originalType == "global::System.Collections.Immutable.ImmutableArray<T>" && nts.TypeArguments.Length == 1;
                            if (isImmutableArray)
                            {
                                var innerType = nts.TypeArguments[0];
                                itemType = innerType.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);
                                isSymbol = GeneratorUtils.IsSymbol(innerType as INamedTypeSymbol);
                            }
                            else
                            {
                                isSymbol = GeneratorUtils.IsSymbol(prop.Type as INamedTypeSymbol);
                            }
                        }
                        result.Add(new SymbolPropertyGenerationInfo(prop.Name, type, itemType, prop.IsAbstract, isSymbol));
                    }
                }
            }
            return result;
        }

    }
}
