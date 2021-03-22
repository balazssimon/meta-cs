// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Text;

namespace MetaDslx.CodeAnalysis.Binding
{
    internal enum ConversionKind : byte
    {
        UnsetConversionKind = 0,
        NoConversion,
        DefaultOrNullLiteral,
        Identity,
    }
}
