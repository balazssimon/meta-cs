using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols.CodeGeneration
{
    public class SymbolPropertyGenerationInfo
    {
        public SymbolPropertyGenerationInfo(string name, string type, string itemType, bool isAbstract, bool isSymbol)
        {
            this.Name = name;
            this.FieldName = "_"+name.ToCamelCase();
            this.Type = type;
            this.ItemType = itemType;
            this.IsAbstract = isAbstract;
            this.IsSymbol = isSymbol;
            this.IsCollection = itemType != null;
        }

        public string Name { get; private set; }
        public string FieldName { get; private set; }
        public string Type { get; private set; }
        public string ItemType { get; private set; }
        public bool IsAbstract { get; private set; }
        public bool IsSymbol { get; private set; }
        public bool IsCollection { get; private set; }
    }
}
