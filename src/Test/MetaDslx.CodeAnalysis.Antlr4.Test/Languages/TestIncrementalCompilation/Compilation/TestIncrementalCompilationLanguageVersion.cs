// NOTE: This is an auto-generated file. However, it will not be regenerated. If you want it to be regenerated, just delete it.
using System;
using MetaDslx.CodeAnalysis;
using Microsoft.CodeAnalysis;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation
{
    /// <summary>
    /// Specifies the language version.
    /// </summary>
    public class TestIncrementalCompilationLanguageVersion : LanguageVersion
    {
        /// <summary>
        /// TestIncrementalCompilation language version 1
        /// </summary>
        public const string TestIncrementalCompilation1 = nameof(TestIncrementalCompilation1);
        protected TestIncrementalCompilationLanguageVersion(string name)
            : base(name)
        {
        }
        protected TestIncrementalCompilationLanguageVersion(EnumObject retargetedValue)
            : base(retargetedValue)
        {
        }
        static TestIncrementalCompilationLanguageVersion()
        {
            EnumObject.AutoInit<TestIncrementalCompilationLanguageVersion>();
        }
        public static implicit operator TestIncrementalCompilationLanguageVersion(string name)
        {
            return FromString<TestIncrementalCompilationLanguageVersion>(name);
        }
        public static explicit operator TestIncrementalCompilationLanguageVersion(int value)
        {
            return FromIntUnsafe<TestIncrementalCompilationLanguageVersion>(value);
        }
        public override bool IsValid()
        {
            if (this == TestIncrementalCompilation1) return true;
            return false;
        }
        /// <summary>
        /// Map a language version (such as Default, Latest, or CSharpN) to a specific version (CSharpM).
        /// </summary>
        public override LanguageVersion MapSpecifiedToEffectiveVersion()
        {
            if (this == Latest || this == Default || this == LatestMajor || this == Preview)
            {
                return TestIncrementalCompilation1;
            }
            return this;
        }
        public override ErrorCode GetErrorCode()
        {
            switch (this.Switch())
            {
                case TestIncrementalCompilation1:
                    return TestIncrementalCompilationErrorCode.ERR_FeatureNotAvailableInVersion1;
                default:
                    throw ExceptionUtilities.UnexpectedValue(this);
            }
        }
    }
    public class TestIncrementalCompilationRequiredLanguageVersion : RequiredLanguageVersion
    {
        internal LanguageVersion Version { get; }
        internal TestIncrementalCompilationRequiredLanguageVersion(LanguageVersion version)
        {
            TestIncrementalCompilationLanguageVersion preview = TestIncrementalCompilationLanguageVersion.Preview;
            Version = (version == preview.MapSpecifiedToEffectiveVersion()) ? TestIncrementalCompilationLanguageVersion.Preview : version;
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
            if (version == TestIncrementalCompilationLanguageVersion.TestIncrementalCompilation1) return "1";
            if (version == TestIncrementalCompilationLanguageVersion.Default) return "default";
            if (version == TestIncrementalCompilationLanguageVersion.Latest) return "latest";
            if (version == TestIncrementalCompilationLanguageVersion.LatestMajor) return "latestmajor";
            if (version == TestIncrementalCompilationLanguageVersion.Preview) return "preview";
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
                    result = TestIncrementalCompilationLanguageVersion.TestIncrementalCompilation1;
                    return true;
                default:
                    result = LanguageVersion.Default;
                    return false;
            }
        }
        public static LanguageVersion CurrentVersion => TestIncrementalCompilationLanguageVersion.TestIncrementalCompilation1;
    }
}

