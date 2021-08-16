using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public interface IErrorSymbol
    {
        DiagnosticInfo? ErrorInfo { get; }
        bool IsUnreported { get; }
        ErrorKind ErrorKind { get; }
        ImmutableArray<Symbol> CandidateSymbols { get; }
        Symbol AsUnreported(DiagnosticInfo? errorInfo = null);
        Symbol AsReported(DiagnosticInfo? errorInfo = null);
        Symbol AsKind(ErrorKind kind);
        Symbol AsKind(ErrorKind kind, ImmutableArray<Symbol> candidateSymbols);
        Symbol AsKind(ErrorKind kind, DiagnosticInfo errorInfo, ImmutableArray<Symbol> candidateSymbols);
    }
}
