using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding.BoundNodes
{
    public abstract class BoundSymbol : BoundValue
    {
        public BoundSymbol(BoundNode parent, SyntaxNodeOrToken syntax) 
            : base(parent, syntax)
        {
        }

        public abstract ImmutableArray<Symbol> Symbols { get; }

        public override ImmutableArray<object> Values => this.Symbols.Cast<Symbol, object>();
    }
}
