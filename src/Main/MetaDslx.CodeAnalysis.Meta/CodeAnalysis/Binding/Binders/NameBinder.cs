using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding.Binders
{
    public class NameBinder : Binder
    {
        public NameBinder(SyntaxNodeOrToken syntax, Binder next) 
            : base(syntax, next)
        {
        }
    }
}
