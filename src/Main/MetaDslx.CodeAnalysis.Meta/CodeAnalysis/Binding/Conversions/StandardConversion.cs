using MetaDslx.CodeAnalysis.Symbols;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding
{
    public class StandardConversion : Conversion
    {
        private Flags _flags;

        public StandardConversion(bool isImplicit)
        {
            if (isImplicit) _flags |= Flags.Implicit;
        }

        public override bool IsImplicit => _flags.HasFlag(Flags.Implicit);

        public override ConversionOperatorSymbol? ConversionOperator => null;

        [Flags]
        private enum Flags
        {
            Implicit,
            Nullable
        }
    }
}
