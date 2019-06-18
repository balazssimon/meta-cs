using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding.BoundNodes
{
    public class BoundStatement : BoundNode
    {
        private readonly IOperation _statement;

        protected BoundStatement(BoundKind kind, BoundTree boundTree, ImmutableArray<BoundNode> childBoundNodes, IOperation statement, LanguageSyntaxNode syntax, bool hasErrors = false)
            : base(kind, boundTree, childBoundNodes, syntax, hasErrors)
        {
            _statement = statement;
        }

        public IOperation Statement => _statement;

        public override string ToString()
        {
            return this.Statement.ToString();
        }
    }
}
