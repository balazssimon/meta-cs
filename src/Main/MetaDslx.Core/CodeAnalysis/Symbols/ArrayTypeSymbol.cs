using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using Microsoft.CodeAnalysis;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public class ArrayTypeSymbol : WrappedTypeSymbol, IArrayTypeSymbol
    {
        public ArrayTypeSymbol(TypeSymbol wrappedType) : base(wrappedType)
        {
        }

        public override TypeKind TypeKind => TypeKind.Array;

        public override SymbolKind Kind => SymbolKind.ArrayType;

        public int Rank => throw new NotImplementedException();

        public bool IsSZArray => throw new NotImplementedException();

        public ImmutableArray<int> LowerBounds => throw new NotImplementedException();

        public ImmutableArray<int> Sizes => throw new NotImplementedException();

        public TypeSymbol ElementType => this.WrappedType;

        public ImmutableArray<CustomModifier> CustomModifiers => throw new NotImplementedException();

        internal override NamedTypeSymbol BaseTypeNoUseSiteDiagnostics => throw new NotImplementedException();

        ITypeSymbol IArrayTypeSymbol.ElementType => this.ElementType;

        public override void Accept(SymbolVisitor visitor)
        {
            visitor.VisitArrayType(this);
        }

        public override TResult Accept<TResult>(SymbolVisitor<TResult> visitor)
        {
            return visitor.VisitArrayType(this);
        }

        public bool Equals(IArrayTypeSymbol other)
        {
            throw new NotImplementedException();
        }

        protected override WrappedTypeSymbol WithWrappedTypeCore(TypeSymbol wrappedType)
        {
            throw new NotImplementedException();
        }

        internal override ImmutableArray<NamedTypeSymbol> InterfacesNoUseSiteDiagnostics(ConsList<TypeSymbol> basesBeingResolved = null)
        {
            throw new NotImplementedException();
        }

        internal static ArrayTypeSymbol CreateArray(AssemblySymbol assembly, TypeSymbol elementType, int rank)
        {
            throw new NotImplementedException();
        }
    }
}
