// NOTE: This is an auto-generated file. However, it will not be regenerated. If you want it to be regenerated, just delete it.
using System;
using MetaDslx.CodeAnalysis;
using Microsoft.CodeAnalysis;
using Roslyn.Utilities;

namespace MetaDslx.Languages.Soal
{
    /// <summary>
    /// Specifies the language version.
    /// </summary>
    public class SoalLanguageVersion : LanguageVersion
    {
        /// <summary>
        /// Soal language version 1
        /// </summary>
        public const string Soal1 = nameof(Soal1);
        protected SoalLanguageVersion(string name)
            : base(name)
        {
        }
        protected SoalLanguageVersion(EnumObject retargetedValue)
            : base(retargetedValue)
        {
        }
        static SoalLanguageVersion()
        {
            EnumObject.AutoInit<SoalLanguageVersion>();
        }
        public static implicit operator SoalLanguageVersion(string name)
        {
            return FromString<SoalLanguageVersion>(name);
        }
        public static explicit operator SoalLanguageVersion(int value)
        {
            return FromIntUnsafe<SoalLanguageVersion>(value);
        }
        public override bool IsValid()
        {
            if (this == Soal1) return true;
            return false;
        }
        /// <summary>
        /// Map a language version (such as Default, Latest, or CSharpN) to a specific version (CSharpM).
        /// </summary>
        public override LanguageVersion MapSpecifiedToEffectiveVersion()
        {
            if (this == Latest || this == Default || this == LatestMajor || this == Preview)
            {
                return Soal1;
            }
            return this;
        }
        public override ErrorCode GetErrorCode()
        {
            switch (this.Switch())
            {
                case Soal1:
                    return SoalErrorCode.ERR_FeatureNotAvailableInVersion1;
                default:
                    throw ExceptionUtilities.UnexpectedValue(this);
            }
        }
    }
    public class SoalRequiredLanguageVersion : RequiredLanguageVersion
    {
        internal LanguageVersion Version { get; }
        internal SoalRequiredLanguageVersion(LanguageVersion version)
        {
            SoalLanguageVersion preview = SoalLanguageVersion.Preview;
            Version = (version == preview.MapSpecifiedToEffectiveVersion()) ? SoalLanguageVersion.Preview : version;
        }
        public override string ToString() => Version.ToDisplayString();
    }
    public static class LanguageVersionFacts
    {
        /// <summary>
        /// Displays the version number in the format expected on the command-line (/langver flag).
        /// For instance, "6", "7", "7.1", "latest".
        /// </summary>
        public static string ToDisplayString(this LanguageVersion version)
        {
            if (version == SoalLanguageVersion.Soal1) return "1";
            if (version == SoalLanguageVersion.Default) return "default";
            if (version == SoalLanguageVersion.Latest) return "latest";
            if (version == SoalLanguageVersion.LatestMajor) return "latestmajor";
            if (version == SoalLanguageVersion.Preview) return "preview";
            throw ExceptionUtilities.UnexpectedValue(version);
        }
        /// <summary>
        /// Try parse a <see cref="LanguageVersion"/> from a string input, returning default if input was null.
        /// </summary>
        public static bool TryParse(string version, out LanguageVersion result)
        {
            if (version == null)
            {
                result = LanguageVersion.Default;
                return true;
            }
            switch (CaseInsensitiveComparison.ToLower(version))
            {
                case "default":
                    result = LanguageVersion.Default;
                    return true;
                case "latest":
                    result = LanguageVersion.Latest;
                    return true;
                case "latestmajor":
                    result = LanguageVersion.LatestMajor;
                    return true;
                case "preview":
                    result = LanguageVersion.Preview;
                    return true;
                case "1":
                case "1.0":
                    result = SoalLanguageVersion.Soal1;
                    return true;
                default:
                    result = LanguageVersion.Default;
                    return false;
            }
        }
        public static LanguageVersion CurrentVersion => SoalLanguageVersion.Soal1;
    }
}

