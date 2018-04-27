using System;
using System.Collections.Generic;
using System.Text;
using MetaDslx.Compiler.Utilities;

namespace MetaDslx.Compiler.Binding.SymbolBinding
{
    public class QualifierBinder : SymbolBinder
    {
        public QualifierBinder(Binder next) : base(next)
        {
        }

        public override bool AddValueBinder(ArrayBuilder<ISymbolBinder> result)
        {
            result.Add(this);
            return true;
        }
    }
}
