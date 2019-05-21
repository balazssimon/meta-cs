// !!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!
using System;
using MetaDslx.CodeAnalysis;
using Microsoft.CodeAnalysis;
using Roslyn.Utilities;

namespace MetaDslx.Bootstrap.Meta
{
    /// <summary>
    /// Specifies the language version.
    /// </summary>
    public class MetaLanguageVersion : LanguageVersion
    {
        /// <summary>
        /// Meta language version 1
        /// </summary>
        public const string Meta1 = nameof(Meta1);
        protected MetaLanguageVersion(string name)
            : base(name)
        {
        }
        protected MetaLanguageVersion(EnumObject retargetedValue)
            : base(retargetedValue)
        {
        }
        static MetaLanguageVersion()
        {
            EnumObject.AutoInit<MetaLanguageVersion>();
        }
        public static implicit operator MetaLanguageVersion(string name)
        {
            return FromString<MetaLanguageVersion>(name);
        }
        public static explicit operator MetaLanguageVersion(int value)
        {
            return FromIntUnsafe<MetaLanguageVersion>(value);
        }
        public override bool IsValid()
        {
            if (this == Meta1) return true;
            return false;
        }
        /// <summary>
        /// Map a language version (such as Default, Latest, or CSharpN) to a specific version (CSharpM).
        /// </summary>
        public override LanguageVersion MapSpecifiedToEffectiveVersion()
        {
            if (this == Latest || this == Default || this == LatestMajor || this == Preview)
            {
                return Meta1;
            }
            return this;
        }
        public override ErrorCode GetErrorCode()
        {
            switch (this.Switch())
            {
                case Meta1:
                    return MetaErrorCode.ERR_FeatureNotAvailableInVersion1;
                default:
                    throw ExceptionUtilities.UnexpectedValue(this);
            }
        }
    }
    public class MetaRequiredLanguageVersion : RequiredLanguageVersion
    {
        internal LanguageVersion Version { get; }
        internal MetaRequiredLanguageVersion(LanguageVersion version)
        {
            MetaLanguageVersion preview = MetaLanguageVersion.Preview;
            Version = (version == preview.MapSpecifiedToEffectiveVersion()) ? MetaLanguageVersion.Preview : version;
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
            if (version == MetaLanguageVersion.Meta1) return "1";
            if (version == MetaLanguageVersion.Default) return "default";
            if (version == MetaLanguageVersion.Latest) return "latest";
            if (version == MetaLanguageVersion.LatestMajor) return "latestmajor";
            if (version == MetaLanguageVersion.Preview) return "preview";
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
                    result = MetaLanguageVersion.Meta1;
                    return true;
                default:
                    result = LanguageVersion.Default;
                    return false;
            }
        }
        public static LanguageVersion CurrentVersion => MetaLanguageVersion.Meta1;
    }
}
