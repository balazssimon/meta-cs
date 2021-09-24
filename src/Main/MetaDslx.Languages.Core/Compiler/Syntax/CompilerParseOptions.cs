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

//using MetaDslx.Languages.Core.Model;
using MetaDslx.Languages.Compiler.Model;

namespace MetaDslx.Languages.Compiler.Syntax
{
    /// <summary>
    /// This class stores several source parsing related options and offers access to their values.
    /// </summary>
    public sealed class CompilerParseOptions : LanguageParseOptions, IEquatable<CompilerParseOptions>
    {
        /// <summary>
        /// The default parse options.
        /// </summary>
        public static CompilerParseOptions Default { get; } = new CompilerParseOptions();
        public CompilerParseOptions(
            CompilerLanguageVersion languageVersion = null,
            DocumentationMode documentationMode = DocumentationMode.Parse,
            SourceCodeKind kind = SourceCodeKind.Regular,
            bool incremental = false,
            IEnumerable<string> preprocessorSymbols = null)
            : this(languageVersion ?? CompilerLanguageVersion.Compiler1,
                  documentationMode,
                  kind,
                  incremental,
                  preprocessorSymbols.ToImmutableArrayOrEmpty(),
                  ImmutableDictionary<string, string>.Empty)
        {
        }
        internal CompilerParseOptions(
            CompilerLanguageVersion languageVersion,
            DocumentationMode documentationMode,
            SourceCodeKind kind,
            bool incremental,
            ImmutableArray<string> preprocessorSymbols,
            IReadOnlyDictionary<string, string> features)
            : base(languageVersion, documentationMode, kind, incremental, preprocessorSymbols, features)
        {
        }
        private CompilerParseOptions(CompilerParseOptions other) : this(
            languageVersion: (CompilerLanguageVersion)other.LanguageVersion,
            documentationMode: other.DocumentationMode,
            kind: other.Kind,
            incremental: other.Incremental,
            preprocessorSymbols: other.PreprocessorSymbols,
            features: other.Features)
        {
        }
        public override Language Language => CompilerLanguage.Instance;
        public new CompilerParseOptions WithKind(SourceCodeKind kind)
        {
            if (kind == this.SpecifiedKind)
            {
                return this;
            }
            var effectiveKind = MapSpecifiedToEffectiveKind(kind);
            return new CompilerParseOptions(this) { SpecifiedKind = kind, Kind = effectiveKind };
        }
        public new CompilerParseOptions WithIncremental(bool incremental)
        {
            if (incremental == this.Incremental)
            {
                return this;
            }
            return new CompilerParseOptions(this) { Incremental = incremental };
        }
        public CompilerParseOptions WithLanguageVersion(CompilerLanguageVersion version)
        {
            if (version == this.SpecifiedLanguageVersion)
            {
                return this;
            }
            var effectiveLanguageVersion = (CompilerLanguageVersion)version.MapSpecifiedToEffectiveVersion();
            return new CompilerParseOptions(this) { SpecifiedLanguageVersion = version, LanguageVersion = effectiveLanguageVersion };
        }
        public CompilerParseOptions WithPreprocessorSymbols(IEnumerable<string> preprocessorSymbols)
        {
            return WithPreprocessorSymbols(preprocessorSymbols.AsImmutableOrNull());
        }
        public CompilerParseOptions WithPreprocessorSymbols(params string[] preprocessorSymbols)
        {
            return WithPreprocessorSymbols(ImmutableArray.Create(preprocessorSymbols));
        }
        public CompilerParseOptions WithPreprocessorSymbols(ImmutableArray<string> symbols)
        {
            if (symbols.IsDefault)
            {
                symbols = ImmutableArray<string>.Empty;
            }
            if (symbols.Equals(this.PreprocessorSymbols))
            {
                return this;
            }
            return new CompilerParseOptions(this) { PreprocessorSymbols = symbols };
        }
        public new CompilerParseOptions WithDocumentationMode(DocumentationMode documentationMode)
        {
            if (documentationMode == this.DocumentationMode)
            {
                return this;
            }
            return new CompilerParseOptions(this) { DocumentationMode = documentationMode };
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
        public new CompilerParseOptions WithFeatures(IEnumerable<KeyValuePair<string, string>> features)
        {
            ImmutableDictionary<string, string> dictionary =
                features?.ToImmutableDictionary(StringComparer.OrdinalIgnoreCase)
                ?? ImmutableDictionary<string, string>.Empty;
            return new CompilerParseOptions(this) { Features = dictionary };
        }
        public override bool Equals(object obj)
        {
            return this.Equals(obj as CompilerParseOptions);
        }
        public bool Equals(CompilerParseOptions other)
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

