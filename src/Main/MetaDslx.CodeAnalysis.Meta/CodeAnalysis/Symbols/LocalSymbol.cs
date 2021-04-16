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

        public bool IsConst { get; internal set; }
        public bool IsRef { get; internal set; }
        public RefKind RefKind { get; internal set; }
        public bool HasConstantValue { get; internal set; }
        public object ConstantValue { get; internal set; }
        public bool IsFixed { get; internal set; }
        internal TypeWithAnnotations TypeWithAnnotations { get;  set; }

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
        protected sealed override ISymbol CreateISymbol()
        {
            return new PublicModel.LocalSymbol(this);
        }
    }
}
