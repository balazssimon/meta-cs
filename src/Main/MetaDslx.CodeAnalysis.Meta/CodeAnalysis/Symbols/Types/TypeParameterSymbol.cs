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
    public abstract partial class TypeParameterSymbol : TypeSymbol
    {
        public override bool IsStatic => false;
        public new TypeParameterSymbol OriginalDefinition => this;

        public override bool GetUnificationUseSiteDiagnosticRecursive(ref DiagnosticInfo result, Symbol owner, ref HashSet<TypeSymbol> checkedTypes)
        {
            throw new NotImplementedException();
        }
    }
}
