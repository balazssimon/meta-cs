using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols.CodeGeneration
{
    public class SymbolGenerationInfo
    {
        public SymbolGenerationInfo(string name, string namespaceName, SymbolGenerationInfo parentSymbol)
        {
            this.Name = name;
            this.NamespaceName = namespaceName;
            this.ParentSymbol = parentSymbol;
            this.IsSymbolClass = this.Name == "Symbol" && parentSymbol == null;
        }

        public bool IsSymbolClass { get; private set; }
        public SymbolParts SymbolParts { get; init; }
        public ParameterOption ModelObjectOption { get; init; }
        public string Name { get; private set; }
        public string NamespaceName { get; private set; }
        public SymbolGenerationInfo ParentSymbol { get; private set; }
        public List<CompletionPartGenerationInfo> CompletionParts { get; init; }
        public ExistingTypeInfo ExistingTypeInfo { get; init; }
        public ExistingTypeInfo ExistingErrorTypeInfo { get; init; }
        public ExistingTypeInfo ExistingCompletionTypeInfo { get; init; }
        public ExistingTypeInfo ExistingMetadataTypeInfo { get; init; }
        public ExistingTypeInfo ExistingSourceTypeInfo { get; init; }

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

        public string GetCompletionPartValue(string name)
        {
            foreach (var part in this.CompletionParts)
            {
                if (part.IsLocked)
                {
                    if (name == part.StartCompletionPartName || name == part.FinishCompletionPartName) return GetCompletionPartValue(part.ContainingTypeFullName, name);
                }
                else
                {
                    if (name == part.CompletionPartName) return GetCompletionPartValue(part.ContainingTypeFullName, name);
                }
            }
            return name;
        }

        private string GetCompletionPartValue(string? containingTypeFullName, string name)
        {
            if (containingTypeFullName is not null) return containingTypeFullName + "." + name;
            else return $"new CompletionPart(nameof({name}))";
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
