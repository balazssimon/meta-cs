using Microsoft.CodeAnalysis;
using MetaDslx.CodeAnalysis.Symbols;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using System.Reflection.Metadata;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Represents a method or method-like symbol (including constructor,
    /// destructor, operator, or property/event accessor).
    /// </summary>
    public abstract class MethodSymbol : MemberSymbol, IMethodSymbol
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

        public override MemberKind MemberKind => MemberKind.Method;

        public abstract MethodKind MethodKind { get; }

        public virtual bool IsAsync => false;

        public virtual bool IsScriptInitializer => false;

        public bool IsEntryPointCandidate { get; internal set; }
        public TypeSymbol ReturnType { get; internal set; }
        public bool IsGenericMethod { get; internal set; }
        public int Arity { get; internal set; }
        internal TypeWithAnnotations ReturnTypeWithAnnotations { get;  set; }
        internal ImmutableArray<TypeWithAnnotations> TypeArgumentsWithAnnotations { get;  set; }
        public ImmutableArray<TypeParameterSymbol> TypeParameters { get; internal set; }
        public ImmutableArray<ParameterSymbol> Parameters { get; internal set; }
        public bool IsEffectivelyReadOnly { get; internal set; }
        public bool IsInitOnly { get; internal set; }
        public new MethodSymbol ConstructedFrom { get; internal set; }
        public new MethodSymbol OriginalDefinition { get; internal set; }
        public MethodSymbol OverriddenMethod { get; internal set; }
        public TypeSymbol ReceiverType { get; internal set; }
        public Microsoft.CodeAnalysis.NullableAnnotation ReceiverNullableAnnotation { get; internal set; }
        public MethodSymbol ReducedFrom { get; internal set; }
        public Symbol AssociatedSymbol { get; internal set; }
        public ImmutableArray<MethodSymbol> ExplicitInterfaceImplementations { get; internal set; }
        public bool HidesBaseMethodsByName { get; internal set; }
        public ImmutableArray<CustomModifier> RefCustomModifiers { get; internal set; }
        public MethodSymbol PartialImplementationPart { get; internal set; }
        public MethodSymbol PartialDefinitionPart { get; internal set; }
        internal Microsoft.Cci.CallingConvention CallingConvention { get; set; }

        public ImmutableArray<AttributeData> GetReturnTypeAttributes()
        {
            throw new NotImplementedException();
        }
                
        internal virtual ImmutableArray<NamedTypeSymbol> UnmanagedCallingConventionTypes => ImmutableArray<NamedTypeSymbol>.Empty;

#nullable enable
        /// <summary>
        /// Platform invoke information, or null if the method isn't a P/Invoke.
        /// </summary>
        public abstract DllImportData? GetDllImportData();
#nullable disable

        public bool IsExtensionMethod { get; internal set; }
        public bool IsVararg { get; internal set; }
        public bool IsCheckedBuiltin { get; internal set; }
        public bool ReturnsVoid { get; internal set; }
        public bool ReturnsByRef { get; internal set; }
        public bool ReturnsByRefReadonly { get; internal set; }
        public RefKind RefKind { get; internal set; }
        public bool IsConditional { get; internal set; }

        MethodKind IMethodSymbol.MethodKind => this.MethodKind;

        int IMethodSymbol.Arity => 0;

        bool IMethodSymbol.IsGenericMethod => this.IsGenericMethod;

        bool IMethodSymbol.IsExtensionMethod => this.IsExtensionMethod;

        bool IMethodSymbol.IsAsync => this.IsAsync;

        bool IMethodSymbol.IsVararg => this.IsVararg;

        bool IMethodSymbol.IsCheckedBuiltin => this.IsCheckedBuiltin;

        bool IMethodSymbol.HidesBaseMethodsByName => this.HidesBaseMethodsByName;

        bool IMethodSymbol.ReturnsVoid => this.ReturnsVoid;

        bool IMethodSymbol.ReturnsByRef => this.ReturnsByRef;

        bool IMethodSymbol.ReturnsByRefReadonly => this.ReturnsByRefReadonly;

        RefKind IMethodSymbol.RefKind => this.RefKind;

        ITypeSymbol IMethodSymbol.ReturnType => this.ReturnType;

        Microsoft.CodeAnalysis.NullableAnnotation IMethodSymbol.ReturnNullableAnnotation => Microsoft.CodeAnalysis.NullableAnnotation.NotAnnotated;

        ImmutableArray<ITypeSymbol> IMethodSymbol.TypeArguments => ImmutableArray<ITypeSymbol>.Empty;

        ImmutableArray<Microsoft.CodeAnalysis.NullableAnnotation> IMethodSymbol.TypeArgumentNullableAnnotations => ImmutableArray<Microsoft.CodeAnalysis.NullableAnnotation>.Empty;

        ImmutableArray<ITypeParameterSymbol> IMethodSymbol.TypeParameters => ImmutableArray<ITypeParameterSymbol>.Empty;

        ImmutableArray<IParameterSymbol> IMethodSymbol.Parameters => ImmutableArray<IParameterSymbol>.Empty;

        IMethodSymbol IMethodSymbol.ConstructedFrom => this.ConstructedFrom;

        bool IMethodSymbol.IsReadOnly => this.IsEffectivelyReadOnly;

        bool IMethodSymbol.IsInitOnly => this.IsInitOnly;

        IMethodSymbol IMethodSymbol.OriginalDefinition => this.OriginalDefinition;

        IMethodSymbol IMethodSymbol.OverriddenMethod => this.OverriddenMethod;

        ITypeSymbol IMethodSymbol.ReceiverType => this.ReceiverType;

        Microsoft.CodeAnalysis.NullableAnnotation IMethodSymbol.ReceiverNullableAnnotation => this.ReceiverNullableAnnotation;

        IMethodSymbol IMethodSymbol.ReducedFrom => this.ReducedFrom;

        ImmutableArray<IMethodSymbol> IMethodSymbol.ExplicitInterfaceImplementations => this.ExplicitInterfaceImplementations.Cast<MethodSymbol, IMethodSymbol>();

        ImmutableArray<CustomModifier> IMethodSymbol.ReturnTypeCustomModifiers => ImmutableArray<CustomModifier>.Empty;

        ImmutableArray <CustomModifier> IMethodSymbol.RefCustomModifiers => ImmutableArray<CustomModifier>.Empty;

        SignatureCallingConvention IMethodSymbol.CallingConvention => SignatureCallingConvention.Default;

        ImmutableArray<INamedTypeSymbol> IMethodSymbol.UnmanagedCallingConventionTypes => ImmutableArray<INamedTypeSymbol>.Empty;

        ISymbol IMethodSymbol.AssociatedSymbol => this.AssociatedSymbol as DeclaredSymbol;

        IMethodSymbol IMethodSymbol.PartialDefinitionPart => this.PartialDefinitionPart;

        IMethodSymbol IMethodSymbol.PartialImplementationPart => this.PartialImplementationPart;

        INamedTypeSymbol IMethodSymbol.AssociatedAnonymousDelegate => null;

        bool IMethodSymbol.IsConditional => this.IsConditional;

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

        internal bool IsNullableAnalysisEnabled()
        {
            throw new NotImplementedException();
        }

        internal TypeSymbol GetTypeInferredDuringReduction(TypeParameterSymbol typeParameterSymbol)
        {
            throw new NotImplementedException();
        }

        internal MethodSymbol ReduceExtensionMethod(TypeSymbol typeSymbol, object compilation)
        {
            throw new NotImplementedException();
        }

        internal MethodSymbol Construct(ImmutableArray<TypeWithAnnotations> typeWithAnnotations)
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

        ImmutableArray<AttributeData> IMethodSymbol.GetReturnTypeAttributes()
        {
            throw new NotImplementedException();
        }

        IMethodSymbol IMethodSymbol.Construct(params ITypeSymbol[] typeArguments)
        {
            throw new NotImplementedException();
        }

        IMethodSymbol IMethodSymbol.Construct(ImmutableArray<ITypeSymbol> typeArguments, ImmutableArray<Microsoft.CodeAnalysis.NullableAnnotation> typeArgumentNullableAnnotations)
        {
            throw new NotImplementedException();
        }

        DllImportData IMethodSymbol.GetDllImportData()
        {
            throw new NotImplementedException();
        }
    }
}
