using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using MetaDslx.CodeAnalysis.Symbols;

namespace MetaDslx.CodeAnalysis.Binding.BoundNodes
{
    public class BoundRoot : BoundSymbols
    {
        public BoundRoot(BoundKind kind, BoundTree boundTree, ImmutableArray<object> childBoundNodes, LanguageSyntaxNode syntax, bool hasErrors = false) 
            : base(kind, boundTree, childBoundNodes, syntax, hasErrors)
        {
        }

        public override ImmutableArray<Symbol> Symbols => ImmutableArray<Symbol>.Empty;
    }
}
