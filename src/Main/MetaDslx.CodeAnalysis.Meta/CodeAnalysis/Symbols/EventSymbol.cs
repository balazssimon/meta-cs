using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public class EventSymbol : MemberSymbol
    {
        public override MemberKind MemberKind => throw new NotImplementedException();

        public override bool IsStatic => throw new NotImplementedException();

        public override Symbol ContainingSymbol => throw new NotImplementedException();

        public override ImmutableArray<Location> Locations => throw new NotImplementedException();

        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => throw new NotImplementedException();

        public MethodSymbol AddMethod { get; internal set; }
        public MethodSymbol RemoveMethod { get; internal set; }
        public EventSymbol OriginalDefinition { get; internal set; }
        public EventSymbol OverriddenEvent { get; internal set; }
        public bool IsWindowsRuntimeEvent { get; internal set; }
        public ImmutableArray<EventSymbol> ExplicitInterfaceImplementations { get; internal set; }
        internal TypeWithAnnotations TypeWithAnnotations { get; }

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
