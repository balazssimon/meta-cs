using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Symbols;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Represents a method or method-like symbol (including constructor,
    /// destructor, operator, or property/event accessor).
    /// </summary>
    public abstract class MethodSymbol : MemberSymbol, IMethodSymbolInternal
    {
        internal const MethodSymbol None = null;

        // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        // Changes to the public interface of this class should remain synchronized with the VB version.
        // Do not make any changes to the public interface without making the corresponding change
        // to the VB version.
        // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

        protected MethodSymbol()
        {
        }

        public abstract MethodKind MethodKind { get; }

        bool IMethodSymbolInternal.IsIterator => throw new NotImplementedException();

        MethodKind IMethodSymbol.MethodKind => throw new NotImplementedException();

        int IMethodSymbol.Arity => throw new NotImplementedException();

        bool IMethodSymbol.IsGenericMethod => throw new NotImplementedException();

        bool IMethodSymbol.IsExtensionMethod => throw new NotImplementedException();

        public virtual bool IsAsync => false;

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

        public virtual bool IsScriptInitializer => false;

        int IMethodSymbolInternal.CalculateLocalSyntaxOffset(int declaratorPosition, SyntaxTree declaratorTree)
        {
            throw new NotImplementedException();
        }

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

        public override void Accept(SymbolVisitor visitor)
        {
            visitor.VisitMethod(this);
        }

        public override TResult Accept<TResult>(SymbolVisitor<TResult> visitor)
        {
            return visitor.VisitMethod(this);
        }

        public override TResult Accept<TArgument, TResult>(SymbolVisitor<TArgument, TResult> visitor, TArgument argument)
        {
            return visitor.VisitMethod(this, argument);
        }

        public override void Accept(Microsoft.CodeAnalysis.SymbolVisitor visitor)
        {
            visitor.VisitMethod(this);
        }

        public override TResult Accept<TResult>(Microsoft.CodeAnalysis.SymbolVisitor<TResult> visitor)
        {
            return visitor.VisitMethod(this);
        }
    }
}
