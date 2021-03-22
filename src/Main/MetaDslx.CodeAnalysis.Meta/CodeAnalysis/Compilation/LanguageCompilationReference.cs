// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MetaDslx.CodeAnalysis;
using System.Collections.Immutable;
using System.Diagnostics;

namespace MetaDslx.CodeAnalysis
{
    /// <summary>
    /// Represents a reference to another compilation. 
    /// </summary>
    [DebuggerDisplay("{GetDebuggerDisplay(), nq}")]
    internal sealed class LanguageCompilationReference : CompilationReference
    {
        /// <summary>
        /// Returns the referenced Compilation.
        /// </summary>
        public new LanguageCompilation Compilation { get; }

        internal override Compilation CompilationCore
        {
            get { return this.Compilation; }
        }

        /// <summary>
        /// Create a metadata reference to a compilation.
        /// </summary>
        /// <param name="compilation">The compilation to reference.</param>
        /// <param name="aliases">Extern aliases for this reference.</param>
        /// <param name="embedInteropTypes">Should interop types be embedded in the created assembly?</param>
        public LanguageCompilationReference(
            LanguageCompilation compilation,
            ImmutableArray<string> aliases = default(ImmutableArray<string>),
            bool embedInteropTypes = false)
            : base(GetProperties(compilation, aliases, embedInteropTypes))
        {
            this.Compilation = compilation;
        }

        private LanguageCompilationReference(LanguageCompilation compilation, MetadataReferenceProperties properties)
            : base(properties)
        {
            this.Compilation = compilation;
        }

        internal override CompilationReference WithPropertiesImpl(MetadataReferenceProperties properties)
        {
            return new LanguageCompilationReference(Compilation, properties);
        }

        private string GetDebuggerDisplay()
        {
            return string.Format("Compilation ({0}): {1}", this.Compilation.Language, this.Compilation.AssemblyName);
        }
    }
}
