// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading;
using Microsoft.CodeAnalysis.CSharp.Emit;
using Microsoft.CodeAnalysis.CSharp.Symbols;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.PooledObjects;
using Microsoft.CodeAnalysis.Text;
using Roslyn.Utilities;

namespace Microsoft.CodeAnalysis.CSharp.Symbols
{
    internal sealed class SourceOrdinaryMethodSymbol : SourceMemberMethodSymbol
    {
        private readonly ImmutableArray<TypeParameterSymbol> _typeParameters;
        private readonly TypeSymbol _explicitInterfaceType;
        private readonly string _name;
        private readonly bool _isExpressionBodied;
        private readonly bool _hasAnyBody;
        private readonly RefKind _refKind;

        private ImmutableArray<MethodSymbol> _lazyExplicitInterfaceImplementations;
        private ImmutableArray<CustomModifier> _lazyRefCustomModifiers;
        private ImmutableArray<ParameterSymbol> _lazyParameters;
        private TypeWithAnnotations _lazyReturnType;
        private bool _lazyIsVararg;

        /// <summary>
        /// A collection of type parameter constraints, populated when
        /// constraints for the first type parameter is requested.
        /// Initialized in two steps. Hold a copy if accessing during initialization.
        /// </summary>
        private ImmutableArray<TypeParameterConstraintClause> _lazyTypeParameterConstraints;

        /// <summary>
        /// If this symbol represents a partial method definition or implementation part, its other part (if any).
        /// This should be set, if at all, before this symbol appears among the members of its owner.  
        /// The implementation part is not listed among the "members" of the enclosing type.
        /// </summary>
        private SourceOrdinaryMethodSymbol _otherPartOfPartial;

        public static SourceOrdinaryMethodSymbol CreateMethodSymbol(
            NamedTypeSymbol containingType,
            Binder bodyBinder,
            CSharpSyntaxNode syntax,
            DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        private SourceOrdinaryMethodSymbol(
            NamedTypeSymbol containingType,
            TypeSymbol explicitInterfaceType,
            string name,
            Location location,
            CSharpSyntaxNode syntax,
            MethodKind methodKind,
            DiagnosticBag diagnostics) :
            base(containingType,
                 syntax.GetReference(),
                 location)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        public override bool ReturnsVoid
        {
            get
            {
                LazyMethodChecks();
                return base.ReturnsVoid;
            }
        }

        // This is also used for async lambdas.  Probably not the best place to locate this method, but where else could it go?
        internal static void ReportAsyncParameterErrors(ImmutableArray<ParameterSymbol> parameters, DiagnosticBag diagnostics, Location location)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        protected sealed override void LazyAsyncMethodChecks(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        protected override void MethodChecks(DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        internal CSharpSyntaxNode GetSyntax()
        {
            Debug.Assert(syntaxReferenceOpt != null);
            return (CSharpSyntaxNode)syntaxReferenceOpt.GetSyntax();
        }

        public override ImmutableArray<TypeParameterSymbol> TypeParameters
        {
            get { return _typeParameters; }
        }

        public override ImmutableArray<TypeParameterConstraintClause> GetTypeParameterConstraintClauses(bool early)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        public override bool IsVararg
        {
            get
            {
                LazyMethodChecks();
                return _lazyIsVararg;
            }
        }

        public override ImmutableArray<Location> Locations
        {
            get
            {
                return this.locations;
            }
        }

        internal override int ParameterCount
        {
            get
            {
                throw new System.NotImplementedException("TODO:MetaDslx");
            }
        }

        public override ImmutableArray<ParameterSymbol> Parameters
        {
            get
            {
                LazyMethodChecks();
                return _lazyParameters;
            }
        }

        public override RefKind RefKind
        {
            get
            {
                return _refKind;
            }
        }

        public override TypeWithAnnotations ReturnTypeWithAnnotations
        {
            get
            {
                LazyMethodChecks();
                return _lazyReturnType;
            }
        }

        internal static void InitializePartialMethodParts(SourceOrdinaryMethodSymbol definition, SourceOrdinaryMethodSymbol implementation)
        {
            Debug.Assert(definition.IsPartialDefinition);
            Debug.Assert(implementation.IsPartialImplementation);
            Debug.Assert((object)definition._otherPartOfPartial == null);
            Debug.Assert((object)implementation._otherPartOfPartial == null);

            definition._otherPartOfPartial = implementation;
            implementation._otherPartOfPartial = definition;
        }

        /// <summary>
        /// If this is a partial implementation part returns the definition part and vice versa.
        /// </summary>
        internal SourceOrdinaryMethodSymbol OtherPartOfPartial
        {
            get { return _otherPartOfPartial; }
        }

        /// <summary>
        /// Returns true if this symbol represents a partial method definition (the part that specifies a signature but no body).
        /// </summary>
        internal bool IsPartialDefinition
        {
            get
            {
                return this.IsPartial && !_hasAnyBody;
            }
        }

        /// <summary>
        /// Returns true if this symbol represents a partial method implementation (the part that specifies both signature and body).
        /// </summary>
        internal bool IsPartialImplementation
        {
            get
            {
                return this.IsPartial && _hasAnyBody;
            }
        }

        /// <summary>
        /// True if this is a partial method that doesn't have an implementation part.
        /// </summary>
        internal bool IsPartialWithoutImplementation
        {
            get
            {
                return this.IsPartialDefinition && (object)_otherPartOfPartial == null;
            }
        }

        /// <summary>
        /// Returns the implementation part of a partial method definition, 
        /// or null if this is not a partial method or it is the definition part.
        /// </summary>
        internal SourceOrdinaryMethodSymbol SourcePartialDefinition
        {
            get
            {
                return this.IsPartialImplementation ? _otherPartOfPartial : null;
            }
        }

        /// <summary>
        /// Returns the definition part of a partial method implementation, 
        /// or null if this is not a partial method or it is the implementation part.
        /// </summary>
        internal SourceOrdinaryMethodSymbol SourcePartialImplementation
        {
            get
            {
                return this.IsPartialDefinition ? _otherPartOfPartial : null;
            }
        }

        public override MethodSymbol PartialDefinitionPart
        {
            get
            {
                return SourcePartialDefinition;
            }
        }

        public override MethodSymbol PartialImplementationPart
        {
            get
            {
                return SourcePartialImplementation;
            }
        }

        public override string GetDocumentationCommentXml(CultureInfo preferredCulture = null, bool expandIncludes = false, CancellationToken cancellationToken = default(CancellationToken))
        {
            return SourceDocumentationCommentUtils.GetAndCacheDocumentationComment(this.SourcePartialImplementation ?? this, expandIncludes, ref lazyDocComment);
        }

        internal override bool IsExplicitInterfaceImplementation
        {
            get
            {
                throw new System.NotImplementedException("TODO:MetaDslx");
            }
        }

        public override ImmutableArray<MethodSymbol> ExplicitInterfaceImplementations
        {
            get
            {
                LazyMethodChecks();
                return _lazyExplicitInterfaceImplementations;
            }
        }

        public override ImmutableArray<CustomModifier> RefCustomModifiers
        {
            get
            {
                LazyMethodChecks();
                return _lazyRefCustomModifiers;
            }
        }

        public override string Name
        {
            get
            {
                return _name;
            }
        }

        protected override SourceMemberMethodSymbol BoundAttributesSource
        {
            get
            {
                return this.SourcePartialDefinition;
            }
        }

        internal override OneOrMany<SyntaxList<CSharpSyntaxNode>> GetAttributeDeclarations()
        {
            if ((object)this.SourcePartialImplementation != null)
            {
                return OneOrMany.Create(ImmutableArray.Create(AttributeDeclarationSyntaxList, this.SourcePartialImplementation.AttributeDeclarationSyntaxList));
            }
            else
            {
                return OneOrMany.Create(AttributeDeclarationSyntaxList);
            }
        }

        private SyntaxList<CSharpSyntaxNode> AttributeDeclarationSyntaxList
        {
            get
            {
                throw new System.NotImplementedException("TODO:MetaDslx");
            }
        }

        internal override bool IsExpressionBodied
        {
            get { return _isExpressionBodied; }
        }

        internal override void AddSynthesizedAttributes(PEModuleBuilder moduleBuilder, ref ArrayBuilder<SynthesizedAttributeData> attributes)
        {
            base.AddSynthesizedAttributes(moduleBuilder, ref attributes);

            if (this.IsExtensionMethod)
            {
                // No need to check if [Extension] attribute was explicitly set since
                // we'll issue CS1112 error in those cases and won't generate IL.
                var compilation = this.DeclaringCompilation;

                AddSynthesizedAttribute(ref attributes, compilation.TrySynthesizeAttribute(
                    WellKnownMember.System_Runtime_CompilerServices_ExtensionAttribute__ctor));
            }
        }

        internal override void ForceComplete(SourceLocation locationOpt, CancellationToken cancellationToken)
        {
            var implementingPart = this.SourcePartialImplementation;
            if ((object)implementingPart != null)
            {
                implementingPart.ForceComplete(locationOpt, cancellationToken);
            }

            base.ForceComplete(locationOpt, cancellationToken);
        }

        internal override bool IsDefinedInSourceTree(
            SyntaxTree tree,
            TextSpan? definedWithinSpan,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            // Since only the declaring (and not the implementing) part of a partial method appears in the member
            // list, we need to ensure we complete the implementation part when needed.
            return
                base.IsDefinedInSourceTree(tree, definedWithinSpan, cancellationToken) ||
                this.SourcePartialImplementation?.IsDefinedInSourceTree(tree, definedWithinSpan, cancellationToken) == true;
        }

        internal override void AfterAddingTypeMembersChecks(ConversionsBase conversions, DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        internal override bool CallsAreOmitted(SyntaxTree syntaxTree)
        {
            if (this.IsPartialWithoutImplementation)
            {
                return true;
            }

            return base.CallsAreOmitted(syntaxTree);
        }

        internal override bool GenerateDebugInfo => !IsAsync && !IsIterator;
    }
}
