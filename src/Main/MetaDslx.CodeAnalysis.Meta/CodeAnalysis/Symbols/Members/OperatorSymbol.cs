using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public abstract partial class OperatorSymbol : BehavioralMemberSymbol
    {
        [SymbolProperty]
        public abstract TypeSymbol ReturnType { get; }

        [SymbolProperty]
        public abstract ImmutableArray<ParameterSymbol> Parameters { get; }

        [SymbolProperty]
        public abstract StatementSymbol Body { get; }

    }
}
