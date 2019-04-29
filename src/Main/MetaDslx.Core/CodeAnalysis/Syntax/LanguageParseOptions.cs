// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.PooledObjects;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis
{
    /// <summary>
    /// This class stores several source parsing related options and offers access to their values.
    /// </summary>
    public abstract class LanguageParseOptions : ParseOptions
    {
        private ImmutableDictionary<string, string> _features;

        /// <summary>
        /// Gets the effective language version, which the compiler uses to select the
        /// language rules to apply to the program.
        /// </summary>
        public LanguageVersion LanguageVersion { get; private set; }

        /// <summary>
        /// Gets the specified language version, which is the value that was specified in
        /// the call to the constructor, or modified using the <see cref="WithLanguageVersion"/> method,
        /// or provided on the command line.
        /// </summary>
        public LanguageVersion SpecifiedLanguageVersion { get; private set; }

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
            IEnumerable<string> preprocessorSymbols = null)
            : this(languageVersion,
                  documentationMode,
                  kind,
                  preprocessorSymbols.ToImmutableArrayOrEmpty(),
                  ImmutableDictionary<string, string>.Empty)
        {
        }

        protected LanguageParseOptions(
            LanguageVersion languageVersion,
            DocumentationMode documentationMode,
            SourceCodeKind kind,
            ImmutableArray<string> preprocessorSymbols,
            IReadOnlyDictionary<string, string> features)
            : base(kind, documentationMode)
        {
            this.SpecifiedLanguageVersion = languageVersion ?? LanguageVersion.Default;
            this.LanguageVersion = languageVersion;
            this.PreprocessorSymbols = preprocessorSymbols.ToImmutableArrayOrEmpty();
            _features = features?.ToImmutableDictionary() ?? ImmutableDictionary<string, string>.Empty;
        }

        public override IReadOnlyDictionary<string, string> Features
        {
            get { return _features; }
            /*protected set
            {
                ImmutableDictionary<string, string> dictionary = value as ImmutableDictionary<string, string>;
                if (dictionary == null) dictionary = value.ToImmutableDictionary();
                _features = dictionary;
            }*/
        }

        public override void ValidateOptions(ArrayBuilder<Diagnostic> builder)
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

    }
}
