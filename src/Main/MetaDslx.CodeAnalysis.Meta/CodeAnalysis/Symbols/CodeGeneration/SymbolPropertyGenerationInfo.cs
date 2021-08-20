using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols.CodeGeneration
{
    public class SymbolPropertyGenerationInfo : CompletionPartGenerationInfo
    {
        public SymbolPropertyGenerationInfo(string containingTypeFullName, string name, string type, string itemType, bool isAbstract, bool isSymbol, CompleteMethodParameters completeMethodParameters, bool generateCompleteMethod)
            : base(containingTypeFullName, "ComputingProperty_" + name, "CompleteSymbolProperty_" + name, completeMethodParameters, generateCompleteMethod, true)
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

        public override string CompleteMethodReturnType => this.Type;
    }
}
