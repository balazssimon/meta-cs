using System;
using System.Collections.Generic;
using System.Text;
using MetaDslx.Compiler.Utilities;
using MetaDslx.Core;

namespace MetaDslx.Compiler.Binding.SymbolBinding
{
    public class SymbolDefBinder : SymbolBinder
    {
        private Type _symbolType;

        public SymbolDefBinder(Binder next, Type symbolType) : base(next)
        {
            _symbolType = symbolType;
        }

        public override bool GetName(LookupResult<Qualifier> result)
        {
            return true;
        }

        public override bool GetProperty(LookupResult<Property> result)
        {
            return true;
        }

        public override bool GetSymbol(LookupResult<ISymbol> result)
        {
            return true;
        }

        public override bool GetValue(LookupResult<object> result)
        {
            return true;
        }

        public override bool GetQualifier(LookupResult<Qualifier> result)
        {
            return true;
        }

        public override bool GetIdentifier(LookupResult<string> result)
        {
            return true;
        }
    }
}
