using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Binding
{
    public class QualifierBinder : ValueBinder
    {
        private ImmutableArray<SyntaxNodeOrToken> _identifiers;

        public QualifierBinder(Binder next, SyntaxNodeOrToken syntax, bool forCompletion) 
            : base(next, syntax, forCompletion)
        {
        }

        public bool IsTopmostQualifierBinder => object.ReferenceEquals(GetTopmostQualifierBinder(this), this);

        internal static QualifierBinder GetTopmostQualifierBinder(Binder binder)
        {
            QualifierBinder result = binder as QualifierBinder;
            while (binder != null)
            {
                binder = binder.Next;
                if (binder is QualifierBinder qb) result = qb;
            }
            return result;
        }

        public ImmutableArray<SyntaxNodeOrToken> Identifiers
        {
            get
            {
                if (_identifiers.IsDefault)
                {
                    if (this.IsTopmostQualifierBinder)
                    {
                        var position = this.GetBinderPosition();
                        var identifiers = FindBinders.FindIdentifierBinders(position).Select(ib => ib.Syntax).ToImmutableArray();
                        ImmutableInterlocked.InterlockedInitialize(ref _identifiers, identifiers);
                    }
                    else
                    {
                        ImmutableInterlocked.InterlockedInitialize(ref _identifiers, ImmutableArray<SyntaxNodeOrToken>.Empty);
                    }
                }
                return _identifiers;
            }
        }

        protected override BoundNode BindNode(DiagnosticBag diagnostics, CancellationToken cancellationToken)
        {
            if (this.Identifiers.IsEmpty) return null;
            // Only create a BoundQualifier node for the topmost qualifier:
            var symbols = this.BindQualifiedName(this.Identifiers, diagnostics, null);
            return new BoundQualifier(this.Identifiers, symbols);
        }

        protected override LookupConstraints AdjustConstraints(LookupConstraints constraints)
        {
            var result = base.AdjustConstraints(constraints);
            if (!this.IsCompletionBinder && !constraints.Syntax.IsNull)
            {
                var index = this.Identifiers.IndexOf(constraints.Syntax);
                if (index >= 0 && index < this.Identifiers.Length-1)
                {
                    result = result.ClearValidators();
                }
            }
            return result;
        }
    }
}
