using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [Symbol]
    public abstract partial class EnumLiteralSymbol : MemberSymbol
    {
        public EnumTypeSymbol ContainingEnumType => this.ContainingType as EnumTypeSymbol;
        public TypeSymbol Type => this.ContainingEnumType;
    }
}
