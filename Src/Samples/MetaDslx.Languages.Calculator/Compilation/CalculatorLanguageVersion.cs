using System;

namespace MetaDslx.Languages.Calculator
{
    /// <summary>
    /// Specifies the language version.
    /// </summary>
    public enum LanguageVersion
    {
        /// <summary>
        /// Calculator language version 1.0.
        /// </summary>
        Calculator1 = 1,
    }

    internal static partial class LanguageVersionExtensions
    {
        internal static bool IsValid(this LanguageVersion value)
        {
            return value >= LanguageVersion.Calculator1 && value <= LanguageVersion.Calculator1;
        }

        internal static object Localize(this LanguageVersion value)
        {
            return (int)value;
        }

        internal static ErrorCode GetErrorCode(this LanguageVersion version)
        {
            switch (version)
            {
                case LanguageVersion.Calculator1:
                    return ErrorCode.ERR_FeatureNotAvailableInVersion1;
                default:
                    throw new ArgumentOutOfRangeException(nameof(version), "Unexpected value: "+version);
            }
        }
    }
}

