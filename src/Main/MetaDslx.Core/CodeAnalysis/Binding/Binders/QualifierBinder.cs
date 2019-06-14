using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding.Binders
{
    public class QualifierBinder : Binder
    {
        private LanguageSyntaxNode _syntax;
        private ImmutableArray<Identifier> _identifiers;

        public QualifierBinder(Binder next, LanguageSyntaxNode syntax) 
            : base(next)
        {
            _syntax = syntax;
        }

        public Qualifier Qualifier => default;
    }
}
