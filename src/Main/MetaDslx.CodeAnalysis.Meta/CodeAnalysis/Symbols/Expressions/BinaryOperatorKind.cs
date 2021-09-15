using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public class BinaryOperatorKind
    {
        // IMPORTANT: make sure to keep the index values in sync with StandardBinaryOperators
        public static readonly BinaryOperatorKind Multiplication = new BinaryOperatorKind(nameof(Multiplication), 0);
        public static readonly BinaryOperatorKind Addition = new BinaryOperatorKind(nameof(Addition), 1);
        public static readonly BinaryOperatorKind Subtraction = new BinaryOperatorKind(nameof(Subtraction), 2);
        public static readonly BinaryOperatorKind Division = new BinaryOperatorKind(nameof(Division), 3);
        public static readonly BinaryOperatorKind Remainder = new BinaryOperatorKind(nameof(Remainder), 4);
        public static readonly BinaryOperatorKind LeftShift = new BinaryOperatorKind(nameof(LeftShift), 5);
        public static readonly BinaryOperatorKind RightShift = new BinaryOperatorKind(nameof(RightShift), 6);
        public static readonly BinaryOperatorKind Equal = new BinaryOperatorKind(nameof(Equal), 7);
        public static readonly BinaryOperatorKind NotEqual = new BinaryOperatorKind(nameof(NotEqual), 8);
        public static readonly BinaryOperatorKind GreaterThan = new BinaryOperatorKind(nameof(GreaterThan), 9);
        public static readonly BinaryOperatorKind LessThan = new BinaryOperatorKind(nameof(LessThan), 10);
        public static readonly BinaryOperatorKind GreaterThanOrEqual = new BinaryOperatorKind(nameof(GreaterThanOrEqual), 11);
        public static readonly BinaryOperatorKind LessThanOrEqual = new BinaryOperatorKind(nameof(LessThanOrEqual), 12);
        public static readonly BinaryOperatorKind LogicalAnd = new BinaryOperatorKind(nameof(LogicalAnd), 13);
        public static readonly BinaryOperatorKind LogicalXor = new BinaryOperatorKind(nameof(LogicalXor), 14);
        public static readonly BinaryOperatorKind LogicalOr = new BinaryOperatorKind(nameof(LogicalOr), 15);
        public static readonly BinaryOperatorKind BitwiseAnd = new BinaryOperatorKind(nameof(BitwiseAnd), 16);
        public static readonly BinaryOperatorKind BitwiseXor = new BinaryOperatorKind(nameof(BitwiseXor), 17);
        public static readonly BinaryOperatorKind BitwiseOr = new BinaryOperatorKind(nameof(BitwiseOr), 18);
        public static readonly BinaryOperatorKind Range = new BinaryOperatorKind(nameof(Range), 19);

        private readonly string _name;
        private readonly int _index;

        public BinaryOperatorKind(string name)
        {
            _name = name;
            _index = -1;
        }

        private BinaryOperatorKind(string name, int index)
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
