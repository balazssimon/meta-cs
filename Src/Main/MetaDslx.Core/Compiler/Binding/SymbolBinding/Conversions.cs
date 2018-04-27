using MetaDslx.Compiler.Binding.Binders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Binding.SymbolBinding
{
    public class Conversions
    {
        private const int MaximumRecursionDepth = 50;

        private readonly ISymbolBinder _binder;
        private readonly int _currentRecursionDepth;

        public Conversions(ISymbolBinder binder)
            : this(binder, currentRecursionDepth: 0)
        {
        }

        private Conversions(ISymbolBinder binder, int currentRecursionDepth)
        {
            _binder = binder;
            _currentRecursionDepth = currentRecursionDepth;
        }

        private Compilation Compilation { get { return _binder.Compilation; } }

    }
}
