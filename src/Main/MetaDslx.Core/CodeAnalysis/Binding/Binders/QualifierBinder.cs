using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding.Binders
{
    public class QualifierBinder : Binder
    {
        public QualifierBinder(Binder next, SyntaxNodeOrToken syntax) 
            : base(next, syntax)
        {
        }
    }
}
