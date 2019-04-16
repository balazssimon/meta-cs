// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using Microsoft.CodeAnalysis.CSharp.Emit;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.PooledObjects;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Threading;
using Microsoft.CodeAnalysis.Text;

namespace Microsoft.CodeAnalysis.CSharp.Symbols
{
    internal abstract class SourceMemberFieldSymbol : SourceFieldSymbolWithSyntaxReference
    {
        private readonly DeclarationModifiers _modifiers;

        internal SourceMemberFieldSymbol(
            SourceMemberContainerTypeSymbol containingType,
            DeclarationModifiers modifiers,
            string name,
            SyntaxReference syntax,
            Location location)
            : base(containingType, name, syntax, location)
        {
            _modifiers = modifiers;
        }

        protected sealed override DeclarationModifiers Modifiers
        {
            get
            {
                return _modifiers;
            }
        }

        protected abstract CSharpSyntaxNode TypeSyntax { get; }

        protected abstract SyntaxTokenList ModifiersTokenList { get; }

        protected void TypeChecks(TypeSymbol type, DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        public abstract bool HasInitializer { get; }

        internal override void AddSynthesizedAttributes(PEModuleBuilder moduleBuilder, ref ArrayBuilder<SynthesizedAttributeData> attributes)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        public override Symbol AssociatedSymbol
        {
            get
            {
                return null;
            }
        }

        public override int FixedSize
        {
            get
            {
                Debug.Assert(!this.IsFixedSizeBuffer, "Subclasses representing fixed fields must override");
                state.NotePartComplete(CompletionPart.FixedSize);
                return 0;
            }
        }

        internal static DeclarationModifiers MakeModifiers(NamedTypeSymbol containingType, SyntaxToken firstIdentifier, SyntaxTokenList modifiers, DiagnosticBag diagnostics, out bool modifierErrors)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        internal sealed override void ForceComplete(SourceLocation locationOpt, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        internal override NamedTypeSymbol FixedImplementationType(PEModuleBuilder emitModule)
        {
            Debug.Assert(!this.IsFixedSizeBuffer, "Subclasses representing fixed fields must override");
            return null;
        }
    }

    internal class SourceMemberFieldSymbolFromDeclarator : SourceMemberFieldSymbol
    {
        private readonly bool _hasInitializer;

        private TypeWithAnnotations.Builder _lazyType;

        // Non-zero if the type of the field has been inferred from the type of its initializer expression
        // and the errors of binding the initializer have been or are being reported to compilation diagnostics.
        private int _lazyFieldTypeInferred;

        internal SourceMemberFieldSymbolFromDeclarator(
            SourceMemberContainerTypeSymbol containingType,
            CSharpSyntaxNode declarator,
            DeclarationModifiers modifiers,
            bool modifierErrors,
            DiagnosticBag diagnostics)
            : base(containingType, modifiers, string.Empty, declarator.GetReference(), declarator.GetLocation())
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        protected sealed override CSharpSyntaxNode TypeSyntax
        {
            get
            {
                throw new System.NotImplementedException("TODO:MetaDslx");
            }
        }

        protected sealed override SyntaxTokenList ModifiersTokenList
        {
            get
            {
                throw new System.NotImplementedException("TODO:MetaDslx");
            }
        }

        public sealed override bool HasInitializer
        {
            get { return _hasInitializer; }
        }

        protected CSharpSyntaxNode VariableDeclaratorNode
        {
            get
            {
                return this.SyntaxNode;
            }
        }

        private static CSharpSyntaxNode GetFieldDeclaration(CSharpSyntaxNode declarator)
        {
            return declarator.Parent.Parent;
        }

        protected override SyntaxList<CSharpSyntaxNode> AttributeDeclarationSyntaxList
        {
            get
            {
                throw new System.NotImplementedException("TODO:MetaDslx");
            }
        }

        internal override bool HasPointerType
        {
            get
            {
                if (!_lazyType.IsDefault)
                {
                    Debug.Assert(_lazyType.DefaultType.IsPointerType() ==
                        IsPointerFieldSyntactically());

                    return _lazyType.DefaultType.IsPointerType();
                }

                return IsPointerFieldSyntactically();
            }
        }

        private bool IsPointerFieldSyntactically()
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        internal sealed override TypeWithAnnotations GetFieldType(ConsList<FieldSymbol> fieldsBeingBound)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        internal bool FieldTypeInferred(ConsList<FieldSymbol> fieldsBeingBound)
        {
            if (!ContainingType.IsScriptClass)
            {
                return false;
            }

            GetFieldType(fieldsBeingBound);

            // lazyIsImplicitlyTypedField can only transition from value 0 to 1:
            return _lazyFieldTypeInferred != 0 || Volatile.Read(ref _lazyFieldTypeInferred) != 0;
        }

        protected sealed override ConstantValue MakeConstantValue(HashSet<SourceFieldSymbolWithSyntaxReference> dependencies, bool earlyDecodingWellKnownAttributes, DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        internal override bool IsDefinedInSourceTree(SyntaxTree tree, TextSpan? definedWithinSpan, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (this.SyntaxTree == tree)
            {
                if (!definedWithinSpan.HasValue)
                {
                    return true;
                }

                var fieldDeclaration = GetFieldDeclaration(this.SyntaxNode);
                return fieldDeclaration.SyntaxTree.HasCompilationUnitRoot && fieldDeclaration.Span.IntersectsWith(definedWithinSpan.Value);
            }

            return false;
        }

        internal override void AfterAddingTypeMembersChecks(ConversionsBase conversions, DiagnosticBag diagnostics)
        {
            var options = (CSharpParseOptions)SyntaxTree.Options;
            Type.CheckAllConstraints(DeclaringCompilation, conversions, ErrorLocation, diagnostics);
            base.AfterAddingTypeMembersChecks(conversions, diagnostics);
        }
    }
}
