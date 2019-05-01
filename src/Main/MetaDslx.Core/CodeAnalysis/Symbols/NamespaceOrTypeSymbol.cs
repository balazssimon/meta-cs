using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public abstract class NamespaceOrTypeSymbol : Symbol, IMetaNamespaceOrTypeSymbol
    {
        /// <summary>
        /// Returns true if this symbol is a namespace. If it is not a namespace, it must be a type.
        /// </summary>
        public bool IsNamespace => Kind == SymbolKind.Namespace;

        /// <summary>
        /// Returns true if this symbols is a type. Equivalent to !IsNamespace.
        /// </summary>
        public bool IsType => !IsNamespace;

        bool INamespaceOrTypeSymbol.IsNamespace => this.IsNamespace;

        bool INamespaceOrTypeSymbol.IsType => this.IsType;

        /// <summary>
        /// Get all the members of this symbol.
        /// </summary>
        /// <returns>An ImmutableArray containing all the members of this symbol. If this symbol has no members,
        /// returns an empty ImmutableArray. Never returns null.</returns>
        public abstract ImmutableArray<Symbol> GetMembers();

        /// <summary>
        /// Get all the members of this symbol. The members may not be in a particular order, and the order
        /// may not be stable from call-to-call.
        /// </summary>
        /// <returns>An ImmutableArray containing all the members of this symbol. If this symbol has no members,
        /// returns an empty ImmutableArray. Never returns null.</returns>
        internal virtual ImmutableArray<Symbol> GetMembersUnordered()
        {
            // Default implementation is to use ordered version. When performance indicates, we specialize to have
            // separate implementation.

            return GetMembers().ConditionallyDeOrder();
        }

        /// <summary>
        /// Get all the members of this symbol that have a particular name.
        /// </summary>
        /// <returns>An ImmutableArray containing all the members of this symbol with the given name. If there are
        /// no members with this name, returns an empty ImmutableArray. Never returns null.</returns>
        public abstract ImmutableArray<Symbol> GetMembers(string name);

        /// <summary>
        /// Get all the members of this symbol that are types that have a particular name and arity
        /// </summary>
        /// <returns>An IEnumerable containing all the types that are members of this symbol with the given name and arity.
        /// If this symbol has no type members with this name and arity,
        /// returns an empty IEnumerable. Never returns null.</returns>
        public virtual ImmutableArray<Symbol> GetMembers(string name, string metadataName)
        {
            // default implementation does a post-filter. We can override this if its a performance burden, but 
            // experience is that it won't be.
            return GetMembers(name).WhereAsArray(m => m.MetadataName == metadataName);
        }

        /// <summary>
        /// Get all the members of this symbol that are types. The members may not be in a particular order, and the order
        /// may not be stable from call-to-call.
        /// </summary>
        /// <returns>An ImmutableArray containing all the types that are members of this symbol. If this symbol has no type members,
        /// returns an empty ImmutableArray. Never returns null.</returns>
        internal virtual ImmutableArray<NamedTypeSymbol> GetTypeMembersUnordered()
        {
            // Default implementation is to use ordered version. When performance indicates, we specialize to have
            // separate implementation.
            return GetTypeMembers().ConditionallyDeOrder();
        }

        /// <summary>
        /// Get all the members of this symbol that are types.
        /// </summary>
        /// <returns>An ImmutableArray containing all the types that are members of this symbol. If this symbol has no type members,
        /// returns an empty ImmutableArray. Never returns null.</returns>
        public abstract ImmutableArray<NamedTypeSymbol> GetTypeMembers();

        /// <summary>
        /// Get all the members of this symbol that are types that have a particular name, of any arity.
        /// </summary>
        /// <returns>An ImmutableArray containing all the types that are members of this symbol with the given name.
        /// If this symbol has no type members with this name,
        /// returns an empty ImmutableArray. Never returns null.</returns>
        public abstract ImmutableArray<NamedTypeSymbol> GetTypeMembers(string name);

        /// <summary>
        /// Get all the members of this symbol that are types that have a particular name and arity
        /// </summary>
        /// <returns>An IEnumerable containing all the types that are members of this symbol with the given name and arity.
        /// If this symbol has no type members with this name and arity,
        /// returns an empty IEnumerable. Never returns null.</returns>
        public virtual ImmutableArray<NamedTypeSymbol> GetTypeMembers(string name, string metadataName)
        {
            // default implementation does a post-filter. We can override this if its a performance burden, but 
            // experience is that it won't be.
            return GetTypeMembers(name).WhereAsArray(t => t.MetadataName == metadataName);
        }

        ImmutableArray<ISymbol> INamespaceOrTypeSymbol.GetMembers()
        {
            return StaticCast<ISymbol>.From(this.GetMembers());
        }

        ImmutableArray<ISymbol> INamespaceOrTypeSymbol.GetMembers(string name)
        {
            return StaticCast<ISymbol>.From(this.GetMembers(name));
        }

        ImmutableArray<ISymbol> IMetaNamespaceOrTypeSymbol.GetMembers(string name, string metadataName)
        {
            return StaticCast<ISymbol>.From(this.GetMembers(name, metadataName));
        }

        ImmutableArray<INamedTypeSymbol> INamespaceOrTypeSymbol.GetTypeMembers()
        {
            return StaticCast<INamedTypeSymbol>.From(this.GetTypeMembers());
        }

        ImmutableArray<INamedTypeSymbol> INamespaceOrTypeSymbol.GetTypeMembers(string name)
        {
            return StaticCast<INamedTypeSymbol>.From(this.GetTypeMembers(name));
        }

        ImmutableArray<INamedTypeSymbol> INamespaceOrTypeSymbol.GetTypeMembers(string name, int arity)
        {
            return StaticCast<INamedTypeSymbol>.From(this.GetTypeMembers(name, $"{name}`{arity}"));
        }

        ImmutableArray<INamedTypeSymbol> IMetaNamespaceOrTypeSymbol.GetTypeMembers(string name, string metadataName)
        {
            return StaticCast<INamedTypeSymbol>.From(this.GetTypeMembers(name, metadataName));
        }
    }
}
