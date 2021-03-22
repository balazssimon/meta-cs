// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Collections.Generic;
using MetaDslx.CodeAnalysis.CSharp.Symbols;
using MetaDslx.CodeAnalysis.CSharp.Syntax;
using MetaDslx.CodeAnalysis.Text;

namespace MetaDslx.CodeAnalysis.CSharp.Symbols
{
    /// <summary>
    /// Utility class for substituting actual type arguments for formal generic type parameters.
    /// </summary>
    internal sealed class MutableTypeMap : AbstractTypeParameterMap
    {
        internal MutableTypeMap()
            : base(new SmallDictionary<TypeParameterSymbol, TypeWithAnnotations>())
        {
        }

        internal void Add(TypeParameterSymbol key, TypeWithAnnotations value)
        {
            this.Mapping.Add(key, value);
        }
    }
}
