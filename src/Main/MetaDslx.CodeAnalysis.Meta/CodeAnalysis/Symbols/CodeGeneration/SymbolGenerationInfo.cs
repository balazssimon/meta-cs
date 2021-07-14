using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols.CodeGeneration
{
    public class SymbolGenerationInfo
    {
        public SymbolGenerationInfo(string name, string namespaceName, string kind, string? subSymbolKindType, string? subSymbolKindName, SymbolGenerationInfo parentSymbol)
        {
            this.Name = name;
            this.NamespaceName = namespaceName;
            this.ParentSymbol = parentSymbol;
            var baseSymbol = parentSymbol;
            var symbolKindType = parentSymbol?.SubSymbolKindType;
            var symbolKindName = parentSymbol?.SubSymbolKindName;
            while (baseSymbol is not null && symbolKindType is null)
            {
                symbolKindType = baseSymbol.SubSymbolKindType;
                symbolKindName = baseSymbol.SubSymbolKindName;
                baseSymbol = baseSymbol.ParentSymbol;
            }
            this.SymbolKindName = symbolKindName;
            this.SymbolKindType = symbolKindType;
            this.SubSymbolKindType = subSymbolKindType;
            this.SubSymbolKindName = subSymbolKindName ?? subSymbolKindType;
            if (name == "Symbol")
            {
                SymbolKind = kind ?? "None";
                IsSymbolClass = true;
            }
            else if (name.EndsWith("Symbol"))
            {
                SymbolKind = kind ?? Name.Substring(0, Name.Length - 6);
            }
            else
            {
                SymbolKind = kind ?? Name;
            }
        }

        public bool IsSymbolClass { get; private set; }
        public SymbolParts SymbolParts { get; init; }
        public ParameterOption ModelObjectOption { get; init; }
        public string Name { get; private set; }
        public string NamespaceName { get; private set; }
        public string SymbolKind { get; private set; }
        public string? SymbolKindType { get; private set; }
        public string? SymbolKindName { get; private set; }
        public string? SubSymbolKindName { get; private set; }
        public string? SubSymbolKindType { get; private set; }
        public SymbolGenerationInfo ParentSymbol { get; private set; }
        public List<CompletionPartGenerationInfo> CompletionParts { get; init; }
        public string? ExistingCompletionBaseType { get; init; }
        public string? ExistingMetadataBaseType { get; init; }
        public string? ExistingSourceBaseType { get; init; }
        public HashSet<string> ExistingCompletionMemberNames { get; init; }
        public HashSet<string> ExistingMetadataMemberNames { get; init; }
        public HashSet<string> ExistingSourceMemberNames { get; init; }

        public IEnumerable<SymbolPropertyGenerationInfo> Properties => this.CompletionParts.OfType<SymbolPropertyGenerationInfo>();
        public IEnumerable<SymbolMethodGenerationInfo> Methods => this.CompletionParts.OfType<SymbolMethodGenerationInfo>();

        public IEnumerable<string> GetCompletionPartNames()
        {
            foreach (var part in this.CompletionParts)
            {
                if (part.IsLocked)
                {
                    yield return part.StartCompletionPartName;
                    yield return part.FinishCompletionPartName;
                }
                else
                {
                    yield return part.CompletionPartName;
                }
            }
        }

        public IEnumerable<string> GetOrderedCompletionParts(bool withLocation)
        {
            yield return "CompletionGraph.StartInitializing";
            yield return "CompletionGraph.FinishInitializing";
            yield return "CompletionGraph.StartCreatingChildren";
            yield return "CompletionGraph.FinishCreatingChildren";
            foreach (var part in this.CompletionParts)
            {
                if (part.IsLocked)
                {
                    yield return part.StartCompletionPartName;
                    yield return part.FinishCompletionPartName;
                }
                else
                {
                    yield return part.CompletionPartName;
                }
            }
            yield return "CompletionGraph.StartComputingNonSymbolProperties";
            yield return "CompletionGraph.FinishComputingNonSymbolProperties";
            if (!withLocation)
            {
                yield return "CompletionGraph.ChildrenCompleted";
            }
        }
    }
}
