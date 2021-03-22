using MetaDslx.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding.BoundNodes
{
    public abstract class BoundValue : BoundNode
    {
        public BoundValue(BoundNode parent, SyntaxNodeOrToken syntax) 
            : base(parent, syntax)
        {
        }

        public abstract ImmutableArray<object> Values { get; }
    }
}
