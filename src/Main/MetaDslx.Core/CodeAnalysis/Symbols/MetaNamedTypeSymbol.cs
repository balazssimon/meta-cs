using Microsoft.Cci;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Symbols;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Runtime.InteropServices;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public class MetaNamedTypeSymbol : NamedTypeSymbol
    {
        public override int Arity => throw new NotImplementedException();

        public override ImmutableArray<TypeParameterSymbol> TypeParameters => throw new NotImplementedException();

        public override NamedTypeSymbol ConstructedFrom => throw new NotImplementedException();

        public override bool MightContainExtensionMethods => throw new NotImplementedException();

        public override string Name => throw new NotImplementedException();

        public override IEnumerable<string> MemberNames => throw new NotImplementedException();

        public override Accessibility DeclaredAccessibility => throw new NotImplementedException();

        public override bool IsSerializable => throw new NotImplementedException();

        public override TypeKind TypeKind => throw new NotImplementedException();

        public override bool IsRefLikeType => throw new NotImplementedException();

        public override bool IsReadOnly => throw new NotImplementedException();

        public override Symbol ContainingSymbol => throw new NotImplementedException();

        public override ImmutableArray<Location> Locations => throw new NotImplementedException();

        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => throw new NotImplementedException();

        public override bool IsStatic => throw new NotImplementedException();

        public override bool IsAbstract => throw new NotImplementedException();

        public override bool IsSealed => throw new NotImplementedException();

        internal override ImmutableArray<TypeWithAnnotations> TypeArgumentsWithAnnotationsNoUseSiteDiagnostics => throw new NotImplementedException();

        internal override bool MangleName => throw new NotImplementedException();

        internal override bool HasCodeAnalysisEmbeddedAttribute => throw new NotImplementedException();

        internal override bool HasSpecialName => throw new NotImplementedException();

        internal override bool IsComImport => throw new NotImplementedException();

        internal override bool IsWindowsRuntimeImport => throw new NotImplementedException();

        internal override bool ShouldAddWinRTMembers => throw new NotImplementedException();

        internal override TypeLayout Layout => throw new NotImplementedException();

        internal override CharSet MarshallingCharSet => throw new NotImplementedException();

        internal override bool HasDeclarativeSecurity => throw new NotImplementedException();

        internal override bool IsInterface => throw new NotImplementedException();

        internal override NamedTypeSymbol BaseTypeNoUseSiteDiagnostics => throw new NotImplementedException();

        internal override ObsoleteAttributeData ObsoleteAttributeData => throw new NotImplementedException();

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

        public override ImmutableArray<NamedTypeSymbol> GetTypeMembers(string name, int arity)
        {
            throw new NotImplementedException();
        }

        internal override ImmutableArray<string> GetAppliedConditionalSymbols()
        {
            throw new NotImplementedException();
        }

        internal override AttributeUsageInfo GetAttributeUsageInfo()
        {
            throw new NotImplementedException();
        }

        internal override NamedTypeSymbol GetDeclaredBaseType(ConsList<TypeSymbol> basesBeingResolved)
        {
            throw new NotImplementedException();
        }

        internal override ImmutableArray<NamedTypeSymbol> GetDeclaredInterfaces(ConsList<TypeSymbol> basesBeingResolved)
        {
            throw new NotImplementedException();
        }

        internal override ImmutableArray<Symbol> GetEarlyAttributeDecodingMembers()
        {
            throw new NotImplementedException();
        }

        internal override ImmutableArray<Symbol> GetEarlyAttributeDecodingMembers(string name)
        {
            throw new NotImplementedException();
        }

        internal override IEnumerable<FieldSymbol> GetFieldsToEmit()
        {
            throw new NotImplementedException();
        }

        internal override ImmutableArray<NamedTypeSymbol> GetInterfacesToEmit()
        {
            throw new NotImplementedException();
        }

        internal override IEnumerable<SecurityAttribute> GetSecurityInformation()
        {
            throw new NotImplementedException();
        }

        internal override ImmutableArray<NamedTypeSymbol> InterfacesNoUseSiteDiagnostics(ConsList<TypeSymbol> basesBeingResolved = null)
        {
            throw new NotImplementedException();
        }
    }
}
