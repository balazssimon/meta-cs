using Microsoft.CodeAnalysis;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Symbols;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;
using System.Threading;

#nullable enable

namespace MetaDslx.Languages.Meta.Symbols
{
	public interface ISymbolVisitor
	{
        void Visit(AssociationSymbol symbol);
	}

	public interface ISymbolVisitor<TResult>
	{
        TResult Visit(AssociationSymbol symbol);
	}

	public interface ISymbolVisitor<TArgument, TResult>
	{
        TResult Visit(AssociationSymbol symbol, TArgument argument);
	}
}
