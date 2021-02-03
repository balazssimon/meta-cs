﻿using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Binding.Binders
{
    public class QualifierBinder : Binder
    {
        private LanguageSyntaxNode _syntax;

        public QualifierBinder(Binder next, LanguageSyntaxNode syntax) 
            : base(next)
        {
            _syntax = syntax;
        }

    }
}
