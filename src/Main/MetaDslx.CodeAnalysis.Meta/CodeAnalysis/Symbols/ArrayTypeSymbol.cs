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
    public abstract partial class ArrayTypeSymbol : TypeSymbol
    {
        public override bool IsStatic => false;

        [SymbolProperty]
        public virtual int LowerBound { get; }
        [SymbolProperty]
        public virtual int Size { get; }
        [SymbolProperty]
        public virtual TypeSymbol ElementType { get; }

        public override bool GetUnificationUseSiteDiagnosticRecursive(ref DiagnosticInfo result, Symbol owner, ref HashSet<TypeSymbol> checkedTypes)
        {
            throw new NotImplementedException();
        }
    }
}
