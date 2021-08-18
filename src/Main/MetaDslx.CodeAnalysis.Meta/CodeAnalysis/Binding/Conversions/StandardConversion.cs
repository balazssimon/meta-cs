using MetaDslx.CodeAnalysis.Symbols;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Binding
{
    public class StandardConversion : Conversion
    {
        private string _name;
        private Flags _flags;

        public StandardConversion(string name, bool isImplicit)
        {
            _name = name;
            if (isImplicit) _flags |= Flags.Implicit;
        }

        public override bool IsImplicit => _flags.HasFlag(Flags.Implicit);

        public override ConversionOperatorSymbol? ConversionOperator => null;

        public override string ToString()
        {
            return _name;
        }

        [Flags]
        private enum Flags
        {
            Implicit,
            Nullable
        }
    }
}
