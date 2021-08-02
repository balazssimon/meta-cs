using Microsoft.CodeAnalysis;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Symbols;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;
using System.Threading;
namespace MetaDslx.CodeAnalysis.Symbols
{
	public interface ISymbolVisitor
	{
        void Visit(ArrayTypeSymbol symbol);
        void Visit(AssemblySymbol symbol);
        void Visit(ClassTypeSymbol symbol);
        void Visit(ConstructorSymbol symbol);
        void Visit(DiscardSymbol symbol);
        void Visit(DynamicTypeSymbol symbol);
        void Visit(EnumLiteralSymbol symbol);
        void Visit(EnumTypeSymbol symbol);
        void Visit(ExpressionSymbol symbol);
        void Visit(InterfaceTypeSymbol symbol);
        void Visit(LabelSymbol symbol);
        void Visit(LocalVariableSymbol symbol);
        void Visit(MethodSymbol symbol);
        void Visit(ModuleSymbol symbol);
        void Visit(NamedTypeSymbol symbol);
        void Visit(NamespaceSymbol symbol);
        void Visit(NullableTypeSymbol symbol);
        void Visit(OperatorSymbol symbol);
        void Visit(ParameterSymbol symbol);
        void Visit(PropertySymbol symbol);
        void Visit(StatementSymbol symbol);
        void Visit(StructTypeSymbol symbol);
        void Visit(Symbol symbol);
        void Visit(TupleTypeSymbol symbol);
        void Visit(TypeParameterSymbol symbol);
        void Visit(TypeSymbol symbol);
        void Visit(AliasSymbol symbol);
	}

	public interface ISymbolVisitor<TResult>
	{
        TResult Visit(ArrayTypeSymbol symbol);
        TResult Visit(AssemblySymbol symbol);
        TResult Visit(ClassTypeSymbol symbol);
        TResult Visit(ConstructorSymbol symbol);
        TResult Visit(DiscardSymbol symbol);
        TResult Visit(DynamicTypeSymbol symbol);
        TResult Visit(EnumLiteralSymbol symbol);
        TResult Visit(EnumTypeSymbol symbol);
        TResult Visit(ExpressionSymbol symbol);
        TResult Visit(InterfaceTypeSymbol symbol);
        TResult Visit(LabelSymbol symbol);
        TResult Visit(LocalVariableSymbol symbol);
        TResult Visit(MethodSymbol symbol);
        TResult Visit(ModuleSymbol symbol);
        TResult Visit(NamedTypeSymbol symbol);
        TResult Visit(NamespaceSymbol symbol);
        TResult Visit(NullableTypeSymbol symbol);
        TResult Visit(OperatorSymbol symbol);
        TResult Visit(ParameterSymbol symbol);
        TResult Visit(PropertySymbol symbol);
        TResult Visit(StatementSymbol symbol);
        TResult Visit(StructTypeSymbol symbol);
        TResult Visit(Symbol symbol);
        TResult Visit(TupleTypeSymbol symbol);
        TResult Visit(TypeParameterSymbol symbol);
        TResult Visit(TypeSymbol symbol);
        TResult Visit(AliasSymbol symbol);
	}

	public interface ISymbolVisitor<TArgument, TResult>
	{
        TResult Visit(ArrayTypeSymbol symbol, TArgument argument);
        TResult Visit(AssemblySymbol symbol, TArgument argument);
        TResult Visit(ClassTypeSymbol symbol, TArgument argument);
        TResult Visit(ConstructorSymbol symbol, TArgument argument);
        TResult Visit(DiscardSymbol symbol, TArgument argument);
        TResult Visit(DynamicTypeSymbol symbol, TArgument argument);
        TResult Visit(EnumLiteralSymbol symbol, TArgument argument);
        TResult Visit(EnumTypeSymbol symbol, TArgument argument);
        TResult Visit(ExpressionSymbol symbol, TArgument argument);
        TResult Visit(InterfaceTypeSymbol symbol, TArgument argument);
        TResult Visit(LabelSymbol symbol, TArgument argument);
        TResult Visit(LocalVariableSymbol symbol, TArgument argument);
        TResult Visit(MethodSymbol symbol, TArgument argument);
        TResult Visit(ModuleSymbol symbol, TArgument argument);
        TResult Visit(NamedTypeSymbol symbol, TArgument argument);
        TResult Visit(NamespaceSymbol symbol, TArgument argument);
        TResult Visit(NullableTypeSymbol symbol, TArgument argument);
        TResult Visit(OperatorSymbol symbol, TArgument argument);
        TResult Visit(ParameterSymbol symbol, TArgument argument);
        TResult Visit(PropertySymbol symbol, TArgument argument);
        TResult Visit(StatementSymbol symbol, TArgument argument);
        TResult Visit(StructTypeSymbol symbol, TArgument argument);
        TResult Visit(Symbol symbol, TArgument argument);
        TResult Visit(TupleTypeSymbol symbol, TArgument argument);
        TResult Visit(TypeParameterSymbol symbol, TArgument argument);
        TResult Visit(TypeSymbol symbol, TArgument argument);
        TResult Visit(AliasSymbol symbol, TArgument argument);
	}
}
