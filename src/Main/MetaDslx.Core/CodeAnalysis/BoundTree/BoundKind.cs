using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.BoundTree
{
    public class BoundKind : EnumObject
    {
        public const string Node = nameof(Node);
        public const string BadSymbol = nameof(BadSymbol);
        public const string BadExpression = nameof(BadExpression);
        public const string BadStatement = nameof(BadStatement);
        public const string Symbol = nameof(Symbol);
        public const string Expression = nameof(Expression);
        public const string Statement = nameof(Statement);

        protected BoundKind(string name)
            : base(name)
        {
        }

        protected BoundKind(EnumObject retargetedValue)
            : base(retargetedValue)
        {
        }

        static BoundKind()
        {
            EnumObject.AutoInit<BoundKind>();
        }

        public static implicit operator BoundKind(string name)
        {
            return FromString<BoundKind>(name);
        }

        public static explicit operator BoundKind(int value)
        {
            return FromIntUnsafe<BoundKind>(value);
        }

    }

}
