using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Analyzers.Symbols
{
    public class ExistingTypeInfo
    {
        public ExistingTypeInfo(bool isSealed, string baseType, HashSet<string> members)
        {
            this.IsSealed = isSealed;
            this.BaseType = baseType;
            this.Members = members;
        }

        public bool IsSealed { get; set; }
        public string BaseType { get; set; }
        public HashSet<string> Members { get; set; }
    }
}
