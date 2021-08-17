using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [Symbol]
    public abstract partial class EnumLiteralSymbol : FieldLikeSymbol
    {
        public EnumTypeSymbol ContainingEnumType => this.ContainingType as EnumTypeSymbol;
        public sealed override TypeSymbol Type => this.ContainingEnumType;
    }
}
