// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Microsoft.CodeAnalysis.CSharp.Emit;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.PooledObjects;
using Roslyn.Utilities;

namespace Microsoft.CodeAnalysis.CSharp.Symbols
{
    internal sealed class SourcePropertySymbol : PropertySymbol, IAttributeTargetSymbol
    {
        private const string DefaultIndexerName = "Item";

        // TODO (tomat): consider splitting into multiple subclasses/rare data.

        private readonly SourceMemberContainerTypeSymbol _containingType;
        private readonly string _name;
        private readonly SyntaxReference _syntaxRef;
        private readonly Location _location;
        private readonly DeclarationModifiers _modifiers;
        private readonly ImmutableArray<CustomModifier> _refCustomModifiers;
        private readonly SourcePropertyAccessorSymbol _getMethod;
        private readonly SourcePropertyAccessorSymbol _setMethod;
        private readonly SynthesizedBackingFieldSymbol _backingField;
        private readonly TypeSymbol _explicitInterfaceType;
        private readonly ImmutableArray<PropertySymbol> _explicitInterfaceImplementations;
        private readonly bool _isExpressionBodied;
        private readonly bool _isAutoProperty;
        private readonly RefKind _refKind;

        private SymbolCompletionState _state;
        private ImmutableArray<ParameterSymbol> _lazyParameters;
        private TypeWithAnnotations.Builder _lazyType;

        /// <summary>
        /// Set in constructor, might be changed while decoding <see cref="IndexerNameAttribute"/>.
        /// </summary>
        private readonly string _sourceName;

        private string _lazyDocComment;
        private OverriddenOrHiddenMembersResult _lazyOverriddenOrHiddenMembers;
        private SynthesizedSealedPropertyAccessor _lazySynthesizedSealedAccessor;
        private CustomAttributesBag<CSharpAttributeData> _lazyCustomAttributesBag;

        // CONSIDER: if the parameters were computed lazily, ParameterCount could be overridden to fall back on the syntax (as in SourceMemberMethodSymbol).

        private SourcePropertySymbol(
           SourceMemberContainerTypeSymbol containingType,
           Binder bodyBinder,
           CSharpSyntaxNode syntax,
           string name,
           Location location,
           DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        internal bool IsExpressionBodied
        {
            get
            {
                return _isExpressionBodied;
            }
        }

        internal static SourcePropertySymbol Create(SourceMemberContainerTypeSymbol containingType, Binder bodyBinder, CSharpSyntaxNode syntax, DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        public override RefKind RefKind
        {
            get
            {
                return _refKind;
            }
        }

        public override TypeWithAnnotations TypeWithAnnotations
        {
            get
            {
                if (_lazyType.IsDefault)
                {
                    var diagnostics = DiagnosticBag.GetInstance();
                    var binder = this.CreateBinderForTypeAndParameters();
                    var syntax = (CSharpSyntaxNode)_syntaxRef.GetSyntax();
                    var result = this.ComputeType(binder, syntax, diagnostics);
                    if (_lazyType.InterlockedInitialize(result))
                    {
                        this.AddDeclarationDiagnostics(diagnostics);
                    }
                    diagnostics.Free();
                }

                return _lazyType.ToType();
            }
        }

        internal bool HasPointerType
        {
            get
            {
                throw new System.NotImplementedException("TODO:MetaDslx");
            }
        }

        /// <remarks>
        /// To facilitate lookup, all indexer symbols have the same name.
        /// Check the MetadataName property to find the name that will be
        /// emitted (based on IndexerNameAttribute, or the default "Item").
        /// </remarks>
        public override string Name
        {
            get
            {
                return _name;
            }
        }

        public override string MetadataName
        {
            get
            {
                // Explicit implementation names may have spaces if the interface
                // is generic (between the type arguments).
                return _sourceName.Replace(" ", "");
            }
        }

        public override Symbol ContainingSymbol
        {
            get
            {
                return _containingType;
            }
        }

        public override NamedTypeSymbol ContainingType
        {
            get
            {
                return _containingType;
            }
        }

        internal override LexicalSortKey GetLexicalSortKey()
        {
            return new LexicalSortKey(_location, this.DeclaringCompilation);
        }

        public override ImmutableArray<Location> Locations
        {
            get
            {
                return ImmutableArray.Create(_location);
            }
        }

        internal Location Location
        {
            get
            {
                return _location;
            }
        }

        public override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences
        {
            get
            {
                return ImmutableArray.Create(_syntaxRef);
            }
        }

        public override bool IsAbstract
        {
            get { return (_modifiers & DeclarationModifiers.Abstract) != 0; }
        }

        public override bool IsExtern
        {
            get { return (_modifiers & DeclarationModifiers.Extern) != 0; }
        }

        public override bool IsStatic
        {
            get { return (_modifiers & DeclarationModifiers.Static) != 0; }
        }

        internal bool IsFixed
        {
            get { return false; }
        }

        /// <remarks>
        /// Even though it is declared with an IndexerDeclarationSyntax, an explicit
        /// interface implementation is not an indexer because it will not cause the
        /// containing type to be emitted with a DefaultMemberAttribute (and even if
        /// there is another indexer, the name of the explicit implementation won't
        /// match).  This is important for round-tripping.
        /// </remarks>
        public override bool IsIndexer
        {
            get { return (_modifiers & DeclarationModifiers.Indexer) != 0; }
        }

        public override bool IsOverride
        {
            get { return (_modifiers & DeclarationModifiers.Override) != 0; }
        }

        public override bool IsSealed
        {
            get { return (_modifiers & DeclarationModifiers.Sealed) != 0; }
        }

        public override bool IsVirtual
        {
            get { return (_modifiers & DeclarationModifiers.Virtual) != 0; }
        }

        internal bool IsNew
        {
            get { return (_modifiers & DeclarationModifiers.New) != 0; }
        }

        internal bool HasReadOnlyModifier => (_modifiers & DeclarationModifiers.ReadOnly) != 0;

        public override MethodSymbol GetMethod
        {
            get { return _getMethod; }
        }

        public override MethodSymbol SetMethod
        {
            get { return _setMethod; }
        }

        internal override Microsoft.Cci.CallingConvention CallingConvention
        {
            get { return (IsStatic ? 0 : Microsoft.Cci.CallingConvention.HasThis); }
        }

        public override ImmutableArray<ParameterSymbol> Parameters
        {
            get
            {
                if (_lazyParameters.IsDefault)
                {
                    var diagnostics = DiagnosticBag.GetInstance();
                    var binder = this.CreateBinderForTypeAndParameters();
                    var syntax = (CSharpSyntaxNode)_syntaxRef.GetSyntax();
                    var result = this.ComputeParameters(binder, syntax, diagnostics);
                    if (ImmutableInterlocked.InterlockedInitialize(ref _lazyParameters, result))
                    {
                        this.AddDeclarationDiagnostics(diagnostics);
                    }
                    diagnostics.Free();
                }

                return _lazyParameters;
            }
        }

        internal override bool IsExplicitInterfaceImplementation
        {
            get { return this.CSharpSyntaxNode.ExplicitInterfaceSpecifier != null; }
        }

        public override ImmutableArray<PropertySymbol> ExplicitInterfaceImplementations
        {
            get { return _explicitInterfaceImplementations; }
        }

        public override ImmutableArray<CustomModifier> RefCustomModifiers
        {
            get { return _refCustomModifiers; }
        }

        public override Accessibility DeclaredAccessibility
        {
            get
            {
                return ModifierUtils.EffectiveAccessibility(_modifiers);
            }
        }

        internal bool IsAutoProperty
        {
            get { return _isAutoProperty; }
        }

        /// <summary>
        /// Backing field for automatically implemented property, or
        /// for a property with an initializer.
        /// </summary>
        internal SynthesizedBackingFieldSymbol BackingField
        {
            get { return _backingField; }
        }

        internal override bool MustCallMethodsDirectly
        {
            get { return false; }
        }

        internal SyntaxReference SyntaxReference
        {
            get
            {
                return _syntaxRef;
            }
        }

        internal CSharpSyntaxNode CSharpSyntaxNode
        {
            get
            {
                return (CSharpSyntaxNode)_syntaxRef.GetSyntax();
            }
        }

        internal SyntaxTree SyntaxTree
        {
            get
            {
                return _syntaxRef.SyntaxTree;
            }
        }

        internal override void AfterAddingTypeMembersChecks(ConversionsBase conversions, DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }
                
        private static ImmutableArray<ParameterSymbol> MakeParameters(
            Binder binder, SourcePropertySymbol owner, CSharpSyntaxNode parameterSyntaxOpt, DiagnosticBag diagnostics, bool addRefReadOnlyModifier)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        public override string GetDocumentationCommentXml(CultureInfo preferredCulture = null, bool expandIncludes = false, CancellationToken cancellationToken = default(CancellationToken))
        {
            return SourceDocumentationCommentUtils.GetAndCacheDocumentationComment(this, expandIncludes, ref _lazyDocComment);
        }

        internal override OverriddenOrHiddenMembersResult OverriddenOrHiddenMembers
        {
            get
            {
                if (_lazyOverriddenOrHiddenMembers == null)
                {
                    Interlocked.CompareExchange(ref _lazyOverriddenOrHiddenMembers, this.MakeOverriddenOrHiddenMembers(), null);
                }
                return _lazyOverriddenOrHiddenMembers;
            }
        }

        /// <summary>
        /// If this property is sealed, then we have to emit both accessors - regardless of whether
        /// they are present in the source - so that they can be marked final. (i.e. sealed).
        /// </summary>
        internal SynthesizedSealedPropertyAccessor SynthesizedSealedAccessorOpt
        {
            get
            {
                bool hasGetter = (object)_getMethod != null;
                bool hasSetter = (object)_setMethod != null;
                if (!this.IsSealed || (hasGetter && hasSetter))
                {
                    return null;
                }

                // This has to be cached because the CCI layer depends on reference equality.
                // However, there's no point in having more than one field, since we don't
                // expect to have to synthesize more than one accessor.
                if ((object)_lazySynthesizedSealedAccessor == null)
                {
                    Interlocked.CompareExchange(ref _lazySynthesizedSealedAccessor, MakeSynthesizedSealedAccessor(), null);
                }
                return _lazySynthesizedSealedAccessor;
            }
        }

        /// <remarks>
        /// Only non-null for sealed properties without both accessors.
        /// </remarks>
        private SynthesizedSealedPropertyAccessor MakeSynthesizedSealedAccessor()
        {
            Debug.Assert(this.IsSealed && ((object)_getMethod == null || (object)_setMethod == null));

            if ((object)_getMethod != null)
            {
                // need to synthesize setter
                MethodSymbol overriddenAccessor = this.GetOwnOrInheritedSetMethod();
                return (object)overriddenAccessor == null ? null : new SynthesizedSealedPropertyAccessor(this, overriddenAccessor);
            }
            else if ((object)_setMethod != null)
            {
                // need to synthesize getter
                MethodSymbol overriddenAccessor = this.GetOwnOrInheritedGetMethod();
                return (object)overriddenAccessor == null ? null : new SynthesizedSealedPropertyAccessor(this, overriddenAccessor);
            }
            else
            {
                // Arguably, it would be more correct to return an array containing two
                // synthesized accessors, but we're already in an error case, so we'll
                // minimize the cascading error behavior by suppressing synthesis.
                return null;
            }
        }

        #region Attributes

        IAttributeTargetSymbol IAttributeTargetSymbol.AttributesOwner
        {
            get { return this; }
        }

        AttributeLocation IAttributeTargetSymbol.DefaultAttributeLocation
        {
            get { return AttributeLocation.Property; }
        }

        AttributeLocation IAttributeTargetSymbol.AllowedAttributeLocations
        {
            get
            {
                return _isAutoProperty
                    ? AttributeLocation.Property | AttributeLocation.Field
                    : AttributeLocation.Property;
            }
        }

        /// <summary>
        /// Returns a bag of custom attributes applied on the property and data decoded from well-known attributes. Returns null if there are no attributes.
        /// </summary>
        /// <remarks>
        /// Forces binding and decoding of attributes.
        /// </remarks>
        private CustomAttributesBag<CSharpAttributeData> GetAttributesBag()
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        /// <summary>
        /// Gets the attributes applied on this symbol.
        /// Returns an empty array if there are no attributes.
        /// </summary>
        /// <remarks>
        /// NOTE: This method should always be kept as a sealed override.
        /// If you want to override attribute binding logic for a sub-class, then override <see cref="GetAttributesBag"/> method.
        /// </remarks>
        public sealed override ImmutableArray<CSharpAttributeData> GetAttributes()
        {
            return this.GetAttributesBag().Attributes;
        }

        /// <summary>
        /// Returns data decoded from well-known attributes applied to the symbol or null if there are no applied attributes.
        /// </summary>
        /// <remarks>
        /// Forces binding and decoding of attributes.
        /// </remarks>
        private CommonPropertyWellKnownAttributeData GetDecodedWellKnownAttributeData()
        {
            var attributesBag = _lazyCustomAttributesBag;
            if (attributesBag == null || !attributesBag.IsDecodedWellKnownAttributeDataComputed)
            {
                attributesBag = this.GetAttributesBag();
            }

            return (CommonPropertyWellKnownAttributeData)attributesBag.DecodedWellKnownAttributeData;
        }

        /// <summary>
        /// Returns data decoded from special early bound well-known attributes applied to the symbol or null if there are no applied attributes.
        /// </summary>
        /// <remarks>
        /// Forces binding and decoding of attributes.
        /// </remarks>
        internal PropertyEarlyWellKnownAttributeData GetEarlyDecodedWellKnownAttributeData()
        {
            var attributesBag = _lazyCustomAttributesBag;
            if (attributesBag == null || !attributesBag.IsEarlyDecodedWellKnownAttributeDataComputed)
            {
                attributesBag = this.GetAttributesBag();
            }

            return (PropertyEarlyWellKnownAttributeData)attributesBag.EarlyDecodedWellKnownAttributeData;
        }

        internal override void AddSynthesizedAttributes(PEModuleBuilder moduleBuilder, ref ArrayBuilder<SynthesizedAttributeData> attributes)
        {
            base.AddSynthesizedAttributes(moduleBuilder, ref attributes);

            var type = this.TypeWithAnnotations;

            if (type.Type.ContainsDynamic())
            {
                AddSynthesizedAttribute(ref attributes,
                    DeclaringCompilation.SynthesizeDynamicAttribute(type.Type, type.CustomModifiers.Length + RefCustomModifiers.Length, _refKind));
            }

            if (type.Type.ContainsTupleNames())
            {
                AddSynthesizedAttribute(ref attributes,
                    DeclaringCompilation.SynthesizeTupleNamesAttribute(type.Type));
            }

            if (type.NeedsNullableAttribute())
            {
                AddSynthesizedAttribute(ref attributes, moduleBuilder.SynthesizeNullableAttribute(this, type));
            }

            if (this.ReturnsByRefReadonly)
            {
                AddSynthesizedAttribute(ref attributes, moduleBuilder.SynthesizeIsReadOnlyAttribute(this));
            }
        }

        internal sealed override bool IsDirectlyExcludedFromCodeCoverage =>
            GetDecodedWellKnownAttributeData()?.HasExcludeFromCodeCoverageAttribute == true;

        internal override bool HasSpecialName
        {
            get
            {
                var data = GetDecodedWellKnownAttributeData();
                return data != null && data.HasSpecialNameAttribute;
            }
        }

        internal override CSharpAttributeData EarlyDecodeWellKnownAttribute(ref EarlyDecodeWellKnownAttributeArguments<EarlyWellKnownAttributeBinder, NamedTypeSymbol, CSharpSyntaxNode, AttributeLocation> arguments)
        {
            CSharpAttributeData boundAttribute;
            ObsoleteAttributeData obsoleteData;

            if (EarlyDecodeDeprecatedOrExperimentalOrObsoleteAttribute(ref arguments, out boundAttribute, out obsoleteData))
            {
                if (obsoleteData != null)
                {
                    arguments.GetOrCreateData<PropertyEarlyWellKnownAttributeData>().ObsoleteAttributeData = obsoleteData;
                }

                return boundAttribute;
            }

            if (CSharpAttributeData.IsTargetEarlyAttribute(arguments.AttributeType, arguments.AttributeSyntax, AttributeDescription.IndexerNameAttribute))
            {
                bool hasAnyDiagnostics;
                boundAttribute = arguments.Binder.GetAttribute(arguments.AttributeSyntax, arguments.AttributeType, out hasAnyDiagnostics);
                if (!boundAttribute.HasErrors)
                {
                    string indexerName = boundAttribute.CommonConstructorArguments[0].DecodeValue<string>(SpecialType.System_String);
                    if (indexerName != null)
                    {
                        arguments.GetOrCreateData<PropertyEarlyWellKnownAttributeData>().IndexerName = indexerName;
                    }

                    if (!hasAnyDiagnostics)
                    {
                        return boundAttribute;
                    }
                }

                return null;
            }

            return base.EarlyDecodeWellKnownAttribute(ref arguments);
        }

        /// <summary>
        /// Returns data decoded from Obsolete attribute or null if there is no Obsolete attribute.
        /// This property returns ObsoleteAttributeData.Uninitialized if attribute arguments haven't been decoded yet.
        /// </summary>
        internal override ObsoleteAttributeData ObsoleteAttributeData
        {
            get
            {
                if (!_containingType.AnyMemberHasAttributes)
                {
                    return null;
                }

                var lazyCustomAttributesBag = _lazyCustomAttributesBag;
                if (lazyCustomAttributesBag != null && lazyCustomAttributesBag.IsEarlyDecodedWellKnownAttributeDataComputed)
                {
                    return ((PropertyEarlyWellKnownAttributeData)lazyCustomAttributesBag.EarlyDecodedWellKnownAttributeData)?.ObsoleteAttributeData;
                }

                return ObsoleteAttributeData.Uninitialized;
            }
        }

        internal override void DecodeWellKnownAttribute(ref DecodeWellKnownAttributeArguments<CSharpSyntaxNode, CSharpAttributeData, AttributeLocation> arguments)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        internal override void PostDecodeWellKnownAttributes(ImmutableArray<CSharpAttributeData> boundAttributes, ImmutableArray<CSharpSyntaxNode> allAttributeSyntaxNodes, DiagnosticBag diagnostics, AttributeLocation symbolPart, WellKnownAttributeData decodedData)
        {
            Debug.Assert(!boundAttributes.IsDefault);
            Debug.Assert(!allAttributeSyntaxNodes.IsDefault);
            Debug.Assert(boundAttributes.Length == allAttributeSyntaxNodes.Length);
            Debug.Assert(_lazyCustomAttributesBag != null);
            Debug.Assert(_lazyCustomAttributesBag.IsDecodedWellKnownAttributeDataComputed);
            Debug.Assert(symbolPart == AttributeLocation.None);

            base.PostDecodeWellKnownAttributes(boundAttributes, allAttributeSyntaxNodes, diagnostics, symbolPart, decodedData);
        }

        #endregion

        #region Completion

        internal sealed override bool RequiresCompletion
        {
            get { return true; }
        }

        internal sealed override bool HasComplete(CompletionPart part)
        {
            return _state.HasComplete(part);
        }

        internal override void ForceComplete(SourceLocation locationOpt, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        #endregion

        private TypeWithAnnotations ComputeType(Binder binder, CSharpSyntaxNode syntax, DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        private ImmutableArray<ParameterSymbol> ComputeParameters(Binder binder, CSharpSyntaxNode syntax, DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        private Binder CreateBinderForTypeAndParameters()
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }
    }
}
