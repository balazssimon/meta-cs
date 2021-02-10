using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class SymbolAttribute : Attribute
    {
        private LanguageSymbolKind _symbolKind;

        public SymbolAttribute(LanguageSymbolKind symbolKind)
        {
            _symbolKind = symbolKind;
        }

        public LanguageSymbolKind SymbolKind => _symbolKind;
    }
}
