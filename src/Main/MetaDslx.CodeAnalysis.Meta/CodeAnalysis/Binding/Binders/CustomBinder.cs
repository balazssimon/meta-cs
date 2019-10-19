using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding.Binders
{
    public class CustomBinder : Binder
    {
        private readonly LanguageSyntaxNode _syntax;

        public CustomBinder(Binder next, LanguageSyntaxNode syntax)
            : base(next)
        {
            _syntax = syntax;
        }

        public LanguageSyntaxNode Syntax => _syntax;
    }
}
