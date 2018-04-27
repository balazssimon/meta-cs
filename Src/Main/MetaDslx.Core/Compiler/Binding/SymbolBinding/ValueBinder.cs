using MetaDslx.Compiler.Utilities;
using MetaDslx.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MetaDslx.Compiler.Binding.SymbolBinding
{
    public class ValueBinder : SymbolBinder
    {
        private Lazy<Optional<object>> _value;

        public ValueBinder(Binder next, Optional<object> value) : base(next)
        {
            if (value.HasValue) _value = new Lazy<Optional<object>>(() => value);
            else _value = null;
        }

        public override void Bind()
        {
            Interlocked.CompareExchange(ref _value, new Lazy<Optional<object>>(() => this.LazyValue()), null);
        }

        private Optional<object> LazyValue()
        {
            var values = this.BoundNode.GetSynthesized(this, (ISymbolBinder sb) => sb.GetValue());
            if (values.Length == 1)
            {
                return new Optional<object>(values[0]);
            }
            else
            {
                //this.DiagnosticBag.Add();
                return Optional<object>.None;
            }
        }

        public override Optional<object> GetValue()
        {
            if (_value != null) return new Optional<object>(_value.Value);
            else return Optional<object>.None;
        }

        public override Optional<ISymbol> GetSymbol()
        {
            if (_value != null && _value.Value != null && _value.Value.Value is ISymbol) return new Optional<ISymbol>((ISymbol)_value.Value.Value);
            else return Optional<ISymbol>.None;
        }

        public override bool AddValueBinder(ArrayBuilder<ISymbolBinder> result)
        {
            result.Add(this);
            return true;
        }
    }
}
