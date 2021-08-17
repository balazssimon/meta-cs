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

namespace MetaDslx.Languages.Meta.Symbols.Factory
{
	public class AssociationSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataAssociationSymbol(container);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataAssociationSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataAssociationSymbol.Error(wrappedSymbol, kind, errorInfo, unreported);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceAssociationSymbol(container, declaration);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceAssociationSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceAssociationSymbol.Error(wrappedSymbol, kind, errorInfo, unreported);
        }
	}

}
