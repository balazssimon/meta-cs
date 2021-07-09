// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using Microsoft.CodeAnalysis;
using System.Collections.Immutable;
using System.Diagnostics;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [Symbol]
    public partial class DiscardSymbol : Symbol
    {
        public TypeSymbol Type { get; }


        internal TypeWithAnnotations TypeWithAnnotations { get; set; }

        public override bool Equals(object obj) => obj is DiscardSymbol other && this.Type.Equals(other.Type);
        public override int GetHashCode() => this.Type.GetHashCode();

    }
}
