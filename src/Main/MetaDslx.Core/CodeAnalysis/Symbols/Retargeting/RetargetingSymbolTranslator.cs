using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using Microsoft.CodeAnalysis;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public class RetargetingSymbolTranslator
    {
        public virtual T Retarget<T>(T symbol)
            where T: Symbol
        {
            return symbol;
        }

        public virtual ImmutableArray<T> Retarget<T>(ImmutableArray<T> symbols)
            where T: Symbol
        {
            return symbols;
        }

        public virtual T Retarget<T>(T symbol, RetargetOptions options)
            where T : Symbol
        {
            throw new NotImplementedException("TODO:MetaDslx");
        }

        public virtual ImmutableArray<T> Retarget<T>(ImmutableArray<T> symbols, RetargetOptions options)
            where T : Symbol
        {
            throw new NotImplementedException("TODO:MetaDslx");
        }

        internal ImmutableArray<AttributeData> GetRetargetedAttributes(ImmutableArray<AttributeData> immutableArray, ref ImmutableArray<AttributeData> lazyCustomAttributes)
        {
            throw new NotImplementedException("TODO:MetaDslx");
        }
    }
}
