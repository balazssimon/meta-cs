using MetaDslx.CodeAnalysis.Binding.Binders;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding.BoundNodes
{
    public class BoundAttribute : BoundSymbolUse
    {
        public BoundAttribute(BoundKind kind, BoundTree boundTree, ImmutableArray<object> childBoundNodes, ImmutableArray<Type> types, ImmutableArray<Type> nestingTypes, LanguageSyntaxNode syntax, bool hasErrors = false) 
            : base(kind, boundTree, childBoundNodes, types, nestingTypes, syntax, hasErrors)
        {
        }
    }
}
