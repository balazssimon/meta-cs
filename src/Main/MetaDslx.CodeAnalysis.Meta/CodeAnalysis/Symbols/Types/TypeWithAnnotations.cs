using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public class TypeWithAnnotations
    {
        public bool HasType => true;

        public TypeSymbol? Type => null;

        internal static TypeWithAnnotations Create(TypeSymbol? type)
        {
            throw new NotImplementedException();
        }

        internal bool Is(TypeParameterSymbol tp)
        {
            throw new NotImplementedException();
        }
    }
}
