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

        protected override BoundNode BindNode(CancellationToken cancellationToken)
        {
            // Only create a BoundQualifier node for the topmost qualifier:
            if (Next.GetBoundQualifier() != null) return null;
            var position = this.GetBinderPosition();
            var identifiers = FindBinders.FindIdentifierBinders(position).Select(ib => ib.Syntax).ToImmutableArray();
            return new BoundQualifier(identifiers);
        }

        public override BoundQualifier GetBoundQualifier()
        {
            return (BoundQualifier)this.Bind();
        }

        protected override LookupConstraints AdjustConstraintsFor(SyntaxNodeOrToken lookupSyntax, LookupConstraints constraints)
        {
            var boundNode = (BoundQualifier)this.Bind();
            if (boundNode != null && boundNode.IsLastIdentifier(lookupSyntax))
            {
                return base.AdjustConstraintsFor(lookupSyntax, constraints);
            }
            return constraints;
        }

    }
}
