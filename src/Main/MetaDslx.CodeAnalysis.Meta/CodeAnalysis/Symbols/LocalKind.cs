using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public class LocalKind : EnumObject
    {
        /// <summary>
        /// Local name is an unknown name.
        /// </summary>
        public const string None = nameof(None);

        public const string Label = nameof(Label);

        public const string Parameter = nameof(Parameter);

        protected LocalKind(string name)
            : base(name)
        {
        }

        protected LocalKind(EnumObject retargetedValue)
            : base(retargetedValue)
        {
        }

        static LocalKind()
        {
            EnumObject.RegisterDefault<LocalKind>(None);
            EnumObject.AutoInit<LocalKind>();
        }

        public static implicit operator LocalKind(string name)
        {
            return FromString<LocalKind>(name);
        }

        public static explicit operator LocalKind(int value)
        {
            return FromIntUnsafe<LocalKind>(value);
        }
    }
}
