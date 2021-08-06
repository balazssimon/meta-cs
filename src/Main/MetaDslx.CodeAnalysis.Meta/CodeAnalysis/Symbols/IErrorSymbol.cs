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
        //bool IsUnreported { get; }
        //ErrorKind ErrorKind { get; }
        //ImmutableArray<DeclaredSymbol> CandidateSymbols { get; }
    }
}
