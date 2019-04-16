// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp.Emit;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.PooledObjects;
using Roslyn.Utilities;

namespace Microsoft.CodeAnalysis.CSharp.Symbols
{
    internal sealed class SourcePropertyAccessorSymbol : SourceMemberMethodSymbol
    {
        private readonly SourcePropertySymbol _property;
        private ImmutableArray<ParameterSymbol> _lazyParameters;
        private TypeWithAnnotations _lazyReturnType;
        private ImmutableArray<CustomModifier> _lazyRefCustomModifiers;
        private readonly ImmutableArray<MethodSymbol> _explicitInterfaceImplementations;
        private readonly string _name;
        private readonly bool _isAutoPropertyAccessor;
        private readonly bool _isExpressionBodied;

        public static SourcePropertyAccessorSymbol CreateAccessorSymbol(
            NamedTypeSymbol containingType,
            SourcePropertySymbol property,
            DeclarationModifiers propertyModifiers,
            string propertyName,
            CSharpSyntaxNode syntax,
            PropertySymbol explicitlyImplementedPropertyOpt,
            string aliasQualifierOpt,
            bool isAutoPropertyAccessor,
            bool isExplicitInterfaceImplementation,
            DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        public static SourcePropertyAccessorSymbol CreateAccessorSymbol(
            NamedTypeSymbol containingType,
            SourcePropertySymbol property,
            DeclarationModifiers propertyModifiers,
            string propertyName,
            CSharpSyntaxNode syntax,
            PropertySymbol explicitlyImplementedPropertyOpt,
            string aliasQualifierOpt,
            bool isExplicitInterfaceImplementation,
            DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        internal override bool IsExpressionBodied
        {
            get
            {
                return _isExpressionBodied;
            }
        }

        private static void GetNameAndExplicitInterfaceImplementations(
            PropertySymbol explicitlyImplementedPropertyOpt,
            string propertyName,
            bool isWinMd,
            string aliasQualifierOpt,
            bool isGetMethod,
            out string name,
            out ImmutableArray<MethodSymbol> explicitInterfaceImplementations)
        {
            if ((object)explicitlyImplementedPropertyOpt == null)
            {
                name = GetAccessorName(propertyName, isGetMethod, isWinMd);
                explicitInterfaceImplementations = ImmutableArray<MethodSymbol>.Empty;
            }
            else
            {
                MethodSymbol implementedAccessor = isGetMethod
                    ? explicitlyImplementedPropertyOpt.GetMethod
                    : explicitlyImplementedPropertyOpt.SetMethod;

                string accessorName = (object)implementedAccessor != null
                    ? implementedAccessor.Name
                    : GetAccessorName(explicitlyImplementedPropertyOpt.MetadataName,
                        isGetMethod, isWinMd); //Not name - could be indexer placeholder

                name = ExplicitInterfaceHelpers.GetMemberName(accessorName, explicitlyImplementedPropertyOpt.ContainingType, aliasQualifierOpt);
                explicitInterfaceImplementations = (object)implementedAccessor == null
                    ? ImmutableArray<MethodSymbol>.Empty
                    : ImmutableArray.Create<MethodSymbol>(implementedAccessor);
            }
        }

        private SourcePropertyAccessorSymbol(
            NamedTypeSymbol containingType,
            string name,
            SourcePropertySymbol property,
            DeclarationModifiers propertyModifiers,
            ImmutableArray<MethodSymbol> explicitInterfaceImplementations,
            Location location,
            CSharpSyntaxNode syntax,
            bool isExplicitInterfaceImplementation,
            DiagnosticBag diagnostics) :
            base(containingType, syntax.GetReference(), location)
        {
            _property = property;
            _explicitInterfaceImplementations = explicitInterfaceImplementations;
            _name = name;
            _isAutoPropertyAccessor = false;
            _isExpressionBodied = true;

            // The modifiers for the accessor are the same as the modifiers for the property,
            // minus the indexer and readonly bit
            var declarationModifiers = GetAccessorModifiers(propertyModifiers);

            // ReturnsVoid property is overridden in this class so
            // returnsVoid argument to MakeFlags is ignored.
            this.MakeFlags(MethodKind.PropertyGet, declarationModifiers, returnsVoid: false, isExtensionMethod: false,
                isMetadataVirtualIgnoringModifiers: explicitInterfaceImplementations.Any());

            CheckFeatureAvailabilityAndRuntimeSupport(syntax, location, hasBody: true, diagnostics: diagnostics);
            CheckModifiersForBody(syntax, location, diagnostics);

            var info = ModifierUtils.CheckAccessibility(this.DeclarationModifiers, this, isExplicitInterfaceImplementation);
            if (info != null)
            {
                diagnostics.Add(info, location);
            }

            this.CheckModifiers(location, hasBody: true, isAutoPropertyOrExpressionBodied: true, diagnostics: diagnostics);

            if (this.IsOverride)
            {
                MethodSymbol overriddenMethod = this.OverriddenMethod;
                if ((object)overriddenMethod != null)
                {
                    // If this accessor is overriding a method from metadata, it is possible that
                    // the name of the overridden method doesn't follow the C# get_X/set_X pattern.
                    // We should copy the name so that the runtime will recognize this as an override.
                    _name = overriddenMethod.Name;
                }
            }
        }

        private SourcePropertyAccessorSymbol(
            NamedTypeSymbol containingType,
            string name,
            SourcePropertySymbol property,
            DeclarationModifiers propertyModifiers,
            ImmutableArray<MethodSymbol> explicitInterfaceImplementations,
            Location location,
            CSharpSyntaxNode syntax,
            MethodKind methodKind,
            bool isAutoPropertyAccessor,
            bool isExplicitInterfaceImplementation,
            DiagnosticBag diagnostics)
            : base(containingType,
                   syntax.GetReference(),
                   location)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        private static DeclarationModifiers GetAccessorModifiers(DeclarationModifiers propertyModifiers) =>
            propertyModifiers & ~(DeclarationModifiers.Indexer | DeclarationModifiers.ReadOnly);

        protected override void MethodChecks(DiagnosticBag diagnostics)
        {
            // These values may not be final, but we need to have something set here in the
            // event that we need to find the overridden accessor.
            _lazyParameters = ComputeParameters(diagnostics);
            _lazyReturnType = ComputeReturnType(diagnostics);
            _lazyRefCustomModifiers = ImmutableArray<CustomModifier>.Empty;

            if (_explicitInterfaceImplementations.Length > 0)
            {
                Debug.Assert(_explicitInterfaceImplementations.Length == 1);
                MethodSymbol implementedMethod = _explicitInterfaceImplementations[0];
                CustomModifierUtils.CopyMethodCustomModifiers(implementedMethod, this, out _lazyReturnType,
                                                              out _lazyRefCustomModifiers,
                                                              out _lazyParameters, alsoCopyParamsModifier: false);
            }
            else if (this.IsOverride)
            {
                // This will cause another call to SourceMethodSymbol.LazyMethodChecks, 
                // but that method already handles reentrancy for exactly this case.
                MethodSymbol overriddenMethod = this.OverriddenMethod;
                if ((object)overriddenMethod != null)
                {
                    CustomModifierUtils.CopyMethodCustomModifiers(overriddenMethod, this, out _lazyReturnType,
                                                                  out _lazyRefCustomModifiers,
                                                                  out _lazyParameters, alsoCopyParamsModifier: true);
                }
            }
            else if (_lazyReturnType.SpecialType != SpecialType.System_Void)
            {
                PropertySymbol associatedProperty = _property;
                var type = associatedProperty.TypeWithAnnotations;
                _lazyReturnType = _lazyReturnType.WithTypeAndModifiers(
                    CustomModifierUtils.CopyTypeCustomModifiers(type.Type, _lazyReturnType.Type, this.ContainingAssembly),
                    type.CustomModifiers);
                _lazyRefCustomModifiers = associatedProperty.RefCustomModifiers;
            }
        }

        public override Accessibility DeclaredAccessibility
        {
            get
            {
                var accessibility = this.LocalAccessibility;
                if (accessibility != Accessibility.NotApplicable)
                {
                    return accessibility;
                }

                var propertyAccessibility = _property.DeclaredAccessibility;
                Debug.Assert(propertyAccessibility != Accessibility.NotApplicable);
                return propertyAccessibility;
            }
        }

        public override Symbol AssociatedSymbol
        {
            get { return _property; }
        }

        public override bool IsVararg
        {
            get { return false; }
        }

        public override bool ReturnsVoid
        {
            get { return this.ReturnType.SpecialType == SpecialType.System_Void; }
        }

        public override ImmutableArray<ParameterSymbol> Parameters
        {
            get
            {
                LazyMethodChecks();
                return _lazyParameters;
            }
        }

        public override ImmutableArray<TypeParameterSymbol> TypeParameters
        {
            get { return ImmutableArray<TypeParameterSymbol>.Empty; }
        }

        public override ImmutableArray<TypeParameterConstraintClause> GetTypeParameterConstraintClauses(bool early)
            => ImmutableArray<TypeParameterConstraintClause>.Empty;

        public override RefKind RefKind
        {
            get { return _property.RefKind; }
        }

        public override TypeWithAnnotations ReturnTypeWithAnnotations
        {
            get
            {
                LazyMethodChecks();
                return _lazyReturnType;
            }
        }

        private TypeWithAnnotations ComputeReturnType(DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        private Binder GetBinder()
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
            /*
            var syntax = this.GetSyntax();
            var compilation = this.DeclaringCompilation;
            var binderFactory = compilation.GetBinderFactory(syntax.SyntaxTree);
            return binderFactory.GetBinder(syntax);*/
        }

        public override ImmutableArray<CustomModifier> RefCustomModifiers
        {
            get
            {
                LazyMethodChecks();
                return _lazyRefCustomModifiers;
            }
        }

        /// <summary>
        /// Return Accessibility declared locally on the accessor, or
        /// NotApplicable if no accessibility was declared explicitly.
        /// </summary>
        internal Accessibility LocalAccessibility
        {
            get { return ModifierUtils.EffectiveAccessibility(this.DeclarationModifiers); }
        }

        /// <summary>
        /// Indicates whether this accessor itself has a 'readonly' modifier.
        /// </summary>
        internal bool LocalDeclaredReadOnly => (DeclarationModifiers & DeclarationModifiers.ReadOnly) != 0;

        /// <summary>
        /// Indicates whether this accessor is readonly due to reasons scoped to itself and its containing property.
        /// </summary>
        internal override bool IsDeclaredReadOnly => LocalDeclaredReadOnly || _property.HasReadOnlyModifier || IsReadOnlyAutoGetter;

        private bool IsReadOnlyAutoGetter => ContainingType.IsStructType() && !_property.IsStatic && _isAutoPropertyAccessor && MethodKind == MethodKind.PropertyGet;

        private DeclarationModifiers MakeModifiers(CSharpSyntaxNode syntax, bool isExplicitInterfaceImplementation,
            bool hasBody, Location location, DiagnosticBag diagnostics, out bool modifierErrors)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        private void CheckModifiers(Location location, bool hasBody, bool isAutoPropertyOrExpressionBodied, DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        /// <summary>
        /// If we are outputting a .winmdobj then the setter name is put_, not set_.
        /// </summary>
        internal static string GetAccessorName(string propertyName, bool getNotSet, bool isWinMdOutput)
        {
            var prefix = getNotSet ? "get_" : isWinMdOutput ? "put_" : "set_";
            return prefix + propertyName;
        }

        /// <returns>
        /// <see cref="AccessorDeclarationSyntax"/> or <see cref="ArrowExpressionClauseSyntax"/>
        /// </returns>
        internal CSharpSyntaxNode GetSyntax()
        {
            Debug.Assert(syntaxReferenceOpt != null);
            return (CSharpSyntaxNode)syntaxReferenceOpt.GetSyntax();
        }

        public override ImmutableArray<MethodSymbol> ExplicitInterfaceImplementations
        {
            get
            {
                return _explicitInterfaceImplementations;
            }
        }

        internal override OneOrMany<SyntaxList<CSharpSyntaxNode>> GetAttributeDeclarations()
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        public override string Name
        {
            get
            {
                return _name;
            }
        }

        public override bool IsImplicitlyDeclared
        {
            get
            {
                // Per design meeting resolution [see bug 11253], no source accessor is implicitly declared in C#,
                // because there is "get", "set", or expression-body syntax.
                return false;
            }
        }

        internal override bool GenerateDebugInfo
        {
            get
            {
                return true;
            }
        }

        private ImmutableArray<ParameterSymbol> ComputeParameters(DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        internal override void AfterAddingTypeMembersChecks(ConversionsBase conversions, DiagnosticBag diagnostics)
        {
            base.AfterAddingTypeMembersChecks(conversions, diagnostics);

            if (IsDeclaredReadOnly)
            {
                this.DeclaringCompilation.EnsureIsReadOnlyAttributeExists(diagnostics, locations[0], modifyCompilation: true);
            }
        }

        internal override void AddSynthesizedAttributes(PEModuleBuilder moduleBuilder, ref ArrayBuilder<SynthesizedAttributeData> attributes)
        {
            base.AddSynthesizedAttributes(moduleBuilder, ref attributes);

            if (_isAutoPropertyAccessor)
            {
                var compilation = this.DeclaringCompilation;
                AddSynthesizedAttribute(ref attributes, compilation.TrySynthesizeAttribute(WellKnownMember.System_Runtime_CompilerServices_CompilerGeneratedAttribute__ctor));
            }
        }
    }
}
