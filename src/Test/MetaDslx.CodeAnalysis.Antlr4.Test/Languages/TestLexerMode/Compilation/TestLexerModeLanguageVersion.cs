// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System;
using MetaDslx.CodeAnalysis;
using Microsoft.CodeAnalysis;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLexerMode
{
    /// <summary>
    /// Specifies the language version.
    /// </summary>
    public class TestLexerModeLanguageVersion : LanguageVersion
    {
        /// <summary>
        /// TestLexerMode language version 1
        /// </summary>
        public const string TestLexerMode1 = nameof(TestLexerMode1);
        protected TestLexerModeLanguageVersion(string name)
            : base(name)
        {
        }
        protected TestLexerModeLanguageVersion(EnumObject retargetedValue)
            : base(retargetedValue)
        {
        }
        static TestLexerModeLanguageVersion()
        {
            EnumObject.AutoInit<TestLexerModeLanguageVersion>();
        }
        public static implicit operator TestLexerModeLanguageVersion(string name)
        {
            return FromString<TestLexerModeLanguageVersion>(name);
        }
        public static explicit operator TestLexerModeLanguageVersion(int value)
        {
            return FromIntUnsafe<TestLexerModeLanguageVersion>(value);
        }
        public override bool IsValid()
        {
            if (this == TestLexerMode1) return true;
            return false;
        }
        /// <summary>
        /// Map a language version (such as Default, Latest, or CSharpN) to a specific version (CSharpM).
        /// </summary>
        public override LanguageVersion MapSpecifiedToEffectiveVersion()
        {
            if (this == Latest || this == Default || this == LatestMajor || this == Preview)
            {
                return TestLexerMode1;
            }
            return this;
        }
        public override ErrorCode GetErrorCode()
        {
            switch (this.Switch())
            {
                case TestLexerMode1:
                    return TestLexerModeErrorCode.ERR_FeatureNotAvailableInVersion1;
                default:
                    throw ExceptionUtilities.UnexpectedValue(this);
            }
        }
    }
    public class TestLexerModeRequiredLanguageVersion : RequiredLanguageVersion
    {
        internal LanguageVersion Version { get; }
        internal TestLexerModeRequiredLanguageVersion(LanguageVersion version)
        {
            TestLexerModeLanguageVersion preview = TestLexerModeLanguageVersion.Preview;
            Version = (version == preview.MapSpecifiedToEffectiveVersion()) ? TestLexerModeLanguageVersion.Preview : version;
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
            if (version == TestLexerModeLanguageVersion.TestLexerMode1) return "1";
            if (version == TestLexerModeLanguageVersion.Default) return "default";
            if (version == TestLexerModeLanguageVersion.Latest) return "latest";
            if (version == TestLexerModeLanguageVersion.LatestMajor) return "latestmajor";
            if (version == TestLexerModeLanguageVersion.Preview) return "preview";
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
                    result = TestLexerModeLanguageVersion.TestLexerMode1;
                    return true;
                default:
                    result = LanguageVersion.Default;
                    return false;
            }
        }
        public static LanguageVersion CurrentVersion => TestLexerModeLanguageVersion.TestLexerMode1;
    }
}

