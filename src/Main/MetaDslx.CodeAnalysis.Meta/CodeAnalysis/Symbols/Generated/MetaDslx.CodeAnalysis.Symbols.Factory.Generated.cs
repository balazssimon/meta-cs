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

namespace MetaDslx.CodeAnalysis.Symbols.Factory
{
	public class ArgumentSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataArgumentSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataArgumentSymbol.Error(container, errorInfo, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceArgumentSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourceArgumentSymbol.Error(container, declaration, errorInfo, modelObject);
        }
	}
	public class AssignmentExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataAssignmentExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataAssignmentExpressionSymbol.Error(container, errorInfo, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceAssignmentExpressionSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourceAssignmentExpressionSymbol.Error(container, declaration, errorInfo, modelObject);
        }
	}
	public class AwaitExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataAwaitExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataAwaitExpressionSymbol.Error(container, errorInfo, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceAwaitExpressionSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourceAwaitExpressionSymbol.Error(container, declaration, errorInfo, modelObject);
        }
	}
	public class BinaryExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataBinaryExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataBinaryExpressionSymbol.Error(container, errorInfo, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceBinaryExpressionSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourceBinaryExpressionSymbol.Error(container, declaration, errorInfo, modelObject);
        }
	}
	public class CoalesceExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataCoalesceExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataCoalesceExpressionSymbol.Error(container, errorInfo, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceCoalesceExpressionSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourceCoalesceExpressionSymbol.Error(container, declaration, errorInfo, modelObject);
        }
	}
	public class CompoundAssignmentExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataCompoundAssignmentExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataCompoundAssignmentExpressionSymbol.Error(container, errorInfo, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceCompoundAssignmentExpressionSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourceCompoundAssignmentExpressionSymbol.Error(container, declaration, errorInfo, modelObject);
        }
	}
	public class ConditionalExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataConditionalExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataConditionalExpressionSymbol.Error(container, errorInfo, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceConditionalExpressionSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourceConditionalExpressionSymbol.Error(container, declaration, errorInfo, modelObject);
        }
	}
	public class ConversionExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataConversionExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataConversionExpressionSymbol.Error(container, errorInfo, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceConversionExpressionSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourceConversionExpressionSymbol.Error(container, declaration, errorInfo, modelObject);
        }
	}
	public class DefaultValueExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataDefaultValueExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataDefaultValueExpressionSymbol.Error(container, errorInfo, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceDefaultValueExpressionSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourceDefaultValueExpressionSymbol.Error(container, declaration, errorInfo, modelObject);
        }
	}
	public class DiscardExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataDiscardExpressionSymbol(container);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataDiscardExpressionSymbol.Error(container, errorInfo);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceDiscardExpressionSymbol(container, declaration);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourceDiscardExpressionSymbol.Error(container, declaration, errorInfo);
        }
	}
	public class DynamicExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataDynamicExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataDynamicExpressionSymbol.Error(container, errorInfo, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceDynamicExpressionSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourceDynamicExpressionSymbol.Error(container, declaration, errorInfo, modelObject);
        }
	}
	public class IncrementOrDecrementExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataIncrementOrDecrementExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataIncrementOrDecrementExpressionSymbol.Error(container, errorInfo, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceIncrementOrDecrementExpressionSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourceIncrementOrDecrementExpressionSymbol.Error(container, declaration, errorInfo, modelObject);
        }
	}
	public class IndexerAccessExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataIndexerAccessExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataIndexerAccessExpressionSymbol.Error(container, errorInfo, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceIndexerAccessExpressionSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourceIndexerAccessExpressionSymbol.Error(container, declaration, errorInfo, modelObject);
        }
	}
	public class InstanceReferenceExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataInstanceReferenceExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataInstanceReferenceExpressionSymbol.Error(container, errorInfo, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceInstanceReferenceExpressionSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourceInstanceReferenceExpressionSymbol.Error(container, declaration, errorInfo, modelObject);
        }
	}
	public class InvocationExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataInvocationExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataInvocationExpressionSymbol.Error(container, errorInfo, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceInvocationExpressionSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourceInvocationExpressionSymbol.Error(container, declaration, errorInfo, modelObject);
        }
	}
	public class IsTypeExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataIsTypeExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataIsTypeExpressionSymbol.Error(container, errorInfo, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceIsTypeExpressionSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourceIsTypeExpressionSymbol.Error(container, declaration, errorInfo, modelObject);
        }
	}
	public class LambdaExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataLambdaExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataLambdaExpressionSymbol.Error(container, errorInfo, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceLambdaExpressionSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourceLambdaExpressionSymbol.Error(container, declaration, errorInfo, modelObject);
        }
	}
	public class LiteralExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataLiteralExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataLiteralExpressionSymbol.Error(container, errorInfo, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceLiteralExpressionSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourceLiteralExpressionSymbol.Error(container, declaration, errorInfo, modelObject);
        }
	}
	public class MemberReferenceExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataMemberReferenceExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataMemberReferenceExpressionSymbol.Error(container, errorInfo, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceMemberReferenceExpressionSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourceMemberReferenceExpressionSymbol.Error(container, declaration, errorInfo, modelObject);
        }
	}
	public class NameOfExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataNameOfExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataNameOfExpressionSymbol.Error(container, errorInfo, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceNameOfExpressionSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourceNameOfExpressionSymbol.Error(container, declaration, errorInfo, modelObject);
        }
	}
	public class ObjectCreationExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataObjectCreationExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataObjectCreationExpressionSymbol.Error(container, errorInfo, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceObjectCreationExpressionSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourceObjectCreationExpressionSymbol.Error(container, declaration, errorInfo, modelObject);
        }
	}
	public class ParenthesizedExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataParenthesizedExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataParenthesizedExpressionSymbol.Error(container, errorInfo, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceParenthesizedExpressionSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourceParenthesizedExpressionSymbol.Error(container, declaration, errorInfo, modelObject);
        }
	}
	public class ReferenceExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataReferenceExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataReferenceExpressionSymbol.Error(container, errorInfo, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceReferenceExpressionSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourceReferenceExpressionSymbol.Error(container, declaration, errorInfo, modelObject);
        }
	}
	public class SizeOfExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataSizeOfExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataSizeOfExpressionSymbol.Error(container, errorInfo, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceSizeOfExpressionSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourceSizeOfExpressionSymbol.Error(container, declaration, errorInfo, modelObject);
        }
	}
	public class ThrowExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataThrowExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataThrowExpressionSymbol.Error(container, errorInfo, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceThrowExpressionSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourceThrowExpressionSymbol.Error(container, declaration, errorInfo, modelObject);
        }
	}
	public class TupleExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataTupleExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataTupleExpressionSymbol.Error(container, errorInfo, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceTupleExpressionSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourceTupleExpressionSymbol.Error(container, declaration, errorInfo, modelObject);
        }
	}
	public class TypeOfExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataTypeOfExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataTypeOfExpressionSymbol.Error(container, errorInfo, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceTypeOfExpressionSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourceTypeOfExpressionSymbol.Error(container, declaration, errorInfo, modelObject);
        }
	}
	public class UnaryExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataUnaryExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataUnaryExpressionSymbol.Error(container, errorInfo, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceUnaryExpressionSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourceUnaryExpressionSymbol.Error(container, declaration, errorInfo, modelObject);
        }
	}
	public class VariableDeclarationExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataVariableDeclarationExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataVariableDeclarationExpressionSymbol.Error(container, errorInfo, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceVariableDeclarationExpressionSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourceVariableDeclarationExpressionSymbol.Error(container, declaration, errorInfo, modelObject);
        }
	}
	public class VariableDeclarationGroupExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataVariableDeclarationGroupExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataVariableDeclarationGroupExpressionSymbol.Error(container, errorInfo, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceVariableDeclarationGroupExpressionSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourceVariableDeclarationGroupExpressionSymbol.Error(container, declaration, errorInfo, modelObject);
        }
	}
	public class BinaryOperatorSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataBinaryOperatorSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataBinaryOperatorSymbol.Error(container, errorInfo, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceBinaryOperatorSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourceBinaryOperatorSymbol.Error(container, declaration, errorInfo, modelObject);
        }
	}
	public class ConstructorSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataConstructorSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataConstructorSymbol.Error(container, errorInfo, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceConstructorSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourceConstructorSymbol.Error(container, declaration, errorInfo, modelObject);
        }
	}
	public class ConversionOperatorSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataConversionOperatorSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataConversionOperatorSymbol.Error(container, errorInfo, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceConversionOperatorSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourceConversionOperatorSymbol.Error(container, declaration, errorInfo, modelObject);
        }
	}
	public class DestructorSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataDestructorSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataDestructorSymbol.Error(container, errorInfo, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceDestructorSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourceDestructorSymbol.Error(container, declaration, errorInfo, modelObject);
        }
	}
	public class FieldSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataFieldSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataFieldSymbol.Error(container, errorInfo, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceFieldSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourceFieldSymbol.Error(container, declaration, errorInfo, modelObject);
        }
	}
	public class IndexerSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataIndexerSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataIndexerSymbol.Error(container, errorInfo, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceIndexerSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourceIndexerSymbol.Error(container, declaration, errorInfo, modelObject);
        }
	}
	public class LambdaSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataLambdaSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataLambdaSymbol.Error(container, errorInfo, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceLambdaSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourceLambdaSymbol.Error(container, declaration, errorInfo, modelObject);
        }
	}
	public class MemberSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataMemberSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataMemberSymbol.Error(container, errorInfo, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceMemberSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourceMemberSymbol.Error(container, declaration, errorInfo, modelObject);
        }
	}
	public class MethodSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataMethodSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataMethodSymbol.Error(container, errorInfo, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceMethodSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourceMethodSymbol.Error(container, declaration, errorInfo, modelObject);
        }
	}
	public class ParameterSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataParameterSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataParameterSymbol.Error(container, errorInfo, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceParameterSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourceParameterSymbol.Error(container, declaration, errorInfo, modelObject);
        }
	}
	public class PropertySymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataPropertySymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataPropertySymbol.Error(container, errorInfo, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourcePropertySymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourcePropertySymbol.Error(container, declaration, errorInfo, modelObject);
        }
	}
	public class UnaryOperatorSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataUnaryOperatorSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataUnaryOperatorSymbol.Error(container, errorInfo, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceUnaryOperatorSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourceUnaryOperatorSymbol.Error(container, declaration, errorInfo, modelObject);
        }
	}
	public class AliasSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            throw new NotImplementedException("CreateMetadataSymbol for MetadataAliasSymbol should be implemented in a custom SymbolFactory.");
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            throw new NotImplementedException("CreateMetadataSymbol for MetadataAliasSymbol should be implemented in a custom SymbolFactory.");
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceAliasSymbol(container, declaration);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourceAliasSymbol.Error(container, declaration, errorInfo);
        }
	}
	public class NamespaceSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataNamespaceSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataNamespaceSymbol.Error(container, errorInfo, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            throw new NotImplementedException("CreateSourceSymbol for SourceNamespaceSymbol should be implemented in a custom SymbolFactory.");
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
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

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataBlockStatementSymbol.Error(container, errorInfo, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceBlockStatementSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourceBlockStatementSymbol.Error(container, declaration, errorInfo, modelObject);
        }
	}
	public class CatchClauseSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataCatchClauseSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataCatchClauseSymbol.Error(container, errorInfo, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceCatchClauseSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourceCatchClauseSymbol.Error(container, declaration, errorInfo, modelObject);
        }
	}
	public class DefaultCaseClauseSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataDefaultCaseClauseSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataDefaultCaseClauseSymbol.Error(container, errorInfo, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceDefaultCaseClauseSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourceDefaultCaseClauseSymbol.Error(container, declaration, errorInfo, modelObject);
        }
	}
	public class EmptyStatementSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataEmptyStatementSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataEmptyStatementSymbol.Error(container, errorInfo, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceEmptyStatementSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourceEmptyStatementSymbol.Error(container, declaration, errorInfo, modelObject);
        }
	}
	public class ExpressionStatementSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataExpressionStatementSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataExpressionStatementSymbol.Error(container, errorInfo, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceExpressionStatementSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourceExpressionStatementSymbol.Error(container, declaration, errorInfo, modelObject);
        }
	}
	public class ForEachLoopStatementSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataForEachLoopStatementSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataForEachLoopStatementSymbol.Error(container, errorInfo, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceForEachLoopStatementSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourceForEachLoopStatementSymbol.Error(container, declaration, errorInfo, modelObject);
        }
	}
	public class ForLoopStatementSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataForLoopStatementSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataForLoopStatementSymbol.Error(container, errorInfo, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceForLoopStatementSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourceForLoopStatementSymbol.Error(container, declaration, errorInfo, modelObject);
        }
	}
	public class ForToLoopStatementSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataForToLoopStatementSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataForToLoopStatementSymbol.Error(container, errorInfo, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceForToLoopStatementSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourceForToLoopStatementSymbol.Error(container, declaration, errorInfo, modelObject);
        }
	}
	public class IfStatementSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataIfStatementSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataIfStatementSymbol.Error(container, errorInfo, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceIfStatementSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourceIfStatementSymbol.Error(container, declaration, errorInfo, modelObject);
        }
	}
	public class JumpStatementSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataJumpStatementSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataJumpStatementSymbol.Error(container, errorInfo, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceJumpStatementSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourceJumpStatementSymbol.Error(container, declaration, errorInfo, modelObject);
        }
	}
	public class LabelSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataLabelSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataLabelSymbol.Error(container, errorInfo, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceLabelSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourceLabelSymbol.Error(container, declaration, errorInfo, modelObject);
        }
	}
	public class LockStatementSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataLockStatementSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataLockStatementSymbol.Error(container, errorInfo, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceLockStatementSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourceLockStatementSymbol.Error(container, declaration, errorInfo, modelObject);
        }
	}
	public class ReturnStatementSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataReturnStatementSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataReturnStatementSymbol.Error(container, errorInfo, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceReturnStatementSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourceReturnStatementSymbol.Error(container, declaration, errorInfo, modelObject);
        }
	}
	public class SwitchCaseSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataSwitchCaseSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataSwitchCaseSymbol.Error(container, errorInfo, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceSwitchCaseSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourceSwitchCaseSymbol.Error(container, declaration, errorInfo, modelObject);
        }
	}
	public class SwitchStatementSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataSwitchStatementSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataSwitchStatementSymbol.Error(container, errorInfo, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceSwitchStatementSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourceSwitchStatementSymbol.Error(container, declaration, errorInfo, modelObject);
        }
	}
	public class TryStatementSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataTryStatementSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataTryStatementSymbol.Error(container, errorInfo, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceTryStatementSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourceTryStatementSymbol.Error(container, declaration, errorInfo, modelObject);
        }
	}
	public class UsingStatementSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataUsingStatementSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataUsingStatementSymbol.Error(container, errorInfo, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceUsingStatementSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourceUsingStatementSymbol.Error(container, declaration, errorInfo, modelObject);
        }
	}
	public class VariableSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataVariableSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataVariableSymbol.Error(container, errorInfo, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceVariableSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourceVariableSymbol.Error(container, declaration, errorInfo, modelObject);
        }
	}
	public class WhileLoopStatementSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataWhileLoopStatementSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataWhileLoopStatementSymbol.Error(container, errorInfo, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceWhileLoopStatementSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourceWhileLoopStatementSymbol.Error(container, declaration, errorInfo, modelObject);
        }
	}
	public class ArrayTypeSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataArrayTypeSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataArrayTypeSymbol.Error(container, errorInfo, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceArrayTypeSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourceArrayTypeSymbol.Error(container, declaration, errorInfo, modelObject);
        }
	}
	public class ClassTypeSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataClassTypeSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataClassTypeSymbol.Error(container, errorInfo, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceClassTypeSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourceClassTypeSymbol.Error(container, declaration, errorInfo, modelObject);
        }
	}
	public class DelegateTypeSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataDelegateTypeSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataDelegateTypeSymbol.Error(container, errorInfo, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceDelegateTypeSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourceDelegateTypeSymbol.Error(container, declaration, errorInfo, modelObject);
        }
	}
	public class EnumLiteralSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataEnumLiteralSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataEnumLiteralSymbol.Error(container, errorInfo, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceEnumLiteralSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourceEnumLiteralSymbol.Error(container, declaration, errorInfo, modelObject);
        }
	}
	public class EnumTypeSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataEnumTypeSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataEnumTypeSymbol.Error(container, errorInfo, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceEnumTypeSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourceEnumTypeSymbol.Error(container, declaration, errorInfo, modelObject);
        }
	}
	public class InterfaceTypeSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataInterfaceTypeSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataInterfaceTypeSymbol.Error(container, errorInfo, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceInterfaceTypeSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourceInterfaceTypeSymbol.Error(container, declaration, errorInfo, modelObject);
        }
	}
	public class NamedTypeSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataNamedTypeSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataNamedTypeSymbol.Error(container, errorInfo, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceNamedTypeSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourceNamedTypeSymbol.Error(container, declaration, errorInfo, modelObject);
        }
	}
	public class NullableTypeSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataNullableTypeSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataNullableTypeSymbol.Error(container, errorInfo, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceNullableTypeSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourceNullableTypeSymbol.Error(container, declaration, errorInfo, modelObject);
        }
	}
	public class PrimitiveTypeSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataPrimitiveTypeSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataPrimitiveTypeSymbol.Error(container, errorInfo, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourcePrimitiveTypeSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourcePrimitiveTypeSymbol.Error(container, declaration, errorInfo, modelObject);
        }
	}
	public class StructTypeSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataStructTypeSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataStructTypeSymbol.Error(container, errorInfo, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceStructTypeSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourceStructTypeSymbol.Error(container, declaration, errorInfo, modelObject);
        }
	}
	public class TupleTypeSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataTupleTypeSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataTupleTypeSymbol.Error(container, errorInfo, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceTupleTypeSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourceTupleTypeSymbol.Error(container, declaration, errorInfo, modelObject);
        }
	}
	public class TypeParameterSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateMetadataSymbol(Symbol container, object? modelObject)
        {
            return new Metadata.MetadataTypeParameterSymbol(container, modelObject);
        }

        public Symbol? CreateMetadataErrorSymbol(Symbol container, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Metadata.MetadataTypeParameterSymbol.Error(container, errorInfo, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, MergedDeclaration declaration, object? modelObject)
        {
            return new Source.SourceTypeParameterSymbol(container, declaration, modelObject);
        }

        public Symbol? CreateSourceErrorSymbol(Symbol container, MergedDeclaration declaration, object? modelObject, DiagnosticInfo errorInfo)
        {
            return new Source.SourceTypeParameterSymbol.Error(container, declaration, errorInfo, modelObject);
        }
	}
}
