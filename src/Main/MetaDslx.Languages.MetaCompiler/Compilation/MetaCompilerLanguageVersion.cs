// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System;
using MetaDslx.CodeAnalysis;
using Microsoft.CodeAnalysis;
using Roslyn.Utilities;

namespace MetaDslx.Languages.MetaCompiler
{
    /// <summary>
    /// Specifies the language version.
    /// </summary>
    public class MetaCompilerLanguageVersion : LanguageVersion
    {
        /// <summary>
        /// MetaCompiler language version 1
        /// </summary>
        public const string MetaCompiler1 = nameof(MetaCompiler1);
        protected MetaCompilerLanguageVersion(string name)
            : base(name)
        {
        }
        protected MetaCompilerLanguageVersion(EnumObject retargetedValue)
            : base(retargetedValue)
        {
        }
        static MetaCompilerLanguageVersion()
        {
            EnumObject.AutoInit<MetaCompilerLanguageVersion>();
        }
        public static implicit operator MetaCompilerLanguageVersion(string name)
        {
            return FromString<MetaCompilerLanguageVersion>(name);
        }
        public static explicit operator MetaCompilerLanguageVersion(int value)
        {
            return FromIntUnsafe<MetaCompilerLanguageVersion>(value);
        }
        public override bool IsValid()
        {
            if (this == MetaCompiler1) return true;
            return false;
        }
        /// <summary>
        /// Map a language version (such as Default, Latest, or CSharpN) to a specific version (CSharpM).
        /// </summary>
        public override LanguageVersion MapSpecifiedToEffectiveVersion()
        {
            if (this == Latest || this == Default || this == LatestMajor || this == Preview)
            {
                return MetaCompiler1;
            }
            return this;
        }
        public override ErrorCode GetErrorCode()
        {
            switch (this.Switch())
            {
                case MetaCompiler1:
                    return MetaCompilerErrorCode.ERR_FeatureNotAvailableInVersion1;
                default:
                    throw ExceptionUtilities.UnexpectedValue(this);
            }
        }
    }
    public class MetaCompilerRequiredLanguageVersion : RequiredLanguageVersion
    {
        internal LanguageVersion Version { get; }
        internal MetaCompilerRequiredLanguageVersion(LanguageVersion version)
        {
            MetaCompilerLanguageVersion preview = MetaCompilerLanguageVersion.Preview;
            Version = (version == preview.MapSpecifiedToEffectiveVersion()) ? MetaCompilerLanguageVersion.Preview : version;
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
            if (version == MetaCompilerLanguageVersion.MetaCompiler1) return "1";
            if (version == MetaCompilerLanguageVersion.Default) return "default";
            if (version == MetaCompilerLanguageVersion.Latest) return "latest";
            if (version == MetaCompilerLanguageVersion.LatestMajor) return "latestmajor";
            if (version == MetaCompilerLanguageVersion.Preview) return "preview";
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
                    result = MetaCompilerLanguageVersion.MetaCompiler1;
                    return true;
                default:
                    result = LanguageVersion.Default;
                    return false;
            }
        }
        public static LanguageVersion CurrentVersion => MetaCompilerLanguageVersion.MetaCompiler1;
    }
}

