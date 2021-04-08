using MetaDslx.CodeAnalysis.Binding.BoundNodes;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Binding.Binders
{
    public class QualifierBinder : ValueBinder
    {
        private ImmutableArray<SyntaxNodeOrToken> _identifiers;

        public QualifierBinder(Binder next, SyntaxNodeOrToken syntax) 
            : base(next, syntax)
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

        protected override BoundNode BindNode(CancellationToken cancellationToken)
        {
            if (this.Identifiers.IsEmpty) return null;
            // Only create a BoundQualifier node for the topmost qualifier:
            var diagnostics = DiagnosticBag.GetInstance();
            var symbols = this.BindQualifiedName(this.Identifiers, diagnostics, null);
            return new BoundQualifier(this.Identifiers, symbols, diagnostics.ToReadOnlyAndFree());
        }

        protected override LookupConstraints AdjustConstraints(LookupConstraints constraints)
        {
            var result = base.AdjustConstraints(constraints);
            if (constraints.OriginalBinder != null)
            {
                var index = this.Identifiers.IndexOf(constraints.OriginalBinder.Syntax);
                if (index >= 0 && index < this.Identifiers.Length-1)
                {
                    result = result.WithTypes(ImmutableArray<Type>.Empty);
                }
            }
            return result;
        }
    }
}
