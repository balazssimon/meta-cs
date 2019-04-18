using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Symbols;
using Microsoft.CodeAnalysis.PooledObjects;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /*
    public class MetaTypeSymbol : TypeSymbol
    {
        public override bool IsReferenceType => throw new NotImplementedException();

        public override bool IsValueType => throw new NotImplementedException();

        public override TypeKind TypeKind => throw new NotImplementedException();

        public override bool IsRefLikeType => throw new NotImplementedException();

        public override bool IsReadOnly => throw new NotImplementedException();

        public override SymbolKind Kind => throw new NotImplementedException();

        public override Symbol ContainingSymbol => throw new NotImplementedException();

        public override ImmutableArray<Location> Locations => throw new NotImplementedException();

        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => throw new NotImplementedException();

        public override Accessibility DeclaredAccessibility => throw new NotImplementedException();

        public override bool IsStatic => throw new NotImplementedException();

        public override bool IsAbstract => throw new NotImplementedException();

        public override bool IsSealed => throw new NotImplementedException();

        internal override NamedTypeSymbol BaseTypeNoUseSiteDiagnostics => throw new NotImplementedException();

        internal override ManagedKind ManagedKind => throw new NotImplementedException();

        internal override ObsoleteAttributeData ObsoleteAttributeData => throw new NotImplementedException();

        public override void Accept(SymbolVisitor visitor)
        {
            throw new NotImplementedException();
        }

        public override TResult Accept<TResult>(SymbolVisitor<TResult> visitor)
        {
            throw new NotImplementedException();
        }

        public override void Accept(CSharpSymbolVisitor visitor)
        {
            throw new NotImplementedException();
        }

        public override TResult Accept<TResult>(CSharpSymbolVisitor<TResult> visitor)
        {
            throw new NotImplementedException();
        }

        public override ImmutableArray<Symbol> GetMembers()
        {
            throw new NotImplementedException();
        }

        public override ImmutableArray<Symbol> GetMembers(string name)
        {
            throw new NotImplementedException();
        }

        public override ImmutableArray<NamedTypeSymbol> GetTypeMembers()
        {
            throw new NotImplementedException();
        }

        public override ImmutableArray<NamedTypeSymbol> GetTypeMembers(string name)
        {
            throw new NotImplementedException();
        }

        internal override TResult Accept<TArgument, TResult>(CSharpSymbolVisitor<TArgument, TResult> visitor, TArgument a)
        {
            throw new NotImplementedException();
        }

        internal override void AddNullableTransforms(ArrayBuilder<byte> transforms)
        {
            throw new NotImplementedException();
        }

        internal override bool ApplyNullableTransforms(byte defaultTransformFlag, ImmutableArray<byte> transforms, ref int position, out TypeSymbol result)
        {
            throw new NotImplementedException();
        }

        internal override bool GetUnificationUseSiteDiagnosticRecursive(ref DiagnosticInfo result, Symbol owner, ref HashSet<TypeSymbol> checkedTypes)
        {
            throw new NotImplementedException();
        }

        internal override ImmutableArray<NamedTypeSymbol> InterfacesNoUseSiteDiagnostics(ConsList<TypeSymbol> basesBeingResolved = null)
        {
            throw new NotImplementedException();
        }

        internal override TypeSymbol MergeNullability(TypeSymbol other, VarianceKind variance)
        {
            throw new NotImplementedException();
        }

        internal override TypeSymbol SetNullabilityForReferenceTypes(Func<TypeWithAnnotations, TypeWithAnnotations> transform)
        {
            throw new NotImplementedException();
        }
    }*/
}
