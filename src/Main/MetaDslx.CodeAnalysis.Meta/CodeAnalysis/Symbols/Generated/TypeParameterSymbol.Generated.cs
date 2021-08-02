using Microsoft.CodeAnalysis;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Declarations;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Symbols.Metadata;
using MetaDslx.CodeAnalysis.Symbols.Source;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Symbols
{
	public abstract partial class TypeParameterSymbol
	{
        public override void Accept(MetaDslx.CodeAnalysis.Symbols.SymbolVisitor visitor)
        {
            if (visitor is ISymbolVisitor isv) isv.Visit(this);
        }

        public override TResult Accept<TResult>(MetaDslx.CodeAnalysis.Symbols.SymbolVisitor<TResult> visitor)
        {
            if (visitor is ISymbolVisitor<TResult> isv) return isv.Visit(this);
            else return default(TResult);
        }

        public override TResult Accept<TArgument, TResult>(MetaDslx.CodeAnalysis.Symbols.SymbolVisitor<TArgument, TResult> visitor, TArgument argument)
        {
            if (visitor is ISymbolVisitor<TArgument, TResult> isv) return isv.Visit(this, argument);
            else return default(TResult);
        }
	}
}
