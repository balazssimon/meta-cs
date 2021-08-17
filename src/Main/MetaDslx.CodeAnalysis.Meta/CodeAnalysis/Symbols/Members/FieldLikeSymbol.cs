using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public abstract class FieldLikeSymbol : MemberSymbol
    {
        [SymbolProperty]
        public abstract TypeSymbol Type { get; }
    }
}
