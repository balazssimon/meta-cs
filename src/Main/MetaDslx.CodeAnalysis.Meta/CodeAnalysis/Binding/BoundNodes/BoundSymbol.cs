using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding.BoundNodes
{
    public abstract class BoundSymbol : BoundNode
    {
        public BoundSymbol(SyntaxNodeOrToken syntax, BoundNode parent) 
            : base(syntax, parent)
        {
        }

        public abstract ImmutableArray<Symbol> Symbols { get; }
    }
}
