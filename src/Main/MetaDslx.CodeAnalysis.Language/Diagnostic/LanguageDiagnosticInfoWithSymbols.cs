using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace Microsoft.CodeAnalysis
{
    public class DiagnosticInfoWithSymbols : LanguageDiagnosticInfo
    {
        // not serialized:
        internal readonly ImmutableArray<ISymbol> Symbols;

        public DiagnosticInfoWithSymbols(ImmutableArray<ISymbol> symbols, ErrorCode errorCode, object[] arguments)
            : base(errorCode, arguments)
        {
            this.Symbols = symbols;
        }
    }
}
