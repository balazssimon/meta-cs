using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Represents a reference to a member of a class, struct, or interface.
    /// </summary>
    [Symbol]
    public abstract partial class MemberReferenceExpressionSymbol : ExpressionSymbol
    {
        /// <summary>
        /// Instance of the type. Null if the reference is to a static/shared member.
        /// </summary>
        [SymbolProperty]
        public abstract ExpressionSymbol? Instance { get; }

        /// <summary>
        /// Referenced member.
        /// </summary>
        [SymbolProperty]
        public abstract string MemberName { get; }

        /// <summary>
        /// Indicates whether member access is null conditional (?. operator)
        /// </summary>
        [SymbolProperty]
        public abstract bool IsNullConditional { get; }

        /// <summary>
        /// Type arguments.
        /// </summary>
        [SymbolProperty]
        public abstract ImmutableArray<TypeSymbol> TypeArguments { get; }

        /// <summary>
        /// Referenced member.
        /// </summary>
        public virtual MemberSymbol Member { get; }

        /// <summary>
        /// The containing type of the referenced member, if different from type of the <see cref="Instance" />.
        /// </summary>
        public virtual TypeSymbol? ContainingType { get; }
    }
}
