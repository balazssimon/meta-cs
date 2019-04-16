// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Collections.Immutable;
using System.Diagnostics;
using System.Threading;
using Microsoft.CodeAnalysis.CSharp.Symbols;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace Microsoft.CodeAnalysis.CSharp.Symbols
{
    /// <summary>
    /// This class represents an event declared in source without explicit accessors.
    /// It implicitly has thread safe accessors and an associated field (of the same
    /// name), unless it does not have an initializer and is either extern or inside
    /// an interface, in which case it only has accessors.
    /// </summary>
    internal sealed class SourceFieldLikeEventSymbol : SourceEventSymbol
    {
        private readonly string _name;
        private readonly TypeWithAnnotations _type;
        private readonly SourceEventFieldSymbol _associatedField;
        private readonly SynthesizedFieldLikeEventAccessorSymbol _addMethod;
        private readonly SynthesizedFieldLikeEventAccessorSymbol _removeMethod;

        internal SourceFieldLikeEventSymbol(SourceMemberContainerTypeSymbol containingType, Binder binder, SyntaxTokenList modifiers, CSharpSyntaxNode declaratorSyntax, DiagnosticBag diagnostics)
            : base(containingType, declaratorSyntax, modifiers, isFieldLike: true, interfaceSpecifierSyntaxOpt: null,
                   nameTokenSyntax: declaratorSyntax.Identifier, diagnostics: diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        /// <summary>
        /// Backing field for field-like event. Will be null if the event
        /// has no initializer and is either extern or inside an interface.
        /// </summary>
        internal override FieldSymbol AssociatedField
        {
            get { return _associatedField; }
        }

        public override string Name
        {
            get { return _name; }
        }

        public override TypeWithAnnotations TypeWithAnnotations
        {
            get { return _type; }
        }

        public override MethodSymbol AddMethod
        {
            get { return _addMethod; }
        }

        public override MethodSymbol RemoveMethod
        {
            get { return _removeMethod; }
        }

        internal override bool IsExplicitInterfaceImplementation
        {
            get { return false; }
        }

        protected override AttributeLocation AllowedAttributeLocations
        {
            get
            {
                return (object)_associatedField != null ?
                    AttributeLocation.Event | AttributeLocation.Method | AttributeLocation.Field :
                    AttributeLocation.Event | AttributeLocation.Method;
            }
        }

        public override ImmutableArray<EventSymbol> ExplicitInterfaceImplementations
        {
            get { return ImmutableArray<EventSymbol>.Empty; }
        }

        private SourceEventFieldSymbol MakeAssociatedField(CSharpSyntaxNode declaratorSyntax)
        {
            DiagnosticBag discardedDiagnostics = DiagnosticBag.GetInstance();
            var field = new SourceEventFieldSymbol(this, declaratorSyntax, discardedDiagnostics);
            discardedDiagnostics.Free();

            Debug.Assert(field.Name == _name);
            return field;
        }

        internal override void ForceComplete(SourceLocation locationOpt, CancellationToken cancellationToken)
        {
            if ((object)this.AssociatedField != null)
            {
                this.AssociatedField.ForceComplete(locationOpt, cancellationToken);
            }

            base.ForceComplete(locationOpt, cancellationToken);
        }
    }
}
