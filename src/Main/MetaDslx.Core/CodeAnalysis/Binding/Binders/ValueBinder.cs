using Microsoft.CodeAnalysis;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Binding.Binders
{
    public class ValueBinder : Binder
    {
        private Lazy<object> _lazyValue;

        public ValueBinder(Binder next, object value)
            : base(next)
        {
            _lazyValue = new Lazy<object>(() => value);
        }

        protected ValueBinder(Binder next)
            : base(next)
        {
            _lazyValue = new Lazy<object>(this.ComputeValue, true);
        }

        public object Value => _lazyValue.Value;

        protected virtual object ComputeValue()
        {
            throw ExceptionUtilities.Unreachable;
        }
    }
}
