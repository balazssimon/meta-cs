// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Microsoft.CodeAnalysis.CSharp.Symbols;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.PooledObjects;
using Microsoft.CodeAnalysis.Text;
using Roslyn.Utilities;

namespace Microsoft.CodeAnalysis.CSharp
{
    internal partial class Symbol
    {
        /// <summary>
        /// Gets the attributes for this symbol. Returns an empty <see cref="ImmutableArray&lt;AttributeData&gt;"/> if
        /// there are no attributes.
        /// </summary>
        public virtual ImmutableArray<CSharpAttributeData> GetAttributes()
        {
            Debug.Assert(!(this is IAttributeTargetSymbol)); //such types must override

            // Return an empty array by default.
            // Sub-classes that can have custom attributes must
            // override this method
            return ImmutableArray<CSharpAttributeData>.Empty;
        }

        /// <summary>
        /// Gets the attribute target kind corresponding to the symbol kind
        /// If attributes cannot be applied to this symbol kind, returns
        /// an invalid AttributeTargets value of 0
        /// </summary>
        /// <returns>AttributeTargets or 0</returns>
        internal virtual AttributeTargets GetAttributeTarget()
        {
            switch (this.Kind)
            {
                case SymbolKind.Assembly:
                    return AttributeTargets.Assembly;

                case SymbolKind.Field:
                    return AttributeTargets.Field;

                case SymbolKind.Method:
                    var method = (MethodSymbol)this;
                    switch (method.MethodKind)
                    {
                        case MethodKind.Constructor:
                        case MethodKind.StaticConstructor:
                            return AttributeTargets.Constructor;

                        default:
                            return AttributeTargets.Method;
                    }

                case SymbolKind.NamedType:
                    var namedType = (NamedTypeSymbol)this;
                    switch (namedType.TypeKind)
                    {
                        case TypeKind.Class:
                            return AttributeTargets.Class;

                        case TypeKind.Delegate:
                            return AttributeTargets.Delegate;

                        case TypeKind.Enum:
                            return AttributeTargets.Enum;

                        case TypeKind.Interface:
                            return AttributeTargets.Interface;

                        case TypeKind.Struct:
                            return AttributeTargets.Struct;

                        case TypeKind.TypeParameter:
                            return AttributeTargets.GenericParameter;

                        case TypeKind.Submission:
                            // attributes can't be applied on a submission type:
                            throw ExceptionUtilities.UnexpectedValue(namedType.TypeKind);
                    }
                    break;

                case SymbolKind.NetModule:
                    return AttributeTargets.Module;

                case SymbolKind.Parameter:
                    return AttributeTargets.Parameter;

                case SymbolKind.Property:
                    return AttributeTargets.Property;

                case SymbolKind.Event:
                    return AttributeTargets.Event;

                case SymbolKind.TypeParameter:
                    return AttributeTargets.GenericParameter;
            }

            return 0;
        }

        /// <summary>
        /// Method to early decode the type of well-known attribute which can be queried during the BindAttributeType phase.
        /// This method is called first during attribute binding so that any attributes that affect semantics of type binding
        /// can be decoded here.
        /// </summary>
        /// <remarks>
        /// NOTE: If you are early decoding any new well-known attribute, make sure to update PostEarlyDecodeWellKnownAttributeTypes 
        /// to default initialize this data.
        /// </remarks>
        internal virtual void EarlyDecodeWellKnownAttributeType(NamedTypeSymbol attributeType, CSharpSyntaxNode attributeSyntax)
        {
        }

        /// <summary>
        /// This method is called during attribute binding after EarlyDecodeWellKnownAttributeTypes has been executed.
        /// Symbols should default initialize the data for early decoded well-known attributes here.
        /// </summary>
        internal virtual void PostEarlyDecodeWellKnownAttributeTypes()
        {
        }

        /// <summary>
        /// Method to early decode applied well-known attribute which can be queried by the binder.
        /// This method is called during attribute binding after we have bound the attribute types for all attributes,
        /// but haven't yet bound the attribute arguments/attribute constructor.
        /// Early decoding certain well-known attributes enables the binder to use this decoded information on this symbol
        /// when binding the attribute arguments/attribute constructor without causing attribute binding cycle.
        /// </summary>
        internal virtual CSharpAttributeData EarlyDecodeWellKnownAttribute(ref EarlyDecodeWellKnownAttributeArguments<EarlyWellKnownAttributeBinder, NamedTypeSymbol, CSharpSyntaxNode, AttributeLocation> arguments)
        {
            return null;
        }

        internal static bool EarlyDecodeDeprecatedOrExperimentalOrObsoleteAttribute(
            ref EarlyDecodeWellKnownAttributeArguments<EarlyWellKnownAttributeBinder, NamedTypeSymbol, CSharpSyntaxNode, AttributeLocation> arguments,
            out CSharpAttributeData attributeData,
            out ObsoleteAttributeData obsoleteData)
        {
            var type = arguments.AttributeType;
            var syntax = arguments.AttributeSyntax;

            ObsoleteAttributeKind kind;
            if (CSharpAttributeData.IsTargetEarlyAttribute(type, syntax, AttributeDescription.ObsoleteAttribute))
            {
                kind = ObsoleteAttributeKind.Obsolete;
            }
            else if (CSharpAttributeData.IsTargetEarlyAttribute(type, syntax, AttributeDescription.DeprecatedAttribute))
            {
                kind = ObsoleteAttributeKind.Deprecated;
            }
            else if (CSharpAttributeData.IsTargetEarlyAttribute(type, syntax, AttributeDescription.ExperimentalAttribute))
            {
                kind = ObsoleteAttributeKind.Experimental;
            }
            else
            {
                obsoleteData = null;
                attributeData = null;
                return false;
            }

            bool hasAnyDiagnostics;
            attributeData = arguments.Binder.GetAttribute(syntax, type, out hasAnyDiagnostics);
            if (!attributeData.HasErrors)
            {
                obsoleteData = attributeData.DecodeObsoleteAttribute(kind);
                if (hasAnyDiagnostics)
                {
                    attributeData = null;
                }
            }
            else
            {
                obsoleteData = null;
                attributeData = null;
            }
            return true;
        }

        /// <summary>
        /// This method is called by the binder when it is finished binding a set of attributes on the symbol so that
        /// the symbol can extract data from the attribute arguments and potentially perform validation specific to
        /// some well known attributes.
        /// <para>
        /// NOTE: If we are decoding a well-known attribute that could be queried by the binder, consider decoding it during early decoding pass.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// Symbol types should override this if they want to handle a specific well-known attribute.
        /// If the attribute is of a type that the symbol does not wish to handle, it should delegate back to
        /// this (base) method.
        /// </para>
        /// </remarks>
        internal virtual void DecodeWellKnownAttribute(ref DecodeWellKnownAttributeArguments<CSharpSyntaxNode, CSharpAttributeData, AttributeLocation> arguments)
        {
        }

        /// <summary>
        /// Called to report attribute related diagnostics after all attributes have been bound and decoded.
        /// Called even if there are no attributes.
        /// </summary>
        /// <remarks>
        /// This method is called by the binder from <see cref="LoadAndValidateAttributes"/> after it has finished binding attributes on the symbol,
        /// has executed <see cref="DecodeWellKnownAttribute"/> for attributes applied on the symbol and has stored the decoded data in the
        /// lazyCustomAttributesBag on the symbol. Bound attributes haven't been stored on the bag yet.
        /// 
        /// Post-validation for attributes that is dependent on other attributes can be done here.
        /// 
        /// This method should not have any side effects on the symbol, i.e. it SHOULD NOT change the symbol state.
        /// </remarks>
        /// <param name="boundAttributes">Bound attributes.</param>
        /// <param name="allAttributeSyntaxNodes">Syntax nodes of attributes in order they are specified in source, or null if there are no attributes.</param>
        /// <param name="diagnostics">Diagnostic bag.</param>
        /// <param name="symbolPart">Specific part of the symbol to which the attributes apply, or <see cref="AttributeLocation.None"/> if the attributes apply to the symbol itself.</param>
        /// <param name="decodedData">Decoded well-known attribute data, could be null.</param>
        internal virtual void PostDecodeWellKnownAttributes(ImmutableArray<CSharpAttributeData> boundAttributes, ImmutableArray<CSharpSyntaxNode> allAttributeSyntaxNodes, DiagnosticBag diagnostics, AttributeLocation symbolPart, WellKnownAttributeData decodedData)
        {
        }

        /// <summary>
        /// This method does the following set of operations in the specified order:
        /// (1) GetAttributesToBind: Merge attributes from the given attributesSyntaxLists and filter out attributes by attribute target.
        /// (2) BindAttributeTypes: Bind all the attribute types to enable early decode of certain well-known attributes by type.
        /// (3) EarlyDecodeWellKnownAttributes: Perform early decoding of certain well-known attributes that could be queried by the binder in subsequent steps.
        ///     (NOTE: This step has the side effect of updating the symbol state based on the data extracted from well known attributes).
        /// (4) GetAttributes: Bind the attributes (attribute arguments and constructor) using bound attribute types.
        /// (5) DecodeWellKnownAttributes: Decode and validate bound well known attributes.
        ///     (NOTE: This step has the side effect of updating the symbol state based on the data extracted from well known attributes).
        /// (6) StoreBoundAttributesAndDoPostValidation:
        ///     (a) Store the bound attributes in lazyCustomAttributes in a thread safe manner.
        ///     (b) Perform some additional post attribute validations, such as
        ///         1) Duplicate attributes, attribute usage target validation, etc.
        ///         2) Post validation for attributes dependent on other attributes
        ///         These validations cannot be performed prior to step 6(a) as we might need to
        ///         perform a GetAttributes() call on a symbol which can introduce a cycle in attribute binding.
        ///         We avoid this cycle by performing such validations in PostDecodeWellKnownAttributes after lazyCustomAttributes have been set.
        ///     NOTE: PostDecodeWellKnownAttributes SHOULD NOT change the symbol state.
        /// </summary>
        /// <remarks>
        /// Current design of early decoding well-known attributes doesn't permit decoding attribute arguments/constructor as this can lead to binding cycles.
        /// For well-known attributes used by the binder, where we need the decoded arguments, we must handle them specially in one of the following possible ways:
        ///   (a) Avoid decoding the attribute arguments during binding and delay the corresponding binder tasks to a separate post-pass executed after binding.
        ///   (b) As the cycles can be caused only when we are binding attribute arguments/constructor, special case the corresponding binder tasks based on the current BinderFlags.
        /// </remarks>
        /// <param name="attributesSyntaxLists"></param>
        /// <param name="lazyCustomAttributesBag"></param>
        /// <param name="symbolPart">Specific part of the symbol to which the attributes apply, or <see cref="AttributeLocation.None"/> if the attributes apply to the symbol itself.</param>
        /// <param name="earlyDecodingOnly">Indicates that only early decoding should be performed.  WARNING: the resulting bag will not be sealed.</param>
        /// <param name="binderOpt">Binder to use. If null, <see cref="DeclaringCompilation"/> GetBinderFactory will be used.</param>
        /// <param name="attributeMatchesOpt">If specified, only load attributes that match this predicate, and any diagnostics produced will be dropped.</param>
        /// <returns>Flag indicating whether lazyCustomAttributes were stored on this thread. Caller should check for this flag and perform NotePartComplete if true.</returns>
        internal bool LoadAndValidateAttributes(
            OneOrMany<SyntaxList<CSharpSyntaxNode>> attributesSyntaxLists,
            ref CustomAttributesBag<CSharpAttributeData> lazyCustomAttributesBag,
            AttributeLocation symbolPart = AttributeLocation.None,
            bool earlyDecodingOnly = false,
            Binder binderOpt = null,
            Func<CSharpSyntaxNode, bool> attributeMatchesOpt = null)
        {
            var diagnostics = DiagnosticBag.GetInstance();
            var compilation = this.DeclaringCompilation;

            ImmutableArray<Binder> binders;
            ImmutableArray<CSharpSyntaxNode> attributesToBind = this.GetAttributesToBind(attributesSyntaxLists, symbolPart, diagnostics, compilation, attributeMatchesOpt, binderOpt, out binders);
            Debug.Assert(!attributesToBind.IsDefault);

            ImmutableArray<CSharpAttributeData> boundAttributes;
            WellKnownAttributeData wellKnownAttributeData;

            if (attributesToBind.Any())
            {
                Debug.Assert(!binders.IsDefault);
                Debug.Assert(binders.Length == attributesToBind.Length);

                // Initialize the bag so that data decoded from early attributes can be stored onto it.
                if (lazyCustomAttributesBag == null)
                {
                    Interlocked.CompareExchange(ref lazyCustomAttributesBag, new CustomAttributesBag<CSharpAttributeData>(), null);
                }

                // Bind the attribute types and then early decode them.
                int totalAttributesCount = attributesToBind.Length;
                var attributeTypesBuilder = new NamedTypeSymbol[totalAttributesCount];

                Binder.BindAttributeTypes(binders, attributesToBind, this, attributeTypesBuilder, diagnostics);
                ImmutableArray<NamedTypeSymbol> boundAttributeTypes = attributeTypesBuilder.AsImmutableOrNull();

                this.EarlyDecodeWellKnownAttributeTypes(boundAttributeTypes, attributesToBind);
                this.PostEarlyDecodeWellKnownAttributeTypes();

                // Bind the attribute in two stages - early and normal.
                var attributesBuilder = new CSharpAttributeData[totalAttributesCount];

                // Early bind and decode some well-known attributes.
                EarlyWellKnownAttributeData earlyData = this.EarlyDecodeWellKnownAttributes(binders, boundAttributeTypes, attributesToBind, symbolPart, attributesBuilder);
                Debug.Assert(!attributesBuilder.Contains((attr) => attr != null && attr.HasErrors));

                // Store data decoded from early bound well-known attributes.
                // TODO: what if this succeeds on another thread, not ours?
                lazyCustomAttributesBag.SetEarlyDecodedWellKnownAttributeData(earlyData);

                if (earlyDecodingOnly)
                {
                    diagnostics.Free(); //NOTE: dropped.
                    return false;
                }

                // Bind attributes.
                Binder.GetAttributes(binders, attributesToBind, boundAttributeTypes, attributesBuilder, diagnostics);
                boundAttributes = attributesBuilder.AsImmutableOrNull();

                // All attributes must be bound by now.
                Debug.Assert(!boundAttributes.Any((attr) => attr == null));

                // Validate attribute usage and Decode remaining well-known attributes.
                wellKnownAttributeData = this.ValidateAttributeUsageAndDecodeWellKnownAttributes(binders, attributesToBind, boundAttributes, diagnostics, symbolPart);

                // Store data decoded from remaining well-known attributes.
                // TODO: what if this succeeds on another thread but not this thread?
                lazyCustomAttributesBag.SetDecodedWellKnownAttributeData(wellKnownAttributeData);
            }
            else if (earlyDecodingOnly)
            {
                diagnostics.Free(); //NOTE: dropped.
                return false;
            }
            else
            {
                boundAttributes = ImmutableArray<CSharpAttributeData>.Empty;
                wellKnownAttributeData = null;
                Interlocked.CompareExchange(ref lazyCustomAttributesBag, CustomAttributesBag<CSharpAttributeData>.WithEmptyData(), null);
                this.PostEarlyDecodeWellKnownAttributeTypes();
            }

            this.PostDecodeWellKnownAttributes(boundAttributes, attributesToBind, diagnostics, symbolPart, wellKnownAttributeData);

            // Store attributes into the bag.
            bool lazyAttributesStoredOnThisThread = false;
            if (lazyCustomAttributesBag.SetAttributes(boundAttributes))
            {
                if (attributeMatchesOpt is null)
                {
                    this.RecordPresenceOfBadAttributes(boundAttributes);
                    AddDeclarationDiagnostics(diagnostics);
                }
                lazyAttributesStoredOnThisThread = true;
                if (lazyCustomAttributesBag.IsEmpty) lazyCustomAttributesBag = CustomAttributesBag<CSharpAttributeData>.Empty;
            }

            Debug.Assert(lazyCustomAttributesBag.IsSealed);
            diagnostics.Free();
            return lazyAttributesStoredOnThisThread;
        }

        private void RecordPresenceOfBadAttributes(ImmutableArray<CSharpAttributeData> boundAttributes)
        {
            foreach (var attribute in boundAttributes)
            {
                if (attribute.HasErrors)
                {
                    CSharpCompilation compilation = this.DeclaringCompilation;
                    Debug.Assert(compilation != null);
                    ((SourceModuleSymbol)compilation.SourceModule).RecordPresenceOfBadAttributes();
                    break;
                }
            }
        }

        /// <summary>
        /// Method to merge attributes from the given attributesSyntaxLists and filter out attributes by attribute target.
        /// This is the first step in attribute binding.
        /// </summary>
        /// <remarks>
        /// This method can generate diagnostics for few cases where we have an invalid target specifier and the parser hasn't generated the necessary diagnostics.
        /// It should not perform any bind operations as it can lead to an attribute binding cycle.
        /// </remarks>
        private ImmutableArray<CSharpSyntaxNode> GetAttributesToBind(
            OneOrMany<SyntaxList<CSharpSyntaxNode>> attributeDeclarationSyntaxLists,
            AttributeLocation symbolPart,
            DiagnosticBag diagnostics,
            CSharpCompilation compilation,
            Func<CSharpSyntaxNode, bool> attributeMatchesOpt,
            Binder rootBinderOpt,
            out ImmutableArray<Binder> binders)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        /// <summary>
        /// Method to early decode certain well-known attributes which can be queried by the binder.
        /// This method is called during attribute binding after we have bound the attribute types for all attributes,
        /// but haven't yet bound the attribute arguments/attribute constructor.
        /// Early decoding certain well-known attributes enables the binder to use this decoded information on this symbol
        /// when binding the attribute arguments/attribute constructor without causing attribute binding cycle.
        /// </summary>
        internal EarlyWellKnownAttributeData EarlyDecodeWellKnownAttributes(
            ImmutableArray<Binder> binders,
            ImmutableArray<NamedTypeSymbol> boundAttributeTypes,
            ImmutableArray<CSharpSyntaxNode> attributesToBind,
            AttributeLocation symbolPart,
            CSharpAttributeData[] boundAttributesBuilder)
        {
            Debug.Assert(boundAttributeTypes.Any());
            Debug.Assert(attributesToBind.Any());
            Debug.Assert(binders.Any());
            Debug.Assert(boundAttributesBuilder != null);
            Debug.Assert(!boundAttributesBuilder.Contains((attr) => attr != null));

            var earlyBinder = new EarlyWellKnownAttributeBinder(binders[0]);
            var arguments = new EarlyDecodeWellKnownAttributeArguments<EarlyWellKnownAttributeBinder, NamedTypeSymbol, CSharpSyntaxNode, AttributeLocation>();
            arguments.SymbolPart = symbolPart;

            for (int i = 0; i < boundAttributeTypes.Length; i++)
            {
                NamedTypeSymbol boundAttributeType = boundAttributeTypes[i];
                if (!boundAttributeType.IsErrorType())
                {
                    if (binders[i] != earlyBinder.Next)
                    {
                        earlyBinder = new EarlyWellKnownAttributeBinder(binders[i]);
                    }

                    arguments.Binder = earlyBinder;
                    arguments.AttributeType = boundAttributeType;
                    arguments.AttributeSyntax = attributesToBind[i];

                    // Early bind some well-known attributes
                    CSharpAttributeData earlyBoundAttributeOpt = this.EarlyDecodeWellKnownAttribute(ref arguments);
                    Debug.Assert(earlyBoundAttributeOpt == null || !earlyBoundAttributeOpt.HasErrors);

                    boundAttributesBuilder[i] = earlyBoundAttributeOpt;
                }
            }

            return arguments.HasDecodedData ? arguments.DecodedData : null;
        }

        private void EarlyDecodeWellKnownAttributeTypes(ImmutableArray<NamedTypeSymbol> attributeTypes, ImmutableArray<CSharpSyntaxNode> attributeSyntaxList)
        {
            Debug.Assert(attributeSyntaxList.Any());
            Debug.Assert(attributeTypes.Any());

            for (int i = 0; i < attributeTypes.Length; i++)
            {
                var attributeType = attributeTypes[i];

                if (!attributeType.IsErrorType())
                {
                    this.EarlyDecodeWellKnownAttributeType(attributeType, attributeSyntaxList[i]);
                }
            }
        }

        /// <summary>
        /// This method validates attribute usage for each bound attribute and calls <see cref="DecodeWellKnownAttribute"/>
        /// on attributes with valid attribute usage.
        /// This method is called by the binder when it is finished binding a set of attributes on the symbol so that
        /// the symbol can extract data from the attribute arguments and potentially perform validation specific to
        /// some well known attributes.
        /// </summary>
        private WellKnownAttributeData ValidateAttributeUsageAndDecodeWellKnownAttributes(
            ImmutableArray<Binder> binders,
            ImmutableArray<CSharpSyntaxNode> attributeSyntaxList,
            ImmutableArray<CSharpAttributeData> boundAttributes,
            DiagnosticBag diagnostics,
            AttributeLocation symbolPart)
        {
            Debug.Assert(binders.Any());
            Debug.Assert(attributeSyntaxList.Any());
            Debug.Assert(boundAttributes.Any());
            Debug.Assert(binders.Length == boundAttributes.Length);
            Debug.Assert(attributeSyntaxList.Length == boundAttributes.Length);

            int totalAttributesCount = boundAttributes.Length;
            HashSet<NamedTypeSymbol> uniqueAttributeTypes = new HashSet<NamedTypeSymbol>();
            var arguments = new DecodeWellKnownAttributeArguments<CSharpSyntaxNode, CSharpAttributeData, AttributeLocation>();
            arguments.Diagnostics = diagnostics;
            arguments.AttributesCount = totalAttributesCount;
            arguments.SymbolPart = symbolPart;

            for (int i = 0; i < totalAttributesCount; i++)
            {
                CSharpAttributeData boundAttribute = boundAttributes[i];
                CSharpSyntaxNode attributeSyntax = attributeSyntaxList[i];
                Binder binder = binders[i];

                // Decode attribute as a possible well-known attribute only if it has no binding errors and has valid AttributeUsage.
                if (!boundAttribute.HasErrors && ValidateAttributeUsage(boundAttribute, attributeSyntax, binder.Compilation, symbolPart, diagnostics, uniqueAttributeTypes))
                {
                    arguments.Attribute = boundAttribute;
                    arguments.AttributeSyntaxOpt = attributeSyntax;
                    arguments.Index = i;

                    this.DecodeWellKnownAttribute(ref arguments);
                }
            }

            return arguments.HasDecodedData ? arguments.DecodedData : null;
        }

        /// <summary>
        /// Validate attribute usage target and duplicate attributes.
        /// </summary>
        /// <param name="attribute">Bound attribute</param>
        /// <param name="node">Syntax node for attribute specification</param>
        /// <param name="compilation">Compilation</param>
        /// <param name="symbolPart">Symbol part to which the attribute has been applied.</param>
        /// <param name="diagnostics">Diagnostics</param>
        /// <param name="uniqueAttributeTypes">Set of unique attribute types applied to the symbol</param>
        private bool ValidateAttributeUsage(
            CSharpAttributeData attribute,
            CSharpSyntaxNode node,
            CSharpCompilation compilation,
            AttributeLocation symbolPart,
            DiagnosticBag diagnostics,
            HashSet<NamedTypeSymbol> uniqueAttributeTypes)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        /// <summary>
        /// Ensure that attributes are bound and the ObsoleteState of this symbol is known.
        /// </summary>
        internal void ForceCompleteObsoleteAttribute()
        {
            if (this.ObsoleteState == ThreeState.Unknown)
            {
                this.GetAttributes();
            }
            Debug.Assert(this.ObsoleteState != ThreeState.Unknown, "ObsoleteState should be true or false now.");
        }
    }
}
