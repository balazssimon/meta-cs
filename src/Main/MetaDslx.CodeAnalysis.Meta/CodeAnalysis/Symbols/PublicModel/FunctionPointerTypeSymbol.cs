// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Diagnostics;
using Microsoft.CodeAnalysis;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Symbols.PublicModel
{
    internal sealed class FunctionPointerTypeSymbol : TypeSymbol, IFunctionPointerTypeSymbol
    {
        private readonly Symbols.FunctionPointerTypeSymbol _underlying;

        public FunctionPointerTypeSymbol(Symbols.FunctionPointerTypeSymbol underlying, Microsoft.CodeAnalysis.NullableAnnotation nullableAnnotation)
            : base(nullableAnnotation)
        {
            RoslynDebug.Assert(underlying is object);
            _underlying = underlying;
        }

        public IMethodSymbol Signature => _underlying.Signature.GetPublicSymbol();
        internal override Symbols.TypeSymbol UnderlyingTypeSymbol => _underlying;
        internal override Symbols.NamespaceOrTypeSymbol UnderlyingNamespaceOrTypeSymbol => _underlying;
        internal override Symbols.Symbol UnderlyingSymbol => _underlying;

        protected override void Accept(Microsoft.CodeAnalysis.SymbolVisitor visitor)
            => visitor.VisitFunctionPointerType(this);

        protected override TResult? Accept<TResult>(Microsoft.CodeAnalysis.SymbolVisitor<TResult> visitor)
            where TResult : default
        {
            return visitor.VisitFunctionPointerType(this);
        }

        protected override ITypeSymbol WithNullableAnnotation(Microsoft.CodeAnalysis.NullableAnnotation nullableAnnotation)
        {
            Debug.Assert(nullableAnnotation != this.NullableAnnotation);
            Debug.Assert(nullableAnnotation != _underlying.DefaultNullableAnnotation);
            return new FunctionPointerTypeSymbol(_underlying, nullableAnnotation);
        }
    }
}
