using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;

namespace MetaDslx.CodeAnalysis.Binding.BoundNodes
{
    public class BoundExpression : BoundNode
    {
        private readonly IOperation _expression;

        protected BoundExpression(BoundKind kind, BoundTree boundTree, ImmutableArray<object> childBoundNodes, IOperation expression, LanguageSyntaxNode syntax, bool hasErrors = false)
            : base(kind, boundTree, childBoundNodes, syntax, hasErrors)
        {
            _expression = expression;
        }

        public IOperation Expression => _expression;
        public ConstantValue ConstantValue => throw new NotImplementedException("TODO:MetaDslx");
        public TypeSymbol Type => throw new NotImplementedException("TODO:MetaDslx");

        public override string ToString()
        {
            return this.Expression + ": " + this.Type;
        }
    }
}
