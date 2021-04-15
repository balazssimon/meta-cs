using MetaDslx.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [Symbol(HasSubSymbolKinds = true)]
    public abstract class LocalSymbol : DeclaredSymbol
    {
        public sealed override LanguageSymbolKind Kind => LanguageSymbolKind.Member;

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

        public override void Accept(MetaDslx.CodeAnalysis.SymbolVisitor visitor)
        {

        }

        public override TResult Accept<TResult>(MetaDslx.CodeAnalysis.SymbolVisitor<TResult> visitor)
        {
            return default;
        }
    }
}
