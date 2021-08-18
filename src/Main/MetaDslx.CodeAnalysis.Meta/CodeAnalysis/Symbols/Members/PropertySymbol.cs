﻿using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [Symbol]
    public abstract partial class PropertySymbol : FieldLikeSymbol
    {
        [SymbolProperty]
        public virtual MethodSymbol GetMethod { get; }

        [SymbolProperty]
        public virtual MethodSymbol SetMethod { get; }

        public PropertySymbol OverriddenProperty { get; }
        public FieldSymbol BackingField { get; }
    }
}
