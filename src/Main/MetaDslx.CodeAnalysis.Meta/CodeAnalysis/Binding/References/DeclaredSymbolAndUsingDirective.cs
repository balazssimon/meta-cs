// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Syntax;
using MetaDslx.CodeAnalysis;

namespace MetaDslx.CodeAnalysis.Binding
{
    public struct DeclaredSymbolAndUsingDirective
    {
        public readonly DeclaredSymbol DeclaredSymbol;
        public readonly UsingDirective UsingDirective;

        public DeclaredSymbolAndUsingDirective(DeclaredSymbol symbol, UsingDirective usingDirective)
        {
            this.DeclaredSymbol = symbol;
            this.UsingDirective = usingDirective;
        }
    }
}
