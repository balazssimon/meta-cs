using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding.Binders
{
    public class SymbolDefBinder : Binder
    {
        private readonly Type _symbolType;
        private readonly Type _nestingSymbolType;

        public SymbolDefBinder(Binder next, Type symbolType, Type nestingSymbolType) 
            : base(next)
        {
            _symbolType = symbolType;
            _nestingSymbolType = nestingSymbolType;
        }

    }
}
