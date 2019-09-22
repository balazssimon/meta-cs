// NOTE: This is an auto-generated file. However, it will not be regenerated. If you want it to be regenerated, just delete it.
using System;
using MetaDslx.CodeAnalysis;
using Microsoft.CodeAnalysis;
using Roslyn.Utilities;

namespace WebSequenceDiagramsModel
{
    /// <summary>
    /// Specifies the language version.
    /// </summary>
    public class SequenceLanguageVersion : LanguageVersion
    {
        /// <summary>
        /// Sequence language version 1
        /// </summary>
        public const string Sequence1 = nameof(Sequence1);
        protected SequenceLanguageVersion(string name)
            : base(name)
        {
        }
        protected SequenceLanguageVersion(EnumObject retargetedValue)
            : base(retargetedValue)
        {
        }
        static SequenceLanguageVersion()
        {
            EnumObject.AutoInit<SequenceLanguageVersion>();
        }
        public static implicit operator SequenceLanguageVersion(string name)
        {
            return FromString<SequenceLanguageVersion>(name);
        }
        public static explicit operator SequenceLanguageVersion(int value)
        {
            return FromIntUnsafe<SequenceLanguageVersion>(value);
        }
        public override bool IsValid()
        {
            if (this == Sequence1) return true;
            return false;
        }
        /// <summary>
        /// Map a language version (such as Default, Latest, or CSharpN) to a specific version (CSharpM).
        /// </summary>
        public override LanguageVersion MapSpecifiedToEffectiveVersion()
        {
            if (this == Latest || this == Default || this == LatestMajor || this == Preview)
            {
                return Sequence1;
            }
            return this;
        }
        public override ErrorCode GetErrorCode()
        {
            switch (this.Switch())
            {
                case Sequence1:
                    return SequenceErrorCode.ERR_FeatureNotAvailableInVersion1;
                default:
                    throw ExceptionUtilities.UnexpectedValue(this);
            }
        }
    }
    public class SequenceRequiredLanguageVersion : RequiredLanguageVersion
    {
        internal LanguageVersion Version { get; }
        internal SequenceRequiredLanguageVersion(LanguageVersion version)
        {
            SequenceLanguageVersion preview = SequenceLanguageVersion.Preview;
            Version = (version == preview.MapSpecifiedToEffectiveVersion()) ? SequenceLanguageVersion.Preview : version;
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
            if (version == SequenceLanguageVersion.Sequence1) return "1";
            if (version == SequenceLanguageVersion.Default) return "default";
            if (version == SequenceLanguageVersion.Latest) return "latest";
            if (version == SequenceLanguageVersion.LatestMajor) return "latestmajor";
            if (version == SequenceLanguageVersion.Preview) return "preview";
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
                    result = SequenceLanguageVersion.Sequence1;
                    return true;
                default:
                    result = LanguageVersion.Default;
                    return false;
            }
        }
        public static LanguageVersion CurrentVersion => SequenceLanguageVersion.Sequence1;
    }
}

