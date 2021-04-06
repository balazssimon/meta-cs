using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding.BoundNodes
{
    public class BoundExpression : BoundNode
    {
        public Symbol Symbol { get; }
    }
}
