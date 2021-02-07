using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding.BoundNodes
{
    public class BoundExpression : BoundNode
    {
        public BoundExpression(SyntaxNodeOrToken syntax, BoundNode parent)
            : base(syntax, parent)
        {
        }

        public Symbol Symbol { get; }
    }
}
