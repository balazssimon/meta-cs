using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding.BoundNodes
{
    public class BoundValues : BoundValue
    {
        private ImmutableArray<object> _values;

        public BoundValues(BoundNode parent, SyntaxNodeOrToken syntax, ImmutableArray<object> values) 
            : base(parent, syntax)
        {
            _values = values;
        }

        public override ImmutableArray<object> Values => _values;
    }
}
