// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using MetaDslx.Compiler.Utilities;

namespace MetaDslx.Compiler
{
    /// <summary>
    /// Reference to another C# or VB compilation.
    /// </summary>
    public abstract class CompilationReference : MetadataReference, IEquatable<CompilationReference>
    {
        public Compilation Compilation { get { return CompilationCore; } }
        internal abstract Compilation CompilationCore { get; }

        internal CompilationReference(MetadataReferenceProperties properties)
            : base(properties)
        {
        }

        internal static MetadataReferenceProperties GetProperties(Compilation compilation, ImmutableArray<string> aliases, bool embedInteropTypes)
        {
            if (compilation == null)
            {
                throw new ArgumentNullException(nameof(compilation));
            }

            if (compilation.IsSubmission)
            {
                throw new NotSupportedException(CompilerResources.CannotCreateReferenceToSubmission);
            }

            return new MetadataReferenceProperties(aliases, embedInteropTypes);
        }

        /// <summary>
        /// Returns an instance of the reference with specified aliases.
        /// </summary>
        /// <param name="aliases">The new aliases for the reference.</param>
        /// <exception cref="ArgumentException">Alias is invalid for the metadata kind.</exception> 
        public new CompilationReference WithAliases(IEnumerable<string> aliases)
        {
            return this.WithAliases(ImmutableArray.CreateRange(aliases));
        }

        /// <summary>
        /// Returns an instance of the reference with specified aliases.
        /// </summary>
        /// <param name="aliases">The new aliases for the reference.</param>
        /// <exception cref="ArgumentException">Alias is invalid for the metadata kind.</exception> 
        public new CompilationReference WithAliases(ImmutableArray<string> aliases)
        {
            return WithProperties(Properties.WithAliases(aliases));
        }

        /// <summary>
        /// Returns an instance of the reference with specified properties, or this instance if properties haven't changed.
        /// </summary>
        /// <param name="properties">The new properties for the reference.</param>
        /// <exception cref="ArgumentException">Specified values not valid for this reference.</exception> 
        public new CompilationReference WithProperties(MetadataReferenceProperties properties)
        {
            if (properties == this.Properties)
            {
                return this;
            }

            return WithPropertiesImpl(properties);
        }

        internal sealed override MetadataReference WithPropertiesImplReturningMetadataReference(MetadataReferenceProperties properties)
        {
            return WithPropertiesImpl(properties);
        }

        internal abstract CompilationReference WithPropertiesImpl(MetadataReferenceProperties properties);

        public override string Display
        {
            get
            {
                return Compilation.CompilationName;
            }
        }

        public bool Equals(CompilationReference other)
        {
            if (other == null)
            {
                return false;
            }

            if (object.ReferenceEquals(this, other))
            {
                return true;
            }

            // MetadataProperty implements value equality
            return object.Equals(this.Compilation, other.Compilation) && object.Equals(this.Properties, other.Properties);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as CompilationReference);
        }

        public override int GetHashCode()
        {
            return Hash.Combine(this.Compilation.GetHashCode(), this.Properties.GetHashCode());
        }
    }
}
