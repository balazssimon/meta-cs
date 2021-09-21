using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Represents an indexer access.
    /// </summary>
    [Symbol]
    public abstract partial class IndexerAccessExpressionSymbol : ExpressionSymbol, IInvocation
    {
        /// <summary>
        /// The indexed operation.
        /// </summary>
        [SymbolProperty]
        public abstract ExpressionSymbol Receiver { get; }


        /// <summary>
        /// Indicates whether indexed access is null conditional (?[] operator)
        /// </summary>
        [SymbolProperty]
        public abstract bool IsNullConditional { get; }

        /// <summary>
        /// Arguments of the invocation, excluding the instance argument. Arguments are in evaluation order.
        /// </summary>
        /// <remarks>
        /// If the invocation is in its expanded form, then params/ParamArray arguments would be collected into arrays.
        /// Default values are supplied for optional arguments missing in source.
        /// </remarks>
        [SymbolProperty]
        public abstract ImmutableArray<ArgumentSymbol> Arguments { get; }

        /// <summary>
        /// Method or function to be invoked.
        /// </summary>
        [SymbolProperty]
        public virtual IndexerSymbol? Target { get; }

        public bool IsMethodInvocation => false;

        public bool IsPropertyInvocation => true;

        public override bool IsConstant => Receiver?.IsConstant ?? false;

        public override TypeSymbol? Type
        {
            get
            {
                if (Target is not null) return Target.GetMethod?.Result?.Type;
                if (Receiver?.Type is ArrayTypeSymbol arrayType) return arrayType.ElementType;
                return null;
            }
        }

    }
}
