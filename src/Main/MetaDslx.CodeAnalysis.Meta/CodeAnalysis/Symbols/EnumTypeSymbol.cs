using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    [Symbol]
    public abstract partial class EnumTypeSymbol : NamedTypeSymbol
    {
        private ImmutableArray<EnumLiteralSymbol> _literals;

        public override bool IsValueType => true;

        public ImmutableArray<EnumLiteralSymbol> Literals
        {
            get
            {
                if (_literals.IsDefault)
                {
                    ImmutableInterlocked.InterlockedInitialize(ref _literals, this.Members.OfType<EnumLiteralSymbol>().ToImmutableArray());
                }
                return _literals;
            }
        }
    }
}
