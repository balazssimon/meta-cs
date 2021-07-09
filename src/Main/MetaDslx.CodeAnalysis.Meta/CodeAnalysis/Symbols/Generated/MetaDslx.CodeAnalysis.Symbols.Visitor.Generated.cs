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
        void Visit(AssemblySymbol symbol);
        void Visit(DiscardSymbol symbol);
        void Visit(ErrorTypeSymbol symbol);
        void Visit(ExpressionSymbol symbol);
        void Visit(LabelSymbol symbol);
        void Visit(LocalSymbol symbol);
        void Visit(MemberSymbol symbol);
        void Visit(ModuleSymbol symbol);
        void Visit(NamedTypeSymbol symbol);
        void Visit(NamespaceSymbol symbol);
        void Visit(ParameterSymbol symbol);
        void Visit(StatementSymbol symbol);
        void Visit(Symbol symbol);
        void Visit(TypeSymbol symbol);
        void Visit(AliasSymbol symbol);
	}

	public interface ISymbolVisitor<TResult>
	{
        TResult Visit(AssemblySymbol symbol);
        TResult Visit(DiscardSymbol symbol);
        TResult Visit(ErrorTypeSymbol symbol);
        TResult Visit(ExpressionSymbol symbol);
        TResult Visit(LabelSymbol symbol);
        TResult Visit(LocalSymbol symbol);
        TResult Visit(MemberSymbol symbol);
        TResult Visit(ModuleSymbol symbol);
        TResult Visit(NamedTypeSymbol symbol);
        TResult Visit(NamespaceSymbol symbol);
        TResult Visit(ParameterSymbol symbol);
        TResult Visit(StatementSymbol symbol);
        TResult Visit(Symbol symbol);
        TResult Visit(TypeSymbol symbol);
        TResult Visit(AliasSymbol symbol);
	}

	public interface ISymbolVisitor<TArgument, TResult>
	{
        TResult Visit(AssemblySymbol symbol, TArgument argument);
        TResult Visit(DiscardSymbol symbol, TArgument argument);
        TResult Visit(ErrorTypeSymbol symbol, TArgument argument);
        TResult Visit(ExpressionSymbol symbol, TArgument argument);
        TResult Visit(LabelSymbol symbol, TArgument argument);
        TResult Visit(LocalSymbol symbol, TArgument argument);
        TResult Visit(MemberSymbol symbol, TArgument argument);
        TResult Visit(ModuleSymbol symbol, TArgument argument);
        TResult Visit(NamedTypeSymbol symbol, TArgument argument);
        TResult Visit(NamespaceSymbol symbol, TArgument argument);
        TResult Visit(ParameterSymbol symbol, TArgument argument);
        TResult Visit(StatementSymbol symbol, TArgument argument);
        TResult Visit(Symbol symbol, TArgument argument);
        TResult Visit(TypeSymbol symbol, TArgument argument);
        TResult Visit(AliasSymbol symbol, TArgument argument);
	}
}
