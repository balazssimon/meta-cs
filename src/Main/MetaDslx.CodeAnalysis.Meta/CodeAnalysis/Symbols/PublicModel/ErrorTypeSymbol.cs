// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Immutable;
using System.Diagnostics;
using Microsoft.CodeAnalysis;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Symbols.PublicModel
{
    internal sealed class ErrorTypeSymbol : NamedTypeSymbol, IErrorTypeSymbol
    {
        private readonly Symbols.ErrorTypeSymbol _underlying;

        public ErrorTypeSymbol(Symbols.ErrorTypeSymbol underlying, Microsoft.CodeAnalysis.NullableAnnotation nullableAnnotation)
            : base(nullableAnnotation)
        {
            RoslynDebug.Assert(underlying is object);
            _underlying = underlying;
        }

        protected override ITypeSymbol WithNullableAnnotation(Microsoft.CodeAnalysis.NullableAnnotation nullableAnnotation)
        {
            Debug.Assert(nullableAnnotation != _underlying.DefaultNullableAnnotation);
            Debug.Assert(nullableAnnotation != this.NullableAnnotation);
            return new ErrorTypeSymbol(_underlying, nullableAnnotation);
        }

        internal override Symbols.Symbol UnderlyingSymbol => _underlying;
        internal override Symbols.NamespaceOrTypeSymbol UnderlyingNamespaceOrTypeSymbol => _underlying;
        internal override Symbols.TypeSymbol UnderlyingTypeSymbol => _underlying;
        internal override Symbols.NamedTypeSymbol UnderlyingNamedTypeSymbol => _underlying;

        ImmutableArray<ISymbol> IErrorTypeSymbol.CandidateSymbols => _underlying.CandidateSymbols.SelectAsArray(s => s.GetPublicSymbol());

        CandidateReason IErrorTypeSymbol.CandidateReason => _underlying.CandidateReason;
    }
}
