using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public abstract class StatementSymbol : NonDeclaredSymbol
    {
        public abstract StatementKind StatementKind { get; }

        public override void Accept(SymbolVisitor visitor)
        {
            visitor.VisitStatement(this);
        }

        public override TResult Accept<TResult>(SymbolVisitor<TResult> visitor)
        {
            return visitor.VisitStatement(this);
        }

        public override TResult Accept<TArgument, TResult>(SymbolVisitor<TArgument, TResult> visitor, TArgument argument)
        {
            return visitor.VisitStatement(this, argument);
        }

        public override void Accept(Microsoft.CodeAnalysis.SymbolVisitor visitor)
        {

        }

        public override TResult Accept<TResult>(Microsoft.CodeAnalysis.SymbolVisitor<TResult> visitor)
        {
            return default;
        }
    }
}
