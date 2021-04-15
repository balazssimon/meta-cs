using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols.CodeGeneration
{
    public class SymbolGenerationInfo
    {
        public SymbolGenerationInfo(string name, string namespaceName, bool hasSubSymbolKinds, SymbolGenerationInfo parentSymbol)
        {
            this.Name = name;
            this.NamespaceName = namespaceName;
            this.ParentSymbol = parentSymbol;
            if (name == "Symbol")
            {
                IsSymbolClass = true;
                SymbolKind = "None";
                SubSymbolKind = "SymbolKind";
                SubSymbolKindName = "Kind";
            }
            else
            {
                SymbolKind = Name.Substring(0, Name.Length - 6);
                if (hasSubSymbolKinds)
                {
                    SubSymbolKind = SymbolKind + "Kind";
                    SubSymbolKindName = SubSymbolKind;
                }
            }
        }

        public bool IsSymbolClass { get; private set; }
        public string Name { get; private set; }
        public string NamespaceName { get; private set; }
        public string SymbolKind { get; private set; }
        public string SubSymbolKindName { get; private set; }
        public string SubSymbolKind { get; private set; }
        public SymbolGenerationInfo ParentSymbol { get; private set; }
    }
}
