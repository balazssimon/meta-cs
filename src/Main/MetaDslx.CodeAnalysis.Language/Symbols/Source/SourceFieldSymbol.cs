﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.PooledObjects;

namespace Microsoft.CodeAnalysis.CSharp.Symbols
{
    internal abstract class SourceFieldSymbol : FieldSymbolWithAttributesAndModifiers
    {
        protected readonly SourceMemberContainerTypeSymbol containingType;

        protected SourceFieldSymbol(SourceMemberContainerTypeSymbol containingType)
        {
            Debug.Assert((object)containingType != null);

            this.containingType = containingType;
        }

        public abstract override string Name { get; }

        protected override IAttributeTargetSymbol AttributeOwner
        {
            get { return this; }
        }

        internal sealed override bool RequiresCompletion
        {
            get { return true; }
        }

        internal bool IsNew
        {
            get
            {
                return (Modifiers & DeclarationModifiers.New) != 0;
            }
        }

        protected void CheckAccessibility(DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        protected void ReportModifiersDiagnostics(DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        protected ImmutableArray<CustomModifier> RequiredCustomModifiers
        {
            get
            {
                if (!IsVolatile)
                {
                    return ImmutableArray<CustomModifier>.Empty;
                }
                else
                {
                    return ImmutableArray.Create<CustomModifier>(
                            CSharpCustomModifier.CreateRequired(this.ContainingAssembly.GetSpecialType(SpecialType.System_Runtime_CompilerServices_IsVolatile)));
                }
            }
        }

        public sealed override Symbol ContainingSymbol
        {
            get
            {
                return containingType;
            }
        }

        public override NamedTypeSymbol ContainingType
        {
            get
            {
                return this.containingType;
            }
        }

        internal sealed override void DecodeWellKnownAttribute(ref DecodeWellKnownAttributeArguments<CSharpSyntaxNode, CSharpAttributeData, AttributeLocation> arguments)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        internal override void AfterAddingTypeMembersChecks(ConversionsBase conversions, DiagnosticBag diagnostics)
        {
            var location = ErrorLocation;
            if (this.TypeWithAnnotations.NeedsNullableAttribute())
            {
                DeclaringCompilation.EnsureNullableAttributeExists(diagnostics, location, modifyCompilation: true);
            }
        }

        internal sealed override bool HasRuntimeSpecialName
        {
            get
            {
                return this.Name == WellKnownMemberNames.EnumBackingFieldName;
            }
        }
    }

    internal abstract class SourceFieldSymbolWithSyntaxReference : SourceFieldSymbol
    {
        private readonly string _name;
        private readonly Location _location;
        private readonly SyntaxReference _syntaxReference;

        private string _lazyDocComment;
        private ConstantValue _lazyConstantEarlyDecodingValue = Microsoft.CodeAnalysis.ConstantValue.Unset;
        private ConstantValue _lazyConstantValue = Microsoft.CodeAnalysis.ConstantValue.Unset;


        protected SourceFieldSymbolWithSyntaxReference(SourceMemberContainerTypeSymbol containingType, string name, SyntaxReference syntax, Location location)
            : base(containingType)
        {
            Debug.Assert(name != null);
            Debug.Assert(syntax != null);
            Debug.Assert(location != null);

            _name = name;
            _syntaxReference = syntax;
            _location = location;
        }

        public SyntaxTree SyntaxTree
        {
            get
            {
                return _syntaxReference.SyntaxTree;
            }
        }

        public CSharpSyntaxNode SyntaxNode
        {
            get
            {
                return (CSharpSyntaxNode)_syntaxReference.GetSyntax();
            }
        }

        public sealed override string Name
        {
            get
            {
                return _name;
            }
        }

        internal override LexicalSortKey GetLexicalSortKey()
        {
            return new LexicalSortKey(_location, this.DeclaringCompilation);
        }

        public sealed override ImmutableArray<Location> Locations
        {
            get
            {
                return ImmutableArray.Create(_location);
            }
        }

        internal sealed override Location ErrorLocation
        {
            get
            {
                return _location;
            }
        }

        public sealed override ImmutableArray<SyntaxReference> DeclaringSyntaxReferences
        {
            get
            {
                return ImmutableArray.Create<SyntaxReference>(_syntaxReference);
            }
        }

        public sealed override string GetDocumentationCommentXml(CultureInfo preferredCulture = null, bool expandIncludes = false, CancellationToken cancellationToken = default(CancellationToken))
        {
            return SourceDocumentationCommentUtils.GetAndCacheDocumentationComment(this, expandIncludes, ref _lazyDocComment);
        }

        internal sealed override ConstantValue GetConstantValue(ConstantFieldsInProgress inProgress, bool earlyDecodingWellKnownAttributes)
        {
            var value = this.GetLazyConstantValue(earlyDecodingWellKnownAttributes);
            if (value != Microsoft.CodeAnalysis.ConstantValue.Unset)
            {
                return value;
            }

            if (!inProgress.IsEmpty)
            {
                // Add this field as a dependency of the original field, and
                // return Unset. The outer GetConstantValue caller will call
                // this method again after evaluating any dependencies.
                inProgress.AddDependency(this);
                return Microsoft.CodeAnalysis.ConstantValue.Unset;
            }

            // Order dependencies.
            var order = ArrayBuilder<ConstantEvaluationHelpers.FieldInfo>.GetInstance();
            this.OrderAllDependencies(order, earlyDecodingWellKnownAttributes);

            // Evaluate fields in order.
            foreach (var info in order)
            {
                // Bind the field value regardless of whether the field represents
                // the start of a cycle. In the cycle case, there will be unevaluated
                // dependencies and the result will be ConstantValue.Bad plus cycle error.
                var field = info.Field;
                field.BindConstantValueIfNecessary(earlyDecodingWellKnownAttributes, startsCycle: info.StartsCycle);
            }

            order.Free();

            // Return the value of this field.
            return this.GetLazyConstantValue(earlyDecodingWellKnownAttributes);
        }

        /// <summary>
        /// Return the constant value dependencies. Compute the dependencies
        /// if necessary by evaluating the constant value but only persist the
        /// constant value if there were no dependencies. (If there are dependencies,
        /// the constant value will be re-evaluated after evaluating dependencies.)
        /// </summary>
        internal ImmutableHashSet<SourceFieldSymbolWithSyntaxReference> GetConstantValueDependencies(bool earlyDecodingWellKnownAttributes)
        {
            var value = this.GetLazyConstantValue(earlyDecodingWellKnownAttributes);
            if (value != Microsoft.CodeAnalysis.ConstantValue.Unset)
            {
                // Constant value already determined. No need to
                // compute dependencies since the constant values
                // of all dependencies should be evaluated as well.
                return ImmutableHashSet<SourceFieldSymbolWithSyntaxReference>.Empty;
            }

            ImmutableHashSet<SourceFieldSymbolWithSyntaxReference> dependencies;
            var builder = PooledHashSet<SourceFieldSymbolWithSyntaxReference>.GetInstance();
            var diagnostics = DiagnosticBag.GetInstance();
            value = MakeConstantValue(builder, earlyDecodingWellKnownAttributes, diagnostics);

            // Only persist if there are no dependencies and the calculation
            // completed successfully. (We could probably persist in other
            // scenarios but it's probably not worth the added complexity.)
            if ((builder.Count == 0) &&
                (value != null) &&
                !value.IsBad &&
                (value != Microsoft.CodeAnalysis.ConstantValue.Unset) &&
                !diagnostics.HasAnyResolvedErrors())
            {
                this.SetLazyConstantValue(
                    value,
                    earlyDecodingWellKnownAttributes,
                    diagnostics,
                    startsCycle: false);
                dependencies = ImmutableHashSet<SourceFieldSymbolWithSyntaxReference>.Empty;
            }
            else
            {
                dependencies = ImmutableHashSet<SourceFieldSymbolWithSyntaxReference>.Empty.Union(builder);
            }

            diagnostics.Free();
            builder.Free();
            return dependencies;
        }

        private void BindConstantValueIfNecessary(bool earlyDecodingWellKnownAttributes, bool startsCycle)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        private ConstantValue GetLazyConstantValue(bool earlyDecodingWellKnownAttributes)
        {
            return earlyDecodingWellKnownAttributes ? _lazyConstantEarlyDecodingValue : _lazyConstantValue;
        }

        private void SetLazyConstantValue(
            ConstantValue value,
            bool earlyDecodingWellKnownAttributes,
            DiagnosticBag diagnostics,
            bool startsCycle)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        protected abstract ConstantValue MakeConstantValue(HashSet<SourceFieldSymbolWithSyntaxReference> dependencies, bool earlyDecodingWellKnownAttributes, DiagnosticBag diagnostics);
    }
}
