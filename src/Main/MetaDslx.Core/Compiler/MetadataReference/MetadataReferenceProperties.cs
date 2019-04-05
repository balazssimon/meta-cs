// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Immutable;
using MetaDslx.Compiler.Text;
using MetaDslx.Compiler.Utilities;

namespace MetaDslx.Compiler
{
    /// <summary>
    /// Information about a metadata reference.
    /// </summary>
    public struct MetadataReferenceProperties : IEquatable<MetadataReferenceProperties>
    {
        private readonly ImmutableArray<string> _aliases;

        /// <summary>
        /// Initializes reference properties.
        /// </summary>
        /// <param name="aliases">Assembly aliases. Can't be set for a module.</param>
        public MetadataReferenceProperties(ImmutableArray<string> aliases = default(ImmutableArray<string>))
        {
            _aliases = aliases;
            HasRecursiveAliases = false;
        }

        internal MetadataReferenceProperties(ImmutableArray<string> aliases, bool hasRecursiveAliases)
            : this(aliases)
        {
            HasRecursiveAliases = hasRecursiveAliases;
        }

        /// <summary>
        /// Returns <see cref="MetadataReferenceProperties"/> with specified aliases.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// <see cref="Kind"/> is <see cref="MetadataImageKind.Module"/>, as modules can't be aliased.
        /// </exception>
        public MetadataReferenceProperties WithAliases(IEnumerable<string> aliases)
        {
            return WithAliases(aliases.AsImmutableOrEmpty());
        }

        /// <summary>
        /// Returns <see cref="MetadataReferenceProperties"/> with specified aliases.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// <see cref="Kind"/> is <see cref="MetadataImageKind.Module"/>, as modules can't be aliased.
        /// </exception>
        public MetadataReferenceProperties WithAliases(ImmutableArray<string> aliases)
        {
            return new MetadataReferenceProperties(aliases, HasRecursiveAliases);
        }

        /// <summary>
        /// Returns <see cref="MetadataReferenceProperties"/> with <see cref="HasRecursiveAliases"/> set to specified value.
        /// </summary>
        internal MetadataReferenceProperties WithRecursiveAliases(bool value)
        {
            return new MetadataReferenceProperties(_aliases, value);
        }

        /// <summary>
        /// Alias that represents a global declaration space.
        /// </summary>
        /// <remarks>
        /// Namespaces in references whose <see cref="Aliases"/> contain <see cref="GlobalAlias"/> are available in global declaration space.
        /// </remarks>
        public static string GlobalAlias => "global";

        /// <summary>
        /// Aliases for the metadata reference. Empty if the reference has no aliases.
        /// </summary>
        /// <remarks>
        /// In C# these aliases can be used in "extern alias" syntax to disambiguate type names. 
        /// </remarks>
        public ImmutableArray<string> Aliases
        {
            get
            {
                // Simplify usage - we can't avoid the _aliases field being null but we can always return empty array here:
                return _aliases.NullToEmpty();
            }
        }

        /// <summary>
        /// True to apply <see cref="Aliases"/> recursively on the target assembly and on all its transitive dependencies.
        /// False to apply <see cref="Aliases"/> only on the target assembly.
        /// </summary>
        internal bool HasRecursiveAliases { get; private set; }

        public override bool Equals(object obj)
        {
            return obj is MetadataReferenceProperties && Equals((MetadataReferenceProperties)obj);
        }

        public bool Equals(MetadataReferenceProperties other)
        {
            return Aliases.SequenceEqual(other.Aliases)
                && HasRecursiveAliases == other.HasRecursiveAliases;
        }

        public override int GetHashCode()
        {
            return Hash.Combine(HasRecursiveAliases, Hash.CombineValues(Aliases));
        }

        public static bool operator ==(MetadataReferenceProperties left, MetadataReferenceProperties right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(MetadataReferenceProperties left, MetadataReferenceProperties right)
        {
            return !left.Equals(right);
        }
    }
}
