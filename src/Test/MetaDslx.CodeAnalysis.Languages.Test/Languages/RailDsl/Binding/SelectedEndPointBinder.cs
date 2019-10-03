using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Binding;
using System;
using System.Collections.Generic;
using System.Text;

namespace RailDsl.Binding
{
    public class SelectedEndPointBinder : Binder
    {
        public SelectedEndPointBinder(Binder next, LanguageSyntaxNode syntax) 
            : base(next)
        {
        }
    }
}
