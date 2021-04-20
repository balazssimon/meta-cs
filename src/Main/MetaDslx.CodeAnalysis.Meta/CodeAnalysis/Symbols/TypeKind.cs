using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    public class TypeKind : EnumObject
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
        /// Type is a class.
        /// </summary>
        public const string Class = nameof(Class);

        /// <summary>
        /// Type is a struct.
        /// </summary>
        public const string Struct = nameof(Struct);

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

        public const string NamedType = nameof(NamedType);

        protected TypeKind(string name)
            : base(name)
        {
        }

        protected TypeKind(EnumObject retargetedValue)
            : base(retargetedValue)
        {
        }

        static TypeKind()
        {
            EnumObject.RegisterDefault<TypeKind>(None);
            EnumObject.AutoInit<TypeKind>();
        }

        public static implicit operator TypeKind(string name)
        {
            return FromString<TypeKind>(name);
        }

        public static explicit operator TypeKind(int value)
        {
            return FromIntUnsafe<TypeKind>(value);
        }

        public Microsoft.CodeAnalysis.TypeKind ToCSharp()
        {
            return default;
        }
    }
}
