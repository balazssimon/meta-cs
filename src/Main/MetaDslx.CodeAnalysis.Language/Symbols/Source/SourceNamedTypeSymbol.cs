// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.CodeAnalysis.CSharp.Emit;
using Microsoft.CodeAnalysis.CSharp.Symbols;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.PooledObjects;
using Roslyn.Utilities;

namespace Microsoft.CodeAnalysis.CSharp.Symbols
{
    // This is a type symbol associated with a type definition in source code.
    // That is, for a generic type C<T> this is the instance type C<T>.  
    internal sealed partial class SourceNamedTypeSymbol : SourceMemberContainerTypeSymbol, IAttributeTargetSymbol
    {
        private ImmutableArray<TypeParameterSymbol> _lazyTypeParameters;

        /// <summary>
        /// A collection of type parameter constraints, populated when
        /// constraints for the first type parameter are requested.
        /// Initialized in two steps. Hold a copy if accessing during initialization.
        /// </summary>
        private ImmutableArray<TypeParameterConstraintClause> _lazyTypeParameterConstraints;

        private CustomAttributesBag<CSharpAttributeData> _lazyCustomAttributesBag;

        private string _lazyDocComment;

        private ThreeState _lazyIsExplicitDefinitionOfNoPiaLocalType = ThreeState.Unknown;

        protected override Location GetCorrespondingBaseListLocation(NamedTypeSymbol @base)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        internal SourceNamedTypeSymbol(NamespaceOrTypeSymbol containingSymbol, MergedTypeDeclaration declaration, DiagnosticBag diagnostics)
            : base(containingSymbol, declaration, diagnostics)
        {
            Debug.Assert(declaration.Kind == DeclarationKind.Struct ||
                         declaration.Kind == DeclarationKind.Interface ||
                         declaration.Kind == DeclarationKind.Enum ||
                         declaration.Kind == DeclarationKind.Delegate ||
                         declaration.Kind == DeclarationKind.Class);

            if (containingSymbol.Kind == SymbolKind.NamedType)
            {
                // Nested types are never unified.
                _lazyIsExplicitDefinitionOfNoPiaLocalType = ThreeState.False;
            }
        }

        #region Syntax

        private static SyntaxToken GetName(CSharpSyntaxNode node)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        public override string GetDocumentationCommentXml(CultureInfo preferredCulture = null, bool expandIncludes = false, CancellationToken cancellationToken = default(CancellationToken))
        {
            return SourceDocumentationCommentUtils.GetAndCacheDocumentationComment(this, expandIncludes, ref _lazyDocComment);
        }

        #endregion

        #region Type Parameters

        private ImmutableArray<TypeParameterSymbol> MakeTypeParameters(DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        /// <summary>
        /// Returns the constraint clause for the given type parameter.
        /// The `early` parameter indicates whether the clauses can be from the first phase of constraint
        /// checking where the constraint types may still contain invalid or duplicate types.
        /// </summary>
        internal TypeParameterConstraintClause GetTypeParameterConstraintClause(bool early, int ordinal)
        {
            var clauses = _lazyTypeParameterConstraints;
            if (clauses.IsDefault)
            {
                // Early step.
                var diagnostics = DiagnosticBag.GetInstance();
                if (ImmutableInterlocked.InterlockedInitialize(ref _lazyTypeParameterConstraints, MakeTypeParameterConstraintsEarly(diagnostics)))
                {
                    this.AddDeclarationDiagnostics(diagnostics);
                }
                diagnostics.Free();
                clauses = _lazyTypeParameterConstraints;
            }

            if (!early && clauses.IsEarly())
            {
                // Late step.
                var diagnostics = DiagnosticBag.GetInstance();
                var constraints = ConstraintsHelper.MakeTypeParameterConstraintsLate(TypeParameters, clauses, diagnostics);
                Debug.Assert(!constraints.IsEarly());
                if (ImmutableInterlocked.InterlockedCompareExchange(ref _lazyTypeParameterConstraints, constraints, clauses) == clauses)
                {
                    this.AddDeclarationDiagnostics(diagnostics);
                }
                diagnostics.Free();
                clauses = _lazyTypeParameterConstraints;
            }

            return (clauses.Length > 0) ? clauses[ordinal] : TypeParameterConstraintClause.Empty;
        }

        private ImmutableArray<TypeParameterConstraintClause> MakeTypeParameterConstraintsEarly(DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        internal sealed override ImmutableArray<TypeWithAnnotations> TypeArgumentsWithAnnotationsNoUseSiteDiagnostics
        {
            get
            {
                return GetTypeParametersAsTypeArguments();
            }
        }

        public override ImmutableArray<TypeParameterSymbol> TypeParameters
        {
            get
            {
                if (_lazyTypeParameters.IsDefault)
                {
                    var diagnostics = DiagnosticBag.GetInstance();
                    if (ImmutableInterlocked.InterlockedInitialize(ref _lazyTypeParameters, MakeTypeParameters(diagnostics)))
                    {
                        AddDeclarationDiagnostics(diagnostics);
                    }

                    diagnostics.Free();
                }

                return _lazyTypeParameters;
            }
        }

        #endregion

        #region Attributes

        internal ImmutableArray<SyntaxList<CSharpSyntaxNode>> GetAttributeDeclarations()
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        IAttributeTargetSymbol IAttributeTargetSymbol.AttributesOwner
        {
            get { return this; }
        }

        AttributeLocation IAttributeTargetSymbol.DefaultAttributeLocation
        {
            get { return AttributeLocation.Type; }
        }

        AttributeLocation IAttributeTargetSymbol.AllowedAttributeLocations
        {
            get
            {
                switch (TypeKind)
                {
                    case TypeKind.Delegate:
                        return AttributeLocation.Type | AttributeLocation.Return;

                    case TypeKind.Enum:
                    case TypeKind.Interface:
                        return AttributeLocation.Type;

                    case TypeKind.Struct:
                    case TypeKind.Class:
                        return AttributeLocation.Type;

                    default:
                        return AttributeLocation.None;
                }
            }
        }

        /// <summary>
        /// Returns a bag of applied custom attributes and data decoded from well-known attributes. Returns null if there are no attributes applied on the symbol.
        /// </summary>
        /// <remarks>
        /// Forces binding and decoding of attributes.
        /// </remarks>
        private CustomAttributesBag<CSharpAttributeData> GetAttributesBag()
        {
            var bag = _lazyCustomAttributesBag;
            if (bag != null && bag.IsSealed)
            {
                return bag;
            }

            if (LoadAndValidateAttributes(OneOrMany.Create(this.GetAttributeDeclarations()), ref _lazyCustomAttributesBag))
            {
                var completed = state.NotePartComplete(CompletionPart.Attributes);
                Debug.Assert(completed);
            }

            Debug.Assert(_lazyCustomAttributesBag.IsSealed);
            return _lazyCustomAttributesBag;
        }

        /// <summary>
        /// Gets the attributes applied on this symbol.
        /// Returns an empty array if there are no attributes.
        /// </summary>
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
        private TypeWellKnownAttributeData GetDecodedWellKnownAttributeData()
        {
            var attributesBag = _lazyCustomAttributesBag;
            if (attributesBag == null || !attributesBag.IsDecodedWellKnownAttributeDataComputed)
            {
                attributesBag = this.GetAttributesBag();
            }

            return (TypeWellKnownAttributeData)attributesBag.DecodedWellKnownAttributeData;
        }

        /// <summary>
        /// Returns data decoded from special early bound well-known attributes applied to the symbol or null if there are no applied attributes.
        /// </summary>
        /// <remarks>
        /// Forces binding and decoding of attributes.
        /// </remarks>
        internal CommonTypeEarlyWellKnownAttributeData GetEarlyDecodedWellKnownAttributeData()
        {
            var attributesBag = _lazyCustomAttributesBag;
            if (attributesBag == null || !attributesBag.IsEarlyDecodedWellKnownAttributeDataComputed)
            {
                attributesBag = this.GetAttributesBag();
            }

            return (CommonTypeEarlyWellKnownAttributeData)attributesBag.EarlyDecodedWellKnownAttributeData;
        }

        internal override CSharpAttributeData EarlyDecodeWellKnownAttribute(ref EarlyDecodeWellKnownAttributeArguments<EarlyWellKnownAttributeBinder, NamedTypeSymbol, CSharpSyntaxNode, AttributeLocation> arguments)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        internal override AttributeUsageInfo GetAttributeUsageInfo()
        {
            Debug.Assert(this.SpecialType == SpecialType.System_Object || this.DeclaringCompilation.IsAttributeType(this));

            CommonTypeEarlyWellKnownAttributeData data = this.GetEarlyDecodedWellKnownAttributeData();
            if (data != null && !data.AttributeUsageInfo.IsNull)
            {
                return data.AttributeUsageInfo;
            }

            return ((object)this.BaseTypeNoUseSiteDiagnostics != null) ? this.BaseTypeNoUseSiteDiagnostics.GetAttributeUsageInfo() : AttributeUsageInfo.Default;
        }

        /// <summary>
        /// Returns data decoded from Obsolete attribute or null if there is no Obsolete attribute.
        /// This property returns ObsoleteAttributeData.Uninitialized if attribute arguments haven't been decoded yet.
        /// </summary>
        internal override ObsoleteAttributeData ObsoleteAttributeData
        {
            get
            {
                var lazyCustomAttributesBag = _lazyCustomAttributesBag;
                if (lazyCustomAttributesBag != null && lazyCustomAttributesBag.IsEarlyDecodedWellKnownAttributeDataComputed)
                {
                    var data = (CommonTypeEarlyWellKnownAttributeData)lazyCustomAttributesBag.EarlyDecodedWellKnownAttributeData;
                    return data != null ? data.ObsoleteAttributeData : null;
                }

                foreach (var decl in this.declaration.Declarations)
                {
                    if (decl.HasAnyAttributes)
                    {
                        return ObsoleteAttributeData.Uninitialized;
                    }
                }

                return null;
            }
        }

        internal sealed override void DecodeWellKnownAttribute(ref DecodeWellKnownAttributeArguments<CSharpSyntaxNode, CSharpAttributeData, AttributeLocation> arguments)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        internal override bool IsExplicitDefinitionOfNoPiaLocalType
        {
            get
            {
                if (_lazyIsExplicitDefinitionOfNoPiaLocalType == ThreeState.Unknown)
                {
                    CheckPresenceOfTypeIdentifierAttribute();

                    if (_lazyIsExplicitDefinitionOfNoPiaLocalType == ThreeState.Unknown)
                    {
                        _lazyIsExplicitDefinitionOfNoPiaLocalType = ThreeState.False;
                    }
                }

                Debug.Assert(_lazyIsExplicitDefinitionOfNoPiaLocalType != ThreeState.Unknown);
                return _lazyIsExplicitDefinitionOfNoPiaLocalType == ThreeState.True;
            }
        }

        private void CheckPresenceOfTypeIdentifierAttribute()
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        internal override bool IsComImport
        {
            get
            {
                CommonTypeEarlyWellKnownAttributeData data = this.GetEarlyDecodedWellKnownAttributeData();
                return data != null && data.HasComImportAttribute;
            }
        }

        internal override NamedTypeSymbol ComImportCoClass
        {
            get
            {
                TypeWellKnownAttributeData data = this.GetDecodedWellKnownAttributeData();
                return data != null ? data.ComImportCoClass : null;
            }
        }

        internal override bool HasSpecialName
        {
            get
            {
                var data = GetDecodedWellKnownAttributeData();
                return data != null && data.HasSpecialNameAttribute;
            }
        }

        internal override bool HasCodeAnalysisEmbeddedAttribute
        {
            get
            {
                var data = GetEarlyDecodedWellKnownAttributeData();
                return data != null && data.HasCodeAnalysisEmbeddedAttribute;
            }
        }

        internal sealed override bool ShouldAddWinRTMembers
        {
            get { return false; }
        }

        internal sealed override bool IsWindowsRuntimeImport
        {
            get
            {
                TypeWellKnownAttributeData data = this.GetDecodedWellKnownAttributeData();
                return data != null && data.HasWindowsRuntimeImportAttribute;
            }
        }

        public sealed override bool IsSerializable
        {
            get
            {
                var data = this.GetDecodedWellKnownAttributeData();
                return data != null && data.HasSerializableAttribute;
            }
        }

        internal override bool IsDirectlyExcludedFromCodeCoverage =>
            GetDecodedWellKnownAttributeData()?.HasExcludeFromCodeCoverageAttribute == true;

        private bool HasInstanceFields()
        {
            var members = this.GetMembersUnordered();
            for (var i = 0; i < members.Length; i++)
            {
                var m = members[i];
                if (!m.IsStatic)
                {
                    switch (m.Kind)
                    {
                        case SymbolKind.Field:
                            return true;

                        case SymbolKind.Event:
                            if (((EventSymbol)m).AssociatedField != null)
                            {
                                return true;
                            }
                            break;
                    }
                }
            }

            return false;
        }

        internal sealed override TypeLayout Layout
        {
            get
            {
                var data = GetDecodedWellKnownAttributeData();
                if (data != null && data.HasStructLayoutAttribute)
                {
                    return data.Layout;
                }

                if (this.TypeKind == TypeKind.Struct)
                {
                    // CLI spec 22.37.16:
                    // "A ValueType shall have a non-zero size - either by defining at least one field, or by providing a non-zero ClassSize"
                    // 
                    // Dev11 compiler sets the value to 1 for structs with no instance fields and no size specified.
                    // It does not change the size value if it was explicitly specified to be 0, nor does it report an error.
                    return new TypeLayout(LayoutKind.Sequential, this.HasInstanceFields() ? 0 : 1, alignment: 0);
                }

                return default(TypeLayout);
            }
        }

        internal bool HasStructLayoutAttribute
        {
            get
            {
                var data = GetDecodedWellKnownAttributeData();
                return data != null && data.HasStructLayoutAttribute;
            }
        }

        internal override CharSet MarshallingCharSet
        {
            get
            {
                var data = GetDecodedWellKnownAttributeData();
                return (data != null && data.HasStructLayoutAttribute) ? data.MarshallingCharSet : DefaultMarshallingCharSet;
            }
        }

        internal sealed override bool HasDeclarativeSecurity
        {
            get
            {
                var data = this.GetDecodedWellKnownAttributeData();
                return data != null && data.HasDeclarativeSecurity;
            }
        }

        internal bool HasSecurityCriticalAttributes
        {
            get
            {
                var data = this.GetDecodedWellKnownAttributeData();
                return data != null && data.HasSecurityCriticalAttributes;
            }
        }

        internal sealed override IEnumerable<Microsoft.Cci.SecurityAttribute> GetSecurityInformation()
        {
            var attributesBag = this.GetAttributesBag();
            var wellKnownData = (TypeWellKnownAttributeData)attributesBag.DecodedWellKnownAttributeData;
            if (wellKnownData != null)
            {
                SecurityWellKnownAttributeData securityData = wellKnownData.SecurityInformation;
                if (securityData != null)
                {
                    return securityData.GetSecurityAttributes(attributesBag.Attributes);
                }
            }

            return null;
        }

        internal override ImmutableArray<string> GetAppliedConditionalSymbols()
        {
            var data = GetEarlyDecodedWellKnownAttributeData();
            return data != null ? data.ConditionalSymbols : ImmutableArray<string>.Empty;
        }

        internal override void PostDecodeWellKnownAttributes(ImmutableArray<CSharpAttributeData> boundAttributes, ImmutableArray<CSharpSyntaxNode> allAttributeSyntaxNodes, DiagnosticBag diagnostics, AttributeLocation symbolPart, WellKnownAttributeData decodedData)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        /// <remarks>
        /// These won't be returned by GetAttributes on source methods, but they
        /// will be returned by GetAttributes on metadata symbols.
        /// </remarks>
        internal override void AddSynthesizedAttributes(PEModuleBuilder moduleBuilder, ref ArrayBuilder<SynthesizedAttributeData> attributes)
        {
            base.AddSynthesizedAttributes(moduleBuilder, ref attributes);

            CSharpCompilation compilation = this.DeclaringCompilation;

            if (this.ContainsExtensionMethods)
            {
                // No need to check if [Extension] attribute was explicitly set since
                // we'll issue CS1112 error in those cases and won't generate IL.
                AddSynthesizedAttribute(ref attributes, compilation.TrySynthesizeAttribute(WellKnownMember.System_Runtime_CompilerServices_ExtensionAttribute__ctor));
            }

            if (this.IsRefLikeType)
            {
                AddSynthesizedAttribute(ref attributes, moduleBuilder.SynthesizeIsByRefLikeAttribute(this));

                var obsoleteData = ObsoleteAttributeData;
                Debug.Assert(obsoleteData != ObsoleteAttributeData.Uninitialized, "getting synthesized attributes before attributes are decoded");

                // If user specified an Obsolete attribute, we cannot emit ours.
                // NB: we do not check the kind of deprecation. 
                //     we will not emit Obsolete even if Deprecated or Experimental was used.
                //     we do not want to get into a scenario where different kinds of deprecation are combined together.
                //
                if (obsoleteData == null && !this.IsRestrictedType(ignoreSpanLikeTypes: true))
                {
                    AddSynthesizedAttribute(ref attributes, compilation.TrySynthesizeAttribute(WellKnownMember.System_ObsoleteAttribute__ctor,
                        ImmutableArray.Create(
                            new TypedConstant(compilation.GetSpecialType(SpecialType.System_String), TypedConstantKind.Primitive, PEModule.ByRefLikeMarker), // message
                            new TypedConstant(compilation.GetSpecialType(SpecialType.System_Boolean), TypedConstantKind.Primitive, true)), // error=true
                        isOptionalUse: true));
                }
            }

            if (this.IsReadOnly)
            {
                AddSynthesizedAttribute(ref attributes, moduleBuilder.SynthesizeIsReadOnlyAttribute(this));
            }

            if (this.Indexers.Any())
            {
                string defaultMemberName = this.Indexers.First().MetadataName; // UNDONE: IndexerNameAttribute
                var defaultMemberNameConstant = new TypedConstant(compilation.GetSpecialType(SpecialType.System_String), TypedConstantKind.Primitive, defaultMemberName);

                AddSynthesizedAttribute(ref attributes, compilation.TrySynthesizeAttribute(
                    WellKnownMember.System_Reflection_DefaultMemberAttribute__ctor,
                    ImmutableArray.Create(defaultMemberNameConstant)));
            }

            NamedTypeSymbol baseType = this.BaseTypeNoUseSiteDiagnostics;
            if ((object)baseType != null)
            {
                if (baseType.ContainsDynamic())
                {
                    AddSynthesizedAttribute(ref attributes, compilation.SynthesizeDynamicAttribute(baseType, customModifiersCount: 0));
                }

                if (baseType.ContainsTupleNames())
                {
                    AddSynthesizedAttribute(ref attributes, compilation.SynthesizeTupleNamesAttribute(baseType));
                }

                if (baseType.NeedsNullableAttribute())
                {
                    AddSynthesizedAttribute(ref attributes, moduleBuilder.SynthesizeNullableAttribute(this, TypeWithAnnotations.Create(baseType)));
                }
            }
        }

        #endregion
    }
}
