// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING: This is an auto-generated file. Any manual changes will be lost when the file is regenerated.
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Syntax;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using Roslyn.Utilities;

using MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Model;

namespace MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestLanguageAnnotations.Syntax
{
    /// <summary>
    /// This class stores several source parsing related options and offers access to their values.
    /// </summary>
    public sealed class TestLanguageAnnotationsParseOptions : LanguageParseOptions, IEquatable<TestLanguageAnnotationsParseOptions>
    {
        /// <summary>
        /// The default parse options.
        /// </summary>
        public static TestLanguageAnnotationsParseOptions Default { get; } = new TestLanguageAnnotationsParseOptions();
        public TestLanguageAnnotationsParseOptions(
            TestLanguageAnnotationsLanguageVersion languageVersion = null,
            DocumentationMode documentationMode = DocumentationMode.Parse,
            SourceCodeKind kind = SourceCodeKind.Regular,
            bool incremental = false,
            IEnumerable<string> preprocessorSymbols = null)
            : this(languageVersion ?? TestLanguageAnnotationsLanguageVersion.TestLanguageAnnotations1,
                  documentationMode,
                  kind,
                  incremental,
                  preprocessorSymbols.ToImmutableArrayOrEmpty(),
                  ImmutableDictionary<string, string>.Empty)
        {
        }
        internal TestLanguageAnnotationsParseOptions(
            TestLanguageAnnotationsLanguageVersion languageVersion,
            DocumentationMode documentationMode,
            SourceCodeKind kind,
            bool incremental,
            ImmutableArray<string> preprocessorSymbols,
            IReadOnlyDictionary<string, string> features)
            : base(languageVersion, documentationMode, kind, incremental, preprocessorSymbols, features)
        {
        }
        private TestLanguageAnnotationsParseOptions(TestLanguageAnnotationsParseOptions other) : this(
            languageVersion: (TestLanguageAnnotationsLanguageVersion)other.LanguageVersion,
            documentationMode: other.DocumentationMode,
            kind: other.Kind,
            incremental: other.Incremental,
            preprocessorSymbols: other.PreprocessorSymbols,
            features: other.Features)
        {
        }
        public override Language Language => TestLanguageAnnotationsLanguage.Instance;
        public new TestLanguageAnnotationsParseOptions WithKind(SourceCodeKind kind)
        {
            if (kind == this.SpecifiedKind)
            {
                return this;
            }
            var effectiveKind = kind.MapSpecifiedToEffectiveKind();
            return new TestLanguageAnnotationsParseOptions(this) { SpecifiedKind = kind, Kind = effectiveKind };
        }
        public new TestLanguageAnnotationsParseOptions WithIncremental(bool incremental)
        {
            if (incremental == this.Incremental)
            {
                return this;
            }
            return new TestLanguageAnnotationsParseOptions(this) { Incremental = incremental };
        }
        public TestLanguageAnnotationsParseOptions WithLanguageVersion(TestLanguageAnnotationsLanguageVersion version)
        {
            if (version == this.SpecifiedLanguageVersion)
            {
                return this;
            }
            var effectiveLanguageVersion = (TestLanguageAnnotationsLanguageVersion)version.MapSpecifiedToEffectiveVersion();
            return new TestLanguageAnnotationsParseOptions(this) { SpecifiedLanguageVersion = version, LanguageVersion = effectiveLanguageVersion };
        }
        public TestLanguageAnnotationsParseOptions WithPreprocessorSymbols(IEnumerable<string> preprocessorSymbols)
        {
            return WithPreprocessorSymbols(preprocessorSymbols.AsImmutableOrNull());
        }
        public TestLanguageAnnotationsParseOptions WithPreprocessorSymbols(params string[] preprocessorSymbols)
        {
            return WithPreprocessorSymbols(ImmutableArray.Create(preprocessorSymbols));
        }
        public TestLanguageAnnotationsParseOptions WithPreprocessorSymbols(ImmutableArray<string> symbols)
        {
            if (symbols.IsDefault)
            {
                symbols = ImmutableArray<string>.Empty;
            }
            if (symbols.Equals(this.PreprocessorSymbols))
            {
                return this;
            }
            return new TestLanguageAnnotationsParseOptions(this) { PreprocessorSymbols = symbols };
        }
        public new TestLanguageAnnotationsParseOptions WithDocumentationMode(DocumentationMode documentationMode)
        {
            if (documentationMode == this.DocumentationMode)
            {
                return this;
            }
            return new TestLanguageAnnotationsParseOptions(this) { DocumentationMode = documentationMode };
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
        protected override LanguageParseOptions CommonWithIncremental(bool incremental)
        {
            return WithIncremental(incremental);
        }
        /// <summary>
        /// Enable some experimental language features for testing.
        /// </summary>
        public new TestLanguageAnnotationsParseOptions WithFeatures(IEnumerable<KeyValuePair<string, string>> features)
        {
            ImmutableDictionary<string, string> dictionary =
                features?.ToImmutableDictionary(StringComparer.OrdinalIgnoreCase)
                ?? ImmutableDictionary<string, string>.Empty;
            return new TestLanguageAnnotationsParseOptions(this) { Features = dictionary };
        }
        public override void ValidateOptions(ArrayBuilder<Diagnostic> builder)
        {
            base.ValidateOptions(builder);
            // Validate LanguageVersion not SpecifiedLanguageVersion, after Latest/Default has been converted:
            if (!LanguageVersion.IsValid())
            {
                builder.Add(TestLanguageAnnotationsErrorCode.ERR_BadLanguageVersion.ToDiagnosticWithNoLocation(LanguageVersion.ToString()));
            }
        }
        public bool IsFeatureEnabled(string feature)
        {
            throw new NotImplementedException("TODO:MetaDslx");
            /*string featureFlag = feature.RequiredFeature();
            if (featureFlag != null)
            {
                return Features.ContainsKey(featureFlag);
            }
            LanguageVersion availableVersion = LanguageVersion;
            LanguageVersion requiredVersion = feature.RequiredVersion();
            return availableVersion >= requiredVersion;*/
        }
        public override bool Equals(object obj)
        {
            return this.Equals(obj as TestLanguageAnnotationsParseOptions);
        }
        public bool Equals(TestLanguageAnnotationsParseOptions other)
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

