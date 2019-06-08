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

        public SymbolDefBinder(Binder next, SyntaxNodeOrToken syntax, Type symbolType, Type nestingSymbolType) 
            : base(next, syntax)
        {
            _symbolType = symbolType;
            _nestingSymbolType = nestingSymbolType;
        }

    }
}
