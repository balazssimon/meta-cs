using MetaDslx.CodeAnalysis.Binding.Binders.Find;
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
    public class ValueBinder : Binder, IValueBoundary
    {
        private Lazy<object> _lazyValue;

        public ValueBinder(SyntaxNodeOrToken syntax, Binder next, object value)
            : base(syntax, next)
        {
            _lazyValue = new Lazy<object>(() => value);
        }

        protected ValueBinder(SyntaxNodeOrToken syntax, Binder next)
            : base(syntax, next)
        {
            _lazyValue = new Lazy<object>(this.ComputeValue, true);
        }

        public virtual ImmutableArray<object> Values => ImmutableArray.Create(_lazyValue.Value);

        protected virtual object ComputeValue()
        {
            return Language.SyntaxFacts.ExtractValue(this.Syntax);
        }

    }
}
