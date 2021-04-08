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

        protected override BoundNode BindNode(CancellationToken cancellationToken)
        {
            // Only create a BoundQualifier node for the topmost qualifier:
            if (!this.IsTopmostQualifierBinder) return null;
            var position = this.GetBinderPosition();
            var identifiers = FindBinders.FindIdentifierBinders(position).Select(ib => ib.Syntax).ToImmutableArray();
            var diagnostics = DiagnosticBag.GetInstance();
            var symbols = this.BindQualifiedName(identifiers, diagnostics, null);
            return new BoundQualifier(identifiers, symbols, diagnostics.ToReadOnlyAndFree());
        }

    }
}
