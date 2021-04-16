using Microsoft.CodeAnalysis;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public class ArrayTypeSymbol : TypeSymbol
    {
        public override bool IsStatic => throw new NotImplementedException();

        public override Symbol ContainingSymbol => throw new NotImplementedException();

        public override ImmutableArray<Location> Locations => throw new NotImplementedException();

        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => throw new NotImplementedException();

        public int Rank { get; internal set; }
        public bool IsSZArray { get; internal set; }
        public ImmutableArray<int> LowerBounds { get; internal set; }
        public ImmutableArray<int> Sizes { get; internal set; }
        internal TypeWithAnnotations ElementTypeWithAnnotations { get; set; }

        public override void Accept(SymbolVisitor visitor)
        {
            throw new NotImplementedException();
        }

        public override TResult Accept<TResult>(SymbolVisitor<TResult> visitor)
        {
            throw new NotImplementedException();
        }

        public override TResult Accept<TArgument, TResult>(SymbolVisitor<TArgument, TResult> visitor, TArgument argument)
        {
            throw new NotImplementedException();
        }

        public override ImmutableArray<NamedTypeSymbol> GetBaseTypesNoUseSiteDiagnostics(ConsList<TypeSymbol> basesBeingResolved = null)
        {
            throw new NotImplementedException();
        }

        public override ImmutableArray<DeclaredSymbol> GetMembers()
        {
            throw new NotImplementedException();
        }

        public override ImmutableArray<NamedTypeSymbol> GetTypeMembers()
        {
            throw new NotImplementedException();
        }

        public override bool GetUnificationUseSiteDiagnosticRecursive(ref DiagnosticInfo result, Symbol owner, ref HashSet<TypeSymbol> checkedTypes)
        {
            throw new NotImplementedException();
        }

        internal static ArrayTypeSymbol CreateArray(AssemblySymbol assembly, TypeWithAnnotations typeWithAnnotations, int rank)
        {
            throw new NotImplementedException();
        }

        protected sealed override ISymbol CreateISymbol()
        {
            return new PublicModel.ArrayTypeSymbol(this, DefaultNullableAnnotation);
        }

        protected sealed override ITypeSymbol CreateITypeSymbol(Microsoft.CodeAnalysis.NullableAnnotation nullableAnnotation)
        {
            Debug.Assert(nullableAnnotation != DefaultNullableAnnotation);
            return new PublicModel.ArrayTypeSymbol(this, nullableAnnotation);
        }

    }
}
