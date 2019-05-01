// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using Microsoft.CodeAnalysis;
using System;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public sealed class UnsupportedSymbol : ErrorTypeSymbol
    {
        private ISymbol _symbol;

        internal UnsupportedSymbol(ISymbol symbol)
        {
            _symbol = symbol;
        }

        public ISymbol Symbol => _symbol;
    }
}
