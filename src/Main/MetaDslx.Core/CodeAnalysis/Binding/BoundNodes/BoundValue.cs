﻿using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding.BoundNodes
{
    public class BoundValue : BoundNode
    {
        private object _value;

        public BoundValue(BoundKind kind, BoundTree boundTree, ImmutableArray<BoundNode> childBoundNodes, object value, LanguageSyntaxNode syntax, bool hasErrors = false)
            : base(kind, boundTree, childBoundNodes, syntax, hasErrors)
        {
            _value = value;
        }

        public virtual object Value => _value;
    }
}
