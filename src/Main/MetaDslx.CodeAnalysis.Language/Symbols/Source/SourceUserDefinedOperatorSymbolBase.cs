// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Collections.Immutable;
using System.Diagnostics;
using Microsoft.CodeAnalysis.CSharp.Symbols;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using Roslyn.Utilities;
using System.Collections.Generic;
using System;

namespace Microsoft.CodeAnalysis.CSharp.Symbols
{
    internal abstract class SourceUserDefinedOperatorSymbolBase : SourceMemberMethodSymbol
    {
        private readonly string _name;
        private readonly bool _isExpressionBodied;
        private ImmutableArray<ParameterSymbol> _lazyParameters;
        private TypeWithAnnotations _lazyReturnType;

        protected SourceUserDefinedOperatorSymbolBase(
            MethodKind methodKind,
            string name,
            SourceMemberContainerTypeSymbol containingType,
            Location location,
            CSharpSyntaxNode syntax,
            DiagnosticBag diagnostics) :
            base(containingType, syntax.GetReference(), location)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        internal CSharpSyntaxNode GetSyntax()
        {
            Debug.Assert(syntaxReferenceOpt != null);
            return (CSharpSyntaxNode)syntaxReferenceOpt.GetSyntax();
        }

        abstract protected CSharpSyntaxNode ParameterListSyntax { get; }
        abstract protected CSharpSyntaxNode ReturnTypeSyntax { get; }

        protected override void MethodChecks(DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        public sealed override string Name
        {
            get
            {
                return _name;
            }
        }

        public sealed override bool ReturnsVoid
        {
            get
            {
                LazyMethodChecks();
                return base.ReturnsVoid;
            }
        }

        public sealed override bool IsVararg
        {
            get
            {
                return false;
            }
        }

        public sealed override bool IsExtensionMethod
        {
            get
            {
                return false;
            }
        }

        public sealed override ImmutableArray<Location> Locations
        {
            get
            {
                return this.locations;
            }
        }

        internal sealed override int ParameterCount
        {
            get
            {
                throw new System.NotImplementedException("TODO:MetaDslx");
            }
        }

        public sealed override ImmutableArray<ParameterSymbol> Parameters
        {
            get
            {
                LazyMethodChecks();
                return _lazyParameters;
            }
        }

        public sealed override ImmutableArray<TypeParameterSymbol> TypeParameters
        {
            get { return ImmutableArray<TypeParameterSymbol>.Empty; }
        }

        public sealed override ImmutableArray<TypeParameterConstraintClause> GetTypeParameterConstraintClauses(bool early)
            => ImmutableArray<TypeParameterConstraintClause>.Empty;

        public override RefKind RefKind
        {
            get { return RefKind.None; }
        }

        public sealed override TypeWithAnnotations ReturnTypeWithAnnotations
        {
            get
            {
                LazyMethodChecks();
                return _lazyReturnType;
            }
        }

        internal override bool IsExpressionBodied
        {
            get { return _isExpressionBodied; }
        }

        internal sealed override OneOrMany<SyntaxList<CSharpSyntaxNode>> GetAttributeDeclarations()
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        internal sealed override void AfterAddingTypeMembersChecks(ConversionsBase conversions, DiagnosticBag diagnostics)
        {
            // Check constraints on return type and parameters. Note: Dev10 uses the
            // method name location for any such errors. We'll do the same for return
            // type errors but for parameter errors, we'll use the parameter location.

            this.ReturnType.CheckAllConstraints(DeclaringCompilation, conversions, this.Locations[0], diagnostics);

            foreach (var parameter in this.Parameters)
            {
                parameter.Type.CheckAllConstraints(DeclaringCompilation, conversions, parameter.Locations[0], diagnostics);
            }

            ParameterHelpers.EnsureIsReadOnlyAttributeExists(Parameters, diagnostics, modifyCompilation: true);

            var location = ReturnTypeSyntax.Location;
            if (ReturnTypeWithAnnotations.NeedsNullableAttribute())
            {
                this.DeclaringCompilation.EnsureNullableAttributeExists(diagnostics, location, modifyCompilation: true);
            }

            ParameterHelpers.EnsureNullableAttributeExists(Parameters, diagnostics, modifyCompilation: true);
        }
    }
}
