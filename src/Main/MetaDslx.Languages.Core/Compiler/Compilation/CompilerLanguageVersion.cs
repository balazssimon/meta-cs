// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System;
using Microsoft.CodeAnalysis;
using MetaDslx.CodeAnalysis;
using Roslyn.Utilities;

namespace MetaDslx.Languages.Compiler
{
    /// <summary>
    /// Specifies the language version.
    /// </summary>
    public class CompilerLanguageVersion : LanguageVersion
    {
        /// <summary>
        /// Compiler language version 1
        /// </summary>
        public const string Compiler1 = nameof(Compiler1);
        protected CompilerLanguageVersion(string name)
            : base(name)
        {
        }
        protected CompilerLanguageVersion(EnumObject retargetedValue)
            : base(retargetedValue)
        {
        }
        static CompilerLanguageVersion()
        {
            EnumObject.AutoInit<CompilerLanguageVersion>();
        }
        public static implicit operator CompilerLanguageVersion(string name)
        {
            return FromString<CompilerLanguageVersion>(name);
        }
        public static explicit operator CompilerLanguageVersion(int value)
        {
            return FromIntUnsafe<CompilerLanguageVersion>(value);
        }
        public override bool IsValid()
        {
            if (this == Compiler1) return true;
            return false;
        }
        /// <summary>
        /// Map a language version (such as Default, Latest, or CSharpN) to a specific version (CSharpM).
        /// </summary>
        public override LanguageVersion MapSpecifiedToEffectiveVersion()
        {
            if (this == Latest || this == Default || this == LatestMajor || this == Preview)
            {
                return Compiler1;
            }
            return this;
        }
        public override ErrorCode GetErrorCode()
        {
            switch (this.Switch())
            {
                case Compiler1:
                    return CompilerErrorCode.ERR_FeatureNotAvailableInVersion1;
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
            if (version == CompilerLanguageVersion.Compiler1) return "1";
            if (version == CompilerLanguageVersion.Default) return "default";
            if (version == CompilerLanguageVersion.Latest) return "latest";
            if (version == CompilerLanguageVersion.LatestMajor) return "latestmajor";
            if (version == CompilerLanguageVersion.Preview) return "preview";
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
                    result = CompilerLanguageVersion.Compiler1;
                    return true;
                default:
                    result = LanguageVersion.Default;
                    return false;
            }
        }
        public static LanguageVersion CurrentVersion => CompilerLanguageVersion.Compiler1;
    }
}

