using MetaDslx.CodeAnalysis.Symbols;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding.BoundNodes
{
    public class BoundSymbol : BoundValue
    {
        public BoundSymbol(BoundKind kind, BoundTree boundTree, ImmutableArray<BoundNode> childBoundNodes, LanguageSyntaxNode syntax, bool hasErrors = false)
            : base(kind, boundTree, childBoundNodes, null, syntax, hasErrors)
        {
        }

        public virtual Symbol Symbol { get; }

        public override object Value => this.Symbol;
    }
}
