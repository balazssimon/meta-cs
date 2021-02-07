using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding.BoundNodes
{
    public class BoundStatement : BoundNode
    {
        public BoundStatement(SyntaxNodeOrToken syntax, BoundNode parent)
            : base(syntax, parent)
        {
        }
    }
}
