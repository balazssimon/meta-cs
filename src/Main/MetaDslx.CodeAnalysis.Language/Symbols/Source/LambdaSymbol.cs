// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.PooledObjects;
using Roslyn.Utilities;

namespace Microsoft.CodeAnalysis.CSharp.Symbols
{
    internal sealed class LambdaSymbol : SourceMethodSymbol
    {
        private readonly Symbol _containingSymbol;
        private readonly SyntaxNode _syntax;
        private readonly ImmutableArray<ParameterSymbol> _parameters;
        private RefKind _refKind;
        private TypeWithAnnotations _returnType;
        private readonly bool _isSynthesized;
        private readonly bool _isAsync;

        /// <summary>
        /// This symbol is used as the return type of a LambdaSymbol when we are interpreting
        /// lambda's body in order to infer its return type.
        /// </summary>
        internal static readonly TypeSymbol ReturnTypeIsBeingInferred = new UnsupportedMetadataTypeSymbol();

        /// <summary>
        /// This symbol is used as the return type of a LambdaSymbol when we failed to infer its return type.
        /// </summary>
        internal static readonly TypeSymbol InferenceFailureReturnType = new UnsupportedMetadataTypeSymbol();

        private static readonly TypeWithAnnotations UnknownReturnType = TypeWithAnnotations.Create(ErrorTypeSymbol.UnknownResultType);

        public LambdaSymbol(
            CSharpCompilation compilation,
            Symbol containingSymbol,
            ImmutableArray<TypeWithAnnotations> parameterTypes,
            ImmutableArray<RefKind> parameterRefKinds,
            RefKind refKind,
            TypeWithAnnotations returnType,
            DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        public override MethodKind MethodKind
        {
            get { return MethodKind.AnonymousFunction; }
        }

        public override bool IsExtern
        {
            get { return false; }
        }

        public override bool IsSealed
        {
            get { return false; }
        }

        public override bool IsAbstract
        {
            get { return false; }
        }

        public override bool IsVirtual
        {
            get { return false; }
        }

        public override bool IsOverride
        {
            get { return false; }
        }

        public override bool IsStatic
        {
            get { return false; }
        }

        public override bool IsAsync
        {
            get { return _isAsync; }
        }

        internal sealed override ObsoleteAttributeData ObsoleteAttributeData
        {
            get { return null; }
        }

        internal sealed override bool IsMetadataNewSlot(bool ignoreInterfaceImplementationChanges = false)
        {
            return false;
        }

        internal sealed override bool IsMetadataVirtual(bool ignoreInterfaceImplementationChanges = false)
        {
            return false;
        }

        internal override bool IsMetadataFinal
        {
            get
            {
                return false;
            }
        }

        public override bool IsVararg
        {
            get { return false; }
        }

        internal override bool HasSpecialName
        {
            get { return false; }
        }

        internal override System.Reflection.MethodImplAttributes ImplementationAttributes
        {
            get { return default(System.Reflection.MethodImplAttributes); }
        }

        internal override bool RequiresSecurityObject
        {
            get { return false; }
        }

        public override DllImportData GetDllImportData()
        {
            return null;
        }

        internal override MarshalPseudoCustomAttributeData ReturnValueMarshallingInformation
        {
            get { return null; }
        }

        internal override bool HasDeclarativeSecurity
        {
            get { return false; }
        }

        internal override IEnumerable<Microsoft.Cci.SecurityAttribute> GetSecurityInformation()
        {
            throw ExceptionUtilities.Unreachable;
        }

        internal override ImmutableArray<string> GetAppliedConditionalSymbols()
        {
            return ImmutableArray<string>.Empty;
        }

        public override bool ReturnsVoid
        {
            get { return this.ReturnTypeWithAnnotations.HasType && this.ReturnType.SpecialType == SpecialType.System_Void; }
        }

        public override RefKind RefKind
        {
            get { return _refKind; }
        }

        public override TypeWithAnnotations ReturnTypeWithAnnotations
        {
            get { return _returnType; }
        }

        // In error recovery and type inference scenarios we do not know the return type
        // until after the body is bound, but the symbol is created before the body
        // is bound.  Fill in the return type post hoc in these scenarios; the
        // IDE might inspect the symbol and want to know the return type.
        internal void SetInferredReturnType(RefKind refKind, TypeWithAnnotations inferredReturnType)
        {
            Debug.Assert(inferredReturnType.HasType);
            Debug.Assert((object)_returnType.Type == ReturnTypeIsBeingInferred);
            _refKind = refKind;
            _returnType = inferredReturnType;
        }

        public override ImmutableArray<CustomModifier> RefCustomModifiers
        {
            get { return ImmutableArray<CustomModifier>.Empty; }
        }

        internal override bool IsExplicitInterfaceImplementation
        {
            get { return false; }
        }

        public override ImmutableArray<MethodSymbol> ExplicitInterfaceImplementations
        {
            get { return ImmutableArray<MethodSymbol>.Empty; }
        }

        public override Symbol AssociatedSymbol
        {
            get { return null; }
        }

        public override ImmutableArray<TypeWithAnnotations> TypeArgumentsWithAnnotations
        {
            get { return ImmutableArray<TypeWithAnnotations>.Empty; }
        }

        public override ImmutableArray<TypeParameterSymbol> TypeParameters
        {
            get { return ImmutableArray<TypeParameterSymbol>.Empty; }
        }

        public override int Arity
        {
            get { return 0; }
        }

        public override ImmutableArray<ParameterSymbol> Parameters
        {
            get { return _parameters; }
        }

        internal override bool TryGetThisParameter(out ParameterSymbol thisParameter)
        {
            // Lambda symbols have no "this" parameter
            thisParameter = null;
            return true;
        }

        public override Accessibility DeclaredAccessibility
        {
            get { return Accessibility.Private; }
        }

        public override ImmutableArray<Location> Locations
        {
            get
            {
                return ImmutableArray.Create<Location>(_syntax.Location);
            }
        }

        /// <summary>
        /// Locations[0] on lambda symbols covers the entire syntax, which is inconvenient but remains for compatibility.
        /// For better diagnostics quality, use the DiagnosticLocation instead, which points to the "delegate" or the "=>".
        /// </summary>
        internal Location DiagnosticLocation
        {
            get
            {
                throw new System.NotImplementedException("TODO:MetaDslx");
            }
        }

        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences
        {
            get
            {
                return ImmutableArray.Create<SyntaxReference>(_syntax.GetReference());
            }
        }

        public override Symbol ContainingSymbol
        {
            get { return _containingSymbol; }
        }

        internal override Microsoft.Cci.CallingConvention CallingConvention
        {
            get { return Microsoft.Cci.CallingConvention.Default; }
        }

        public override bool IsExtensionMethod
        {
            get { return false; }
        }

        public override bool HidesBaseMethodsByName
        {
            get { return false; }
        }

        public sealed override bool Equals(object symbol)
        {
            if ((object)this == symbol) return true;

            var lambda = symbol as LambdaSymbol;
            return (object)lambda != null
                && lambda._syntax == _syntax
                && lambda._refKind == _refKind
                && TypeSymbol.Equals(lambda.ReturnType, this.ReturnType, TypeCompareKind.ConsiderEverything2)
                && System.Linq.ImmutableArrayExtensions.SequenceEqual(lambda.ParameterTypesWithAnnotations, this.ParameterTypesWithAnnotations, (p1, p2) => p1.Type.Equals(p2.Type))
                && Equals(lambda.ContainingSymbol, this.ContainingSymbol);
        }

        public override int GetHashCode()
        {
            return _syntax.GetHashCode();
        }

        public override bool IsImplicitlyDeclared
        {
            get
            {
                return _isSynthesized;
            }
        }

        internal override bool GenerateDebugInfo
        {
            get { return true; }
        }

        internal override bool IsDeclaredReadOnly => false;

        public override ImmutableArray<TypeParameterConstraintClause> GetTypeParameterConstraintClauses(bool early) => ImmutableArray<TypeParameterConstraintClause>.Empty;

        internal override int CalculateLocalSyntaxOffset(int localPosition, SyntaxTree localTree)
        {
            throw ExceptionUtilities.Unreachable;
        }
    }
}
