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
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorArgumentSymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataArgumentSymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceArgumentSymbol(container, modelObject, declaration);
        }
	}
	public class AssignmentExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorAssignmentExpressionSymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataAssignmentExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceAssignmentExpressionSymbol(container, modelObject, declaration);
        }
	}
	public class AwaitExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorAwaitExpressionSymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataAwaitExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceAwaitExpressionSymbol(container, modelObject, declaration);
        }
	}
	public class BinaryExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorBinaryExpressionSymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataBinaryExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceBinaryExpressionSymbol(container, modelObject, declaration);
        }
	}
	public class CoalesceExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorCoalesceExpressionSymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataCoalesceExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceCoalesceExpressionSymbol(container, modelObject, declaration);
        }
	}
	public class CompoundAssignmentExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorCompoundAssignmentExpressionSymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataCompoundAssignmentExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceCompoundAssignmentExpressionSymbol(container, modelObject, declaration);
        }
	}
	public class ConditionalExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorConditionalExpressionSymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataConditionalExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceConditionalExpressionSymbol(container, modelObject, declaration);
        }
	}
	public class ConversionExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorConversionExpressionSymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataConversionExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceConversionExpressionSymbol(container, modelObject, declaration);
        }
	}
	public class DefaultValueExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorDefaultValueExpressionSymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataDefaultValueExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceDefaultValueExpressionSymbol(container, modelObject, declaration);
        }
	}
	public class DiscardExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorDiscardExpressionSymbol(container, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataDiscardExpressionSymbol(container);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceDiscardExpressionSymbol(container, declaration);
        }
	}
	public class DynamicExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorDynamicExpressionSymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataDynamicExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceDynamicExpressionSymbol(container, modelObject, declaration);
        }
	}
	public class IncrementOrDecrementExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorIncrementOrDecrementExpressionSymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataIncrementOrDecrementExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceIncrementOrDecrementExpressionSymbol(container, modelObject, declaration);
        }
	}
	public class IndexerAccessExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorIndexerAccessExpressionSymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataIndexerAccessExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceIndexerAccessExpressionSymbol(container, modelObject, declaration);
        }
	}
	public class InstanceReferenceExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorInstanceReferenceExpressionSymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataInstanceReferenceExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceInstanceReferenceExpressionSymbol(container, modelObject, declaration);
        }
	}
	public class InvocationExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorInvocationExpressionSymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataInvocationExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceInvocationExpressionSymbol(container, modelObject, declaration);
        }
	}
	public class IsTypeExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorIsTypeExpressionSymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataIsTypeExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceIsTypeExpressionSymbol(container, modelObject, declaration);
        }
	}
	public class LambdaExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorLambdaExpressionSymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataLambdaExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceLambdaExpressionSymbol(container, modelObject, declaration);
        }
	}
	public class LiteralExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorLiteralExpressionSymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataLiteralExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceLiteralExpressionSymbol(container, modelObject, declaration);
        }
	}
	public class MemberReferenceExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorMemberReferenceExpressionSymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataMemberReferenceExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceMemberReferenceExpressionSymbol(container, modelObject, declaration);
        }
	}
	public class NameOfExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorNameOfExpressionSymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataNameOfExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceNameOfExpressionSymbol(container, modelObject, declaration);
        }
	}
	public class ObjectCreationExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorObjectCreationExpressionSymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataObjectCreationExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceObjectCreationExpressionSymbol(container, modelObject, declaration);
        }
	}
	public class ParenthesizedExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorParenthesizedExpressionSymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataParenthesizedExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceParenthesizedExpressionSymbol(container, modelObject, declaration);
        }
	}
	public class ReferenceExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorReferenceExpressionSymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataReferenceExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceReferenceExpressionSymbol(container, modelObject, declaration);
        }
	}
	public class SizeOfExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorSizeOfExpressionSymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataSizeOfExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceSizeOfExpressionSymbol(container, modelObject, declaration);
        }
	}
	public class ThrowExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorThrowExpressionSymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataThrowExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceThrowExpressionSymbol(container, modelObject, declaration);
        }
	}
	public class TupleExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorTupleExpressionSymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataTupleExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceTupleExpressionSymbol(container, modelObject, declaration);
        }
	}
	public class TypeOfExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorTypeOfExpressionSymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataTypeOfExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceTypeOfExpressionSymbol(container, modelObject, declaration);
        }
	}
	public class UnaryExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorUnaryExpressionSymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataUnaryExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceUnaryExpressionSymbol(container, modelObject, declaration);
        }
	}
	public class VariableDeclarationExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorVariableDeclarationExpressionSymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataVariableDeclarationExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceVariableDeclarationExpressionSymbol(container, modelObject, declaration);
        }
	}
	public class VariableDeclarationGroupExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorVariableDeclarationGroupExpressionSymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataVariableDeclarationGroupExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceVariableDeclarationGroupExpressionSymbol(container, modelObject, declaration);
        }
	}
	public class BinaryOperatorSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorBinaryOperatorSymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataBinaryOperatorSymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceBinaryOperatorSymbol(container, modelObject, declaration);
        }
	}
	public class ConstructorSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorConstructorSymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataConstructorSymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceConstructorSymbol(container, modelObject, declaration);
        }
	}
	public class ConversionOperatorSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorConversionOperatorSymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataConversionOperatorSymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceConversionOperatorSymbol(container, modelObject, declaration);
        }
	}
	public class DestructorSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorDestructorSymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataDestructorSymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceDestructorSymbol(container, modelObject, declaration);
        }
	}
	public class FieldSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorFieldSymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataFieldSymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceFieldSymbol(container, modelObject, declaration);
        }
	}
	public class IndexerSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorIndexerSymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataIndexerSymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceIndexerSymbol(container, modelObject, declaration);
        }
	}
	public class LambdaSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorLambdaSymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataLambdaSymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceLambdaSymbol(container, modelObject, declaration);
        }
	}
	public class MemberSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorMemberSymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataMemberSymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceMemberSymbol(container, modelObject, declaration);
        }
	}
	public class MethodSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorMethodSymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataMethodSymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceMethodSymbol(container, modelObject, declaration);
        }
	}
	public class ParameterSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorParameterSymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataParameterSymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceParameterSymbol(container, modelObject, declaration);
        }
	}
	public class PropertySymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorPropertySymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataPropertySymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourcePropertySymbol(container, modelObject, declaration);
        }
	}
	public class UnaryOperatorSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorUnaryOperatorSymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataUnaryOperatorSymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceUnaryOperatorSymbol(container, modelObject, declaration);
        }
	}
	public class AliasSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorAliasSymbol(container, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            throw new NotImplementedException("CreateMetadataSymbol for MetadataAliasSymbol should be implemented in a custom SymbolFactory.");
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceAliasSymbol(container, declaration);
        }
	}
	public class NamespaceSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorNamespaceSymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataNamespaceSymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            throw new NotImplementedException("CreateSourceSymbol for SourceNamespaceSymbol should be implemented in a custom SymbolFactory.");
        }
	}
	public class BlockStatementSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorBlockStatementSymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataBlockStatementSymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceBlockStatementSymbol(container, modelObject, declaration);
        }
	}
	public class CatchClauseSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorCatchClauseSymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataCatchClauseSymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceCatchClauseSymbol(container, modelObject, declaration);
        }
	}
	public class DefaultCaseClauseSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorDefaultCaseClauseSymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataDefaultCaseClauseSymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceDefaultCaseClauseSymbol(container, modelObject, declaration);
        }
	}
	public class EmptyStatementSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorEmptyStatementSymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataEmptyStatementSymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceEmptyStatementSymbol(container, modelObject, declaration);
        }
	}
	public class ExpressionStatementSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorExpressionStatementSymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataExpressionStatementSymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceExpressionStatementSymbol(container, modelObject, declaration);
        }
	}
	public class ForEachLoopStatementSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorForEachLoopStatementSymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataForEachLoopStatementSymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceForEachLoopStatementSymbol(container, modelObject, declaration);
        }
	}
	public class ForLoopStatementSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorForLoopStatementSymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataForLoopStatementSymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceForLoopStatementSymbol(container, modelObject, declaration);
        }
	}
	public class ForToLoopStatementSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorForToLoopStatementSymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataForToLoopStatementSymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceForToLoopStatementSymbol(container, modelObject, declaration);
        }
	}
	public class IfStatementSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorIfStatementSymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataIfStatementSymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceIfStatementSymbol(container, modelObject, declaration);
        }
	}
	public class JumpStatementSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorJumpStatementSymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataJumpStatementSymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceJumpStatementSymbol(container, modelObject, declaration);
        }
	}
	public class LabelSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorLabelSymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataLabelSymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceLabelSymbol(container, modelObject, declaration);
        }
	}
	public class LockStatementSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorLockStatementSymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataLockStatementSymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceLockStatementSymbol(container, modelObject, declaration);
        }
	}
	public class ReturnStatementSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorReturnStatementSymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataReturnStatementSymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceReturnStatementSymbol(container, modelObject, declaration);
        }
	}
	public class SwitchCaseSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorSwitchCaseSymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataSwitchCaseSymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceSwitchCaseSymbol(container, modelObject, declaration);
        }
	}
	public class SwitchStatementSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorSwitchStatementSymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataSwitchStatementSymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceSwitchStatementSymbol(container, modelObject, declaration);
        }
	}
	public class TryStatementSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorTryStatementSymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataTryStatementSymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceTryStatementSymbol(container, modelObject, declaration);
        }
	}
	public class UsingStatementSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorUsingStatementSymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataUsingStatementSymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceUsingStatementSymbol(container, modelObject, declaration);
        }
	}
	public class VariableSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorVariableSymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataVariableSymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceVariableSymbol(container, modelObject, declaration);
        }
	}
	public class WhileLoopStatementSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorWhileLoopStatementSymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataWhileLoopStatementSymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceWhileLoopStatementSymbol(container, modelObject, declaration);
        }
	}
	public class ArrayTypeSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorArrayTypeSymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataArrayTypeSymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceArrayTypeSymbol(container, modelObject, declaration);
        }
	}
	public class ClassTypeSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorClassTypeSymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataClassTypeSymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceClassTypeSymbol(container, modelObject, declaration);
        }
	}
	public class DelegateTypeSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorDelegateTypeSymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataDelegateTypeSymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceDelegateTypeSymbol(container, modelObject, declaration);
        }
	}
	public class EnumLiteralSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorEnumLiteralSymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataEnumLiteralSymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceEnumLiteralSymbol(container, modelObject, declaration);
        }
	}
	public class EnumTypeSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorEnumTypeSymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataEnumTypeSymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceEnumTypeSymbol(container, modelObject, declaration);
        }
	}
	public class InterfaceTypeSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorInterfaceTypeSymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataInterfaceTypeSymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceInterfaceTypeSymbol(container, modelObject, declaration);
        }
	}
	public class NamedTypeSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorNamedTypeSymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataNamedTypeSymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceNamedTypeSymbol(container, modelObject, declaration);
        }
	}
	public class NullableTypeSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorNullableTypeSymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataNullableTypeSymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceNullableTypeSymbol(container, modelObject, declaration);
        }
	}
	public class StructTypeSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorStructTypeSymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataStructTypeSymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceStructTypeSymbol(container, modelObject, declaration);
        }
	}
	public class TupleTypeSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorTupleTypeSymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataTupleTypeSymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceTupleTypeSymbol(container, modelObject, declaration);
        }
	}
	public class TypeParameterSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorTypeParameterSymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataTypeParameterSymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceTypeParameterSymbol(container, modelObject, declaration);
        }
	}
}
