using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding.Binders
{
    public class LocalScopeBinder : Binder
    {
        public LocalScopeBinder(Binder next, LanguageSyntaxNode syntax)
            : base(next, syntax)
        {

        }
    }
}
