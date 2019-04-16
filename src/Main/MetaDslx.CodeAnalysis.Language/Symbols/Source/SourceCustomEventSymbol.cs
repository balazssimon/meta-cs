// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Collections.Immutable;
using System.Diagnostics;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Roslyn.Utilities;

namespace Microsoft.CodeAnalysis.CSharp.Symbols
{
    /// <summary>
    /// This class represents an event declared in source with explicit accessors
    /// (i.e. not a field-like event).
    /// </summary>
    internal sealed class SourceCustomEventSymbol : SourceEventSymbol
    {
        private readonly TypeWithAnnotations _type;
        private readonly string _name;
        private readonly SourceCustomEventAccessorSymbol _addMethod;
        private readonly SourceCustomEventAccessorSymbol _removeMethod;
        private readonly TypeSymbol _explicitInterfaceType;
        private readonly ImmutableArray<EventSymbol> _explicitInterfaceImplementations;

        internal SourceCustomEventSymbol(SourceMemberContainerTypeSymbol containingType, Binder binder, CSharpSyntaxNode syntax, DiagnosticBag diagnostics) :
            base(containingType, syntax, default, isFieldLike: false,
                 interfaceSpecifierSyntaxOpt: syntax,
                 nameTokenSyntax: default, diagnostics: diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        public override TypeWithAnnotations TypeWithAnnotations
        {
            get { return _type; }
        }

        public override string Name
        {
            get { return _name; }
        }

        public override MethodSymbol AddMethod
        {
            get { return _addMethod; }
        }

        public override MethodSymbol RemoveMethod
        {
            get { return _removeMethod; }
        }

        protected override AttributeLocation AllowedAttributeLocations
        {
            get { return AttributeLocation.Event; }
        }

        private CSharpSyntaxNode ExplicitInterfaceSpecifier
        {
            get { throw new System.NotImplementedException("TODO:MetaDslx"); }
        }

        internal override bool IsExplicitInterfaceImplementation
        {
            get { return this.ExplicitInterfaceSpecifier != null; }
        }

        public override ImmutableArray<EventSymbol> ExplicitInterfaceImplementations
        {
            get { return _explicitInterfaceImplementations; }
        }

        internal override void AfterAddingTypeMembersChecks(ConversionsBase conversions, DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

    }
}
