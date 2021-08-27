using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding
{
    public abstract class BoundSymbol : BoundValue
    {
        public abstract ImmutableArray<Symbol> Symbols { get; }

        public override ImmutableArray<object> Values => this.Symbols.Cast<Symbol, object>();
    }
}
