// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using Microsoft.CodeAnalysis;
using System.Collections.Immutable;
using System.Diagnostics;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [Symbol]
    public sealed class DiscardSymbol : Symbol
    {
        public DiscardSymbol(TypeSymbol type)
        {
            Debug.Assert((object)type != null);
            Type = type;
        }

        public TypeSymbol Type { get; }

        /// <summary>
        /// Produce a fresh discard symbol for testing.
        /// </summary>
        internal static DiscardSymbol CreateForTest(ITypeSymbol type) => new DiscardSymbol((TypeSymbol)type);

        public override Symbol ContainingSymbol => null;
        public override ImmutableArray<Symbol> ChildSymbols => ImmutableArray<Symbol>.Empty;
        public override SymbolKind Kind => SymbolKind.Discard;
        public override ImmutableArray<Location> Locations => ImmutableArray<Location>.Empty;
        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => ImmutableArray<SyntaxReference>.Empty;

        internal TypeWithAnnotations TypeWithAnnotations { get; set; }

        public override void Accept(SymbolVisitor visitor) => visitor.VisitDiscard(this);
        public override TResult Accept<TResult>(SymbolVisitor<TResult> visitor) => visitor.VisitDiscard(this);

        public override TResult Accept<TArgument, TResult>(SymbolVisitor<TArgument, TResult> visitor, TArgument argument)
        {
            return visitor.VisitDiscard(this, argument);
        }

        public override bool Equals(object obj) => obj is DiscardSymbol other && this.Type.Equals(other.Type);
        public override int GetHashCode() => this.Type.GetHashCode();

        protected override ISymbol CreateISymbol()
        {
            return new PublicModel.DiscardSymbol(this);
        }

    }
}
