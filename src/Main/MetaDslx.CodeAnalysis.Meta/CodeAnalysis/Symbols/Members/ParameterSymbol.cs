using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [Symbol]
    public partial class ParameterSymbol : VariableSymbol
    {
        [SymbolProperty]
        public virtual bool IsVarArg => false;

        [SymbolProperty]
        public virtual RefKind RefKind => RefKind.None;

        public bool IsOptional => DefaultValue is not null;
    }
}
