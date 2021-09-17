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

namespace MetaDslx.CodeAnalysis.Symbols.Factory
{
	public class AttributeSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataAttributeSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataAttributeSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataAttributeSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceAttributeSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceAttributeSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceAttributeSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class ArgumentSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataArgumentSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataArgumentSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataArgumentSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceArgumentSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceArgumentSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceArgumentSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class AssignmentExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataAssignmentExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataAssignmentExpressionSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataAssignmentExpressionSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceAssignmentExpressionSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceAssignmentExpressionSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceAssignmentExpressionSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class AwaitExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataAwaitExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataAwaitExpressionSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataAwaitExpressionSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceAwaitExpressionSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceAwaitExpressionSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceAwaitExpressionSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class BinaryExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataBinaryExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataBinaryExpressionSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataBinaryExpressionSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceBinaryExpressionSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceBinaryExpressionSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceBinaryExpressionSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class CoalesceExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataCoalesceExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataCoalesceExpressionSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataCoalesceExpressionSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceCoalesceExpressionSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceCoalesceExpressionSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceCoalesceExpressionSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class CompoundAssignmentExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataCompoundAssignmentExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataCompoundAssignmentExpressionSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataCompoundAssignmentExpressionSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceCompoundAssignmentExpressionSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceCompoundAssignmentExpressionSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceCompoundAssignmentExpressionSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class ConditionalExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataConditionalExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataConditionalExpressionSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataConditionalExpressionSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceConditionalExpressionSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceConditionalExpressionSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceConditionalExpressionSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class ConversionExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataConversionExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataConversionExpressionSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataConversionExpressionSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceConversionExpressionSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceConversionExpressionSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceConversionExpressionSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class DefaultValueExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataDefaultValueExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataDefaultValueExpressionSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataDefaultValueExpressionSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceDefaultValueExpressionSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceDefaultValueExpressionSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceDefaultValueExpressionSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class DiscardExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataDiscardExpressionSymbol(container);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataDiscardExpressionSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataDiscardExpressionSymbol.Error(wrappedSymbol, kind, errorInfo, unreported);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceDiscardExpressionSymbol(container, declaration);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceDiscardExpressionSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceDiscardExpressionSymbol.Error(wrappedSymbol, kind, errorInfo, unreported);
        }
	}

	public class DynamicExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataDynamicExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataDynamicExpressionSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataDynamicExpressionSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceDynamicExpressionSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceDynamicExpressionSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceDynamicExpressionSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class IndexerAccessExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataIndexerAccessExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataIndexerAccessExpressionSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataIndexerAccessExpressionSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceIndexerAccessExpressionSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceIndexerAccessExpressionSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceIndexerAccessExpressionSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class InstanceReferenceExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataInstanceReferenceExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataInstanceReferenceExpressionSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataInstanceReferenceExpressionSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceInstanceReferenceExpressionSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceInstanceReferenceExpressionSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceInstanceReferenceExpressionSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class InvocationExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataInvocationExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataInvocationExpressionSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataInvocationExpressionSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceInvocationExpressionSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceInvocationExpressionSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceInvocationExpressionSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class IsTypeExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataIsTypeExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataIsTypeExpressionSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataIsTypeExpressionSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceIsTypeExpressionSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceIsTypeExpressionSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceIsTypeExpressionSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class LambdaExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataLambdaExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataLambdaExpressionSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataLambdaExpressionSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceLambdaExpressionSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceLambdaExpressionSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceLambdaExpressionSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class LiteralExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataLiteralExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataLiteralExpressionSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataLiteralExpressionSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceLiteralExpressionSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceLiteralExpressionSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceLiteralExpressionSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class NameOfExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataNameOfExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataNameOfExpressionSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataNameOfExpressionSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceNameOfExpressionSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceNameOfExpressionSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceNameOfExpressionSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class NullForgivingExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataNullForgivingExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataNullForgivingExpressionSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataNullForgivingExpressionSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceNullForgivingExpressionSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceNullForgivingExpressionSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceNullForgivingExpressionSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class ObjectCreationExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataObjectCreationExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataObjectCreationExpressionSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataObjectCreationExpressionSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceObjectCreationExpressionSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceObjectCreationExpressionSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceObjectCreationExpressionSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class ParenthesizedExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataParenthesizedExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataParenthesizedExpressionSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataParenthesizedExpressionSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceParenthesizedExpressionSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceParenthesizedExpressionSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceParenthesizedExpressionSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class ReferenceExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataReferenceExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataReferenceExpressionSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataReferenceExpressionSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceReferenceExpressionSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceReferenceExpressionSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceReferenceExpressionSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class SizeOfExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataSizeOfExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataSizeOfExpressionSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataSizeOfExpressionSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceSizeOfExpressionSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceSizeOfExpressionSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceSizeOfExpressionSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class ThrowExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataThrowExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataThrowExpressionSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataThrowExpressionSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceThrowExpressionSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceThrowExpressionSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceThrowExpressionSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class TupleExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataTupleExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataTupleExpressionSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataTupleExpressionSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceTupleExpressionSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceTupleExpressionSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceTupleExpressionSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class TypeOfExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataTypeOfExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataTypeOfExpressionSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataTypeOfExpressionSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceTypeOfExpressionSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceTypeOfExpressionSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceTypeOfExpressionSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class UnaryExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataUnaryExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataUnaryExpressionSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataUnaryExpressionSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceUnaryExpressionSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceUnaryExpressionSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceUnaryExpressionSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class VariableDeclarationExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataVariableDeclarationExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataVariableDeclarationExpressionSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataVariableDeclarationExpressionSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceVariableDeclarationExpressionSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceVariableDeclarationExpressionSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceVariableDeclarationExpressionSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class VariableSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataVariableSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataVariableSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataVariableSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceVariableSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceVariableSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceVariableSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class MemberSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataMemberSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataMemberSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataMemberSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceMemberSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceMemberSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceMemberSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class BinaryOperatorSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataBinaryOperatorSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataBinaryOperatorSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataBinaryOperatorSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceBinaryOperatorSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceBinaryOperatorSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceBinaryOperatorSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class ConstructorSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataConstructorSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataConstructorSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataConstructorSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceConstructorSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceConstructorSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceConstructorSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class ConversionOperatorSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataConversionOperatorSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataConversionOperatorSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataConversionOperatorSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceConversionOperatorSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceConversionOperatorSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceConversionOperatorSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class DestructorSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataDestructorSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataDestructorSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataDestructorSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceDestructorSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceDestructorSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceDestructorSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class FieldSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataFieldSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataFieldSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataFieldSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceFieldSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceFieldSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceFieldSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class FunctionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataFunctionSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataFunctionSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataFunctionSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceFunctionSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceFunctionSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceFunctionSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class PropertySymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataPropertySymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataPropertySymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataPropertySymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourcePropertySymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourcePropertySymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourcePropertySymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class IndexerSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataIndexerSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataIndexerSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataIndexerSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceIndexerSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceIndexerSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceIndexerSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class LambdaSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataLambdaSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataLambdaSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataLambdaSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceLambdaSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceLambdaSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceLambdaSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class MethodSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataMethodSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataMethodSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataMethodSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceMethodSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceMethodSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceMethodSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class ParameterSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataParameterSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataParameterSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataParameterSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceParameterSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceParameterSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceParameterSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class UnaryOperatorSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataUnaryOperatorSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataUnaryOperatorSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataUnaryOperatorSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceUnaryOperatorSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceUnaryOperatorSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceUnaryOperatorSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class AliasSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            throw new NotImplementedException("CreateMetadataSymbol for MetadataAliasSymbol should be implemented in a custom SymbolFactory.");
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            throw new NotImplementedException("CreateMetadataSymbol for MetadataAliasSymbol should be implemented in a custom SymbolFactory.");
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            throw new NotImplementedException("CreateMetadataSymbol for MetadataAliasSymbol should be implemented in a custom SymbolFactory.");
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceAliasSymbol(container, declaration);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceAliasSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceAliasSymbol.Error(wrappedSymbol, kind, errorInfo, unreported);
        }
	}

	public class NamespaceSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataNamespaceSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataNamespaceSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataNamespaceSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            throw new NotImplementedException("CreateSourceSymbol for SourceNamespaceSymbol should be implemented in a custom SymbolFactory.");
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            throw new NotImplementedException("CreateSourceSymbol for SourceNamespaceSymbol should be implemented in a custom SymbolFactory.");
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            throw new NotImplementedException("CreateSourceSymbol for SourceNamespaceSymbol should be implemented in a custom SymbolFactory.");
        }
	}

	public class BlockStatementSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataBlockStatementSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataBlockStatementSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataBlockStatementSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceBlockStatementSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceBlockStatementSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceBlockStatementSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class CatchClauseSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataCatchClauseSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataCatchClauseSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataCatchClauseSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceCatchClauseSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceCatchClauseSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceCatchClauseSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class DefaultCaseClauseSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataDefaultCaseClauseSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataDefaultCaseClauseSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataDefaultCaseClauseSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceDefaultCaseClauseSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceDefaultCaseClauseSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceDefaultCaseClauseSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class EmptyStatementSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataEmptyStatementSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataEmptyStatementSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataEmptyStatementSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceEmptyStatementSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceEmptyStatementSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceEmptyStatementSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class ExpressionStatementSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataExpressionStatementSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataExpressionStatementSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataExpressionStatementSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceExpressionStatementSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceExpressionStatementSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceExpressionStatementSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class ForEachLoopStatementSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataForEachLoopStatementSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataForEachLoopStatementSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataForEachLoopStatementSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceForEachLoopStatementSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceForEachLoopStatementSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceForEachLoopStatementSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class ForLoopStatementSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataForLoopStatementSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataForLoopStatementSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataForLoopStatementSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceForLoopStatementSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceForLoopStatementSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceForLoopStatementSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class ForToLoopStatementSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataForToLoopStatementSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataForToLoopStatementSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataForToLoopStatementSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceForToLoopStatementSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceForToLoopStatementSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceForToLoopStatementSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class IfStatementSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataIfStatementSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataIfStatementSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataIfStatementSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceIfStatementSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceIfStatementSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceIfStatementSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class JumpStatementSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataJumpStatementSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataJumpStatementSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataJumpStatementSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceJumpStatementSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceJumpStatementSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceJumpStatementSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class LabeledStatementSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataLabeledStatementSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataLabeledStatementSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataLabeledStatementSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceLabeledStatementSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceLabeledStatementSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceLabeledStatementSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class LabelSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataLabelSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataLabelSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataLabelSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceLabelSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceLabelSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceLabelSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class LockStatementSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataLockStatementSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataLockStatementSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataLockStatementSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceLockStatementSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceLockStatementSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceLockStatementSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class ReturnStatementSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataReturnStatementSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataReturnStatementSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataReturnStatementSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceReturnStatementSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceReturnStatementSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceReturnStatementSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class SingleValueCaseClauseSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataSingleValueCaseClauseSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataSingleValueCaseClauseSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataSingleValueCaseClauseSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceSingleValueCaseClauseSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceSingleValueCaseClauseSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceSingleValueCaseClauseSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class SwitchCaseSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataSwitchCaseSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataSwitchCaseSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataSwitchCaseSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceSwitchCaseSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceSwitchCaseSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceSwitchCaseSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class SwitchStatementSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataSwitchStatementSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataSwitchStatementSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataSwitchStatementSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceSwitchStatementSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceSwitchStatementSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceSwitchStatementSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class TryStatementSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataTryStatementSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataTryStatementSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataTryStatementSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceTryStatementSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceTryStatementSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceTryStatementSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class UsingStatementSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataUsingStatementSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataUsingStatementSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataUsingStatementSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceUsingStatementSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceUsingStatementSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceUsingStatementSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class WhileLoopStatementSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataWhileLoopStatementSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataWhileLoopStatementSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataWhileLoopStatementSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceWhileLoopStatementSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceWhileLoopStatementSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceWhileLoopStatementSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class ArrayTypeSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataArrayTypeSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataArrayTypeSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataArrayTypeSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceArrayTypeSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceArrayTypeSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceArrayTypeSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class NamedTypeSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataNamedTypeSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataNamedTypeSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataNamedTypeSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceNamedTypeSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceNamedTypeSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceNamedTypeSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class ClassTypeSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataClassTypeSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataClassTypeSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataClassTypeSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceClassTypeSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceClassTypeSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceClassTypeSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class CollectionTypeSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataCollectionTypeSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataCollectionTypeSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataCollectionTypeSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceCollectionTypeSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceCollectionTypeSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceCollectionTypeSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class DelegateTypeSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataDelegateTypeSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataDelegateTypeSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataDelegateTypeSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceDelegateTypeSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceDelegateTypeSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceDelegateTypeSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class DictionaryTypeSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataDictionaryTypeSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataDictionaryTypeSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataDictionaryTypeSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceDictionaryTypeSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceDictionaryTypeSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceDictionaryTypeSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class EnumLiteralSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataEnumLiteralSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataEnumLiteralSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataEnumLiteralSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceEnumLiteralSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceEnumLiteralSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceEnumLiteralSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class EnumTypeSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataEnumTypeSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataEnumTypeSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataEnumTypeSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceEnumTypeSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceEnumTypeSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceEnumTypeSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class GenericTypeReferenceTypeSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataGenericTypeReferenceTypeSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataGenericTypeReferenceTypeSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataGenericTypeReferenceTypeSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceGenericTypeReferenceTypeSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceGenericTypeReferenceTypeSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceGenericTypeReferenceTypeSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class InterfaceTypeSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataInterfaceTypeSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataInterfaceTypeSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataInterfaceTypeSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceInterfaceTypeSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceInterfaceTypeSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceInterfaceTypeSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class NullableTypeSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataNullableTypeSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataNullableTypeSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataNullableTypeSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceNullableTypeSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceNullableTypeSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceNullableTypeSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class PrimitiveTypeSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataPrimitiveTypeSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataPrimitiveTypeSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataPrimitiveTypeSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourcePrimitiveTypeSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourcePrimitiveTypeSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourcePrimitiveTypeSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class StructTypeSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataStructTypeSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataStructTypeSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataStructTypeSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceStructTypeSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceStructTypeSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceStructTypeSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class TupleTypeSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataTupleTypeSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataTupleTypeSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataTupleTypeSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceTupleTypeSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceTupleTypeSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceTupleTypeSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

	public class TypeParameterSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataTypeParameterSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, string name, string metadataName, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataTypeParameterSymbol.Error(container, name, metadataName, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Metadata.MetadataTypeParameterSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceTypeParameterSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, ImmutableArray<Symbol> candidateSymbols, bool unreported, object? modelObject)
        {
            return new Source.SourceTypeParameterSymbol.Error(container, declaration, kind, errorInfo, candidateSymbols, unreported, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol wrappedSymbol, MetaDslx.CodeAnalysis.Symbols.ErrorKind kind, DiagnosticInfo? errorInfo, bool unreported, object? modelObject)
        {
            return new Source.SourceTypeParameterSymbol.Error(wrappedSymbol, kind, errorInfo, unreported, modelObject);
        }
	}

}
