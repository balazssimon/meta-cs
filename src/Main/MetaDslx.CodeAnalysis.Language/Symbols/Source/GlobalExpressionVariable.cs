// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Roslyn.Utilities;

namespace Microsoft.CodeAnalysis.CSharp.Symbols
{
    /// <summary>
    /// Represents expression and deconstruction variables declared in a global statement.
    /// </summary>
    internal class GlobalExpressionVariable : SourceMemberFieldSymbol
    {
        private TypeWithAnnotations.Builder _lazyType;

        /// <summary>
        /// The type syntax, if any, from source. Optional for patterns that can omit an explicit type.
        /// </summary>
        private SyntaxReference _typeSyntaxOpt;

        internal GlobalExpressionVariable(
            SourceMemberContainerTypeSymbol containingType,
            DeclarationModifiers modifiers,
            CSharpSyntaxNode typeSyntax,
            string name,
            SyntaxReference syntax,
            Location location)
            : base(containingType, modifiers, name, syntax, location)
        {
            Debug.Assert(DeclaredAccessibility == Accessibility.Private);
            _typeSyntaxOpt = typeSyntax?.GetReference();
        }

        internal static GlobalExpressionVariable Create(
                SourceMemberContainerTypeSymbol containingType,
                DeclarationModifiers modifiers,
                CSharpSyntaxNode typeSyntax,
                string name,
                SyntaxNode syntax,
                Location location,
                FieldSymbol containingFieldOpt,
                SyntaxNode nodeToBind)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }


        protected override SyntaxList<CSharpSyntaxNode> AttributeDeclarationSyntaxList => default;
        protected override CSharpSyntaxNode TypeSyntax => (CSharpSyntaxNode)_typeSyntaxOpt?.GetSyntax();
        protected override SyntaxTokenList ModifiersTokenList => default;
        public override bool HasInitializer => false;
        protected override ConstantValue MakeConstantValue(
            HashSet<SourceFieldSymbolWithSyntaxReference> dependencies,
            bool earlyDecodingWellKnownAttributes,
            DiagnosticBag diagnostics) => null;

        internal override TypeWithAnnotations GetFieldType(ConsList<FieldSymbol> fieldsBeingBound)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        /// <summary>
        /// Can add some diagnostics into <paramref name="diagnostics"/>. 
        /// Returns the type that it actually locks onto (it's possible that it had already locked onto ErrorType).
        /// </summary>
        private TypeWithAnnotations SetType(CSharpCompilation compilation, DiagnosticBag diagnostics, TypeWithAnnotations type)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        /// <summary>
        /// Can add some diagnostics into <paramref name="diagnostics"/>.
        /// Returns the type that it actually locks onto (it's possible that it had already locked onto ErrorType).
        /// </summary>
        internal TypeWithAnnotations SetTypeWithAnnotations(TypeWithAnnotations type, DiagnosticBag diagnostics)
        {
            return SetType(DeclaringCompilation, diagnostics, type);
        }

        protected virtual void InferFieldType(ConsList<FieldSymbol> fieldsBeingBound, Binder binder)
        {
            throw ExceptionUtilities.Unreachable;
        }

        private class InferrableGlobalExpressionVariable : GlobalExpressionVariable
        {
            private readonly FieldSymbol _containingFieldOpt;
            private readonly SyntaxReference _nodeToBind;

            internal InferrableGlobalExpressionVariable(
                SourceMemberContainerTypeSymbol containingType,
                DeclarationModifiers modifiers,
                CSharpSyntaxNode typeSyntax,
                string name,
                SyntaxReference syntax,
                Location location,
                FieldSymbol containingFieldOpt,
                SyntaxNode nodeToBind)
                : base(containingType, modifiers, typeSyntax, name, syntax, location)
            {
                throw new System.NotImplementedException("TODO:MetaDslx");
            }

            protected override void InferFieldType(ConsList<FieldSymbol> fieldsBeingBound, Binder binder)
            {
                throw new System.NotImplementedException("TODO:MetaDslx");
            }
        }
    }
}
