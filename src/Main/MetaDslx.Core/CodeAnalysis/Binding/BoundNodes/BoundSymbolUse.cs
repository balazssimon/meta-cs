using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding.BoundNodes
{
    public class BoundSymbolUse : BoundSymbol
    {
        private ImmutableArray<Type> _symbolTypes;
        private ImmutableArray<Type> _nestingSymbolTypes;

        public BoundSymbolUse(BoundKind kind, BoundTree boundTree, ImmutableArray<BoundNode> childBoundNodes, ImmutableArray<Type> symbolTypes, ImmutableArray<Type> nestingSymbolTypes, LanguageSyntaxNode syntax, bool hasErrors = false)
            : base(kind, boundTree, childBoundNodes, syntax, hasErrors)
        {
            _symbolTypes = symbolTypes;
            _nestingSymbolTypes = nestingSymbolTypes;
        }
    }
}
