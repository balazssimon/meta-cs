// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis.Syntax
{
    /// <summary>
    /// This class stores several source parsing related options and offers access to their values.
    /// </summary>
    public abstract class LanguageParseOptions : ParseOptionsAdapter
    {
        private ImmutableDictionary<string, string> _features;

        public new abstract Language Language { get; }

        public override Language LanguageCore => this.Language;

        /// <summary>
        /// Gets the effective language version, which the compiler uses to select the
        /// language rules to apply to the program.
        /// </summary>
        public LanguageVersion LanguageVersion { get; protected set; }

        /// <summary>
        /// Gets the specified language version, which is the value that was specified in
        /// the call to the constructor, or modified using the <see cref="WithLanguageVersion"/> method,
        /// or provided on the command line.
        /// </summary>
        public LanguageVersion SpecifiedLanguageVersion { get; protected set; }

        /// <summary>
        /// Gets whether the syntax tree is parsed incrementally. If there is no previous parse tree,
        /// the tree is prepared for incremental parsing.
        /// </summary>
        public bool Incremental { get; protected set; }

        public ImmutableArray<string> PreprocessorSymbols { get; protected set; }

        /// <summary>
        /// Gets the names of defined preprocessor symbols.
        /// </summary>
        public override IEnumerable<string> PreprocessorSymbolNames
        {
            get { return PreprocessorSymbols; }
        }

        protected LanguageParseOptions(
            LanguageVersion languageVersion = null,
            DocumentationMode documentationMode = DocumentationMode.Parse,
            SourceCodeKind kind = SourceCodeKind.Regular,
            bool incremental = false,
            IEnumerable<string> preprocessorSymbols = null)
            : this(languageVersion,
                  documentationMode,
                  kind,
                  incremental,
                  preprocessorSymbols.ToImmutableArrayOrEmpty(),
                  ImmutableDictionary<string, string>.Empty)
        {
        }

        protected LanguageParseOptions(
            LanguageVersion languageVersion,
            DocumentationMode documentationMode,
            SourceCodeKind kind,
            bool incremental,
            ImmutableArray<string> preprocessorSymbols,
            IReadOnlyDictionary<string, string> features)
            : base(kind, documentationMode)
        {
            this.SpecifiedLanguageVersion = languageVersion ?? LanguageVersion.Default;
            this.LanguageVersion = languageVersion;
            this.Incremental = incremental;
            this.PreprocessorSymbols = preprocessorSymbols.ToImmutableArrayOrEmpty();
            _features = features?.ToImmutableDictionary() ?? ImmutableDictionary<string, string>.Empty;
        }

        public new IReadOnlyDictionary<string, string> Features
        {
            get { return _features; }
            protected set
            {
                ImmutableDictionary<string, string> dictionary = value as ImmutableDictionary<string, string>;
                if (dictionary == null) dictionary = value.ToImmutableDictionary();
                _features = dictionary;
            }
        }

        protected override IReadOnlyDictionary<string, string> FeaturesCore
        {
            get { return this.Features; }
            set { this.Features = value; }
        }

        internal override void ValidateOptions(ArrayBuilder<Diagnostic> builder)
        {
            ValidateOptions(builder, Microsoft.CodeAnalysis.CSharp.MessageProvider.Instance);

            if (!PreprocessorSymbols.IsDefaultOrEmpty)
            {
                foreach (var symbol in PreprocessorSymbols)
                {
                    if (symbol == null)
                    {
                        builder.Add(InternalErrorCode.ERR_InvalidPreprocessingSymbol.ToDiagnosticInfo("null").ToDiagnostic(Location.None));
                    }
                }
            }
        }

        /// <summary>
        /// Enable incremental parsing.
        /// </summary>
        public LanguageParseOptions WithIncremental(bool incremental)
        {
            return CommonWithIncremental(incremental);
        }

        protected abstract LanguageParseOptions CommonWithIncremental(bool incremental);

        protected SourceCodeKind MapSpecifiedToEffectiveKind(SourceCodeKind kind)
        {
            return kind.MapSpecifiedToEffectiveKind();
        }
    }
}
