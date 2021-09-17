using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public class TypeWithAnnotations
    {
        private TypeSymbol? _type;

        private TypeWithAnnotations(TypeSymbol? type)
        {
            _type = type;
        }

        public bool HasType => _type is not null;

        public TypeSymbol? Type => _type;

        internal static TypeWithAnnotations Create(TypeSymbol? type)
        {
            return new TypeWithAnnotations(type);
        }

        internal bool Is(TypeParameterSymbol tp)
        {
            throw new NotImplementedException();
        }
    }
}
