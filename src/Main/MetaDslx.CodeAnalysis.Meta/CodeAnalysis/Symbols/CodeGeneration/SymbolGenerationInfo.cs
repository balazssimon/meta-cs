using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols.CodeGeneration
{
    public class SymbolGenerationInfo
    {
        public SymbolGenerationInfo(string name, string namespaceName, bool isAbstract, string? subSymbolKindType, string? subSymbolKindName, SymbolGenerationInfo parentSymbol, List<SymbolPropertyGenerationInfo> properties)
        {
            this.Name = name;
            this.NamespaceName = namespaceName;
            this.IsAbstract = isAbstract;
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
                SymbolKind = "None";
                IsSymbolClass = true;
            }
            else if (name.EndsWith("Symbol"))
            {
                SymbolKind = Name.Substring(0, Name.Length - 6);
            }
            else
            {
                SymbolKind = Name;
            }
            this.Properties = properties;
        }

        public bool IsSymbolClass { get; private set; }
        public bool IsAbstract { get; private set; }
        public string Name { get; private set; }
        public string NamespaceName { get; private set; }
        public string SymbolKind { get; private set; }
        public string? SymbolKindType { get; private set; }
        public string? SymbolKindName { get; private set; }
        public string? SubSymbolKindName { get; private set; }
        public string? SubSymbolKindType { get; private set; }
        public SymbolGenerationInfo ParentSymbol { get; private set; }
        public List<SymbolPropertyGenerationInfo> Properties { get; private set; }
    }
}
