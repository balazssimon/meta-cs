using Microsoft.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Represents a <see cref="Body" /> of operations that are executed while using disposable <see cref="Resources" />.
    /// </summary>
    [Symbol]
    public abstract partial class UsingStatementSymbol : StatementSymbol
    {
        private ImmutableArray<LocalSymbol> _resourcesLocals;

        /// <summary>
        /// Declaration introduced or resource held by the using.
        /// </summary>
        [SymbolProperty]
        public abstract ImmutableArray<ExpressionSymbol> Resources { get; }

        /// <summary>
        /// Body of the using, over which the resources of the using are maintained.
        /// </summary>
        [SymbolProperty]
        public abstract StatementSymbol Body { get; }

        /// <summary>
        /// Locals declared within the <see cref="Resources" /> with scope spanning across this entire <see cref="UsingStatementSymbol" />.
        /// </summary>
        public virtual ImmutableArray<LocalSymbol> ResourcesLocals
        {
            get
            {
                if (_resourcesLocals.IsDefault)
                {
                    var result = ArrayBuilder<LocalSymbol>.GetInstance();
                    foreach (var resource in this.Resources)
                    {
                        result.AddRange(resource.DeclaredLocals);
                    }
                    ImmutableInterlocked.InterlockedInitialize(ref _resourcesLocals, result.ToImmutableAndFree());
                }
                return _resourcesLocals;
            }
        }
    }
}
