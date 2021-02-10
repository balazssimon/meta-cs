using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding.BoundNodes
{
    public class BoundExpression : BoundNode
    {
        public BoundExpression(BoundNode parent, SyntaxNodeOrToken syntax)
            : base(parent, syntax)
        {
        }

        public Symbol Symbol { get; }
    }
}
