// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.CodeAnalysis;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Symbols.PublicModel
{
    internal sealed class AliasSymbol : Symbol, IAliasSymbol
    {
        private readonly Symbols.AliasSymbol _underlying;

        public AliasSymbol(Symbols.AliasSymbol underlying)
        {
            RoslynDebug.Assert(underlying is object);
            _underlying = underlying;
        }

        internal override Symbols.Symbol UnderlyingSymbol => _underlying;

        INamespaceOrTypeSymbol IAliasSymbol.Target
        {
            get
            {
                return (INamespaceOrTypeSymbol)_underlying.Target.GetPublicSymbol();
            }
        }

        #region ISymbol Members

        protected override void Accept(Microsoft.CodeAnalysis.SymbolVisitor visitor)
        {
            visitor.VisitAlias(this);
        }

        protected override TResult? Accept<TResult>(Microsoft.CodeAnalysis.SymbolVisitor<TResult> visitor)
            where TResult : default
        {
            return visitor.VisitAlias(this);
        }

        #endregion
    }
}
