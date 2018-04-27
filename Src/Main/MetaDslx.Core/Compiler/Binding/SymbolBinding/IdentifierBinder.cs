using MetaDslx.Compiler.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Compiler.Binding.SymbolBinding
{
    public class IdentifierBinder : SymbolBinder
    {
        public IdentifierBinder(Binder next) : base(next)
        {
        }

        public override bool AddNameBinder(ArrayBuilder<ISymbolBinder> result)
        {
            return true;
        }

        public override bool AddPropertyBinder(ArrayBuilder<ISymbolBinder> result)
        {
            return true;
        }

        public override bool AddValueBinder(ArrayBuilder<ISymbolBinder> result)
        {
            result.Add(this);
            return true;
        }

        public override bool AddIdentifierBinder(ArrayBuilder<ISymbolBinder> result)
        {
            result.Add(this);
            return true;
        }
    }
}
