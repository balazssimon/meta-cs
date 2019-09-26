using MetaDslx.CodeAnalysis.Declarations;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace MetaDslx.CodeAnalysis.Symbols.Source
{
    public class MembersBuilder
    {
        private readonly DeclaredSymbol _symbol;
        private readonly SymbolCompletionState _state;

        public MembersBuilder(DeclaredSymbol symbol, SymbolCompletionState state)
        {
            _symbol = symbol;
            _state = state;
        }

        public readonly ArrayBuilder<Symbol> NonTypeMembers = ArrayBuilder<Symbol>.GetInstance();
        public readonly ArrayBuilder<NamedTypeSymbol> TypeMembers = ArrayBuilder<NamedTypeSymbol>.GetInstance();

        public Members ToReadOnlyAndFree()
        {
            return new Members(_symbol, _state, NonTypeMembers.ToImmutableAndFree(), TypeMembers.ToImmutableAndFree());
        }

        public void Free()
        {
            NonTypeMembers.Free();
            TypeMembers.Free();
        }

    }

}
