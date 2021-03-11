using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public class MemberKind : EnumObject
    {
        /// <summary>
        /// Member is an unknown member.
        /// </summary>
        public const string None = nameof(None);

        /// <summary>
        /// Member is a field.
        /// </summary>
        public const string Field = nameof(Field);

        /// <summary>
        /// Member is a property with implicit getter-setter operations.
        /// </summary>
        public const string Property = nameof(Property);

        /// <summary>
        /// Member is an event.
        /// </summary>
        public const string Event = nameof(Event);

        /// <summary>
        /// Member is a method.
        /// </summary>
        public const string Method = nameof(Method);

        protected MemberKind(string name)
            : base(name)
        {
        }

        protected MemberKind(EnumObject retargetedValue)
            : base(retargetedValue)
        {
        }

        static MemberKind()
        {
            EnumObject.RegisterDefault<MemberKind>(None);
            EnumObject.AutoInit<MemberKind>();
        }

        public static implicit operator MemberKind(string name)
        {
            return FromString<MemberKind>(name);
        }

        public static explicit operator MemberKind(int value)
        {
            return FromIntUnsafe<MemberKind>(value);
        }
    }

}
