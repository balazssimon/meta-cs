// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using Microsoft.CodeAnalysis;
using System.Collections.Immutable;
using System.Diagnostics;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [Symbol(ModelObjectOption = ParameterOption.Disabled)]
    public abstract partial class DiscardSymbol : ExpressionSymbol
    {
        public TypeSymbol Type { get; }

        public override bool Equals(object obj) => obj is DiscardSymbol other && this.Type.Equals(other.Type);
        public override int GetHashCode() => this.Type.GetHashCode();

    }
}
