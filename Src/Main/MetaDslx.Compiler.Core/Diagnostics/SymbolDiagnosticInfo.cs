﻿using MetaDslx.Core;
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
        public ImmutableArray<IMetaSymbol> Symbols { get; }

        public SymbolDiagnosticInfo(MessageProvider messageProvider, ImmutableArray<IMetaSymbol> symbols, int code, params object[] args)
            : base(messageProvider, code, args)
        {
            this.Symbols = symbols;
        }

        private SymbolDiagnosticInfo(SymbolDiagnosticInfo original, DiagnosticSeverity overriddenSeverity)
            : base(original, overriddenSeverity)
        {
            this.Symbols = original.Symbols;
        }

        public virtual SymbolDiagnosticInfo WithSymbols(ImmutableArray<IMetaSymbol> symbols)
        {
            return new SymbolDiagnosticInfo(this.MessageProvider, symbols, this.Code, this.Arguments);
        }

        public override DiagnosticInfo WithSeverity(DiagnosticSeverity overriddenSeverity)
        {
            if (this.Severity != overriddenSeverity) return new SymbolDiagnosticInfo(this, overriddenSeverity);
            else return this;
        }
    }
}
