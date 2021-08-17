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
                }
            }
            var symbolsByNamespace = symbols.GroupBy(s => s.NamespaceName);
            foreach (var sns in symbolsByNamespace)
            {
                Debug.WriteLine($"Generating symbol factory for: {sns.Key}");
                var factoryCode = generator.GenerateFactory(sns.Key, sns);
                context.AddSource(sns.Key+".Factory.Generated.cs", factoryCode);
                Debug.WriteLine($"Generating symbol visitor for: {sns.Key}");
                var visitorCode = generator.GenerateVisitor(sns.Key, sns);
                context.AddSource(sns.Key + ".Visitor.Generated.cs", visitorCode);
            }
        }

        private SymbolGenerationInfo? GetSymbolGenerationInfo(INamedTypeSymbol symbol)
        {
            if (_info.TryGetValue(symbol, out var info)) return info;
            if (!GeneratorUtils.IsAnnotatedSymbol(symbol, out var symbolAttribute)) return null;
            var ns = GeneratorUtils.GetFullName(symbol.ContainingNamespace);
            SymbolParts symbolParts = SymbolParts.All;
            ParameterOption modelObjectOption = ParameterOption.Required;
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
                new SymbolGenerationInfo(symbol.Name, ns, parentInfo)
                {
                    SymbolParts = symbolParts,
                    ModelObjectOption = modelObjectOption,
                    CompletionParts = cpgi.completionParts,
                    ExistingTypeInfo = cpgi.typeInfo,
                    ExistingErrorTypeInfo = cpgi.errorTypeInfo,
                    ExistingCompletionTypeInfo = cpgi.completionTypeInfo,
                    ExistingMetadataTypeInfo = cpgi.metadataTypeInfo,
                    ExistingSourceTypeInfo = cpgi.sourceTypeInfo,
                };
        }

        private (List<CompletionPartGenerationInfo> completionParts, ExistingTypeInfo typeInfo, ExistingTypeInfo errorTypeInfo, ExistingTypeInfo completionTypeInfo, ExistingTypeInfo metadataTypeInfo, ExistingTypeInfo sourceTypeInfo) GetCompletionPartGenerationInfos(INamedTypeSymbol symbol)
        {
            var symbolName = symbol.ContainingSymbol.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);
            var errorName = GetSymbolName(symbol, ".Error.Error");
            var completionName = GetSymbolName(symbol, ".Completion.Completion");
            var metadataName = GetSymbolName(symbol, ".Metadata.Metadata");
            var sourceName = GetSymbolName(symbol, ".Source.Source");
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
            var typeInfo = GetExistingTypeInfo(symbol, null, null);
            var errorTypeInfo = GetExistingTypeInfo(symbol, errorName, symbolName);
            var completionTypeInfo = GetExistingTypeInfo(symbol, completionName, symbolName);
            var metadataTypeInfo = GetExistingTypeInfo(symbol, metadataName, completionName);
            var sourceTypeInfo = GetExistingTypeInfo(symbol, sourceName, completionName);
            return (completionParts, typeInfo, errorTypeInfo, completionTypeInfo, metadataTypeInfo, sourceTypeInfo);
        }

        private ExistingTypeInfo GetExistingTypeInfo(INamedTypeSymbol originalSymbol, string? symbolName, string? expectedBaseTypeName)
        {
            var symbol = symbolName == null ? originalSymbol : originalSymbol.ContainingAssembly.GetTypeByMetadataName(symbolName);
            string? baseType = null;
            var memberNames = new HashSet<string>();
            CollectMemberNames(originalSymbol, symbol, memberNames);
            if (symbol is not null)
            {
                var baseTypeName = symbol.BaseType.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);
                if (baseTypeName != "object" && baseTypeName != expectedBaseTypeName) baseType = baseTypeName;
            }
            return new ExistingTypeInfo(symbol?.IsSealed ?? false, baseType, memberNames);
        }

        private string GetSymbolName(INamedTypeSymbol symbol, string namePrefix)
        {
            return symbol.ContainingSymbol.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat).Substring(8) + namePrefix + symbol.Name;
        }

        private void CollectMemberNames(INamedTypeSymbol originalSymbol, INamedTypeSymbol symbol, HashSet<string> memberNames)
        {
            if (originalSymbol is not null)
            {
                foreach (var member in originalSymbol.GetMembers().Where(m => m.DeclaringSyntaxReferences.Length > 0))
                {
                    if (member.IsSealed && (member.Kind == Microsoft.CodeAnalysis.SymbolKind.Method || member.Kind == Microsoft.CodeAnalysis.SymbolKind.Property))
                    {
                        memberNames.Add(member.Name);
                    }
                }
            }
            if (symbol is not null)
            {
                foreach (var member in symbol.GetMembers().Where(m => m.DeclaringSyntaxReferences.Length > 0))
                {
                    if (member.Kind == Microsoft.CodeAnalysis.SymbolKind.Method || member.Kind == Microsoft.CodeAnalysis.SymbolKind.Property)
                    {
                        memberNames.Add(member.Name);
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
