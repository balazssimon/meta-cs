using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MetaDslx.Compiler.Binding.Binders
{
    public interface ITypeBinder<TBinder>
        where TBinder : Binder<TBinder>
    {
        Conversions<TBinder> Conversions { get; }
    }

    public class TypeBinderPart<TBinder> : BinderPart<TBinder>, ITypeBinder<TBinder>
        where TBinder : Binder<TBinder>
    {
        public TypeBinderPart(TBinder binder) 
            : base(binder)
        {
        }

        private Conversions<TBinder> _lazyConversions;
        public Conversions<TBinder> Conversions
        {
            get
            {
                if (_lazyConversions == null)
                {
                    Interlocked.CompareExchange(ref _lazyConversions, new Conversions<TBinder>(this.Binder), null);
                }
                return _lazyConversions;
            }
        }

    }
}
