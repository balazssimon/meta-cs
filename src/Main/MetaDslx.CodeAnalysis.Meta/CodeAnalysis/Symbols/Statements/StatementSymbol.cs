using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [Symbol(SymbolParts = SymbolParts.None)]
    public abstract partial class StatementSymbol : NonDeclaredSymbol, ILocalDeclarator
    {
        private ImmutableArray<LocalSymbol> _declaredLocals;

        public ImmutableArray<LocalSymbol> DeclaredLocals
        {
            get
            {
                if (_declaredLocals.IsDefault)
                {
                    var result = ArrayBuilder<LocalSymbol>.GetInstance();
                    this.AddDeclaredLocals(result);
                    ImmutableInterlocked.InterlockedInitialize(ref _declaredLocals, result.ToImmutableAndFree());
                }
                return _declaredLocals;
            }
        }

        protected virtual void AddDeclaredLocals(ArrayBuilder<LocalSymbol> result)
        {
            foreach (var child in this.ChildSymbols)
            {
                if (child is ILocalDeclarator localDeclarator)
                {
                    result.AddRange(localDeclarator.DeclaredLocals);
                }
            }
        }

        protected virtual Location GetLocation()
        {
            return this.Locations.FirstOrNone();
        }
    }
}
