using MetaDslx.Compiler.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Compiler.Binding.SymbolBinding
{
    public class NameBinder : SymbolBinder
    {
        public NameBinder(Binder next) : base(next)
        {
        }

        public override bool AddNameBinder(ArrayBuilder<ISymbolBinder> result)
        {
            result.Add(this);
            return true;
        }

    }
}
