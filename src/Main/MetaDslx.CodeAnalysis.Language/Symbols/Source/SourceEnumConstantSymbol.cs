// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Threading;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Roslyn.Utilities;

namespace Microsoft.CodeAnalysis.CSharp.Symbols
{
    /// <summary>
    /// Represents a constant field of an enum.
    /// </summary>
    internal abstract class SourceEnumConstantSymbol : SourceFieldSymbolWithSyntaxReference
    {
        public static SourceEnumConstantSymbol CreateExplicitValuedConstant(
            SourceMemberContainerTypeSymbol containingEnum,
            CSharpSyntaxNode syntax,
            DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        public static SourceEnumConstantSymbol CreateImplicitValuedConstant(
            SourceMemberContainerTypeSymbol containingEnum,
            CSharpSyntaxNode syntax,
            SourceEnumConstantSymbol otherConstant,
            int otherConstantOffset,
            DiagnosticBag diagnostics)
        {
            if ((object)otherConstant == null)
            {
                Debug.Assert(otherConstantOffset == 0);
                return new ZeroValuedEnumConstantSymbol(containingEnum, syntax, diagnostics);
            }
            else
            {
                Debug.Assert(otherConstantOffset > 0);
                return new ImplicitValuedEnumConstantSymbol(containingEnum, syntax, otherConstant, (uint)otherConstantOffset, diagnostics);
            }
        }

        protected SourceEnumConstantSymbol(SourceMemberContainerTypeSymbol containingEnum, CSharpSyntaxNode syntax, DiagnosticBag diagnostics)
            : base(containingEnum, null, syntax.GetReference(), syntax.GetLocation())
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        internal override TypeWithAnnotations GetFieldType(ConsList<FieldSymbol> fieldsBeingBound)
        {
            return TypeWithAnnotations.Create(this.ContainingType);
        }

        public override Symbol AssociatedSymbol
        {
            get
            {
                return null;
            }
        }

        protected sealed override DeclarationModifiers Modifiers
        {
            get
            {
                return DeclarationModifiers.Const | DeclarationModifiers.Static | DeclarationModifiers.Public;
            }
        }

        public new CSharpSyntaxNode SyntaxNode
        {
            get
            {
                return (CSharpSyntaxNode)base.SyntaxNode;
            }
        }

        protected override SyntaxList<CSharpSyntaxNode> AttributeDeclarationSyntaxList
        {
            get
            {
                throw new System.NotImplementedException("TODO:MetaDslx");
            }
        }

        internal sealed override void ForceComplete(SourceLocation locationOpt, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        private sealed class ZeroValuedEnumConstantSymbol : SourceEnumConstantSymbol
        {
            public ZeroValuedEnumConstantSymbol(
                SourceMemberContainerTypeSymbol containingEnum,
                CSharpSyntaxNode syntax,
                DiagnosticBag diagnostics)
                : base(containingEnum, syntax, diagnostics)
            {
            }

            protected override ConstantValue MakeConstantValue(HashSet<SourceFieldSymbolWithSyntaxReference> dependencies, bool earlyDecodingWellKnownAttributes, DiagnosticBag diagnostics)
            {
                var constantType = this.ContainingType.EnumUnderlyingType.SpecialType;
                return Microsoft.CodeAnalysis.ConstantValue.Default(constantType);
            }
        }

        private sealed class ExplicitValuedEnumConstantSymbol : SourceEnumConstantSymbol
        {
            private readonly SyntaxReference _equalsValueNodeRef;

            public ExplicitValuedEnumConstantSymbol(
                SourceMemberContainerTypeSymbol containingEnum,
                CSharpSyntaxNode syntax,
                CSharpSyntaxNode initializer,
                DiagnosticBag diagnostics) :
                base(containingEnum, syntax, diagnostics)
            {
                _equalsValueNodeRef = initializer.GetReference();
            }

            protected override ConstantValue MakeConstantValue(HashSet<SourceFieldSymbolWithSyntaxReference> dependencies, bool earlyDecodingWellKnownAttributes, DiagnosticBag diagnostics)
            {
                throw new System.NotImplementedException("TODO:MetaDslx");
            }
        }

        private sealed class ImplicitValuedEnumConstantSymbol : SourceEnumConstantSymbol
        {
            private readonly SourceEnumConstantSymbol _otherConstant;
            private readonly uint _otherConstantOffset;

            public ImplicitValuedEnumConstantSymbol(
                SourceMemberContainerTypeSymbol containingEnum,
                CSharpSyntaxNode syntax,
                SourceEnumConstantSymbol otherConstant,
                uint otherConstantOffset,
                DiagnosticBag diagnostics) :
                base(containingEnum, syntax, diagnostics)
            {
                Debug.Assert((object)otherConstant != null);
                Debug.Assert(otherConstantOffset > 0);

                _otherConstant = otherConstant;
                _otherConstantOffset = otherConstantOffset;
            }

            protected override ConstantValue MakeConstantValue(HashSet<SourceFieldSymbolWithSyntaxReference> dependencies, bool earlyDecodingWellKnownAttributes, DiagnosticBag diagnostics)
            {
                throw new System.NotImplementedException("TODO:MetaDslx");
            }
        }
    }
}
