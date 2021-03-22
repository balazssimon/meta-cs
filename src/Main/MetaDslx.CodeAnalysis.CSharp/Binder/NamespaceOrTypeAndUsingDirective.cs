// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MetaDslx.CodeAnalysis.CSharp.Symbols;
using MetaDslx.CodeAnalysis.CSharp.Syntax;

namespace MetaDslx.CodeAnalysis.CSharp
{
    internal struct NamespaceOrTypeAndUsingDirective
    {
        public readonly NamespaceOrTypeSymbol NamespaceOrType;
        public readonly UsingDirectiveSyntax UsingDirective;

        public NamespaceOrTypeAndUsingDirective(NamespaceOrTypeSymbol namespaceOrType, UsingDirectiveSyntax usingDirective)
        {
            this.NamespaceOrType = namespaceOrType;
            this.UsingDirective = usingDirective;
        }
    }
}
