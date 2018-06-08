using MetaDslx.Compiler.Utilities;
using MetaDslx.Core;
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

        public override bool GetName(LookupResult<Qualifier> result)
        {
            LookupResult<Qualifier> qualifiers = LookupResult<Qualifier>.GetInstance();
            try
            {
                this.GetQualifier(result);
            }
            finally
            {
                qualifiers.Free();
            }
            return true;
        }
    }
}
