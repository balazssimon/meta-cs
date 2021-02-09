﻿using MetaDslx.CodeAnalysis.Binding.BoundNodes;
using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis;
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
        public QualifierBinder(SyntaxNodeOrToken syntax, Binder next) 
            : base(syntax, next)
        {
        }

        protected override BoundNode CreateBoundNode()
        {
            // Only create a BoundQualifier node for the topmost qualifier:
            if (Next.GetBoundQualifier() != null) return null;
            var position = this.GetBinderPosition();
            var identifiers = FindBinders.FindIdentifierBinders(position).Select(ib => ib.Syntax).ToImmutableArray();
            return new BoundQualifier(this.Syntax, this.ParentBoundNode, identifiers);
        }

        public override BoundQualifier GetBoundQualifier()
        {
            return (BoundQualifier)this.BoundNode;
        }

        protected override LookupConstraints AdjustConstraintsFor(SyntaxNodeOrToken lookupSyntax, LookupConstraints constraints)
        {
            var boundNode = (BoundQualifier)this.BoundNode;
            if (boundNode != null && boundNode.IsLastIdentifier(lookupSyntax))
            {
                return base.AdjustConstraintsFor(lookupSyntax, constraints);
            }
            return constraints;
        }

    }
}
