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

        public BoundValues(SyntaxNodeOrToken syntax, BoundNode parent, ImmutableArray<object> values) : base(syntax, parent)
        {
            _values = values;
        }

        public override ImmutableArray<object> Values => _values;
    }
}
