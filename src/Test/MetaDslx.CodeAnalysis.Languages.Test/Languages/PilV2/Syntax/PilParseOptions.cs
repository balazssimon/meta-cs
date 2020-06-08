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

namespace PilV2.Syntax
{
    /// <summary>
    /// This class stores several source parsing related options and offers access to their values.
    /// </summary>
    public sealed class PilParseOptions : LanguageParseOptions, IEquatable<PilParseOptions>
    {
        /// <summary>
        /// The default parse options.
        /// </summary>
        public static PilParseOptions Default { get; } = new PilParseOptions();
        public PilParseOptions(
            PilLanguageVersion languageVersion = null,
            DocumentationMode documentationMode = DocumentationMode.Parse,
            SourceCodeKind kind = SourceCodeKind.Regular,
            bool incremental = false,
            IEnumerable<string> preprocessorSymbols = null)
            : this(languageVersion ?? PilLanguageVersion.Pil1,
                  documentationMode,
                  kind,
                  incremental,
                  preprocessorSymbols.ToImmutableArrayOrEmpty(),
                  ImmutableDictionary<string, string>.Empty)
        {
        }
        internal PilParseOptions(
            PilLanguageVersion languageVersion,
            DocumentationMode documentationMode,
            SourceCodeKind kind,
            bool incremental,
            ImmutableArray<string> preprocessorSymbols,
            IReadOnlyDictionary<string, string> features)
            : base(languageVersion, documentationMode, kind, incremental, preprocessorSymbols, features)
        {
        }
        private PilParseOptions(PilParseOptions other) : this(
            languageVersion: (PilLanguageVersion)other.LanguageVersion,
            documentationMode: other.DocumentationMode,
            kind: other.Kind,
            incremental: other.Incremental,
            preprocessorSymbols: other.PreprocessorSymbols,
            features: other.Features)
        {
        }
        public override Language Language => PilLanguage.Instance;
        public new PilParseOptions WithKind(SourceCodeKind kind)
        {
            if (kind == this.SpecifiedKind)
            {
                return this;
            }
            var effectiveKind = kind.MapSpecifiedToEffectiveKind();
            return new PilParseOptions(this) { SpecifiedKind = kind, Kind = effectiveKind };
        }
        public new PilParseOptions WithIncremental(bool incremental)
        {
            if (incremental == this.Incremental)
            {
                return this;
            }
            return new PilParseOptions(this) { Incremental = incremental };
        }
        public PilParseOptions WithLanguageVersion(PilLanguageVersion version)
        {
            if (version == this.SpecifiedLanguageVersion)
            {
                return this;
            }
            var effectiveLanguageVersion = (PilLanguageVersion)version.MapSpecifiedToEffectiveVersion();
            return new PilParseOptions(this) { SpecifiedLanguageVersion = version, LanguageVersion = effectiveLanguageVersion };
        }
        public PilParseOptions WithPreprocessorSymbols(IEnumerable<string> preprocessorSymbols)
        {
            return WithPreprocessorSymbols(preprocessorSymbols.AsImmutableOrNull());
        }
        public PilParseOptions WithPreprocessorSymbols(params string[] preprocessorSymbols)
        {
            return WithPreprocessorSymbols(ImmutableArray.Create(preprocessorSymbols));
        }
        public PilParseOptions WithPreprocessorSymbols(ImmutableArray<string> symbols)
        {
            if (symbols.IsDefault)
            {
                symbols = ImmutableArray<string>.Empty;
            }
            if (symbols.Equals(this.PreprocessorSymbols))
            {
                return this;
            }
            return new PilParseOptions(this) { PreprocessorSymbols = symbols };
        }
        public new PilParseOptions WithDocumentationMode(DocumentationMode documentationMode)
        {
            if (documentationMode == this.DocumentationMode)
            {
                return this;
            }
            return new PilParseOptions(this) { DocumentationMode = documentationMode };
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
        public new PilParseOptions WithFeatures(IEnumerable<KeyValuePair<string, string>> features)
        {
            ImmutableDictionary<string, string> dictionary =
                features?.ToImmutableDictionary(StringComparer.OrdinalIgnoreCase)
                ?? ImmutableDictionary<string, string>.Empty;
            return new PilParseOptions(this) { Features = dictionary };
        }
        public override void ValidateOptions(ArrayBuilder<Diagnostic> builder)
        {
            base.ValidateOptions(builder);
            // Validate LanguageVersion not SpecifiedLanguageVersion, after Latest/Default has been converted:
            if (!LanguageVersion.IsValid())
            {
                builder.Add(PilErrorCode.ERR_BadLanguageVersion.ToDiagnosticWithNoLocation(LanguageVersion.ToString()));
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
            return this.Equals(obj as PilParseOptions);
        }
        public bool Equals(PilParseOptions other)
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

