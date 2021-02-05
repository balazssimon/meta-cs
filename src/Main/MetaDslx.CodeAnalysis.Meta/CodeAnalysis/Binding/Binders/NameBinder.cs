using MetaDslx.CodeAnalysis.Binding.Binders.Find;
using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding.Binders
{
    public class NameBinder : Binder, IValueBoundary
    {
        public NameBinder(SyntaxNodeOrToken syntax, Binder next) 
            : base(syntax, next)
        {
        }
    }
}
