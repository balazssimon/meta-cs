using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class ModelObjectSymbolAttribute : Attribute
    {
        private Type _symbolType;

        public ModelObjectSymbolAttribute(Type symbolType)
        {
            _symbolType = symbolType;
        }

        public Type SymbolType => _symbolType;
    }
}
