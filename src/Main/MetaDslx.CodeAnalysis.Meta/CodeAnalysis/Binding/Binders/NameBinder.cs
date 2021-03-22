using MetaDslx.CodeAnalysis.Binding.Binders.Find;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding.Binders
{
    public class NameBinder : Binder, IValueBoundary
    {
        public NameBinder(Binder next, SyntaxNodeOrToken syntax) 
            : base(next, syntax)
        {
        }
    }
}
