﻿using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Binding;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Languages.Test.Languages.Meta.Binding
{
    public class OppositeBinder : Binder
    {
        public OppositeBinder(Binder next, LanguageSyntaxNode node) 
            : base(next)
        {
        }

    }
}
