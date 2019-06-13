using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding.BoundNodes
{
    public class BoundBadStatement : BoundNode
    {
        public BoundBadStatement(LanguageSyntaxNode expression, ImmutableArray<BoundNode> empty, bool hasErrors)
            : base(BoundKind.BadStatement, null, BoundNodeFlags.None, expression, hasErrors)
        {
        }
    }
}
