using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [Symbol]
    public abstract partial class DestructorSymbol : BehavioralMemberSymbol
    {
        [SymbolProperty]
        public abstract StatementSymbol Body { get; }

    }
}
