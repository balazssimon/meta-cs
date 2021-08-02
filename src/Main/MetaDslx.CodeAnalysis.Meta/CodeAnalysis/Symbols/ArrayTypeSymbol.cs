using Microsoft.CodeAnalysis;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [Symbol]
    public abstract class ArrayTypeSymbol : TypeSymbol
    {
        [SymbolProperty]
        public virtual int LowerBound { get; }
        [SymbolProperty]
        public virtual int Size { get; }
        [SymbolProperty]
        public virtual TypeSymbol ElementType { get; }
    }
}
