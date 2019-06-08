using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Binding.Binders
{
    public class ValueBinder : Binder
    {
        private Lazy<object> _lazyValue;

        public ValueBinder(Binder next, SyntaxNodeOrToken syntax, object value)
            : base(next, syntax)
        {
            _lazyValue = new Lazy<object>(() => value);
        }

        protected ValueBinder(Binder next, SyntaxNodeOrToken syntax)
            : base(next, syntax)
        {
            _lazyValue = new Lazy<object>(this.CalculateValue, true);
        }

        public object Value => _lazyValue.Value;

        protected virtual object CalculateValue()
        {
            return null;
        }
    }
}
