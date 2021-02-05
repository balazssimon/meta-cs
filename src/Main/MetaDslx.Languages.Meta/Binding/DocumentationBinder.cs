using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Binding;
using MetaDslx.CodeAnalysis.Binding.Binders;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.Languages.Meta.Binding
{
    public class DocumentationBinder : Binder
    {
        public DocumentationBinder(SyntaxNodeOrToken syntax, Binder next)
            : base(syntax, next)
        {
        }

    }
}
