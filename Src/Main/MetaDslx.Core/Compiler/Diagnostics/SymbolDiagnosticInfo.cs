using MetaDslx.Core;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Diagnostics
{
    public class SymbolDiagnosticInfo : DiagnosticInfo
    {
        public ImmutableArray<ISymbol> Symbols { get; }

        public SymbolDiagnosticInfo(ImmutableArray<ISymbol> symbols, ErrorCode code, params object[] args)
            : base(code, args)
        {
            this.Symbols = symbols;
        }

        private SymbolDiagnosticInfo(SymbolDiagnosticInfo original, DiagnosticSeverity overriddenSeverity)
            : base(original, overriddenSeverity)
        {
            this.Symbols = original.Symbols;
        }

        public virtual SymbolDiagnosticInfo WithSymbols(ImmutableArray<ISymbol> symbols)
        {
            return new SymbolDiagnosticInfo(symbols, this.Code, this.Arguments);
        }

        public override DiagnosticInfo WithSeverity(DiagnosticSeverity overriddenSeverity)
        {
            if (this.Severity != overriddenSeverity) return new SymbolDiagnosticInfo(this, overriddenSeverity);
            else return this;
        }
    }
}
