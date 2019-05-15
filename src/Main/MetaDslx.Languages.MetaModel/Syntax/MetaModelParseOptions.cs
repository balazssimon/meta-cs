// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using MetaDslx.CodeAnalysis;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using Roslyn.Utilities;

namespace MetaDslx.Languages.MetaModel
{
    /// <summary>
    /// This class stores several source parsing related options and offers access to their values.
    /// </summary>
    public sealed class MetaModelParseOptions : LanguageParseOptions, IEquatable<MetaModelParseOptions>
    {
        /// <summary>
        /// The default parse options.
        /// </summary>
        public static MetaModelParseOptions Default { get; } = new MetaModelParseOptions();

        public MetaModelParseOptions(
            LanguageVersion languageVersion = null,
            DocumentationMode documentationMode = DocumentationMode.Parse,
            SourceCodeKind kind = SourceCodeKind.Regular,
            IEnumerable<string> preprocessorSymbols = null)
            : this(languageVersion,
                  documentationMode,
                  kind,
                  preprocessorSymbols.ToImmutableArrayOrEmpty(),
                  ImmutableDictionary<string, string>.Empty)
        {
        }

        internal MetaModelParseOptions(
            LanguageVersion languageVersion,
            DocumentationMode documentationMode,
            SourceCodeKind kind,
            ImmutableArray<string> preprocessorSymbols,
            IReadOnlyDictionary<string, string> features)
            : base(languageVersion, documentationMode, kind, preprocessorSymbols, features)
        {
        }

        private MetaModelParseOptions(MetaModelParseOptions other) : this(
            languageVersion: other.SpecifiedLanguageVersion,
            documentationMode: other.DocumentationMode,
            kind: other.Kind,
            preprocessorSymbols: other.PreprocessorSymbols,
            features: other.Features)
        {
        }

        public override string Language => LanguageNames.CSharp;

        public new MetaModelParseOptions WithKind(SourceCodeKind kind)
        {
            if (kind == this.SpecifiedKind)
            {
                return this;
            }

            var effectiveKind = kind.MapSpecifiedToEffectiveKind();
            return new MetaModelParseOptions(this) { SpecifiedKind = kind, Kind = effectiveKind };
        }

        public MetaModelParseOptions WithLanguageVersion(MetaModelLanguageVersion version)
        {
            if (version == this.SpecifiedLanguageVersion)
            {
                return this;
            }

            var effectiveLanguageVersion = (MetaModelLanguageVersion)version.MapSpecifiedToEffectiveVersion();
            //return new MetaModelParseOptions(this) { SpecifiedLanguageVersion = version, LanguageVersion = effectiveLanguageVersion };
            throw new NotImplementedException("TODO:MetaDslx");
        }

        public MetaModelParseOptions WithPreprocessorSymbols(IEnumerable<string> preprocessorSymbols)
        {
            return WithPreprocessorSymbols(preprocessorSymbols.AsImmutableOrNull());
        }

        public MetaModelParseOptions WithPreprocessorSymbols(params string[] preprocessorSymbols)
        {
            return WithPreprocessorSymbols(ImmutableArray.Create(preprocessorSymbols));
        }

        public MetaModelParseOptions WithPreprocessorSymbols(ImmutableArray<string> symbols)
        {
            if (symbols.IsDefault)
            {
                symbols = ImmutableArray<string>.Empty;
            }

            if (symbols.Equals(this.PreprocessorSymbols))
            {
                return this;
            }

            return new MetaModelParseOptions(this) { PreprocessorSymbols = symbols };
        }

        public new MetaModelParseOptions WithDocumentationMode(DocumentationMode documentationMode)
        {
            if (documentationMode == this.DocumentationMode)
            {
                return this;
            }

            return new MetaModelParseOptions(this) { DocumentationMode = documentationMode };
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
        public new MetaModelParseOptions WithFeatures(IEnumerable<KeyValuePair<string, string>> features)
        {
            ImmutableDictionary<string, string> dictionary =
                features?.ToImmutableDictionary(StringComparer.OrdinalIgnoreCase)
                ?? ImmutableDictionary<string, string>.Empty;

            return new MetaModelParseOptions(this); // TODO:MetaDslx { Features = dictionary };
        }

        public override void ValidateOptions(ArrayBuilder<Diagnostic> builder)
        {
            base.ValidateOptions(builder);

            // Validate LanguageVersion not SpecifiedLanguageVersion, after Latest/Default has been converted:
            if (!LanguageVersion.IsValid())
            {
                builder.Add(MetaModelErrorCode.ERR_BadLanguageVersion.ToDiagnosticWithNoLocation(LanguageVersion.ToString()));
            }
        }

        /* TODO:MetaDslx
        public bool IsFeatureEnabled(string feature)
        {
            string featureFlag = feature.RequiredFeature();
            if (featureFlag != null)
            {
                return Features.ContainsKey(featureFlag);
            }
            LanguageVersion availableVersion = LanguageVersion;
            LanguageVersion requiredVersion = feature.RequiredVersion();
            return availableVersion >= requiredVersion;
        }*/

        public override bool Equals(object obj)
        {
            return this.Equals(obj as MetaModelParseOptions);
        }

        public bool Equals(MetaModelParseOptions other)
        {
            if (object.ReferenceEquals(this, other))
            {
                return true;
            }

            if (!base.EqualsHelper(other))
            {
                return false;
            }

            return this.SpecifiedLanguageVersion == other.SpecifiedLanguageVersion;
        }

        public override int GetHashCode()
        {
            return
                Hash.Combine(base.GetHashCodeHelper(),
                Hash.Combine(this.SpecifiedLanguageVersion.GetHashCode(), 0));
        }
    }
}
