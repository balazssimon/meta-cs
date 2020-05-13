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

namespace MetaDslx.CodeAnalysis.Antlr4Test.Languages.TestIncrementalCompilation.Syntax
{
    /// <summary>
    /// This class stores several source parsing related options and offers access to their values.
    /// </summary>
    public sealed class TestIncrementalCompilationParseOptions : LanguageParseOptions, IEquatable<TestIncrementalCompilationParseOptions>
    {
        /// <summary>
        /// The default parse options.
        /// </summary>
        public static TestIncrementalCompilationParseOptions Default { get; } = new TestIncrementalCompilationParseOptions();
        public TestIncrementalCompilationParseOptions(
            TestIncrementalCompilationLanguageVersion languageVersion = null,
            DocumentationMode documentationMode = DocumentationMode.Parse,
            SourceCodeKind kind = SourceCodeKind.Regular,
            bool incremental = false,
            IEnumerable<string> preprocessorSymbols = null)
            : this(languageVersion ?? TestIncrementalCompilationLanguageVersion.TestIncrementalCompilation1,
                  documentationMode,
                  kind,
                  incremental,
                  preprocessorSymbols.ToImmutableArrayOrEmpty(),
                  ImmutableDictionary<string, string>.Empty)
        {
        }
        internal TestIncrementalCompilationParseOptions(
            TestIncrementalCompilationLanguageVersion languageVersion,
            DocumentationMode documentationMode,
            SourceCodeKind kind,
            bool incremental,
            ImmutableArray<string> preprocessorSymbols,
            IReadOnlyDictionary<string, string> features)
            : base(languageVersion, documentationMode, kind, incremental, preprocessorSymbols, features)
        {
        }
        private TestIncrementalCompilationParseOptions(TestIncrementalCompilationParseOptions other) : this(
            languageVersion: (TestIncrementalCompilationLanguageVersion)other.LanguageVersion,
            documentationMode: other.DocumentationMode,
            kind: other.Kind,
            incremental: other.Incremental,
            preprocessorSymbols: other.PreprocessorSymbols,
            features: other.Features)
        {
        }
        public override Language Language => TestIncrementalCompilationLanguage.Instance;
        public new TestIncrementalCompilationParseOptions WithKind(SourceCodeKind kind)
        {
            if (kind == this.SpecifiedKind)
            {
                return this;
            }
            var effectiveKind = kind.MapSpecifiedToEffectiveKind();
            return new TestIncrementalCompilationParseOptions(this) { SpecifiedKind = kind, Kind = effectiveKind };
        }
        public new TestIncrementalCompilationParseOptions WithIncremental(bool incremental)
        {
            if (incremental == this.Incremental)
            {
                return this;
            }
            return new TestIncrementalCompilationParseOptions(this) { Incremental = incremental };
        }
        public TestIncrementalCompilationParseOptions WithLanguageVersion(TestIncrementalCompilationLanguageVersion version)
        {
            if (version == this.SpecifiedLanguageVersion)
            {
                return this;
            }
            var effectiveLanguageVersion = (TestIncrementalCompilationLanguageVersion)version.MapSpecifiedToEffectiveVersion();
            return new TestIncrementalCompilationParseOptions(this) { SpecifiedLanguageVersion = version, LanguageVersion = effectiveLanguageVersion };
        }
        public TestIncrementalCompilationParseOptions WithPreprocessorSymbols(IEnumerable<string> preprocessorSymbols)
        {
            return WithPreprocessorSymbols(preprocessorSymbols.AsImmutableOrNull());
        }
        public TestIncrementalCompilationParseOptions WithPreprocessorSymbols(params string[] preprocessorSymbols)
        {
            return WithPreprocessorSymbols(ImmutableArray.Create(preprocessorSymbols));
        }
        public TestIncrementalCompilationParseOptions WithPreprocessorSymbols(ImmutableArray<string> symbols)
        {
            if (symbols.IsDefault)
            {
                symbols = ImmutableArray<string>.Empty;
            }
            if (symbols.Equals(this.PreprocessorSymbols))
            {
                return this;
            }
            return new TestIncrementalCompilationParseOptions(this) { PreprocessorSymbols = symbols };
        }
        public new TestIncrementalCompilationParseOptions WithDocumentationMode(DocumentationMode documentationMode)
        {
            if (documentationMode == this.DocumentationMode)
            {
                return this;
            }
            return new TestIncrementalCompilationParseOptions(this) { DocumentationMode = documentationMode };
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
        public new TestIncrementalCompilationParseOptions WithFeatures(IEnumerable<KeyValuePair<string, string>> features)
        {
            ImmutableDictionary<string, string> dictionary =
                features?.ToImmutableDictionary(StringComparer.OrdinalIgnoreCase)
                ?? ImmutableDictionary<string, string>.Empty;
            return new TestIncrementalCompilationParseOptions(this) { Features = dictionary };
        }
        public override void ValidateOptions(ArrayBuilder<Diagnostic> builder)
        {
            base.ValidateOptions(builder);
            // Validate LanguageVersion not SpecifiedLanguageVersion, after Latest/Default has been converted:
            if (!LanguageVersion.IsValid())
            {
                builder.Add(TestIncrementalCompilationErrorCode.ERR_BadLanguageVersion.ToDiagnosticWithNoLocation(LanguageVersion.ToString()));
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
            return this.Equals(obj as TestIncrementalCompilationParseOptions);
        }
        public bool Equals(TestIncrementalCompilationParseOptions other)
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

