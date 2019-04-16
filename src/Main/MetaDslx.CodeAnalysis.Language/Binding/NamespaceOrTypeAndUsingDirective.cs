// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using Microsoft.CodeAnalysis.CSharp.Symbols;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Microsoft.CodeAnalysis.CSharp
{
    internal struct NamespaceOrTypeAndUsingDirective
    {
        public readonly NamespaceOrTypeSymbol NamespaceOrType;
        public readonly CSharpSyntaxNode UsingDirective;

        public NamespaceOrTypeAndUsingDirective(NamespaceOrTypeSymbol namespaceOrType, CSharpSyntaxNode usingDirective)
        {
            this.NamespaceOrType = namespaceOrType;
            this.UsingDirective = usingDirective;
        }
    }
}
