using MetaDslx.Compiler.Binding.Binders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Binding.SymbolBinding
{
    public class OverloadResolution
    {
        private readonly ISymbolBinder _binder;

        public OverloadResolution(ISymbolBinder binder)
        {
            _binder = binder;
        }

        private Compilation Compilation
        {
            get { return _binder.Compilation; }
        }

        private Conversions Conversions
        {
            get { return _binder.Conversions; }
        }
    }
}
