using MetaDslx.CodeAnalysis.Symbols;
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
        private readonly ImmutableArray<Symbol> _symbols;
        // not serialized:
        private readonly ImmutableArray<Location> _additionalLocations;

        public SymbolDiagnosticInfo(ErrorCode errorCode, params object[] arguments)
            : base(errorCode, arguments)
        {
            _symbols = ImmutableArray<Symbol>.Empty;
            _additionalLocations = ImmutableArray<Location>.Empty;
        }

        public SymbolDiagnosticInfo(ErrorCode errorCode, ImmutableArray<Symbol> symbols, params object[] arguments)
            : base(errorCode, arguments)
        {
            _symbols = symbols;
            _additionalLocations = ImmutableArray<Location>.Empty;
        }

        public SymbolDiagnosticInfo(ErrorCode errorCode, ImmutableArray<Symbol> symbols, ImmutableArray<Location> additionalLocations, params object[] arguments)
            : base(errorCode, arguments)
        {
            _symbols = symbols;
            _additionalLocations = additionalLocations;
        }

        public virtual ImmutableArray<Symbol> Symbols => _symbols;

        public override IReadOnlyList<Location> AdditionalLocations => _additionalLocations;
    }
}
