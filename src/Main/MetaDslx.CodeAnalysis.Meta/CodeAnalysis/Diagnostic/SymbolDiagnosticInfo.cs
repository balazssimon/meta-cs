using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis
{
    public class SymbolDiagnosticInfo : LanguageDiagnosticInfo
    {
        // not serialized:
        private readonly ImmutableArray<ISymbol> _symbols;
        // not serialized:
        private readonly ImmutableArray<Location> _additionalLocations;

        public SymbolDiagnosticInfo(ErrorCode errorCode, params object[] arguments)
            : base(errorCode, arguments)
        {
            _symbols = ImmutableArray<ISymbol>.Empty;
            _additionalLocations = ImmutableArray<Location>.Empty;
        }

        public SymbolDiagnosticInfo(ImmutableArray<ISymbol> symbols, ErrorCode errorCode, params object[] arguments)
            : base(errorCode, arguments)
        {
            _symbols = symbols;
            _additionalLocations = ImmutableArray<Location>.Empty;
        }

        public SymbolDiagnosticInfo(ImmutableArray<ISymbol> symbols, ImmutableArray<Location> additionalLocations, ErrorCode errorCode, params object[] arguments)
            : base(errorCode, arguments)
        {
            _symbols = symbols;
            _additionalLocations = additionalLocations;
        }

        public virtual ImmutableArray<ISymbol> Symbols => _symbols;

        public override IReadOnlyList<Location> AdditionalLocations => _additionalLocations;
    }
}
