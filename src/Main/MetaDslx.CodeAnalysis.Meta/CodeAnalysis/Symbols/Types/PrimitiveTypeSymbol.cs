﻿using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [Symbol]
    public abstract partial class PrimitiveTypeSymbol : NamedTypeSymbol
    {
        public override bool IsValueType => true;
    }
}
