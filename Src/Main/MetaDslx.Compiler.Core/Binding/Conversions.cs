using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Binding
{
    public class Conversions
    {
        private const int MaximumRecursionDepth = 50;

        private readonly Binder _binder;
        private readonly int _currentRecursionDepth;

        public Conversions(Binder binder)
            : this(binder, currentRecursionDepth: 0)
        {
        }

        private Conversions(Binder binder, int currentRecursionDepth)
        {
            _binder = binder;
            _currentRecursionDepth = currentRecursionDepth;
        }

        private Compilation Compilation { get { return _binder.Compilation; } }

    }
}
