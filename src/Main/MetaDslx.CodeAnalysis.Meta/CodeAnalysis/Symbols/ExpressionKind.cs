using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public class ExpressionKind : EnumObject
    {
        /// <summary>
        /// Expression is an unknown expression.
        /// </summary>
        public const string None = nameof(None);

        protected ExpressionKind(string name)
            : base(name)
        {
        }

        protected ExpressionKind(EnumObject retargetedValue)
            : base(retargetedValue)
        {
        }

        static ExpressionKind()
        {
            EnumObject.RegisterDefault<ExpressionKind>(None);
            EnumObject.AutoInit<ExpressionKind>();
        }

        public static implicit operator ExpressionKind(string name)
        {
            return FromString<ExpressionKind>(name);
        }

        public static explicit operator ExpressionKind(int value)
        {
            return FromIntUnsafe<ExpressionKind>(value);
        }
    }

}
