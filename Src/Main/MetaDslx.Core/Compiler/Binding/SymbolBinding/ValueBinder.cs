using MetaDslx.Compiler.Syntax;
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
        private Optional<object> _value;

        public ValueBinder(Binder next, Optional<object> value) : base(next)
        {
            _value = value;
        }

        public override bool GetValue(LookupResult<object> result)
        {
            object value;
            if (_value.HasValue)
            {
                value = _value.Value;
            }
            else
            {
                value = this.GetNodeValue(this.RedNode);
            }
            result.MergeEqual(LookupResult<object>.Good(value));
            return true;
        }

        protected virtual object GetNodeValue(RedNode node)
        {
            return this.Compilation.SymbolResolution.GetValue(node);
        }
    }
}
