using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class SymbolAttribute : Attribute
    {
        public bool NoSource { get; set; }
        public bool NoMeta { get; set; }
        public bool NoModel { get; set; }
        public bool OptionalModelObject { get; set; }
        public string SymbolKind { get; set; }
        public string SubSymbolKindType { get; set; }
        public string SubSymbolKindName { get; set; }
    }
}
