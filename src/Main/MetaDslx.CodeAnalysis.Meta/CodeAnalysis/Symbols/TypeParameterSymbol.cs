using Microsoft.CodeAnalysis;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public class TypeParameterSymbol : TypeSymbol
    {
        public override bool IsStatic => throw new NotImplementedException();

        public override Symbol ContainingSymbol => throw new NotImplementedException();

        public override ImmutableArray<Location> Locations => throw new NotImplementedException();

        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => throw new NotImplementedException();

        public new TypeParameterSymbol OriginalDefinition => throw new NotImplementedException();

        public int Ordinal { get; internal set; }
        public VarianceKind Variance { get; internal set; }
        public bool HasReferenceTypeConstraint { get; internal set; }
        public bool HasValueTypeConstraint { get; internal set; }
        public bool HasUnmanagedTypeConstraint { get; internal set; }
        public bool HasNotNullConstraint { get; internal set; }
        public bool HasConstructorConstraint { get; internal set; }
        public MethodSymbol DeclaringMethod { get; internal set; }
        public NamedTypeSymbol DeclaringType { get; internal set; }
        public TypeParameterKind TypeParameterKind { get; internal set; }
        public bool? ReferenceTypeConstraintIsNullable { get; internal set; }
        internal ImmutableArray<TypeWithAnnotations> ConstraintTypesNoUseSiteDiagnostics { get; }
        public virtual TypeParameterSymbol ReducedFrom { get; }


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

        public override bool GetUnificationUseSiteDiagnosticRecursive(ref DiagnosticInfo result, Symbol owner, ref HashSet<TypeSymbol> checkedTypes)
        {
            throw new NotImplementedException();
        }

    }
}
