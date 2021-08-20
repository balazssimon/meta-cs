using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public abstract partial class FieldLikeSymbol : MemberSymbol
    {
        [SymbolProperty]
        public abstract TypeSymbol Type { get; }
    }
}
