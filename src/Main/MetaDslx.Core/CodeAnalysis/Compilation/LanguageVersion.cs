using Roslyn.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis
{
    public class LanguageVersion : EnumObject
    {
        /// <summary>
        /// The latest major supported version.
        /// </summary>
        public const string LatestMajor = nameof(LatestMajor);

        /// <summary>
        /// Preview of the next language version.
        /// </summary>
        public const string Preview = nameof(Preview);

        /// <summary>
        /// The latest supported version of the language.
        /// </summary>
        public const string Latest = nameof(Latest);

        /// <summary>
        /// The default language version, which is the latest supported version.
        /// </summary>
        public const string Default = nameof(Default);

        protected LanguageVersion(string name)
            : base(name)
        {
        }

        protected LanguageVersion(EnumObject retargetedValue)
            : base(retargetedValue)
        {
        }

        static LanguageVersion()
        {
            EnumObject.AutoInit<LanguageVersion>();
        }

        public static implicit operator LanguageVersion(string name)
        {
            return FromString<LanguageVersion>(name);
        }

        public static explicit operator LanguageVersion(int value)
        {
            return FromIntUnsafe<LanguageVersion>(value);
        }

        public virtual LanguageVersion MapSpecifiedToEffectiveVersion()
        {
            // TODO:MetaDslx
            return this;
        }

        public virtual bool IsValid()
        {
            // TODO:MetaDslx
            return true;
        }

        public virtual ErrorCode GetErrorCode()
        {
            // TODO:MetaDslx
            throw new NotImplementedException();
        }
    }
}
