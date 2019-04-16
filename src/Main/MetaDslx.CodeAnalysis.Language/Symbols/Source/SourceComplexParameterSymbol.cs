// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Roslyn.Utilities;

namespace Microsoft.CodeAnalysis.CSharp.Symbols
{
    /// <summary>
    /// A source parameter, potentially with a default value, attributes, etc.
    /// </summary>
    internal class SourceComplexParameterSymbol : SourceParameterSymbol, IAttributeTargetSymbol
    {
        [Flags]
        private enum ParameterSyntaxKind : byte
        {
            Regular = 0,
            ParamsParameter = 1,
            ExtensionThisParameter = 2,
            DefaultParameter = 4,
        }

        private readonly SyntaxReference _syntaxRef;
        private readonly ParameterSyntaxKind _parameterSyntaxKind;

        private CustomAttributesBag<CSharpAttributeData> _lazyCustomAttributesBag;
        private ThreeState _lazyHasOptionalAttribute;
        protected ConstantValue _lazyDefaultSyntaxValue;

        internal SourceComplexParameterSymbol(
            Symbol owner,
            int ordinal,
            TypeWithAnnotations parameterType,
            RefKind refKind,
            string name,
            ImmutableArray<Location> locations,
            SyntaxReference syntaxRef,
            ConstantValue defaultSyntaxValue,
            bool isParams,
            bool isExtensionMethodThis)
            : base(owner, parameterType, ordinal, refKind, name, locations)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        private Binder ParameterBinderOpt => (ContainingSymbol as LocalFunctionSymbol)?.ParameterBinder;

        internal override SyntaxReference SyntaxReference => _syntaxRef;

        internal CSharpSyntaxNode CSharpSyntaxNode => (CSharpSyntaxNode)_syntaxRef?.GetSyntax();

        internal SyntaxTree SyntaxTree => _syntaxRef == null ? null : _syntaxRef.SyntaxTree;

        internal override ConstantValue ExplicitDefaultConstantValue
        {
            get
            {
                // Parameter has either default argument syntax or DefaultParameterValue attribute, but not both.
                // We separate these since in some scenarios (delegate Invoke methods) we need to suppress syntactic 
                // default value but use value from pseudo-custom attribute. 
                //
                // For example:
                // public delegate void D([Optional, DefaultParameterValue(1)]int a, int b = 2);
                //
                // Dev11 emits the first parameter as option with default value and the second as regular parameter.
                // The syntactic default value is suppressed since additional synthesized parameters are added at the end of the signature.

                return DefaultSyntaxValue ?? DefaultValueFromAttributes;
            }
        }

        internal override ConstantValue DefaultValueFromAttributes
        {
            get
            {
                ParameterEarlyWellKnownAttributeData data = GetEarlyDecodedWellKnownAttributeData();
                return (data != null && data.DefaultParameterValue != ConstantValue.Unset) ? data.DefaultParameterValue : ConstantValue.NotAvailable;
            }
        }

        internal override bool IsIDispatchConstant
            => GetDecodedWellKnownAttributeData()?.HasIDispatchConstantAttribute == true;

        internal override bool IsIUnknownConstant
            => GetDecodedWellKnownAttributeData()?.HasIUnknownConstantAttribute == true;

        private bool HasCallerLineNumberAttribute
            => GetEarlyDecodedWellKnownAttributeData()?.HasCallerLineNumberAttribute == true;

        private bool HasCallerFilePathAttribute
            => GetEarlyDecodedWellKnownAttributeData()?.HasCallerFilePathAttribute == true;

        private bool HasCallerMemberNameAttribute
            => GetEarlyDecodedWellKnownAttributeData()?.HasCallerMemberNameAttribute == true;

        internal override bool IsCallerLineNumber => HasCallerLineNumberAttribute;

        internal override bool IsCallerFilePath => !HasCallerLineNumberAttribute && HasCallerFilePathAttribute;

        internal override bool IsCallerMemberName => !HasCallerLineNumberAttribute
                                                  && !HasCallerFilePathAttribute
                                                  && HasCallerMemberNameAttribute;

        internal override FlowAnalysisAnnotations FlowAnalysisAnnotations
        {
            get
            {
                FlowAnalysisAnnotations? annotations = TryGetExtraAttributeAnnotations();
                if (annotations.HasValue)
                {
                    // https://github.com/dotnet/roslyn/issues/30078: Make sure this is covered by test
                    return annotations.Value;
                }

                ParameterWellKnownAttributeData attributeData = GetDecodedWellKnownAttributeData();
                bool hasEnsuresNotNull = attributeData?.HasEnsuresNotNullAttribute == true;

                return FlowAnalysisAnnotationsFacts.Create(
                    notNullWhenTrue: hasEnsuresNotNull || attributeData?.HasNotNullWhenTrueAttribute == true,
                    notNullWhenFalse: hasEnsuresNotNull || attributeData?.HasNotNullWhenFalseAttribute == true,
                    assertsTrue: attributeData?.HasAssertsTrueAttribute == true,
                    assertsFalse: attributeData?.HasAssertsFalseAttribute == true);
            }
        }

        private ConstantValue DefaultSyntaxValue
        {
            get
            {
                if (_lazyDefaultSyntaxValue == ConstantValue.Unset)
                {
                    var diagnostics = DiagnosticBag.GetInstance();

                    if (Interlocked.CompareExchange(
                        ref _lazyDefaultSyntaxValue,
                        MakeDefaultExpression(diagnostics, ParameterBinderOpt),
                        ConstantValue.Unset) == ConstantValue.Unset)
                    {
                        // This is a race condition where the thread that loses
                        // the compare exchange tries to access the diagnostics
                        // before the thread which won the race finishes adding
                        // them. https://github.com/dotnet/roslyn/issues/17243
                        AddDeclarationDiagnostics(diagnostics);
                    }

                    diagnostics.Free();
                }

                return _lazyDefaultSyntaxValue;
            }
        }

        // If binder is null, then get it from the compilation. Otherwise use the provided binder.
        // Don't always get it from the compilation because we might be in a speculative context (local function parameter),
        // in which case the declaring compilation is the wrong one.
        protected ConstantValue MakeDefaultExpression(DiagnosticBag diagnostics, Binder binder)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        public override string MetadataName
        {
            get
            {
                // The metadata parameter name should be the name used in the partial definition.

                var sourceMethod = this.ContainingSymbol as SourceOrdinaryMethodSymbol;
                if ((object)sourceMethod == null)
                {
                    return base.MetadataName;
                }

                var definition = sourceMethod.SourcePartialDefinition;
                if ((object)definition == null)
                {
                    return base.MetadataName;
                }

                return definition.Parameters[this.Ordinal].MetadataName;
            }
        }

        protected virtual IAttributeTargetSymbol AttributeOwner => this;

        IAttributeTargetSymbol IAttributeTargetSymbol.AttributesOwner => AttributeOwner;

        AttributeLocation IAttributeTargetSymbol.DefaultAttributeLocation => AttributeLocation.Parameter;

        AttributeLocation IAttributeTargetSymbol.AllowedAttributeLocations => AttributeLocation.Parameter;

        /// <summary>
        /// Symbol to copy bound attributes from, or null if the attributes are not shared among multiple source parameter symbols.
        /// </summary>
        /// <remarks>
        /// Used for parameters of partial implementation. We bind the attributes only on the definition
        /// part and copy them over to the implementation.
        /// </remarks>
        private SourceParameterSymbol BoundAttributesSource
        {
            get
            {
                var sourceMethod = this.ContainingSymbol as SourceOrdinaryMethodSymbol;
                if ((object)sourceMethod == null)
                {
                    return null;
                }

                var impl = sourceMethod.SourcePartialImplementation;
                if ((object)impl == null)
                {
                    return null;
                }

                return (SourceParameterSymbol)impl.Parameters[this.Ordinal];
            }
        }

        internal sealed override SyntaxList<CSharpSyntaxNode> AttributeDeclarationList
        {
            get
            {
                throw new System.NotImplementedException("TODO:MetaDslx");
            }
        }

        /// <summary>
        /// Gets the syntax list of custom attributes that declares attributes for this parameter symbol.
        /// </summary>
        internal virtual OneOrMany<SyntaxList<CSharpSyntaxNode>> GetAttributeDeclarations()
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        /// <summary>
        /// Returns data decoded from well-known attributes applied to the symbol or null if there are no applied attributes.
        /// </summary>
        /// <remarks>
        /// Forces binding and decoding of attributes.
        /// </remarks>
        internal ParameterWellKnownAttributeData GetDecodedWellKnownAttributeData()
        {
            var attributesBag = _lazyCustomAttributesBag;
            if (attributesBag == null || !attributesBag.IsDecodedWellKnownAttributeDataComputed)
            {
                attributesBag = this.GetAttributesBag();
            }

            return (ParameterWellKnownAttributeData)attributesBag.DecodedWellKnownAttributeData;
        }

        /// <summary>
        /// Returns data decoded from special early bound well-known attributes applied to the symbol or null if there are no applied attributes.
        /// </summary>
        /// <remarks>
        /// Forces binding and decoding of attributes.
        /// </remarks>
        internal ParameterEarlyWellKnownAttributeData GetEarlyDecodedWellKnownAttributeData()
        {
            var attributesBag = _lazyCustomAttributesBag;
            if (attributesBag == null || !attributesBag.IsEarlyDecodedWellKnownAttributeDataComputed)
            {
                attributesBag = this.GetAttributesBag();
            }

            return (ParameterEarlyWellKnownAttributeData)attributesBag.EarlyDecodedWellKnownAttributeData;
        }

        /// <summary>
        /// Returns a bag of applied custom attributes and data decoded from well-known attributes. Returns null if there are no attributes applied on the symbol.
        /// </summary>
        /// <remarks>
        /// Forces binding and decoding of attributes.
        /// </remarks>
        internal sealed override CustomAttributesBag<CSharpAttributeData> GetAttributesBag()
        {
            if (_lazyCustomAttributesBag == null || !_lazyCustomAttributesBag.IsSealed)
            {
                SourceParameterSymbol copyFrom = this.BoundAttributesSource;

                // prevent infinite recursion:
                Debug.Assert(!ReferenceEquals(copyFrom, this));

                bool bagCreatedOnThisThread;
                if ((object)copyFrom != null)
                {
                    var attributesBag = copyFrom.GetAttributesBag();
                    bagCreatedOnThisThread = Interlocked.CompareExchange(ref _lazyCustomAttributesBag, attributesBag, null) == null;
                }
                else
                {
                    var attributeSyntax = this.GetAttributeDeclarations();
                    bagCreatedOnThisThread = LoadAndValidateAttributes(attributeSyntax, ref _lazyCustomAttributesBag, binderOpt: ParameterBinderOpt);
                }

                if (bagCreatedOnThisThread)
                {
                    state.NotePartComplete(CompletionPart.Attributes);
                }
            }

            return _lazyCustomAttributesBag;
        }

        internal override void EarlyDecodeWellKnownAttributeType(NamedTypeSymbol attributeType, CSharpSyntaxNode attributeSyntax)
        {
            Debug.Assert(!attributeType.IsErrorType());

            // NOTE: OptionalAttribute is decoded specially before any of the other attributes and stored in the parameter
            // symbol (rather than in the EarlyWellKnownAttributeData) because it is needed during overload resolution.
            if (CSharpAttributeData.IsTargetEarlyAttribute(attributeType, attributeSyntax, AttributeDescription.OptionalAttribute))
            {
                _lazyHasOptionalAttribute = ThreeState.True;
            }
        }

        internal override void PostEarlyDecodeWellKnownAttributeTypes()
        {
            if (_lazyHasOptionalAttribute == ThreeState.Unknown)
            {
                _lazyHasOptionalAttribute = ThreeState.False;
            }

            base.PostEarlyDecodeWellKnownAttributeTypes();
        }

        internal override CSharpAttributeData EarlyDecodeWellKnownAttribute(ref EarlyDecodeWellKnownAttributeArguments<EarlyWellKnownAttributeBinder, NamedTypeSymbol, CSharpSyntaxNode, AttributeLocation> arguments)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        private CSharpAttributeData EarlyDecodeAttributeForDefaultParameterValue(AttributeDescription description, ref EarlyDecodeWellKnownAttributeArguments<EarlyWellKnownAttributeBinder, NamedTypeSymbol, CSharpSyntaxNode, AttributeLocation> arguments)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        internal override void DecodeWellKnownAttribute(ref DecodeWellKnownAttributeArguments<CSharpSyntaxNode, CSharpAttributeData, AttributeLocation> arguments)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        private void DecodeDefaultParameterValueAttribute(AttributeDescription description, ref DecodeWellKnownAttributeArguments<CSharpSyntaxNode, CSharpAttributeData, AttributeLocation> arguments)
        {
            var attribute = arguments.Attribute;
            var syntax = arguments.AttributeSyntaxOpt;
            var diagnostics = arguments.Diagnostics;

            Debug.Assert(syntax != null);
            Debug.Assert(diagnostics != null);

            var value = DecodeDefaultParameterValueAttribute(description, attribute, syntax, diagnose: true, diagnosticsOpt: diagnostics);
            if (!value.IsBad)
            {
                VerifyParamDefaultValueMatchesAttributeIfAny(value, syntax, diagnostics);
            }
        }

        /// <summary>
        /// Verify the default value matches the default value from any earlier attribute
        /// (DefaultParameterValueAttribute, DateTimeConstantAttribute or DecimalConstantAttribute).
        /// If not, report ERR_ParamDefaultValueDiffersFromAttribute.
        /// </summary>
        private void VerifyParamDefaultValueMatchesAttributeIfAny(ConstantValue value, CSharpSyntaxNode syntax, DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        private ConstantValue DecodeDefaultParameterValueAttribute(AttributeDescription description, CSharpAttributeData attribute, CSharpSyntaxNode node, bool diagnose, DiagnosticBag diagnosticsOpt)
        {
            Debug.Assert(!attribute.HasErrors);

            if (description.Equals(AttributeDescription.DefaultParameterValueAttribute))
            {
                return DecodeDefaultParameterValueAttribute(attribute, node, diagnose, diagnosticsOpt);
            }
            else if (description.Equals(AttributeDescription.DecimalConstantAttribute))
            {
                return attribute.DecodeDecimalConstantValue();
            }
            else
            {
                Debug.Assert(description.Equals(AttributeDescription.DateTimeConstantAttribute));
                return attribute.DecodeDateTimeConstantValue();
            }
        }

        private ConstantValue DecodeDefaultParameterValueAttribute(CSharpAttributeData attribute, CSharpSyntaxNode node, bool diagnose, DiagnosticBag diagnosticsOpt)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        internal override void PostDecodeWellKnownAttributes(ImmutableArray<CSharpAttributeData> boundAttributes, ImmutableArray<CSharpSyntaxNode> allAttributeSyntaxNodes, DiagnosticBag diagnostics, AttributeLocation symbolPart, WellKnownAttributeData decodedData)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        /// <summary>
        /// True if the parameter has default argument syntax.
        /// </summary>
        internal override bool HasDefaultArgumentSyntax
        {
            get
            {
                return (_parameterSyntaxKind & ParameterSyntaxKind.DefaultParameter) != 0;
            }
        }

        /// <summary>
        /// True if the parameter is marked by <see cref="System.Runtime.InteropServices.OptionalAttribute"/>.
        /// </summary>
        internal sealed override bool HasOptionalAttribute
        {
            get
            {
                if (_lazyHasOptionalAttribute == ThreeState.Unknown)
                {
                    SourceParameterSymbol copyFrom = this.BoundAttributesSource;

                    // prevent infinite recursion:
                    Debug.Assert(!ReferenceEquals(copyFrom, this));

                    if ((object)copyFrom != null)
                    {
                        // Parameter of partial implementation.
                        // We bind the attributes only on the definition part and copy them over to the implementation.
                        _lazyHasOptionalAttribute = copyFrom.HasOptionalAttribute.ToThreeState();
                    }
                    else
                    {
                        // lazyHasOptionalAttribute is decoded early, hence we cannot reach here when binding attributes for this symbol.
                        // So it is fine to force complete attributes here.

                        var attributes = GetAttributes();

                        if (!attributes.Any())
                        {
                            _lazyHasOptionalAttribute = ThreeState.False;
                        }
                    }
                }

                Debug.Assert(_lazyHasOptionalAttribute.HasValue());

                return _lazyHasOptionalAttribute.Value();
            }
        }

        internal override bool IsMetadataOptional
        {
            get
            {
                // NOTE: IsMetadataOptional property can be invoked during overload resolution.
                // NOTE: Optional attribute is decoded very early in attribute binding phase, see method EarlyDecodeOptionalAttribute
                // NOTE: If you update the below check to look for any more attributes, make sure that they are decoded early.
                return HasDefaultArgumentSyntax || HasOptionalAttribute;
            }
        }

        internal sealed override bool IsMetadataIn
            => base.IsMetadataIn || GetDecodedWellKnownAttributeData()?.HasInAttribute == true;

        internal sealed override bool IsMetadataOut
            => base.IsMetadataOut || GetDecodedWellKnownAttributeData()?.HasOutAttribute == true;

        internal sealed override MarshalPseudoCustomAttributeData MarshallingInformation
            => GetDecodedWellKnownAttributeData()?.MarshallingInformation;

        public override bool IsParams => (_parameterSyntaxKind & ParameterSyntaxKind.ParamsParameter) != 0;

        internal override bool IsExtensionMethodThis => (_parameterSyntaxKind & ParameterSyntaxKind.ExtensionThisParameter) != 0;

        public override ImmutableArray<CustomModifier> RefCustomModifiers => ImmutableArray<CustomModifier>.Empty;

        internal override void ForceComplete(SourceLocation locationOpt, CancellationToken cancellationToken)
        {
            base.ForceComplete(locationOpt, cancellationToken);

            // Force binding of default value.
            var unused = this.ExplicitDefaultConstantValue;
        }
    }

    internal sealed class SourceComplexParameterSymbolWithCustomModifiersPrecedingByRef : SourceComplexParameterSymbol
    {
        private readonly ImmutableArray<CustomModifier> _refCustomModifiers;

        internal SourceComplexParameterSymbolWithCustomModifiersPrecedingByRef(
            Symbol owner,
            int ordinal,
            TypeWithAnnotations parameterType,
            RefKind refKind,
            ImmutableArray<CustomModifier> refCustomModifiers,
            string name,
            ImmutableArray<Location> locations,
            SyntaxReference syntaxRef,
            ConstantValue defaultSyntaxValue,
            bool isParams,
            bool isExtensionMethodThis)
            : base(owner, ordinal, parameterType, refKind, name, locations, syntaxRef, defaultSyntaxValue, isParams, isExtensionMethodThis)
        {
            Debug.Assert(!refCustomModifiers.IsEmpty);

            _refCustomModifiers = refCustomModifiers;

            Debug.Assert(refKind != RefKind.None || _refCustomModifiers.IsEmpty);
        }

        public override ImmutableArray<CustomModifier> RefCustomModifiers => _refCustomModifiers;
    }
}
