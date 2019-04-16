using MetaDslx.Core;
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

    public class DiagnosticInfoWithMetaSymbols : LanguageDiagnosticInfo
    {
        // not serialized:
        internal readonly ImmutableArray<IMetaSymbol> Symbols;

        public DiagnosticInfoWithMetaSymbols(ImmutableArray<IMetaSymbol> symbols, ErrorCode errorCode, object[] arguments)
            : base(errorCode, arguments)
        {
            this.Symbols = symbols;
        }
    }
}
