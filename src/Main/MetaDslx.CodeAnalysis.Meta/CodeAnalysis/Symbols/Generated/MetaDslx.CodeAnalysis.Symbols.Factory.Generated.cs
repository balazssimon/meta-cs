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
	public class DefaultExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorDefaultExpressionSymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataDefaultExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceDefaultExpressionSymbol(container, modelObject, declaration);
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
	public class IndexerExpressionSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorIndexerExpressionSymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataIndexerExpressionSymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceIndexerExpressionSymbol(container, modelObject, declaration);
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
	public class LocalVariableSymbolFactory : IGeneratedSymbolFactory
	{
        public Symbol? CreateErrorSymbol(Symbol? container, object? modelObject, MergedDeclaration? declaration)
        {
            return new Error.ErrorLocalVariableSymbol(container, modelObject, declaration);
        }

        public Symbol? CreateMetadataSymbol(Symbol container, object modelObject)
        {
            return new Metadata.MetadataLocalVariableSymbol(container, modelObject);
        }

        public Symbol? CreateSourceSymbol(Symbol container, object modelObject, MergedDeclaration declaration)
        {
            return new Source.SourceLocalVariableSymbol(container, modelObject, declaration);
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
