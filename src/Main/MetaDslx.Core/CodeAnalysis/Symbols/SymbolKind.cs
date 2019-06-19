using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols
{
    /// <summary>
    /// Specifies the possible kinds of symbols.
    /// </summary>
    public class LanguageSymbolKind : EnumObject
    {
        /// <summary>
        /// Symbol is an unknown symbol.
        /// </summary>
        public const string None = nameof(None);

        /// <summary>
        /// Symbol is an assembly.
        /// </summary>
        public const string Assembly = nameof(Assembly);

        /// <summary>
        /// Symbol is a netmodule.
        /// </summary>
        public const string NetModule = nameof(NetModule);

        /// <summary>
        /// Symbol is an alias.
        /// </summary>
        public const string Alias = nameof(Alias);

        /// <summary>
        /// Symbol is a namespace.
        /// </summary>
        public const string Namespace = nameof(Namespace);

        /// <summary>
        /// Symbol is a named type (e.g. class).
        /// </summary>
        public const string NamedType = nameof(NamedType);

        /// <summary>
        /// Symbol is a name without members.
        /// </summary>
        public const string Name = nameof(Name);

        /// <summary>
        /// Symbol is a property.
        /// </summary>
        public const string Property = nameof(Property);

        /// <summary>
        /// Symbol is an operation.
        /// </summary>
        public const string Operation = nameof(Operation);

        /// <summary>
        /// Symbol is a dynamic type.
        /// </summary>
        public const string DynamicType = nameof(DynamicType);

        /// <summary>
        /// Symbol is a constructed type that has no name.
        /// </summary>
        public const string ConstructedType = nameof(ConstructedType);

        /// <summary>
        /// Symbol that represents an error 
        /// </summary>
        public const string ErrorType = nameof(ErrorType);

        /// <summary>
        /// Discarded symbol, i.e. '_'
        /// </summary>
        public const string Discard = nameof(Discard);

        protected LanguageSymbolKind(string name)
            : base(name)
        {
        }

        protected LanguageSymbolKind(EnumObject retargetedValue)
            : base(retargetedValue)
        {
        }

        static LanguageSymbolKind()
        {
            EnumObject.RegisterDefault<LanguageSymbolKind>(None);
            EnumObject.AutoInit<LanguageSymbolKind>();
        }

        public static implicit operator LanguageSymbolKind(string name)
        {
            return FromString<LanguageSymbolKind>(name);
        }

        public static explicit operator LanguageSymbolKind(int value)
        {
            return FromIntUnsafe<LanguageSymbolKind>(value);
        }

    }
}
