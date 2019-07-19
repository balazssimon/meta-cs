using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public abstract class DeclaredSymbol : Symbol
    {
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

        /// <summary>
        /// Get a source symbol for the given declaration syntax.
        /// </summary>
        /// <returns>Null if there is no matching declaration.</returns>
        public DeclaredSymbol GetSourceMember(SyntaxNodeOrToken syntax)
        {
            foreach (var member in GetMembers())
            {
                var memberT = member as DeclaredSymbol;
                if ((object)memberT != null)
                {
                    if (syntax != null)
                    {
                        var locations = memberT.Locations;
                        if (locations.Length == 0)
                        {
                            foreach (var syntaxRef in memberT.DeclaringSyntaxReferences)
                            {
                                var loc = syntaxRef.GetLocation();
                                if (loc.IsInSource && loc.SourceTree == syntax.SyntaxTree && syntax.Span.Equals(loc.SourceSpan))
                                {
                                    return memberT;
                                }
                            }
                        }
                        foreach (var loc in locations)
                        {
                            if (loc.IsInSource && loc.SourceTree == syntax.SyntaxTree && syntax.Span.Equals(loc.SourceSpan))
                            {
                                return memberT;
                            }
                        }
                    }
                    else
                    {
                        return memberT;
                    }
                }
            }

            // None found.
            return null;
        }
    }
}
