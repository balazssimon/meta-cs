// NOTE: This is an auto-generated file. However, it will not be regenerated. If you want it to be regenerated, just delete it.
using System;
using MetaDslx.CodeAnalysis;
using Microsoft.CodeAnalysis;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Antlr4.Test.Language.TestLanguageOne
{
    /// <summary>
    /// Specifies the language version.
    /// </summary>
    public class TestLangOneLanguageVersion : LanguageVersion
    {
        /// <summary>
        /// TestLangOne language version 1
        /// </summary>
        public const string TestLangOne1 = nameof(TestLangOne1);
        protected TestLangOneLanguageVersion(string name)
            : base(name)
        {
        }
        protected TestLangOneLanguageVersion(EnumObject retargetedValue)
            : base(retargetedValue)
        {
        }
        static TestLangOneLanguageVersion()
        {
            EnumObject.AutoInit<TestLangOneLanguageVersion>();
        }
        public static implicit operator TestLangOneLanguageVersion(string name)
        {
            return FromString<TestLangOneLanguageVersion>(name);
        }
        public static explicit operator TestLangOneLanguageVersion(int value)
        {
            return FromIntUnsafe<TestLangOneLanguageVersion>(value);
        }
        public override bool IsValid()
        {
            if (this == TestLangOne1) return true;
            return false;
        }
        /// <summary>
        /// Map a language version (such as Default, Latest, or CSharpN) to a specific version (CSharpM).
        /// </summary>
        public override LanguageVersion MapSpecifiedToEffectiveVersion()
        {
            if (this == Latest || this == Default || this == LatestMajor || this == Preview)
            {
                return TestLangOne1;
            }
            return this;
        }
        public override ErrorCode GetErrorCode()
        {
            switch (this.Switch())
            {
                case TestLangOne1:
                    return TestLangOneErrorCode.ERR_FeatureNotAvailableInVersion1;
                default:
                    throw ExceptionUtilities.UnexpectedValue(this);
            }
        }
    }
    public class TestLangOneRequiredLanguageVersion : RequiredLanguageVersion
    {
        internal LanguageVersion Version { get; }
        internal TestLangOneRequiredLanguageVersion(LanguageVersion version)
        {
            TestLangOneLanguageVersion preview = TestLangOneLanguageVersion.Preview;
            Version = (version == preview.MapSpecifiedToEffectiveVersion()) ? TestLangOneLanguageVersion.Preview : version;
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
            if (version == TestLangOneLanguageVersion.TestLangOne1) return "1";
            if (version == TestLangOneLanguageVersion.Default) return "default";
            if (version == TestLangOneLanguageVersion.Latest) return "latest";
            if (version == TestLangOneLanguageVersion.LatestMajor) return "latestmajor";
            if (version == TestLangOneLanguageVersion.Preview) return "preview";
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
                    result = TestLangOneLanguageVersion.TestLangOne1;
                    return true;
                default:
                    result = LanguageVersion.Default;
                    return false;
            }
        }
        public static LanguageVersion CurrentVersion => TestLangOneLanguageVersion.TestLangOne1;
    }
}

