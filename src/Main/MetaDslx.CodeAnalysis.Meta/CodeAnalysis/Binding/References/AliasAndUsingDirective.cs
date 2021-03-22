// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MetaDslx.CodeAnalysis.Symbols.Source;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.CodeAnalysis;

namespace MetaDslx.CodeAnalysis.Binding
{
    public struct AliasAndUsingDirective
    {
        public readonly AliasSymbol Alias;
        public readonly UsingDirective UsingDirective;

        public AliasAndUsingDirective(AliasSymbol alias, UsingDirective usingDirective)
        {
            this.Alias = alias;
            this.UsingDirective = usingDirective;
        }
    }
}
