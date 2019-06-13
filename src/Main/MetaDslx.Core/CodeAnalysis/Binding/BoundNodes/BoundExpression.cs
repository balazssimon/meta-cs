using System;
using System.Collections.Generic;
using System.Text;
using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis;

namespace MetaDslx.CodeAnalysis.Binding.BoundNodes
{
    public class BoundExpression : BoundNode
    {
        private readonly IOperation _expression;

        protected BoundExpression(BoundKind kind, LanguageSyntaxNode syntax, IOperation expression, bool hasErrors = false)
            : base(kind, syntax)
        {
            _expression = expression;
        }

        public IOperation Expression => _expression;
        public ConstantValue ConstantValue => throw new NotImplementedException("TODO:MetaDslx");
        public TypeSymbol Type => throw new NotImplementedException("TODO:MetaDslx");
    }
}
