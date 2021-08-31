using MetaDslx.CodeAnalysis.Symbols;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace MetaDslx.CodeAnalysis.Analyzers.Symbols
{
    public class SymbolGenerationInfo
    {
        public SymbolGenerationInfo(string name, string namespaceName, SymbolGenerationInfo parentSymbol)
        {
            this.Name = name;
            this.NamespaceName = namespaceName;
            this.ParentSymbol = parentSymbol;
            this.IsSymbolClass = name == "Symbol" && parentSymbol == null;
        }

        public bool IsSymbolClass { get; private set; }
        public bool IsAbstract { get; set; }
        public SymbolParts SymbolParts { get; set; }
        public ParameterOption ModelObjectOption { get; set; }
        public string Name { get; private set; }
        public string NamespaceName { get; private set; }
        public SymbolGenerationInfo ParentSymbol { get; private set; }
        public List<CompletionPartGenerationInfo> CompletionParts { get; set; }
        public ExistingTypeInfo ExistingTypeInfo { get; set; }
        public ExistingTypeInfo ExistingErrorTypeInfo { get; set; }
        public ExistingTypeInfo ExistingCompletionTypeInfo { get; set; }
        public ExistingTypeInfo ExistingMetadataTypeInfo { get; set; }
        public ExistingTypeInfo ExistingSourceTypeInfo { get; set; }

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
            if (containingTypeFullName is not null && containingTypeFullName != NamespaceName + "." + Name) return containingTypeFullName + ".CompletionParts." + name;
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
                yield return "CompletionGraph.StartValidatingSymbol";
                yield return "CompletionGraph.FinishValidatingSymbol";
            }
        }
    }
}
