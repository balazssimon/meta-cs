using MetaDslx.Compiler.Binding.Binders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Binding
{
    public class Conversions<TBinder>
        where TBinder: Binder<TBinder>
    {
        private const int MaximumRecursionDepth = 50;

        private readonly TBinder _binder;
        private readonly int _currentRecursionDepth;

        public Conversions(TBinder binder)
            : this(binder, currentRecursionDepth: 0)
        {
        }

        private Conversions(TBinder binder, int currentRecursionDepth)
        {
            _binder = binder;
            _currentRecursionDepth = currentRecursionDepth;
        }

        private Compilation Compilation { get { return _binder.Compilation; } }

    }
}
