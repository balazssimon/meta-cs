// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using Microsoft.CodeAnalysis.CSharp.Symbols;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace Microsoft.CodeAnalysis.CSharp.Symbols
{
    internal sealed class SourceUserDefinedConversionSymbol : SourceUserDefinedOperatorSymbolBase
    {
        public static SourceUserDefinedConversionSymbol CreateUserDefinedConversionSymbol(
            SourceMemberContainerTypeSymbol containingType,
            CSharpSyntaxNode syntax,
            DiagnosticBag diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        // NOTE: no need to call WithUnsafeRegionIfNecessary, since the signature
        // is bound lazily using binders from a BinderFactory (which will already include an
        // UnsafeBinder, if necessary).
        private SourceUserDefinedConversionSymbol(
            SourceMemberContainerTypeSymbol containingType,
            string name,
            Location location,
            CSharpSyntaxNode syntax,
            DiagnosticBag diagnostics) :
            base(
                MethodKind.Conversion,
                name,
                containingType,
                location,
                syntax,
                diagnostics)
        {
            throw new System.NotImplementedException("TODO:MetaDslx");
        }

        internal new CSharpSyntaxNode GetSyntax()
        {
            Debug.Assert(syntaxReferenceOpt != null);
            return (CSharpSyntaxNode)syntaxReferenceOpt.GetSyntax();
        }

        protected override CSharpSyntaxNode ParameterListSyntax
        {
            get
            {
                throw new System.NotImplementedException("TODO:MetaDslx");
            }
        }

        protected override CSharpSyntaxNode ReturnTypeSyntax
        {
            get
            {
                throw new System.NotImplementedException("TODO:MetaDslx");
            }
        }

        internal override bool GenerateDebugInfo
        {
            get { return true; }
        }
    }
}
