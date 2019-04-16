// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using Microsoft.CodeAnalysis.PooledObjects;
using Roslyn.Utilities;

namespace Microsoft.CodeAnalysis.CSharp
{
    /// <summary>
    /// This class stores several source parsing related options and offers access to their values.
    /// </summary>
    public abstract class CSharpParseOptions : ParseOptions
    {
        private ImmutableDictionary<string, string> _features;

        public ImmutableArray<string> PreprocessorSymbols { get; protected set; }

        /// <summary>
        /// Gets the names of defined preprocessor symbols.
        /// </summary>
        public override IEnumerable<string> PreprocessorSymbolNames
        {
            get { return PreprocessorSymbols; }
        }

        protected CSharpParseOptions(
            DocumentationMode documentationMode = DocumentationMode.Parse,
            SourceCodeKind kind = SourceCodeKind.Regular,
            IEnumerable<string> preprocessorSymbols = null)
            : this(documentationMode,
                  kind,
                  preprocessorSymbols.ToImmutableArrayOrEmpty(),
                  ImmutableDictionary<string, string>.Empty)
        {
        }

        protected CSharpParseOptions(
            DocumentationMode documentationMode,
            SourceCodeKind kind,
            ImmutableArray<string> preprocessorSymbols,
            IReadOnlyDictionary<string, string> features)
            : base(kind, documentationMode)
        {
            this.PreprocessorSymbols = preprocessorSymbols.ToImmutableArrayOrEmpty();
            _features = features?.ToImmutableDictionary() ?? ImmutableDictionary<string, string>.Empty;
        }

        public override IReadOnlyDictionary<string, string> Features
        {
            get { return _features; }
            protected set
            {
                ImmutableDictionary<string, string> dictionary = value as ImmutableDictionary<string, string>;
                if (dictionary == null) dictionary = value.ToImmutableDictionary();
                _features = dictionary;
            }
        }

        public override void ValidateOptions(ArrayBuilder<Diagnostic> builder)
        {
            ValidateOptions(builder, MessageProvider.Instance);

            if (!PreprocessorSymbols.IsDefaultOrEmpty)
            {
                foreach (var symbol in PreprocessorSymbols)
                {
                    if (symbol == null)
                    {
                        builder.Add(LanguageDiagnostic.Create(CSharpErrorCode.ERR_InvalidPreprocessingSymbol, "null"));
                    }
                }
            }
        }

    }
}
