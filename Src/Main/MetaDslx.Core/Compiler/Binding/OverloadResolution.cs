using MetaDslx.Compiler.Binding.Binders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Binding
{
    public class OverloadResolution<TBinder>
        where TBinder: Binder<TBinder>, ITypeBinder<TBinder>
    {
        private readonly TBinder _binder;

        public OverloadResolution(TBinder binder)
        {
            _binder = binder;
        }

        private Compilation Compilation
        {
            get { return _binder.Compilation; }
        }

        private Conversions<TBinder> Conversions
        {
            get { return _binder.Conversions; }
        }
    }
}
