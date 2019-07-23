using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public class LanguageTypeKind : EnumObject
    {
        /// <summary>
        /// Type is an unknown type.
        /// </summary>
        public const string None = nameof(None);

        /// <summary>
        /// Type is a module.
        /// </summary>
        public const string Module = nameof(Module);

        /// <summary>
        /// Type is a named type (e.g. class).
        /// </summary>
        public const string NamedType = nameof(NamedType);

        /// <summary>
        /// Type is an anonymous type.
        /// </summary>
        public const string AnonymousType = nameof(AnonymousType);

        /// <summary>
        /// Type is an enum.
        /// </summary>
        public const string Enum = nameof(Enum);

        /// <summary>
        /// Type is a value type.
        /// </summary>
        public const string Value = nameof(Value);

        /// <summary>
        /// Type is a dynamic type.
        /// </summary>
        public const string Dynamic = nameof(Dynamic);

        /// <summary>
        /// Type is a constructed type that has no name.
        /// </summary>
        public const string Constructed = nameof(Constructed);

        /// <summary>
        /// Type that represents a submission.
        /// </summary>
        public const string Submission = nameof(Submission);

        /// <summary>
        /// Type that represents an error.
        /// </summary>
        public const string Error = nameof(Error);

        protected LanguageTypeKind(string name)
            : base(name)
        {
        }

        protected LanguageTypeKind(EnumObject retargetedValue)
            : base(retargetedValue)
        {
        }

        static LanguageTypeKind()
        {
            EnumObject.RegisterDefault<LanguageTypeKind>(None);
            EnumObject.AutoInit<LanguageTypeKind>();
        }

        public static implicit operator LanguageTypeKind(string name)
        {
            return FromString<LanguageTypeKind>(name);
        }

        public static explicit operator LanguageTypeKind(int value)
        {
            return FromIntUnsafe<LanguageTypeKind>(value);
        }
    }
}
