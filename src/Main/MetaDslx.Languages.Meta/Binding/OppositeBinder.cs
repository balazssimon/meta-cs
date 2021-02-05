using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Binding;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Languages.Meta.Binding
{
    public class OppositeBinder : Binder
    {
        public OppositeBinder(SyntaxNodeOrToken syntax, Binder next) 
            : base(syntax, next)
        {
        }

    }
}
