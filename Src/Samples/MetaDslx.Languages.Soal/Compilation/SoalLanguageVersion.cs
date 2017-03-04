// !!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!
using System;

namespace MetaDslx.Languages.Soal
{
    /// <summary>
    /// Specifies the language version.
    /// </summary>
    public enum LanguageVersion
    {
        /// <summary>
        /// Soal language version 1.0.
        /// </summary>
        Soal1 = 1,
    }

    internal static partial class LanguageVersionExtensions
    {
        internal static bool IsValid(this LanguageVersion value)
        {
            return value >= LanguageVersion.Soal1 && value <= LanguageVersion.Soal1;
        }

        internal static object Localize(this LanguageVersion value)
        {
            return (int)value;
        }

        internal static SoalErrorCode GetErrorCode(this LanguageVersion version)
        {
            switch (version)
            {
                case LanguageVersion.Soal1:
                    return SoalErrorCode.ERR_FeatureNotAvailableInVersion1;
                default:
                    throw new ArgumentOutOfRangeException(nameof(version), "Unexpected value: "+version);
            }
        }
    }
}

