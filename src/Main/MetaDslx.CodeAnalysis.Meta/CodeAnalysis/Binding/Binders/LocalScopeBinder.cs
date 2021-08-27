using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding
{
    public class LocalScopeBinder : Binder
    {
        public LocalScopeBinder(Binder next, SyntaxNodeOrToken syntax, bool forCompletion)
            : base(next, syntax, forCompletion)
        {

        }
    }
}
