// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using Microsoft.CodeAnalysis.CSharp.Symbols;
using Microsoft.CodeAnalysis.PooledObjects;
using Roslyn.Utilities;
using System;
using System.Collections.Immutable;
using System.Diagnostics;
using Microsoft.CodeAnalysis.Operations;

namespace MetaDslx.CodeAnalysis.Binding
{
    /// <summary>
    /// Summarizes whether a conversion is allowed, and if so, which kind of conversion (and in some cases, the
    /// associated symbol).
    /// </summary>
    public struct Conversion 
    {
        private readonly ConversionKind _kind;

        private Conversion(ConversionKind kind)
        {
            _kind = kind;
        }

        internal static Conversion UnsetConversion => new Conversion(ConversionKind.UnsetConversionKind);
        internal static Conversion NoConversion => new Conversion(ConversionKind.NoConversion);
    }
}
