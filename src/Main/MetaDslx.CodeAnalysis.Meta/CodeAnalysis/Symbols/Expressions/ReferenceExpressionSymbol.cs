using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Represents a non-member-access reference to a declared symbol.
    /// </summary>
    [Symbol]
    public abstract partial class ReferenceExpressionSymbol : ExpressionSymbol
    {
        /// <summary>
        /// If the reference is a member access, this is the type or instance of which the member is accessed.
        /// </summary>
        [SymbolProperty]
        public abstract ExpressionSymbol? Receiver { get; }

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
        /// True if this reference is also the declaration site of this variable. This is true in out variable declarations
        /// and in deconstruction operations where a new variable is being declared.
        /// </summary>
        [SymbolProperty]
        public abstract bool IsDeclaration { get; }

        /// <summary>
        /// Referenced symbol (e.g., a type, a variable or a member).
        /// </summary>
        public virtual DeclaredSymbol ReferencedSymbol { get; }

        /// <summary>
        /// The containing type of the referenced member, if different from type of the <see cref="Receiver" />.
        /// </summary>
        public virtual TypeSymbol? ContainingType { get; }

        public override bool IsInstanceReceiver => Receiver?.IsInstanceReceiver ?? !(ReferencedSymbol is TypeSymbol);

        public override bool IsStaticReceiver => ReferencedSymbol is TypeSymbol;
    }
}
