using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding.Binders
{
    public class LocalScopeBinder : Binder
    {
        public LocalScopeBinder(Binder next, SyntaxNodeOrToken syntax)
            : base(next, syntax)
        {

        }
    }
}
