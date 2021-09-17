﻿using Microsoft.CodeAnalysis;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Symbols;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;
using System.Threading;

#nullable enable

namespace MetaDslx.CodeAnalysis.Symbols
{
	public interface ISymbolVisitor
	{
        void Visit(Symbol symbol);
        void Visit(AssemblySymbol symbol);
        void Visit(AttributeSymbol symbol);
        void Visit(ArgumentSymbol symbol);
        void Visit(ExpressionSymbol symbol);
        void Visit(AssignmentExpressionSymbol symbol);
        void Visit(AwaitExpressionSymbol symbol);
        void Visit(BinaryExpressionSymbol symbol);
        void Visit(CoalesceExpressionSymbol symbol);
        void Visit(CompoundAssignmentExpressionSymbol symbol);
        void Visit(ConditionalExpressionSymbol symbol);
        void Visit(ConversionExpressionSymbol symbol);
        void Visit(DefaultValueExpressionSymbol symbol);
        void Visit(DiscardExpressionSymbol symbol);
        void Visit(DynamicExpressionSymbol symbol);
        void Visit(IndexerAccessExpressionSymbol symbol);
        void Visit(InstanceReferenceExpressionSymbol symbol);
        void Visit(InvocationExpressionSymbol symbol);
        void Visit(IsTypeExpressionSymbol symbol);
        void Visit(LambdaExpressionSymbol symbol);
        void Visit(LiteralExpressionSymbol symbol);
        void Visit(NameOfExpressionSymbol symbol);
        void Visit(NullForgivingExpressionSymbol symbol);
        void Visit(ObjectCreationExpressionSymbol symbol);
        void Visit(ParenthesizedExpressionSymbol symbol);
        void Visit(ReferenceExpressionSymbol symbol);
        void Visit(SizeOfExpressionSymbol symbol);
        void Visit(ThrowExpressionSymbol symbol);
        void Visit(TupleExpressionSymbol symbol);
        void Visit(TypeOfExpressionSymbol symbol);
        void Visit(UnaryExpressionSymbol symbol);
        void Visit(VariableDeclarationExpressionSymbol symbol);
        void Visit(VariableSymbol symbol);
        void Visit(MemberSymbol symbol);
        void Visit(BinaryOperatorSymbol symbol);
        void Visit(ConstructorSymbol symbol);
        void Visit(ConversionOperatorSymbol symbol);
        void Visit(DestructorSymbol symbol);
        void Visit(FieldSymbol symbol);
        void Visit(FunctionSymbol symbol);
        void Visit(PropertySymbol symbol);
        void Visit(IndexerSymbol symbol);
        void Visit(LambdaSymbol symbol);
        void Visit(MethodSymbol symbol);
        void Visit(ParameterSymbol symbol);
        void Visit(UnaryOperatorSymbol symbol);
        void Visit(ModuleSymbol symbol);
        void Visit(AliasSymbol symbol);
        void Visit(NamespaceSymbol symbol);
        void Visit(StatementSymbol symbol);
        void Visit(BlockStatementSymbol symbol);
        void Visit(CatchClauseSymbol symbol);
        void Visit(DefaultCaseClauseSymbol symbol);
        void Visit(EmptyStatementSymbol symbol);
        void Visit(ExpressionStatementSymbol symbol);
        void Visit(ForEachLoopStatementSymbol symbol);
        void Visit(ForLoopStatementSymbol symbol);
        void Visit(ForToLoopStatementSymbol symbol);
        void Visit(IfStatementSymbol symbol);
        void Visit(JumpStatementSymbol symbol);
        void Visit(LabeledStatementSymbol symbol);
        void Visit(LabelSymbol symbol);
        void Visit(LockStatementSymbol symbol);
        void Visit(ReturnStatementSymbol symbol);
        void Visit(SingleValueCaseClauseSymbol symbol);
        void Visit(SwitchCaseSymbol symbol);
        void Visit(SwitchStatementSymbol symbol);
        void Visit(TryStatementSymbol symbol);
        void Visit(UsingStatementSymbol symbol);
        void Visit(WhileLoopStatementSymbol symbol);
        void Visit(TypeSymbol symbol);
        void Visit(ArrayTypeSymbol symbol);
        void Visit(NamedTypeSymbol symbol);
        void Visit(ClassTypeSymbol symbol);
        void Visit(CollectionTypeSymbol symbol);
        void Visit(DelegateTypeSymbol symbol);
        void Visit(DictionaryTypeSymbol symbol);
        void Visit(DynamicTypeSymbol symbol);
        void Visit(EnumLiteralSymbol symbol);
        void Visit(EnumTypeSymbol symbol);
        void Visit(GenericTypeReferenceTypeSymbol symbol);
        void Visit(InterfaceTypeSymbol symbol);
        void Visit(NullableTypeSymbol symbol);
        void Visit(PrimitiveTypeSymbol symbol);
        void Visit(StructTypeSymbol symbol);
        void Visit(TupleTypeSymbol symbol);
        void Visit(TypeParameterSymbol symbol);
	}

	public interface ISymbolVisitor<TResult>
	{
        TResult Visit(Symbol symbol);
        TResult Visit(AssemblySymbol symbol);
        TResult Visit(AttributeSymbol symbol);
        TResult Visit(ArgumentSymbol symbol);
        TResult Visit(ExpressionSymbol symbol);
        TResult Visit(AssignmentExpressionSymbol symbol);
        TResult Visit(AwaitExpressionSymbol symbol);
        TResult Visit(BinaryExpressionSymbol symbol);
        TResult Visit(CoalesceExpressionSymbol symbol);
        TResult Visit(CompoundAssignmentExpressionSymbol symbol);
        TResult Visit(ConditionalExpressionSymbol symbol);
        TResult Visit(ConversionExpressionSymbol symbol);
        TResult Visit(DefaultValueExpressionSymbol symbol);
        TResult Visit(DiscardExpressionSymbol symbol);
        TResult Visit(DynamicExpressionSymbol symbol);
        TResult Visit(IndexerAccessExpressionSymbol symbol);
        TResult Visit(InstanceReferenceExpressionSymbol symbol);
        TResult Visit(InvocationExpressionSymbol symbol);
        TResult Visit(IsTypeExpressionSymbol symbol);
        TResult Visit(LambdaExpressionSymbol symbol);
        TResult Visit(LiteralExpressionSymbol symbol);
        TResult Visit(NameOfExpressionSymbol symbol);
        TResult Visit(NullForgivingExpressionSymbol symbol);
        TResult Visit(ObjectCreationExpressionSymbol symbol);
        TResult Visit(ParenthesizedExpressionSymbol symbol);
        TResult Visit(ReferenceExpressionSymbol symbol);
        TResult Visit(SizeOfExpressionSymbol symbol);
        TResult Visit(ThrowExpressionSymbol symbol);
        TResult Visit(TupleExpressionSymbol symbol);
        TResult Visit(TypeOfExpressionSymbol symbol);
        TResult Visit(UnaryExpressionSymbol symbol);
        TResult Visit(VariableDeclarationExpressionSymbol symbol);
        TResult Visit(VariableSymbol symbol);
        TResult Visit(MemberSymbol symbol);
        TResult Visit(BinaryOperatorSymbol symbol);
        TResult Visit(ConstructorSymbol symbol);
        TResult Visit(ConversionOperatorSymbol symbol);
        TResult Visit(DestructorSymbol symbol);
        TResult Visit(FieldSymbol symbol);
        TResult Visit(FunctionSymbol symbol);
        TResult Visit(PropertySymbol symbol);
        TResult Visit(IndexerSymbol symbol);
        TResult Visit(LambdaSymbol symbol);
        TResult Visit(MethodSymbol symbol);
        TResult Visit(ParameterSymbol symbol);
        TResult Visit(UnaryOperatorSymbol symbol);
        TResult Visit(ModuleSymbol symbol);
        TResult Visit(AliasSymbol symbol);
        TResult Visit(NamespaceSymbol symbol);
        TResult Visit(StatementSymbol symbol);
        TResult Visit(BlockStatementSymbol symbol);
        TResult Visit(CatchClauseSymbol symbol);
        TResult Visit(DefaultCaseClauseSymbol symbol);
        TResult Visit(EmptyStatementSymbol symbol);
        TResult Visit(ExpressionStatementSymbol symbol);
        TResult Visit(ForEachLoopStatementSymbol symbol);
        TResult Visit(ForLoopStatementSymbol symbol);
        TResult Visit(ForToLoopStatementSymbol symbol);
        TResult Visit(IfStatementSymbol symbol);
        TResult Visit(JumpStatementSymbol symbol);
        TResult Visit(LabeledStatementSymbol symbol);
        TResult Visit(LabelSymbol symbol);
        TResult Visit(LockStatementSymbol symbol);
        TResult Visit(ReturnStatementSymbol symbol);
        TResult Visit(SingleValueCaseClauseSymbol symbol);
        TResult Visit(SwitchCaseSymbol symbol);
        TResult Visit(SwitchStatementSymbol symbol);
        TResult Visit(TryStatementSymbol symbol);
        TResult Visit(UsingStatementSymbol symbol);
        TResult Visit(WhileLoopStatementSymbol symbol);
        TResult Visit(TypeSymbol symbol);
        TResult Visit(ArrayTypeSymbol symbol);
        TResult Visit(NamedTypeSymbol symbol);
        TResult Visit(ClassTypeSymbol symbol);
        TResult Visit(CollectionTypeSymbol symbol);
        TResult Visit(DelegateTypeSymbol symbol);
        TResult Visit(DictionaryTypeSymbol symbol);
        TResult Visit(DynamicTypeSymbol symbol);
        TResult Visit(EnumLiteralSymbol symbol);
        TResult Visit(EnumTypeSymbol symbol);
        TResult Visit(GenericTypeReferenceTypeSymbol symbol);
        TResult Visit(InterfaceTypeSymbol symbol);
        TResult Visit(NullableTypeSymbol symbol);
        TResult Visit(PrimitiveTypeSymbol symbol);
        TResult Visit(StructTypeSymbol symbol);
        TResult Visit(TupleTypeSymbol symbol);
        TResult Visit(TypeParameterSymbol symbol);
	}

	public interface ISymbolVisitor<TArgument, TResult>
	{
        TResult Visit(Symbol symbol, TArgument argument);
        TResult Visit(AssemblySymbol symbol, TArgument argument);
        TResult Visit(AttributeSymbol symbol, TArgument argument);
        TResult Visit(ArgumentSymbol symbol, TArgument argument);
        TResult Visit(ExpressionSymbol symbol, TArgument argument);
        TResult Visit(AssignmentExpressionSymbol symbol, TArgument argument);
        TResult Visit(AwaitExpressionSymbol symbol, TArgument argument);
        TResult Visit(BinaryExpressionSymbol symbol, TArgument argument);
        TResult Visit(CoalesceExpressionSymbol symbol, TArgument argument);
        TResult Visit(CompoundAssignmentExpressionSymbol symbol, TArgument argument);
        TResult Visit(ConditionalExpressionSymbol symbol, TArgument argument);
        TResult Visit(ConversionExpressionSymbol symbol, TArgument argument);
        TResult Visit(DefaultValueExpressionSymbol symbol, TArgument argument);
        TResult Visit(DiscardExpressionSymbol symbol, TArgument argument);
        TResult Visit(DynamicExpressionSymbol symbol, TArgument argument);
        TResult Visit(IndexerAccessExpressionSymbol symbol, TArgument argument);
        TResult Visit(InstanceReferenceExpressionSymbol symbol, TArgument argument);
        TResult Visit(InvocationExpressionSymbol symbol, TArgument argument);
        TResult Visit(IsTypeExpressionSymbol symbol, TArgument argument);
        TResult Visit(LambdaExpressionSymbol symbol, TArgument argument);
        TResult Visit(LiteralExpressionSymbol symbol, TArgument argument);
        TResult Visit(NameOfExpressionSymbol symbol, TArgument argument);
        TResult Visit(NullForgivingExpressionSymbol symbol, TArgument argument);
        TResult Visit(ObjectCreationExpressionSymbol symbol, TArgument argument);
        TResult Visit(ParenthesizedExpressionSymbol symbol, TArgument argument);
        TResult Visit(ReferenceExpressionSymbol symbol, TArgument argument);
        TResult Visit(SizeOfExpressionSymbol symbol, TArgument argument);
        TResult Visit(ThrowExpressionSymbol symbol, TArgument argument);
        TResult Visit(TupleExpressionSymbol symbol, TArgument argument);
        TResult Visit(TypeOfExpressionSymbol symbol, TArgument argument);
        TResult Visit(UnaryExpressionSymbol symbol, TArgument argument);
        TResult Visit(VariableDeclarationExpressionSymbol symbol, TArgument argument);
        TResult Visit(VariableSymbol symbol, TArgument argument);
        TResult Visit(MemberSymbol symbol, TArgument argument);
        TResult Visit(BinaryOperatorSymbol symbol, TArgument argument);
        TResult Visit(ConstructorSymbol symbol, TArgument argument);
        TResult Visit(ConversionOperatorSymbol symbol, TArgument argument);
        TResult Visit(DestructorSymbol symbol, TArgument argument);
        TResult Visit(FieldSymbol symbol, TArgument argument);
        TResult Visit(FunctionSymbol symbol, TArgument argument);
        TResult Visit(PropertySymbol symbol, TArgument argument);
        TResult Visit(IndexerSymbol symbol, TArgument argument);
        TResult Visit(LambdaSymbol symbol, TArgument argument);
        TResult Visit(MethodSymbol symbol, TArgument argument);
        TResult Visit(ParameterSymbol symbol, TArgument argument);
        TResult Visit(UnaryOperatorSymbol symbol, TArgument argument);
        TResult Visit(ModuleSymbol symbol, TArgument argument);
        TResult Visit(AliasSymbol symbol, TArgument argument);
        TResult Visit(NamespaceSymbol symbol, TArgument argument);
        TResult Visit(StatementSymbol symbol, TArgument argument);
        TResult Visit(BlockStatementSymbol symbol, TArgument argument);
        TResult Visit(CatchClauseSymbol symbol, TArgument argument);
        TResult Visit(DefaultCaseClauseSymbol symbol, TArgument argument);
        TResult Visit(EmptyStatementSymbol symbol, TArgument argument);
        TResult Visit(ExpressionStatementSymbol symbol, TArgument argument);
        TResult Visit(ForEachLoopStatementSymbol symbol, TArgument argument);
        TResult Visit(ForLoopStatementSymbol symbol, TArgument argument);
        TResult Visit(ForToLoopStatementSymbol symbol, TArgument argument);
        TResult Visit(IfStatementSymbol symbol, TArgument argument);
        TResult Visit(JumpStatementSymbol symbol, TArgument argument);
        TResult Visit(LabeledStatementSymbol symbol, TArgument argument);
        TResult Visit(LabelSymbol symbol, TArgument argument);
        TResult Visit(LockStatementSymbol symbol, TArgument argument);
        TResult Visit(ReturnStatementSymbol symbol, TArgument argument);
        TResult Visit(SingleValueCaseClauseSymbol symbol, TArgument argument);
        TResult Visit(SwitchCaseSymbol symbol, TArgument argument);
        TResult Visit(SwitchStatementSymbol symbol, TArgument argument);
        TResult Visit(TryStatementSymbol symbol, TArgument argument);
        TResult Visit(UsingStatementSymbol symbol, TArgument argument);
        TResult Visit(WhileLoopStatementSymbol symbol, TArgument argument);
        TResult Visit(TypeSymbol symbol, TArgument argument);
        TResult Visit(ArrayTypeSymbol symbol, TArgument argument);
        TResult Visit(NamedTypeSymbol symbol, TArgument argument);
        TResult Visit(ClassTypeSymbol symbol, TArgument argument);
        TResult Visit(CollectionTypeSymbol symbol, TArgument argument);
        TResult Visit(DelegateTypeSymbol symbol, TArgument argument);
        TResult Visit(DictionaryTypeSymbol symbol, TArgument argument);
        TResult Visit(DynamicTypeSymbol symbol, TArgument argument);
        TResult Visit(EnumLiteralSymbol symbol, TArgument argument);
        TResult Visit(EnumTypeSymbol symbol, TArgument argument);
        TResult Visit(GenericTypeReferenceTypeSymbol symbol, TArgument argument);
        TResult Visit(InterfaceTypeSymbol symbol, TArgument argument);
        TResult Visit(NullableTypeSymbol symbol, TArgument argument);
        TResult Visit(PrimitiveTypeSymbol symbol, TArgument argument);
        TResult Visit(StructTypeSymbol symbol, TArgument argument);
        TResult Visit(TupleTypeSymbol symbol, TArgument argument);
        TResult Visit(TypeParameterSymbol symbol, TArgument argument);
	}
}
