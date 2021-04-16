using Microsoft.CodeAnalysis;
using MetaDslx.CodeAnalysis.Symbols;
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
    public abstract class MethodSymbol : MemberSymbol
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
    }
}
