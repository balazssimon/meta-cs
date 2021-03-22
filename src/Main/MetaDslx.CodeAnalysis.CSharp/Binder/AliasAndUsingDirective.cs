// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MetaDslx.CodeAnalysis.CSharp.Symbols;
using MetaDslx.CodeAnalysis.CSharp.Syntax;

namespace MetaDslx.CodeAnalysis.CSharp
{
    internal struct AliasAndUsingDirective
    {
        public readonly AliasSymbol Alias;
        public readonly UsingDirectiveSyntax UsingDirective;

        public AliasAndUsingDirective(AliasSymbol alias, UsingDirectiveSyntax usingDirective)
        {
            this.Alias = alias;
            this.UsingDirective = usingDirective;
        }
    }
}
