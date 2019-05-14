using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.BoundTree
{
    public class BoundBadStatement : BoundNode
    {
        public BoundBadStatement(LanguageSyntaxNode expression, ImmutableArray<BoundNode> empty, bool hasErrors)
        {
        }
    }
}
