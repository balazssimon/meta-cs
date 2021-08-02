using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [Symbol]
    public abstract partial class NullableTypeSymbol : TypeSymbol
    {
        public override bool IsStatic => false;

        [SymbolProperty]
        public virtual TypeSymbol InnerType { get; }

        public override bool GetUnificationUseSiteDiagnosticRecursive(ref DiagnosticInfo result, Symbol owner, ref HashSet<TypeSymbol> checkedTypes)
        {
            throw new NotImplementedException();
        }
    }
}
