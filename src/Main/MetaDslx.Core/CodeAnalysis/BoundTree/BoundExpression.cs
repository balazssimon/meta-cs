using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.CodeAnalysis;

namespace MetaDslx.CodeAnalysis.BoundTree
{
    public class BoundExpression : BoundNode
    {
        internal ConstantValue ConstantValue { get; }
    }
}
