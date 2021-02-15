using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class SymbolAttribute : Attribute
    {
        private Type _symbolType;

        public SymbolAttribute(Type symbolType)
        {
            _symbolType = symbolType;
        }

        public Type SymbolType => _symbolType;
    }
}
