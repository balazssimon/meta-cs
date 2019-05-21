﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MetaDslx.CodeAnalysis;
using Microsoft.CodeAnalysis;
using Roslyn.Utilities;

namespace MetaDslx.Languages.MetaModel
{
    /// <summary>
    /// Specifies the language version.
    /// </summary>
    public class MetaModelLanguageVersion : LanguageVersion
    {
        /// <summary>
        /// MetaModel language version 1
        /// </summary>
        public const string MetaModel1 = nameof(MetaModel1);

        protected MetaModelLanguageVersion(string name)
            : base(name)
        {
        }

        protected MetaModelLanguageVersion(EnumObject retargetedValue)
            : base(retargetedValue)
        {
        }

        static MetaModelLanguageVersion()
        {
            EnumObject.AutoInit<MetaModelLanguageVersion>();
        }

        public static implicit operator MetaModelLanguageVersion(string name)
        {
            return FromString<MetaModelLanguageVersion>(name);
        }

        public static explicit operator MetaModelLanguageVersion(int value)
        {
            return FromIntUnsafe<MetaModelLanguageVersion>(value);
        }

        public override bool IsValid()
        {
            if (this == MetaModel1) return true;
            return false;
        }

        /// <summary>
        /// Map a language version (such as Default, Latest, or CSharpN) to a specific version (CSharpM).
        /// </summary>
        public override LanguageVersion MapSpecifiedToEffectiveVersion()
        {
            if (this == Latest || this == Default || this == LatestMajor || this == Preview)
            {
                return MetaModel1;
            }
            return this;
        }

        public override ErrorCode GetErrorCode()
        {
            switch (this.Switch())
            {
                case MetaModel1:
                    return MetaModelErrorCode.ERR_FeatureNotAvailableInVersion1;
                default:
                    throw ExceptionUtilities.UnexpectedValue(this);
            }
        }
    }

    public class MetaModelRequiredLanguageVersion : RequiredLanguageVersion
    {
        internal LanguageVersion Version { get; }

        internal MetaModelRequiredLanguageVersion(LanguageVersion version)
        {
            MetaModelLanguageVersion preview = MetaModelLanguageVersion.Preview;
            Version = (version == preview.MapSpecifiedToEffectiveVersion()) ? MetaModelLanguageVersion.Preview : version;
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
            if (version == MetaModelLanguageVersion.MetaModel1) return "1";
            if (version == MetaModelLanguageVersion.Default) return "default";
            if (version == MetaModelLanguageVersion.Latest) return "latest";
            if (version == MetaModelLanguageVersion.LatestMajor) return "latestmajor";
            if (version == MetaModelLanguageVersion.Preview) return "preview";
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
                    result = MetaModelLanguageVersion.MetaModel1;
                    return true;
                default:
                    result = LanguageVersion.Default;
                    return false;
            }
        }
        
        public static LanguageVersion CurrentVersion => MetaModelLanguageVersion.MetaModel1;

    }
}
