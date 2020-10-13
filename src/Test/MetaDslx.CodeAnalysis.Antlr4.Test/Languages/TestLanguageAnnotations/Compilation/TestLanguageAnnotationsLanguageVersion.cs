// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System;
using MetaDslx.CodeAnalysis;
using Microsoft.CodeAnalysis;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations
{
    /// <summary>
    /// Specifies the language version.
    /// </summary>
    public class TestLanguageAnnotationsLanguageVersion : LanguageVersion
    {
        /// <summary>
        /// TestLanguageAnnotations language version 1
        /// </summary>
        public const string TestLanguageAnnotations1 = nameof(TestLanguageAnnotations1);
        protected TestLanguageAnnotationsLanguageVersion(string name)
            : base(name)
        {
        }
        protected TestLanguageAnnotationsLanguageVersion(EnumObject retargetedValue)
            : base(retargetedValue)
        {
        }
        static TestLanguageAnnotationsLanguageVersion()
        {
            EnumObject.AutoInit<TestLanguageAnnotationsLanguageVersion>();
        }
        public static implicit operator TestLanguageAnnotationsLanguageVersion(string name)
        {
            return FromString<TestLanguageAnnotationsLanguageVersion>(name);
        }
        public static explicit operator TestLanguageAnnotationsLanguageVersion(int value)
        {
            return FromIntUnsafe<TestLanguageAnnotationsLanguageVersion>(value);
        }
        public override bool IsValid()
        {
            if (this == TestLanguageAnnotations1) return true;
            return false;
        }
        /// <summary>
        /// Map a language version (such as Default, Latest, or CSharpN) to a specific version (CSharpM).
        /// </summary>
        public override LanguageVersion MapSpecifiedToEffectiveVersion()
        {
            if (this == Latest || this == Default || this == LatestMajor || this == Preview)
            {
                return TestLanguageAnnotations1;
            }
            return this;
        }
        public override ErrorCode GetErrorCode()
        {
            switch (this.Switch())
            {
                case TestLanguageAnnotations1:
                    return TestLanguageAnnotationsErrorCode.ERR_FeatureNotAvailableInVersion1;
                default:
                    throw ExceptionUtilities.UnexpectedValue(this);
            }
        }
    }
    public class TestLanguageAnnotationsRequiredLanguageVersion : RequiredLanguageVersion
    {
        internal LanguageVersion Version { get; }
        internal TestLanguageAnnotationsRequiredLanguageVersion(LanguageVersion version)
        {
            TestLanguageAnnotationsLanguageVersion preview = TestLanguageAnnotationsLanguageVersion.Preview;
            Version = (version == preview.MapSpecifiedToEffectiveVersion()) ? TestLanguageAnnotationsLanguageVersion.Preview : version;
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
            if (version == TestLanguageAnnotationsLanguageVersion.TestLanguageAnnotations1) return "1";
            if (version == TestLanguageAnnotationsLanguageVersion.Default) return "default";
            if (version == TestLanguageAnnotationsLanguageVersion.Latest) return "latest";
            if (version == TestLanguageAnnotationsLanguageVersion.LatestMajor) return "latestmajor";
            if (version == TestLanguageAnnotationsLanguageVersion.Preview) return "preview";
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
                    result = TestLanguageAnnotationsLanguageVersion.TestLanguageAnnotations1;
                    return true;
                default:
                    result = LanguageVersion.Default;
                    return false;
            }
        }
        public static LanguageVersion CurrentVersion => TestLanguageAnnotationsLanguageVersion.TestLanguageAnnotations1;
    }
}

