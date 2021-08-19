using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public class BinaryOperatorKind
    {
        public static readonly BinaryOperatorKind Multiplication = new BinaryOperatorKind(nameof(Multiplication));
        public static readonly BinaryOperatorKind Addition = new BinaryOperatorKind(nameof(Addition));
        public static readonly BinaryOperatorKind Subtraction = new BinaryOperatorKind(nameof(Subtraction));
        public static readonly BinaryOperatorKind Division = new BinaryOperatorKind(nameof(Division));
        public static readonly BinaryOperatorKind Remainder = new BinaryOperatorKind(nameof(Remainder));
        public static readonly BinaryOperatorKind LeftShift = new BinaryOperatorKind(nameof(LeftShift));
        public static readonly BinaryOperatorKind RightShift = new BinaryOperatorKind(nameof(RightShift));
        public static readonly BinaryOperatorKind Equal = new BinaryOperatorKind(nameof(Equal));
        public static readonly BinaryOperatorKind NotEqual = new BinaryOperatorKind(nameof(NotEqual));
        public static readonly BinaryOperatorKind GreaterThan = new BinaryOperatorKind(nameof(GreaterThan));
        public static readonly BinaryOperatorKind LessThan = new BinaryOperatorKind(nameof(LessThan));
        public static readonly BinaryOperatorKind GreaterThanOrEqual = new BinaryOperatorKind(nameof(GreaterThanOrEqual));
        public static readonly BinaryOperatorKind LessThanOrEqual = new BinaryOperatorKind(nameof(LessThanOrEqual));
        public static readonly BinaryOperatorKind LogicalAnd = new BinaryOperatorKind(nameof(LogicalAnd));
        public static readonly BinaryOperatorKind LogicalXor = new BinaryOperatorKind(nameof(LogicalXor));
        public static readonly BinaryOperatorKind LogicalOr = new BinaryOperatorKind(nameof(LogicalOr));
        public static readonly BinaryOperatorKind BitwiseAnd = new BinaryOperatorKind(nameof(BitwiseAnd));
        public static readonly BinaryOperatorKind BitwiseXor = new BinaryOperatorKind(nameof(BitwiseXor));
        public static readonly BinaryOperatorKind BitwiseOr = new BinaryOperatorKind(nameof(BitwiseOr));

        private readonly string _name;

        public BinaryOperatorKind(string name)
        {
            _name = name;
        }

        public override string ToString()
        {
            return _name;
        }
    }
}
