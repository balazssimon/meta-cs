using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace Microsoft.CodeAnalysis
{
    public class LanguageDiagnosticInfoWithSymbols : LanguageDiagnosticInfo
    {
        // not serialized:
        internal readonly ImmutableArray<ISymbol> Symbols;

        public LanguageDiagnosticInfoWithSymbols(ImmutableArray<ISymbol> symbols, ErrorCode errorCode, object[] arguments)
            : base(errorCode, arguments)
        {
            this.Symbols = symbols;
        }
    }
}
