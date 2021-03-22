// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MetaDslx.CodeAnalysis.CSharp.Symbols;
using MetaDslx.CodeAnalysis.CSharp.Syntax;
using MetaDslx.CodeAnalysis.Text;

namespace MetaDslx.CodeAnalysis.CSharp.Syntax
{
    public enum XmlNameAttributeElementKind : byte
    {
        Parameter = 0,
        ParameterReference = 1,
        TypeParameter = 2,
        TypeParameterReference = 3,
    }
}
