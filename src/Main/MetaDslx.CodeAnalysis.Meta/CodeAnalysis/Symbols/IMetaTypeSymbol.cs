using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public interface IMetaTypeSymbol : ITypeSymbol
    {
        /// <summary>
        /// Gets the set of base types that this type directly inherits from. This set does not include
        /// base types that are base types of directly implemented base types.
        /// </summary>
        ImmutableArray<INamedTypeSymbol> BaseTypes { get; }

        /// <summary>
        /// The list of all base types of which this type is a declared subtype, excluding this type
        /// itself. This includes all declared base types, all declared base types of base
        /// types, and all declared base types of those results (recursively). Each result
        /// appears exactly once in the list. This list is topologically sorted by the inheritance
        /// relationship: if base type A extends base type B, then A precedes B in the
        /// list. This is not quite the same as "all base types of which this type is a proper
        /// subtype" because it does not take into account variance: AllBaseTypes for
        /// IEnumerable&lt;string&gt; will not include IEnumerable&lt;object&gt;.
        /// </summary>
        ImmutableArray<INamedTypeSymbol> AllBaseTypes { get; }

        /// <summary>
        /// Returns the corresponding symbol in this type or a base type that implements 
        /// baseMember (either implicitly or explicitly), or null if no such symbol exists
        /// (which might be either because this type doesn't implement the container of
        /// baseMember, or this type doesn't supply a member that successfully implements
        /// baseMember).
        /// </summary>
        /// <param name="baseMember">
        /// Must be a non-null property, method, or event.
        /// </param>
        ISymbol FindImplementationForBaseTypeMember(ISymbol baseMember);
    }
}
