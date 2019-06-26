using MetaDslx.CodeAnalysis.Binding.Binders;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding.BoundNodes
{
    public class BoundAttribute : BoundSymbolUse
    {
        public BoundAttribute(BoundKind kind, BoundTree boundTree, ImmutableArray<BoundNode> childBoundNodes, ImmutableArray<Type> symbolTypes, ImmutableArray<Type> nestingSymbolTypes, LanguageSyntaxNode syntax, bool hasErrors = false) 
            : base(kind, boundTree, childBoundNodes, symbolTypes, nestingSymbolTypes, syntax, hasErrors)
        {
        }
    }
}
