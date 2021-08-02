using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [Symbol]
    public partial class ParameterSymbol : LocalSymbol
    {
        [SymbolProperty]
        public virtual bool IsConst => false;

        [SymbolProperty]
        public virtual TypeSymbol? Type => null;

        [SymbolProperty]
        public virtual ExpressionSymbol? DefaultValue => null;

        [SymbolProperty]
        public virtual bool IsVarArg => false;

        [SymbolProperty]
        public virtual RefKind RefKind => RefKind.None;

        public new ParameterSymbol OriginalDefinition => this;
    }
}
