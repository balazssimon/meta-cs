using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class SymbolAttribute : Attribute
    {
        public string SubSymbolKindType { get; set; }
        public string SubSymbolKindName { get; set; }
    }
}
