using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public class FieldSymbol : MemberSymbol
    {
        public override MemberKind MemberKind => throw new NotImplementedException();

        public override bool IsStatic => throw new NotImplementedException();

        public override Symbol ContainingSymbol => throw new NotImplementedException();

        public override ImmutableArray<Location> Locations => throw new NotImplementedException();

        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => throw new NotImplementedException();

        public bool IsConst { get; internal set; }
        public bool IsReadOnly { get; internal set; }
        public bool IsVolatile { get; internal set; }
        public bool IsFixedSizeBuffer { get; internal set; }
        public bool HasConstantValue { get; internal set; }
        public object ConstantValue { get; internal set; }
        public new FieldSymbol OriginalDefinition { get; internal set; }
        public FieldSymbol CorrespondingTupleField { get; internal set; }
        public Symbol AssociatedSymbol { get; internal set; }
        internal TypeWithAnnotations TypeWithAnnotations { get;  }

        public override ImmutableArray<DeclaredSymbol> GetMembers()
        {
            throw new NotImplementedException();
        }

        public override ImmutableArray<NamedTypeSymbol> GetTypeMembers()
        {
            throw new NotImplementedException();
        }

        protected override ISymbol CreateISymbol()
        {
            throw new NotImplementedException();
        }
    }
}
