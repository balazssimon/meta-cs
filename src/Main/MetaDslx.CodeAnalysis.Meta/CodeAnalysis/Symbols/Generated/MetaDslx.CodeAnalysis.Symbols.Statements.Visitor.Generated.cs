using Microsoft.CodeAnalysis;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Symbols;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;
using System.Threading;
namespace MetaDslx.CodeAnalysis.Symbols.Statements
{
	public interface ISymbolVisitor
	{
        void Visit(EmptyStatementSymbol symbol);
	}

	public interface ISymbolVisitor<TResult>
	{
        TResult Visit(EmptyStatementSymbol symbol);
	}

	public interface ISymbolVisitor<TArgument, TResult>
	{
        TResult Visit(EmptyStatementSymbol symbol, TArgument argument);
	}
}
