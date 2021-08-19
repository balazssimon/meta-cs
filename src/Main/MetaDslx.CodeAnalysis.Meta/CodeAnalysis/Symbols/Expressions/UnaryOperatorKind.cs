using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public class UnaryOperatorKind
    {
        // IMPORTANT: make sure to keep the index values in sync with StandardUnaryOperatorSignatures
        public static readonly UnaryOperatorKind UnaryPlus = new UnaryOperatorKind(nameof(UnaryPlus), 0);
        public static readonly UnaryOperatorKind UnaryMinus = new UnaryOperatorKind(nameof(UnaryMinus), 1);
        public static readonly UnaryOperatorKind LogicalNegation = new UnaryOperatorKind(nameof(LogicalNegation), 2);
        public static readonly UnaryOperatorKind BitwiseComplement = new UnaryOperatorKind(nameof(BitwiseComplement), 3);
        public static readonly UnaryOperatorKind PrefixIncrement = new UnaryOperatorKind(nameof(PrefixIncrement), 4);
        public static readonly UnaryOperatorKind PostfixIncrement = new UnaryOperatorKind(nameof(PostfixIncrement), 5);
        public static readonly UnaryOperatorKind PrefixDecrement = new UnaryOperatorKind(nameof(PrefixDecrement), 6);
        public static readonly UnaryOperatorKind PostfixDecrement = new UnaryOperatorKind(nameof(PostfixDecrement), 7);

        private readonly string _name;
        private readonly int _index;

        public UnaryOperatorKind(string name)
        {
            _name = name;
            _index = -1;
        }

        private UnaryOperatorKind(string name, int index)
        {
            _name = name;
            _index = index;
        }

        public int StandardIndex => _index;

        public override string ToString()
        {
            return _name;
        }
    }
}
