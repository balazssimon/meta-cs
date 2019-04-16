// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using Microsoft.Cci;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.PooledObjects;
using Roslyn.Utilities;

namespace Microsoft.CodeAnalysis.CSharp.Symbols
{
    internal sealed class LocalFunctionSymbol : SourceMethodSymbol
    {
        private readonly Binder _binder;
        private readonly CSharpSyntaxNode _syntax;
        private readonly Symbol _containingSymbol;
        private readonly DeclarationModifiers _declarationModifiers;
        private readonly ImmutableArray<SourceMethodTypeParameterSymbol> _typeParameters;
        private readonly RefKind _refKind;

        private ImmutableArray<ParameterSymbol> _lazyParameters;
        private bool _lazyIsVarArg;
        // Initialized in two steps. Hold a copy if accessing during initialization.
        private ImmutableArray<TypeParameterConstraintClause> _lazyTypeParameterConstraints;
        private TypeWithAnnotations _lazyReturnType;
        private TypeWithAnnotations.Builder _lazyIteratorElementType;

        // Lock for initializing lazy fields and registering their diagnostics
        // Acquire this lock when initializing lazy objects to guarantee their declaration
        // diagnostics get added to the store exactly once
        private readonly DiagnosticBag _declarationDiagnostics;

        public LocalFunctionSymbol(
            Binder binder,
            Symbol containingSymbol,
            CSharpSyntaxNode syntax)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        /// <summary>
        /// Binder that owns the scope for the local function symbol, namely the scope where the
        /// local function is declared.
        /// </summary>
        internal Binder ScopeBinder { get; }

        public Binder ParameterBinder => _binder;

        internal void GetDeclarationDiagnostics(DiagnosticBag addTo)
        {
            // Force complete type parameters
            foreach (var typeParam in _typeParameters)
            {
                typeParam.ForceComplete(null, default(CancellationToken));
            }

            // force lazy init
            ComputeParameters();

            foreach (var p in _lazyParameters)
            {
                // Force complete parameters to retrieve all diagnostics
                p.ForceComplete(null, default(CancellationToken));
            }

            ComputeReturnType();

            addTo.AddRange(_declarationDiagnostics);
        }

        internal override void AddDeclarationDiagnostics(DiagnosticBag diagnostics)
            => _declarationDiagnostics.AddRange(diagnostics);

        public override bool IsVararg
        {
            get
            {
                ComputeParameters();
                return _lazyIsVarArg;
            }
        }

        public override ImmutableArray<ParameterSymbol> Parameters
        {
            get
            {
                ComputeParameters();
                return _lazyParameters;
            }
        }

        private void ComputeParameters()
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        public override TypeWithAnnotations ReturnTypeWithAnnotations
        {
            get
            {
                ComputeReturnType();
                return _lazyReturnType;
            }
        }

        public override RefKind RefKind => _refKind;

        internal void ComputeReturnType()
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        public override bool ReturnsVoid => ReturnType.SpecialType == SpecialType.System_Void;

        public override int Arity => TypeParameters.Length;

        public override ImmutableArray<TypeWithAnnotations> TypeArgumentsWithAnnotations => GetTypeParametersAsTypeArguments();

        public override ImmutableArray<TypeParameterSymbol> TypeParameters
            => _typeParameters.Cast<SourceMethodTypeParameterSymbol, TypeParameterSymbol>();

        public override bool IsExtensionMethod
        {
            get
            {
                throw new System.NotImplementedException("TODO:MetaDslx");
            }
        }

        // Replace with IsStatic after fixing https://github.com/dotnet/roslyn/issues/27719.
        internal bool IsStaticLocalFunction => throw new System.NotImplementedException("TODO:MetaDslx");

        internal override TypeWithAnnotations IteratorElementTypeWithAnnotations
        {
            get
            {
                return _lazyIteratorElementType.ToType();
            }
            set
            {
                Debug.Assert(_lazyIteratorElementType.IsDefault || TypeSymbol.Equals(_lazyIteratorElementType.ToType().Type, value.Type, TypeCompareKind.ConsiderEverything2));
                _lazyIteratorElementType.InterlockedInitialize(value);
            }
        }

        public override MethodKind MethodKind => MethodKind.LocalFunction;

        public sealed override Symbol ContainingSymbol => _containingSymbol;

        public override string Name => throw new System.NotImplementedException("TODO:MetaDslx");

        public SyntaxToken NameToken => throw new System.NotImplementedException("TODO:MetaDslx");

        public Binder SignatureBinder => _binder;

        internal override bool HasSpecialName => false;

        public override bool HidesBaseMethodsByName => false;

        public override ImmutableArray<MethodSymbol> ExplicitInterfaceImplementations => ImmutableArray<MethodSymbol>.Empty;

        public override ImmutableArray<Location> Locations => ImmutableArray.Create(_syntax.GetLocation());

        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences => ImmutableArray.Create(_syntax.GetReference());

        internal override bool GenerateDebugInfo => true;

        public override ImmutableArray<CustomModifier> RefCustomModifiers => ImmutableArray<CustomModifier>.Empty;

        internal override MethodImplAttributes ImplementationAttributes => default(MethodImplAttributes);

        internal override ObsoleteAttributeData ObsoleteAttributeData => null;

        internal override MarshalPseudoCustomAttributeData ReturnValueMarshallingInformation => null;

        internal override CallingConvention CallingConvention => CallingConvention.Default;

        internal override bool HasDeclarativeSecurity => false;

        internal override bool RequiresSecurityObject => false;

        public override Symbol AssociatedSymbol => null;

        public override Accessibility DeclaredAccessibility => ModifierUtils.EffectiveAccessibility(_declarationModifiers);

        public override bool IsAsync => (_declarationModifiers & DeclarationModifiers.Async) != 0;

        public override bool IsStatic => (_declarationModifiers & DeclarationModifiers.Static) != 0;

        public override bool IsVirtual => (_declarationModifiers & DeclarationModifiers.Virtual) != 0;

        public override bool IsOverride => (_declarationModifiers & DeclarationModifiers.Override) != 0;

        public override bool IsAbstract => (_declarationModifiers & DeclarationModifiers.Abstract) != 0;

        public override bool IsSealed => (_declarationModifiers & DeclarationModifiers.Sealed) != 0;

        public override bool IsExtern => (_declarationModifiers & DeclarationModifiers.Extern) != 0;

        public bool IsUnsafe => (_declarationModifiers & DeclarationModifiers.Unsafe) != 0;

        internal bool IsExpressionBodied => throw new System.NotImplementedException("TODO:MetaDslx");

        internal override bool IsDeclaredReadOnly => false;

        public override DllImportData GetDllImportData() => null;

        internal override ImmutableArray<string> GetAppliedConditionalSymbols() => ImmutableArray<string>.Empty;

        internal override bool IsMetadataNewSlot(bool ignoreInterfaceImplementationChanges = false) => false;

        internal override bool IsMetadataVirtual(bool ignoreInterfaceImplementationChanges = false) => false;

        internal override IEnumerable<SecurityAttribute> GetSecurityInformation()
        {
            throw ExceptionUtilities.Unreachable;
        }

        internal override int CalculateLocalSyntaxOffset(int localPosition, SyntaxTree localTree)
        {
            throw ExceptionUtilities.Unreachable;
        }

        internal override bool TryGetThisParameter(out ParameterSymbol thisParameter)
        {
            // Local function symbols have no "this" parameter
            thisParameter = null;
            return true;
        }

        private static void ReportAttributesDisallowed(SyntaxList<CSharpSyntaxNode> attributes, DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        private ImmutableArray<SourceMethodTypeParameterSymbol> MakeTypeParameters(DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        public override ImmutableArray<TypeParameterConstraintClause> GetTypeParameterConstraintClauses(bool early)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        public override int GetHashCode()
        {
            // this is what lambdas do (do not use hashes of other fields)
            return _syntax.GetHashCode();
        }

        public sealed override bool Equals(object symbol)
        {
            if ((object)this == symbol) return true;

            var localFunction = symbol as LocalFunctionSymbol;
            return (object)localFunction != null
                && localFunction._syntax == _syntax;
        }
    }
}
