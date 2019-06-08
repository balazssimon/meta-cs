using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding.Binders
{
    public class ScopeBinder : InContainerBinder
    {
        public ScopeBinder(NamespaceOrTypeSymbol container, Binder next, LanguageSyntaxNode syntax)
            : base(container, next, syntax, false)
        {
        }
    }
}
