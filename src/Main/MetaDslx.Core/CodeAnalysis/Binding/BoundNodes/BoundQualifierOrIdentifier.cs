using MetaDslx.CodeAnalysis.Symbols;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding.BoundNodes
{
    public abstract class BoundQualifierOrIdentifier : BoundValues
    {
        public BoundQualifierOrIdentifier(BoundKind kind, BoundTree boundTree, ImmutableArray<BoundNode> childBoundNodes, LanguageSyntaxNode syntax, bool hasErrors = false)
            : base(kind, boundTree, childBoundNodes, syntax, hasErrors)
        {
        }

        public abstract ImmutableArray<BoundIdentifier> Identifiers { get; }

        public abstract Symbol Symbol { get; }

        public override ImmutableArray<object> Values => ImmutableArray.Create<object>(this.Symbol);
    }
}
