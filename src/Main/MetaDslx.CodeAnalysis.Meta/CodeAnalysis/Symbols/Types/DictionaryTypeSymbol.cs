using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [Symbol]
    public partial class DictionaryTypeSymbol : TypeSymbol
    {
        public override bool IsStatic => false;

        [SymbolProperty]
        public virtual bool IsUnordered { get; }
        [SymbolProperty]
        public virtual TypeSymbol KeyType { get; }
        [SymbolProperty]
        public virtual TypeSymbol ValueType { get; }

        public override bool GetUnificationUseSiteDiagnosticRecursive(ref DiagnosticInfo result, Symbol owner, ref HashSet<TypeSymbol> checkedTypes)
        {
            throw new NotImplementedException();
        }
    }
}
