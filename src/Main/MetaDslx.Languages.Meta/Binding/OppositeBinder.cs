using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Binding.Binders.Find;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Languages.Meta.Binding
{
    public class OppositeBinder : Binder, IValueBoundary, IPropertyBoundary
    {
        public OppositeBinder(SyntaxNodeOrToken syntax, Binder next) 
            : base(syntax, next)
        {
        }

    }
}
