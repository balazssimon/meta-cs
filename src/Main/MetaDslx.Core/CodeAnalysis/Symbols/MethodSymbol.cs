using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using Microsoft.CodeAnalysis;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public class MethodSymbol : MemberSymbol, IMethodSymbol
    {
        public virtual MethodKind MethodKind => throw new NotImplementedException();

        public virtual int Arity => throw new NotImplementedException();

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

        MethodKind IMethodSymbol.MethodKind => throw new NotImplementedException();

        int IMethodSymbol.Arity => throw new NotImplementedException();

        bool IMethodSymbol.IsGenericMethod => throw new NotImplementedException();

        bool IMethodSymbol.IsExtensionMethod => throw new NotImplementedException();

        bool IMethodSymbol.IsAsync => throw new NotImplementedException();

        bool IMethodSymbol.IsVararg => throw new NotImplementedException();

        bool IMethodSymbol.IsCheckedBuiltin => throw new NotImplementedException();

        bool IMethodSymbol.HidesBaseMethodsByName => throw new NotImplementedException();

        bool IMethodSymbol.ReturnsVoid => throw new NotImplementedException();

        bool IMethodSymbol.ReturnsByRef => throw new NotImplementedException();

        bool IMethodSymbol.ReturnsByRefReadonly => throw new NotImplementedException();

        RefKind IMethodSymbol.RefKind => throw new NotImplementedException();

        ITypeSymbol IMethodSymbol.ReturnType => throw new NotImplementedException();

        ImmutableArray<ITypeSymbol> IMethodSymbol.TypeArguments => throw new NotImplementedException();

        ImmutableArray<ITypeParameterSymbol> IMethodSymbol.TypeParameters => throw new NotImplementedException();

        ImmutableArray<IParameterSymbol> IMethodSymbol.Parameters => throw new NotImplementedException();

        IMethodSymbol IMethodSymbol.ConstructedFrom => throw new NotImplementedException();

        bool IMethodSymbol.IsReadOnly => throw new NotImplementedException();

        IMethodSymbol IMethodSymbol.OriginalDefinition => throw new NotImplementedException();

        IMethodSymbol IMethodSymbol.OverriddenMethod => throw new NotImplementedException();

        ITypeSymbol IMethodSymbol.ReceiverType => throw new NotImplementedException();

        IMethodSymbol IMethodSymbol.ReducedFrom => throw new NotImplementedException();

        ImmutableArray<IMethodSymbol> IMethodSymbol.ExplicitInterfaceImplementations => throw new NotImplementedException();

        ImmutableArray<CustomModifier> IMethodSymbol.ReturnTypeCustomModifiers => throw new NotImplementedException();

        ImmutableArray<CustomModifier> IMethodSymbol.RefCustomModifiers => throw new NotImplementedException();

        ISymbol IMethodSymbol.AssociatedSymbol => throw new NotImplementedException();

        IMethodSymbol IMethodSymbol.PartialDefinitionPart => throw new NotImplementedException();

        IMethodSymbol IMethodSymbol.PartialImplementationPart => throw new NotImplementedException();

        INamedTypeSymbol IMethodSymbol.AssociatedAnonymousDelegate => throw new NotImplementedException();

        IMethodSymbol IMethodSymbol.Construct(params ITypeSymbol[] typeArguments)
        {
            throw new NotImplementedException();
        }

        DllImportData IMethodSymbol.GetDllImportData()
        {
            throw new NotImplementedException();
        }

        ImmutableArray<AttributeData> IMethodSymbol.GetReturnTypeAttributes()
        {
            throw new NotImplementedException();
        }

        ITypeSymbol IMethodSymbol.GetTypeInferredDuringReduction(ITypeParameterSymbol reducedFromTypeParameter)
        {
            throw new NotImplementedException();
        }

        IMethodSymbol IMethodSymbol.ReduceExtensionMethod(ITypeSymbol receiverType)
        {
            throw new NotImplementedException();
        }
    }
}
