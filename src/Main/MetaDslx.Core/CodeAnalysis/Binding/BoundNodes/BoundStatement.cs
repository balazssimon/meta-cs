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

        protected override void AddIdentifiers(ArrayBuilder<Identifier> identifiers)
        {
        }

        protected override void AddQualifiers(ArrayBuilder<Qualifier> qualifiers)
        {
        }

        protected override void AddNames(ArrayBuilder<Qualifier> names)
        {
        }

        protected override void AddProperties(ArrayBuilder<string> properties)
        {
        }

        protected override void AddValues(string property, ArrayBuilder<object> values)
        {
        }

        public override string ToString()
        {
            return this.Statement.ToString();
        }
    }
}
