using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public abstract class StructuralMemberSymbol : MemberSymbol
    {
        [SymbolProperty]
        public abstract TypeSymbol Type { get; }
    }
}
