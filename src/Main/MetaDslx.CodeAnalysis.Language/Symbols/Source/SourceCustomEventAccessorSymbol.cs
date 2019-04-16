// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp.Symbols;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Roslyn.Utilities;

namespace Microsoft.CodeAnalysis.CSharp.Symbols
{
    /// <summary>
    /// This class represents an event accessor declared in source 
    /// (i.e. not one synthesized for a field-like event).
    /// </summary>
    /// <remarks>
    /// The accessors are associated with <see cref="SourceCustomEventSymbol"/>.
    /// </remarks>
    internal sealed class SourceCustomEventAccessorSymbol : SourceEventAccessorSymbol
    {
        private readonly ImmutableArray<MethodSymbol> _explicitInterfaceImplementations;
        private readonly string _name;

        internal SourceCustomEventAccessorSymbol(
            SourceEventSymbol @event,
            CSharpSyntaxNode syntax,
            EventSymbol explicitlyImplementedEventOpt,
            string aliasQualifierOpt,
            DiagnosticBag diagnostics)
            : base(@event,
                   syntax.GetReference(),
                   ImmutableArray.Create(syntax.GetLocation()))
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        internal CSharpSyntaxNode GetSyntax()
        {
            Debug.Assert(syntaxReferenceOpt != null);
            return (CSharpSyntaxNode)syntaxReferenceOpt.GetSyntax();
        }

        public override Accessibility DeclaredAccessibility
        {
            get
            {
                return this.AssociatedSymbol.DeclaredAccessibility;
            }
        }

        public override ImmutableArray<MethodSymbol> ExplicitInterfaceImplementations
        {
            get { return _explicitInterfaceImplementations; }
        }

        internal override OneOrMany<SyntaxList<CSharpSyntaxNode>> GetAttributeDeclarations()
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        public override string Name
        {
            get { return _name; }
        }

        public override bool IsImplicitlyDeclared
        {
            get { return false; }
        }

        internal override bool GenerateDebugInfo
        {
            get { return true; }
        }

        internal override bool IsExpressionBodied
        {
            get
            {
                throw new System.NotImplementedException("TODO:MetaDslx");
            }
        }
    }
}
