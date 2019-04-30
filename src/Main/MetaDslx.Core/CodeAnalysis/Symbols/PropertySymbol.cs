using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public class PropertySymbol : MemberSymbol, IPropertySymbol
    {
        public virtual bool IsIndexer => throw new NotImplementedException();

        public override SymbolKind Kind => throw new NotImplementedException();

        public override Symbol ContainingSymbol => throw new NotImplementedException();

        public override ImmutableArray<Location> Locations => throw new NotImplementedException();

        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => throw new NotImplementedException();

        public override Accessibility DeclaredAccessibility => throw new NotImplementedException();

        public override bool IsStatic => throw new NotImplementedException();

        public override bool IsVirtual => throw new NotImplementedException();

        public override bool IsOverride => throw new NotImplementedException();

        public override bool IsAbstract => throw new NotImplementedException();

        public override bool IsSealed => throw new NotImplementedException();

        public override bool IsExtern => throw new NotImplementedException();

        bool IPropertySymbol.IsIndexer => throw new NotImplementedException();

        bool IPropertySymbol.IsReadOnly => throw new NotImplementedException();

        bool IPropertySymbol.IsWriteOnly => throw new NotImplementedException();

        bool IPropertySymbol.IsWithEvents => throw new NotImplementedException();

        bool IPropertySymbol.ReturnsByRef => throw new NotImplementedException();

        bool IPropertySymbol.ReturnsByRefReadonly => throw new NotImplementedException();

        RefKind IPropertySymbol.RefKind => throw new NotImplementedException();

        ITypeSymbol IPropertySymbol.Type => throw new NotImplementedException();

        ImmutableArray<IParameterSymbol> IPropertySymbol.Parameters => throw new NotImplementedException();

        IMethodSymbol IPropertySymbol.GetMethod => throw new NotImplementedException();

        IMethodSymbol IPropertySymbol.SetMethod => throw new NotImplementedException();

        IPropertySymbol IPropertySymbol.OriginalDefinition => throw new NotImplementedException();

        IPropertySymbol IPropertySymbol.OverriddenProperty => throw new NotImplementedException();

        ImmutableArray<IPropertySymbol> IPropertySymbol.ExplicitInterfaceImplementations => throw new NotImplementedException();

        ImmutableArray<CustomModifier> IPropertySymbol.RefCustomModifiers => throw new NotImplementedException();

        ImmutableArray<CustomModifier> IPropertySymbol.TypeCustomModifiers => throw new NotImplementedException();
    }
}
