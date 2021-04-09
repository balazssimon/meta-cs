using MetaDslx.CodeAnalysis.Binding.Binders.Find;
using MetaDslx.CodeAnalysis.Binding.BoundNodes;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.PooledObjects;
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

        public ValueBinder(Binder next, SyntaxNodeOrToken syntax, object value)
            : base(next, syntax)
        {
            _lazyValue = new Lazy<object>(() => value);
        }

        protected ValueBinder(Binder next, SyntaxNodeOrToken syntax)
            : base(next, syntax)
        {
            _lazyValue = new Lazy<object>(this.ComputeValue, true);
        }

        public virtual ImmutableArray<object> Values => ImmutableArray.Create(_lazyValue.Value);

        protected virtual object ComputeValue()
        {
            return Language.SyntaxFacts.ExtractValue(this.Syntax);
        }

        protected override BoundNode BindNode(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            return new BoundValues(this.Values);
        }
    }
}
