﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Compiler.Core.Syntax.InternalSyntax;

namespace MetaDslx.Compiler.Core.Syntax
{
    public abstract class SyntaxNode : RedNode
    {
        protected SyntaxNode(GreenNode green, SyntaxNode parent, int position) 
            : base(green, parent, position)
        {
        }

        protected SyntaxNode(GreenNode green, SyntaxTree syntaxTree, int position) 
            : base(green, syntaxTree, position)
        {
        }
    }
}
