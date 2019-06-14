using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding.BoundNodes
{
    public class BoundSymbolDef : BoundSymbol
    {
        private Type _symbolType;

        public BoundSymbolDef(BoundKind kind, BoundTree boundTree, ImmutableArray<BoundNode> childBoundNodes, Type symbolType, LanguageSyntaxNode syntax, bool hasErrors = false) 
            : base(kind, boundTree, childBoundNodes, syntax, hasErrors)
        {
            _symbolType = symbolType;
        }
    }
}
