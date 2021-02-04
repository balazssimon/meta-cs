using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding.Binders
{
    public class CustomBinder : Binder
    {
        public CustomBinder(SyntaxNodeOrToken syntax, Binder next)
            : base(syntax, next)
        {
        }

    }
}
