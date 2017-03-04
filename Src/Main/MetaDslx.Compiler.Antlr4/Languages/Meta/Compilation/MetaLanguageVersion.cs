// !!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!
using System;

namespace MetaDslx.Languages.Meta
{
    /// <summary>
    /// Specifies the language version.
    /// </summary>
    public enum LanguageVersion
    {
        /// <summary>
        /// Meta language version 1.0.
        /// </summary>
        Meta1 = 1,
    }

    internal static partial class LanguageVersionExtensions
    {
        internal static bool IsValid(this LanguageVersion value)
        {
            return value >= LanguageVersion.Meta1 && value <= LanguageVersion.Meta1;
        }

        internal static object Localize(this LanguageVersion value)
        {
            return (int)value;
        }

        internal static MetaErrorCode GetErrorCode(this LanguageVersion version)
        {
            switch (version)
            {
                case LanguageVersion.Meta1:
                    return MetaErrorCode.ERR_FeatureNotAvailableInVersion1;
                default:
                    throw new ArgumentOutOfRangeException(nameof(version), "Unexpected value: "+version);
            }
        }
    }
}

