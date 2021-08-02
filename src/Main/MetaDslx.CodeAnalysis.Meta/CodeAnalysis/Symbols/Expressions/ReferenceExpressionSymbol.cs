using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [Symbol]
    public abstract partial class ReferenceExpressionSymbol : ExpressionSymbol
    {
        [SymbolProperty]
        public abstract ExpressionSymbol? Instance { get; }

        [SymbolProperty]
        public abstract string ReferencedName { get; }

        public virtual LocalSymbol LocalSymbol { get; }
        public virtual MemberSymbol MemberSymbol { get; }
    }
}
