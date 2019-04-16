// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Collections.Immutable;
using System.Diagnostics;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Roslyn.Utilities;

namespace Microsoft.CodeAnalysis.CSharp.Symbols
{
    internal sealed class SourceDestructorSymbol : SourceMemberMethodSymbol
    {
        private TypeWithAnnotations _lazyReturnType;
        private readonly bool _isExpressionBodied;

        internal SourceDestructorSymbol(
            SourceMemberContainerTypeSymbol containingType,
            CSharpSyntaxNode syntax,
            DiagnosticBag diagnostics) :
            base(containingType, syntax.GetReference(), syntax.GetLocation())
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

        public override bool IsVararg
        {
            get { return false; }
        }

        internal override int ParameterCount
        {
            get { return 0; }
        }

        public override ImmutableArray<ParameterSymbol> Parameters
        {
            get { return ImmutableArray<ParameterSymbol>.Empty; }
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

        private DeclarationModifiers MakeModifiers(SyntaxTokenList modifiers, Location location, DiagnosticBag diagnostics, out bool modifierErrors)
        {
            // Check that the set of modifiers is allowed
            const DeclarationModifiers allowedModifiers = DeclarationModifiers.Extern | DeclarationModifiers.Unsafe;
            var mods = ModifierUtils.MakeAndCheckNontypeMemberModifiers(modifiers, DeclarationModifiers.None, allowedModifiers, location, diagnostics, out modifierErrors);

            this.CheckUnsafeModifier(mods, diagnostics);

            mods = (mods & ~DeclarationModifiers.AccessibilityMask) | DeclarationModifiers.Protected; // we mark destructors protected in the symbol table

            return mods;
        }

        public override string Name
        {
            get { return WellKnownMemberNames.DestructorName; }
        }

        internal override bool IsExpressionBodied
        {
            get
            {
                return _isExpressionBodied;
            }
        }

        internal override OneOrMany<SyntaxList<CSharpSyntaxNode>> GetAttributeDeclarations()
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        internal override OneOrMany<SyntaxList<CSharpSyntaxNode>> GetReturnTypeAttributeDeclarations()
        {
            // destructors can't have return type attributes
            return OneOrMany.Create(default(SyntaxList<CSharpSyntaxNode>));
        }

        internal sealed override bool IsMetadataVirtual(bool ignoreInterfaceImplementationChanges = false)
        {
            return true;
        }

        internal override bool IsMetadataFinal
        {
            get
            {
                return false;
            }
        }

        internal sealed override bool IsMetadataNewSlot(bool ignoreInterfaceImplementationChanges = false)
        {
            return (object)this.ContainingType.BaseTypeNoUseSiteDiagnostics == null;
        }

        internal override bool GenerateDebugInfo
        {
            get { return true; }
        }
    }
}
