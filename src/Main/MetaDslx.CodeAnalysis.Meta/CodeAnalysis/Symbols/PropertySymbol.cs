using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public class PropertySymbol : MemberSymbol
    {
        public override MemberKind MemberKind => throw new NotImplementedException();

        public override bool IsStatic => throw new NotImplementedException();

        public override Symbol ContainingSymbol => throw new NotImplementedException();

        public override ImmutableArray<Location> Locations => throw new NotImplementedException();

        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => throw new NotImplementedException();

        internal TypeWithAnnotations TypeWithAnnotations { get;  set; }
        public ImmutableArray<CustomModifier> RefCustomModifiers { get; internal set; }
        public bool ReturnsByRefReadonly { get; internal set; }
        public bool ReturnsByRef { get; internal set; }
        public RefKind RefKind { get; internal set; }
        public bool IsReadOnly { get; internal set; }
        public bool IsWriteOnly { get; internal set; }
        public PropertySymbol OverriddenProperty { get; internal set; }
        public ImmutableArray<ParameterSymbol> Parameters { get; internal set; }
        public MethodSymbol GetMethod { get; internal set; }
        public MethodSymbol SetMethod { get; internal set; }
        public bool IsIndexer { get; internal set; }
        public new PropertySymbol OriginalDefinition { get; internal set; }
        public ImmutableArray<PropertySymbol> ExplicitInterfaceImplementations { get; internal set; }

    }
}
