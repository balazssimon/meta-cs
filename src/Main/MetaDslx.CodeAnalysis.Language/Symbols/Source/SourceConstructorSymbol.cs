// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Collections.Immutable;
using System.Diagnostics;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using Roslyn.Utilities;

namespace Microsoft.CodeAnalysis.CSharp.Symbols
{
    internal sealed class SourceConstructorSymbol : SourceMemberMethodSymbol
    {
        private ImmutableArray<ParameterSymbol> _lazyParameters;
        private TypeWithAnnotations _lazyReturnType;
        private bool _lazyIsVararg;
        private readonly bool _isExpressionBodied;

        public static SourceConstructorSymbol CreateConstructorSymbol(
            SourceMemberContainerTypeSymbol containingType,
            CSharpSyntaxNode syntax,
            DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        private SourceConstructorSymbol(
            SourceMemberContainerTypeSymbol containingType,
            Location location,
            CSharpSyntaxNode syntax,
            MethodKind methodKind,
            DiagnosticBag diagnostics) :
            base(containingType, syntax.GetReference(), ImmutableArray.Create(location))
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        protected override void MethodChecks(DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        internal override void AfterAddingTypeMembersChecks(ConversionsBase conversions, DiagnosticBag diagnostics)
        {
            base.AfterAddingTypeMembersChecks(conversions, diagnostics);

            ParameterHelpers.EnsureIsReadOnlyAttributeExists(Parameters, diagnostics, modifyCompilation: true);
            ParameterHelpers.EnsureNullableAttributeExists(Parameters, diagnostics, modifyCompilation: true);

            foreach (var parameter in this.Parameters)
            {
                parameter.Type.CheckAllConstraints(DeclaringCompilation, conversions, parameter.Locations[0], diagnostics);
            }
        }

        internal CSharpSyntaxNode GetSyntax()
        {
            Debug.Assert(syntaxReferenceOpt != null);
            return (CSharpSyntaxNode)syntaxReferenceOpt.GetSyntax();
        }

        public override bool IsVararg
        {
            get
            {
                LazyMethodChecks();
                return _lazyIsVararg;
            }
        }

        public override bool IsImplicitlyDeclared
        {
            get
            {
                return base.IsImplicitlyDeclared;
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

        public override ImmutableArray<TypeParameterSymbol> TypeParameters
        {
            get { return ImmutableArray<TypeParameterSymbol>.Empty; }
        }

        public override ImmutableArray<TypeParameterConstraintClause> GetTypeParameterConstraintClauses(bool early)
            => ImmutableArray<TypeParameterConstraintClause>.Empty;

        public override RefKind RefKind
        {
            get { return RefKind.None; }
        }

        public override TypeWithAnnotations ReturnTypeWithAnnotations
        {
            get
            {
                LazyMethodChecks();
                return _lazyReturnType;
            }
        }

        public override string Name
        {
            get { return this.IsStatic ? WellKnownMemberNames.StaticConstructorName : WellKnownMemberNames.InstanceConstructorName; }
        }

        internal override OneOrMany<SyntaxList<CSharpSyntaxNode>> GetAttributeDeclarations()
        {
            return OneOrMany.Create(((CSharpSyntaxNode)this.SyntaxNode).AttributeLists);
        }

        internal override OneOrMany<SyntaxList<CSharpSyntaxNode>> GetReturnTypeAttributeDeclarations()
        {
            // constructors can't have return type attributes
            return OneOrMany.Create(default(SyntaxList<CSharpSyntaxNode>));
        }

        protected override IAttributeTargetSymbol AttributeOwner
        {
            get
            {
                return base.AttributeOwner;
            }
        }

        internal override bool IsExpressionBodied
        {
            get
            {
                return _isExpressionBodied;
            }
        }

        internal override bool GenerateDebugInfo
        {
            get { return true; }
        }

        internal override int CalculateLocalSyntaxOffset(int position, SyntaxTree tree)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }
    }
}
