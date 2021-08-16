using MetaDslx.CodeAnalysis.Declarations;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public interface IGeneratedSymbolFactory
    {
        Symbol? CreateMetadataSymbol(Symbol container, object? modelObject);
        Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject);
        Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject);
        Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject);
        Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject);
        Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject);
    }
}
