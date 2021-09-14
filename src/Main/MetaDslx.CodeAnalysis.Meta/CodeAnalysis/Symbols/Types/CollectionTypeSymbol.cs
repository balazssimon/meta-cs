using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [Symbol]
    public partial class CollectionTypeSymbol : TypeSymbol
    {
        public override bool IsStatic => false;

        [SymbolProperty]
        public virtual bool IsUnique { get; }
        [SymbolProperty]
        public virtual bool IsUnordered { get; }
        [SymbolProperty]
        public virtual TypeSymbol ItemType { get; }

        public override bool GetUnificationUseSiteDiagnosticRecursive(ref DiagnosticInfo result, Symbol owner, ref HashSet<TypeSymbol> checkedTypes)
        {
            throw new NotImplementedException();
        }
    }
}
