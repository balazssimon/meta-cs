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
    /// <summary>
    /// Encapsulates information about the members of a source symbol.
    /// </summary>
    public sealed class Members
    {
        private readonly DeclaredSymbol _symbol;
        private readonly SymbolCompletionState _state;

        public readonly ImmutableArray<Symbol> NamedNonTypeMembers;
        public readonly ImmutableArray<NamedTypeSymbol> NamedTypeMembers;
        public readonly ImmutableArray<Symbol> AnonymousNonTypeMembers;
        public readonly ImmutableArray<NamedTypeSymbol> AnonymousTypeMembers;

        public Members(DeclaredSymbol symbol, SymbolCompletionState state,
            ImmutableArray<Symbol> nonTypeMembers, ImmutableArray<NamedTypeSymbol> typeMembers)
        {
            Debug.Assert(!nonTypeMembers.IsDefault);
            Debug.Assert(!typeMembers.IsDefault);
            Debug.Assert(!nonTypeMembers.Any(s => s is ITypeSymbol));
            Debug.Assert(!typeMembers.Any(s => !(s is ITypeSymbol)));
            _symbol = symbol;
            _state = state;
            this.NamedNonTypeMembers = nonTypeMembers.WhereAsArray(m => m.Name != null);
            this.NamedTypeMembers = typeMembers.WhereAsArray(m => m.Name != null);
            this.AnonymousNonTypeMembers = nonTypeMembers.WhereAsArray(m => m.Name == null);
            this.AnonymousTypeMembers = typeMembers.WhereAsArray(m => m.Name == null);
        }

        public ImmutableArray<NamespaceSymbol> NamespaceMembers => NamedNonTypeMembers.OfType<NamespaceSymbol>().ToImmutableArray();

        public ImmutableArray<Symbol> StaticMembers => NamedNonTypeMembers.Where(NamedTypeSymbol.IsStaticMember).ToImmutableArray();

        public ImmutableArray<Symbol> InstanceMembers => NamedNonTypeMembers.Where(NamedTypeSymbol.IsInstanceMember).ToImmutableArray();

        public ImmutableArray<Symbol> AllMembers
        {
            get
            {
                ArrayBuilder<Symbol> result = ArrayBuilder<Symbol>.GetInstance();
                result.AddRange(NamedNonTypeMembers);
                result.AddRange(NamedTypeMembers);
                result.AddRange(AnonymousNonTypeMembers);
                result.AddRange(AnonymousTypeMembers);
                return result.ToImmutableAndFree();
            }
        }
    }
}
