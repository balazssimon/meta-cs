using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public class StatementKind : EnumObject
    {
        /// <summary>
        /// Statement is an unknown statement.
        /// </summary>
        public const string None = nameof(None);

        protected StatementKind(string name)
            : base(name)
        {
        }

        protected StatementKind(EnumObject retargetedValue)
            : base(retargetedValue)
        {
        }

        static StatementKind()
        {
            EnumObject.RegisterDefault<StatementKind>(None);
            EnumObject.AutoInit<StatementKind>();
        }

        public static implicit operator StatementKind(string name)
        {
            return FromString<StatementKind>(name);
        }

        public static explicit operator StatementKind(int value)
        {
            return FromIntUnsafe<StatementKind>(value);
        }
    }
}
