﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Compiler.Core.Syntax.InternalSyntax;

namespace MetaDslx.Compiler.Core.Syntax
{
    public abstract class SyntaxTrivia : RedNode
    {
        protected SyntaxTrivia(GreenNode green, SyntaxNode parent, int position) 
            : base(green, parent, position)
        {
        }
    }
}
