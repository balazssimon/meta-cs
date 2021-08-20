using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [Symbol]
    public abstract partial class IndexerSymbol : PropertySymbol, IInvocableMember
    {
        [SymbolProperty]
        public abstract ImmutableArray<ParameterSymbol> Parameters { get; }

        public bool IsVarArg => this.Parameters.Any(p => p.IsVarArg);
    }
}
