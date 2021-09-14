using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [Symbol]
    public partial class GenericTypeReferenceTypeSymbol : TypeSymbol
    {
        public override bool IsStatic => false;

        [SymbolProperty]
        public virtual NamedTypeSymbol ReferencedType { get; }
        [SymbolProperty]
        public virtual ImmutableArray<TypeSymbol> TypeArguments { get; }

        public virtual NamedTypeSymbol ConstructedType { get; }

        public override bool GetUnificationUseSiteDiagnosticRecursive(ref DiagnosticInfo result, Symbol owner, ref HashSet<TypeSymbol> checkedTypes)
        {
            throw new NotImplementedException();
        }
    }
}
