using Microsoft.CodeAnalysis;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Symbols;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;
using System.Threading;
using MetaDslx.CodeAnalysis.Declarations;

#nullable enable

namespace GeneratedSourceSymbols.Factory
{
	public class CustomSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataCustomSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataCustomSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataCustomSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceCustomSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceCustomSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceCustomSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

}
