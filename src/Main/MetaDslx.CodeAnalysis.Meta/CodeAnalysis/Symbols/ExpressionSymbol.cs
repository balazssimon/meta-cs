using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [Symbol(HasSubSymbolKinds = true)]
    public abstract class ExpressionSymbol : NonDeclaredSymbol
    {
        public abstract ExpressionKind ExpressionKind { get; }


        public override void Accept(SymbolVisitor visitor)
        {
            visitor.VisitExpression(this);
        }

        public override TResult Accept<TResult>(SymbolVisitor<TResult> visitor)
        {
            return visitor.VisitExpression(this);
        }

        public override TResult Accept<TArgument, TResult>(SymbolVisitor<TArgument, TResult> visitor, TArgument argument)
        {
            return visitor.VisitExpression(this, argument);
        }

    }
}
