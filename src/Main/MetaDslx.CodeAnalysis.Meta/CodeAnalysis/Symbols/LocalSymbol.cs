using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [Symbol(HasSubSymbolKinds = true)]
    public abstract class LocalSymbol : DeclaredSymbol
    {
        public sealed override SymbolKind Kind => SymbolKind.Member;

        public abstract LocalKind LocalKind { get; }

        public override ImmutableArray<Symbol> ChildSymbols => GetMembers().Cast<DeclaredSymbol, Symbol>();

        public override bool IsStatic => false;

        public override void Accept(SymbolVisitor visitor)
        {
            visitor.VisitLocal(this);
        }

        public override TResult Accept<TResult>(SymbolVisitor<TResult> visitor)
        {
            return visitor.VisitLocal(this);
        }

        public override TResult Accept<TArgument, TResult>(SymbolVisitor<TArgument, TResult> visitor, TArgument argument)
        {
            return visitor.VisitLocal(this, argument);
        }

    }
}
