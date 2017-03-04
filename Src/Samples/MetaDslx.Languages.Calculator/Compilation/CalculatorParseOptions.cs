// !!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Compiler;
using MetaDslx.Compiler.Syntax;
using MetaDslx.Compiler.Utilities;

namespace MetaDslx.Languages.Calculator
{
    /// <summary>
    /// This class stores several source parsing related options and offers access to their values.
    /// </summary>
    public sealed class CalculatorParseOptions : ParseOptions, IEquatable<CalculatorParseOptions>
    {
        /// <summary>
        /// The default parse options.
        /// </summary>
        public static CalculatorParseOptions Default { get; } = new CalculatorParseOptions();

        private ImmutableDictionary<string, string> _features;

        /// <summary>
        /// Gets the language version.
        /// </summary>
        public LanguageVersion LanguageVersion { get; private set; }

        public CalculatorParseOptions(
            LanguageVersion languageVersion = LanguageVersion.Calculator1,
            DocumentationMode documentationMode = DocumentationMode.Parse,
            SourceCodeKind kind = SourceCodeKind.Regular)
            : base(kind, documentationMode)
        {
            if (!languageVersion.IsValid())
            {
                throw new ArgumentOutOfRangeException(nameof(languageVersion));
            }
            if (!kind.IsValid())
            {
                throw new ArgumentOutOfRangeException(nameof(kind));
            }
            this.LanguageVersion = languageVersion;
            _features = ImmutableDictionary<string, string>.Empty;
        }

        internal CalculatorParseOptions(
            LanguageVersion languageVersion,
            DocumentationMode documentationMode,
            SourceCodeKind kind,
            ImmutableDictionary<string, string> features)
            : this(languageVersion, documentationMode, kind)
        {
            if (features == null)
            {
                throw new ArgumentNullException(nameof(features));
            }
            _features = features;
        }

        private CalculatorParseOptions(CalculatorParseOptions other) : this(
            languageVersion: other.LanguageVersion,
            documentationMode: other.DocumentationMode,
            kind: other.Kind)
        {
        }

        public new CalculatorParseOptions WithKind(SourceCodeKind kind)
        {
            if (kind == this.Kind)
            {
                return this;
            }

            if (!kind.IsValid())
            {
                throw new ArgumentOutOfRangeException(nameof(kind));
            }

            return new CalculatorParseOptions(this) { Kind = kind };
        }

        public CalculatorParseOptions WithLanguageVersion(LanguageVersion version)
        {
            if (version == this.LanguageVersion)
            {
                return this;
            }

            if (!version.IsValid())
            {
                throw new ArgumentOutOfRangeException(nameof(version));
            }

            return new CalculatorParseOptions(this) { LanguageVersion = version };
        }

        public new CalculatorParseOptions WithDocumentationMode(DocumentationMode documentationMode)
        {
            if (documentationMode == this.DocumentationMode)
            {
                return this;
            }

            if (!documentationMode.IsValid())
            {
                throw new ArgumentOutOfRangeException(nameof(documentationMode));
            }

            return new CalculatorParseOptions(this) { DocumentationMode = documentationMode };
        }

        public override ParseOptions CommonWithKind(SourceCodeKind kind)
        {
            return WithKind(kind);
        }

        protected override ParseOptions CommonWithDocumentationMode(DocumentationMode documentationMode)
        {
            return WithDocumentationMode(documentationMode);
        }

        protected override ParseOptions CommonWithFeatures(IEnumerable<KeyValuePair<string, string>> features)
        {
            return WithFeatures(features);
        }

        /// <summary>
        /// Enable some experimental language features for testing.
        /// </summary>
        public new CalculatorParseOptions WithFeatures(IEnumerable<KeyValuePair<string, string>> features)
        {
            if (features == null)
            {
                throw new ArgumentNullException(nameof(features));
            }

            return new CalculatorParseOptions(this) { _features = features.ToImmutableDictionary(StringComparer.OrdinalIgnoreCase) };
        }
        public override IReadOnlyDictionary<string, string> Features
        {
            get
            {
                return _features;
            }
        }
        internal bool IsFeatureEnabled(CalculatorFeature feature)
        {
            string featureFlag = feature.RequiredFeature();
            if (featureFlag != null)
            {
                return Features.ContainsKey(featureFlag);
            }
            LanguageVersion availableVersion = LanguageVersion;
            LanguageVersion requiredVersion = feature.RequiredVersion();
            return availableVersion >= requiredVersion;
        }
        public override bool Equals(object obj)
        {
            return this.Equals(obj as CalculatorParseOptions);
        }

        public bool Equals(CalculatorParseOptions other)
        {
            if (object.ReferenceEquals(this, other))
            {
                return true;
            }
            if (!base.EqualsHelper(other))
            {
                return false;
            }
            return this.LanguageVersion == other.LanguageVersion;
        }

        public override int GetHashCode()
        {
            return
                Hash.Combine(base.GetHashCodeHelper(),
                Hash.Combine((int)this.LanguageVersion, 0));
        }
    }
}

