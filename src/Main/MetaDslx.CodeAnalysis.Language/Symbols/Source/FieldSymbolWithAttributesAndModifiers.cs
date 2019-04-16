// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.CodeAnalysis.CSharp.Emit;
using Microsoft.CodeAnalysis.CSharp.Symbols;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.PooledObjects;
using Roslyn.Utilities;

namespace Microsoft.CodeAnalysis.CSharp.Symbols
{
    internal abstract class FieldSymbolWithAttributesAndModifiers : FieldSymbol, IAttributeTargetSymbol
    {
        private CustomAttributesBag<CSharpAttributeData> _lazyCustomAttributesBag;
        protected SymbolCompletionState state;
        internal abstract Location ErrorLocation { get; }
        protected abstract DeclarationModifiers Modifiers { get; }

        /// <summary>
        /// Gets the syntax list of custom attributes applied on the symbol.
        /// </summary>
        protected abstract SyntaxList<CSharpSyntaxNode> AttributeDeclarationSyntaxList { get; }

        protected abstract IAttributeTargetSymbol AttributeOwner { get; }

        IAttributeTargetSymbol IAttributeTargetSymbol.AttributesOwner
            => this.AttributeOwner;

        AttributeLocation IAttributeTargetSymbol.DefaultAttributeLocation
            => AttributeLocation.Field;

        AttributeLocation IAttributeTargetSymbol.AllowedAttributeLocations
            => AttributeLocation.Field;

        internal sealed override bool HasComplete(CompletionPart part)
            => state.HasComplete(part);

        public sealed override bool IsStatic
            => (Modifiers & DeclarationModifiers.Static) != 0;

        public sealed override bool IsReadOnly
            => (Modifiers & DeclarationModifiers.ReadOnly) != 0;

        public sealed override Accessibility DeclaredAccessibility
            => ModifierUtils.EffectiveAccessibility(Modifiers);

        public sealed override bool IsConst
            => (Modifiers & DeclarationModifiers.Const) != 0;

        public sealed override bool IsVolatile
            => (Modifiers & DeclarationModifiers.Volatile) != 0;

        public sealed override bool IsFixedSizeBuffer
            => (Modifiers & DeclarationModifiers.Fixed) != 0;

        /// <summary>
        /// Gets the attributes applied on this symbol.
        /// Returns an empty array if there are no attributes.
        /// </summary>
        /// <remarks>
        /// NOTE: This method should always be kept as a sealed override.
        /// If you want to override attribute binding logic for a sub-class, then override <see cref="GetAttributesBag"/> method.
        /// </remarks>
        public sealed override ImmutableArray<CSharpAttributeData> GetAttributes()
            => this.GetAttributesBag().Attributes;

        /// <summary>
        /// Returns a bag of applied custom attributes and data decoded from well-known attributes.
        /// Returns an empty bag if there are no attributes applied on the symbol.
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

            if (LoadAndValidateAttributes(OneOrMany.Create(this.AttributeDeclarationSyntaxList), ref _lazyCustomAttributesBag))
            {
                var completed = state.NotePartComplete(CompletionPart.Attributes);
                Debug.Assert(completed);
            }

            Debug.Assert(_lazyCustomAttributesBag.IsSealed);
            return _lazyCustomAttributesBag;
        }

        /// <summary>
        /// Returns data decoded from well-known attributes applied to the symbol or null if there are no applied attributes.
        /// </summary>
        /// <remarks>
        /// Forces binding and decoding of attributes.
        /// </remarks>
        protected CommonFieldWellKnownAttributeData GetDecodedWellKnownAttributeData()
        {
            var attributesBag = _lazyCustomAttributesBag;
            if (attributesBag == null || !attributesBag.IsDecodedWellKnownAttributeDataComputed)
            {
                attributesBag = this.GetAttributesBag();
            }

            return (CommonFieldWellKnownAttributeData)attributesBag.DecodedWellKnownAttributeData;
        }

        internal sealed override CSharpAttributeData EarlyDecodeWellKnownAttribute(ref EarlyDecodeWellKnownAttributeArguments<EarlyWellKnownAttributeBinder, NamedTypeSymbol, CSharpSyntaxNode, AttributeLocation> arguments)
        {
            CSharpAttributeData boundAttribute;
            ObsoleteAttributeData obsoleteData;

            if (EarlyDecodeDeprecatedOrExperimentalOrObsoleteAttribute(ref arguments, out boundAttribute, out obsoleteData))
            {
                if (obsoleteData != null)
                {
                    arguments.GetOrCreateData<CommonFieldEarlyWellKnownAttributeData>().ObsoleteAttributeData = obsoleteData;
                }

                return boundAttribute;
            }

            return base.EarlyDecodeWellKnownAttribute(ref arguments);
        }

        /// <summary>
        /// Returns data decoded from Obsolete attribute or null if there is no Obsolete attribute.
        /// This property returns ObsoleteAttributeData.Uninitialized if attribute arguments haven't been decoded yet.
        /// </summary>
        internal sealed override ObsoleteAttributeData ObsoleteAttributeData
        {
            get
            {
                var containingSourceType = (SourceMemberContainerTypeSymbol)ContainingType;
                if (!containingSourceType.AnyMemberHasAttributes)
                {
                    return null;
                }

                var lazyCustomAttributesBag = _lazyCustomAttributesBag;
                if (lazyCustomAttributesBag != null && lazyCustomAttributesBag.IsEarlyDecodedWellKnownAttributeDataComputed)
                {
                    var data = (CommonFieldEarlyWellKnownAttributeData)lazyCustomAttributesBag.EarlyDecodedWellKnownAttributeData;
                    return data != null ? data.ObsoleteAttributeData : null;
                }

                return ObsoleteAttributeData.Uninitialized;
            }
        }

        internal override void DecodeWellKnownAttribute(ref DecodeWellKnownAttributeArguments<CSharpSyntaxNode, CSharpAttributeData, AttributeLocation> arguments)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        internal sealed override bool HasSpecialName
        {
            get
            {
                if (this.HasRuntimeSpecialName)
                {
                    return true;
                }

                var data = GetDecodedWellKnownAttributeData();
                return data != null && data.HasSpecialNameAttribute;
            }
        }

        internal sealed override bool IsNotSerialized
        {
            get
            {
                var data = GetDecodedWellKnownAttributeData();
                return data != null && data.HasNonSerializedAttribute;
            }
        }

        internal sealed override MarshalPseudoCustomAttributeData MarshallingInformation
        {
            get
            {
                var data = GetDecodedWellKnownAttributeData();
                return data != null ? data.MarshallingInformation : null;
            }
        }

        internal sealed override int? TypeLayoutOffset
        {
            get
            {
                var data = GetDecodedWellKnownAttributeData();
                return data != null ? data.Offset : null;
            }
        }

        internal override void AddSynthesizedAttributes(PEModuleBuilder moduleBuilder, ref ArrayBuilder<SynthesizedAttributeData> attributes)
        {
            base.AddSynthesizedAttributes(moduleBuilder, ref attributes);

            var type = this.TypeWithAnnotations;

            if (type.Type.ContainsDynamic())
            {
                AddSynthesizedAttribute(ref attributes,
                    DeclaringCompilation.SynthesizeDynamicAttribute(type.Type, TypeWithAnnotations.CustomModifiers.Length));
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
        }
    }
}
