// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Reflection.PortableExecutable;

namespace MetaDslx.Compiler
{
    /// <summary>
    /// Represents metadata image reference.
    /// </summary>
    /// <remarks>
    /// Represents a logical location of the image, not the content of the image. 
    /// The content might change in time. A snapshot is taken when the compiler queries the reference for its metadata.
    /// </remarks>
    public abstract class MetadataReference
    {
        public MetadataReferenceProperties Properties { get; }

        protected MetadataReference(MetadataReferenceProperties properties)
        {
            this.Properties = properties;
        }

        /// <summary>
        /// Path or name used in error messages to identity the reference.
        /// </summary>
        public virtual string Display { get { return null; } }

        /// <summary>
        /// Returns true if this reference is an unresolved reference.
        /// </summary>
        internal virtual bool IsUnresolved
        {
            get { return false; }
        }

        /// <summary>
        /// Returns an instance of the reference with specified aliases.
        /// </summary>
        /// <param name="aliases">The new aliases for the reference.</param>
        /// <exception cref="ArgumentException">Alias is invalid for the metadata kind.</exception> 
        public MetadataReference WithAliases(IEnumerable<string> aliases)
        {
            return WithAliases(ImmutableArray.CreateRange(aliases));
        }

        /// <summary>
        /// Returns an instance of the reference with specified aliases.
        /// </summary>
        /// <param name="aliases">The new aliases for the reference.</param>
        /// <exception cref="ArgumentException">Alias is invalid for the metadata kind.</exception> 
        public MetadataReference WithAliases(ImmutableArray<string> aliases)
        {
            return WithProperties(Properties.WithAliases(aliases));
        }

        /// <summary>
        /// Returns an instance of the reference with specified properties, or this instance if properties haven't changed.
        /// </summary>
        /// <param name="properties">The new properties for the reference.</param>
        /// <exception cref="ArgumentException">Specified values not valid for this reference.</exception>
        public MetadataReference WithProperties(MetadataReferenceProperties properties)
        {
            if (properties == this.Properties)
            {
                return this;
            }

            return WithPropertiesImplReturningMetadataReference(properties);
        }

        internal abstract MetadataReference WithPropertiesImplReturningMetadataReference(MetadataReferenceProperties properties);
    }
}
