// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using Microsoft.CodeAnalysis;

namespace MetaDslx.CodeAnalysis.Binding
{
    internal struct AliasAndUsingDirective
    {
        public readonly IAliasSymbol Alias;
        public readonly SyntaxNode UsingDirective;

        public AliasAndUsingDirective(IAliasSymbol alias, SyntaxNode usingDirective)
        {
            this.Alias = alias;
            this.UsingDirective = usingDirective;
        }
    }
}
