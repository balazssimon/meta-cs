using MetaDslx.CodeAnalysis.Binding.BoundNodes;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
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

        public override void InitializeQualifierSymbol(BoundQualifier qualifier)
        {
            var length = qualifier.Identifiers.Length;
            if (length == 1)
            {
                qualifier.InitializeValues(qualifier.Identifiers, ImmutableArray.Create(this.Value));
            }
            else if (length > 1)
            {
                var values = ArrayBuilder<object>.GetInstance();
                for (int i = 0; i < length; i++)
                {
                    if (i < length - 1) values.Add(null);
                    else values.Add(this.Value);
                }
                qualifier.InitializeValues(qualifier.Identifiers, values.ToImmutableAndFree());
            }
            else
            {
                qualifier.InitializeValues(qualifier.Identifiers, ImmutableArray<object>.Empty);
            }
        }
    }
}
