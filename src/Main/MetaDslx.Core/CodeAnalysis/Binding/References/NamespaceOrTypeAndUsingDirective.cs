// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using Microsoft.CodeAnalysis;

namespace MetaDslx.CodeAnalysis.Binding
{
    internal struct NamespaceOrTypeAndUsingDirective
    {
        public readonly INamespaceOrTypeSymbol NamespaceOrType;
        public readonly SyntaxNode UsingDirective;

        public NamespaceOrTypeAndUsingDirective(INamespaceOrTypeSymbol namespaceOrType, SyntaxNode usingDirective)
        {
            this.NamespaceOrType = namespaceOrType;
            this.UsingDirective = usingDirective;
        }
    }
}
