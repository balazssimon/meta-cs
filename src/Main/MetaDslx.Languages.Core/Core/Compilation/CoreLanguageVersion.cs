// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System;
using Microsoft.CodeAnalysis;
using MetaDslx.CodeAnalysis;
using Roslyn.Utilities;

namespace MetaDslx.Languages.Core
{
    /// <summary>
    /// Specifies the language version.
    /// </summary>
    public class CoreLanguageVersion : LanguageVersion
    {
        /// <summary>
        /// Core language version 1
        /// </summary>
        public const string Core1 = nameof(Core1);
        protected CoreLanguageVersion(string name)
            : base(name)
        {
        }
        protected CoreLanguageVersion(EnumObject retargetedValue)
            : base(retargetedValue)
        {
        }
        static CoreLanguageVersion()
        {
            EnumObject.AutoInit<CoreLanguageVersion>();
        }
        public static implicit operator CoreLanguageVersion(string name)
        {
            return FromString<CoreLanguageVersion>(name);
        }
        public static explicit operator CoreLanguageVersion(int value)
        {
            return FromIntUnsafe<CoreLanguageVersion>(value);
        }
        public override bool IsValid()
        {
            if (this == Core1) return true;
            return false;
        }
        /// <summary>
        /// Map a language version (such as Default, Latest, or CSharpN) to a specific version (CSharpM).
        /// </summary>
        public override LanguageVersion MapSpecifiedToEffectiveVersion()
        {
            if (this == Latest || this == Default || this == LatestMajor || this == Preview)
            {
                return Core1;
            }
            return this;
        }
        public override ErrorCode GetErrorCode()
        {
            switch (this.Switch())
            {
                case Core1:
                    return CoreErrorCode.ERR_FeatureNotAvailableInVersion1;
                default:
                    throw ExceptionUtilities.UnexpectedValue(this);
            }
        }
    }
    public static class LanguageVersionFacts
    {
        /// <summary>
        /// Displays the version number in the format expected on the command-line (/langver flag).
        /// For instance, "6", "7", "7.1", "latest".
        /// </summary>
        public static string ToDisplayString(this LanguageVersion version)
        {
            if (version == CoreLanguageVersion.Core1) return "1";
            if (version == CoreLanguageVersion.Default) return "default";
            if (version == CoreLanguageVersion.Latest) return "latest";
            if (version == CoreLanguageVersion.LatestMajor) return "latestmajor";
            if (version == CoreLanguageVersion.Preview) return "preview";
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
                    result = CoreLanguageVersion.Core1;
                    return true;
                default:
                    result = LanguageVersion.Default;
                    return false;
            }
        }
        public static LanguageVersion CurrentVersion => CoreLanguageVersion.Core1;
    }
}

