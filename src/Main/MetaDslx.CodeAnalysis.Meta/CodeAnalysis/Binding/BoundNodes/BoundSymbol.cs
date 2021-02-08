﻿using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding.BoundNodes
{
    public abstract class BoundSymbol : BoundValue
    {
        public BoundSymbol(SyntaxNodeOrToken syntax, BoundNode parent) 
            : base(syntax, parent)
        {
        }

        public abstract ImmutableArray<Symbol> Symbols { get; }

        public override ImmutableArray<object> Values => this.Symbols.Cast<Symbol, object>();
    }
}
