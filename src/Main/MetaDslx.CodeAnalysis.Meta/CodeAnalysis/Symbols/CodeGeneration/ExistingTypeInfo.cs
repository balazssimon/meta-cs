using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols.CodeGeneration
{
    public class ExistingTypeInfo
    {
        public ExistingTypeInfo(bool isSealed, string baseType, HashSet<string> members)
        {
            this.IsSealed = isSealed;
            this.BaseType = baseType;
            this.Members = members;
        }

        public bool IsSealed { get; init; }
        public string BaseType { get; init; }
        public HashSet<string> Members { get; init; }
    }
}
