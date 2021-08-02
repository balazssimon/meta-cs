// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using Microsoft.CodeAnalysis;
using System;
using System.Collections.Immutable;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public partial class TypeSymbol
    {
        public bool IsRecord { get; internal set; }
        public bool IsNativeIntegerType { get; internal set; }
        public Microsoft.CodeAnalysis.NullableAnnotation DefaultNullableAnnotation { get; internal set; }
        public bool IsManagedTypeNoUseSiteDiagnostics { get; internal set; }

        /// <summary>
        /// Represents the method by which this type implements a given interface type
        /// and/or the corresponding diagnostics.
        /// </summary>
        protected class SymbolAndDiagnostics
        {
            public static readonly SymbolAndDiagnostics Empty = new SymbolAndDiagnostics(null, ImmutableArray<Diagnostic>.Empty);

            public readonly Symbol Symbol;
            public readonly ImmutableArray<Diagnostic> Diagnostics;

            public SymbolAndDiagnostics(Symbol symbol, ImmutableArray<Diagnostic> diagnostics)
            {
                this.Symbol = symbol;
                this.Diagnostics = diagnostics;
            }
        }

        internal bool IsNullableType()
        {
            throw new NotImplementedException();
        }

        internal bool IsTypeParameter()
        {
            throw new NotImplementedException();
        }
    }
}
