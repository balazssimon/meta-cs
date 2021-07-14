using MetaDslx.CodeAnalysis.Analyzers.CodeGeneration;
using MetaDslx.CodeAnalysis.Symbols.CodeGeneration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MetaDslx.CodeAnalysis.Analyzers.Symbols
{
    using MetaDslx.CodeAnalysis.Symbols;
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
                    if (info.SymbolParts != SymbolParts.None)
                    {
                        var completionSymbolCode = generator.GenerateCompletionSymbol(info);
                        context.AddSource("Completion" + symbol.Name + ".Generated.cs", completionSymbolCode);
                        if (info.SymbolParts.HasFlag(SymbolParts.Metadata))
                        {
                            var metaSymbolCode = generator.GenerateMetadataSymbol(info);
                            context.AddSource("Metadata" + symbol.Name + ".Generated.cs", metaSymbolCode);
                        }
                        if (info.SymbolParts.HasFlag(SymbolParts.Source))
                        {
                            var sourceSymbolCode = generator.GenerateSourceSymbol(info);
                            context.AddSource("Source" + symbol.Name + ".Generated.cs", sourceSymbolCode);
                        }
                    }
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
            SymbolParts symbolParts = SymbolParts.All;
            ParameterOption modelObjectOption = ParameterOption.Required;
            string? kind = null;
            string? subSymbolKindType = null;
            string? subSymbolKindName = null;
            foreach (var arg in symbolAttribute.NamedArguments)
            {
                if (arg.Key == "SymbolParts")
                {
                    symbolParts = (SymbolParts)arg.Value.Value;
                }
                if (arg.Key == "ModelObjectOption")
                {
                    modelObjectOption = (ParameterOption)arg.Value.Value;
                }
                if (arg.Key == "SymbolKind")
                {
                    kind = (string?)arg.Value.Value;
                }
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
            var cpgi = GetCompletionPartGenerationInfos(symbol);
            return
                new SymbolGenerationInfo(symbol.Name, ns, kind, subSymbolKindType, subSymbolKindName, parentInfo)
                {
                    SymbolParts = symbolParts,
                    ModelObjectOption = modelObjectOption,
                    CompletionParts = cpgi.completionParts,
                    ExistingCompletionMethodNames = cpgi.completionMethodNames,
                    ExistingMetadataMethodNames = cpgi.metadataMethodNames,
                    ExistingSourceMethodNames = cpgi.sourceMethodNames
                };
        }

        private (List<CompletionPartGenerationInfo> completionParts, HashSet<string> completionMethodNames, HashSet<string> metadataMethodNames, HashSet<string> sourceMethodNames) GetCompletionPartGenerationInfos(INamedTypeSymbol symbol)
        {
            var completionMethodNames = new HashSet<string>();
            var metadataMethodNames = new HashSet<string>();
            var sourceMethodNames = new HashSet<string>();
            var completionParts = new List<CompletionPartGenerationInfo>();
            var currentSymbol = symbol;
            while (currentSymbol != null)
            {
                foreach (var member in currentSymbol.GetMembers().Reverse().Where(m => m.DeclaringSyntaxReferences.Length > 0))
                {
                    CompletionPartGenerationInfo? cpgi = null;
                    if (member.Kind == Microsoft.CodeAnalysis.SymbolKind.Method)
                    {
                        cpgi = GetMethodGenerationInfo(member);
                    }
                    else if (member.Kind == Microsoft.CodeAnalysis.SymbolKind.Property)
                    {
                        cpgi = GetPropertyGenerationInfo(member);
                    }
                    if (cpgi is not null)
                    {
                        completionParts.Add(cpgi);
                    }
                }
                currentSymbol = currentSymbol.BaseType;
            }
            completionParts.Reverse();
            CollectMethodNames(symbol, ".Completion.Completion", completionMethodNames);
            CollectMethodNames(symbol, ".Metadata.Metadata", metadataMethodNames);
            CollectMethodNames(symbol, ".Source.Source", sourceMethodNames);
            return (completionParts, completionMethodNames, metadataMethodNames, sourceMethodNames);
        }

        private void CollectMethodNames(INamedTypeSymbol symbol, string namePrefix, HashSet<string> methodNames)
        {
            var completionSymbolName = symbol.ContainingSymbol.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat).Substring(8) + namePrefix + symbol.Name;
            var completionSymbol = symbol.ContainingAssembly.GetTypeByMetadataName(completionSymbolName);
            if (completionSymbol is not null)
            {
                foreach (var member in completionSymbol.GetMembers())
                {
                    if (member.Kind == Microsoft.CodeAnalysis.SymbolKind.Method)
                    {
                        methodNames.Add(member.Name);
                    }
                }
            }
        }

        private SymbolMethodGenerationInfo? GetMethodGenerationInfo(ISymbol member)
        {
            if (member.Kind == Microsoft.CodeAnalysis.SymbolKind.Method && member is IMethodSymbol method)
            {
                if (GeneratorUtils.IsCompletionMethod(method, out var attr))
                {
                    var completeMethodParameters = CompleteMethodParameters.None;
                    foreach (var param in method.Parameters)
                    {
                        if (param.Type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat) == "global::Microsoft.CodeAnalysis.SourceLocation")
                        {
                            completeMethodParameters |= CompleteMethodParameters.LocationOpt;
                        }
                        if (param.Type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat) == "global::Microsoft.CodeAnalysis.DiagnosticBag")
                        {
                            completeMethodParameters |= CompleteMethodParameters.Diagnostics;
                        }
                        if (param.Type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat) == "global::System.Threading.CancellationToken")
                        {
                            completeMethodParameters |= CompleteMethodParameters.CancellationToken;
                        }
                    }
                    bool locked = true;
                    foreach (var arg in attr.NamedArguments)
                    {
                        if (arg.Key == "IsLocked")
                        {
                            locked = (bool)arg.Value.Value!;
                        }
                    }
                    return new SymbolMethodGenerationInfo(method.Name, completeMethodParameters, locked);
                }
            }
            return null;
        }

        private SymbolPropertyGenerationInfo? GetPropertyGenerationInfo(ISymbol member)
        {
            if (member.Kind == Microsoft.CodeAnalysis.SymbolKind.Property && member is IPropertySymbol prop)
            {
                if (prop.Name == "Name") return null;
                if (GeneratorUtils.IsSymbolProperty(prop, out var attr))
                {
                    var type = prop.Type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);
                    string? itemType = null;
                    var isSymbol = false;
                    if (prop.Type is INamedTypeSymbol nts)
                    {
                        var originalType = nts.OriginalDefinition.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);
                        var isImmutableArray = originalType == "global::System.Collections.Immutable.ImmutableArray<T>" && nts.TypeArguments.Length == 1;
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
                    var completeMethodParameters = CompleteMethodParameters.All;
                    foreach (var arg in attr.NamedArguments)
                    {
                        if (arg.Key == "CompleteMethodParameters")
                        {
                            completeMethodParameters = (CompleteMethodParameters)arg.Value.Value!;
                        }
                    }
                    return new SymbolPropertyGenerationInfo(prop.Name, type, itemType, prop.IsAbstract, isSymbol, completeMethodParameters, true);
                }
            }
            return null;
        }
    }
}
