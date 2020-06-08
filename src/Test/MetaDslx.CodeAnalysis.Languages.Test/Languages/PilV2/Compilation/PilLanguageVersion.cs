// NOTE: This is an auto-generated file. However, it will not be regenerated. If you want it to be regenerated, just delete it.
using System;
using MetaDslx.CodeAnalysis;
using Microsoft.CodeAnalysis;
using Roslyn.Utilities;

namespace PilV2
{
    /// <summary>
    /// Specifies the language version.
    /// </summary>
    public class PilLanguageVersion : LanguageVersion
    {
        /// <summary>
        /// Pil language version 1
        /// </summary>
        public const string Pil1 = nameof(Pil1);
        protected PilLanguageVersion(string name)
            : base(name)
        {
        }
        protected PilLanguageVersion(EnumObject retargetedValue)
            : base(retargetedValue)
        {
        }
        static PilLanguageVersion()
        {
            EnumObject.AutoInit<PilLanguageVersion>();
        }
        public static implicit operator PilLanguageVersion(string name)
        {
            return FromString<PilLanguageVersion>(name);
        }
        public static explicit operator PilLanguageVersion(int value)
        {
            return FromIntUnsafe<PilLanguageVersion>(value);
        }
        public override bool IsValid()
        {
            if (this == Pil1) return true;
            return false;
        }
        /// <summary>
        /// Map a language version (such as Default, Latest, or CSharpN) to a specific version (CSharpM).
        /// </summary>
        public override LanguageVersion MapSpecifiedToEffectiveVersion()
        {
            if (this == Latest || this == Default || this == LatestMajor || this == Preview)
            {
                return Pil1;
            }
            return this;
        }
        public override ErrorCode GetErrorCode()
        {
            switch (this.Switch())
            {
                case Pil1:
                    return PilErrorCode.ERR_FeatureNotAvailableInVersion1;
                default:
                    throw ExceptionUtilities.UnexpectedValue(this);
            }
        }
    }
    public class PilRequiredLanguageVersion : RequiredLanguageVersion
    {
        internal LanguageVersion Version { get; }
        internal PilRequiredLanguageVersion(LanguageVersion version)
        {
            PilLanguageVersion preview = PilLanguageVersion.Preview;
            Version = (version == preview.MapSpecifiedToEffectiveVersion()) ? PilLanguageVersion.Preview : version;
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
            if (version == PilLanguageVersion.Pil1) return "1";
            if (version == PilLanguageVersion.Default) return "default";
            if (version == PilLanguageVersion.Latest) return "latest";
            if (version == PilLanguageVersion.LatestMajor) return "latestmajor";
            if (version == PilLanguageVersion.Preview) return "preview";
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
                    result = PilLanguageVersion.Pil1;
                    return true;
                default:
                    result = LanguageVersion.Default;
                    return false;
            }
        }
        public static LanguageVersion CurrentVersion => PilLanguageVersion.Pil1;
    }
}

