using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Declarations;
using MetaDslx.CodeAnalysis.Symbols;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GeneratedSourceSymbols
{
    [Symbol]
    public partial class CustomSymbol : Symbol
    {
        [SymbolProperty]
        public abstract CustomSymbol Left { get; }
        [SymbolProperty]
        public abstract CustomSymbol Right { get; }
        [SymbolProperty]
        public abstract ImmutableArray<CustomSymbol> CustomArray { get; }
        [SymbolProperty]
        public abstract ImmutableArray<int> IntArray { get; }
        [SymbolProperty]
        public abstract int Int { get; }
    }
}
