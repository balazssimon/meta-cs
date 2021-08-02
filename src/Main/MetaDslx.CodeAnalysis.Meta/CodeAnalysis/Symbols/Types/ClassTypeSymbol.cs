using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [Symbol]
    public abstract partial class ClassTypeSymbol : NamedTypeSymbol
    {
        public override bool IsReferenceType => true;
    }
}
