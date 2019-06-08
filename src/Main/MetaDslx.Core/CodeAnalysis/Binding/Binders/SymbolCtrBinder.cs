using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding.Binders
{
    public class SymbolCtrBinder : Binder
    {
        private readonly Type _symbolType;

        public SymbolCtrBinder(Binder next, SyntaxNodeOrToken syntax, Type symbolType)
            : base(next, syntax)
        {
            _symbolType = symbolType;
        }

    }
}
